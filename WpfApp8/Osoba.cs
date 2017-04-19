using System;
using System.ComponentModel;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;

namespace WpfApp8
{
    class Osoba : INotifyPropertyChanged, IDataErrorInfo
    {
        public bool Szczegoly { get; set; }
        private string _imie;
        private string _nazwisko;
        private string _email;
        private string _plec;
        public string Pesel { get; set; }
        public int Wiek { get; set; }


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

        public string Plec
        {
            get { return _plec; }
            set
            {
                _plec = value;
                OnPropertyChanged("Plec");
            }
        }

        public bool PlecK
        {
            get { return Plec.Equals("Kobieta"); }
            set
            {
                Plec = "Kobieta";
                OnPropertyChanged("PlecM");
            }
        }

        public bool PlecM
        {
            get { return Plec.Equals("Mezczyzna"); }
            set
            {
                Plec = "Mezczyzna";
                OnPropertyChanged("PlecK");
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
            Imie = null;
            Nazwisko = null;
            Email = null;
            Kwota = 0;
            Region = null;
            Dostep = 0;
            Szczegoly = false;
            Plec = "";
            Wiek = 1;
            Pesel = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public string Error { get; }

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Pesel":
                        long pesel;
                        if (long.TryParse(Pesel, out pesel))
                        {
                            if (Pesel.Length != 11)
                            {
                                return "Pesel musi mieć 11 znaków!";
                            }
                        }
                        else
                        {
                            return "Niepoprawny format pesela!";
                        }
                        break;
                    case "Imie":
                        if (string.IsNullOrEmpty(Imie))
                        {
                            return "Imię nie może być puste!";
                        }
                        break;
                    case "Nazwisko":
                        if (string.IsNullOrEmpty(Imie))
                        {
                            return "Nazwisko nie może być puste!";
                        }
                        break;
                    case "Wiek":
                        if (Wiek <= 0 || Wiek > 150)
                        {
                            return "Wiek musi być miedzy  1 - 150";
                        }
                        break;
                    case "Kwota":
                        if (Kwota < 0)
                        {
                            return "Kwota musi być większa od 0";
                        }
                        break;
                    case "Email":
                        if (!string.IsNullOrEmpty(Email))
                        {
                            try
                            {
                                MailAddress mail = new MailAddress(Email);
                                _email = Email;
                            }
                            catch (FormatException)
                            {
                                _email = null;
                                return "Niepoprawny format adresu email!";
                            }
                        }
                        break;
                }
                return null;
            }
        }
    }
}
