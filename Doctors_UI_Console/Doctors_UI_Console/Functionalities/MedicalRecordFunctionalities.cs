using Controller.DoctorContr;
using Controller.MedicalRecordContr;
using Controller.MedicineContr;
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
    public class MedicalRecordFunctionalities
    {

        private static MedicineController mc = new MedicineController();
        private static MedicalRecordController medicalRecordController = new MedicalRecordController();
        private static PatientController patientController = new PatientController();
        private static RoomsController roomsController = new RoomsController();
        private static DoctorController doctorController = new DoctorController();

        #region Write a Prescription
        public static void WritePrescription(MedicalRecord mr)
        {
            if (!LoggedIn.doctorLoggedIn.AbleToPrescribeTreatments)
            {
                Console.WriteLine("\tSorry " + LoggedIn.doctorLoggedIn.Name + ", you are not allowed to prescribe treatments.");
                Thread.Sleep(3000);
                return;
            }


            PatientModel patient = patientController.FindById(mr.PatientId);

            Treatment newTreatment = new Treatment() { Medicines = new ObservableCollection<Medicine>() };
            List<Medicine> availableMedicines = new List<Medicine>(mc.GetAvailableMedicines());

            Console.WriteLine("\n\t~~~ Write a Prescription for " + patient.Name + " " + patient.Surname + " ~~~");
            foreach (Medicine med in availableMedicines)
            {
                MedicinesFunctionalities.PrintMedicine(med);
            }

            Console.Write("\n\tSelect medicines for the prescription: (ID)");
            Console.WriteLine("\tPress X to finish entering medicines.");
            while (true)
            {
                Console.Write("\tMedicine ID: ");
                string input = Console.ReadLine();
                if (input.ToLower().Equals("x"))
                {
                    break;
                }

                if (Int32.TryParse(input, out int id))
                {
                    Medicine matches = availableMedicines.Find(med => med.Id == id);
                    if (matches != null)
                    {
                        newTreatment.Medicines.Add(matches);
                        Console.WriteLine("\tSuccessfully added " + matches.Name + "!");
                    }
                    else
                    {
                        Console.WriteLine("\tPlease select a medicine from the list.");
                    }
                }
                else
                {
                    Console.WriteLine("\t\tPlease enter a valid id!");
                }
            }

            Console.Write("\tEnter the starting date: (e.g. 12/24/2020) ");
            newTreatment.DateTimeStart = EnterDate();
            Console.WriteLine("\tStarting date is " + newTreatment.DateTimeStart.ToShortDateString());

            Console.Write("\tEnter the ending date: (e.g. 1/14/2021) ");
            newTreatment.DateTimeEnd = EnterDate();
            Console.WriteLine("\tEnding date is " + newTreatment.DateTimeEnd.ToShortDateString());

            Console.Write("\tProvide instructions for handling this treatment: ");
            string instructions = Console.ReadLine();
            newTreatment.Instructions = instructions;


            mr.Treatments.Add(newTreatment);
            medicalRecordController.UpdateMedicalRecord(mr);
            Console.WriteLine("\n\t ~~~ You've successfully written a prescription for " + patient.Name + " " + patient.Surname + "! ~~~");
        }
        #endregion

        public static void WriteReport(MedicalRecord mr)
        {
            if(mr.Checkups.Count == 0 || mr.Operations.Count == 0)
            {
                Console.WriteLine("\tPatient does not have any terms to write report for.");
                Thread.Sleep(2000);
                return;
            }

            List<string> commonConditions = new List<string>();
            List<string> observations = new List<string>();
            PatientModel patient = patientController.FindById(mr.PatientId);
            foreach (int termId in mr.Checkups)
            {
                Console.WriteLine("\tCheckup with id: " + termId);
            }
            foreach (int termId in mr.Operations)
            {
                Console.WriteLine("\tOperation with id: " + termId);
            }

            if(mr.Operations.Count == 0 || mr.Checkups.Count == 0)
            {
                Console.WriteLine("\t\tPatient has no terms to write report on!");
                Thread.Sleep(2000);
                return;
            }

            Report newReport = new Report();
            Console.Write("\n\tSelect term for the this report: (ID)");
            while (true)
            {
                Console.Write("\tTerm ID: ");
                string input = Console.ReadLine();
                if (input.ToLower().Equals("x"))
                {
                    break;
                }

                if (Int32.TryParse(input, out int id))
                {
                    int checkupMatch = mr.Checkups.Find(term => term == id);
                    if (checkupMatch != 0)
                    {
                        newReport.TermId = checkupMatch;
                        Console.WriteLine("\tSuccessfully selected checkup with ID " + checkupMatch + "!");
                        break;
                    }
                    else
                    {
                        int operationMatch = mr.Operations.Find(term => term == id);
                        if (operationMatch != 0)
                        {
                            newReport.TermId = operationMatch;
                            Console.WriteLine("\tSuccessfully selected checkup with ID " + operationMatch + "!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\tPlease select a term from the list.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\t\tPlease enter a valid id!");
                }
            }
            

            Console.Write("\tPlease enter patient's report during this term (e.g. how he felt): ");
            string patientsReport = Console.ReadLine();

            Console.Write("\tPlease enter your remarks during this term (e.g. what do you think about his situation): ");
            string doctorsRemark = Console.ReadLine();

            Console.WriteLine("\tSelect common medical conditions that you could notice on the patient: ");
            commonConditions = SelectCommonConditions();

            Console.WriteLine("\tPlease perform measurements of patient's vital functions: ");
            observations = PerformObservations();

            newReport.PatientsReport = patientsReport;
            newReport.DoctorsRemark = doctorsRemark;
            newReport.CommonMedicalConditions = commonConditions;
            newReport.PatientsReport = patientsReport;
            newReport.Observations = observations;
            
            medicalRecordController.SaveReport(mr, newReport);
            Console.WriteLine("\n\t\tSuccessfully saved new report for " + patient.Name + " " + patient.Surname + "!");
        }

        public static void PreviewReports(MedicalRecord mr)
        {
            PatientModel patient = patientController.FindById(mr.PatientId);
            //odraditi populaciju termina
            Console.WriteLine("\n\t~ Previewing reports for " + patient.Name + " " + patient.Surname + " ~");

            if (mr.Reports.Count == 0)
            {
                Console.WriteLine("\t\tThere are no reports for " + patient.Name + " " + patient.Surname + ".\n\n");
                Thread.Sleep(2000);
                return;
            }

            foreach (Report report in mr.Reports)
            {
                PrintReport(report);
            }

            Console.WriteLine("\tPress any key to exit preview.");
            Console.ReadLine();
        }

        public static void AccommodatePatient(MedicalRecord mr)
        {
            if (mr.IsAccommodated)
            {
                Console.Write("\n\tPatient is already accommodated! Do you wish to transfer him? (Y/N) ");
                if (string.Compare(Console.ReadLine(), "N", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    return;
                }
            }

            List<Room> availableRooms = roomsController.GetAvailablePatientsRooms();
            if(availableRooms.Count == 0)
            {
                Console.WriteLine("\t\tThere are no rooms available!");
                Thread.Sleep(2000);
                return;
            }
            Console.WriteLine("\tSelect a room from the list of available rooms");
            while (true)
            {
                foreach (Room room in availableRooms)
                {
                    Console.WriteLine("\t\t*** Room " + room.NumberOfRoom);
                    Console.WriteLine("\t\t\tCapacity: " + room.Capacity);
                    Console.WriteLine("\t\t\tPatients accommodated: " + room.PatientsAccommodated);
                    Console.WriteLine("\t\t\tId " + room.RoomId);
                }
                Console.Write("\t\tPick a room: (ID) ");
                string roomId = Console.ReadLine();

                if (Int32.TryParse(roomId, out int id))
                {
                    if (!availableRooms.Any(room => room.RoomId == id))
                    {
                        Console.WriteLine("\tPlease select a choice from the list.");
                        continue;
                    }
                    Room selectedRoom = availableRooms.Where(room => room.RoomId == id).FirstOrDefault();
                    mr.IsAccommodated = true;
                    mr.RoomId = id;
                    Console.WriteLine("\tSuccessfully selected room " + selectedRoom.NumberOfRoom + " from the list!");
                    break;
                }
            }
            Console.Write("\tEnter accommodation start date: ");
            mr.AccommodationStart = EnterDate();
            Console.Write("\tEnter accommodation end date: ");
            mr.AccommodationEnd = EnterDate();
            mr.IsAccommodated = true;

            medicalRecordController.UpdateMedicalRecord(mr);
            Console.WriteLine("\tSuccessfully accommodated patient in room!");

            //Update room
            Room updateRoom = roomsController.findById(mr.RoomId);
            updateRoom.PatientsAccommodated++;
            roomsController.makeUpdateFor(updateRoom);
        }

        public static void ReferToSpecialist(MedicalRecord mr)
        {
            SpecialtyType specialtyNeeded = SpecialtyType.general;
            while (true)
            {
                Console.WriteLine("\tSpecialties we have: ");
                Console.WriteLine("\t\t1) Cardiovascular");
                Console.WriteLine("\t\t2) Dermatological");
                Console.WriteLine("\t\t3) Oncological");
                Console.Write("\tWhat kind of specialist do you need? ");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    specialtyNeeded = SpecialtyType.cardiovascular;
                    break;
                }
                else
                {
                    continue;
                }
            }

            List<Doctor> specialistsFound = doctorController.GetAllSpecialistsBySpecialty(specialtyNeeded);
            if (specialistsFound.Count == 0)
            {
                Console.WriteLine("\tThere are no specialists for this specialty...");
                return;
            }

            int selectedSpecialist = -1;
            while (true)
            {
                foreach (Doctor doc in specialistsFound)
                {
                    Console.WriteLine("\t\tName: " + doc.Name + " " + doc.Surname);
                    Console.WriteLine("\t\tId: " + doc.Id);
                }

                Console.Write("\tSelect a doctor: (ID) ");
                string docId = Console.ReadLine();
                if (Int32.TryParse(docId, out int id))
                {
                    if (!specialistsFound.Any(spec => spec.Id == id))
                    {
                        Console.WriteLine("\tPlease select a specialist from the list.");
                        continue;
                    }
                    Doctor doctor = specialistsFound.Where(spec => spec.Id == id).FirstOrDefault();
                    selectedSpecialist = doctor.Id;
                    Console.WriteLine("\tSuccessfully selected room " + doctor.Name + " " + doctor.Surname + " from the list!");
                    break;
                }
                else
                {
                    continue;
                }
            }

            Console.WriteLine("\tWhich dates do you need?");
            Console.Write("\t\tStart date: (YYYY-MM-DD) ");
            DateTime fromTime = EnterDate();
            Console.Write("\t\tEnd date: (YYYY-MM-DD) ");
            DateTime toTime = EnterDate();

            ReferralToSpecialist referral = new ReferralToSpecialist()
            {
                NonspecialistId = LoggedIn.doctorLoggedIn.Id,
                SpecialistId = selectedSpecialist,
                ValidFromDate = fromTime,
                ValidToDate = toTime
            };

            mr.AddReferralToSpecialist(referral);
            medicalRecordController.UpdateMedicalRecord(mr);

            Console.WriteLine("\tSuccessfully created a referral!");
        }

        #region Helpers

        private static void PrintReport(Report report)
        {
            //odraditi populaciju termina
            Console.WriteLine("\t\tTerm ID: " + report.TermId);
            Console.WriteLine("\t\tPatient's report: " + report.PatientsReport);
            Console.WriteLine("\t\tDoctor's remarks: " + report.DoctorsRemark);
            Console.WriteLine("\t\tCommon medical conditions: ");
            foreach (string cond in report.CommonMedicalConditions)
            {
                Console.WriteLine("\t\t\t- " + cond);
            }
            Console.WriteLine("\t\tObservations: ");
            foreach (string obs in report.Observations)
            {
                Console.WriteLine("\t\t\t- " + obs);
            }
        }
        public static DateTime EnterDate()
        {
            while (true)
            {
                if (DateTime.TryParse(Console.ReadLine(), out DateTime enteredDateTime))
                {
                    if (enteredDateTime < DateTime.Now)
                    {
                        Console.WriteLine("\t\tDate cannot be before today!");
                        continue;
                    }
                    return enteredDateTime;
                }
                else
                {
                    Console.WriteLine("\tYou have entered an incorrect value. Please try again.");
                    Console.WriteLine("\t\tTry again: ");
                }
            }
        }

        private static List<string> SelectCommonConditions()
        {
            List<string> result = new List<string>();
            List<string> commonConditions = new List<string>()
            {
                "Alcohol Dependence",
                "Drug Dependence",
                "Seizure(s) - Cerebral",
                "Seizure(s) - Alcohol related",
                "Heart Disease",
                "Motor Function/Ability Impaired",
                "Visual Acuity Impairment",
                "Visual Field Impairment",
                "Mental or Emotional Illness",
                "Dementia or Alzheimer's",
                "Sleep Apnea",
                "Narcolepsy",
                "Diabetes or Hypoglicemia",
                "Blackout or Loss of Awareness",
                "Bone or Join deformity",
                "Stroke or Head Injury",
                "Loss of Memory",
                "Skin Disease",
                "Intestinal Troubles",
                "Skin Disease",
                "Swollen or Painful Joints",
                "Chronic Cough",
                "Fever",
                "Car or Sea Sickness",
                "Rapid Gain/Loss of Weight"
            };

            while (true)
            {
                int i = 0;
                foreach (string condition in commonConditions)
                {
                    Console.WriteLine("\t\t- " + ++i + " " + condition);
                }
                Console.WriteLine("\tPress X to continue with writing the report.");
                Console.Write("\tChoose a condition: ");
                string input = Console.ReadLine();
                if (input.ToLower().Equals("x"))
                {
                    break;
                }

                if (Int32.TryParse(input, out int id))
                {
                    if (id > commonConditions.Count || id < 1)
                    {
                        Console.WriteLine("\tPlease select a condition from the list.");
                        continue;
                    }
                    string matches = commonConditions[id - 1];
                    if (!matches.Equals(""))
                    {
                        result.Add(matches);
                        commonConditions.Remove(matches);
                        Console.WriteLine("\tSuccessfully added " + matches + " to the list of common conditions!");
                    }
                    else
                    {
                        Console.WriteLine("\tPlease select a term from the list.");
                    }
                }
                else
                {
                    Console.WriteLine("\t\tPlease enter a valid id!");
                }

            }

            return result;
        }

        private static List<string> PerformObservations()
        {
            List<string> result = new List<string>();

            Console.WriteLine("\tAirway: ");
            string airway = "Airway: " + SelectFromTheList(new List<string>() { "Clear", "Obstructed", "Noisy" });
            result.Add(airway);

            Console.WriteLine("\tBreathing: ");
            string breathing = "Breathing: " + SelectFromTheList(new List<string>() { "Normal", "Shallow", "Irregular" });
            result.Add(breathing);

            Console.WriteLine("\tPupils: ");
            string pupils = "Pupils: " + SelectFromTheList(new List<string>() { "Normal", "Reactive" });
            result.Add(pupils);

            double upperBloodPressure = InputNumericalValue("Upper blood pressure");
            double lowerBloodPressure = InputNumericalValue("Lower blood pressure");
            string bloodPressureString = "Blood pressure: " + upperBloodPressure + "/" + lowerBloodPressure;
            result.Add(bloodPressureString);

            double heartRate = InputNumericalValue("Heart rate");
            string heartRateString = "Heart rate: " + heartRate;
            result.Add(heartRateString);

            double temperature = InputNumericalValue("Temperature");
            string temperatureString = "Temperature: " + temperature;
            result.Add(temperatureString);

            Console.WriteLine("\tSuccessfully added observations to the report!");

            return result;
        }

        private static string SelectFromTheList(List<string> choices)
        {
            string result = "";

            while (true)
            {
                int i = 0;
                foreach (string choice in choices)
                {
                    Console.WriteLine("\t" + ++i + " " + choice);
                }
                Console.Write("\tYour choice: ");
                string input = Console.ReadLine();

                if (Int32.TryParse(input, out int id))
                {
                    if (id > choices.Count || id < 1)
                    {
                        Console.WriteLine("\tPlease select a choice from the list.");
                        continue;
                    }
                    string matches = choices[id - 1];
                    if (!matches.Equals(""))
                    {
                        result = matches;
                        Console.WriteLine("\tSuccessfully selected " + matches + " from the list of choices!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\tPlease select a choice from the list.");
                    }
                }
                else
                {
                    Console.WriteLine("\t\tPlease enter a valid id!");
                }
            }

            return result;
        }

        // Label - what is being inputted (heart rate, blood pressure etc)
        private static double InputNumericalValue(string label)
        {
            double result = -1;

            while (true)
            {
                Console.Write("\t" + label + ": ");
                string input = Console.ReadLine();

                if (Double.TryParse(input, out double number))
                {
                    if (number < 0)
                    {
                        Console.WriteLine("\tPlease input a valid value for " + label);
                        continue;
                    }
                    result = number;
                    break;
                }
                else
                {
                    Console.WriteLine("\t\tPlease enter a number!");
                }
            }

            return result;
        }
        #endregion
    }
}
