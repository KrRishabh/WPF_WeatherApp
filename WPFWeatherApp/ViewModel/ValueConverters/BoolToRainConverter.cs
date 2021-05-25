using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPFWeatherApp.ViewModel.ValueConverters
{
    public class BoolToRainConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isRaining = (bool)value;
            if (isRaining)
                return "Raining";
            return "Not Raining";

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string displayMessage = (string)value;
            if (displayMessage == "Raining")
                return true;
            return false;
        }
    }
}
