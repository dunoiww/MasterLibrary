using MasterLibrary.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using MasterLibrary.ViewModel.AdminVM;
using MasterLibrary.ViewModel.LoginVM;
using System.Text.RegularExpressions;

namespace MasterLibrary.Views.Admin.ImportBookPage
{
    /// <summary>
    /// Interaction logic for ImportBookPage.xaml
    /// </summary>
    public partial class ImportBookPage : Page
    {
        public ImportBookPage()
        {
            InitializeComponent();
        }

        private void i_gianhap_txb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }

}
