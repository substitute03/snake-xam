using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace SnakeMobile.ValueConverters
{
    public class TimeSpanToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TimeSpan fromValue = (TimeSpan)value;
            string toValue = $"{fromValue.Minutes}:{fromValue.Seconds}";
            return toValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string fromValue = value.ToString();
            TimeSpan toValue = new TimeSpan();

            int minutes = int.Parse(fromValue.Substring(0, fromValue.IndexOf(":")));
            int seconds = int.Parse(fromValue.Substring(fromValue.IndexOf(":"), fromValue.Length - 1));

            int totalSeconds = (minutes * 60) + seconds;

            DateTime baselineTime = DateTime.UtcNow;
            DateTime toTime = baselineTime.AddSeconds(totalSeconds);

            toValue = toTime - baselineTime;

            return toValue;
        }
    }
}
