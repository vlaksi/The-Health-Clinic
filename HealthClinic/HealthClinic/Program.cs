using Controller.DoctorContr;
using Controller.EmployeeContr;
using Controller.MedicalRecordContr;
using Controller.PatientContr;
using HealthClinic.Repository.UserRepo.DoctorRepo;
using Model.BusinessHours;
using Model.MedicalRecord;
using Model.Users;
using System;

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
                Name = "Nikola",
                Surname = "Kuzmanovic",
                Adress = "Vojvode Putnika 19, Novi Sad",
                Gender = "Male",
                Jmbg = "0612996800077",
                Birthday = new DateTime(1996, 12, 6),
                ParentsName = "Milija",
                PhoneNumber = "069-145-987",
                Accommodation = "At home",
                Email = "nikolak@gmail.com",
                Password= "12345678",
                MedicalRecordId = 1
            });
            patientController.PatientRegister(new PatientModel()
            {
                Name = "Stefan",
                Surname = "Jovanovic",
                Adress = "Koce Kolarova 14, Novi Sad",
                Gender = "Male",
                Jmbg = "0711996803071",
                Birthday = new DateTime(1990, 11, 7),
                ParentsName = "Jovica",
                PhoneNumber = "064-155-417",
                Accommodation = "At home",
                Email = "stefanj@gmail.com",
                Password = "12345678",
                MedicalRecordId = 2
            });
            patientController.PatientRegister(new PatientModel()
            {
                Name = "Milica",
                Surname = "Milovanovic",
                Adress = "Veternicka rampa bb, Novi Sad",
                Gender = "Male",
                Jmbg = "0706963801057",
                Birthday = new DateTime(1963, 6, 7),
                ParentsName = "Ilija",
                PhoneNumber = "061-292-674",
                Accommodation = "At home",
                Email = "stefanj@gmail.com",
                Password = "12345678",
                MedicalRecordId = 3
            });*/
            #endregion


            #region Creating doctors
            /*DoctorController doctorController = new DoctorController();
            doctorController.AddDoctor(new Doctor()
            {
                AbleToPrescribeTreatments = true,
                AbleToValidateMedicines = true,
                BusinessHours = new BusinessHoursModel()
                {
                    FromDate = new DateTime(2020, 6, 6),
                    ToDate = new DateTime(2020, 9, 6),
                    FromHour = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7,0,0), 
                    ToHour = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 15,0,0), 
                },
                Name = "Ivan",
                Surname = "Ivanovic",
                Birthday = new DateTime(1990, 1, 3),
                EmployeeType = EmployeeType.Doctor,
                Email = "ivanivanovic@gmail.com",
                Jmbg = "1112221112221",
                Password = "ivanivanovic",
                JobPosition = "Doctor",
                SpecialtyType = SpecialtyType.cardiovascular,
            });

            doctorController.AddDoctor(new Doctor()
            {
                AbleToPrescribeTreatments = false,
                AbleToValidateMedicines = false,
                BusinessHours = new BusinessHoursModel()
                {
                    FromDate = new DateTime(2020, 6, 6),
                    ToDate = new DateTime(2020, 9, 6),
                    FromHour = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 16, 0, 0),
                    ToHour = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 0, 0),
                },
                Name = "Petar",
                Surname = "Petrovic",
                Birthday = new DateTime(1980, 1, 3),
                EmployeeType = EmployeeType.Doctor,
                Email = "petarpetrovic@gmail.com",
                Jmbg = "2221112221112",
                Password = "petarpetrovic",
                JobPosition = "Doctor",
                SpecialtyType = SpecialtyType.general,
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
                    ToHour = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 15, 0, 0), //od 7 ujutru
                },
                Name = "Stefan",
                Surname = "Stefanovic",
                Birthday = new DateTime(1981, 1, 3),
                EmployeeType = EmployeeType.Doctor,
                Email = "stefanstefanovic@gmail.com",
                Jmbg = "3334443334443",
                Password = "stefanstefanovic",
                JobPosition = "Doctor",
                SpecialtyType = SpecialtyType.cardiovascular,
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
                    ToHour = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 15, 0, 0), //od 7 ujutru
                },
                Name = "Jovan",
                Surname = "Jovic",
                Birthday = new DateTime(1981, 1, 3),
                EmployeeType = EmployeeType.Doctor,
                Email = "jovanjovic@gmail.com",
                Jmbg = "4443334443334",
                Password = "jovanjovic",
                JobPosition = "Doctor",
                SpecialtyType = SpecialtyType.cardiovascular,
            });*/

            #endregion


            //Ostaviti, trebace kasnije da se nadograde
            #region Creating medical records

            /*MedicalRecordController medicalRecordController = new MedicalRecordController();
            medicalRecordController.CreateMedicalRecord(new MedicalRecord()
            {
                DoctorId = 1,
                PatientId = 1,
            });

            medicalRecordController.CreateMedicalRecord(new MedicalRecord()
            {
                DoctorId = 1,
                PatientId = 2
            });

            medicalRecordController.CreateMedicalRecord(new MedicalRecord()
            {
                DoctorId = 2,
                PatientId = 3
            });*/

            #endregion

            Console.ReadLine();
        }
    }
}
