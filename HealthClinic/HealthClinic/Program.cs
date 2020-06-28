
﻿using Controller.DoctorContr;
using Controller.EmployeeContr;
using Controller.MedicalRecordContr;
using Controller.MedicineContr;
using Controller.PatientContr;
using HealthClinic.Repository.UserRepo.DoctorRepo;
using Model.BusinessHours;
using Model.MedicalRecord;
using Model.Medicine;
using Model.Users;
using System;
using System.Collections.Generic;

namespace HealthClinic
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ostaviti, trebace kasnije da se nadograde
            #region Creating blog posts
            /*BlogPostController bc = new BlogPostController();
            bc.CreateBlogPost(new BlogPostModel()
            {
                Title = "Alcohol, Coffee, and Holiday Excess: A Hepatology Perspective",
                Type = "General Health",
                Content = "With the beginning of the year, comes the usual rush of consults to my office for abnormal liver tests. Perhaps it’s a coincidence, but my suspicion is that these visits are related to the many holiday parties and their "
                + "associated excessive drink and dietary indiscretions—which brings me to the topic of alcohol. How much alcohol is too much ? This question has long been debated by researchers(and home microbrewers).\n\nUntil recently,"
                + "the standard answer has been 14 drinks per week for men and 7 drinks per week for women.In reality, this recommendation is likely only acceptable to those with BMIs of less than 25 and no other medical comorbidities.",
                DatePublished = DateTime.Now,
                Doctor = 1 
                //Comment = new List<Comment>()
            });

            bc.CreateBlogPost(new BlogPostModel()
            {
                Title = "Eat the Right Foods This Winter",
                Type = "Food",
                Content = "Did you know what you eat plays an important role in staying healthy during cold and flu season?\n"
                + "Protein is the building block of immune cells. A diet lacking in protein can seriously hamper your immune function. Most adults need at least 50 grams of quality protein per day, or a palm-sized portion per meal. Try to incorporate quality protein at each meal, like eggs for breakfast, turkey chili for lunch, and fish or chicken for dinner.\n\n"
                + "Make sure your meals have COLOR. As a rule of thumb, the more colorful foods are, the healthier they are – unless you’re eating a bag of Skittles. Deep, rich colors indicate micronutrients and antioxidants, which your body needs for protection and recovery from illness.",
                DatePublished = DateTime.Now.AddDays(-15),
                Doctor = 2
                //Comment = new List<Comment>()
            });

            bc.CreateBlogPost(new BlogPostModel()
            {
                Title = "Get Your Flu Shot, Not the Flu",
                Type = "Viruses",
                Content = "It seems like fall has just begun, but we’re already talking about the flu virus.\n"
                + "It is difficult to predict what type of flu will be prominent each year. Flu seasons are unpredictable for a variety of reasons: the timing, severity, and length of the season usually vary from one year to another.\n"
                + "Flu season typically peaks between December and February, but physicians are already starting to see some of the first cases.",
                DatePublished = DateTime.Now.AddDays(-5),
                Doctor = 3
                //Comment = new List<Comment>()
            });*/
            #endregion


            #region Creating patients
            /*PatientController patientController = new PatientController();
            patientController.PatientRegister(new PatientModel() {
                Name = "Milos",
                Surname = "Krickovic",
                Adress = "Valentina Vodnika 14, Novi Sad",
                Gender = "Male",
                Jmbg = "1112221112221",
                Birthday = new DateTime(1996, 12, 6),
                ParentsName = "Milan",
                PhoneNumber = "069-145-987",
                Email = "mikikriki@gmail.com",
                Password= "12345678",
                MedicalRecordId = 1
            });
            patientController.PatientRegister(new PatientModel()
            {
                Name = "Jovanka",
                Surname = "Broz",
                Adress = "Nepoznata ulica bb, Novi Sad",
                Gender = "Female",
                Jmbg = "2221112221112",
                Birthday = new DateTime(1990, 11, 7),
                ParentsName = "NN",
                PhoneNumber = "064-155-417",
                Email = "jovankabroz@gmail.com",
                Password = "12345678",
                MedicalRecordId = 2
            });
            patientController.PatientRegister(new PatientModel()
            {
                Name = "Milica",
                Surname = "Micic",
                Adress = "Koste Racina bb, Novi Sad",
                Gender = "Female",
                Jmbg = "2223332223332",
                Birthday = new DateTime(1963, 6, 7),
                ParentsName = "Ilija",
                PhoneNumber = "061-292-674",
                Email = "milicamicic@gmail.com",
                Password = "12345678",
                MedicalRecordId = 3
            });
            patientController.PatientRegister(new PatientModel()
            {
                Name = "Ivan",
                Surname = "Ivanovic",
                Adress = "Valentina Vodnika 14, Novi Sad",
                Gender = "Male",
                Jmbg = "333222333222",
                Birthday = new DateTime(1996, 12, 6),
                ParentsName = "Milan",
                PhoneNumber = "069-145-987",
                Email = "ivanivanovic@gmail.com",
                Password = "12345678",
                MedicalRecordId = 4
            });
            patientController.PatientRegister(new PatientModel()
            {
                Name = "Stevica",
                Surname = "Cvarkov",
                Adress = "Nepoznata ulica bb, Novi Sad",
                Gender = "Male",
                Jmbg = "3334443334443",
                Birthday = new DateTime(1990, 11, 7),
                ParentsName = "Jovan",
                PhoneNumber = "064-155-417",
                Email = "stevicacvarkov@gmail.com",
                Password = "12345678",
                MedicalRecordId = 5
            });
            patientController.PatientRegister(new PatientModel()
            {
                Name = "Jagoda",
                Surname = "Markov",
                Adress = "Koste Racina bb, Novi Sad",
                Gender = "Female",
                Jmbg = "4443334443334",
                Birthday = new DateTime(1963, 6, 7),
                ParentsName = "Ilija",
                PhoneNumber = "061-292-674",
                Email = "jagodamarkov@gmail.com",
                Password = "12345678",
                MedicalRecordId = 6
            });
            patientController.PatientRegister(new PatientModel()
            {
                Name = "Velinko",
                Surname = "Popara",
                Adress = "Valentina Vodnika 11, Novi Sad",
                Gender = "Male",
                Jmbg = "4445554445554",
                Birthday = new DateTime(1996, 12, 6),
                ParentsName = "Milan",
                PhoneNumber = "069-145-987",
                Email = "mikikriki@gmail.com",
                Password = "12345678",
                MedicalRecordId = 7
            });
            patientController.PatientRegister(new PatientModel()
            {
                Name = "Stevo",
                Surname = "Visekruna",
                Adress = "Nepoznata ulica bb, Novi Sad",
                Gender = "Male",
                Jmbg = "5554445554445",
                Birthday = new DateTime(1990, 11, 7),
                ParentsName = "NN",
                PhoneNumber = "064-155-417",
                Email = "visekruna@gmail.com",
                Password = "12345678",
                MedicalRecordId = 8
            });
            patientController.PatientRegister(new PatientModel()
            {
                Name = "Ninoslav",
                Surname = "Loncar",
                Adress = "Koste Racina bb, Novi Sad",
                Gender = "Male",
                Jmbg = "6665556665556",
                Birthday = new DateTime(1963, 6, 7),
                ParentsName = "Ilija",
                PhoneNumber = "061-292-674",
                Email = "loncar@gmail.com",
                Password = "12345678",
                MedicalRecordId = 9
            });
            patientController.PatientRegister(new PatientModel()
            {
                Name = "Milan",
                Surname = "Stupar",
                Adress = "Koste Racina bb, Novi Sad",
                Gender = "Male",
                Jmbg = "8889998889998",
                Birthday = new DateTime(1963, 6, 7),
                ParentsName = "Ilija",
                PhoneNumber = "061-292-674",
                Email = "stupar@gmail.com",
                Password = "12345678",
                MedicalRecordId = 10
            });*/
            #endregion


            #region Creating doctors
            /*DoctorController doctorController = new DoctorController();
            doctorController.AddDoctor(new Doctor()
            {
                AbleToPrescribeTreatments = true,
                AbleToValidateMedicines = false,
                BusinessHours = new BusinessHoursModel()
                {
                    FromDate = new DateTime(2020, 6, 6),
                    ToDate = new DateTime(2020, 9, 6),
                    FromHour = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7,0,0), 
                    ToHour = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 15,0,0), 
                },
                Name = "Nemanja",
                Surname = "Vidic",
                Birthday = new DateTime(1990, 1, 3),
                EmployeeType = EmployeeType.Doctor,
                Email = "nemanjavidic@gmail.com",
                Jmbg = "1231231231231",
                Password = "nemanjavidic",
                JobPosition = "Doctor",
                SpecialtyType = SpecialtyType.otolaryngological,
            });

            doctorController.AddDoctor(new Doctor()
            {
                AbleToPrescribeTreatments = true,
                AbleToValidateMedicines = false,
                BusinessHours = new BusinessHoursModel()
                {
                    FromDate = new DateTime(2020, 6, 6),
                    ToDate = new DateTime(2020, 9, 6),
                    FromHour = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 15, 0, 0),
                    ToHour = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 0, 0),
                },
                Name = "Irina",
                Surname = "Ivkovic",
                Birthday = new DateTime(1980, 1, 3),
                EmployeeType = EmployeeType.Doctor,
                Email = "irinaivkovic@gmail.com",
                Jmbg = "3213213213211",
                Password = "irinaivkovic",
                JobPosition = "Doctor",
                SpecialtyType = SpecialtyType.oncological,
            });

            doctorController.AddDoctor(new Doctor()
            {
                AbleToPrescribeTreatments = true,
                AbleToValidateMedicines = true,
                BusinessHours = new BusinessHoursModel()
                {
                    FromDate = new DateTime(2020, 6, 6),
                    ToDate = new DateTime(2020, 9, 6),
                    FromHour = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 0, 0), //od 7 ujutru
                    ToHour = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 16, 0, 0), //od 7 ujutru
                },
                Name = "Jelena",
                Surname = "Djokovic",
                Birthday = new DateTime(1981, 1, 3),
                EmployeeType = EmployeeType.Doctor,
                Email = "jelenadjokovic@gmail.com",
                Jmbg = "9997779997779",
                Password = "jelenadjokovic",
                JobPosition = "Doctor",
                SpecialtyType = SpecialtyType.neurological,
            });

            doctorController.AddDoctor(new Doctor()
            {
                AbleToPrescribeTreatments = false,
                AbleToValidateMedicines = false,
                BusinessHours = new BusinessHoursModel()
                {
                    FromDate = new DateTime(2020, 6, 6),
                    ToDate = new DateTime(2020, 9, 6),
                    FromHour = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 0, 0), //od 7 ujutru
                    ToHour = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 15, 0, 0), //od 7 ujutru
                },
                Name = "Savo",
                Surname = "Krstic",
                Birthday = new DateTime(1981, 1, 3),
                EmployeeType = EmployeeType.Doctor,
                Email = "savokrstic@gmail.com",
                Jmbg = "6665556665556",
                Password = "savokrstic",
                JobPosition = "Doctor",
                SpecialtyType = SpecialtyType.general,
            });

            doctorController.AddDoctor(new Doctor()
            {
                AbleToPrescribeTreatments = true,
                AbleToValidateMedicines = false,
                BusinessHours = new BusinessHoursModel()
                {
                    FromDate = new DateTime(2020, 6, 6),
                    ToDate = new DateTime(2020, 9, 6),
                    FromHour = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 0, 0), //od 7 ujutru
                    ToHour = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 15, 0, 0), //od 7 ujutru
                },
                Name = "Vlado",
                Surname = "Dincic",
                Birthday = new DateTime(1981, 1, 3),
                EmployeeType = EmployeeType.Doctor,
                Email = "vladodincic@gmail.com",
                Jmbg = "4343434343431",
                Password = "vladodincic",
                JobPosition = "Doctor",
                SpecialtyType = SpecialtyType.general,
            });
            */
            #endregion

            //Ostaviti, trebace kasnije da se nadograde
            #region Creating medical records
            /*
            MedicalRecordController medicalRecordController = new MedicalRecordController();
            medicalRecordController.CreateMedicalRecord(new MedicalRecord()
            {
                DoctorId = 1,
                PatientId = 1,
            });


            medicalRecordController.CreateMedicalRecord(new MedicalRecord()
            {
                DoctorId = 2,
                PatientId = 2,
            });

            medicalRecordController.CreateMedicalRecord(new MedicalRecord()
            {
                DoctorId = 8,
                PatientId = 3
            });

            medicalRecordController.CreateMedicalRecord(new MedicalRecord()
            {
                DoctorId = 9,
                PatientId = 4
            });
            medicalRecordController.CreateMedicalRecord(new MedicalRecord()
            {
                DoctorId = 8,
                PatientId = 5
            });
            medicalRecordController.CreateMedicalRecord(new MedicalRecord()
            {
                DoctorId = 2,
                PatientId = 6
            });
            medicalRecordController.CreateMedicalRecord(new MedicalRecord()
            {
                DoctorId = 2,
                PatientId = 7
            });
            medicalRecordController.CreateMedicalRecord(new MedicalRecord()
            {
                DoctorId = 2,
                PatientId = 8
            });
            medicalRecordController.CreateMedicalRecord(new MedicalRecord()
            {
                DoctorId = 8,
                PatientId = 9
            });
            medicalRecordController.CreateMedicalRecord(new MedicalRecord()
            {
                DoctorId = 9,
                PatientId = 10
            });
            */
            #endregion

            Console.ReadLine();
        }
    }
}
