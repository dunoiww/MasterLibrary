using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MasterLibrary.Utils.ConverterValue
{
    public class StatusBillCusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string _TrangThai = value as string;

            if (_TrangThai == "Đang trên đường vận chuyển")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ForegroundStatusBillCusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            // Retrieve the format string and use it to format the value.
            string _TrangThai = value as string;

            if (_TrangThai == "Đang trên đường vận chuyển")
            {
                return "#ffde59";
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

    public class ForegroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            // Retrieve the format string and use it to format the value.
            string _TrangThai = value as string;

            if (_TrangThai == "Chờ xác nhận")
            {
                return "#f1c232";
            }
            else if (_TrangThai == "Đơn hàng đã bị huỷ")
            {
                return "#BA1111";
            }
            else if (_TrangThai == "Giao hàng thành công")
            {
                return "#428720";
            }
            else
            {
                return "#DD000000";
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
