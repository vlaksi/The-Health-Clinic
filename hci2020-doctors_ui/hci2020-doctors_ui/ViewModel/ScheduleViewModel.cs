using hci2020_doctors_ui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace hci2020_doctors_ui.ViewModel
{
    public class ScheduleViewModel : BaseViewModel
    {
        #region Public properties
        public List<string> AppointmentTypeCollection { get; set; }
        public List<string> SpecialtyTypeCollection { get; set; }
        public List<int> FloorsCollection { get; set; }
        public List<string> Rooms { get; set; }
        public List<string> Doctors { get; set; }
        public List<string> Patients { get; set; }
        #endregion

        #region Selected items
        public string SelectedPatient { get; set; }
        public string SelectedDoctor { get; set; }
        public string SelectedAppointmentType { get; set; }
        public string SelectedSpecialty { get; set; }
        public int SelectedFloor { get; set; }
        public string SelectedRoom { get; set; }
        public DateTime SelectedDate { get; set; }
        public DateTime SelectedTime { get; set; }
        #endregion
        public ScheduleViewModel()
        {
            AppointmentTypeCollection = new List<string>()
            {
                (string)Application.Current.Resources["CheckupLabel"],
               (string)Application.Current.Resources["OperationLabel"]
            };

            FloorsCollection = new List<int>()
            {
                1,
                2,
                3,
                4
            };

            Patients = new List<string>
            {
                "Ildika Kisz",
                "Petar Perić",
                "Ilija Stevanović",
                "Ivana Živanović"
            };

            SpecialtyTypeCollection = new List<string>()
            {
                "General",
                "Cardiac",
                "Respiratory",
            };

            Doctors = new List<string>()
            {
                "Petar Perović",
                "Jovan Jovanić",
                "Ivica Ivić",
                "Petra Jovanović"
            };

            Rooms = new List<string>()
            {
                 (string)Application.Current.Resources["OperatingRoomLabel"] + " 2245",
                 (string)Application.Current.Resources["OrdinationLabel"] + " 14",
                 (string)Application.Current.Resources["OperatingRoomLabel"] + " 1234",
                 (string)Application.Current.Resources["OperatingRoomLabel"] + " 5453",
                 (string)Application.Current.Resources["OperatingRoomLabel"] + " 4123"
            };

            SelectedPatient = "";
            SelectedDoctor = "";
            SelectedAppointmentType = "";
            SelectedSpecialty = "";
            SelectedFloor = 0;
            SelectedRoom = "";
            SelectedDate = DateTime.Now;
            SelectedTime = DateTime.Now;

            SubmitScheduleForm = new RelayCommand(SubmitSchedule);
        }
    
        public RelayCommand SubmitScheduleForm { get; set; }
    
        public void SubmitSchedule(object param)
        {
            foreach(PatientModel patient in SearchViewModel.Instance.Patients)
            {
                if (patient.Name.Equals(SelectedPatient))
                {
                    Console.WriteLine(patient.Name);
                    AppointmentTypes apptype;
                    string subject;

                    string[] roomNumber = SelectedRoom.Split(' ');
                    string roomno = "";
                    if (roomNumber.Length == 3) roomno = roomNumber[2];
                    if (roomNumber.Length == 2) roomno = roomNumber[1];


                    if(SelectedAppointmentType.Equals((string)Application.Current.Resources["CheckupLabel"]))
                    {
                        apptype = AppointmentTypes.Checkup;
                        subject = (string)Application.Current.Resources["CheckupLabel"];
                    }
                    else
                    {
                        apptype = AppointmentTypes.Operation;
                        subject = (string)Application.Current.Resources["OperationLabel"];
                    }
                    patient.Terms.Add(new Appointment()
                    {
                        AppointmentType = apptype,
                        StartTime = SelectedTime,
                        EndTime = SelectedTime.Date.AddHours(1),
                        AppointmentStartTime = SelectedTime.ToString("hh:mm tt"),
                        AppointmentEndTime = SelectedTime.AddHours(1).ToString("hh:mm tt"),
                        Subject = subject,
                        Location = roomno,
                        SpecialtyType = SpecialtyType.Cardiac,
                        AppointmentBackground = CalendarViewModel.SetBackground(apptype),
                        Patient = SelectedPatient
                    });

                    return;
                    
                }
            }
        }
    }
}
