using hci2020_doctors_ui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace hci2020_doctors_ui.ViewModel
{
    public class AccommodatePatientViewModel : BaseViewModel
    {
        private int selectedFloor;

        public int SelectedFloor
        {
            get { return selectedFloor; }
            set { selectedFloor = value; OnPropertyChanged("SelectedFloor"); }
        }

        private string selectedRoom;

        public string SelectedRoom
        {
            get { return selectedRoom; }
            set { selectedRoom = value; OnPropertyChanged("SelectedRoom"); }
        }

        private DateTime sectedStartDate;

        public DateTime SelectedStartDate
        {
            get { return sectedStartDate; }
            set { sectedStartDate = value; OnPropertyChanged("SelectedStartDate"); }
        }

        private DateTime selectedEndDate;

        public DateTime SelectedEndDate
        {
            get { return selectedEndDate; }
            set { selectedEndDate = value; OnPropertyChanged("SelectedEndDate"); }
        }

        public List<int> FloorsCollection { get; set; }
        public List<string> Rooms { get; set; }

        private PatientModel patient;

        public PatientModel Patient
        {
            get { return patient; }
            set { patient = value; OnPropertyChanged("Patient"); }
        }


        public AccommodatePatientViewModel(PatientModel pat)
        {

            Patient = pat;

            FloorsCollection = new List<int>()
            {
                1,
                2,
                3,
                4
            };


            Rooms = new List<string>()
            {
                 (string)Application.Current.Resources["RoomLabel"] + " 2245",
                 (string)Application.Current.Resources["RoomLabel"] + " 14",
                 (string)Application.Current.Resources["RoomLabel"] + " 1234",
                 (string)Application.Current.Resources["RoomLabel"] + " 5453",
                 (string)Application.Current.Resources["RoomLabel"] + " 4123"
            };

            SelectedFloor = 0;
            SelectedRoom = "";
            SelectedStartDate = DateTime.Now;
            SelectedEndDate = DateTime.Now;

            SubmitAccommodateCommand = new RelayCommand(SubmitAccommodate);
        }

        public RelayCommand SubmitAccommodateCommand { get; set; }

        public void SubmitAccommodate(object param)
        {
            Console.WriteLine(SelectedRoom);
            Patient.Accommodate = SelectedRoom; 
        }
    }
}
