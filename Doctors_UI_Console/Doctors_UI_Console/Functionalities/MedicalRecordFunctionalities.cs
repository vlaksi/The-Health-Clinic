using Controller.MedicalRecordContr;
using Controller.MedicineContr;
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
    public class MedicalRecordFunctionalities
    {

        private static MedicineController mc = new MedicineController();
        private static MedicalRecordController medicalRecordController = new MedicalRecordController();

        #region Write a Prescription
        public static void WritePrescription(MedicalRecord mr)
        {
            Treatment newTreatment = new Treatment() { Medicines = new ObservableCollection<Medicine>() };

            List<Medicine> availableMedicines = new List<Medicine>(mc.GetAvailableMedicines());

            Console.WriteLine("\n\t~~~ Write a Prescription for " + mr.Name + " " + mr.Surname + " ~~~");
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
            Console.WriteLine("\n\t ~~~ You've successfully written a prescription for " + mr.Name + " " + mr.Surname + "! ~~~");
        }
        #endregion 


        public static void WriteReport(MedicalRecord mr)
        {
            List<string> commonConditions = new List<string>();
            List<string> observations = new List<string>();

            /*
             * Kada se dodaju termini
            foreach (int termId in mr.Terms)
            {
                Console.WriteLine("\tTerm with id: " + termId);
            }

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
                    int matches = mr.Terms.Find(term => term == id);
                    if (matches != 0)
                    {
                        newReport.TermId = id;
                        Console.WriteLine("\tSuccessfully selected term with ID " + matches + "!");
                        break;
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
            */

            Console.Write("\tPlease enter patient's report during this term (e.g. how he felt): ");
            string patientsReport = Console.ReadLine();

            Console.Write("\tPlease enter your remarks during this term (e.g. what do you think about his situation): ");
            string doctorsRemark = Console.ReadLine();

            Console.WriteLine("\tSelect common medical conditions that you could notice on the patient: ");
            commonConditions = SelectCommonConditions();

            Console.WriteLine("\tPlease perform measurements of patient's vital functions: ");
            observations = PerformObservations();


            Report newReport = new Report()
            {
                PatientsReport = patientsReport,
                DoctorsRemark = doctorsRemark,
                CommonMedicalConditions = commonConditions,
                Observations = observations
            };
            medicalRecordController.SaveReport(mr, newReport);
            Console.WriteLine("\n\t\tSuccessfully saved new report for " + mr.Name + " " + mr.Surname + "!");
        }

        public static void PreviewReports(MedicalRecord mr)
        {
            //odraditi populaciju termina
            Console.WriteLine("\n\t~ Previewing reports for " + mr.Name + " " + mr.Surname + " ~");

            if (mr.Reports.Count == 0)
            {
                Console.WriteLine("\t\tThere are no reports for " + mr.Name + " " + mr.Surname + ".");
                return;
            }

            foreach (Report report in mr.Reports)
            {
                PrintReport(report);
            }

            Console.WriteLine("\tPress any key to exit preview");
            Console.ReadLine();
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
        private static DateTime EnterDate()
        {
            while (true)
            {
                if (DateTime.TryParse(Console.ReadLine(), out DateTime enteredDateTime))
                {
                    return enteredDateTime;
                }
                else
                {
                    Console.WriteLine("\tYou have entered an incorrect value. Please try again.");
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
                int i = 0;
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
