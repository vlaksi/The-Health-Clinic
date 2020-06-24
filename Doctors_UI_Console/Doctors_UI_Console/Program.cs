using Doctors_UI_Console.Functionalities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Doctors_UI_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;

            while (showMenu)
            {
                showMenu = ShowMainMenu();
            }

            Console.WriteLine("\tExiting....");
            System.Threading.Thread.Sleep(1200);
        }

        private static bool ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("\n  ~~~~ Welcome, doctor! ~~~~");
            Console.WriteLine("\t1) Search Patients");
            Console.WriteLine("\t2) Preview Terms");
            Console.WriteLine("\t3) Preview Medicines awaiting Approval");
            Console.WriteLine("\t4) Schedule an Appointment");
            Console.WriteLine("\t5) Visit Blog");
            Console.WriteLine("\tEnter X to exit the application.");
            Console.Write("\n\t>> ");

            switch (Console.ReadLine().ToLower())
            {
                case "1":
                    PatientFunctionalities.SearchPatients();
                    return true;
                case "2":
                    return true;
                case "3":
                    MedicinesFunctionalities.PreviewMedicinesWaitingApproval();
                    return true;
                case "4":
                    return true;
                case "5":
                    BlogFunctionalities.VisitBlog();
                    return true;
                case "x":
                    return false;
                default:
                    return true;
            }
        }
    }
}
