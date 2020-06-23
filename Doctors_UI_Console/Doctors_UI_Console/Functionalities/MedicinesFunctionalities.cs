using Controller.MedicineContr;
using Model.Medicine;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctors_UI_Console.Functionalities
{
    public class MedicinesFunctionalities
    {
        private static MedicineController medicineController = new MedicineController();

        public static void PreviewMedicinesWaitingApproval()
        {
            Console.WriteLine("\n\t~~~ Medicines awaiting Approval ~~~");
            List<Medicine> medicinesAwaitingApproval = medicineController.GetMedicinesAwaitingApproval();

            foreach (Medicine med in medicinesAwaitingApproval)
            {
                PrintMedicine(med);
            }

            Console.WriteLine("\n\t\tWhich medicine do you wish to approve? (ID) ");
            string input = Console.ReadLine();
            Console.WriteLine("\t\tPress X to exit");
            ValidateMedicineFromList(input, medicinesAwaitingApproval);
        }

        private static void PrintMedicine(Medicine med)
        {
            Console.WriteLine("\n\t~~~ Name: " + med.Name + " ~~~");
            Console.WriteLine("\t\tID: " + med.Id);
            Console.WriteLine("\t\tManufacturer: " + med.Manufacturer);
            Console.WriteLine("\t\tMedicine type: " + SpecialtyTypeExtensions.ToFriendlyString(med.SpecialtyType));
            Console.WriteLine("\t\tExpires: " + med.ExpirationDate.ToShortDateString());
            Console.WriteLine("\t\tQuantity: " + med.Quantity);
            Console.WriteLine("\t\tMedicine status: " + MedicineStatusExtensions.ToFriendlyString(med.MedicineStatus));
            Console.WriteLine("\t\tIngredients: ");
            foreach (Ingredient ing in med.Ingredient)
            {
                Console.WriteLine("\t\t\t* " + ing.Code + " " + ing.Name);
            }
            Console.WriteLine("\t\tAlergens: ");
            foreach (Alergen alerg in med.Alergen)
            {
                Console.WriteLine("\t\t\t* " + alerg.Code + " " + alerg.Name);
            }

        }


        private static void ValidateMedicineFromList(string input, List<Medicine>medicines)
        {
            bool badParse = true;
            while (badParse)
            {
                if (Int32.TryParse(input, out int id))
                {
                    Medicine matches = medicines.Find(mr => mr.Id == id);
                    if (matches != null)
                    {
                        medicineController.ValidateMedicine(matches);
                        badParse = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\tAre you sure you entered ID from the list?");
                        break;
                    }
                }
                else if (input.ToLower().Equals("x"))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\tPlease enter a valid ID!");
                }
            }
        }
    }
}
