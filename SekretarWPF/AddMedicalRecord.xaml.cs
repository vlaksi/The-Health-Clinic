using SekretarWPF.Data;
using SekretarWPF.Model;
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

        private MedicalRecord medicalRecord;

        public MedicalRecord MedicalRecord
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
            MedicalRecord medicalRecord = this.MedicalRecord;
            medicalRecord.Name = this.tbName.Text;
            medicalRecord.Surname = this.tbSurname.Text;
            medicalRecord.Gender = getGender();
            medicalRecord.DateOfBirth = (DateTime)this.dpBirth.SelectedDate;
            medicalRecord.Address = this.tbAddress.Text;
            medicalRecord.JMBG = this.tbJMBG.Text;
            medicalRecord.ParentName = this.tbParentName.Text;
            medicalRecord.HealthInsuranceNumber = this.tbHealthInsuranceNumber.Text;
            medicalRecord.Phone = this.tbPhone.Text;
            medicalRecord.HealthInsuranceCarrier = this.tbHealthInsuranceCarrier.Text;

            if (!DummyData.medicalRecords.Contains(medicalRecord))
                DummyData.medicalRecords.Add(medicalRecord);
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        internal void EditMedicalRecord(MedicalRecord medicalRecord)
        {
            this.nameFieldError.Visibility = Visibility.Hidden;
            this.surnameFieldError.Visibility = Visibility.Hidden;
            this.MedicalRecord = medicalRecord;
            setGender();
            this.Visibility = Visibility.Visible;
            this.delete.Visibility = Visibility.Visible;
        }

        internal void AddNewMedicalRecord()
        {
            this.nameFieldError.Visibility = Visibility.Visible;
            this.surnameFieldError.Visibility = Visibility.Visible;
            this.save.IsEnabled = false;

            this.MedicalRecord = new MedicalRecord();
            this.Visibility = Visibility.Visible;
            this.delete.Visibility = Visibility.Collapsed;
        }

        private void setGender()
        {
            if(this.MedicalRecord.Gender == Gender.Male)
            {
                rbMale.IsChecked = true;
            } else
            {
                rbFemale.IsChecked = true;
            }
        }

        private Gender getGender()
        {
            if((bool)rbMale.IsChecked)
            {
                return Gender.Male;
            } else
            {
                return Gender.Female;
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
