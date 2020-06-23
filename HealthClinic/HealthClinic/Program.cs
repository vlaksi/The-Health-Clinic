using Controller.MedicalRecordContr;
using Controller.SurveyResponseContr;
using Model.MedicalRecord;
using Model.Medicine;
using Model.Survey;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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




            MedicalRecordController medicalRecordController = new MedicalRecordController();
            medicalRecordController.CreateMedicalRecord(new MedicalRecord()
            {
                Name = "Nikola",
                Surname = "Kuzmanovic",
                Address = "Vojvode Putnika 19, Novi Sad",
                Gender = "Male",
                Jmbg = "0612996800077",
                DateOfBirth = new DateTime(1996, 12, 6),
                ParentsName = "Milija",
                HealthInsuranceNumber = "0105048561",
                Phone = "069-145-987",
                HealthInsuranceCarrier = "Nikola Kuzmanovic",
            });

            medicalRecordController.CreateMedicalRecord(new MedicalRecord()
            {
                Name = "Stefan",
                Surname = "Jovanovic",
                Address = "Koce Kolarova 14, Novi Sad",
                Gender = "Male",
                Jmbg = "0711996803071",
                DateOfBirth = new DateTime(1990, 11, 7),
                ParentsName = "Jovica",
                HealthInsuranceNumber = "0414048511",
                Phone = "064-155-417",
                HealthInsuranceCarrier = "Stefan Jovanovic",
            });

            medicalRecordController.CreateMedicalRecord(new MedicalRecord()
            {
                Name = "Milica",
                Surname = "Milovanovic",
                Address = "Veternicka rampa bb, Novi Sad",
                Gender = "Male",
                Jmbg = "0706963801057",
                DateOfBirth = new DateTime(1963, 6, 7),
                ParentsName = "Ilija",
                HealthInsuranceNumber = "1451724048",
                Phone = "061-292-674",
                HealthInsuranceCarrier = "Milica Milovanovic",
            });

            medicalRecordController.CreateMedicalRecord(new MedicalRecord()
            {
                Name = "Mikica",
                Surname = "Mikic",
                Address = "Vase Stajica 26, Novi Sad",
                Gender = "Male",
                Jmbg = "0901010801057",
                DateOfBirth = new DateTime(2010, 1, 9),
                ParentsName = "Petar",
                HealthInsuranceNumber = "1451724048",
                Phone = "066-956-423",
                HealthInsuranceCarrier = "Petar Mikic",
            });

            Console.ReadLine();
        }
    }
}
