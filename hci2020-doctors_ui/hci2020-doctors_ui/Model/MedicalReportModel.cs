using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hci2020_doctors_ui.Model
{
    public class MedicalReportModel : ObservableObject
    {
		private ObservableCollection<string> commonConditions;

		public ObservableCollection<string> CommonConditions
		{
			get { return commonConditions; }
			set { commonConditions = value; OnPropertyChanged("CommonConditions"); }
		}

		private string patientsReport;

		public string PatientsReport
		{
			get { return patientsReport; }
			set { patientsReport = value; OnPropertyChanged("PatientsReport"); }
		}

		private ObservableCollection<string> observations;

		public ObservableCollection<string> Observations
		{
			get { return observations; }
			set { observations = value; OnPropertyChanged("Observations"); }
		}

		private string doctorsRemark;

		public string DoctorsRemark
		{
			get { return doctorsRemark; }
			set { doctorsRemark = value; OnPropertyChanged("DoctorsRemark"); }
		}

		public MedicalReportModel() { }


	}
}
