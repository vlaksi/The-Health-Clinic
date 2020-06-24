using Controller.MedicalRecordContr;
using Model.Calendar;
using Model.MedicalRecord;
using Model.Medicine;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctors_UI_Console.Functionalities
{
    public class PatientFunctionalities
    {
        private static MedicalRecordController medicalRecordController = new MedicalRecordController();
        public PatientFunctionalities()
        {

        }

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

                List<MedicalRecord> recordsList = new List<MedicalRecord>();
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
                            Console.WriteLine(patientId);
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
                    MedicalRecord matches = recordsList.Find(mr => mr.Id == id);
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

        //Obični prikaz rezultata pretrage, bez funkcionalnosti nad kartonima.
        private static void PrintSearchResults(List<MedicalRecord> records)
        {
            foreach (MedicalRecord mr in records)
            {
                // ~~~ Priprema ~~~
                //Dobavljanje termina:

                //Dobavljanje tretmana:
                ObservableCollection<Treatment> treatments = mr.Treatments;

                // ~~~ Print ~~~
                Console.WriteLine("\t~~~ Medical record of " + mr.Name + " " + mr.Surname + " ~~~~");
                Console.WriteLine("\t\tParents Name: " + mr.ParentsName);
                Console.WriteLine("\t\tGender: " + mr.Gender);
                Console.WriteLine("\t\tBirth: " + mr.DateOfBirth.ToShortDateString());
                Console.WriteLine("\t\tAddress: " + mr.Address);
                Console.WriteLine("\t\tPhone: " + mr.Phone);
                if (treatments == null || treatments.Count == 0)
                {
                    Console.WriteLine("\t\tTreatments: None");
                }
                else
                {
                    Console.WriteLine("\t\tTreatments: ");
                    PrintTreatments(treatments);
                }
                Console.WriteLine("\t\tID: " + mr.Id);
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


        // Kada se konačno odabere jedan pacijent, ulazi se u njegov karton i moguće je raditi funkcionalnosti poput propisivanje tretmana itd.
        private static void EnterPatientsMedicalRecord(MedicalRecord mr)
        {
            bool breakOut = false;
            while (!breakOut)
            {
                // ~~~ Priprema ~~~
                //Dobavljanje termina:

                //Dobavljanje tretmana:
                ObservableCollection<Treatment> treatments = mr.Treatments;

                // ~~~ Print ~~~
                Console.WriteLine("\t~~~ Medical record of " + mr.Name + " " + mr.Surname + " ~~~~");
                Console.WriteLine("\t\tParents Name: " + mr.ParentsName);
                Console.WriteLine("\t\tGender: " + mr.Gender);
                Console.WriteLine("\t\tBirth: " + mr.DateOfBirth.ToShortDateString());
                Console.WriteLine("\t\tAddress: " + mr.Address);
                Console.WriteLine("\t\tPhone: " + mr.Phone);
                if (treatments == null || treatments.Count == 0)
                {
                    Console.WriteLine("\t\tTreatments: None");
                }
                else
                {
                    Console.WriteLine("\t\tTreatments: ");
                    PrintTreatments(treatments);
                }
                Console.WriteLine("\t\tID: " + mr.Id);



                Console.WriteLine("\n\t1) Write a Prescription");
                Console.WriteLine("\t2) Make a Referral to Specialist");
                Console.WriteLine("\t3) Write a Report");
                Console.WriteLine("\t4) Preview Reports");
                Console.WriteLine("\tX) Exit " + mr.Name + "'s Medical Record");
                Console.Write("\t\tWhich action do you want to perform? ");
                switch (Console.ReadLine().ToLower())
                {
                    case "1":
                        MedicalRecordFunctionalities.WritePrescription(mr);
                        break;
                    case "3":
                        MedicalRecordFunctionalities.WriteReport(mr);
                        break;
                    case "4":
                        MedicalRecordFunctionalities.PreviewReports(mr);
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
