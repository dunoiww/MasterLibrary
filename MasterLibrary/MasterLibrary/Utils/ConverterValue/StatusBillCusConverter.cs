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
                return "#0f82af";
            }
            else
            {
                return "#808080";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
