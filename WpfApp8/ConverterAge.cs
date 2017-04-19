using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApp8
{
    public class ConverterAge : IValueConverter
    {
        public int GroupInterval { get; set; }

        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            int age = (int) value;
            if (age < GroupInterval)
            {
                return String.Format(culture, "Mniej niż {0:d} lat",
                    GroupInterval);
            }
            else
            {
                int interval = (int) age / GroupInterval;
                int lowerLimit = interval * GroupInterval;
                int upperLimit = (interval + 1) * GroupInterval;
                return String.Format(culture, "{0:d} – {1:d}",
                    lowerLimit, upperLimit);
            }
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
