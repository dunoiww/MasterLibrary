using MasterLibrary.DTOs;
using MasterLibrary.Models.DataProvider;
using MasterLibrary.Views.Customer.DeliveryPage;
using MasterLibrary.Views.MessageBoxML;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using ComboBox = System.Windows.Controls.ComboBox;

namespace MasterLibrary.ViewModel.CustomerVM.DeliveryVM
{
    public class DeliveryViewModel : BaseViewModel
    {
        #region variable
        private bool _IsGettingSource;
        public bool IsGettingSource
        {
            get { return _IsGettingSource; }
            set { _IsGettingSource = value; OnPropertyChanged(); }
        }

        public static Grid MaskName { get; set; }

        //Variable of page Process
        private ComboBoxItem _SelectedDeliveryFilter;
        public ComboBoxItem SelectedDeliveryFilter
        {
            get => _SelectedDeliveryFilter;
            set { _SelectedDeliveryFilter = value; OnPropertyChanged(); }
        }

        private int _SelectedDeliveryMonth;
        public int SelectedDeliveryMonth
        {
            get { return _SelectedDeliveryMonth; }
            set { _SelectedDeliveryMonth = value; OnPropertyChanged(); }
        }

        private int _SelectedDeliveryYear;
        public int SelectedDeliveryYear
        {
            get { return _SelectedDeliveryYear; }
            set { _SelectedDeliveryYear = value; OnPropertyChanged(); }
        }

        private BillDTO _SelectedProcessItem;
        public BillDTO SelectedProcessItem
        {
            get { return _SelectedProcessItem; }
            set { _SelectedProcessItem = value; OnPropertyChanged(); }
        }

        private ObservableCollection<BillDTO> _ListProcess;
        public ObservableCollection<BillDTO> ListProcess
        {
            get { return _ListProcess; }
            set { _ListProcess = value; OnPropertyChanged(); }
        }

        //Variable of page Finish
        private ComboBoxItem _SelectedFinishFilter;
        public ComboBoxItem SelectedFinishFilter
        {
            get => _SelectedFinishFilter;
            set { _SelectedFinishFilter = value; OnPropertyChanged(); }
        }

        private int _SelectedFinishMonth;
        public int SelectedFinishMonth
        {
            get { return _SelectedFinishMonth; }
            set { _SelectedFinishMonth = value; OnPropertyChanged(); }
        }

        private int _SelectedFinishYear;
        public int SelectedFinishYear
        {
            get { return _SelectedFinishYear; }
            set { _SelectedFinishYear = value; OnPropertyChanged(); }
        }

        private ObservableCollection<BillDTO> _ListFinish;
        public ObservableCollection<BillDTO> ListFinish
        {
            get { return _ListFinish; }
            set { _ListFinish = value; OnPropertyChanged(); }
        }

        private BillDTO _SelectedFinishBook;
        public BillDTO SelectedFinishBook
        {
            get { return _SelectedFinishBook; }
            set { _SelectedFinishBook = value; OnPropertyChanged(); }
        }

        //Variable của window review
        private static double _RatingStar;
        public static double RatingStar
        {
            get { return _RatingStar; }
            set { _RatingStar = value; }
        }

        private string _ReviewText;
        public string ReviewText
        {
            get { return _ReviewText; }
            set { _ReviewText = value; OnPropertyChanged(); }   
        }

        private BookDTO _CurrentBook;
        public BookDTO CurrentBook
        {
            get { return _CurrentBook; }
            set { _CurrentBook = value; OnPropertyChanged(); }
        }



        #endregion

        #region Icommand
        //Icommand của page chung
        public ICommand LoadProcessPage { get; set; }
        public ICommand LoadFinishPage { get; set; }
        public ICommand MaskNameML { get; set; }
        public ICommand closeML { get; set; }


        //Icommand của page xử lý
        public ICommand CheckSelectedDeliveryFilterML { get; set; }
        public ICommand SelectedDeliveryMonthML { get; set; }
        public ICommand SelectedDeliveryYearML { get; set; }
        public ICommand ReceivedBook { get; set; }


        //Icommand của page finish
        public ICommand CheckSelectedFinishFilterML { get; set; }
        public ICommand SelectedFinishMonthML { get; set; }
        public ICommand SelectedFinishYearML { get; set; }
        public ICommand OpenReviewBook { get; set; }

        //Icommand của window review book
        public ICommand CloseReviewBook { get; set; }
        public ICommand UpdateReviewBook { get; set; }
        #endregion

        public DeliveryViewModel() {

            //Load dữ liệu ban đầu
            SelectedDeliveryMonth = DateTime.Now.Month;
            SelectedDeliveryYear = DateTime.Now.Year;

            MaskNameML = new RelayCommand<Grid>((p) => { return true; }, (p) => { MaskName = p; });
            closeML = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                MaskName.Visibility = Visibility.Collapsed;
                p.Close();
            });

            LoadProcessPage = new RelayCommand<Frame>((p) => { return true; }, async (p) =>
            {
                IsGettingSource = true;
                ListProcess = new ObservableCollection<BillDTO>();
                await GetListProcessSource("");
                IsGettingSource = false;
                DeNotFinish page = new DeNotFinish();
                p.Content = page;
            });

            LoadFinishPage = new RelayCommand<Frame>((p) => { return true; }, async (p) =>
            {
                IsGettingSource = true;
                ListFinish = new ObservableCollection<BillDTO>();
                await GetListFinishSource("");
                IsGettingSource = false;
                DeFinish page = new DeFinish();
                p.Content = page;
            });

            //Process page
            CheckSelectedDeliveryFilterML = new RelayCommand<ComboBox>((p) => { return true; }, async (p) =>
            {
                await checkDeliveryFilter();
            });

            SelectedDeliveryMonthML = new RelayCommand<ComboBox>((p) => { return true; }, async (p) =>
            {
                await checkDeliveryMonthFilter();
            });

            SelectedDeliveryYearML = new RelayCommand<ComboBox>((p) => { return true; }, async (p) =>
            {
                await checkDeliveryMonthFilter();
            });

            ReceivedBook = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                await UpdateReceivedBook();
            });


            //Finish page
            CheckSelectedFinishFilterML = new RelayCommand<ComboBox>((p) => { return true; }, async (p) =>
            {
                await checkFinishFilter();
            });

            SelectedFinishMonthML = new RelayCommand<ComboBox>((p) => { return true; }, async (p) =>
            {
                await checkFinishMonthFilter();
            });

            SelectedFinishYearML = new RelayCommand<ComboBox>((p) => { return true; }, async (p) =>
            {
                await checkFinishMonthFilter();
            });

            //window review book
            OpenReviewBook = new RelayCommand<Window>((p) => { return true; }, async (p) =>
            {
                GetCurrentBook();

                MaskName.Visibility = Visibility.Visible;

                bool isExistCus = await Task.Run(() => ReviewServices.Ins.FindCusReview(MainCustomerViewModel.CurrentCustomer.MAKH, SelectedFinishBook.MASACH));
                if (isExistCus)
                {
                    MessageBoxML mb = new MessageBoxML("Thông báo", "Bạn đã nhận xét sản phầm này rồi, có muốn nhận xét lại?", MessageType.Accept, MessageButtons.YesNo);
                    mb.ShowDialog();
                    if ((bool)mb.DialogResult)
                    {
                        ReviewBook rb = new ReviewBook();
                        rb.ShowDialog();
                    }
                }
                else
                {
                    ReviewBook rb = new ReviewBook();
                    rb.ShowDialog();
                }

                MaskName.Visibility = Visibility.Collapsed;
            });

            CloseReviewBook = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                ReviewText = string.Empty;
                RatingStar = 0;
                p.Close();
            });

            UpdateReviewBook = new RelayCommand<Window>((p) => { return true; }, async (p) =>
            {
                updateReview();
            });
        }

        

        #region Task Process
        public async Task GetListProcessSource(string s = "")
        {
            ListProcess = new ObservableCollection<BillDTO>();
            switch (s)
            {
                case "":
                    {
                        try
                        {
                            IsGettingSource = true;
                            ListProcess = new ObservableCollection<BillDTO>(await BillServices.Ins.GetAllBillByCus(MainCustomerViewModel.CurrentCustomer.MAKH));
                            IsGettingSource = false;
                            return;
                        }
                        catch (System.Data.Entity.Core.EntityException e)
                        {
                            MessageBoxML mb = new MessageBoxML("Lỗi", "Mất kết nối cơ sở dữ liệu", MessageType.Error, MessageButtons.OK);
                            mb.ShowDialog();
                            throw;
                        }
                        catch
                        {
                            MessageBoxML mb = new MessageBoxML("Lỗi", "Lỗi hệ thống", MessageType.Error, MessageButtons.OK);
                            mb.ShowDialog();
                            throw;
                        }
                    }

                case "month":
                    {
                        IsGettingSource = true;
                        await checkDeliveryMonthFilter();
                        IsGettingSource = false;
                        return;
                    }
            }

        }

        public async Task checkDeliveryMonthFilter()
        {
            try
            {
                ListProcess = new ObservableCollection<BillDTO>(await BillServices.Ins.GetAllBillByCusByMonth(MainCustomerViewModel.CurrentCustomer.MAKH, SelectedDeliveryMonth, SelectedDeliveryYear));
            }
            catch (System.Data.Entity.Core.EntityException e)
            {
                MessageBoxML mb = new MessageBoxML("Lỗi", "Mất kết nối cơ sở dữ liệu", MessageType.Error, MessageButtons.OK);
                mb.ShowDialog();
                throw;
            }
            catch
            {
                MessageBoxML mb = new MessageBoxML("Lỗi", "Lỗi hệ thống", MessageType.Error, MessageButtons.OK);
                mb.ShowDialog();
                throw;
            }
        }

        public async Task checkDeliveryFilter()
        {
            switch (SelectedDeliveryFilter.Content.ToString())
            {
                case "Toàn bộ":
                    {
                        await GetListProcessSource("");
                        return;
                    }

                case "Theo tháng":
                    {
                        await GetListProcessSource("month");
                        return;
                    }
            }
        }

        public async Task UpdateReceivedBook()
        {
            MessageBoxML ms = new MessageBoxML("Xác nhận", "Hãy chắc chắn rằng bạn đã nhận được đơn hàng này", MessageType.Accept, MessageButtons.YesNo);
            ms.ShowDialog();

            if ((bool)ms.DialogResult)
            {
                BillDTO newBill = new BillDTO()
                {
                    MAKH = SelectedProcessItem.MAKH,
                    cusId = (int)SelectedProcessItem.MAKH,
                    cusName = SelectedProcessItem.cusName,
                    cusAdd = SelectedProcessItem.cusAdd,
                    MAHD = SelectedProcessItem.MAHD,
                    TRIGIA = (decimal)SelectedProcessItem.TRIGIA,
                    NGHD = SelectedProcessItem.NGHD,
                    TRANGTHAI = "Giao hàng thành công",
                    TenSach = SelectedProcessItem.TenSach,
                    ISRECEIVED = 1
                };

                (bool isReceived, string lb) = await BillServices.Ins.UpdateReceivedBook(newBill);

                await checkDeliveryFilter();

                if (isReceived)
                {
                    MessageBoxML ms1 = new MessageBoxML("Thông báo", lb, MessageType.Accept, MessageButtons.OK);
                    ms1.ShowDialog();
                }
                else
                {
                    MessageBoxML ms1 = new MessageBoxML("Lỗi", lb, MessageType.Accept, MessageButtons.OK);
                    ms1.ShowDialog();
                }
            }
        }
        #endregion

        #region Task Finish
        public async Task GetListFinishSource(string s="")
        {
            ListFinish = new ObservableCollection<BillDTO>();
            switch (s)
            {
                case "":
                    {
                        try
                        {
                            IsGettingSource = true;
                            ListFinish = new ObservableCollection<BillDTO>(await BillServices.Ins.GetAllBillFinish(MainCustomerViewModel.CurrentCustomer.MAKH));
                            IsGettingSource = false;
                            return;
                        }
                        catch (System.Data.Entity.Core.EntityException e)
                        {
                            MessageBoxML mb = new MessageBoxML("Lỗi", "Mất kết nối cơ sở dữ liệu", MessageType.Error, MessageButtons.OK);
                            mb.ShowDialog();
                            throw;
                        }
                        catch
                        {
                            MessageBoxML mb = new MessageBoxML("Lỗi", "Lỗi hệ thống", MessageType.Error, MessageButtons.OK);
                            mb.ShowDialog();
                            throw;
                        }
                    }

                case "month":
                    {
                        IsGettingSource = true;
                        await checkFinishMonthFilter();
                        IsGettingSource = false;
                        return;
                    }
            }
        }

        public async Task checkFinishMonthFilter()
        {
            try
            {
                ListFinish = new ObservableCollection<BillDTO>(await BillServices.Ins.GetAllBillFinishByMonth(MainCustomerViewModel.CurrentCustomer.MAKH, SelectedDeliveryMonth, SelectedDeliveryYear));
            }
            catch (System.Data.Entity.Core.EntityException e)
            {
                MessageBoxML mb = new MessageBoxML("Lỗi", "Mất kết nối cơ sở dữ liệu", MessageType.Error, MessageButtons.OK);
                mb.ShowDialog();
                throw;
            }
            catch
            {
                MessageBoxML mb = new MessageBoxML("Lỗi", "Lỗi hệ thống", MessageType.Error, MessageButtons.OK);
                mb.ShowDialog();
                throw;
            }
        }

        public async Task checkFinishFilter()
        {
            switch (SelectedFinishFilter.Content.ToString())
            {
                case "Toàn bộ":
                    {
                        await GetListFinishSource("");
                        return;
                    }

                case "Theo tháng":
                    {
                        await GetListFinishSource("month");
                        return;
                    }
            }
        }
        #endregion

        #region Task review
        public async Task updateReview()
        {
            if (RatingStar == 0 || string.IsNullOrEmpty(ReviewText))
            {
                MessageBoxML ms = new MessageBoxML("Thông báo", "Bạn chưa điền đầy đủ thông tin đánh giá.", MessageType.Error, MessageButtons.OK);
                ms.ShowDialog();
            }
            else
            {
                string reviewText = ReviewText;

                (bool isRating, string lb) = await BookServices.Ins.UpdateReview(CurrentBook.MaSach, RatingStar);

                if (isRating)
                {
                    (bool isReviewed, string lb2) = await ReviewServices.Ins.AddReview(MainCustomerViewModel.CurrentCustomer.MAKH, CurrentBook.MaSach, reviewText);

                    if (isReviewed)
                    {
                        MessageBoxML mb = new MessageBoxML("Thông báo", lb2, MessageType.Accept, MessageButtons.OK);
                        mb.ShowDialog();
                    }
                    else
                    {
                        MessageBoxML mb = new MessageBoxML("Lỗi", lb2, MessageType.Accept, MessageButtons.OK);
                        mb.ShowDialog();
                    }
                }
                else
                {
                    MessageBoxML mb = new MessageBoxML("Lỗi", lb, MessageType.Accept, MessageButtons.OK);
                    mb.ShowDialog();
                }
            }
            
        }

        public async Task GetCurrentBook()
        {
            CurrentBook = await BookServices.Ins.GetBook(SelectedFinishBook.MASACH);
        }

        #endregion
    }
}
