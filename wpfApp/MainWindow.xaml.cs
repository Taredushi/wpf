using System;
using System.Collections.Generic;
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

namespace wpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CustomStack _stack;
        public MainWindow()
        {
            InitializeComponent();
            _stack = new CustomStack();
        }

        private void PushButton_OnClick(object sender, RoutedEventArgs e)
        {
            _stack.Push(TextBox.Text);
            Label.Content = _stack.Top();
        }

        private void PopButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (_stack.Empty())
            {
                Label.Content = "Pusty stos";
            }
            else
            {
                _stack.Pop();
                Label.Content = _stack.Empty() ? "Pusty stos" : _stack.Top();
            }
        }
    }
}
