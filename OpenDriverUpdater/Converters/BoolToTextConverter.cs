// DriverPro/Converters/BoolToTextConverter.cs
using System;
using System.Globalization;
using System.Windows.Data;

namespace DriverPro.Converters
{
    // ConverterParameter="TextFalse|TextTrue"
    public sealed class BoolToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var p = (parameter as string)?.Split('|');
            if (p == null || p.Length != 2) return "";
            bool b = value is bool v && v;
            return b ? p[1] : p[0];
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotSupportedException();
    }
}
