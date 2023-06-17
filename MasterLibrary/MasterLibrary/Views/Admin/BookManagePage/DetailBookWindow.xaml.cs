using MasterLibrary.Views.Admin.CustomerManagePage;
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

namespace MasterLibrary.Views.Admin.BookManagePage
{
    /// <summary>
    /// Interaction logic for DetailBookWindow.xaml
    /// </summary>
    public partial class DetailBookWindow : Window
    {
        public DetailBookWindow()
        {
            InitializeComponent();
        }

        private void DetailBookWindowML_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();

            // Kiểm tra xem người dùng đã chọn máy in và các tùy chọn in khác chưa
            if (printDialog.ShowDialog() == true)
            {
                // Chuyển đổi Window hiện tại thành hình ảnh (Visual)
                var visual = new DrawingVisual();
                using (var context = visual.RenderOpen())
                {
                    var brush = new VisualBrush(DetailBookWindowML);
                    context.DrawRectangle(brush, null, new Rect(new Point(), new Size(DetailBookWindowML.ActualWidth, DetailBookWindowML.ActualHeight)));
                }

                // In hình ảnh hoá đơn
                printDialog.PrintVisual(visual, "Hoá đơn");
            }
        }
    }
}
