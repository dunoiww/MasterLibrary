using MasterLibrary.DTOs;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;
using ComboBox = System.Windows.Controls.ComboBox;
using DatePicker = System.Windows.Controls.DatePicker;
using ComboBoxItem = System.Windows.Controls.ComboBoxItem;
using Grid = System.Windows.Controls.Grid;
using MasterLibrary.Views.Admin.HistoryPage;
using System.Windows.Forms;
using SaveFileDialog = System.Windows.Forms.SaveFileDialog;
using MasterLibrary.Views.MessageBoxML;
using MasterLibrary.Models.DataProvider;
using System.Windows;
using JetBrains.Annotations;
using MessageBox = System.Windows.Forms.MessageBox;
using MaterialDesignThemes.Wpf;
using MasterLibrary.Views.Customer;
using MasterLibrary.ViewModel.CustomerVM;
using MasterLibrary.Utils;

namespace MasterLibrary.ViewModel.AdminVM.HistoryVM
{
    public class HistoryViewModel : BaseViewModel
    {

        #region property

        private int view = 0;
        private bool _IsGettingSource;
        public bool IsGettingSource 
        {
            get => _IsGettingSource;
            set { _IsGettingSource = value; OnPropertyChanged(); }
        }

        private DateTime _getCurrentDate;
        public DateTime GetCurrentDate
        {
            get => _getCurrentDate; 
            set { _getCurrentDate = value; }
        }

        private string _setCurrentDate;
        public string SetCurrentDate
        {
            get => _setCurrentDate;
            set { _setCurrentDate = value; }
        }

        private DateTime _SelectedRevenueDate;
        public DateTime SelectedRevenueDate
        {
            get => _SelectedRevenueDate;
            set { _SelectedRevenueDate = value; OnPropertyChanged(); } 
        }

        private ComboBoxItem _SelectedRevenueFilter;
        public ComboBoxItem SelectedRevenueFilter
        { 
            get => _SelectedRevenueFilter; 
            set { _SelectedRevenueFilter = value; OnPropertyChanged(); } 
        }

        private ComboBoxItem _SelectedExpenseFilter;
        public ComboBoxItem SelectedExpenseFilter
        {
            get => _SelectedExpenseFilter;
            set { _SelectedExpenseFilter = value; OnPropertyChanged(); }
        }

        private ComboBoxItem _SelectedTroubleFilter;
        public ComboBoxItem SelectedTroubleFilter
        {
            get => _SelectedTroubleFilter;
            set { _SelectedTroubleFilter = value; OnPropertyChanged(); }
        }

        private ComboBoxItem _SelectedCollectFilter;
        public ComboBoxItem SelectedCollectFilter
        {
            get => _SelectedCollectFilter;
            set { _SelectedCollectFilter = value; OnPropertyChanged(); }
        }

        private ComboBoxItem _SelectedBorrowFilter;
        public ComboBoxItem SelectedBorrowFilter
        {
            get => _SelectedBorrowFilter;
            set { _SelectedBorrowFilter = value; OnPropertyChanged(); }
        }

        private int _SelectedRevenueMonth;
        public int SelectedRevenueMonth
        { 
            get => _SelectedRevenueMonth; 
            set { _SelectedRevenueMonth = value; OnPropertyChanged(); } 
        }

        private int _SelectedRevenueYear;
        public int SelectedRevenueYear
        {
            get => _SelectedRevenueYear;
            set { _SelectedRevenueYear = value; OnPropertyChanged(); }
        }

        private int _SelectedExpenseMonth;
        public int SelectedExpenseMonth
        {
            get => _SelectedExpenseMonth;
            set { _SelectedExpenseMonth = value; OnPropertyChanged(); }
        }

        private int _SelectedExpenseYear;
        public int SelectedExpenseYear
        {
            get => _SelectedExpenseYear;
            set { _SelectedExpenseYear = value; OnPropertyChanged(); }
        }

        private int _SelectedTroubleYear;
        public int SelectedTroubleYear
        {
            get => _SelectedTroubleYear;
            set { _SelectedTroubleYear = value; OnPropertyChanged(); }
        }

        private int _SelectedTroubleMonth;
        public int SelectedTroubleMonth
        {
            get => _SelectedTroubleMonth;
            set { _SelectedTroubleMonth = value; OnPropertyChanged(); }
        }

        private int _SelectedCollectMonth;
        public int SelectedCollectMonth
        {
            get => _SelectedCollectMonth;
            set { _SelectedCollectMonth = value; OnPropertyChanged(); }
        }

        private int _SelectedCollectYear;
        public int SelectedCollectYear
        {
            get => _SelectedCollectYear;
            set { _SelectedCollectYear = value; OnPropertyChanged(); }
        }

        private int _SelectedBorrowMonth;
        public int SelectedBorrowMonth
        {
            get => _SelectedBorrowMonth;
            set { _SelectedBorrowMonth = value; OnPropertyChanged(); }
        }

        private int _SelectedBorrowYear;
        public int SelectedBorrowYear
        {
            get => _SelectedBorrowYear;
            set { _SelectedBorrowYear = value; OnPropertyChanged(); }
        }

        private int _CountConfirm;
        public int CountConfirm
        {
            get => _CountConfirm;
            set { _CountConfirm = value; OnPropertyChanged(); }
        }

        private int _CountCancel;
        public int CountCancel
        {
            get => _CountCancel;
            set { _CountCancel = value; OnPropertyChanged(); }
        }

        private int _CountSuccess;
        public int CountSuccess
        {
            get => _CountSuccess;
            set { _CountSuccess = value; OnPropertyChanged(); }
        }

        private int _CountDelivery;
        public int CountDelivery
        {
            get => _CountDelivery;
            set { _CountDelivery = value; OnPropertyChanged(); }
        }

        private BillDTO _SelectedItemRevenue;
        public BillDTO SelectedItemRevenue
        {
            get => _SelectedItemRevenue;
            set { _SelectedItemRevenue = value; OnPropertyChanged(); }
        }

        private BookInBorrowDTO _SelectedBorrowItem;
        public BookInBorrowDTO SelectedBorrowItem
        {
            get => _SelectedBorrowItem;
            set { _SelectedBorrowItem = value; OnPropertyChanged(); }
        }

        private BillDTO _DetailRevenue;
        public BillDTO DetailRevenue
        {
            get => _DetailRevenue;
            set { _DetailRevenue = value; OnPropertyChanged(); }
        }

        public static Grid MaskName { get; set; }

        private ObservableCollection<InputBookDTO> _ListExpense;
        public ObservableCollection<InputBookDTO> ListExpense
        {
            get => _ListExpense;
            set { _ListExpense = value; OnPropertyChanged(); }
        }

        private ObservableCollection<BillDTO> _ListRevenue;
        public ObservableCollection<BillDTO> ListRevenue
        {
            get => _ListRevenue;
            set { _ListRevenue = value; OnPropertyChanged(); }
        }

        private ObservableCollection<TroubleDTO> _ListTrouble;
        public ObservableCollection<TroubleDTO> ListTrouble
        {
            get => _ListTrouble;
            set { _ListTrouble = value; OnPropertyChanged(); }
        }

        private ObservableCollection<BookInCollectDTO> _ListCollect;
        public ObservableCollection<BookInCollectDTO> ListCollect
        {
            get => _ListCollect;
            set { _ListCollect = value; OnPropertyChanged(); }
        }

        private ObservableCollection<BookInBorrowDTO> _ListBorrow;
        public ObservableCollection<BookInBorrowDTO> ListBorrow
        {
            get => _ListBorrow;
            set { _ListBorrow = value; OnPropertyChanged(); }
        }

        private ObservableCollection<BillDetailDTO> _ListProduct;
        public ObservableCollection<BillDetailDTO> ListProduct
        {
            get => _ListProduct;
            set { _ListProduct = value; OnPropertyChanged();}
        }

        private ObservableCollection<BookInBorrowDTO> _ListBorrowByCus;
        public ObservableCollection<BookInBorrowDTO> ListBorrowByCus
        {
            get => _ListBorrowByCus;
            set { _ListBorrowByCus = value; OnPropertyChanged(); }
        }

        #endregion

        #region Icommand
        public ICommand LoadExpensePage { get; set; }
        public ICommand LoadRevenuePage { get; set; }
        public ICommand LoadTroublePage { get; set; }
        public ICommand LoadCollectPage { get; set; }
        public ICommand LoadBorrowPage { get; set; }
        public ICommand ExportFileML { get; set; }
        public ICommand MaskNameML { get; set; }
        public ICommand SelectedExpenseMonthML { get; set; }
        public ICommand SelectedExpenseYearML { get; set; }
        public ICommand CheckSelectedExpenseFilterML { get; set; }
        public ICommand CheckSelectedRevenueFilterML { get; set; }
        public ICommand CheckSelectedTroubleFilterML { get; set; }
        public ICommand CheckSelectedCollectFilterML { get; set; }
        public ICommand CheckSelectedBorrowFilterML { get; set; }
        public ICommand SelectedRevenueMonthML { get; set; }
        public ICommand SelectedRevenueYearML { get; set; }
        public ICommand SelectedRevenueDateML { get; set; }
        public ICommand SelectedTroubleMonthML { get; set; }
        public ICommand SelectedTroubleYearML { get; set; }
        public ICommand SelectedCollectMonthML { get; set; }
        public ICommand SelectedCollectYearML { get; set; }
        public ICommand SelectedBorrowMonthML { get; set; }
        public ICommand SelectedBorrowYearML { get; set; }
        public ICommand LoadInforRevenueML { get; set; }
        public ICommand LoadInfoBorrow { get; set; }
        public ICommand closeML { get; set; }

        public ICommand ConfirmBill { get; set; }
        public ICommand CancelBill { get; set; }
        #endregion

        public HistoryViewModel()
        {
            #region SetTime
            GetCurrentDate = DateTime.Today;
            SelectedRevenueDate = GetCurrentDate;
            SelectedRevenueMonth = DateTime.Now.Month - 1;
            SelectedExpenseMonth = DateTime.Now.Month - 1;
            SelectedTroubleMonth = DateTime.Now.Month - 1;
            SelectedCollectMonth = DateTime.Now.Month - 1;
            SelectedBorrowMonth = DateTime.Now.Month - 1;
            SelectedRevenueYear = DateTime.Now.Year;
            SelectedExpenseYear = DateTime.Now.Year;
            SelectedTroubleYear = DateTime.Now.Year;
            SelectedCollectYear = DateTime.Now.Year;
            SelectedBorrowYear = DateTime.Now.Year;
            #endregion

            MaskNameML = new RelayCommand<Grid>((p) => { return true; }, (p) => { MaskName = p; });
            closeML = new RelayCommand<Window>((p) => { return true; }, (p) =>
            { 
                MaskName.Visibility = Visibility.Collapsed;
                SelectedItemRevenue = null;
                p.Close();
            });

            #region oldIcommand
            SelectedExpenseMonthML = new RelayCommand<ComboBox>((p) => { return true; }, async (p) =>
            {
                await checkExpenseMonthFilter();
            });

            SelectedExpenseYearML = new RelayCommand<ComboBox>((p) => { return true; }, async (p) =>
            {
                await checkExpenseMonthFilter();
            });

            SelectedRevenueMonthML = new RelayCommand<ComboBox>((p) => { return true; }, async (p) =>
            {
                await checkRevenueMonthFilter();
            });

            SelectedRevenueYearML = new RelayCommand<ComboBox>((p) => { return true; }, async (p) =>
            {
                await checkRevenueMonthFilter();
            });

            SelectedTroubleMonthML = new RelayCommand<ComboBox>((p) => { return true; }, async (p) =>
            {
                await checkTroubleMonthFilter();
            });

            SelectedTroubleYearML = new RelayCommand<ComboBox>((p) => { return true; }, async (p) =>
            {
                await checkTroubleMonthFilter();
            });

            SelectedCollectMonthML = new RelayCommand<ComboBox>((p) => { return true; }, async (p) =>
            {
                await checkCollectMonthFilter();
            });

            SelectedCollectYearML = new RelayCommand<ComboBox>((p) => { return true; }, async (p) =>
            {
                await checkCollectMonthFilter();
            });

            SelectedBorrowMonthML = new RelayCommand<ComboBox>((p) => { return true; }, async (p) =>
            {
                await checkBorrowMonthFilter();
            });

            SelectedBorrowYearML = new RelayCommand<ComboBox>((p) => { return true; }, async (p) =>
            {
                await checkBorrowMonthFilter();
            });

            SelectedRevenueDateML = new RelayCommand<DatePicker>((p) => { return true; }, async (p) => 
            {
                await GetRevenueListSource("date");
            });

            CheckSelectedExpenseFilterML = new RelayCommand<ComboBox>((p) => { return true; }, async (p) =>
            {
                await checkExpenseFilter();
            });

            CheckSelectedRevenueFilterML = new RelayCommand<ComboBox>((p) => { return true; }, async (p) => 
            {
                await checkRevenueFilter();
            });

            CheckSelectedTroubleFilterML = new RelayCommand<ComboBox>((p) => { return true; }, async (p) =>
            {
                await checkTroubleFilter();
            });

            CheckSelectedCollectFilterML = new RelayCommand<ComboBox>((p) => { return true; }, async (p) =>
            {
                await checkCollectFilter();
            });

            CheckSelectedBorrowFilterML = new RelayCommand<ComboBox>((p) => { return true; }, async (p) =>
            {
                await checkBorrowFilter();
            });

            LoadExpensePage = new RelayCommand<Frame>((p) => { return true; }, async (p) => 
            {
                view = 0;
                IsGettingSource = true;
                ListExpense = new ObservableCollection<InputBookDTO>();
                await GetExpenseListSource("");
                IsGettingSource = false;
                ExpensePage page = new ExpensePage();
                p.Content = page;
            });

            LoadRevenuePage = new RelayCommand<Frame>((p) => { return true; }, async(p) =>
            {
                view = 1;
                IsGettingSource = true;
                ListRevenue = new ObservableCollection<BillDTO>();
                await GetRevenueListSource("");
                IsGettingSource=false;
                RevenuePage page = new RevenuePage();
                p.Content = page;
            });

            LoadTroublePage = new RelayCommand<Frame>((p) => { return true; }, async (p) =>
            {
                view = 2;
                IsGettingSource = true;
                ListTrouble = new ObservableCollection<TroubleDTO>();
                await GetTroubleListSource("");
                IsGettingSource = false;
                p.Content = new TroublePage_His();
            });

            LoadCollectPage = new RelayCommand<Frame>((p) => { return true; }, async (p) =>
            {
                view = 3;
                IsGettingSource = true;
                ListCollect = new ObservableCollection<BookInCollectDTO>();
                await GetCollectListSource("");
                IsGettingSource = false;
                p.Content = new CollectPage();
            });

            LoadBorrowPage = new RelayCommand<Frame>((p) => { return true; }, async (p) =>
            {
                view = 4;
                IsGettingSource = true;
                ListBorrow = new ObservableCollection<BookInBorrowDTO>();
                await GetBorrowListSource("");
                IsGettingSource = false;
                p.Content = new BorrowPage();
            });

            ExportFileML = new RelayCommand<object>((p) => { return true; }, async(p) =>
            {
                ExportFile();
            });

            #endregion

            ConfirmBill = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                UpdateConfirmBill();
            });

            CancelBill = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                UpdateCancelBill();
            });

            #region Load hoá đơn
            LoadInforRevenueML = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                if (SelectedItemRevenue != null)
                {
                    try
                    {
                        IsGettingSource = true;
                        ListProduct = new ObservableCollection<BillDetailDTO>(await Task.Run(() => BillDetailServices.Ins.GetAllProduct(SelectedItemRevenue.MAHD)));
                        IsGettingSource = false;
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
                    decimal totalcost = 0;
                    RevenueDetail rd = new RevenueDetail();
                    rd.idBill.Content = SelectedItemRevenue.MAHD;
                    rd.ngmuahang.Content = SelectedItemRevenue.NGHD;
                    rd.cusID.Content = SelectedItemRevenue.MAKH;
                    rd.cusName.Content = SelectedItemRevenue.cusName;
                    rd.cusAdd.Content = SelectedItemRevenue.cusAdd;

                    for (int i = 0; i < ListProduct.Count; i++)
                    {
                        totalcost += ListProduct[i].TongGiaMoiCai;
                    }

                    rd.TotalCost.Content = Helper.FormatVNMoney(totalcost);
                    MaskName.Visibility = Visibility.Visible;
                    rd.ShowDialog();
                }
            });
            #endregion

            #region Load sách được mượn bởi khách hàng
            LoadInfoBorrow = new RelayCommand<Window>((p) => { return true; }, async (p) =>
            {
                if (SelectedBorrowItem != null)
                {
                    try
                    {
                        IsGettingSource = true;
                        ListBorrowByCus = new ObservableCollection<BookInBorrowDTO>(await Task.Run(() => BookInBorrowServices.Ins.GetListBookBorrow(SelectedBorrowItem.MAKH, SelectedBorrowItem.NgayMuon)));
                        IsGettingSource = false;
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
                    BorrowDetail bd = new BorrowDetail();
                    bd.cusName.Content = SelectedBorrowItem.TenKH;
                    bd.ngmuonsach.Content = SelectedBorrowItem.NgayMuon;
                    MaskName.Visibility = Visibility.Visible;
                    bd.ShowDialog();
                }
            });
            #endregion
        }

        public async void UpdateConfirmBill()
        {
            MessageBoxML mb = new MessageBoxML("Xác nhận", "Bạn có muốn xác nhận đơn hàng này?", MessageType.Accept, MessageButtons.YesNo);
            mb.ShowDialog();

            if ((bool)mb.DialogResult)
            {
                BillDTO newBill = new BillDTO()
                {
                    MAKH = SelectedItemRevenue.MAKH,
                    cusId = (int)SelectedItemRevenue.MAKH,
                    cusName = SelectedItemRevenue.cusName,
                    cusAdd = SelectedItemRevenue.cusAdd,
                    MAHD = SelectedItemRevenue.MAHD,
                    TRIGIA = (decimal)SelectedItemRevenue.TRIGIA,
                    NGHD = SelectedItemRevenue.NGHD,
                    TRANGTHAI = "Đang trên đường vận chuyển",
                    TenSach = SelectedItemRevenue.TenSach,
                };

                (bool isUpdate, string lb) = await BillServices.Ins.UpdateBillConfirm(newBill);

                await checkRevenueFilter();

                if (isUpdate)
                {
                    MessageBoxML ms = new MessageBoxML("Thông báo", lb, MessageType.Accept, MessageButtons.OK);
                    ms.ShowDialog();
                    
                }
                else
                {
                    MessageBoxML ms = new MessageBoxML("Lỗi", lb, MessageType.Accept, MessageButtons.OK);
                    ms.ShowDialog();
                }
            }
        }

        public async void UpdateCancelBill()
        {
            MessageBoxML mb = new MessageBoxML("Huỷ đơn hàng", "Bạn có muốn huỷ đơn hàng này?", MessageType.Accept, MessageButtons.YesNo);
            mb.ShowDialog();

            if ((bool)mb.DialogResult)
            {
                BillDTO currentBill = new BillDTO()
                {
                    MAKH = SelectedItemRevenue.MAKH,
                    cusId = (int)SelectedItemRevenue.MAKH,
                    cusName = SelectedItemRevenue.cusName,
                    cusAdd = SelectedItemRevenue.cusAdd,
                    MAHD = SelectedItemRevenue.MAHD,
                    TRIGIA = (decimal)SelectedItemRevenue.TRIGIA,
                    NGHD = SelectedItemRevenue.NGHD,
                    TRANGTHAI = "Đơn hàng đã bị huỷ",
                    TenSach = SelectedItemRevenue.TenSach,
                };

                (bool isCancel, string lb) = await BillServices.Ins.CancelBill(currentBill);

                await checkRevenueFilter();
                if (isCancel)
                {
                    MessageBoxML ms = new MessageBoxML("Thông báo", lb, MessageType.Accept, MessageButtons.OK);
                    ms.ShowDialog();
                }
                else
                {
                    MessageBoxML ms = new MessageBoxML("Lỗi", lb, MessageType.Accept, MessageButtons.OK);
                    ms.ShowDialog();
                }
            }
        }

        //filter tháng cho danh sách chi tiền
        public async Task checkExpenseMonthFilter()
        {
            try
            {
                ListExpense = new ObservableCollection<InputBookDTO>(await InputBookServices.Ins.GetBookInput(SelectedExpenseMonth + 1, SelectedExpenseYear));
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

        //filter tháng cho danh sách lợi nhuận
        public async Task checkRevenueMonthFilter()
        {
            try
            {
                ListRevenue = new ObservableCollection<BillDTO>(await BillServices.Ins.GetBillByMonth(SelectedRevenueMonth + 1, SelectedRevenueYear));
                CountConfirm = 0;
                CountCancel = 0;
                CountSuccess = 0;
                CountDelivery = 0;
                for (int i = 0; i < ListRevenue.Count; i++)
                {
                    if (ListRevenue[i].TRANGTHAI == "Chờ xác nhận")
                    {
                        CountConfirm++;
                    }
                    if (ListRevenue[i].TRANGTHAI == "Đơn hàng đã bị huỷ")
                    {
                        CountCancel++;
                    }
                    if (ListRevenue[i].TRANGTHAI == "Giao hàng thành công")
                    {
                        CountSuccess++;
                    }
                    if (ListRevenue[i].TRANGTHAI == "Đang trên đường vận chuyển")
                    {
                        CountDelivery++;
                    }
                }
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

        public async Task checkTroubleMonthFilter()
        {
            try
            {
                ListTrouble = new ObservableCollection<TroubleDTO>(await TroubleServices.Ins.GetTroubleByMonth(SelectedTroubleMonth + 1, SelectedTroubleYear));
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

        public async Task checkCollectMonthFilter()
        {
            try
            {
                ListCollect = new ObservableCollection<BookInCollectDTO>(await BookInBorrowServices.Ins.GetCollectBookByMonth(SelectedCollectMonth + 1, SelectedCollectYear));
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

        public async Task checkBorrowMonthFilter()
        {
            try
            {
                ListBorrow = new ObservableCollection<BookInBorrowDTO>(await BookInBorrowServices.Ins.GetBookBorrowByMonth(SelectedBorrowMonth + 1, SelectedBorrowYear));
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

        //lấy danh sách thu từ việc bán sách
        public async Task GetRevenueListSource(string s="")
        {
            ListRevenue = new ObservableCollection<BillDTO>();
            switch(s)
            {
                case "date":
                    {
                        try
                        {
                            IsGettingSource = true;
                            ListRevenue = new ObservableCollection<BillDTO>((System.Collections.Generic.IEnumerable<BillDTO>)await BillServices.Ins.GetBillByDate(SelectedRevenueDate));
                            CountConfirm = 0;
                            CountCancel = 0;
                            CountSuccess = 0;
                            CountDelivery = 0;
                            for (int i = 0; i < ListRevenue.Count; i++)
                            {
                                if (ListRevenue[i].TRANGTHAI == "Chờ xác nhận")
                                {
                                    CountConfirm++;
                                }
                                if (ListRevenue[i].TRANGTHAI == "Đơn hàng đã bị huỷ")
                                {
                                    CountCancel++;
                                }
                                if (ListRevenue[i].TRANGTHAI == "Giao hàng thành công")
                                {
                                    CountSuccess++;
                                }
                                if (ListRevenue[i].TRANGTHAI == "Đang trên đường vận chuyển")
                                {
                                    CountDelivery++;
                                }
                            }
                            IsGettingSource = false;
                            return;
                        }
                        catch(System.Data.Entity.Core.EntityException e)
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
                        await checkRevenueMonthFilter();
                        IsGettingSource = false;
                        return;
                    }
                case "":
                    {
                        try
                        {
                            IsGettingSource = true;
                            ListRevenue = new ObservableCollection<BillDTO>((System.Collections.Generic.IEnumerable<BillDTO>)await BillServices.Ins.GetAllBill());
                            CountConfirm = 0;
                            CountCancel = 0;
                            CountSuccess = 0;
                            CountDelivery = 0;
                            for (int i = 0; i < ListRevenue.Count; i++)
                            {
                                if (ListRevenue[i].TRANGTHAI == "Chờ xác nhận")
                                {
                                    CountConfirm++;
                                }
                                if (ListRevenue[i].TRANGTHAI == "Đơn hàng đã bị huỷ")
                                {
                                    CountCancel++;
                                }
                                if (ListRevenue[i].TRANGTHAI == "Giao hàng thành công")
                                {
                                    CountSuccess++;
                                }
                                if (ListRevenue[i].TRANGTHAI == "Đang trên đường vận chuyển")
                                {
                                    CountDelivery++;
                                }
                            }
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
            }
        }

        //lấy danh sách chi từ việc bán sách
        public async Task GetExpenseListSource(string s = "")
        {
            ListExpense = new ObservableCollection<InputBookDTO>();
            switch (s)
            {
                case "":
                    {
                        try
                        {
                            IsGettingSource = true;
                            ListExpense = new ObservableCollection<InputBookDTO>(await InputBookServices.Ins.GetBookInput());
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
                        await checkExpenseMonthFilter();
                        IsGettingSource = false;
                        return;
                    }
            }
        }

        //Lấy danh sách sự cố
        public async Task GetTroubleListSource(string s = "")
        {
            ListTrouble = new ObservableCollection<TroubleDTO>();
            switch(s)
            {
                case "":
                    {
                        try
                        {
                            IsGettingSource = true;
                            ListTrouble = new ObservableCollection<TroubleDTO>(await TroubleServices.Ins.GetAllTrouble());
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
                        await checkTroubleMonthFilter();
                        IsGettingSource = false;
                        return;
                    }
            }
        }

        public async Task GetCollectListSource(string s = "")
        {
            ListCollect = new ObservableCollection<BookInCollectDTO>();
            switch(s)
            {
                case "":
                    {
                        try
                        {
                            IsGettingSource = true;
                            ListCollect = new ObservableCollection<BookInCollectDTO>(await BookInBorrowServices.Ins.GetAllCollectBook());
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
                        await checkCollectMonthFilter();
                        IsGettingSource = false;
                        return;
                    }
            }
        }

        public async Task GetBorrowListSource(string s = "")
        {
            ListBorrow = new ObservableCollection<BookInBorrowDTO>();
            switch(s)
            {
                case "":
                    {
                        try
                        {
                            IsGettingSource = true;
                            ListBorrow = new ObservableCollection<BookInBorrowDTO>(await BookInBorrowServices.Ins.GetAllBookBorrow());
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
                        await checkBorrowMonthFilter();
                        IsGettingSource = false;
                        return;
                    }
            }
        }

        //filter
        public async Task checkExpenseFilter()
        {
            switch(SelectedExpenseFilter.Content.ToString())
            {
                case "Toàn bộ":
                    {
                        await GetExpenseListSource("");
                        return;
                    }
                case "Theo tháng":
                    {
                        await GetExpenseListSource("month");
                        return;
                    }
            }
        }

        //filter 
        public async Task checkRevenueFilter()
        {
            switch(SelectedRevenueFilter.Content.ToString())
            {
                case "Toàn bộ":
                    {
                        await GetRevenueListSource("");
                        return;
                    }
                case "Theo ngày":
                    {
                        await GetRevenueListSource("date");
                        return;
                    }
                case "Theo tháng":
                    {
                        await GetRevenueListSource("month");
                        return;
                    }
            }
        }

        public async Task checkTroubleFilter()
        {
            switch (SelectedTroubleFilter.Content.ToString())
            {
                case "Toàn bộ":
                    {
                        await GetTroubleListSource("");
                        return;
                    }
                case "Theo tháng":
                    {
                        await GetTroubleListSource("month");
                        return;
                    }
            }
        }

        public async Task checkCollectFilter()
        {
            switch (SelectedCollectFilter.Content.ToString())
            {
                case "Toàn bộ":
                    {
                        await GetCollectListSource("");
                        return;
                    }
                case "Theo tháng":
                    {
                        await GetCollectListSource("month");
                        return;
                    }
            }
        }

        public async Task checkBorrowFilter()
        {
            switch (SelectedBorrowFilter.Content.ToString())
            {
                case "Toàn bộ":
                    {
                        await GetBorrowListSource("");
                        return;
                    }
                case "Theo tháng":
                    {
                        await GetBorrowListSource("month");
                        return;
                    }
            }
        }
        //xuất file excel
        public void ExportFile()
        {
            switch (view)
            {
                case 0:
                    {
                        SaveFileDialog sf = new SaveFileDialog
                        {
                            FileName = "NhapSach",
                            Filter = "Excel |*.xlsx",
                            ValidateNames = true
                        };
                        if (sf.ShowDialog() == DialogResult.OK)
                        {
                            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
                            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                            app.Visible = false;
                            Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(1);
                            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];

                            ws.Cells[1, 1] = "Mã đơn";
                            ws.Cells[1, 2] = "Tên sách";
                            ws.Cells[1, 3] = "Ngày nhập";
                            ws.Cells[1, 4] = "Số lượng";
                            ws.Cells[1, 5] = "Giá nhập";

                            int count = 2;
                            foreach (var item in ListExpense)
                            {
                                ws.Cells[count, 1] = item.IDInput;
                                ws.Cells[count, 2] = item.TenSach;
                                ws.Cells[count, 3] = item.NgNhap;
                                ws.Cells[count, 4] = item.SoLuong;
                                ws.Cells[count, 5] = item.GiaNhapStr;

                                count++;
                            }
                            ws.SaveAs(sf.FileName);
                            wb.Close();
                            app.Quit();

                            Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                            MessageBoxML mb = new MessageBoxML("Thông báo", "Xuất file thành công", MessageType.Accept, MessageButtons.OK);
                            mb.ShowDialog();
                        }
                        break;
                    }

                case 1:
                    {
                        SaveFileDialog sf = new SaveFileDialog
                        {
                            FileName = "BanSach",
                            Filter = "Excel |*.xlsx",
                            ValidateNames = true
                        };
                        if (sf.ShowDialog() == DialogResult.OK)
                        {
                            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
                            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                            app.Visible = false;
                            Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(1);
                            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];

                            ws.Cells[1, 1] = "Mã đơn";
                            ws.Cells[1, 2] = "Mã khách hàng";
                            ws.Cells[1, 3] = "Tên khách hàng";
                            ws.Cells[1, 4] = "Ngày bán";
                            ws.Cells[1, 5] = "Tổng giá";
                            ws.Cells[1, 6] = "Trạng thái";

                            int count = 2;
                            foreach (var item in ListRevenue)
                            {
                                ws.Cells[count, 1] = item.MAHD;
                                ws.Cells[count, 2] = item.MAKH;
                                ws.Cells[count, 3] = item.cusName;
                                ws.Cells[count, 4] = item.NGHD;
                                ws.Cells[count, 5] = item.TRIGIAStr;
                                ws.Cells[count, 6] = item.TRANGTHAI;

                                count++;
                            }
                            ws.SaveAs(sf.FileName);
                            wb.Close();
                            app.Quit();

                            Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                            MessageBoxML mb = new MessageBoxML("Thông báo", "Xuất file thành công", MessageType.Accept, MessageButtons.OK);
                            mb.ShowDialog();
                        }
                        break;
                    }

                case 2:
                    {
                        SaveFileDialog sf = new SaveFileDialog
                        {
                            FileName = "SuCo",
                            Filter = "Excel |*.xlsx",
                            ValidateNames = true
                        };
                        if (sf.ShowDialog() == DialogResult.OK)
                        {
                            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
                            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                            app.Visible = false;
                            Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(1);
                            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];

                            ws.Cells[1, 1] = "Mã sự cố";
                            ws.Cells[1, 2] = "Tên loại sự cố";
                            ws.Cells[1, 3] = "Thời gian báo";
                            ws.Cells[1, 4] = "Chi phí";
                            ws.Cells[1, 5] = "Mô tả";

                            int count = 2;
                            foreach (var item in ListTrouble)
                            {
                                ws.Cells[count, 1] = item.MaSC;
                                ws.Cells[count, 2] = item.TenLoaiSuCo;
                                ws.Cells[count, 3] = item.NgayBaoCao;
                                ws.Cells[count, 4] = item.ChiPhistr;
                                ws.Cells[count, 5] = item.MoTa;

                                count++;
                            }
                            ws.SaveAs(sf.FileName);
                            wb.Close();
                            app.Quit();

                            Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                            MessageBoxML mb = new MessageBoxML("Thông báo", "Xuất file thành công", MessageType.Accept, MessageButtons.OK);
                            mb.ShowDialog();
                        }
                        break;
                    }

                case 3:
                    {
                        SaveFileDialog sf = new SaveFileDialog
                        {
                            FileName = "ThuSach",
                            Filter = "Excel |*.xlsx",
                            ValidateNames = true
                        };
                        if (sf.ShowDialog() == DialogResult.OK)
                        {
                            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
                            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                            app.Visible = false;
                            Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(1);
                            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];

                            ws.Cells[1, 1] = "Mã phiếu thu";
                            ws.Cells[1, 2] = "Tên khách hàng";
                            ws.Cells[1, 3] = "Tên sách";
                            ws.Cells[1, 4] = "Ngày thu";
                            ws.Cells[1, 5] = "Số ngày quá hạn";
                            ws.Cells[1, 6] = "Số lượng hỏng";
                            ws.Cells[1, 7] = "Tổng tiền hỏng";
                            ws.Cells[1, 8] = "Tiền trễ";
                            ws.Cells[1, 9] = "Tổng tiền trả";

                            int count = 2;
                            foreach (var item in ListCollect)
                            {
                                ws.Cells[count, 1] = item.MaPhieuMuon;
                                ws.Cells[count, 2] = item.TenKH;
                                ws.Cells[count, 3] = item.TenSach;
                                ws.Cells[count, 4] = item.NgayTra;
                                ws.Cells[count, 5] = item.SoNgayQuaHan;
                                ws.Cells[count, 6] = item.SoLuongHong;
                                ws.Cells[count, 7] = item.TongTienHongStr;
                                ws.Cells[count, 8] = item.TienTreStr;
                                ws.Cells[count, 9] = item.TongTienTraStr;

                                count++;
                            }
                            ws.SaveAs(sf.FileName);
                            wb.Close();
                            app.Quit();

                            Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                            MessageBoxML mb = new MessageBoxML("Thông báo", "Xuất file thành công", MessageType.Accept, MessageButtons.OK);
                            mb.ShowDialog();
                        }
                        break;
                    }
                case 4:
                    {
                        SaveFileDialog sf = new SaveFileDialog
                        {
                            FileName = "MuonSach",
                            Filter = "Excel |*.xlsx",
                            ValidateNames = true
                        };
                        if (sf.ShowDialog() == DialogResult.OK)
                        {
                            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
                            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                            app.Visible = false;
                            Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(1);
                            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];

                            ws.Cells[1, 1] = "Mã phiếu mượn";
                            ws.Cells[1, 2] = "Tên khách hàng";
                            ws.Cells[1, 3] = "Tên sách";
                            ws.Cells[1, 4] = "Ngày mượn";
                            ws.Cells[1, 5] = "Ngày hết hạn";
                            ws.Cells[1, 6] = "Số lượng mượn";
                            //ws.Cells[1, 7] = "Giá";

                            int count = 2;
                            foreach (var item in ListBorrow)
                            {
                                ws.Cells[count, 1] = item.MaPhieuMuon;
                                ws.Cells[count, 2] = item.TenKH;
                                ws.Cells[count, 3] = item.TenSach;
                                ws.Cells[count, 4] = item.NgayMuon;
                                ws.Cells[count, 5] = item.NgayHetHan;
                                ws.Cells[count, 6] = item.SoLuong;
                                //ws.Cells[count, 7] = item.Gia;

                                count++;
                            }
                            ws.SaveAs(sf.FileName);
                            wb.Close();
                            app.Quit();

                            Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                            MessageBoxML mb = new MessageBoxML("Thông báo", "Xuất file thành công", MessageType.Accept, MessageButtons.OK);
                            mb.ShowDialog();
                        }
                        break;
                    }
            }
        }

    }
}
