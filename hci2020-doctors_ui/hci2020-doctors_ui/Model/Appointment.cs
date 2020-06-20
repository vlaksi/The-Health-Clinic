using Syncfusion.UI.Xaml.Schedule;
using System;
using System.ComponentModel;

namespace hci2020_doctors_ui.Model
{
    public enum AppointmentTypes
    {
        Checkup,
        Operation
    }
    public class Appointment : ScheduleAppointment
    {
        #region Public properties
        private String _patient;
        private string _appointmentStartTime;
        private string _appointmentEndTime;
        private AppointmentTypes appointmentType;
        private string doctor;

        private MedicalReportModel report;

        public MedicalReportModel Report
        {
            get { return report; }
            set { report = value; }
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        public string Doctor
        {
            get { return doctor; }
            set { doctor = value; }
        }


        private SpecialtyType specialtyType;

        public SpecialtyType SpecialtyType
        {
            get { return specialtyType; }
            set { specialtyType = value; OnPropertyChanged("SpecialtyType"); }
        }

        private string appointmentDate;

        public string AppointmentDate
        {
            get { return appointmentDate; }
            set { appointmentDate = value; }
        }


        public String Patient
        {
            get
            {
                return _patient;
            }
            set
            {
                _patient = value;
                OnPropertyChanged("Patient");
            }
        }
        public string AppointmentStartTime
        {
            get { return _appointmentStartTime; }
            set
            {
                _appointmentStartTime = value;
                OnPropertyChanged("AppointmentTime");
            }
        }
        public string AppointmentEndTime
        {
            get { return _appointmentEndTime; }
            set
            {
                _appointmentEndTime = value;
                OnPropertyChanged("AppointmentTime");
            }
        }
        public AppointmentTypes AppointmentType
        {
            get { return appointmentType; }
            set
            {
                appointmentType = value;
                OnPropertyChanged("AppointmentType");
            }
        }
        #endregion

        #region Property Changed
        private void OnPropertyChanged(string propertyName)
        {
            var eventHandler = PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public new event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
