using Controller.MedicalRecordContr;
using Controller.MedicineContr;
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
    }
}
