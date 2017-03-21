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
using System.Drawing;
using System.Windows.Shapes;

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Point _startPoint;
        private Rectangle _lastRectangle;
        private bool _isDragging;

        public MainWindow()
        {
            InitializeComponent();
            KeyDown += MyCanvas_OnKeyDown;
            _isDragging = false;
        }


        private void MyCanvas_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                _startPoint = Mouse.GetPosition(MyCanvas);
                MyCanvas.CaptureMouse();
                _isDragging = true;
                CreateRectangle();
            }
        }

        private void MyCanvas_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released)
            {
                if (MyCanvas.IsMouseCaptured)
                {
                    var currentPosition = Mouse.GetPosition(MyCanvas);
                    if (currentPosition.X < _startPoint.X || currentPosition.Y < _startPoint.Y)
                    {
                        MyCanvas.Children.Remove(_lastRectangle);
                    }
                    else
                    {
                        ResizeRectangle(currentPosition);
                    }
                    _isDragging = false;
                    MyCanvas.ReleaseMouseCapture();
                    e.Handled = true;
                }
            }

        }

        private void MyCanvas_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (MyCanvas.IsMouseCaptured && _isDragging)
            {
                var currentPosition = Mouse.GetPosition(MyCanvas);
                if (currentPosition.X < _startPoint.X || currentPosition.Y < _startPoint.Y) return;
                ResizeRectangle(currentPosition);
            }
        }

        private void CreateRectangle()
        {
            _lastRectangle = new Rectangle()
            {
                Stroke = new SolidColorBrush(Colors.Blue),
            };
            MyCanvas.Children.Add(_lastRectangle);
            Canvas.SetLeft(_lastRectangle, _startPoint.X);
            Canvas.SetTop(_lastRectangle, _startPoint.Y);
        }

        private void ResizeRectangle(Point currentPosition)
        {
            var width = currentPosition.X - _startPoint.X;
            var height = currentPosition.Y - _startPoint.Y;
            _lastRectangle.Width = width;
            _lastRectangle.Height = height;
        }

        private void MyCanvas_OnKeyDown(object sender, KeyEventArgs e)
        {
            if ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift && e.Key == Key.Left)
            {
                var width = _lastRectangle.Width - 1;
                _lastRectangle.Width = width > 0 ? width : 1;
            }
            else if ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift && e.Key == Key.Right)
            {
                var width = _lastRectangle.Width + 1;
                _lastRectangle.Width = width + Canvas.GetLeft(_lastRectangle) < MyCanvas.ActualWidth
                    ? width
                    : MyCanvas.ActualWidth - Canvas.GetLeft(_lastRectangle);
            }
            else if ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift && e.Key == Key.Up)
            {
                var height = _lastRectangle.Height - 1;
                _lastRectangle.Height = height > 0 ? height : 1;
            }
            else if ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift && e.Key == Key.Down)
            {
                var height = _lastRectangle.Height + 1;
                _lastRectangle.Height = height + Canvas.GetTop(_lastRectangle) < MyCanvas.ActualHeight
                    ? height
                    : MyCanvas.ActualHeight - Canvas.GetTop(_lastRectangle);
            }
            else if (e.Key == Key.Left)
            {
                var left = Canvas.GetLeft(_lastRectangle) - 1;
                left = left >= 0 ? left : 0;
                Canvas.SetLeft(_lastRectangle, left);
            }
            else if (e.Key == Key.Right)
            {
                var left = Canvas.GetLeft(_lastRectangle) + 1;
                left = left + _lastRectangle.Width <= MyCanvas.ActualWidth
                    ? left
                    : MyCanvas.ActualWidth - _lastRectangle.Width;
                Canvas.SetLeft(_lastRectangle, left);
            }
            else if (e.Key == Key.Up)
            {
                var top = Canvas.GetTop(_lastRectangle) - 1;
                top = top >= 0 ? top : 0;
                Canvas.SetTop(_lastRectangle, top);
            }
            else if (e.Key == Key.Down)
            {
                var top = Canvas.GetTop(_lastRectangle) + 1;
                top = top + _lastRectangle.Height <= MyCanvas.ActualHeight
                    ? top
                    : MyCanvas.ActualHeight - _lastRectangle.Height;
                Canvas.SetTop(_lastRectangle, top);
            }
        }

    }
}
