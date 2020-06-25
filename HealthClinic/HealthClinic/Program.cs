using Controller.BlogPostContr;
using Controller.EmployeeContr;
using Controller.MedicalRecordContr;
using Controller.SurveyResponseContr;
using Model.BlogPost;
using Model.MedicalRecord;
using Model.Medicine;
using Model.Survey;
using Model.Users;
using Repository.EmployeeRepo;
using Repository.UserRepo;
using Service.EmployeeServ;
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

            //Ostaviti, trebace kasnije da se nadograde
            #region Creating medical records
            /*
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
            });*/
            #endregion

            Console.ReadLine();
        }
    }
}
