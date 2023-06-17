﻿using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using MasterLibrary.DTOs;
using MasterLibrary.Models.DataProvider;
using MasterLibrary.Views.Admin.BookManagePage;
using MasterLibrary.Views.MessageBoxML;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MasterLibrary.ViewModel.AdminVM
{
    public class BookManageViewModel : BaseViewModel
    {
        #region Property
        private ObservableCollection<BookDTO> _listbookmanage;
        public  ObservableCollection<BookDTO> Listbookmanage
        {
            get { return _listbookmanage; }
            set { _listbookmanage = value; OnPropertyChanged(); }
        }

        private BookDTO _SelectedBook;
        public BookDTO SelectedBook
        {
            get => _SelectedBook;
            set { _SelectedBook = value; OnPropertyChanged(); }
        }

        private string _masach;
        public string MaSach
        {
            get { return _masach; }
            set { _masach = value; OnPropertyChanged(); }
        }

        private string _tensach;
        public string TenSach
        {
            get { return _tensach; }
            set { _tensach = value; OnPropertyChanged(); }
        }

        private string _tacgia;
        public string TacGia
        {
            get { return _tacgia; }
            set { _tacgia = value; OnPropertyChanged(); }
        }

        private string _nhaxuatban;
        public string NhaXuatBan
        {
            get { return _nhaxuatban; }
            set { _nhaxuatban = value; OnPropertyChanged(); }
        }

        private string _namxuatban;
        public string NamXuatBan
        {
            get { return _namxuatban; }
            set { _namxuatban = value; OnPropertyChanged(); }
        }

        private string _soluong;
        public string SoLuong
        {
            get { return _soluong; }
            set { _soluong = value; OnPropertyChanged(); }
        }

        private string _gia;
        public string Gia
        {
            get { return _gia; }
            set { _gia = value; OnPropertyChanged(); }
        }

        private string _theloai;
        public string TheLoai
        {
            get { return _theloai; }
            set { _theloai = value; OnPropertyChanged(); }
        }

        private string _mota;
        public string MoTa
        {
            get { return _mota; }
            set { _mota = value; OnPropertyChanged(); }
        }

        private string _tang;
        public string Tang
        {
            get { return _tang; }
            set { _tang = value; OnPropertyChanged(); }
        }

        private string _day;
        public string Day
        {
            get { return _day; }
            set { _day = value; OnPropertyChanged(); }
        }

        private string _imgsource;
        public string ImgSource
        {
            get { return _imgsource; }
            set { _imgsource = value; OnPropertyChanged(); }
        }

        private bool _isIncomplete;
        public bool IsIncomplete
        {
            get { return _isIncomplete; }
            set { _isIncomplete = value; OnPropertyChanged(); }
        }

        private List<TangDTO> _dsTang;
        public List<TangDTO> DsTang
        {
            get { return _dsTang; }
            set { _dsTang = value; OnPropertyChanged();}
        }

        private List<DayDTO> _dsDay;
        public List<DayDTO> DsDay
        {
            get { return _dsDay; }
            set { _dsDay = value; OnPropertyChanged(); }
        }

        private int _maTang;
        public int MaTang
        {
            get { return _maTang; }
            set { _maTang = value; OnPropertyChanged(); }
        }

        private int _maDay;
        public int MaDay
        {
            get { return _maDay; }
            set { _maDay = value; OnPropertyChanged(); }
        }

        private bool _isNull;
        public bool IsNull
        {
            get { return _isNull; }
            set { _isNull = value; OnPropertyChanged();}
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { _isLoading = value; OnPropertyChanged();}
        }

        private TangDTO _SelectedTang;
        public TangDTO SelectedTang
        {
            get => _SelectedTang;
            set { _SelectedTang = value; OnPropertyChanged(); }
        }

        public static Grid MaskName { get; set; }

        #endregion

        #region Icommand
        public ICommand LoadManageBookData { get; set; }
        public ICommand LoadInforBookML { get; set; }
        public ICommand SavingData { get; set; }
        public ICommand Updating { get; set; }
        public ICommand DeletingBook { get; set; }
        public ICommand UpdatingBook { get; set; }
        public ICommand ImportImageForAddingWindow { get; set; }
        public ICommand ImportImageForUpdatingWindow { get; set; }
        public ICommand FloorChangeML { get; set; }
        public ICommand TypeChangeML { get; set; }
        public ICommand ShelvesChangeML { get; set; }
        public ICommand closeML { get; set; }
        public ICommand MaskNameML { get; set; }
        #endregion
        public BookManageViewModel()
        {

            MaskNameML = new RelayCommand<Grid>((p) => { return true; }, (p) => { MaskName = p; });
            closeML = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });
            //Nút update của chức năng chỉnh sửa
            Updating = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                using (var context = new MasterlibraryEntities())
                {
                    string connectionStr = context.Database.Connection.ConnectionString;
                    SqlConnection connect = new SqlConnection(connectionStr);
                    connect.Open();
                    SqlCommand command = new SqlCommand();

                    command.Connection = connect;
                    command.Parameters.AddWithValue("@masach", updatingwindow.masach);
                    command.Parameters.AddWithValue("@tensach", TenSach);
                    command.Parameters.AddWithValue("@tacgia", TacGia);
                    command.Parameters.AddWithValue("@namxb", NamXuatBan);
                    command.Parameters.AddWithValue("@nxb", NhaXuatBan);
                    command.Parameters.AddWithValue("@sl", SoLuong);
                    command.Parameters.AddWithValue("@gia", Gia);
                    command.Parameters.AddWithValue("@imagesource", ImgSource);
                    command.Parameters.AddWithValue("@theloai", TheLoai);
                    command.Parameters.AddWithValue("@mota", MoTa);
                    command.Parameters.AddWithValue("@tang", MaTang);
                    command.Parameters.AddWithValue("@day", MaDay);
                    command.Parameters.AddWithValue("@ratingstar", 0);
                    command.Parameters.AddWithValue("@review", "");
                    command.Parameters.AddWithValue("@soluongdanhgia", 0);
                    command.Parameters.AddWithValue("@avgrating", 0);

                    if (!String.IsNullOrEmpty(TenSach) && !String.IsNullOrEmpty(TacGia) && !String.IsNullOrEmpty(NamXuatBan) && !String.IsNullOrEmpty(NhaXuatBan) && !String.IsNullOrEmpty(SoLuong) && !String.IsNullOrEmpty(Gia) && !String.IsNullOrEmpty(ImgSource) && !String.IsNullOrEmpty(TheLoai) && !String.IsNullOrEmpty(MoTa) && !String.IsNullOrEmpty(Day) && !String.IsNullOrEmpty(Tang))
                    {
                        command.CommandText = "UPDATE SACH " +
                                              "SET TENSACH = @tensach, TACGIA = @tacgia, NAMXB = @namxb, NXB = @nxb, SL = @sl, GIA = @gia, IMAGESOURCE = @imagesource, THELOAI = @theloai, MOTA = @mota, VITRITANG = @tang, VITRIDAY = @day, RATING = @ratingstar, SOLUONGDANHGIA = @soluongdanhgia, AVGRATING = @avgrating " +
                                              "WHERE MASACH = @masach";
                        context.SaveChanges();
                        int a = command.ExecuteNonQuery();
                        if (a != 0)
                        {
                            MessageBoxML msb = new MessageBoxML("Thông báo", "Cập nhật sách thành công", MessageType.Accept, MessageButtons.OK);
                            msb.ShowDialog();
                            p.Close();
                        }
                    }
                    else
                    {
                        MessageBoxML msb = new MessageBoxML("Lỗi", "Bạn chưa điền đầy đủ các thông tin trên!", MessageType.Error, MessageButtons.OK);
                        msb.ShowDialog();
                    }
                }
                
            });

            // Nút import của chức năng sửa
            ImportImageForUpdatingWindow = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.Filter = "JPG File (.jpg)|*.jpg";
                Nullable<bool> result = dlg.ShowDialog();
                if (result == true)
                {
                    BitmapImage img = new BitmapImage();
                    img.BeginInit();
                    img.UriSource = new Uri(dlg.FileName);
                    img.EndInit();
                    updatingwindow.Image.Source = img;
                    Account account = new Account("dg0uneomp", "924294962494475", "Ahrb-2beUzb0TEJpKjHck2IYCGI");

                    Cloudinary cloudinary = new Cloudinary(account);
                    cloudinary.Api.Secure = true;
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(dlg.FileName)
                    };
                    IsLoading = true;
                    var uploadResult = cloudinary.Upload(uploadParams);

                    ImgSource = uploadResult.Url.ToString();
                    IsLoading = false;
                }
            });

            // Load dữ liệu vào trang quản lý sách
            LoadManageBookData = new RelayCommand<DataGrid>((p) => { return true; }, (p) =>
            {
                Loaded(p);
            });

            //Nút xóa sách ở trang quản lý sách
            DeletingBook = new RelayCommand<DataGrid>((p) => { return true; }, (p) =>
            {
                BookDTO item = p.Items[p.SelectedIndex] as BookDTO;
                    string masach = item.MaSach.ToString();
                    using (var context = new MasterlibraryEntities())
                    {
                        string connectionStr = context.Database.Connection.ConnectionString;
                        SqlConnection connect = new SqlConnection(connectionStr);
                        connect.Open();
                        SqlCommand command = new SqlCommand();
                        command.Connection = connect;
                        command.Parameters.AddWithValue("@masach", masach);
                        MessageBoxML msb = new MessageBoxML("Cảnh báo", "Bạn có muốn xóa sách này không", MessageType.Waitting, MessageButtons.YesNo);

                        if (msb.ShowDialog() == true)
                        {
                            try
                            {
                                command.CommandText = "UPDATE SACH SET ISEXIST = 0 WHERE MASACH = @masach";
                                context.SaveChanges();
                                if (command.ExecuteNonQuery() != 0)
                                {
                                    msb = new MessageBoxML("Thông báo", "Thành công", MessageType.Accept, MessageButtons.OK);
                                    msb.ShowDialog();
                                    Loaded(p);
                                }
                            }
                            catch
                            {
                                msb = new MessageBoxML("Thông báo", "Không thể xóa sách ", MessageType.Error, MessageButtons.OK);
                                msb.ShowDialog();
                            }
                        }
                    }
            });

            UpdatingBook = new RelayCommand<DataGrid>((p) => { return true; }, (p) =>
            {
                MaskName.Visibility = Visibility.Visible;
                BookDTO item = p.Items[p.SelectedIndex] as BookDTO;
                var masach = item.MaSach.ToString();
                updatingwindow window = new updatingwindow(masach);
                //TheLoai = null;
                //Tang = null;
                //Day = null;
                //MessageBox.Show(item.ToString());
                DsTang = LayTang();

                if (item.ImageSource == null)
                {
                    SoLuong = item.SoLuong.ToString();
                    TenSach = item.TenSach.ToString();
                    TacGia = item.TacGia.ToString();
                    NhaXuatBan = item.NXB;
                    Gia = item.Gia.ToString(); ;
                    NamXuatBan = ImgSource = Tang = Day = TheLoai = MoTa = null;
                }
                else
                {
                    SoLuong = item.SoLuong.ToString();
                    TenSach = item.TenSach.ToString();
                    TacGia = item.TacGia.ToString();
                    NhaXuatBan = item.NXB;
                    NamXuatBan = item.NamXB.ToString();
                    Gia = item.Gia.ToString();
                    Tang = item.TenTang.ToString();
                    MaTang = item.MaTang;
                    DsDay = LayDay();
                    Day = item.TenDay.ToString();
                    MaDay = item.MaDay;
                    ImgSource = item.ImageSource.ToString();
                    MoTa = item.MoTa.ToString();
                    TheLoai = item.TheLoai;
                   
                    //Load ảnh hiện tại lên trang chỉnh sửa
                    BitmapImage img = new BitmapImage();
                    img.BeginInit();
                    img.UriSource = new Uri(item.ImageSource);
                    img.EndInit();
                    window.image_img.Source = img;
                }
                window.ShowDialog();
                MaskName.Visibility = Visibility.Collapsed;
                //load lại trang quản lý sách
                Loaded(p);
            });

            FloorChangeML = new RelayCommand<ComboBox>((p) => { return true; }, (p) =>
            {
                try
                {
                    TangDTO m = p.SelectedItem as TangDTO;
                    Tang = m.TenTang;
                    MaTang = m.MaTang;
                    Day = null;
                    DsDay = LayDay();
                }
                catch { }
                

            });

            ShelvesChangeML = new RelayCommand<ComboBox>((p) => { return true; }, (p) =>
            {
                try
                {
                    DayDTO m = p.SelectedItem as DayDTO;
                    Day = m.TenDay;
                    MaDay = m.MaDay;
                    IsNull = true;
                }
                catch { }
            });

        }

        public void Loaded(DataGrid p)
        {
            Listbookmanage = new ObservableCollection<BookDTO>();
            using (var context = new MasterlibraryEntities())
            {
                foreach (var item in context.SACHes)
                {
                    if (item.ISEXIST == 0) continue;

                    BookDTO book = new BookDTO();
                    if(item.IMAGESOURCE == null)
                    {
                        book.MaSach = item.MASACH;
                        book.TenSach = item.TENSACH;
                        book.TacGia = item.TACGIA;
                        book.SoLuong = (int)item.SL;
                        book.Gia = (int)item.GIA;
                        book.NXB = item.NXB;
                    }
                    else
                    {
                        book.MaSach = item.MASACH;
                        book.TenSach = item.TENSACH;
                        book.TacGia = item.TACGIA;
                        book.SoLuong = (int)item.SL;
                        book.Gia = (int)item.GIA;
                        book.NXB = item.NXB;
                        book.NamXB = (int)item.NAMXB;
                        book.TheLoai = item.THELOAI;
                        book.ImageSource = item.IMAGESOURCE;
                        book.MoTa = item.MOTA;
                        book.TenDay = (from s in context.DAYKEs where s.MADAY == item.VITRIDAY select s.TENDAY).FirstOrDefault();
                        book.TenTang = (from s in context.TANGs where s.MATANG == item.VITRITANG select s.TENTANG).FirstOrDefault();
                        book.MaTang = (int)item.VITRITANG;
                        book.MaDay = (int)item.VITRIDAY;
                    }    
                    Listbookmanage.Add(book);
                }
            }

            foreach(BookDTO book in Listbookmanage)
            {
                if(book.TheLoai == null || book.ImageSource == null)
                    book.IsIncomplete = true;
                else
                    book.IsIncomplete = false;
            }
        }
        public List<DayDTO> LayDay()
        {
            
            List<DayDTO> items = new List<DayDTO>();
            using(var context = new MasterlibraryEntities())
            {
                foreach (var t in context.DAYKEs)
                {
                    if (t.IDTANG == ((from s in context.TANGs where s.TENTANG == Tang select s.MATANG).FirstOrDefault()))
                    {
                        DayDTO day = new DayDTO();
                        day.MaTang = (int)t.IDTANG;
                        day.MaDay = t.MADAY;
                        day.TenDay = t.TENDAY;
                        items.Add(day);
                    }
                }
            }
            return items;
        }

        public List<TangDTO> LayTang()
        {
            List<TangDTO> items = new List<TangDTO>();
            using (var context = new MasterlibraryEntities())
            {
                foreach (var t in context.TANGs)
                {
                    TangDTO z = new TangDTO();
                    z.MaTang = t.MATANG;
                    z.TenTang = t.TENTANG;
                    items.Add(z);
                }
            }
            return items;
        }
    }
}
