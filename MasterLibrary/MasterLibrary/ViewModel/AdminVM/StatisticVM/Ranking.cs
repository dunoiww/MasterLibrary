using LiveCharts;
using LiveCharts.Wpf;
using MasterLibrary.DTOs;
using MasterLibrary.Models.DataProvider;
using MasterLibrary.Views.MessageBoxML;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using SeriesCollection = LiveCharts.SeriesCollection;

namespace MasterLibrary.ViewModel.AdminVM.StatisticVM
{
    public partial class StatisticManagementViewModel : BaseViewModel
    {
        private List<CustomerDTO> top5Customer;
        public List<CustomerDTO> Top5Customer
        {
            get { return top5Customer; }
            set { top5Customer = value; OnPropertyChanged(); }
        }

        private SeriesCollection _Top5BookData;
        public SeriesCollection Top5BookData
        {
            get { return _Top5BookData; }
            set { _Top5BookData = value; OnPropertyChanged(); }
        }

        private List<BookDTO> _Top5Book;
        public List<BookDTO> Top5Book
        {
            get { return _Top5Book; }
            set { _Top5Book = value; OnPropertyChanged(); }
        }

        private ComboBoxItem _SelectedRankingPeriod;
        public ComboBoxItem SelectedRankingPeriod
        {
            get { return _SelectedRankingPeriod; }
            set { _SelectedRankingPeriod = value; OnPropertyChanged(); }
        }

        private string _SelectedRankingTime;
        public string SelectedRankingTime
        {
            get { return _SelectedRankingTime; }
            set { _SelectedRankingTime = value; OnPropertyChanged(); }
        }

        private int _SelectedRankingYear;
        public int SelectedRankingYear
        {
            get { return _SelectedRankingYear; }
            set { _SelectedRankingYear = value; OnPropertyChanged(); }
        }

        private ComboBoxItem _SelectedBestSellPeriod;
        public ComboBoxItem SelectedBestSellPeriod
        {
            get { return _SelectedBestSellPeriod; }
            set { _SelectedBestSellPeriod = value; OnPropertyChanged(); }
        }

        private string _SelectedBestSellTime;
        public string SelectedBestSellTime
        {
            get { return _SelectedBestSellTime; }
            set { _SelectedBestSellTime = value; OnPropertyChanged(); }
        }

        private int _SelectedBestSellYear;
        public int SelectedBestSellYear
        {
            get { return _SelectedBestSellYear; }
            set { _SelectedBestSellYear = value; OnPropertyChanged(); }
        }

        private int walkingGuest;
        public int WalkingGuest
        {
            get { return walkingGuest; }
            set { walkingGuest = value; OnPropertyChanged(); }
        }

        //Top 5 khách hàng mua nhiều nhất
        public async Task ChangeRankingPeriod()
        {
            if (SelectedRankingPeriod != null)
            {
                switch (SelectedRankingPeriod.Content.ToString())
                {
                    case "Theo năm":
                        {
                            if (SelectedRankingTime != null)
                            {
                                await LoadRankingByYear();
                                SelectedRankingYear = int.Parse(SelectedRankingTime);
                            }
                            return;
                        }
                    case "Theo tháng":
                        {
                            if (SelectedRankingTime != null)
                            {
                                await LoadRankingByMonth();
                            }
                            return;
                        }
                }
            }
        }

        public async Task LoadRankingByYear()
        {
            if (SelectedRankingTime.Length != 4) return;
            try
            {
                List<CustomerDTO> Top5Cus = await Task.Run(() => StatisticServices.Ins.GetTop5CustomerExpenseByYear(int.Parse(SelectedRankingTime)));
                Top5Customer = Top5Cus;
            }
            catch (System.Data.Entity.Core.EntityException e)
            {
                Console.WriteLine(e);
                MessageBoxML mb = new MessageBoxML("Lỗi", "Mất kết nối cơ sở dữ liệu", MessageType.Error, MessageButtons.OK);
                mb.ShowDialog();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                MessageBoxML mb = new MessageBoxML("Lỗi", "Lỗi hệ thống", MessageType.Error, MessageButtons.OK);
                mb.ShowDialog();
            }
        }

        public async Task LoadRankingByMonth()
        {
            if (SelectedRankingTime.Length == 4) return;
            try
            {
                List<CustomerDTO> Top5Cus = await Task.Run(() => StatisticServices.Ins.GetTop5CustomerExpenseByMonth(int.Parse(SelectedRankingTime.Remove(0, 6)), SelectedRankingYear));
                Top5Customer = Top5Cus;
            }
            catch (System.Data.Entity.Core.EntityException e)
            {
                Console.WriteLine(e);
                MessageBoxML mb = new MessageBoxML("Lỗi", "Mất kết nối cơ sở dữ liệu", MessageType.Error, MessageButtons.OK);
                mb.ShowDialog();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                MessageBoxML mb = new MessageBoxML("Lỗi", "Lỗi hệ thống", MessageType.Error, MessageButtons.OK);
                mb.ShowDialog();
            }
        }


        //Top 5 sách bán chạy nhất
        public async Task ChangeBestSellPeriod()
        {
            if (SelectedBestSellPeriod != null)
            {
                switch (SelectedBestSellPeriod.Content.ToString())
                {
                    case "Theo năm":
                        {
                            if (SelectedBestSellTime != null)
                            {
                                await LoadBestSellByYear();
                                SelectedBestSellYear = int.Parse(SelectedBestSellTime);
                            }
                            return;
                        }
                    case "Theo tháng":
                        {
                            if (SelectedBestSellTime != null)
                            {
                                await LoadBestSellByMonth();
                            }
                            return;
                        }
                }
            }
        }

        public async Task LoadBestSellByYear()
        {
            if (SelectedBestSellTime.Length != 4) return;
            try
            {
                Top5Book = await Task.Run(() => StatisticServices.Ins.GetTop5BookByYear(int.Parse(SelectedBestSellTime)));
            }
            catch (System.Data.Entity.Core.EntityException e)
            {
                Console.WriteLine(e);
                MessageBoxML mb = new MessageBoxML("Lỗi", "Mất kết nối cơ sở dữ liệu", MessageType.Error, MessageButtons.OK);
                mb.ShowDialog();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                MessageBoxML mb = new MessageBoxML("Lỗi", "Lỗi hệ thống", MessageType.Error, MessageButtons.OK);
                mb.ShowDialog();
            }

            List<decimal> SellData = new List<decimal>();
            SellData.Add(0);
            for (int i = 0; i < Top5Book.Count; i++)
            {
                SellData.Add(Top5Book[i].tonggiaban / 1000000);
            }

            Top5BookData = new SeriesCollection
            {
                new ColumnSeries
                {
                    Values = new ChartValues<decimal>(SellData),
                    Title = "Doanh thu"
                },
            };
        }

        public async Task LoadBestSellByMonth()
        {
            if (SelectedBestSellTime.Length == 4) return;
            try
            {
                Top5Book = await Task.Run(() => StatisticServices.Ins.GetTop5BookByMonth(int.Parse(SelectedBestSellTime.Remove(0, 6)), SelectedBestSellYear));
            }
            catch (System.Data.Entity.Core.EntityException e)
            {
                Console.WriteLine(e);
                MessageBoxML mb = new MessageBoxML("Lỗi", "Mất kết nối cơ sở dữ liệu", MessageType.Error, MessageButtons.OK);
                mb.ShowDialog();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                MessageBoxML mb = new MessageBoxML("Lỗi", "Lỗi hệ thống", MessageType.Error, MessageButtons.OK);
                mb.ShowDialog();
            }

            List<decimal> SellData = new List<decimal>();
            SellData.Add(0);
            for (int i = 0; i < Top5Book.Count; i++)
            {
                SellData.Add(Top5Book[i].tonggiaban / 1000000);
            }

            Top5BookData = new SeriesCollection
            {
                new ColumnSeries
                {
                    Values = new ChartValues<decimal>(SellData),
                    Title = "Doanh thu"
                },
            };
        }
    }
}
