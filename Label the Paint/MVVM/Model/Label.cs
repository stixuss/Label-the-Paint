using Label_the_Paint.Core;
using System;


namespace Label_the_Paint.MVVM.Model
{
    class Label : ObservableObject
    {
        public Label()
        {

        }

        string _name = "";
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        string _number = "";
        public string Number
        {
            get
            {
                return _number;
            }

            set
            {
                _number = value;
                OnPropertyChanged("Number");
            }
        }

        string _catalog = "";
        public string Catalog
        {
            get
            {
                return _catalog;
            }

            set
            {
                _catalog = value;
                OnPropertyChanged("Catalog");
            }
        }

        DateTime _date;
        public DateTime Date
        {
            get
            {
                return _date;
            }

            set
            {
                _date = value;
                OnPropertyChanged("Date");
            }
        }

        string _code = "";
        public string Code
        {
            get
            {
                return _code;
            }

            set
            {
                _code = value;
                OnPropertyChanged("Code");
            }
        }
    }
}
