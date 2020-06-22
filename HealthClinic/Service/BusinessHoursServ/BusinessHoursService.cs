// File:    BusinessHoursService.cs
// Author:  Vaxi
// Created: Tuesday, May 19, 2020 11:40:42 PM
// Purpose: Definition of Class BusinessHoursService

using System;
using System.Collections.Generic;
using Model.BusinessHours;
using Model.Users;
using Repository.BusinessHoursRepo;

namespace Service.BusinessHoursServ
{
   public class BusinessHoursService
   {
      public BusinessHoursRepositoryFactory businessHoursRepositoryFactory;

      public void SetDoctorsBusinessHours(List<Doctor> doctors, BusinessHoursModel businessHours)
      {
         throw new NotImplementedException();
      }
      
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
      
      public void SaveAll(List<Doctor> doctors)
      {
         throw new NotImplementedException();
      }
      
   
   }
}