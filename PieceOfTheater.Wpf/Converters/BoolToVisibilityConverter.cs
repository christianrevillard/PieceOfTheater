using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows;

namespace PieceOfTheater.Wpf.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {

        public bool Inverted { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool hide = false;

            if (parameter != null)
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                hide = parameter.ToString().Equals("hide", StringComparison.InvariantCultureIgnoreCase);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            }
            var result = (bool)value;

            if (Inverted)
                result = !result;

            return result ? Visibility.Visible : (hide ? Visibility.Hidden : Visibility.Collapsed);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility v = (Visibility)value;
            if (v == Visibility.Visible)
                return true;
            else
                return false;
        }
    }
}
