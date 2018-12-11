using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace STFU.Executable.AutoUploader.WPF.Converters
{
    public class EnumToInt32Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(int))
                throw new InvalidOperationException($"The target must be {typeof(int)}.");

            return (int)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!typeof(Enum).IsAssignableFrom(targetType))
                throw new InvalidOperationException($"The target must be an Enumeration.");

            return Enum.ToObject(targetType, value);
        }
    }
}
