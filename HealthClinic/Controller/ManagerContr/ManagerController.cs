// File:    ManagerController.cs
// Author:  Vaxi
// Created: Wednesday, April 1, 2020 9:43:21 PM
// Purpose: Definition of Class ManagerController

using Model.BusinessHours;
using Model.Calendar;
using Model.Users;
using Service.UserServ;
using System;

namespace Controller.ManagerContr
{
   public class ManagerController
   {
      public ManagerService managerService;

      public Doctor RegisterDoctor(Doctor doctor)
      {
         throw new NotImplementedException();
      }
      
      public Report GenerateReport()
      {
         throw new NotImplementedException();
      }
      
      public BusinessHoursModel GiveDoctorHours(Doctor doctor)
      {
         throw new NotImplementedException();
      }
      
   
   }
}