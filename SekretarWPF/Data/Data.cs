using Controller.TermContr;
using Model.Calendar;
using SekretarWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SekretarWPF.Data
{
    class DummyData
    {
        private static TermContextController termController = new TermContextController();

        public static List<Appointment> checkUps = new List<Appointment>();
        public static List<Appointment> operations = new List<Appointment>();

        private static List<Operation> operationsModel = loadOperations();
        private static List<Checkup> checkupsModel = loadCheckups();


        private static List<Checkup> loadCheckups()
        {
            List<Checkup> checkups = new List<Checkup>();
            foreach(Checkup checkup in termController.getAllCheckups())
            {
                checkups.Add(checkup);
            
                Appointment checkUp1 = new Appointment()
                {
                    AppointmentImageURI = new BitmapImage(new Uri("pack://application:,,,/SekretarWPF;Component/Assets/CheckUp.png")),
                    AppointmentType = AppointmentTypes.CheckUp,
                    StartTime = checkup.StartTime,
                    AppointmentTime = checkup.StartTime.ToString("hh:mm tt"),
                    EndTime = checkup.EndTime,
                    AppointmentBackground = new SolidColorBrush(Color.FromRgb(211, 47, 47))
                };
                checkUp1.Id = checkup.Id;
                //checkUp1.Doctor = checkup.Doctor.Name + " " + checkup.Doctor.Surname;
                //checkUp1.Patient = checkup.MedicalRecord.Name + " " + checkup.MedicalRecord.Surname;
                //checkUp1.Ordination = "Ordination " + checkup.ordination.NumberOfRoom;
                DummyData.checkUps.Add(checkUp1);
            }

            return checkups;
        }

        private static List<Operation> loadOperations()
        {
            List<Operation> operations = new List<Operation>();
            foreach (Operation operation in termController.getAllOperations())
            {
                operations.Add(operation);

                Appointment operation1 = new Appointment()
                {
                    AppointmentImageURI = new BitmapImage(new Uri("pack://application:,,,/SekretarWPF;Component/Assets/Operation.png")),
                    AppointmentType = AppointmentTypes.Operation,
                    StartTime = operation.StartTime,
                    AppointmentTime = operation.StartTime.ToString("hh:mm tt"),
                    EndTime = operation.EndTime,
                    AppointmentBackground = new SolidColorBrush(Color.FromRgb(56, 142, 60))
                };
                operation1.Id = operation.Id;
                //operation1.Patient = "Patient3";
                //operation1.Specialist = "Specialist1";
                //operation1.OperatingRoom = "OperatingRoom2";
                DummyData.operations.Add(operation1);
            }

            return operations;
        }

        public static void removeCheckup(Appointment appointment)
        {
            checkUps.Remove(appointment);
            Checkup toRemove = null;
            foreach(Checkup checkup in checkupsModel)
            {
                if (checkup.Id == appointment.Id)
                {
                    termController.CancelTerm(checkup);
                    toRemove = checkup;
                    break;
                }
            }
            checkupsModel.Remove(toRemove);
        }

        public static void saveCheckup(Appointment appointment)
        {
            Checkup checkup = new Checkup();
            checkup.StartTime = appointment.StartTime;
            checkup.EndTime = appointment.EndTime;

            termController.ScheduleTerm(checkup);

            appointment.Id = checkup.Id;

            checkUps.Add(appointment);
            checkupsModel.Add(checkup);

        }

        public static void removeOpeation(Appointment appointment)
        {
            operations.Remove(appointment);
            Operation toRemove = null;
            foreach (Operation operation in operationsModel)
            {
                if (operation.Id == appointment.Id)
                {
                    termController.CancelTerm(operation);
                    toRemove = operation;
                    break;
                }
            }
            operationsModel.Remove(toRemove);
        }

        public static void saveOperation(Appointment appointment)
        {
            Operation operation = new Operation();
            operation.StartTime = appointment.StartTime;
            operation.EndTime = appointment.EndTime;

            termController.ScheduleTerm(operation);

            appointment.Id = operation.Id;

            operations.Add(appointment);
            operationsModel.Add(operation);

        }

    }
}
