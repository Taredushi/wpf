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

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<User> _userCollection;
        private ViewDialog _previewDialog;
        private User _userPreview;

        public MainWindow()
        {
            InitializeComponent();
            _previewDialog = new ViewDialog();
            _userCollection = new ObservableCollection<User>();
            _userCollection.CollectionChanged += (e, v) => DisableButtons();
            UsersListBox.ItemsSource = _userCollection;
            DisableButtons();
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            _previewDialog?.Close();
            this.Close();
        }

        private void DisableButtons()
        {
            if (_userCollection.Count != 0) return;

            DeleteButton.IsEnabled = false;
            EditButton.IsEnabled = false;
            ViewButton.IsEnabled = false;
            _previewDialog?.Close();
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            var userdlg = new UserDialog();
            
            if (userdlg.ShowDialog() == true)
            {
                _userCollection.Add(userdlg.User);
            }
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            var msgBox = MessageBox.Show(this, "Na pewno usunąć?", "Delete", MessageBoxButton.OKCancel,
                MessageBoxImage.None, MessageBoxResult.Cancel);

            if (msgBox == MessageBoxResult.OK)
            {
                _userCollection.Remove((User) UsersListBox.SelectedItem);
            }
        }

        private void UsersListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UsersListBox.SelectedItems.Count > 0)
            {
                DeleteButton.IsEnabled = true;
                EditButton.IsEnabled = true;
                _userPreview = _userCollection[UsersListBox.SelectedIndex];

                if (_previewDialog != null && _previewDialog.IsLoaded)
                {
                    ViewButton.IsEnabled = false;
                    _previewDialog.User = _userPreview;
                    _previewDialog.Update();
                }
                else
                {
                    ViewButton.IsEnabled = true;
                }
            }
            else
            {
                DisableButtons();
            }
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            var userdlg = new UserDialog(UsersListBox.SelectedItem as User);

            if (userdlg.ShowDialog() == true)
            {
                _userCollection[UsersListBox.SelectedIndex] = userdlg.User;
                UsersListBox.Items.Refresh();
            }
        }

        private void ViewButton_OnClick(object sender, RoutedEventArgs e)
        {
            _previewDialog = new ViewDialog();
            _previewDialog.User = _userPreview;
            _previewDialog.Show();
        }

        public void Update()
        {
            int index = _userCollection.IndexOf(_userPreview);
            _userCollection[index] = _previewDialog.User;
            UsersListBox.Items.Refresh();
        }
    }
}
