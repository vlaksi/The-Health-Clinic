// File:    CheckupFileRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 5:16:42 PM
// Purpose: Definition of Class CheckupFileRepository

using System;

namespace Repository.TermRepo
{
   public class CheckupFileRepository<Checkup,int> : CheckupRepository where Checkup : T
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
      
      public Iterable<Checkup> FindAllById(Iterable<int> ids)
      {
         throw new NotImplementedException();
      }
      
      public int Count()
      {
         throw new NotImplementedException();
      }
      
      public void Delete<T>(Checkup entity)
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
      
      public Iterable<Checkup> FindAll()
      {
         throw new NotImplementedException();
      }
      
      public Checkup FindById(int id)
      {
         throw new NotImplementedException();
      }
      
      public void Save(Checkup entity)
      {
         throw new NotImplementedException();
      }
      
      public void SaveAll(Iterable<Checkup> entities)
      {
         throw new NotImplementedException();
      }
   
   }
}