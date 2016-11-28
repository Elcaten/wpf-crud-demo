using System;
using System.Globalization;
using System.Windows.Data;
using Lineyschikov.WpfAssignment.Desktop.Models;

namespace Lineyschikov.WpfAssignment.Desktop.CustomConverters
{
    public class NullToBoolConverter : IValueConverter
    {
        public object ConvertBack(object o, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        public object Convert(object o, Type targetType, object parameter, CultureInfo culture)
        {
            return o != null;
        }

    }
}