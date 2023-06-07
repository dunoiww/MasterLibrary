﻿using MasterLibrary.DTOs;
using MasterLibrary.Models.DataProvider;
using MasterLibrary.Utils;
using MasterLibrary.Views.Customer;
using MasterLibrary.Views.Customer.BuyBookPage;
using MasterLibrary.Views.MessageBoxML;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MasterLibrary.ViewModel.CustomerVM.BuyBookVM
{
    public class DetailBookViewModel: BaseViewModel
    {
        #region Thuộc tính
        private BookDTO _BookCurrent;
        public BookDTO BookCurrent
        {
            get { return _BookCurrent; }
            set
            {
                _BookCurrent = value;
                OnPropertyChanged();
            }
        }

        private int _soluongBook;
        public int soluongBook
        {
            get { return _soluongBook; }
            set
            {
                _soluongBook = value;
                OnPropertyChanged();
            }
        }

        private int _Quantity;
        public int Quantity
        {
            get { return _Quantity; }
            set 
            {
                _Quantity = (int)value;
                OnPropertyChanged();
            }
        }

        private decimal _TotalTien;
        public decimal TotalTien
        {
            get { return _TotalTien; }
            set
            {
                _TotalTien = value;
                OnPropertyChanged();
            }
        }

        private string _TotalTienStr;
        public string TotalTienStr
        {
            get { return _TotalTienStr; }
            set
            {
                _TotalTienStr = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<ReviewDTO> _ListReview;
        public ObservableCollection<ReviewDTO> ListReview
        {
            get { return _ListReview; }
            set { _ListReview = value; OnPropertyChanged(); }
        }

        #endregion

        #region ICommand
        public ICommand FirstLoadML { get; set; }
        public ICommand CloseDetailBook { get; set; }
        public ICommand MinusCommand { get; set; }
        public ICommand PlusCommand { get; set; }
        public ICommand AddCart { get; set; }
        public ICommand BuyIt { get; set; }
        public ICommand QuantityChange { get; set; }
        public ICommand CheckNullTxb { get; set; }

        #endregion

        #region thuộc tính tạm thời
        public static int selectBookId { get; set; }

        #endregion

        public DetailBookViewModel()
        {
            // Load lần đầu
            FirstLoadML = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                BookCurrent = await BookServices.Ins.GetBook(selectBookId);
                ListReview = new ObservableCollection<ReviewDTO>(await ReviewServices.Ins.GetAllReview(BookCurrent.MaSach));
                soluongBook = BookCurrent.SoLuong;
                Quantity = 0;
                TotalTien = 0;
                TotalTienStr = Helper.FormatVNMoney(TotalTien);
            });

            // Đóng trang detailBook
            CloseDetailBook = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                DetailBookService w = Application.Current.Windows.OfType<DetailBookService>().FirstOrDefault();
                w.Close();
                BuyBookViewModel.MaskName.Visibility = Visibility.Collapsed;
            });

            // Giảm số lượng
            MinusCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                --Quantity;
            });

            // Tăng số lượng
            PlusCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                ++Quantity;
            });

            // Thêm vào giỏ hàng
            AddCart = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                if (Quantity == 0)
                {
                    MessageBoxML ms = new MessageBoxML("Thông báo", "Số lượng bằng 0 nên không thực hiện được thao tác", MessageType.Error, MessageButtons.OK);
                    ms.ShowDialog();
                    return;
                }

                (bool isAddCart, string lb) = await BookInCartServices.Ins.AddBookInCart(MainCustomerViewModel.CurrentCustomer.MAKH, selectBookId, Quantity, BookCurrent.SoLuong);
                
                if (isAddCart == true)
                {
                    Quantity = 0;
                    MessageBoxML ms = new MessageBoxML("Thông báo", lb, MessageType.Accept, MessageButtons.OK);
                    ms.ShowDialog();
                }
                else
                {
                    MessageBoxML ms = new MessageBoxML("Lỗi", lb, MessageType.Error, MessageButtons.OK);
                    ms.ShowDialog();
                }
            });

            // Mua ngay
            BuyIt = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                if (string.IsNullOrEmpty(MainCustomerViewModel.CurrentCustomer.DIACHI) == true)
                {
                    MessageBoxML ms = new MessageBoxML("Thông báo", "Vui lòng vào cài đặt để cập nhật địa chỉ của bạn để mua hàng", MessageType.Error, MessageButtons.OK);
                    ms.ShowDialog();

                    return;
                }

                if (Quantity == 0)
                {
                    MessageBoxML ms = new MessageBoxML("Thông báo", "Số lượng bằng 0 nên không thực hiện mua được", MessageType.Error, MessageButtons.OK);
                    ms.ShowDialog();
                    return;
                }

                decimal totalTien = TotalTien;

                List<BillDetailDTO> newbillDetailList = new List<BillDetailDTO>
                    {
                        new BillDetailDTO
                        {
                            MaSach = BookCurrent.MaSach,
                            SoLuong = Quantity,
                            GiaMoiCai = BookCurrent.Gia
                        }
                    };

                BillDTO bill = new BillDTO
                {
                    NGHD = DateTime.Now,
                    MAKH = MainCustomerViewModel.CurrentCustomer.MAKH,
                    TRIGIA = totalTien,
                    TRANGTHAI = "Chờ xác nhận",
                    ISRECEIVED = 0
                };

                // Tạo hoá đơn mới
                int billId = await BuyServices.Ins.CreateNewBill(bill);

                //Tạo các chi tiết hoá đơn

                (bool isCreate, string lb) = await BuyServices.Ins.CreateNewBillDetail(billId, newbillDetailList);

                if (isCreate == true)
                {
                    BookCurrent.SoLuong -= Quantity;
                    soluongBook = BookCurrent.SoLuong;
                    Quantity = 0;

                    MessageBoxML ms = new MessageBoxML("Thông báo", "Vui lòng vào Đơn hàng để theo dõi tình trạng đơn hàng của bạn!", MessageType.Accept, MessageButtons.OK);
                    ms.ShowDialog();
                }
                else
                {
                    MessageBoxML ms = new MessageBoxML("Thông báo", lb, MessageType.Error, MessageButtons.OK);
                    ms.ShowDialog();
                }
            });

            // Thay đổi số lượng
            QuantityChange = new RelayCommand<Label>((p) => { return true; }, (p) =>
            {
                if (Quantity > BookCurrent.SoLuong)
                {
                    Quantity = BookCurrent.SoLuong;
                    p.Content = "Vượt số lượng hiện có.";
                }
                else if (Quantity < 0)
                {
                    Quantity = 0;
                    p.Content = "Không còn sách để giảm.";
                }
                else
                {
                    p.Content = "";
                }
                
                //if (Quantity >= 0)
                //{
                //    p.Content = "";
                //}

                //if (Quantity < 0)
                //{
                //    Quantity = 0;
                //    p.Content = "Số lượng sách đã là nhỏ nhất";
                //}

                TotalTien = Quantity * BookCurrent.Gia;
                TotalTienStr = Helper.FormatVNMoney(TotalTien);
            });

            // Kiểm tra null của textbox
            CheckNullTxb = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                if (string.IsNullOrEmpty(p.Text) || p.Text == "0")
                {
                    Quantity = 0;
                }

                TotalTien = Quantity * BookCurrent.Gia;
                TotalTienStr = Helper.FormatVNMoney(TotalTien);
            });
        }
    }
}
