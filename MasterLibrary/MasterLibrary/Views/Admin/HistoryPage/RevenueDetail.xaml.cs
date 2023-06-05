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

namespace MasterLibrary.Views.Admin.HistoryPage
{
    /// <summary>
    /// Interaction logic for RevenueDetail.xaml
    /// </summary>
    public partial class RevenueDetail : Window
    {
        public RevenueDetail()
        {
            InitializeComponent();
        }

        private void RevenueDetailML_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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
                    var brush = new VisualBrush(RevenueDetailML);
                    context.DrawRectangle(brush, null, new Rect(new Point(), new Size(RevenueDetailML.ActualWidth, RevenueDetailML.ActualHeight)));
                }

                // In hình ảnh hoá đơn
                printDialog.PrintVisual(visual, "Hoá đơn");
            }
        }
    }
}
