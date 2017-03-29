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
    /// Interaction logic for UserDialog.xaml
    /// </summary>
    public partial class UserDialog : Window
    {
        public User User { get; set; }

        public UserDialog()
        {
            InitializeComponent();
        }

        public UserDialog(User user)
        {
            User = user;
            InitializeComponent();
        }

        private void UserDialog_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (User != null)
            {
                NameTb.Text = User.Name;
                SurnameTb.Text = User.Surname;
                EmailTb.Text = User.Email;
            }
        }

        private void OkButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (User == null)
            {
                User = new User();
            }
            User.Name = NameTb.Text;
            User.Surname = SurnameTb.Text;
            User.Email = EmailTb.Text;

            this.DialogResult = true;
            Close();
        }

        private void CancleButton_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
