// File:    ManagerController.cs
// Author:  Igorr
// Created: Wednesday, April 1, 2020 9:43:21 PM
// Purpose: Definition of Class ManagerController

using System;

namespace Controller
{
   public class ManagerController
   {
      public Doctor RegisterDoctor(Model.Users.Doctor doctor)
      {
         throw new NotImplementedException();
      }
      
      public Report GenerateReport()
      {
         throw new NotImplementedException();
      }
      
      public Model.BusinessHours.BusinessHours GiveDoctorHours(Doctor doctor)
      {
         throw new NotImplementedException();
      }
      
      public Service.ManagerService managerService;
   
   }
}