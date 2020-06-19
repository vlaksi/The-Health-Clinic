// File:    UserController.cs
// Author:  Igorr
// Created: Tuesday, April 21, 2020 4:35:09 PM
// Purpose: Definition of Class UserController

using System;

namespace Controller
{
   public class UserController
   {
      public Model.Users.RegisteredUser LogIn(String username, String password)
      {
         throw new NotImplementedException();
      }
      
      public int aSurvey(Patient patient, Doctor doctor)
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
      
      public Service.UserFactoryService userFactoryService;
   
   }
}