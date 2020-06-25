// File:    UserFactoryService.cs
// Author:  Vaxi
// Created: Tuesday, April 21, 2020 4:35:09 PM
// Purpose: Definition of Class UserFactoryService

using Model.Users;
using System;
using System.Collections.Generic;

namespace Service.UserServ
{
    public class UserFactoryService
    {
        //public IUserRepositoryFacotory iUserRepositoryFacotory;

        public void ChooseTypeOfUser(RegisteredUser user)
        {
            var managerTest = new Manager();
            var patientTest = new PatientModel();
            var secretaryTest = new Secretary();
            var doctorTest = new Doctor();
            // ovako samo mogu da prosledim IsInstanceOf objekat za proveru

            /*if ((user.GetType()).IsInstanceOfType(managerTest))
            {
                iUserRepositoryFacotory = new ManagerFileRepositoryFactory();//TODO: I ovde moramo promeniti ako hocemo bazu podataka
            }else if ((user.GetType()).IsInstanceOfType(patientTest))
            {
                iUserRepositoryFacotory = new PatientFileRepositoryFactory();
            }
            else if ((user.GetType()).IsInstanceOfType(secretaryTest))
            {
                iUserRepositoryFacotory = new SecretaryFileRepositoryFactory();
            }else if ((user.GetType()).IsInstanceOfType(doctorTest))
            {
                iUserRepositoryFacotory = new DoctorFileRepositoryFactory();
            }*/

        }

        public RegisteredUser LogIn(String username, String password)
        {
            throw new NotImplementedException();
        }

        public int SurveyAboutDoctor(PatientModel patient, Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public int RateClinic(PatientModel patient)
        {
            throw new NotImplementedException();
        }

        public RegisteredUser SignUpUser()
        {
            throw new NotImplementedException();
        }

        public RegisteredUser DeleteUser()
        {
            throw new NotImplementedException();
        }

        public List<RegisteredUser> GetAllUsers()
        {
            throw new NotImplementedException();
        }


    }
}