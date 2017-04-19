using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp7
{
    class Osoba : INotifyPropertyChanged
    {
        public bool Szczegoly { get; set; }
        private string _imie;
        private string _nazwisko;
        private string _email;

        public string Imie
        {
            get { return _imie; }
            set
            {
                _imie = value;
                OnPropertyChanged("Display");
            }
        }

        public string Nazwisko
        {
            get { return _nazwisko; }
            set
            {
                _nazwisko = value;
                OnPropertyChanged("Display");
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Display");
            }
        }

        public double Kwota { get; set; }
        public string Region { get; set; }
        public int Dostep { get; set; }

        public string Display
        {
            get { return _imie + " " + _nazwisko + " (" + _email + ")"; }
        }

        public Osoba()
        {
            _imie = null;
            _nazwisko = null;
            _email = null;
            Kwota = 0;
            Region = null;
            Dostep = 0;
            Szczegoly = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
