using hci2020_doctors_ui.Model;

namespace hci2020_doctors_ui.ViewModel
{
    public class PDFReportViewModel : BaseViewModel
    {
        private PatientModel patient;

        public PatientModel Patient
        {
            get { return patient; }
            set { patient = value; OnPropertyChanged("Patient"); }
        }

        private Appointment appointment;

        public Appointment Appointment
        {
            get { return appointment; }
            set { appointment = value; OnPropertyChanged("Appointment"); }
        }

        public PDFReportViewModel(PatientModel patient, Appointment appointment)
        {
            Patient = patient;
            Appointment = appointment;
        }

    }
}
