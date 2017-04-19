using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApp8
{
    public class ConverterKwota : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double cena = (double)value * 100 / 123;
            return cena.ToString("C", culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string cena = value.ToString();
            double wynik;
            if (Double.TryParse(cena, NumberStyles.Any, culture, out wynik))
            {
                return wynik + 0.23 * wynik;
            }
            return value;
        }
    }
}
