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
    /// Interaction logic for DeNotFinish.xaml
    /// </summary>
    public partial class DeNotFinish : Page
    {
        public DeNotFinish()
        {
            InitializeComponent();
        }

        private void FilterBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lvProcess.ItemsSource).Refresh();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvProcess.ItemsSource);
            view.Filter = Filter;
        }

        private bool Filter(object item)
        {
            if (String.IsNullOrEmpty(FilterBox.Text)) return true;
            else
            {
                return ((item as BillDTO).MAHD.ToString().IndexOf(FilterBox.Text, StringComparison.OrdinalIgnoreCase) >= 0) ||
                        ((item as BillDTO).MASACH.ToString().IndexOf(FilterBox.Text, StringComparison.OrdinalIgnoreCase) >= 0) ||
                        ((item as BillDTO).TenSach.ToString().IndexOf(FilterBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }
        }
    }
}
