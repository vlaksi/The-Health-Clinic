using Controller.DoctorContr;
using Controller.MedicalRecordContr;
using Controller.PatientContr;
using Controller.RoomsContr;
using Controller.TermContr;
using Model.Calendar;
using Model.MedicalRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Doctors_UI_Console.Functionalities
{
    public class UserFunctionalities
    {
        private static PatientController patientController = new PatientController();
        private static DoctorController doctorController = new DoctorController();
        private static RoomsController roomsController = new RoomsController();
        private static TermContextController termController = new TermContextController();
        private static MedicalRecordController medicalRecordController = new MedicalRecordController();
        public static void PreviewMyAppointments()
        {
            while (true)
            {
                while (true)
                {
                    Console.Clear();
                    List<int> operationsForSelection = new List<int>();

                    List<Operation> operations = termController.getAllOperationsForDoctor(LoggedIn.doctorLoggedIn.Id);

                    Console.WriteLine("\n\t~~~ Your Operations ~~~");
                    if (operations.Count == 0)
                    {
                        Console.WriteLine("\t\tNone.\n");
                        Console.Write("\t\t\tPress any key continue to checkups.");
                        Console.ReadLine();
                        break;
                    }
                    else
                    {
                        foreach (Operation operation in operations)
                        {
                            operationsForSelection.Add(operation.Id);
                            CalendarFunctionalities.PrintOperation(operation);
                        }

                        Console.WriteLine("\t\tDo you want to edit or cancel any operation? ");
                        Console.WriteLine("\t\t\t1) Edit");
                        Console.WriteLine("\t\t\t2) Cancel");
                        Console.WriteLine("\t\t\tX) Neither");
                        Console.Write("\t\t>> ");
                        string input = Console.ReadLine();
                        if (input == "1")
                        {
                            EditOperation(operationsForSelection);
                        }
                        else if (input == "2")
                        {
                            CancelOperation(operationsForSelection);
                        }
                        else if (input == "X" || input == "x")
                        {
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

                while (true)
                {
                    List<int> checkupsForSelection = new List<int>();
                    List<Checkup> checkups = termController.getAllCheckupsForDoctor(LoggedIn.doctorLoggedIn.Id);

                    Console.WriteLine("\n\t~~~ Your Checkups ~~~");
                    if (checkups.Count == 0)
                    {
                        Console.WriteLine("\t\tNone.\n");
                        Console.Write("\t\t\tPress any key to exit preview.");
                        Console.ReadLine();
                        return;
                    }
                    else
                    {
                        foreach (Checkup checkup in checkups)
                        {
                            checkupsForSelection.Add(checkup.Id);
                            CalendarFunctionalities.PrintCheckup(checkup);
                        }

                        Console.WriteLine("\t\tDo you want to edit or cancel any checkups? ");
                        Console.WriteLine("\t\t\t1) Edit");
                        Console.WriteLine("\t\t\t2) Cancel");
                        Console.WriteLine("\t\t\tX) Neither");
                        Console.Write("\t\t>> ");
                        string input = Console.ReadLine();
                        if (input == "1")
                        {
                            EditCheckup(checkupsForSelection);
                        }
                        else if (input == "2")
                        {
                            CancelCheckup(checkupsForSelection);
                        }
                        else if (input == "X" || input == "x")
                        {
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                break;
            }
            Console.WriteLine("\n");
        }

        public static void EditOperation(List<int> operationsForSelection)
        {
            Console.WriteLine("\n\t\tWhich operation would you like to edit? (ID) ");
            int operationId = CalendarFunctionalities.SelectFromTheList(operationsForSelection);
            Operation operation = termController.FindOperationById(operationId);
            CalendarFunctionalities.PrintOperation(operation);
            Console.WriteLine("\t\tAs of now, we only support editing times.");
            Console.Write("\t\tEnter new start time: (YYYY/MM/DD hh:mm:ss) ");
            operation.StartTime = MedicalRecordFunctionalities.EnterDate();
            Console.Write("\t\tEnter new end time: (YYYY/MM/DD hh:mm:ss) ");
            operation.EndTime = MedicalRecordFunctionalities.EnterDate();
            termController.EditTerm(operation);
            Console.WriteLine("\t\t\tSuccessfully edited operation!");
            Thread.Sleep(1500);
        }

        public static void CancelOperation(List<int> operationsForSelection)
        {
            Console.WriteLine("\n\t\tWhich operation would you like to cancel? (ID) ");
            int operationId = CalendarFunctionalities.SelectFromTheList(operationsForSelection);
            Operation operation = termController.FindOperationById(operationId);
            CalendarFunctionalities.PrintOperation(operation);
            Console.Write("\t\tAre you sure? (Y/N) ");
            string input = Console.ReadLine();
            if (string.Compare(input, "Y", StringComparison.OrdinalIgnoreCase) == 0)
            {
                termController.CancelTerm(operation);
                MedicalRecord mr = medicalRecordController.GetMedicalRecord(operation.Id);
                mr.RemoveOperation(operation.Id);
                medicalRecordController.UpdateMedicalRecord(mr);
                Console.WriteLine("\t\t\tSuccessfully canceled operation!");
            }
            else
            {
                Console.WriteLine("\t\t\tGoing back...");
            }

            Thread.Sleep(1500);
        }

        public static void EditCheckup(List<int> checkupsForSelection)
        {
            Console.WriteLine("\n\t\tWhich checkup would you like to edit? (ID) ");
            int checkupId = CalendarFunctionalities.SelectFromTheList(checkupsForSelection);
            Checkup checkup = termController.FindCheckupById(checkupId);
            CalendarFunctionalities.PrintCheckup(checkup);
            Console.WriteLine("\t\tAs of now, we only support editing times.");
            Console.Write("\t\tEnter new start time: (YYYY/MM/DD hh:mm:ss) ");
            checkup.StartTime = MedicalRecordFunctionalities.EnterDate();
            Console.Write("\t\tEnter new end time: (YYYY/MM/DD hh:mm:ss) ");
            checkup.EndTime = MedicalRecordFunctionalities.EnterDate();
            termController.EditTerm(checkup);
            Console.WriteLine("\t\t\tSuccessfully edited checkup!");
            Thread.Sleep(1500);
        }

        public static void CancelCheckup(List<int> checkupsForSelection)
        {
            Console.WriteLine("\n\t\tWhich checkup would you like to cancel? (ID) ");
            int checkupId = CalendarFunctionalities.SelectFromTheList(checkupsForSelection);
            Checkup checkup = termController.FindCheckupById(checkupId);
            CalendarFunctionalities.PrintCheckup(checkup);
            Console.Write("\t\tAre you sure? (Y/N) ");
            string input = Console.ReadLine();
            if (string.Compare(input, "Y", StringComparison.OrdinalIgnoreCase) == 0)
            {
                termController.CancelTerm(checkup);
                MedicalRecord mr = medicalRecordController.GetMedicalRecord(checkup.Id);
                mr.RemoveCheckup(checkup.Id);
                medicalRecordController.UpdateMedicalRecord(mr);
                Console.WriteLine("\t\t\tSuccessfully canceled checkup!");
            }
            else
            {
                Console.WriteLine("\t\t\tGoing back...");
            }

            Thread.Sleep(1500);
        }

    }
}
