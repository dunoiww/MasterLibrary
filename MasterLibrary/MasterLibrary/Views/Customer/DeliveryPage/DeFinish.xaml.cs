using MasterLibrary.DTOs;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Page = System.Windows.Controls.Page;

namespace MasterLibrary.Views.Customer.DeliveryPage
{
    /// <summary>
    /// Interaction logic for DeFinish.xaml
    /// </summary>
    public partial class DeFinish : Page
    {
        public DeFinish()
        {
            InitializeComponent();
        }

        private void FilterBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lvFinish.ItemsSource).Refresh();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvFinish.ItemsSource);
            view.Filter = Filter;
        }

        private bool Filter(object item)
        {
            if (String.IsNullOrEmpty(FilterBox.Text)) return true;
            else
            {
                return ((item as BillDTO).MAHD.ToString().IndexOf(FilterBox.Text, StringComparison.OrdinalIgnoreCase) >= 0) ||
                        ((item as BillDTO).TenSach.ToString().IndexOf(FilterBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }
        }

        private void filtercbb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cbb = sender as ComboBox;
            if (cbbMonth != null)
            {
                switch (cbb.SelectedIndex)
                {
                    case 0:
                        {
                            cbbMonth.Visibility = Visibility.Collapsed;
                            cbbYear.Visibility = Visibility.Collapsed;
                            break;
                        }
                    case 1:
                        {
                            cbbMonth.Visibility = Visibility.Visible;
                            cbbYear.Visibility = Visibility.Visible;
                            break;
                        }
                }
            }
        }

        private void cbbYear_Loaded(object sender, RoutedEventArgs e)
        {
            if (cbbYear == null) return;

            List<string> list = new List<string>();

            int now = -1;
            for (int i = 2021; i <= DateTime.Now.Year; i++)
            {
                now++;
                list.Add(i.ToString());
            }

            cbbYear.ItemsSource = list;
            cbbYear.SelectedIndex = now;
        }
    }
}
