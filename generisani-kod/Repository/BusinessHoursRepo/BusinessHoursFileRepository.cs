// File:    BusinessHoursFileRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 5:16:42 PM
// Purpose: Definition of Class BusinessHoursFileRepository

using System;

namespace Repository.BusinessHoursRepo
{
   public class BusinessHoursFileRepository<BusinessHours,int> : BusinessHoursRepository where BusinessHours : T
    where int : ID
   {
      private void OpenFile()
      {
         throw new NotImplementedException();
      }
      
      private void CloseFile()
      {
         throw new NotImplementedException();
      }
      
      private string filePath;
      
      /// Metoda koja za prosledjene doktore ponovo vraca osvezen prikaz njihovog stanja radnog kalendara u skladistu podataka.
      public BusinessHours GetUpdatedBusinessHours(List<Doctors> doctors)
      {
         throw new NotImplementedException();
      }
   
   }
}