using Controller.DoctorContr;
using Controller.MedicalRecordContr;
using Controller.PatientContr;
using Controller.RoomsContr;
using Controller.TermContr;
using Model.Calendar;
using Model.MedicalRecord;
using Model.Rooms;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Doctors_UI_Console.Functionalities
{
    public class CalendarFunctionalities
    {
        private static MedicalRecordController medicalRecordController = new MedicalRecordController();
        private static PatientController patientController = new PatientController();
        private static DoctorController doctorController = new DoctorController();
        private static RoomsController roomsController = new RoomsController();
        private static TermContextController termController = new TermContextController();

        public static void ScheduleOperation(MedicalRecord mr)
        {
            Console.Clear();
            PatientModel patient = patientController.FindById(mr.PatientId);
            List<Room> operatingRooms = roomsController.GetAllOperatingRooms();
            Operation operation = new Operation();

            Console.WriteLine("\n ~~~ Scheduling a operation for " + patient.Name + " " + patient.Surname + " ~~~");

            //Odabir tipa operacije
            Console.WriteLine("\tWhat is this operation's specialty type? ");
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
                    operation.SpecialtyType = SpecialtyType.cardiovascular;
                    break;
                }
                else if (input == "2")
                {
                    operation.SpecialtyType = SpecialtyType.dermatological;
                    break;
                }
                else if (input == "3")
                {
                    operation.SpecialtyType = SpecialtyType.oncological;
                    break;
                }
                else
                {
                    continue;
                }
            }

            List<Doctor> specialistsFound = doctorController.GetAllSpecialistsBySpecialty(operation.SpecialtyType);
            if (specialistsFound.Count == 0)
            {
                Console.WriteLine("\t\tThere are no specialists for this specialty...");
                return;
            }

            //Odabir doktora
            while (true)
            {
                if (LoggedIn.doctorLoggedIn.SpecialtyType == operation.SpecialtyType)
                {
                    Console.Write("\t\tAre you going to be the specialist for this operation? (Y/N) ");
                    string input = Console.ReadLine();
                    if (string.Compare(input, "Y", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        operation.SpecialistId = LoggedIn.doctorLoggedIn.Id;
                        break;
                    }
                }
                while (true)
                {
                    Console.WriteLine("\t\tSelect another specialist for this operation: ");
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
                        operation.SpecialistId = doctor.Id;
                        Console.WriteLine("\tSuccessfully selected doctor " + doctor.Name + " " + doctor.Surname + " from the list!");
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                break;
            }

            Console.Write("\tSelect start time for this operation: (YYYY/MM/DD hh:mm:ss) ");
            operation.StartTime = MedicalRecordFunctionalities.EnterDate();
            Console.Write("\tSelect end time for this operation: (YYYY/MM/DD hh:mm:ss) ");
            operation.EndTime = MedicalRecordFunctionalities.EnterDate();
            Console.WriteLine("\n");

            Doctor checkDoctor = doctorController.FindById(operation.SpecialistId);
            if (!doctorController.IsDoctorFree(checkDoctor, operation.StartTime, operation.EndTime))
            {
                Console.WriteLine("\t\tSelected specialist is not free in this period!");
                Thread.Sleep(2000);
                return;
            }

            // Odabir sobe
            while (true)
            {

                foreach (Room room in operatingRooms)
                {
                    Console.WriteLine("\t\t\t- Operating room " + room.NumberOfRoom + ", ID: " + room.RoomId);
                }
                Console.Write("\t\tPick a room: (ID) ");
                string roomId = Console.ReadLine();

                if (Int32.TryParse(roomId, out int id))
                {
                    if (!operatingRooms.Any(room => room.RoomId == id))
                    {
                        Console.WriteLine("\tPlease select a choice from the list.");
                        continue;
                    }
                    Room selectedRoom = operatingRooms.Where(room => room.RoomId == id).FirstOrDefault();
                    operation.OperatingRoomId = selectedRoom.RoomId;
                    Console.WriteLine("\tSuccessfully selected room " + selectedRoom.NumberOfRoom + " from the list!");
                    break;
                }
            }

            operation.MedicalRecordId = mr.MedicalRecordId;
            termController.ScheduleTerm(operation);
            mr.AddOperation(operation.Id);
            medicalRecordController.UpdateMedicalRecord(mr);
            Console.WriteLine("\t\tSuccessfully scheduled operation for " + patient.Name + " " + patient.Surname + "!\n");
            Thread.Sleep(3000);
        }

        public static void ScheduleCheckup(MedicalRecord mr)
        {
            Console.Clear();
            PatientModel patient = patientController.FindById(mr.PatientId);
            List<Room> ordinations = roomsController.GetAllOrdinations();
            Checkup checkup = new Checkup();

            Console.WriteLine("\n ~~~ Scheduling a checkup for " + patient.Name + " " + patient.Surname + " ~~~");

            //Odabir tipa operacije
            Console.WriteLine("\tWhat is this checkup's specialty type? ");
            while (true)
            {
                Console.WriteLine("\tSpecialties we have: ");
                Console.WriteLine("\t\t1) General");
                Console.WriteLine("\t\t2) Cardiovascular");
                Console.WriteLine("\t\t3) Dermatological");
                Console.WriteLine("\t\t4) Oncological");
                Console.Write("\tWhat kind of specialist do you need? ");
                string input = Console.ReadLine();
                if (input == "2")
                {
                    checkup.SpecialtyType = SpecialtyType.cardiovascular;
                    break;
                }
                else if (input == "1")
                {
                    checkup.SpecialtyType = SpecialtyType.general;
                    break;
                }
                else if (input == "3")
                {
                    checkup.SpecialtyType = SpecialtyType.dermatological;
                    break;
                }
                else if (input == "4")
                {
                    checkup.SpecialtyType = SpecialtyType.oncological;
                    break;
                }
                else
                {
                    continue;
                }
            }

            List<Doctor> doctorsFound = doctorController.GetAllSpecialistsBySpecialty(checkup.SpecialtyType);

            if (doctorsFound.Count == 0)
            {
                Console.WriteLine("\t\tThere are no doctors for this specialty...");
                return;
            }

            //Odabir doktora
            while (true)
            {
                if (LoggedIn.doctorLoggedIn.SpecialtyType == checkup.SpecialtyType)
                {
                    Console.Write("\t\tAre you going to be the doctor for this checkup? (Y/N) ");
                    string input = Console.ReadLine();
                    if (string.Compare(input, "Y", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        checkup.DoctorId = LoggedIn.doctorLoggedIn.Id;
                        break;
                    }
                }
                while (true)
                {
                    Console.WriteLine("\t\tSelect doctor for this checkup: ");
                    foreach (Doctor doc in doctorsFound)
                    {
                        Console.WriteLine("\t\tName: " + doc.Name + " " + doc.Surname);
                        Console.WriteLine("\t\tId: " + doc.Id);
                    }

                    Console.Write("\tSelect a doctor: (ID) ");
                    string docId = Console.ReadLine();
                    if (Int32.TryParse(docId, out int id))
                    {
                        if (!doctorsFound.Any(spec => spec.Id == id))
                        {
                            Console.WriteLine("\tPlease select a doctor from the list.");
                            continue;
                        }
                        Doctor doctor = doctorsFound.Where(spec => spec.Id == id).FirstOrDefault();
                        checkup.DoctorId = doctor.Id;
                        Console.WriteLine("\tSuccessfully selected doctor " + doctor.Name + " " + doctor.Surname + " from the list!");
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                break;
            }

            Console.Write("\tSelect start time for this checkup: (YYYY/MM/DD hh:mm:ss) ");
            checkup.StartTime = MedicalRecordFunctionalities.EnterDate();
            Console.Write("\tSelect end time for this checkup: (YYYY/MM/DD hh:mm:ss) ");
            checkup.EndTime = MedicalRecordFunctionalities.EnterDate();
            Console.WriteLine("\n");

            Doctor checkDoctor = doctorController.FindById(checkup.DoctorId);
            if (!doctorController.IsDoctorFree(checkDoctor, checkup.StartTime, checkup.EndTime))
            {
                Console.WriteLine("\t\tSelected doctor is not free in this period!");
                Thread.Sleep(2000);
                return;
            }

            // Odabir sobe
            while (true)
            {

                foreach (Room room in ordinations)
                {
                    Console.WriteLine("\t\t\t- Ordination " + room.NumberOfRoom + ", ID: " + room.RoomId);
                }
                Console.Write("\t\tPick a room: (ID) ");
                string roomId = Console.ReadLine();

                if (Int32.TryParse(roomId, out int id))
                {
                    if (!ordinations.Any(room => room.RoomId == id))
                    {
                        Console.WriteLine("\tPlease select a choice from the list.");
                        continue;
                    }
                    Room selectedRoom = ordinations.Where(room => room.RoomId == id).FirstOrDefault();
                    checkup.OrdinationId = selectedRoom.RoomId;
                    Console.WriteLine("\tSuccessfully selected room " + selectedRoom.NumberOfRoom + " from the list!");
                    break;
                }
            }

            checkup.MedicalRecordId = mr.MedicalRecordId;
            termController.ScheduleTerm(checkup);
            mr.AddCheckup(checkup.Id);
            medicalRecordController.UpdateMedicalRecord(mr);
            Console.WriteLine("\t\tSuccessfully scheduled checkup for " + patient.Name + " " + patient.Surname + "!\n");
            Thread.Sleep(3000);
        }

        public static void PreviewTerms(MedicalRecord mr)
        {
            while (true)
            {
                while (true)
                {
                    List<Operation> operations = termController.getAllOperationsForPatient(mr.MedicalRecordId);
                    Console.WriteLine("\n\t~~~ Operations ~~~");
                    if (operations.Count == 0)
                    {
                        Console.WriteLine("\t\t\tNone.");
                        Console.Write("\t\tPress any key to continue to checkups.\n");
                        Console.ReadLine();
                        break;
                    }
                    else
                    {
                        foreach (Operation operation in operations)
                        {
                            PrintOperation(operation);
                        }

                        Console.WriteLine("\t\tDo you want to edit or cancel any operation? ");
                        Console.WriteLine("\t\t\t1) Edit");
                        Console.WriteLine("\t\t\t2) Cancel");
                        Console.WriteLine("\t\t\tX) Neither");
                        Console.Write("\t\t>> ");
                        string input = Console.ReadLine();
                        if (input == "1")
                        {
                            EditOperation(mr);
                        }
                        else if (input == "2")
                        {
                            CancelOperation(mr);
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
                    List<Checkup> checkups = termController.getAllCheckupsForPatient(mr.MedicalRecordId);
                    Console.WriteLine("\n\t~~~ Checkups ~~~");
                    if (checkups.Count == 0)
                    {
                        Console.WriteLine("\t\t\tNone.");
                        Console.Write("\t\tPress any key to exit preview.");
                        Console.ReadLine();
                        return;
                    }
                    else
                    {
                        foreach (Checkup checkup in checkups)
                        {
                            PrintCheckup(checkup);
                        }

                        Console.WriteLine("\t\tDo you want to edit or cancel any checkup? ");
                        Console.WriteLine("\t\t\t1) Edit");
                        Console.WriteLine("\t\t\t2) Cancel");
                        Console.WriteLine("\t\t\tX) Neither");
                        Console.Write("\t\t>> ");
                        string input = Console.ReadLine();
                        if (input == "1")
                        {
                            EditCheckup(mr);
                        }
                        else if (input == "2")
                        {
                            CancelCheckup(mr);
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
        public static void EditOperation(MedicalRecord mr)
        {
            Console.WriteLine("\n\t\tWhich operation would you like to edit? (ID) ");
            int operationId = SelectFromTheList(mr.Operations);
            Operation operation = termController.FindOperationById(operationId);
            PrintOperation(operation);
            Console.WriteLine("\t\tAs of now, we only support editing times.");
            Console.Write("\t\tEnter new start time: (YYYY/MM/DD hh:mm:ss) ");
            operation.StartTime = MedicalRecordFunctionalities.EnterDate();
            Console.Write("\t\tEnter new end time: (YYYY/MM/DD hh:mm:ss) ");
            operation.EndTime = MedicalRecordFunctionalities.EnterDate();
            termController.EditTerm(operation);
            Console.WriteLine("\t\t\tSuccessfully edited operation!");
            Thread.Sleep(1500);
        }

        public static void EditCheckup(MedicalRecord mr)
        {
            Console.WriteLine("\n\t\tWhich checkup would you like to edit? (ID) ");
            int checkupId = SelectFromTheList(mr.Checkups);
            Checkup checkup = termController.FindCheckupById(checkupId);
            PrintCheckup(checkup);
            Console.WriteLine("\t\tAs of now, we only support editing times.");
            Console.Write("\t\tEnter new start time: (YYYY/MM/DD hh:mm:ss) ");
            checkup.StartTime = MedicalRecordFunctionalities.EnterDate();
            Console.Write("\t\tEnter new end time: (YYYY/MM/DD hh:mm:ss) ");
            checkup.EndTime = MedicalRecordFunctionalities.EnterDate();
            termController.EditTerm(checkup);
            Console.WriteLine("\t\t\tSuccessfully edited checkup!");
            Thread.Sleep(1500);
        }

        public static void CancelCheckup(MedicalRecord mr)
        {
            Console.WriteLine("\n\t\tWhich checkup would you like to cancel? (ID) ");
            int checkupId = SelectFromTheList(mr.Checkups);
            Checkup checkup = termController.FindCheckupById(checkupId);
            PrintCheckup(checkup);
            Console.Write("\t\tAre you sure? (Y/N) ");
            string input = Console.ReadLine();
            if (string.Compare(input, "Y", StringComparison.OrdinalIgnoreCase) == 0)
            {
                termController.CancelTerm(checkup);
                mr.Checkups.Remove(checkup.Id);
                medicalRecordController.UpdateMedicalRecord(mr);
                Console.WriteLine("\t\t\tSuccessfully canceled checkup!");
            }
            else
            {
                Console.WriteLine("\t\t\tGoing back...");
            }

            Thread.Sleep(1500);
        }

        public static void CancelOperation(MedicalRecord mr)
        {
            Console.WriteLine("\n\t\tWhich operation would you like to cancel? (ID) ");
            int operationId = SelectFromTheList(mr.Operations);
            Operation operation = termController.FindOperationById(operationId);
            PrintOperation(operation);
            Console.Write("\t\tAre you sure? (Y/N) ");
            string input = Console.ReadLine();
            if (string.Compare(input, "Y", StringComparison.OrdinalIgnoreCase) == 0)
            {
                termController.CancelTerm(operation);
                mr.Operations.Remove(operation.Id);
                medicalRecordController.UpdateMedicalRecord(mr);
                Console.WriteLine("\t\t\tSuccessfully canceled operation!");
            }
            else
            {
                Console.WriteLine("\t\t\tGoing back...");
            }

            Thread.Sleep(1500);
        }

        #region Helpers
        public static void PrintOperation(Operation operation)
        {
            MedicalRecord mr = medicalRecordController.GetMedicalRecord(operation.MedicalRecordId);
            PatientModel patient = patientController.FindById(mr.PatientId);
            Doctor doctor = doctorController.FindById(operation.SpecialistId);
            Room room = roomsController.findById(operation.OperatingRoomId);
            Console.WriteLine("\t~~~ Operation with ID " + operation.Id + " ~~~");
            Console.WriteLine("\t\tPatient: " + patient.Name + " " + patient.Surname);
            Console.WriteLine("\t\tDoctor: " + doctor.Name + " " + doctor.Surname);
            Console.WriteLine("\t\tStart time: " + operation.StartTime);
            Console.WriteLine("\t\tEnd time: " + operation.EndTime);
            Console.WriteLine("\t\tOperating room: " + room.NumberOfRoom);
            Console.WriteLine("\t\tType of operation: " + operation.SpecialtyType.ToFriendlyString() + "\n");
        }

        public static void PrintCheckup(Checkup checkup)
        {
            MedicalRecord mr = medicalRecordController.GetMedicalRecord(checkup.MedicalRecordId);
            PatientModel patient = patientController.FindById(mr.PatientId);
            Doctor doctor = doctorController.FindById(checkup.DoctorId);
            Room room = roomsController.findById(checkup.OrdinationId);
            Console.WriteLine("\t~~~ Checkup with ID " + checkup.Id + " ~~~");
            Console.WriteLine("\t\tPatient: " + patient.Name + " " + patient.Surname);
            Console.WriteLine("\t\tDoctor: " + doctor.Name + " " + doctor.Surname);
            Console.WriteLine("\t\tStart time: " + checkup.StartTime);
            Console.WriteLine("\t\tEnd time: " + checkup.EndTime);
            Console.WriteLine("\t\tOrdination: " + room.NumberOfRoom);
            Console.WriteLine("\t\tType of checkup: " + checkup.SpecialtyType.ToFriendlyString() + "\n");
        }

        public static int SelectFromTheList(List<int> choices)
        {
            int result = -1;

            while (true)
            {
                foreach (int choice in choices)
                {
                    Console.WriteLine("\t\t\t ID: " + choice);
                }
                Console.Write("\t\tYour choice: ");
                string input = Console.ReadLine();

                if (Int32.TryParse(input, out int id))
                {
                    if (!choices.Contains(id))
                    {
                        Console.WriteLine("\t\t\tPlease select a choice from the list.");
                        continue;
                    }

                    result = choices.Where(selected => selected == id).FirstOrDefault();
                    break;
                }
                else
                {
                    Console.WriteLine("\t\tPlease enter a valid id!");
                }
            }

            return result;
        }
        #endregion
    }
}
