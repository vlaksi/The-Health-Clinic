// File:    MedicineFileRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 5:16:42 PM
// Purpose: Definition of Class MedicineFileRepository

using System;

namespace Repository
{
   public class MedicineFileRepository<Medicine,int> : MedicineRepository where Medicine : T
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
      
      public Iterable<Medicine> FindAllById(Iterable<int> ids)
      {
         throw new NotImplementedException();
      }
      
      public int Count()
      {
         throw new NotImplementedException();
      }
      
      public void Delete<T>(Medicine entity)
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
      
      public Iterable<Medicine> FindAll()
      {
         throw new NotImplementedException();
      }
      
      public Medicine FindById(int id)
      {
         throw new NotImplementedException();
      }
      
      public void Save(Medicine entity)
      {
         throw new NotImplementedException();
      }
      
      public void SaveAll(Iterable<Medicine> entities)
      {
         throw new NotImplementedException();
      }
   
   }
}