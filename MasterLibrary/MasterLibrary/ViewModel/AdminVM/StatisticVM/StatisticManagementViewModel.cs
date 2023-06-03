using LiveCharts;
using MasterLibrary.Views.Admin.StatisticalPage;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MasterLibrary.ViewModel.AdminVM.StatisticVM
{
    public partial class StatisticManagementViewModel : BaseViewModel
    {
        public Frame mainFrame { get; set; }
        public Card ButtonView { get; set; }

        public SeriesCollection pie { get; set; }
        public SeriesCollection pie2 { get; set; }

        private bool isLoading;
        public bool IsLoading
        {
            get { return isLoading; }
            set { isLoading = value; OnPropertyChanged(); }
        }


        public ICommand LoadViewML { get; set; }
        public ICommand StoreButtonNameML { get; set; }
        public ICommand LoadAllStatisticalML { get; set; }
        public ICommand LoadRankStatisticalML { get; set; }
        public ICommand ChangeBestSellPeriodML { get; set; }
        public ICommand ChangePeriodML { get; set; }
        public ICommand ChangeRankingPeriodML { get; set; }

        public StatisticManagementViewModel()
        {
            LoadViewML = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                mainFrame = p;
            });
            StoreButtonNameML = new RelayCommand<Card>((p) => { return true; }, (p) =>
            {
                ButtonView = p;
                p.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#fafafa");
                p.SetValue(ShadowAssist.ShadowDepthProperty, ShadowDepth.Depth0);

            });

            LoadAllStatisticalML = new RelayCommand<Card>((p) => { return true; }, (p) =>
            {
                ChangeView(p);
                mainFrame.Content = new StatisticalPage();
            });

            LoadRankStatisticalML = new RelayCommand<Card>((p) => { return true; }, (p) =>
            {
                ChangeView(p);
                mainFrame.Content = new RankingStatistical();
            });

            //LoadBestSellingML = new RelayCommand<Card>((p) => { return true; }, (p) =>
            //{
            //    ChangeView(p);
            //    mainFrame.Content = new BestSellingStatistical();
            //});

            ChangePeriodML = new RelayCommand<ComboBox>((p) => { return true; }, async (p) =>
            {
                IsLoading = true;
                await ChangePeriod();
                IsLoading = false;
            });

            ChangeRankingPeriodML = new RelayCommand<ComboBox>((p) => { return true; }, async (p) =>
            {
                IsLoading = true;
                await ChangeRankingPeriod();
                IsLoading = false;
            });

            ChangeBestSellPeriodML = new RelayCommand<ComboBox>((p) => { return true; }, async (p) =>
            {
                isLoading = true;
                await ChangeBestSellPeriod();
                isLoading = false;
            });
        }

        public void ChangeView(Card p)
        {
            ButtonView.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#f0f2f5");
            ButtonView.SetValue(ShadowAssist.ShadowDepthProperty, ShadowDepth.Depth2);
            ButtonView = p;
            p.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#fafafa");
            p.SetValue(ShadowAssist.ShadowDepthProperty, ShadowDepth.Depth0);
        }
    }
}
