// File:    ManagerController.cs
// Author:  Vaxi
// Created: Wednesday, April 1, 2020 9:43:21 PM
// Purpose: Definition of Class ManagerController

using System;

namespace Controller.ManagerContr
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
      
      public Service.UserServ.ManagerService managerService;
   
   }
}