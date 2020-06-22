using hci2020_doctors_ui.Model;
using Syncfusion.UI.Xaml.Schedule;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hci2020_doctors_ui.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        private static HomeViewModel instance;
        public HomeViewModel()
        {
            MedicinesWaitingApproval = WritePrescriptionViewModel.Instance.MedicinesWaitingApproval;
            ApproveMedicineCommand = new RelayCommand(ApproveMedicine);
            DeclineMedicineCommand = new RelayCommand(DeclineMedicine);
        }
        public static HomeViewModel Instance
        {
            get
            {
                if (instance == null)
                    instance = new HomeViewModel();
                return instance;
            }
        }

        #region Command
        public RelayCommand ApproveMedicineCommand { get; set; }
        public RelayCommand DeclineMedicineCommand { get; set; }

        public void ApproveMedicine(object param)
        {
            MedicineModel med = (MedicineModel)param;
            med.Status = MedicineStatus.Validated;
            WritePrescriptionViewModel.Instance.MedicineCollection.Add(med);
            WritePrescriptionViewModel.Instance.MedicinesWaitingApproval.Remove(med);

            Console.WriteLine("Medicine approved.");
        }

        public void DeclineMedicine(object param)
        {
            MedicineModel med = (MedicineModel)param;
            MedicinesWaitingApproval.Remove(med);
        }
        #endregion

        #region Properties

        private ScheduleAppointmentCollection appointmentsToShow;

        public ScheduleAppointmentCollection AppointmentsToShow
        {
            get
            {
                appointmentsToShow = CalendarViewModel.Instance.GetClosestAppointments();
                return appointmentsToShow;
            }
            set { appointmentsToShow = value; OnPropertyChanged("AppointmentsToShow"); }
        }

        // For testing closest appointments
        public void printSome()
        {
            foreach (Appointment app in CalendarViewModel.Instance.Appointments)
            {
                Console.WriteLine("All apps - " + app.StartTime);
            }

            Console.WriteLine("a");
            foreach (Appointment appoint in AppointmentsToShow)
            {
                Console.WriteLine("Closest apps - " + appoint.StartTime);
            }
        }

        private ObservableCollection<MedicineModel> medicinesWaitingApproval;
        public ObservableCollection<MedicineModel> MedicinesWaitingApproval
        {
            get { return medicinesWaitingApproval; }
            set { medicinesWaitingApproval = value; OnPropertyChanged("MedicinesWaitingApproval"); }
        }
        #endregion

    }

}
