using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace SnakeMobile.ValueConverters
{
    public class IntToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int fromValue = (int)value;
            string toValue = fromValue.ToString();
            return toValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string fromValue = value.ToString();
            int toValue = int.Parse(fromValue);
            return toValue;
        }
    }
}
