using System;
using System.Globalization;
using System.Windows.Data;

namespace STFU.Executable.AutoUploader.WPF.Converters
{
    public class InverseBooleanConverter : IValueConverter
    {
        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(bool))
                throw new InvalidOperationException($"The target must be {typeof(bool)}.");

            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion Public Methods
    }
}