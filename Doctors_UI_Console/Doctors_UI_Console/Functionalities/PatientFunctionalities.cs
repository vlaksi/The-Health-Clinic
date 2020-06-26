using Controller.DoctorContr;
using Controller.MedicalRecordContr;
using Controller.PatientContr;
using Controller.RoomsContr;
using Model.Calendar;
using Model.MedicalRecord;
using Model.Medicine;
using Model.Rooms;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Doctors_UI_Console.Functionalities
{
    public class PatientFunctionalities
    {
        private static MedicalRecordController medicalRecordController = new MedicalRecordController();
        private static PatientController patientController = new PatientController();
        private static DoctorController doctorController = new DoctorController();
        private static RoomsController roomsController = new RoomsController();

        #region Search
        public static void SearchPatients()
        {
            bool searchPatients = true;

            while (searchPatients)
            {
                searchPatients = ShowSearchMenu();
            }

        }

        private static bool ShowSearchMenu()
        {
            Console.Clear();
            Console.WriteLine("\n~~~~ Searching for Patients ~~~~");
            Console.WriteLine("\tDo you wish to search patients by Name or by their ID?");
            Console.WriteLine("\t\t1) Name");
            Console.WriteLine("\t\t2) ID");
            Console.WriteLine("\tEnter X to exit the Search menu");
            Console.Write("\n\t>> ");


            switch (Console.ReadLine().ToLower())
            {
                case "1":
                    SearchPatientsByName();
                    return true;
                case "2":
                    SearchPatientsByID();
                    return true;
                case "x":
                    return false;
                default:
                    return true;
            }
        }

        private static void SearchPatientsByID()
        {
            bool breakOut = false;
            while (!breakOut)
            {
                Console.WriteLine("\n ~ Searching for Patients by ID ~");
                Console.WriteLine("\tEnter X to exit the Search menu");
                Console.Write("\n\tEnter patient's ID: ");
                string input;

                switch (input = Console.ReadLine().ToLower())
                {
                    case "x":
                        breakOut = true;
                        break;
                    default:
                        MedicalRecord found = medicalRecordController.GetMedicalRecordByPatientId(Convert.ToInt32(input));
                        if (found != null)
                        {
                            EnterPatientsMedicalRecord(found);
                            breakOut = true;
                        }
                        else
                        {
                            Console.WriteLine("\tNo patients with that ID were found! Please try again...");
                        }
                        break;
                }
            }
        }

        private static void SearchPatientsByName()
        {
            bool breakOut = false;
            while (!breakOut)
            {
                Console.WriteLine("\n ~ Searching for Patients by Name");
                Console.WriteLine("\tEnter X to exit the Search menu");
                Console.Write("\n\tEnter patient's name: ");

                List<MedicalRecord> recordsList = new List<MedicalRecord>();
                string input;

                switch (input = Console.ReadLine().ToLower())
                {
                    case "x":
                        breakOut = true;
                        break;
                    default:
                        recordsList = new List<MedicalRecord>(medicalRecordController.GetMedicalRecordByPatientName(input));
                        if (recordsList.Count != 0)
                        {
                            PrintSearchResults(recordsList);
                            Console.WriteLine("\t\t\t\t* " + recordsList.Count + " record(s) found.");
                            Console.Write("\n\tPlease enter ID of patient whose medical record you wish to preview: ");
                            string patientId = Console.ReadLine();
                            SelectPatientFromListById(patientId, recordsList);
                            breakOut = true;
                        }
                        else
                        {
                            Console.WriteLine("\tNo patients with that name were found! Please try again...");
                        }

                        break;
                }
            }

        }

        private static void SelectPatientFromListById(string patientId, List<MedicalRecord> recordsList)
        {
            bool badParse = true;
            while (badParse)
            {
                if (Int32.TryParse(patientId, out int id))
                {
                    MedicalRecord matches = recordsList.Find(mr => mr.PatientId == id);
                    if (matches != null)
                    {
                        EnterPatientsMedicalRecord(matches);
                        badParse = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\tAre you sure you entered ID from the list?");
                        break;
                    }
                }
                else if (patientId.ToLower().Equals("x"))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\tPlease enter a valid ID!");
                }
            }
        }
        #endregion
        #region Prints
        private static void PrintMedicalRecord(MedicalRecord mr)
        {
            PatientModel patient = patientController.FindById(mr.PatientId);
            // ~~~ Priprema ~~~
            //Dobavljanje termina:

            //Dobavljanje tretmana:
            ObservableCollection<Treatment> treatments = mr.Treatments;

            // ~~~ Print ~~~
            Console.WriteLine("\t~~~ Medical record of " + patient.Name + " " + patient.Surname + " ~~~~");
            Console.WriteLine("\t\tParents Name: " + patient.ParentsName);
            Console.WriteLine("\t\tGender: " + patient.Gender);
            Console.WriteLine("\t\tBirth: " + patient.Birthday.ToShortDateString());
            Console.WriteLine("\t\tAddress: " + patient.Adress);
            Console.WriteLine("\t\tPhone: " + patient.PhoneNumber);
            if (mr.IsAccommodated)
            {
                Room accommodation = roomsController.findById(mr.RoomId);
                Console.WriteLine("\t\tAccommodation: " + accommodation.NumberOfRoom);
            }
            else
            {
                Console.WriteLine("\t\tAccommodation: At home");
            }
            if (treatments == null || treatments.Count == 0)
            {
                Console.WriteLine("\t\tTreatments: None");
            }
            else
            {
                Console.WriteLine("\t\tTreatments: ");
                PrintTreatments(treatments);
            }
            if (mr.ReferralToSpecialist.Count == 0)
            {
                Console.WriteLine("\t\tReferrals: None.");
            }
            else
            {
                Console.WriteLine("\t\tReferrals:");
                PrintReferrals(mr.ReferralToSpecialist);
            }
            Console.WriteLine("\t\tMedical Record ID: " + mr.MedicalRecordId);
        }

        //Obični prikaz rezultata pretrage, bez funkcionalnosti nad kartonima.
        private static void PrintSearchResults(List<MedicalRecord> records)
        {
            foreach (MedicalRecord mr in records)
            {
                PrintMedicalRecord(mr);
            }
        }


        private static void PrintTreatments(ObservableCollection<Treatment> treatments)
        {
            foreach (Treatment treatment in treatments)
            {
                Console.WriteLine("\t\tTreatment which started on " + treatment.DateTimeStart.ToShortDateString() + " and ended/will end on " + treatment.DateTimeEnd.ToShortDateString() + ", patient took/takes: ");
                foreach (Medicine med in treatment.Medicines)
                {
                    Console.WriteLine("\t\t\t\t- " + med.Name);
                }
                Console.WriteLine("\t\t\tFollowing instructions were given:");
                Console.WriteLine("\t\t\t\t'" + treatment.Instructions + "'");
            }
        }

        private static void PrintReferrals(List<ReferralToSpecialist> referrals)
        {

            foreach (ReferralToSpecialist referral in referrals)
            {
                Doctor nonSpecialist = doctorController.FindById(referral.NonspecialistId);
                Doctor specialist = doctorController.FindById(referral.SpecialistId);
                Console.WriteLine("\t\t\tReferral from " + nonSpecialist.Name + " " + nonSpecialist.Surname + ", ");
                Console.WriteLine("\t\t\tto " + specialist.Name + " " + specialist.Surname + ", valid from ");
                Console.WriteLine("\t\t\t" + referral.ValidFromDate.ToShortDateString() + " to " + referral.ValidToDate.ToShortDateString() + ".\n");
            }
        }
        #endregion

        // Kada se konačno odabere jedan pacijent, ulazi se u njegov karton i moguće je raditi funkcionalnosti poput propisivanje tretmana itd.
        private static void EnterPatientsMedicalRecord(MedicalRecord mr)
        {
            PatientModel patient = patientController.FindById(mr.PatientId);

            bool breakOut = false;
            while (!breakOut)
            {
                PrintMedicalRecord(mr);

                Console.WriteLine("\n\t1) Write a Prescription");
                Console.WriteLine("\t2) Make a Referral to Specialist");
                Console.WriteLine("\t3) Write a Report");
                Console.WriteLine("\t4) Preview Reports");
                Console.WriteLine("\t5) Accommodate patient");
                Console.WriteLine("\t6) Schedule checkup");
                if (LoggedIn.doctorLoggedIn.SpecialtyType != SpecialtyType.general)
                {
                    Console.WriteLine("\t7) Schedule operation");
                }
                Console.WriteLine("\t8) Preview All Terms");
                Console.WriteLine("\tX) Exit " + patient.Name + "'s Medical Record");
                Console.Write("\t\tWhich action do you want to perform? ");
                switch (Console.ReadLine().ToLower())
                {
                    case "1":
                        MedicalRecordFunctionalities.WritePrescription(mr);
                        break;
                    case "2":
                        MedicalRecordFunctionalities.ReferToSpecialist(mr);
                        break;
                    case "3":
                        MedicalRecordFunctionalities.WriteReport(mr);
                        break;
                    case "4":
                        MedicalRecordFunctionalities.PreviewReports(mr);
                        break;
                    case "5":
                        MedicalRecordFunctionalities.AccommodatePatient(mr);
                        break;
                    case "6":
                        CalendarFunctionalities.ScheduleCheckup(mr);
                        break;
                    case "7":
                        if (LoggedIn.doctorLoggedIn.SpecialtyType == SpecialtyType.general)
                        {
                            Console.WriteLine("\t\tAs general practicioner, you cannot schedule operations.");
                            Thread.Sleep(1500);
                            break;
                        }   
                        CalendarFunctionalities.ScheduleOperation(mr);
                        break;
                    case "8":
                        CalendarFunctionalities.PreviewTerms(mr);
                        break;
                    case "x":
                        breakOut = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
