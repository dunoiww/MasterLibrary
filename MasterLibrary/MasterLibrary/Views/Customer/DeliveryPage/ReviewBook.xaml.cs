using MasterLibrary.ViewModel.CustomerVM.DeliveryVM;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace MasterLibrary.Views.Customer.DeliveryPage
{
    /// <summary>
    /// Interaction logic for ReviewBook.xaml
    /// </summary>
    public partial class ReviewBook : Window
    {
        public ReviewBook()
        {
            InitializeComponent();
        }

        private void BasicRatingBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double newValue = e.NewValue;
            DeliveryViewModel.RatingStar = newValue;
        }
    }
}
