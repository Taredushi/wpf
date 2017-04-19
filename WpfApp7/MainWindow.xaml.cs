using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace WpfApp7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> _dropList;
        private ObservableCollection<Osoba> _dataSource;


        public MainWindow()
        {
            InitializeComponent();
            _dropList = new List<string>();
            _dataSource = new ObservableCollection<Osoba>();

            OsobyListBox.ItemsSource = _dataSource;
            OsobyListBox.DisplayMemberPath = "Display";
            ComboBox.ItemsSource = _dropList;

            AddRegion();
        }

        private void UsunButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (OsobyListBox.SelectedItems.Count == 0) return;
            _dataSource.RemoveAt(OsobyListBox.SelectedIndex);
        }

        private void DodajButton_OnClick(object sender, RoutedEventArgs e)
        {
            _dataSource.Add(new Osoba());

            OsobyListBox.SelectedIndex = _dataSource.Count - 1;
            ImieTb.Focus();
        }


        private void AddRegion()
        {
            _dropList.Add("Białystok");
            _dropList.Add("Kraków");
            _dropList.Add("Płock");
            _dropList.Add("Warszawa");
            _dropList.Add("Wrocław");
        }
    }
}
