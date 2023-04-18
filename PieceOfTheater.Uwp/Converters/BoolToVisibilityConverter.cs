using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace PieceOfTheater.Uwp.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public bool Inverted { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var result = (bool)value;

            if (Inverted)
                result = !result;

            return result ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            Visibility v = (Visibility)value;
            if (v == Visibility.Visible)
                return true;
            else
                return false;
        }
    }
}
