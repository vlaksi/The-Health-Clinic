using Controller.MedicalRecordContr;
using Controller.PatientContr;
using Model.MedicalRecord;
using Model.Users;
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
using System.Windows.Shapes;

namespace SekretarWPF
{
    /// <summary>
    /// Interaction logic for AddMedicalRecord.xaml
    /// </summary>
    public partial class AddMedicalRecord : Window, INotifyPropertyChanged
    {

        private PatientModel medicalRecord;
        private PatientController controller = new PatientController();
        private string mode;

        public PatientModel MedicalRecord
        {
            get { return medicalRecord; }
            set
            {
                medicalRecord = value;
                this.OnPropertyChanged("MedicalRecord");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public AddMedicalRecord()
        {
            InitializeComponent();
            this.DataContext = this;
            this.Closing += AddMedicalRecord_Closing;
        }

        private void AddMedicalRecord_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }

        private void OnPropertyChanged(String name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            PatientModel medicalRecord = this.MedicalRecord;
            medicalRecord.Name = this.tbName.Text;
            medicalRecord.Surname = this.tbSurname.Text;
            medicalRecord.Gender = getGender();
            medicalRecord.Birthday = (DateTime)this.dpBirth.SelectedDate;
            medicalRecord.Adress = this.tbAddress.Text;
            medicalRecord.Jmbg = this.tbJMBG.Text;
            medicalRecord.ParentsName = this.tbParentName.Text;
            medicalRecord.PhoneNumber = this.tbPhone.Text;
            medicalRecord.Email = this.tbEmail.Text;
            medicalRecord.Biography = this.tbBiography.Text;

            if(mode.Equals("edit"))
            {
                controller.SavePatient(medicalRecord);
            } else if(mode.Equals("new"))
            {
                controller.PatientRegister(medicalRecord);
                UserControlPatients.data.Add(medicalRecord);
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        internal void EditMedicalRecord(PatientModel medicalRecord)
        {
            mode = "edit";
            this.nameFieldError.Visibility = Visibility.Hidden;
            this.surnameFieldError.Visibility = Visibility.Hidden;
            this.MedicalRecord = medicalRecord;
            setGender();
            this.Visibility = Visibility.Visible;
            this.delete.Visibility = Visibility.Visible;
        }

        internal void AddNewMedicalRecord()
        {
            mode = "new";
            this.nameFieldError.Visibility = Visibility.Visible;
            this.surnameFieldError.Visibility = Visibility.Visible;
            this.save.IsEnabled = false;

            this.MedicalRecord = new PatientModel();
            this.Visibility = Visibility.Visible;
            this.delete.Visibility = Visibility.Collapsed;
        }

        private void setGender()
        {
            if(this.MedicalRecord.Gender.Equals("Male"))
            {
                rbMale.IsChecked = true;
            } else
            {
                rbFemale.IsChecked = true;
            }
        }

        private String getGender()
        {
            if((bool)rbMale.IsChecked)
            {
                return "Male";
            } else
            {
                return "Female";
            }
        }

        private void tbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!tbName.Text.Trim().Equals("") )
            {
                this.nameFieldError.Visibility = Visibility.Hidden;
                if(!tbSurname.Text.Trim().Equals(""))
                    save.IsEnabled = true;
            } else
            {
                save.IsEnabled = false;
                this.nameFieldError.Visibility = Visibility.Visible;
            }
        }

        private void tbSurname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!tbSurname.Text.Trim().Equals(""))
            {
                this.surnameFieldError.Visibility = Visibility.Hidden;
                if (!tbName.Text.Trim().Equals(""))
                    save.IsEnabled = true;
            }
            else
            {
                save.IsEnabled = false;
                this.surnameFieldError.Visibility = Visibility.Visible;
            }
        }
    }
}
