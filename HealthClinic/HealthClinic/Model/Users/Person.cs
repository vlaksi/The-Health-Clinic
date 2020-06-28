// File:    Person.cs
// Author:  Vaxi
// Created: Wednesday, April 1, 2020 9:45:03 PM
// Purpose: Definition of Class Person

using HealthClinic.Utilities;
using System;

namespace Model.Users
{
    public class Person : ObservableObject
    {
        #region Attributes

        private int id;
        private string name;
        private string surname;
        private string gender;
        private DateTime _birthday;
        private string _adress;
        private string jmbg;
        private string parentsName;
        private string _biography;
        private string _phoneNumber;
        private string _email;
        #endregion

        public string Email
        {
            get { return _email; }
            set
            {
                if (value != _email)
                {
                    _email = value;
                    OnPropertyChanged("Email");
                }
            }
        }

        public string Jmbg
        {
            get { return jmbg; }
            set
            {
                if (value != jmbg)
                {
                    jmbg = value;
                    OnPropertyChanged("Jmbg");
                }
            }
        }

        public string ParentsName
        {
            get { return parentsName; }
            set
            {
                if (value != parentsName)
                {
                    parentsName = value;
                    OnPropertyChanged("ParentsName");
                }
            }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (value != _phoneNumber)
                {
                    _phoneNumber = value;
                    OnPropertyChanged("PhoneNumber");
                }
            }
        }

        #region Properties
        public string Adress
        {
            get { return _adress; }
            set
            {
                if (value != _adress)
                {
                    _adress = value;
                    OnPropertyChanged("Adress");
                }
            }
        }

        public string Biography
        {
            get { return _biography; }
            set
            {
                if (value != _biography)
                {
                    _biography = value;
                    OnPropertyChanged("Biography");
                }
            }
        }

        public DateTime Birthday
        {
            get { return _birthday; }
            set
            {
                if (value != _birthday)
                {
                    _birthday = value;
                    OnPropertyChanged("Birthday");
                }
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                this.surname = value;
                OnPropertyChanged("Surname");
            }
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                this.id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        #endregion
    }
}