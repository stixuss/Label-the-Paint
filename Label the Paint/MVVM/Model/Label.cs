using Label_the_Paint.Core;
using System;


namespace Label_the_Paint.MVVM.Model
{
    public class Label : ObservableObject
    {

        private string _name = "Nazwa Farby";
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private string _number = "Numer Farby";
        public string Number
        {
            get
            {
                return _number;
            }

            set
            {
                _number = value;
                OnPropertyChanged();
            }
        }

        private string _catalog = "Numer katalogu";
        public string Catalog
        {
            get
            {
                return _catalog;
            }

            set
            {
                _catalog = value;
                OnPropertyChanged();
            }
        }

        private DateTime _date;
        public DateTime Date
        {
            get
            {
                return _date;
            }

            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        private string _code = "Kod farby";
        public string Code
        {
            get
            {
                return _code;
            }

            set
            {
                _code = value;
                OnPropertyChanged();
            }
        }
    }
}
