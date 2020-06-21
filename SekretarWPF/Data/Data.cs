using SekretarWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SekretarWPF.Data
{
    class DummyData
    {
        public static ObservableCollection<MedicalRecord> medicalRecords = populateMedicalRecords();
        public static List<Appointment> checkUps = populateCheckUps();
        public static List<Appointment> operations = populateOperations();

        private static ObservableCollection<MedicalRecord> populateMedicalRecords()
        {
            ObservableCollection<MedicalRecord> medicalRecords = new ObservableCollection<MedicalRecord>();
            medicalRecords.Add(new MedicalRecord("Marko", "Markovic", "Brace Jerkovic 19", Gender.Male, "0309987800077", new DateTime(1987, 9, 3), "Vukan", "412986453", "068/997-525", "Marko Markovic"));
            medicalRecords.Add(new MedicalRecord("Mila", "Vukotic", "Augusta Cesarca 2", Gender.Female, "0502992700088", new DateTime(1992, 2, 5), "Milos", "452245224", "063/854-426", "Mila Vukotic"));
            medicalRecords.Add(new MedicalRecord("Ana", "Arsovic", "Jovana Ducica 9", Gender.Female, "0248857800077", new DateTime(1977, 4, 1), "Veljko", "412986453", "068/548-123", "Ana Arsovic"));
            medicalRecords.Add(new MedicalRecord("Zoran", "Zubic", "Andje Rankovic 2", Gender.Male, "0503678900088", new DateTime(1965, 2, 11), "Gvozden", "51153121", "067/589-131", "Zoran Zubic"));
            medicalRecords.Add(new MedicalRecord("Filip", "Jerkovic", "Brace Jerkovic 19", Gender.Male, "03011287800077", new DateTime(1957, 9, 3), "Vukan", "412986453", "068/997-525", "Filip Jerkovic"));
            medicalRecords.Add(new MedicalRecord("Milica", "Ostojic", "Augusta Cesarca 2", Gender.Female, "0505592700088", new DateTime(1999, 2, 5), "Milos", "452245224", "063/854-426", "Milica Ostojic"));
            medicalRecords.Add(new MedicalRecord("Jovana", "Peric", "Jovana Ducica 9", Gender.Female, "02485257800077", new DateTime(1977, 4, 1), "Veljko", "412986453", "068/548-123", "Jovana Peric"));
            medicalRecords.Add(new MedicalRecord("Goran", "Karan", "Andje Rankovic 2", Gender.Male, "0505488900088", new DateTime(1965, 2, 11), "Gvozden", "51153121", "067/589-131", "Goran Karan"));
            medicalRecords.Add(new MedicalRecord("Ivan", "Jezdic", "Brace Jerkovic 19", Gender.Male, "0309987800077", new DateTime(1987, 9, 3), "Vukan", "412986453", "068/997-525", "Marko Markovic"));
            medicalRecords.Add(new MedicalRecord("Mira", "Skoric", "Augusta Cesarca 2", Gender.Female, "0502992700088", new DateTime(1992, 2, 5), "Milos", "452245224", "063/854-426", "Mila Vukotic"));
            medicalRecords.Add(new MedicalRecord("Ferenc", "Lato", "Jovana Ducica 9", Gender.Male, "0248857800077", new DateTime(1977, 4, 1), "Veljko", "412986453", "068/548-123", "Ana Arsovic"));
            medicalRecords.Add(new MedicalRecord("Joksim", "Knezevic", "Andje Rankovic 2", Gender.Male, "0503678900088", new DateTime(1965, 2, 11), "Gvozden", "51153121", "067/589-131", "Zoran Zubic"));
            medicalRecords.Add(new MedicalRecord("Miroslav", "Seslija", "Brace Jerkovic 19", Gender.Male, "03011287800077", new DateTime(1957, 9, 3), "Vukan", "412986453", "068/997-525", "Filip Jerkovic"));
            medicalRecords.Add(new MedicalRecord("Anja", "Vojnovic", "Augusta Cesarca 2", Gender.Female, "0505592700088", new DateTime(1999, 2, 5), "Milos", "452245224", "063/854-426", "Milica Ostojic"));
            medicalRecords.Add(new MedicalRecord("Milana", "Petrovic", "Jovana Ducica 9", Gender.Female, "02485257800077", new DateTime(1977, 4, 1), "Veljko", "412986453", "068/548-123", "Jovana Peric"));
            medicalRecords.Add(new MedicalRecord("Petar", "Petrovic", "Andje Rankovic 2", Gender.Male, "0505488900088", new DateTime(1965, 2, 11), "Gvozden", "51153121", "067/589-131", "Goran Karan"));
            return medicalRecords;
        }

        private static List<Appointment> populateCheckUps()
        {
            List<Appointment> checkUps = new List<Appointment>();
            DateTime currentdate = DateTime.Now.Date;
            Appointment checkUp1 = new Appointment()
            {
                AppointmentImageURI = new BitmapImage(new Uri("pack://application:,,,/SekretarWPF;Component/Assets/CheckUp.png")),
                AppointmentType = AppointmentTypes.CheckUp,
                StartTime = currentdate.AddHours(6),
                AppointmentTime = currentdate.AddHours(6).ToString("hh:mm tt"),
                EndTime = currentdate.AddHours(7),
                AppointmentBackground = new SolidColorBrush(Color.FromRgb(211, 47, 47))
            };
            checkUp1.Doctor = "Doctor1";
            checkUp1.Patient = "Patient2";
            checkUp1.Ordination = "Ordination3";
            checkUps.Add(checkUp1);

            Appointment checkUp2 = new Appointment()
            {
                AppointmentImageURI = new BitmapImage(new Uri("pack://application:,,,/SekretarWPF;Component/Assets/CheckUp.png")),
                AppointmentType = AppointmentTypes.CheckUp,
                StartTime = currentdate.AddHours(7),
                AppointmentTime = currentdate.AddHours(7).ToString("hh:mm tt"),
                EndTime = currentdate.AddHours(9),
                AppointmentBackground = new SolidColorBrush(Color.FromRgb(211, 47, 47))
            };
            checkUp2.Doctor = "Doctor3";
            checkUp2.Patient = "Patient1";
            checkUp2.Ordination = "Ordination2";
            checkUps.Add(checkUp2);
            return checkUps;
        }

        private static List<Appointment> populateOperations()
        {
            List<Appointment> operations = new List<Appointment>();
            DateTime currentdate = DateTime.Now.Date;
            Appointment operation1 = new Appointment()
            {
                AppointmentImageURI = new BitmapImage(new Uri("pack://application:,,,/SekretarWPF;Component/Assets/Operation.png")),
                AppointmentType = AppointmentTypes.Operation,
                StartTime = currentdate.AddHours(7),
                AppointmentTime = currentdate.AddHours(7).ToString("hh:mm tt"),
                EndTime = currentdate.AddHours(9),
                AppointmentBackground = new SolidColorBrush(Color.FromRgb(56, 142, 60))
            };
            operation1.Patient = "Patient3";
            operation1.Specialist = "Specialist1";
            operation1.OperatingRoom = "OperatingRoom2";
            operations.Add(operation1);
            return operations;
        }

        public static DataTable getAppointmentsAsTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Type");
            dataTable.Columns.Add("Doctor");
            dataTable.Columns.Add("Patient");
            dataTable.Columns.Add("Room");
            dataTable.Columns.Add("Start time");
            dataTable.Columns.Add("End time");

            List<Appointment> appointmentsThisWeek = new List<Appointment>();
            foreach (Appointment appointment in checkUps)
            {
                if (isDateThisWeek(appointment.StartTime))
                    appointmentsThisWeek.Add(appointment);
            }
            foreach (Appointment appointment in operations)
            {
                if (isDateThisWeek(appointment.StartTime))
                    appointmentsThisWeek.Add(appointment);
            }

            appointmentsThisWeek.Sort((x, y) => DateTime.Compare(x.StartTime, y.StartTime));

            foreach (Appointment appointment in appointmentsThisWeek)
            {
                if(appointment.AppointmentType == AppointmentTypes.CheckUp)
                {
                    dataTable.Rows.Add(new object[] { "Check Up", appointment.Doctor, appointment.Patient, appointment.Ordination, appointment.StartTime.ToString(), appointment.EndTime.ToString() });
                } else
                {
                    dataTable.Rows.Add(new object[] { "Operation", appointment.Specialist, appointment.Patient, appointment.OperatingRoom, appointment.StartTime.ToString(), appointment.EndTime.ToString() });
                }
                
            }
            return dataTable;
        }

        private static bool isDateThisWeek(DateTime date2)
        {
            DateTime date1 = DateTime.Now.Date;
            var cal = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
            var d1 = date1.Date.AddDays(-1 * ((int)cal.GetDayOfWeek(date1)-1));
            var d2 = date2.Date.AddDays(-1 * ((int)cal.GetDayOfWeek(date2)-1));

            return d1 == d2;
        }

    }
}
