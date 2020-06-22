// File:    BusinessHoursController.cs
// Author:  Vaxi
// Created: Sunday, May 3, 2020 8:58:30 PM
// Purpose: Definition of Class BusinessHoursController

using Model.Users;
using Model.BusinessHours;
using System;
using Service.BusinessHoursServ;

namespace Controller.BusinessHoursContr
{
   public class BusinessHoursController
   {
      public BusinessHoursService businessHoursService;

      public int GetBusinessHours(Doctor doctor, DateTime date)
      {
         throw new NotImplementedException();
      }
      
      public DateTime GetBuisinessDate(Doctor doctor)
      {
         throw new NotImplementedException();
      }
      
      public BusinessHoursModel AddBusinessHours()
      {
         throw new NotImplementedException();
      }
      
      public void DelteBusinessHours()
      {
         throw new NotImplementedException();
      }
      
   
   }
}