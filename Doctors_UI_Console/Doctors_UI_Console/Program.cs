using Controller.DoctorContr;
using Doctors_UI_Console.Functionalities;
using Model.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Doctors_UI_Console
{
    static class LoggedIn
    {
        public static Doctor doctorLoggedIn;
    }

    class Program
    {

        static void Main(string[] args)
        {
            //DoctorController doctorController = new DoctorController();
            //LoggedIn.doctorLoggedIn = doctorController.FindById(3);
            Login();

            bool showMenu = true;
            while (showMenu)
            {
                showMenu = ShowMainMenu();
            }

            Console.WriteLine("\n\tExiting....");
            Thread.Sleep(1500);
        }

        private static void Login()
        {
            DoctorController doctorController = new DoctorController();
            Doctor doctorLoggedIn;
            while (true)
            {
                Console.WriteLine("\n\t\t ~~~~~~~~~~~ LOGIN ~~~~~~~~~~~");
                Console.Write("\t\t  Email: ");
                string email = Console.ReadLine();
                Console.Write("\t\t  Password: ");
                string password = Console.ReadLine();
                
                if((doctorLoggedIn = doctorController.DoctorLogin(email, password)) == null)
                {
                    Console.WriteLine("\n\t\t\t\t *** Invalid credentials! ***");
                    Thread.Sleep(2000);
                    continue;
                }
                else
                {
                    LoggedIn.doctorLoggedIn = doctorLoggedIn;
                    Console.WriteLine("\n\t\t\t\t ~~~ Successful login! ~~~");
                    Thread.Sleep(1500);
                    break;
                }
            }
        }

        private static bool ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("\n  ~~~~ Welcome, " + LoggedIn.doctorLoggedIn.Name + "! ~~~~");
            Console.WriteLine("\t1) Search Patients");
            Console.WriteLine("\t2) Preview Medicines awaiting Approval");
            Console.WriteLine("\t3) Preview My Appointments");
            Console.WriteLine("\t4) Visit Blog");
            Console.WriteLine("\t5) Profile Settings");
            Console.WriteLine("\tEnter X to exit the application.");
            Console.Write("\n\t>> ");

            switch (Console.ReadLine().ToLower())
            {
                case "1":
                    PatientFunctionalities.SearchPatients();
                    return true;
                case "2":
                    MedicinesFunctionalities.PreviewMedicinesWaitingApproval();
                    return true;
                case "3":
                    UserFunctionalities.PreviewMyAppointments();
                    return true;
                case "4":
                    BlogFunctionalities.VisitBlog();
                    return true;
                case "5":
                    UserFunctionalities.VisitMyProfile();
                    return true;
                case "x":
                    return false;
                default:
                    return true;
            }
        }
    }
}
