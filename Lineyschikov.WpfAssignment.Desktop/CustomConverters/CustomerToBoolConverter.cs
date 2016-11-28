using System;
using System.Globalization;
using System.Windows.Data;
using Lineyschikov.WpfAssignment.Desktop.Models;

namespace Lineyschikov.WpfAssignment.Desktop.CustomConverters
{
    public class CustomerToBoolConverter : IValueConverter
    {
        public object ConvertBack(object o, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        public object Convert(object o, Type targetType, object parameter, CultureInfo culture)
        {
            if (o == null) return false;
            var customer = o as Customer;
            if (customer != null) return customer.Id != 0;
            throw new NotSupportedException();
        }

    }
}
            