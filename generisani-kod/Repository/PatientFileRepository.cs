// File:    PatientFileRepository.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:19:33 AM
// Purpose: Definition of Class PatientFileRepository

using System;

namespace Repository
{
   public class PatientFileRepository<Patient,int> : PatientRepository where Patient : T
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
      
      public int Count()
      {
         throw new NotImplementedException();
      }
      
      public void Delete(Patient entity)
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
      
      public Iterable<Patient> FindAll()
      {
         throw new NotImplementedException();
      }
      
      public Patient FindById(int id)
      {
         throw new NotImplementedException();
      }
      
      public void Save(Patient entity)
      {
         throw new NotImplementedException();
      }
      
      public void SaveAll(Iterable<Patient> entities)
      {
         throw new NotImplementedException();
      }
      
      public Iterable<Patient> FindAllById(Iterable<int> ids)
      {
         throw new NotImplementedException();
      }
   
   }
}