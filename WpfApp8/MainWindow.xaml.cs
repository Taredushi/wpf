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

namespace WpfApp8
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
            _dropList = new List<string>();
            _dataSource = new ObservableCollection<Osoba>();
            InitializeComponent();
            

            OsobyListBox.ItemsSource = _dataSource;
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

        private ListCollectionView View
        {
            get
            {
                return (ListCollectionView)CollectionViewSource.GetDefaultView(_dataSource);
            }
        }

        private void AddRegion()
        {
            _dropList.Add("Białystok");
            _dropList.Add("Kraków");
            _dropList.Add("Płock");
            _dropList.Add("Warszawa");
            _dropList.Add("Wrocław");
        }

        private void Filter(object sender, RoutedEventArgs e)
        {
            var region = regionfiltertxt.Text;
            View.Filter = delegate (object item)
            {
                var osoba = item as Osoba;
                if (osoba != null)
                {
                    return osoba.Region.ToLower().Equals(region.ToLower());
                }
                return false;
            };
        }
        private void ClearFilter(object sender, RoutedEventArgs e)
        {
            View.Filter = null;
        }

        private void GroupNone(object sender, RoutedEventArgs e)
        {
            if (View.GroupDescriptions != null) View.GroupDescriptions.Clear();
        }

        private void GroupMale(object sender, RoutedEventArgs e)
        {
            if (View.GroupDescriptions == null) return;
            View.GroupDescriptions.Clear();
            View.GroupDescriptions.Add(new PropertyGroupDescription("Plec"));
        }

        private void GroupName(object sender, RoutedEventArgs e)
        {
            if (View.GroupDescriptions == null) return;
            View.GroupDescriptions.Clear();
            View.GroupDescriptions.Add(new PropertyGroupDescription("Imie"));
        }

        private void GroupAge(object sender, RoutedEventArgs e)
        {
            if (View.GroupDescriptions == null) return;
            View.GroupDescriptions.Clear();
            ConverterAge grouper = new ConverterAge();
            grouper.GroupInterval = 15;

            View.GroupDescriptions.Add(new PropertyGroupDescription("Wiek", grouper));
        }
    }
}
