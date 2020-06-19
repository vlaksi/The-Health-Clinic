using Model.Users;
using System;

namespace HealthClinic
{
    class Program
    {
        static void Main(string[] args)
        {

            PatientModel pacijent = new PatientModel();
            pacijent.Name = "Vladislav";
            Console.WriteLine(pacijent.Name);
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
