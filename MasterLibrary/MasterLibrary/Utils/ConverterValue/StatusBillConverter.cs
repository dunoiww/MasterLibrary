using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MasterLibrary.Utils.ConverterValue
{
    public class StatusBillConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string _TrangThai = value as string;

            if (_TrangThai == "Đang trên đường vận chuyển" || _TrangThai == "Đơn hàng đã bị huỷ" || _TrangThai == "Giao hàng thành công")
            {
                return Visibility.Collapsed;
            }
            else
            {
                return Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ForegroundStatusBillConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            // Retrieve the format string and use it to format the value.
            string _TrangThai = value as string;

            if (_TrangThai == "Đang trên đường vận chuyển")
            {
                return "#d9d9d9 ";
            }
            else if (_TrangThai == "Chờ xác nhận")
            {
                return "#98cbfa";
            }
            else
            {
                return "#d9d9d9 ";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ForegroundStatusDeleteBillConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            // Retrieve the format string and use it to format the value.
            string _TrangThai = value as string;

            if (_TrangThai == "Đang trên đường vận chuyển")
            {
                return "#d9d9d9";
            }
            else if (_TrangThai == "Chờ xác nhận")
            {
                return "#f07f7f";
            }
            else
            {
                return "#d9d9d9";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
