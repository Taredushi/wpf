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
using System.Windows.Shapes;

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for ViewDialog.xaml
    /// </summary>
    public partial class ViewDialog : Window
    {
        public User User { get; set; }
        private MainWindow main;

        public ViewDialog()
        {
            InitializeComponent();
            main = Application.Current.MainWindow as MainWindow;
        }

        private void ViewDialog_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (User != null)
            {
                NameTb.Text = User.Name;
                SurnameTb.Text = User.Surname;
                EmailTb.Text = User.Email;
            }
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void NameTb_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            User.Name = NameTb.Text;
            main.Update();
        }

        private void SurnameTb_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            User.Surname = SurnameTb.Text;
            main.Update();
        }

        private void EmailTb_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            User.Email = EmailTb.Text;
            main.Update();
        }

        public void Update()
        {
            if (User != null)
            {
                NameTb.Text = User.Name;
                SurnameTb.Text = User.Surname;
                EmailTb.Text = User.Email;
            }
        }
    }
}
