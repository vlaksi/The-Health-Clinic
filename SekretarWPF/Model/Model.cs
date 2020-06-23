using Syncfusion.UI.Xaml.Schedule;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SekretarWPF
{
    #region Appointment Class
    public enum AppointmentTypes
    {
        CheckUp,
        Operation
    }
    public class Appointment : ScheduleAppointment, INotifyPropertyChanged
    {
        #region public properties
        private ImageSource _imageuri;
        private string doctor;
        private string specialist;
        private string patient;
        private string ordination;
        private string operatingRoom;

        public string Doctor
        {
            get { return doctor; }
            set { doctor = value; }
        }

        public string Specialist
        {
            get { return specialist; }
            set { specialist = value; }
        }

        public string Patient
        {
            get { return patient; }
            set { patient = value; }
        }

        public string Ordination
        {
            get { return ordination; }
            set { ordination = value; }
        }

        public string OperatingRoom
        {
            get { return operatingRoom; }
            set { operatingRoom = value; }
        }

        public ImageSource AppointmentImageURI
        {
            get { return _imageuri; }
            set
            {
                _imageuri = value;
                OnPropertyChanged("AppointmentImageURI");
            }
        }
        private string _appointmentTime;
        public string AppointmentTime
        {
            get { return _appointmentTime; }
            set
            {
                _appointmentTime = value;
                OnPropertyChanged("AppointmentTime");
            }
        }

        public AppointmentTypes AppointmentType { get; set; }
        public int Id { get; set; }

        #endregion

        private void OnPropertyChanged(string propertyName)
        {
            var eventHandler = PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public new event PropertyChangedEventHandler PropertyChanged;
    }

    #endregion

}
