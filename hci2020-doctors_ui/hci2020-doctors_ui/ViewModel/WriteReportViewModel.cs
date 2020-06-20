using hci2020_doctors_ui.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace hci2020_doctors_ui.ViewModel
{
    public class WriteReportViewModel : BaseViewModel
    {
        #region Properties

        #region Airway buttons
        private bool airway1;

        public bool Airway1
        {
            get { return airway1; }
            set
            {
                airway1 = value;
                if (airway1)
                {
                    Airway2 = false;
                    Airway3 = false;
                }
                OnPropertyChanged("Airway1");
            }
        }

        private bool airway2;

        public bool Airway2
        {
            get { return airway2; }
            set
            {
                airway2 = value;
                if (airway2)
                {
                    Airway1 = false;
                    Airway3 = false;
                }
                OnPropertyChanged("Airway2");
            }
        }

        private bool airway3;

        public bool Airway3
        {
            get { return airway3; }
            set
            {
                airway3 = value;
                if (airway3)
                {
                    Airway2 = false;
                    Airway1 = false;
                }
                OnPropertyChanged("Airway3");
            }
        }
        #endregion

        #region Breathing buttons
        private bool breathing1;

        public bool Breathing1
        {
            get { return breathing1; }
            set
            {
                breathing1 = value;
                if (breathing1)
                {
                    Breathing2 = false;
                    Breathing3 = false;
                }
                OnPropertyChanged("Breathing1");
            }
        }

        private bool breathing2;

        public bool Breathing2
        {
            get { return breathing2; }
            set
            {
                breathing2 = value;
                if (breathing2)
                {
                    Breathing1 = false;
                    Breathing3 = false;
                }
                OnPropertyChanged("Breathing2");
            }
        }

        private bool breathing3;

        public bool Breathing3
        {
            get { return breathing3; }
            set
            {
                breathing3 = value;
                if (breathing3)
                {
                    Breathing2 = false;
                    Breathing1 = false;
                }
                OnPropertyChanged("Breathing3");
            }
        }

        #endregion

        #region Pupils buttons
        private bool pupils1;

        public bool Pupils1
        {
            get { return pupils1; }
            set
            {
                pupils1 = value;
                if (pupils1)
                {
                    Pupils2 = false;
                }
                OnPropertyChanged("Pupils1");
            }
        }
        private bool pupils2;

        public bool Pupils2
        {
            get { return pupils2; }
            set
            {
                pupils2 = value;
                if (pupils2)
                {
                    Pupils1 = false;
                }
                OnPropertyChanged("Pupils2");
            }
        }
        #endregion

        private string upperBloodPressure;

        public string UpperBloodPressure
        {
            get { return upperBloodPressure; }
            set { upperBloodPressure = value; OnPropertyChanged("UpperBloodPressure"); }
        }

        private string lowerBloodPressure;

        public string LowerBloodPressure
        {
            get { return lowerBloodPressure; }
            set { lowerBloodPressure = value; OnPropertyChanged("LowerBloodPressure"); }
        }

        private string temperature;

        public string Temperature
        {
            get { return temperature; }
            set { temperature = value; OnPropertyChanged("Temperature"); }
        }

        private string heartRate;

        public string HeartRate
        {
            get { return heartRate; }
            set { heartRate = value; OnPropertyChanged("HeartRate"); }
        }


        private string patientsReport;

        public string PatientsReport
        {
            get { return patientsReport; }
            set { patientsReport = value; OnPropertyChanged("PatientsReport"); }
        }

        private string remarks;

        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; OnPropertyChanged("Remarks"); }
        }


        private ObservableCollection<string> purposeCollection;
        public ObservableCollection<string> PurposeCollection
        {
            get
            {
                return new ObservableCollection<String>()
            {
                (string)Application.Current.Resources["General Checkup"],
                (string)Application.Current.Resources["Post-operation Checkup"],
                (string)Application.Current.Resources["Pre-operation Checkup"],
                (string)Application.Current.Resources["Control Checkup"],
                (string)Application.Current.Resources["Surgery Report"],
                (string)Application.Current.Resources["Accident Report"],
                (string)Application.Current.Resources["Emergency Report"],
            };
            }
            set { purposeCollection = value; OnPropertyChanged("PurposeCollection"); }
        }
        private PatientModel patient;

        public PatientModel Patient
        {
            get { return patient; }
            set { patient = value; OnPropertyChanged("Patient"); }
        }

        public string SelectedPurpose { get; set; }

        private string searchText;

        public string SearchText
        {
            get { return searchText; }
            set { searchText = value; OnPropertyChanged("SearchText"); }
        }

        private ObservableCollection<string> commonMedicalConditionsFiltered;

        public ObservableCollection<string> CommonMedicalConditionsFiltered
        {
            get
            {
                return commonMedicalConditionsFiltered;
                /*return new ObservableCollection<string>()
            {
                (string)Application.Current.Resources["AlcoholLabel"],
                (string)Application.Current.Resources["StrokeLabel"],
                (string)Application.Current.Resources["Fever"],
                (string)Application.Current.Resources["Drug Dependence"],
                (string)Application.Current.Resources["Seizure(s) - Cerebral"],
                (string)Application.Current.Resources["Seizure(s) - Alcohol related"],
                (string)Application.Current.Resources["Heart Disease"],
                (string)Application.Current.Resources["Motor Function/Ability Impaired"],
                (string)Application.Current.Resources["Visual Acuity Impairment"],
                (string)Application.Current.Resources["Visual Field Impairment"],
                (string)Application.Current.Resources["Mental or Emotional Illness"],
                (string)Application.Current.Resources["Dementia or Alzheimer's"],
                (string)Application.Current.Resources["Sleep Apnea"],
                (string)Application.Current.Resources["Narcolepsy"],
                (string)Application.Current.Resources["Diabetes or Hypoglicemia"],
                (string)Application.Current.Resources["Blackout or Loss of Awareness"],
                (string)Application.Current.Resources["Bone or Join deformity"],
                (string)Application.Current.Resources["Loss of Memory"],
                (string)Application.Current.Resources["Skin Disease"],
                (string)Application.Current.Resources["Intestinal Troubles"],
                (string)Application.Current.Resources["Skin Disease"],
                (string)Application.Current.Resources["Swollen or Painful Joints"],
                (string)Application.Current.Resources["Chronic Cough"],
                (string)Application.Current.Resources["Car or Sea Sickness"],
                (string)Application.Current.Resources["Rapid Gain/Loss of Weight"]
            };*/
            }
            set { commonMedicalConditionsFiltered = value; OnPropertyChanged("CommonMedicalConditionsFiltered"); }
        }


        private ObservableCollection<string> commonMedicalConditions;
        public ObservableCollection<string> CommonMedicalConditions
        {
            get
            {
                return new ObservableCollection<string>()
            {
                (string)Application.Current.Resources["AlcoholLabel"],
                (string)Application.Current.Resources["StrokeLabel"],
                (string)Application.Current.Resources["Fever"],
                (string)Application.Current.Resources["Drug Dependence"],
                (string)Application.Current.Resources["Seizure(s) - Cerebral"],
                (string)Application.Current.Resources["Seizure(s) - Alcohol related"],
                (string)Application.Current.Resources["Heart Disease"],
                (string)Application.Current.Resources["Motor Function/Ability Impaired"],
                (string)Application.Current.Resources["Visual Acuity Impairment"],
                (string)Application.Current.Resources["Visual Field Impairment"],
                (string)Application.Current.Resources["Mental or Emotional Illness"],
                (string)Application.Current.Resources["Dementia or Alzheimer's"],
                (string)Application.Current.Resources["Sleep Apnea"],
                (string)Application.Current.Resources["Narcolepsy"],
                (string)Application.Current.Resources["Diabetes or Hypoglicemia"],
                (string)Application.Current.Resources["Blackout or Loss of Awareness"],
                (string)Application.Current.Resources["Bone or Join deformity"],
                (string)Application.Current.Resources["Loss of Memory"],
                (string)Application.Current.Resources["Skin Disease"],
                (string)Application.Current.Resources["Intestinal Troubles"],
                (string)Application.Current.Resources["Skin Disease"],
                (string)Application.Current.Resources["Swollen or Painful Joints"],
                (string)Application.Current.Resources["Chronic Cough"],
                (string)Application.Current.Resources["Car or Sea Sickness"],
                (string)Application.Current.Resources["Rapid Gain/Loss of Weight"]
            };
            }
            set { commonMedicalConditions = value; OnPropertyChanged("CommonMedicalConditions"); }
        }
        public ObservableCollection<string> SelectedConditions { get; set; }
        #endregion

        #region Commands
        public RelayCommand AddConditionCommand { get; set; }

        public void AddCondition(object param)
        {
            string selectedCond = (string)param;
            foreach (string cond in SelectedConditions)
            {
                if (cond.Equals(selectedCond)) return;
            }
            SelectedConditions.Add(selectedCond);
        }

        public RelayCommand DeleteConditionCommand { get; set; }

        public void DeleteCondition(object param)
        {
            string selectedCond = (string)param;
            for (int i = 0; i < SelectedConditions.Count; i++)
            {
                if (SelectedConditions[i].Equals(selectedCond))
                {
                    SelectedConditions.Remove(SelectedConditions[i]);
                }
            }
        }

        public RelayCommand SearchCommand { get; set; }

        public void Search(object param)
        {
            if (string.IsNullOrEmpty(SearchText) || CommonMedicalConditionsFiltered.Count <= 0)
            {
                CommonMedicalConditionsFiltered = new ObservableCollection<string>(CommonMedicalConditions);
                return;
            }
            Console.WriteLine(SearchText);
            CommonMedicalConditionsFiltered = new ObservableCollection<string>();
            foreach (string cond in CommonMedicalConditions)
            {
                if (cond.ToLower().Contains(SearchText.ToLower()))
                {
                    CommonMedicalConditionsFiltered.Add(cond);
                }
            }
        }

        public RelayCommand SubmitCommand { get; set; }

        public void Submit(object param)
        {
            //Preparing
            string airway = "";
            string breathing = "";
            string pupils = "";

            if (Airway1) airway = (string)Application.Current.Resources["Normal"];
            if (Airway2) airway = (string)Application.Current.Resources["Obstructed"];
            if (Airway3) airway = (string)Application.Current.Resources["Noisy"];

            if (Breathing1) breathing = (string)Application.Current.Resources["Normal"];
            if (Breathing2) breathing = (string)Application.Current.Resources["Shallow"];
            if (Breathing3) breathing = (string)Application.Current.Resources["Irregular"];

            if (Pupils1) pupils = (string)Application.Current.Resources["Normal"];
            if (Pupils2) pupils = (string)Application.Current.Resources["Reactive"];

            ObservableCollection<string> observations = new ObservableCollection<string>();
            observations.Add(airway);
            observations.Add(breathing);
            if (UpperBloodPressure == "") UpperBloodPressure = "120";
            if (LowerBloodPressure == "") LowerBloodPressure = "80";
            observations.Add(UpperBloodPressure + "/" + LowerBloodPressure);
            if (HeartRate == "") HeartRate = "60";
            observations.Add(HeartRate);
            if (Temperature == "") Temperature = "36.5";
            observations.Add(Temperature);
            observations.Add(pupils);
            //Finished preps

            Patient.Terms.Add(new Appointment()
            {
                Patient = Patient.Name,
                AppointmentDate = DateTime.Now.ToShortDateString(),
                AppointmentStartTime = DateTime.Now.AddHours(-1).ToShortTimeString(),
                AppointmentEndTime = DateTime.Now.ToShortTimeString(),
                AppointmentType = AppointmentTypes.Checkup,
                Doctor = "Petar Peric",
                SpecialtyType = SpecialtyType.General,
                Report = new MedicalReportModel()
                {
                    CommonConditions = SelectedConditions,
                    DoctorsRemark = Remarks,
                    Observations = observations,
                    PatientsReport = PatientsReport
                }
            });

        }
        #endregion

        private static WriteReportViewModel instance;
        public static WriteReportViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WriteReportViewModel(new PatientModel());
                }
                return instance;
            }
            set
            {
                instance = value;
            }
        }

        public WriteReportViewModel(PatientModel pat)
        {
            PurposeCollection = new ObservableCollection<String>()
            {
                (string)Application.Current.Resources["General Checkup"],
                (string)Application.Current.Resources["Post-operation Checkup"],
                (string)Application.Current.Resources["Pre-operation Checkup"],
                (string)Application.Current.Resources["Control Checkup"],
                (string)Application.Current.Resources["Surgery Report"],
                (string)Application.Current.Resources["Accident Report"],
                (string)Application.Current.Resources["Emergency Report"],
            };
            SelectedPurpose = "";
            PatientsReport = "";
            Remarks = "";
            Temperature = "";
            UpperBloodPressure = "";
            LowerBloodPressure = "";
            HeartRate = "";
            Airway1 = true;
            Breathing1 = true;
            Pupils1 = true;
            Patient = pat;
            Console.WriteLine(pat.Name);
            CommonMedicalConditions = new ObservableCollection<string>()
            {
                (string)Application.Current.Resources["AlcoholLabel"],
                (string)Application.Current.Resources["StrokeLabel"],
                (string)Application.Current.Resources["Fever"],
                (string)Application.Current.Resources["Drug Dependence"],
                (string)Application.Current.Resources["Seizure(s) - Cerebral"],
                (string)Application.Current.Resources["Seizure(s) - Alcohol related"],
                (string)Application.Current.Resources["Heart Disease"],
                (string)Application.Current.Resources["Motor Function/Ability Impaired"],
                (string)Application.Current.Resources["Visual Acuity Impairment"],
                (string)Application.Current.Resources["Visual Field Impairment"],
                (string)Application.Current.Resources["Mental or Emotional Illness"],
                (string)Application.Current.Resources["Dementia or Alzheimer's"],
                (string)Application.Current.Resources["Sleep Apnea"],
                (string)Application.Current.Resources["Narcolepsy"],
                (string)Application.Current.Resources["Diabetes or Hypoglicemia"],
                (string)Application.Current.Resources["Blackout or Loss of Awareness"],
                (string)Application.Current.Resources["Bone or Join deformity"],
                (string)Application.Current.Resources["Loss of Memory"],
                (string)Application.Current.Resources["Skin Disease"],
                (string)Application.Current.Resources["Intestinal Troubles"],
                (string)Application.Current.Resources["Skin Disease"],
                (string)Application.Current.Resources["Swollen or Painful Joints"],
                (string)Application.Current.Resources["Chronic Cough"],
                (string)Application.Current.Resources["Car or Sea Sickness"],
                (string)Application.Current.Resources["Rapid Gain/Loss of Weight"]
            };
            CommonMedicalConditionsFiltered = new ObservableCollection<string>(CommonMedicalConditions);
            SelectedConditions = new ObservableCollection<string>();
            AddConditionCommand = new RelayCommand(AddCondition);
            DeleteConditionCommand = new RelayCommand(DeleteCondition);
            SearchCommand = new RelayCommand(Search);
            SubmitCommand = new RelayCommand(Submit);
        }
    }
}
