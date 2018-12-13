using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace STFU.Executable.AutoUploader.WPF.Converters
{
    public class BooleanAndMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (!values.All(e => e is bool))
                values = values.Where(e => e is bool).ToArray();

            if (values.Length == 2)
                return (bool)values[0] && (bool)values[1];

            bool result = false;
            for (int i = 0; i < values.Length; i++)
                result &= (bool)values[i];
            return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back.");
        }
    }
}
