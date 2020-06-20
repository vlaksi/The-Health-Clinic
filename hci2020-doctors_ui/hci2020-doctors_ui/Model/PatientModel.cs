using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hci2020_doctors_ui.Model
{
    public class PatientModel : ObservableObject
    {

        #region Properties
        private string name;
		private DateTime birth;
		private string gender;
		private string email;
		private string phone;
		private string bloodType;
		private string allergies;
		private string diseases;
		private string accommodation;
		private string generalPracticioner;
		private ObservableCollection<Appointment> terms;
		private ObservableCollection<PrescriptionMedicineModel> therapy;
		private int id;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		public DateTime Birth
		{
			get { return birth; }
			set { birth = value; OnPropertyChanged("Birth"); }
		}
		public string Name
		{
			get { return name; }
			set { name = value; OnPropertyChanged("Name"); }
		}
		public string Gender
		{
			get { return gender; }
			set { gender = value; OnPropertyChanged("Gender"); }
		}
		public string BloodType
		{
			get { return bloodType; }
			set { bloodType = value; OnPropertyChanged("BloodType"); }
		}
		public string Email
		{
			get { return email; }
			set { email = value; OnPropertyChanged("Email"); }
		}
		public string Phone
		{
			get { return phone; }
			set { phone = value; OnPropertyChanged("Phone"); }
		}
		public string Allergies
		{
			get { return allergies; }
			set { allergies = value; OnPropertyChanged("Allergies"); }
		}
		public string Diseases
		{
			get { return diseases; }
			set { diseases = value; OnPropertyChanged("Diseases"); }
		}
		public string Accommodate
		{
			get { return accommodation; }
			set { accommodation = value; OnPropertyChanged("Accommodate"); }
		}
		public string GeneralPracticioner
		{
			get { return generalPracticioner; }
			set { generalPracticioner = value; OnPropertyChanged("GeneralPracticioner"); }
		}
		public ObservableCollection<Appointment> Terms
		{
			get { return terms; }
			set { terms = value; OnPropertyChanged("Terms"); }
		}
		public ObservableCollection<PrescriptionMedicineModel> Therapy
		{
			get { return therapy; }
			set { therapy = value; OnPropertyChanged("Therapy"); }
		}
        #endregion





    }
}
