using hci2020_doctors_ui.Model;
using Syncfusion.UI.Xaml.Schedule;
using System;
using System.Windows;
using System.Windows.Media;

namespace hci2020_doctors_ui.ViewModel
{
    public class CalendarViewModel : BaseViewModel
    {

        private static CalendarViewModel instance;

        public static CalendarViewModel Instance
        {
            get
            {
                if (instance == null)
                    instance = new CalendarViewModel();
                return instance;
            }
        }

        public CalendarViewModel()
        {
            this.LoadAppointments();
            SaveCommand = new RelayCommand(Save);
            DeleteCommand = new RelayCommand(Delete);
            PasteCommand = new RelayCommand(Paste);
            StartDate = DateTime.Now;
            StartTime = DateTime.Now;
            EndTime = DateTime.Now;
        }


        #region Helper

        public ScheduleAppointmentCollection GetClosestAppointments()
        {
            ScheduleAppointmentCollection retVal = new ScheduleAppointmentCollection();
            ScheduleAppointmentCollection tempList = new ScheduleAppointmentCollection();

            foreach (ScheduleAppointment app in Appointments)
            {
                tempList.Add(app);
            }

            ScheduleAppointment temp;

            for (int i = 0; i < tempList.Count - 2; i++)
            {
                for (int j = i + 1; j < tempList.Count - 1; j++)
                {
                    if (DateTime.Compare(tempList[i].StartTime, tempList[j].StartTime) > 0)
                    {
                        temp = tempList[i];
                        tempList[i] = tempList[j];
                        tempList[j] = temp;
                    }
                }
            }

            for (int i = 0; i < 3; i++)
            {
                retVal.Add(tempList[i]);
            }

            return retVal;
        }


        #endregion


        #region Properties
        private DateTime startDate;
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; OnPropertyChanged("StartDate"); }
        }
        private DateTime startTime;
        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; OnPropertyChanged("StartTime"); }
        }
        private DateTime endTime;
        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; OnPropertyChanged("EndTime"); }
        }
        private string location;
        public string Location
        {
            get { return location; }
            set { location = value; OnPropertyChanged("Location"); }
        }
        private string patient;
        public string Patient
        {
            get { return patient; }
            set { patient = value; OnPropertyChanged("Patient"); }
        }
        private AppointmentTypes apptype;
        public AppointmentTypes Apptype
        {
            get { return apptype; }
            set { apptype = value; OnPropertyChanged("Apptype"); }
        }
        private Appointment appointment;
        public Appointment Appointment
        {
            get { return appointment; }
            set { appointment = value; OnPropertyChanged("Appointment"); }
        }
        private bool editMode;

        public bool EditMode
        {
            get { return editMode; }
            set { editMode = value; OnPropertyChanged("EditMode"); }
        }

        #endregion

        #region Appointments
        private ScheduleAppointmentCollection appointments;

        public ScheduleAppointmentCollection Appointments
        {
            get { return appointments; }
            set
            {
                appointments = value;
                OnPropertyChanged("Appointments");
            }
        }

        private ScheduleAppointmentCollection operations;

        public ScheduleAppointmentCollection Operations
        {
            get { return operations; }
            set { operations = value; OnPropertyChanged("Operations"); }
        }

        private ScheduleAppointmentCollection checkups;

        public ScheduleAppointmentCollection Checkups
        {
            get
            {
                return checkups;
            }
            set
            {
                checkups = value;
                OnPropertyChanged("Checkups");
            }
        }
        #endregion

        #region Commands
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand PasteCommand { get; set; }

        public void Delete(object appointment)
        {

            Appointment app = (Appointment)appointment;
            if (app != null)
            {
                if (app.AppointmentType == AppointmentTypes.Checkup)
                {
                    Checkups.Remove(app);
                    Appointments.Remove(app);
                }
                else if (app.AppointmentType == AppointmentTypes.Operation)
                {
                    Operations.Remove(app);
                    Appointments.Remove(app);
                }
            }
        }

        public void Paste(object param)
        {
            Appointment app = (Appointment)param;
            if (app.AppointmentType == AppointmentTypes.Checkup)
            {
                Checkups.Add(app);
                Appointments.Add(app);
            }
            else if (app.AppointmentType == AppointmentTypes.Operation)
            {
                Operations.Add(app);
                Appointments.Add(app);
            }
        }

        public void Save(object param)
        {
            Appointment appointment = new Appointment();
            appointment.StartTime = StartDate.Date.Add(StartTime.TimeOfDay);
            appointment.EndTime = StartDate.Date.Add(EndTime.TimeOfDay);
            appointment.AppointmentStartTime = StartTime.ToString("hh:mm tt");
            appointment.AppointmentEndTime = EndTime.ToString("hh:mm tt");
            appointment.Subject = Apptype.ToString();
            appointment.Location = Location;
            appointment.Patient = Patient;
            appointment.AppointmentType = Apptype;
            appointment.AppointmentBackground = SetBackground(Apptype);
            if (appointment.StartTime == appointment.EndTime)
                appointment.EndTime = EndTime.AddHours(1);


            if (EditMode)
            {
                Delete(appointment);
            }


            if (!Operations.Contains(appointment) && !Checkups.Contains(appointment))
            {
                if (appointment.AppointmentType == AppointmentTypes.Checkup)
                {
                    Checkups.Add(appointment);
                    Appointments.Add(appointment);
                }
                else if (appointment.AppointmentType == AppointmentTypes.Operation)
                {
                    Operations.Add(appointment);
                    Appointments.Add(appointment);
                }
            }

            EditMode = false;
        }
        #endregion

        #region Checkboxes
        private bool operationsChecked;
        public bool OperationsChecked
        {
            get
            {
                /*
                foreach (Appointment app in Appointments)
                {
                    Console.WriteLine(app.AppointmentType + " " + app.Patient);
                }
                Console.WriteLine("----");
                foreach (Appointment app in Operations)
                {
                    Console.WriteLine(app.AppointmentType + " " + app.Patient);
                }

                Console.WriteLine("----");
                foreach(Appointment app in Appointments)
                {
                    Console.WriteLine(app.AppointmentType + " " + app.Patient);
                }
                Console.WriteLine("----");
                Console.WriteLine("----");
                Console.WriteLine("----");*/
                return operationsChecked;
            }
            set
            {
                operationsChecked = value;
                if (operationsChecked == true)
                {
                    foreach (Appointment app in Operations)
                    {
                        Appointments.Add(app);
                    }
                }
                else if (operationsChecked == false)
                {
                    foreach (Appointment app in Operations)
                    {
                        Appointments.Remove(app);
                    }
                }
                OnPropertyChanged("OperationsChecked");
            }
        }

        private bool checkupsChecked;
        public bool CheckupsChecked
        {
            get
            {
                return checkupsChecked;
            }
            set
            {
                checkupsChecked = value;
                if (checkupsChecked == true)
                {
                    foreach (Appointment app in Checkups)
                    {
                        Appointments.Add(app);
                    }
                }
                else if (checkupsChecked == false)
                {
                    foreach (Appointment app in Checkups)
                    {
                        Appointments.Remove(app);
                    }
                }
                OnPropertyChanged("CheckupsChecked");
            }
        }
        #endregion

        #region Initial Load
        private void LoadAppointments()
        {
            Appointments = new ScheduleAppointmentCollection();
            Operations = new ScheduleAppointmentCollection();
            Checkups = new ScheduleAppointmentCollection();

            DateTime currentdate = DateTime.Now.Date;
            if (currentdate.DayOfWeek == System.DayOfWeek.Friday)
                currentdate = currentdate.SubtractDays(3);
            else if (currentdate.DayOfWeek == System.DayOfWeek.Sunday || currentdate.DayOfWeek == System.DayOfWeek.Saturday)
                currentdate = currentdate.AddDays(3);

            //podesiti za odbranu
            currentdate = currentdate.AddHours(-6);
            //Checkup
            Appointment app1 = new Appointment()
            {
                AppointmentType = AppointmentTypes.Checkup,
                StartTime = currentdate.AddHours(1),
                EndTime = currentdate.AddHours(3),
                AppointmentStartTime = currentdate.AddHours(1).ToString("hh:mm tt"),
                AppointmentEndTime = currentdate.AddHours(3).ToString("hh:mm tt"),
                Subject = (string)Application.Current.Resources["CheckupLabel"],
                Location = "177",
                SpecialtyType = SpecialtyType.Cardiac,
                AppointmentBackground = SetBackground(AppointmentTypes.Checkup),
                Patient = SearchViewModel.Instance.Patients[0].Name
            };
            //Checkup
            Appointment app2 = new Appointment()
            {
                AppointmentType = AppointmentTypes.Checkup,
                StartTime = currentdate.Date.AddHours(3),
                EndTime = currentdate.Date.AddHours(4),
                AppointmentStartTime = currentdate.AddHours(3).ToString("hh:mm tt"),
                AppointmentEndTime = currentdate.AddHours(4).ToString("hh:mm tt"),
                Subject = (string)Application.Current.Resources["CheckupLabel"],
                Location = "233",
                SpecialtyType = SpecialtyType.Cardiac,
                AppointmentBackground = SetBackground(AppointmentTypes.Checkup),
                Patient = SearchViewModel.Instance.Patients[1].Name
            };
            currentdate = currentdate.AddDays(-1).AddHours(-7);
            //Operation
            Appointment app3 = new Appointment()
            {
                AppointmentType = AppointmentTypes.Operation,
                StartTime = currentdate.AddHours(1),
                EndTime = currentdate.AddHours(2),
                AppointmentStartTime = currentdate.AddHours(1).ToString("hh:mm tt"),
                AppointmentEndTime = currentdate.AddHours(2).ToString("hh:mm tt"),
                Subject = (string)Application.Current.Resources["OperationLabel"],
                Location = "2139",
                SpecialtyType = SpecialtyType.Cardiac,
                AppointmentBackground = SetBackground(AppointmentTypes.Operation),
                Patient = SearchViewModel.Instance.Patients[2].Name
            };
            //Checkup
            Appointment app4 = new Appointment()
            {
                AppointmentType = AppointmentTypes.Checkup,
                StartTime = currentdate.Date.AddHours(3),
                EndTime = currentdate.Date.AddHours(4),
                AppointmentStartTime = currentdate.AddHours(3).ToString("hh:mm tt"),
                AppointmentEndTime = currentdate.AddHours(4).ToString("hh:mm tt"),
                Subject = (string)Application.Current.Resources["CheckupLabel"],
                Location = "327",
                SpecialtyType = SpecialtyType.Cardiac,
                AppointmentBackground = SetBackground(AppointmentTypes.Checkup),
                Patient = SearchViewModel.Instance.Patients[1].Name
            };
            //Operation
            Appointment app5 = new Appointment()
            {
                AppointmentType = AppointmentTypes.Operation,
                StartTime = currentdate.AddHours(7),
                EndTime = currentdate.AddHours(8),
                AppointmentStartTime = currentdate.AddHours(7).ToString("hh:mm tt"),
                AppointmentEndTime = currentdate.AddHours(8).ToString("hh:mm tt"),
                Subject = (string)Application.Current.Resources["OperationLabel"],
                Location = "2139",
                AppointmentBackground = SetBackground(AppointmentTypes.Operation),
                Patient = SearchViewModel.Instance.Patients[0].Name
            };
            currentdate = currentdate.AddDays(2).AddHours(-7);
            //Operation
            Appointment app6 = new Appointment()
            {
                AppointmentType = AppointmentTypes.Operation,
                StartTime = currentdate.AddHours(1),
                EndTime = currentdate.AddHours(2),
                AppointmentStartTime = currentdate.AddHours(1).ToString("hh:mm tt"),
                AppointmentEndTime = currentdate.AddHours(2).ToString("hh:mm tt"),
                Subject = (string)Application.Current.Resources["OperationLabel"],
                Location = "1023",
                SpecialtyType = SpecialtyType.Oncological,
                AppointmentBackground = SetBackground(AppointmentTypes.Operation),
                Patient = SearchViewModel.Instance.Patients[2].Name
            };
            currentdate = currentdate.AddDays(1).AddHours(-8);
            //Operation
            Appointment app7 = new Appointment()
            {
                AppointmentType = AppointmentTypes.Operation,
                StartTime = currentdate.AddHours(1),
                EndTime = currentdate.AddHours(2).AddMinutes(30),
                AppointmentStartTime = currentdate.AddHours(1).ToString("hh:mm tt"),
                AppointmentEndTime = currentdate.AddHours(2).AddMinutes(30).ToString("hh:mm tt"),
                Subject = (string)Application.Current.Resources["OperationLabel"],
                Location = "402",
                SpecialtyType = SpecialtyType.Oncological,
                AppointmentBackground = SetBackground(AppointmentTypes.Operation),
                Patient = SearchViewModel.Instance.Patients[3].Name
            };
            //Checkup
            Appointment app8 = new Appointment()
            {
                AppointmentType = AppointmentTypes.Checkup,
                StartTime = currentdate.AddHours(4).AddMinutes(-30),
                EndTime = currentdate.AddHours(5),
                AppointmentStartTime = currentdate.AddHours(4).AddMinutes(-30).ToString("hh:mm tt"),
                AppointmentEndTime = currentdate.AddHours(5).ToString("hh:mm tt"),
                Subject = (string)Application.Current.Resources["CheckupLabel"],
                Location = "115",
                SpecialtyType = SpecialtyType.Oncological,
                AppointmentBackground = SetBackground(AppointmentTypes.Checkup),
                Patient = SearchViewModel.Instance.Patients[1].Name
            };
            currentdate = currentdate.AddDays(1).AddHours(-7);
            //Checkup
            Appointment app9 = new Appointment()
            {
                AppointmentType = AppointmentTypes.Checkup,
                StartTime = currentdate.AddHours(2),
                EndTime = currentdate.AddHours(3),
                AppointmentStartTime = currentdate.AddHours(2).ToString("hh:mm tt"),
                AppointmentEndTime = currentdate.AddHours(3).ToString("hh:mm tt"),
                Subject = (string)Application.Current.Resources["CheckupLabel"],
                Location = "231",
                SpecialtyType = SpecialtyType.Oncological,
                AppointmentBackground = SetBackground(AppointmentTypes.Checkup),
                Patient = SearchViewModel.Instance.Patients[2].Name
            };
            //Checkup
            Appointment app10 = new Appointment()
            {
                AppointmentType = AppointmentTypes.Checkup,
                StartTime = currentdate,
                EndTime = currentdate,
                AppointmentStartTime = currentdate.ToString("hh:mm tt"),
                AppointmentEndTime = currentdate.ToString("hh:mm tt"),
                Subject = (string)Application.Current.Resources["CheckupLabel"],
                Location = "1002",
                SpecialtyType = SpecialtyType.General,
                AppointmentBackground = SetBackground(AppointmentTypes.Checkup),
                Patient = SearchViewModel.Instance.Patients[0].Name
            };
            //Operation
            Appointment app11 = new Appointment()
            {
                AppointmentType = AppointmentTypes.Operation,
                StartTime = currentdate.AddHours(4),
                EndTime = currentdate.AddHours(5),
                AppointmentStartTime = currentdate.AddHours(4).ToString("hh:mm tt"),
                AppointmentEndTime = currentdate.AddHours(5).ToString("hh:mm tt"),
                Subject = (string)Application.Current.Resources["OperationLabel"],
                Location = "2139",
                SpecialtyType = SpecialtyType.Oncological,
                AppointmentBackground = SetBackground(AppointmentTypes.Operation),
                Patient = SearchViewModel.Instance.Patients[3].Name
            };

            Operations.Add(app3);
            Operations.Add(app5);
            Operations.Add(app6);
            Operations.Add(app7);
            Operations.Add(app11);

            Checkups.Add(app1);
            Checkups.Add(app2);
            Checkups.Add(app4);
            Checkups.Add(app8);
            Checkups.Add(app9);
            Checkups.Add(app10);

            CheckupsChecked = true;
            OperationsChecked = true;
        }

        public static SolidColorBrush SetBackground(AppointmentTypes type)
        {
            SolidColorBrush bg = null;
            switch (type)
            {
                case AppointmentTypes.Checkup: bg = new SolidColorBrush((Color)Application.Current.Resources["Checkup"]); break;
                case AppointmentTypes.Operation: bg = new SolidColorBrush((Color)Application.Current.Resources["Success"]); break;
            }
            return bg;
        }
        #endregion
    }
}
