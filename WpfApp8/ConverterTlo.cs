using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfApp8
{
    public class ConverterTlo : IValueConverter
    {
        public Brush MeskiBrush { get; set; }
        public Brush ZenskiBrush { get; set; }
        public Brush DefaultBrush { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                string plec = (string)value;
                if (plec.Equals("Mezczyzna"))
                {
                    return MeskiBrush;
                }
                if (plec.Equals("Kobieta"))
                {
                    return ZenskiBrush;
                }
                return DefaultBrush;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
