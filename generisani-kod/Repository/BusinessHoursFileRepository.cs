// File:    BusinessHoursFileRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 5:16:42 PM
// Purpose: Definition of Class BusinessHoursFileRepository

using System;

namespace Repository
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
      
      public Iterable<BusinessHours> FindAllById(Iterable<int> ids)
      {
         throw new NotImplementedException();
      }
      
      public int Count()
      {
         throw new NotImplementedException();
      }
      
      public void Delete(BusinessHours entity)
      {
         throw new NotImplementedException();
      }
      
      public void DeleteAll()
      {
         throw new NotImplementedException();
      }
      
      public void DeleteById(int identificator)
      {
         throw new NotImplementedException();
      }
      
      public Boolean ExistsById(int id)
      {
         throw new NotImplementedException();
      }
      
      public Iterable<BusinessHours> FindAll()
      {
         throw new NotImplementedException();
      }
      
      public BusinessHours FindById(int id)
      {
         throw new NotImplementedException();
      }
      
      public void Save(BusinessHours entity)
      {
         throw new NotImplementedException();
      }
      
      public void SaveAll(Iterable<BusinessHours> entities)
      {
         throw new NotImplementedException();
      }
      
      /// Metoda koja za prosledjene doktore ponovo vraca osvezen prikaz njihovog stanja radnog kalendara u skladistu podataka.
      public BusinessHours GetUpdatedBusinessHours(List<Doctors> doctors)
      {
         throw new NotImplementedException();
      }
   
   }
}