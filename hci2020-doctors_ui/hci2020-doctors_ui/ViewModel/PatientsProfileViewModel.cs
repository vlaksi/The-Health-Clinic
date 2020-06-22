using Controller.MedicalRecordContr;
using hci2020_doctors_ui.Model;
using Model.MedicalRecord;
using System;
using System.Collections.ObjectModel;

namespace hci2020_doctors_ui.ViewModel
{
    public class PatientsProfileViewModel : BaseViewModel
    {

        private static PatientsProfileViewModel instance;
        public static PatientsProfileViewModel Instance
        {
            get
            {
                return instance;
            }
            set { instance = value; }
        }

        public PatientsProfileViewModel(PatientModel pat)
        {
            Instance = this;
            Instance.Patient = pat;
            CurrentMedicalRecord = medicalRecordController.GetMedicalRecordByPatientId(pat.Id);
            Console.WriteLine(CurrentMedicalRecord.PatientId + " " + CurrentMedicalRecord.Name);
            NavigateToReport = new RelayCommand(NavigateTo);
            GetStatusReport = new RelayCommand(GetPatientsStatusInTimePeriod);
            AppointmentsInSelectedPeriod = new ObservableCollection<Appointment>();
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
        }

        #region Properties
        private MedicalRecordController medicalRecordController = new MedicalRecordController();


        private PatientModel patient;

        public PatientModel Patient
        {
            get { return patient; }
            set { patient = value; OnPropertyChanged("Patient"); }
        }

        private MedicalRecord currentMedicalRecord;
        public MedicalRecord CurrentMedicalRecord
        {
            get { return currentMedicalRecord; }
            set { currentMedicalRecord = value; OnPropertyChanged("CurrentMedicalRecord"); }
        }

        private Appointment appointmentBinding;

        public Appointment AppointmentBinding
        {
            get { return appointmentBinding; }
            set { appointmentBinding = value; OnPropertyChanged("AppointmentBinding"); }
        }

        private DateTime startDate;

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; OnPropertyChanged("StartDate"); }
        }

        private DateTime endDate;

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; OnPropertyChanged("EndDate"); }
        }


        private ObservableCollection<Appointment> appointmentsInSelectedPeriod;

        public ObservableCollection<Appointment> AppointmentsInSelectedPeriod
        {
            get { return appointmentsInSelectedPeriod; }
            set { appointmentsInSelectedPeriod = value; OnPropertyChanged("AppointmentsInSelectedPeriod"); }
        }
        #endregion


        #region Commands
        public RelayCommand GetStatusReport { get; set; }
        public void GetPatientsStatusInTimePeriod(object param)
        {
            DateTime start = StartDate;
            DateTime end = EndDate;

            Console.WriteLine(start.ToString());
            Console.WriteLine(end.ToString());

            foreach (Appointment app in Patient.Terms)
            {
                string[] parts = app.AppointmentDate.Split('/');
                string appDate = parts[1] + "/" + parts[0] + "/" + parts[2];
                if (DateTime.Compare(Convert.ToDateTime(appDate).ToLocalTime(), start.ToLocalTime()) > 0
                    && DateTime.Compare(Convert.ToDateTime(appDate).ToLocalTime(), end.ToLocalTime()) < 0)
                {
                    AppointmentsInSelectedPeriod.Add(app);
                    Console.WriteLine(app.AppointmentDate);
                }
            }

        }


        public RelayCommand NavigateToReport { get; set; }
        public void NavigateTo(object param)
        {
            int id = (int)param;
            foreach (Appointment app in Patient.Terms)
            {
                if (app.Id == id)
                {
                    AppointmentBinding = app;
                    return;
                }
            }
        }
        #endregion
    }
}
