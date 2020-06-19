// File:    BusinessHoursService.cs
// Author:  Vaxi
// Created: Tuesday, May 19, 2020 11:40:42 PM
// Purpose: Definition of Class BusinessHoursService

using System;

namespace Service.BusinessHoursServ
{
   public class BusinessHoursService
   {
      public doctors SetDoctorsBusinessHours(List<Doctor> doctors, Model.BusinessHours.BusinessHours businessHours)
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
      
      public Model.BusinessHours.BusinessHours AddBusinessHours()
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
      
      public BusinessHoursRepositoryFactory businessHoursRepositoryFactory;
   
   }
}