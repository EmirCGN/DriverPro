// DriverPro/Converters/NavEqualsConverter.cs
using System;
using System.Globalization;
using System.Windows.Data;
using DriverPro.ViewModels;

namespace DriverPro.Converters
{
    public sealed class NavEqualsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is NavPage v && parameter is string s && Enum.TryParse<NavPage>(s, out var p))
                return v.Equals(p);
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b && b && parameter is string s && Enum.TryParse<NavPage>(s, out var p))
                return p;
            return Binding.DoNothing;
        }
    }
}
