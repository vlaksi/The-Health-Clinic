// File:    UserController.cs
// Author:  Vaxi
// Created: Tuesday, April 21, 2020 4:35:09 PM
// Purpose: Definition of Class UserController

using Model.Users;
using Service.UserServ;
using System;
using System.Collections.Generic;

namespace Controller.UserContr
{
   public class UserController
   {
      public UserFactoryService userFactoryService;

      public RegisteredUser LogIn(String username, String password)
      {
         throw new NotImplementedException();
      }
      
      public int aSurvey(PatientModel patient, Doctor doctor)
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