// File:    UserFactoryService.cs
// Author:  Filip Zukovic
// Created: Tuesday, April 21, 2020 4:35:09 PM
// Purpose: Definition of Class UserFactoryService

using System;

namespace Service
{
   public class UserFactoryService
   {
      public void ChooseTypeOfUser(User user)
      {
         if(user.IsInstanceOf(Manager))
            iUserRepository = new ManagerRepository();
         else if(user.IsInstanceOf(Patient))
            iUserRepository = new PatientRepository();
         else if(user.IsInstanceOf(Secretary))
            iUserRepository = new SecretaryRepository();
         else if(user.IsInstanceOf(Doctor))
            iUserRepository = new DoctorRepository();
      }
      
      public Model.Users.RegisteredUser LogIn(String username, String password)
      {
         throw new NotImplementedException();
      }
      
      public int SurveyAboutDoctor(Patient patient, Doctor doctor)
      {
         throw new NotImplementedException();
      }
      
      public int RateClinic(Patient patient)
      {
         throw new NotImplementedException();
      }
      
      public Model.Users.RegisteredUser SignUpUser()
      {
         throw new NotImplementedException();
      }
      
      public Model.Users.RegisteredUser DeleteUser()
      {
         throw new NotImplementedException();
      }
      
      public List<RegisteredUser> GetAllUsers()
      {
         throw new NotImplementedException();
      }
      
      public Repository.IUserRepositoryFacotory iUserRepositoryFacotory;
   
   }
}