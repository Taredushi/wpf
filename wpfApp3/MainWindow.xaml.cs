using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ContentTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ContentLabel.Content = ContentTextBox.Text;
        }

        #region Alignment

        private void HorizontalLeftRadioButton_OnChecked(object sender, RoutedEventArgs e)
        {
            ContentLabel.HorizontalAlignment = HorizontalAlignment.Left;
        }
        private void HorizontalRightRadioButton_OnChecked(object sender, RoutedEventArgs e)
        {
            ContentLabel.HorizontalAlignment = HorizontalAlignment.Right;
        }
        private void HorizontalCenterRadioButton_OnChecked(object sender, RoutedEventArgs e)
        {
            ContentLabel.HorizontalAlignment = HorizontalAlignment.Center;
        }
        private void HorizontalStretchRadioButton_OnChecked(object sender, RoutedEventArgs e)
        {
            ContentLabel.HorizontalAlignment = HorizontalAlignment.Stretch;
        }

        private void VerticalTopRadioButton_OnChecked(object sender, RoutedEventArgs e)
        {
            ContentLabel.VerticalAlignment = VerticalAlignment.Top;
        }
        private void VerticalBottomRadioButton_OnChecked(object sender, RoutedEventArgs e)
        {
            ContentLabel.VerticalAlignment = VerticalAlignment.Bottom;
        }
        private void VerticalCenterRadioButton_OnChecked(object sender, RoutedEventArgs e)
        {
            ContentLabel.VerticalAlignment = VerticalAlignment.Center;
        }
        private void VerticalStretchRadioButton_OnChecked(object sender, RoutedEventArgs e)
        {
            ContentLabel.VerticalAlignment = VerticalAlignment.Stretch;
        }

        #endregion

        #region Content Alignment

        private void ConHorizontalLeftRadioButton_OnChecked(object sender, RoutedEventArgs e)
        {
            ContentLabel.HorizontalContentAlignment = HorizontalAlignment.Left;
        }
        private void ConHorizontalRightRadioButton_OnChecked(object sender, RoutedEventArgs e)
        {
            ContentLabel.HorizontalContentAlignment = HorizontalAlignment.Right;
        }
        private void ConHorizontalCenterRadioButton_OnChecked(object sender, RoutedEventArgs e)
        {
            ContentLabel.HorizontalContentAlignment = HorizontalAlignment.Center;
        }
        private void ConHorizontalStretchRadioButton_OnChecked(object sender, RoutedEventArgs e)
        {
            ContentLabel.HorizontalContentAlignment = HorizontalAlignment.Stretch;
        }

        private void ConVerticalTopRadioButton_OnChecked(object sender, RoutedEventArgs e)
        {
            ContentLabel.VerticalContentAlignment = VerticalAlignment.Top;
        }
        private void ConVerticalBottomRadioButton_OnChecked(object sender, RoutedEventArgs e)
        {
            ContentLabel.VerticalContentAlignment = VerticalAlignment.Bottom;
        }
        private void ConVerticalCenterRadioButton_OnChecked(object sender, RoutedEventArgs e)
        {
            ContentLabel.VerticalContentAlignment = VerticalAlignment.Center;
        }
        private void ConVerticalStretchRadioButton_OnChecked(object sender, RoutedEventArgs e)
        {
            ContentLabel.VerticalContentAlignment = VerticalAlignment.Stretch;
        }

        #endregion

        #region Font

        private void BoldCheckbox_OnChecked(object sender, RoutedEventArgs e)
        {
            ContentLabel.FontWeight = FontWeights.Bold;
        }

        private void BoldCheckBox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            ContentLabel.FontWeight = FontWeights.Normal;
        }

        private void ItalicCheckbox_OnChecked(object sender, RoutedEventArgs e)
        {
            ContentLabel.FontStyle = FontStyles.Italic;
        }

        private void ItalicCheckBox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            ContentLabel.FontStyle = FontStyles.Normal;
        }

        private void FontSizeTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            int size;

            if (int.TryParse(FontSizeTextBox.Text, out size) && size > 0)
            {
                ContentLabel.FontSize = size;
            }
        }

        private void FontFamilyTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(FontFamilyTextBox.Text)) return;

            ContentLabel.FontFamily = new FontFamily(FontFamilyTextBox.Text);
        }

        #endregion

        #region Other

        private void MarginSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ContentLabel.Margin = new Thickness(MarginSlider.Value);
        }

        private void PaddingSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ContentLabel.Padding = new Thickness(PaddingSlider.Value);
        }

        private void BackgroundSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ContentLabel.Background = new SolidColorBrush(Color.FromRgb((byte)BackgroundSliderR.Value, (byte)BackgroundSliderG.Value, (byte)BackgroundSliderB.Value));
        }

        private void ForegroundTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            int r;
            int g;
            int b;

            if (int.TryParse(ForegroundTextBoxR.Text, out r) && int.TryParse(ForegroundTextBoxG.Text, out g) &&
                int.TryParse(ForegroundTextBoxB.Text, out b))
            {
                if (r <= 255 && g <= 255 && b <= 255 && r >= 0 && g >= 0 && b >= 0)
                {
                    ContentLabel.Foreground = new SolidColorBrush(Color.FromRgb((byte)r, (byte)g, (byte)b));
                }
            }
        }

        private void BorderBrushComboBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var selectedElement = BorderBrushComboBox.Text;
            if (string.IsNullOrEmpty(selectedElement)) return;

            try
            {
                var convertFromString = ColorConverter.ConvertFromString(selectedElement);
                if (convertFromString != null)
                {
                    var color = (Color)convertFromString;
                    ContentLabel.BorderBrush = new SolidColorBrush(color);
                }
            }
            catch
            {
                //ignore
            }
            
        }

        private void BorderThicknessSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ContentLabel.BorderThickness = new Thickness(BorderThicknessSlider.Value);
        }

        #endregion


    }
}
