using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace STFU.Executable.AutoUploader.WPF.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(Visibility))
                throw new InvalidOperationException($"The target must be {typeof(Visibility)}.");

            return ((bool)value ? Visibility.Visible : Visibility.Hidden);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(bool))
                throw new InvalidOperationException($"The target must be {typeof(bool)}.");

            return (Visibility)value == Visibility.Visible;
        }

        #endregion Public Methods
    }
}