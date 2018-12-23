using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace STFU.Executable.AutoUploader.WPF.Converters
{
    public class Int32ToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(string))
                throw new ArgumentException("targetType must be a string.", nameof(targetType));
            return ((int)value).ToString("00");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(string))
                throw new ArgumentException($"targetType must be of type {typeof(int)}.", nameof(targetType));
            int.TryParse((string)value, out int result);
            return result;
        }
    }
}
