using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            UpCommand = new MyCommand();
            DownCommand = new MyCommand();
            UpCommand.Function = OnUp;
            DownCommand.Function = OnDown;
            UpButtons_CheckStatus();
            DownButtons_CheckStatus();
            DataContext = this;
        }

        public MyCommand UpCommand { get; set; }
        public MyCommand DownCommand { get; set; }

        private void OnUp(string parameter)
        {
            if (parameter.Equals("One"))
            {
                var item = A.Items[0] as ListBoxItem;
                BuforTb.Text = item.Content.ToString();
                A.Items.RemoveAt(0);
            }
            else if (parameter.Equals("Two"))
            {
                var item = B.Items[0] as ListBoxItem;
                BuforTb.Text = item.Content.ToString();
                B.Items.RemoveAt(0);
            }
            else if (parameter.Equals("Three"))
            {
                var item = C.Items[0] as ListBoxItem;
                BuforTb.Text = item.Content.ToString();
                C.Items.RemoveAt(0);
            }
        }

        private void OnDown(string parameter)
        {
            var item = new ListBoxItem();
            item.Content = BuforTb.Text;

            if (parameter.Equals("One"))
            {
                A.Items.Insert(0, item);
            }
            else if (parameter.Equals("Two"))
            {
                B.Items.Insert(0, item);
            }
            else if (parameter.Equals("Three"))
            {
                C.Items.Insert(0, item);
            }

            BuforTb.Text = null;
        }

        private void UpButtons_CheckStatus()
        {
            OneUp.IsEnabled = A.Items.Count != 0 && string.IsNullOrEmpty(BuforTb.Text);
            TwoUp.IsEnabled = B.Items.Count != 0 && string.IsNullOrEmpty(BuforTb.Text);
            ThreeUp.IsEnabled = C.Items.Count != 0 && string.IsNullOrEmpty(BuforTb.Text);
        }

        private void DownButtons_CheckStatus()
        {
            var result = !string.IsNullOrEmpty(BuforTb.Text);
            if (A.Items.Count == 0)
            {
                OneDown.IsEnabled = result;
            }
            else
            {
                OneDown.IsEnabled = result && int.Parse((A.Items[0] as ListBoxItem).Content.ToString()) >= int.Parse(BuforTb.Text);
            }
            if (B.Items.Count == 0)
            {
                TwoDown.IsEnabled = result;
            }
            else
            {
                TwoDown.IsEnabled = result && int.Parse((B.Items[0] as ListBoxItem).Content.ToString()) >= int.Parse(BuforTb.Text);
            }
            if (C.Items.Count == 0)
            {
                ThreeDown.IsEnabled = result;
            }
            else
            {
                ThreeDown.IsEnabled = result && int.Parse((C.Items[0] as ListBoxItem).Content.ToString()) >= int.Parse(BuforTb.Text);
            }
            
        }

        private void BuforTb_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            DownButtons_CheckStatus();
            UpButtons_CheckStatus();
        }
    }
}
