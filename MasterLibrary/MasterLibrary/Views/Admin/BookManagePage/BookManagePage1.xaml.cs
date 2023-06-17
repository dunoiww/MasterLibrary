using MasterLibrary.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MasterLibrary.Views.Admin.BookManagePage
{
    /// <summary>
    /// Interaction logic for BookManagePage1.xaml
    /// </summary>
    public partial class BookManagePage1 : Page
    {
        public BookManagePage1()
        {
            InitializeComponent();
        }
        #region Search
        private bool Filter(object item)
        {
            if (String.IsNullOrEmpty(txbFilter.Text))
                return true;
            else
                return ((item as BookDTO).TenSach.IndexOf(txbFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    ((item as BookDTO).TacGia.IndexOf(txbFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        public void CreateTextBoxFilter()
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(dtg_manage.ItemsSource);
            view.Filter = Filter;
        }

        private void TextBox_TextChanged_Find(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dtg_manage.ItemsSource).Refresh();
            CreateTextBoxFilter();
        }
        #endregion

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedbook = dtg_manage.SelectedItem as BookDTO;
            DetailBookWindow dbw = new DetailBookWindow();
            dbw.bookName.Content = selectedbook.TenSach;
            dbw.bookGenre.Content = selectedbook.TheLoai;
            dbw.bookAuthor.Content = selectedbook.TacGia;
            dbw.bookPublishing.Content = selectedbook.NamXB;
            dbw.bookNXB.Content = selectedbook.NXB;
            dbw.bookPrice.Content = selectedbook.GiaStr;
            ShadowMask.Visibility = Visibility.Visible;
            dbw.ShowDialog();
            ShadowMask.Visibility = Visibility.Collapsed;
        }
    }
}
