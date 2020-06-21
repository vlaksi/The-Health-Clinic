using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekretarWPF.Model
{
    public enum Gender
    {
        Male,
        Female
    }
    public class MedicalRecord : INotifyPropertyChanged
    {

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
                OnPropertyChanged("Initials");
            }
        }

        private string surname;
        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged("Surname");
                OnPropertyChanged("Initials");
            }
        }

        public string Initials
        {
            get
            {
                if(selected)
                {
                    return "✓";
                } else
                {
                    string initials = "";
                    initials += name.Substring(0, 1);
                    initials += surname.Substring(0, 1);
                    initials = initials.ToUpper();
                    return initials;
                }
            }
        }

        private bool selected = false;
        public bool Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged("Initials");
            }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }

        private Gender gender;
        public Gender Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                OnPropertyChanged("Gender");
            }
        }

        private string jmbg;
        public string JMBG
        {
            get { return jmbg; }
            set
            {
                jmbg = value;
                OnPropertyChanged("JMBG");
            }
        }

        private DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                dateOfBirth = value;
                OnPropertyChanged("DateOfBirth");
            }
        }

        private string parentName;
        public string ParentName
        {
            get { return parentName; }
            set
            {
                parentName = value;
                OnPropertyChanged("ParentName");
            }
        }

        private string healthInsuranceNumber;
        public string HealthInsuranceNumber
        {
            get { return healthInsuranceNumber; }
            set
            {
                healthInsuranceNumber = value;
                OnPropertyChanged("HealthInsuranceNumber");
            }
        }

        private string phone;
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChanged("Phone");
            }
        }

        private string healthInsuranceCarrier;
        public string HealthInsuranceCarrier
        {
            get { return healthInsuranceCarrier; }
            set
            {
                healthInsuranceCarrier = value;
                OnPropertyChanged("HealthInsuranceCarrier");
            }
        }

        public MedicalRecord()
        {
        }

        public MedicalRecord(string name, string surname, string address, Gender gender, string jmbg,
                             DateTime dateOfBirth, string parentName, string healthInsuranceNumber,
                             string phone, string healthInsuranceCarrier)
        {
            this.name = name;
            this.surname = surname;
            this.address = address;
            this.gender = gender;
            this.jmbg = jmbg;
            this.dateOfBirth = dateOfBirth;
            this.parentName = parentName;
            this.healthInsuranceNumber = healthInsuranceNumber;
            this.phone = phone;
            this.healthInsuranceCarrier = healthInsuranceCarrier;
        }
        private void OnPropertyChanged(string propertyName)
        {
            var eventHandler = PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public new event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return name + " " + surname + ", " + jmbg;
        }
    }
}
