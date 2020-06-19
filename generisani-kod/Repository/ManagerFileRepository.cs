// File:    ManagerFileRepository.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:19:33 AM
// Purpose: Definition of Class ManagerFileRepository

using System;

namespace Repository
{
   public class ManagerFileRepository<Manager,int> : ManagerRepository where Manager : T
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
      
      public void Delete(Manager entity)
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
      
      public Iterable<Manager> FindAll()
      {
         throw new NotImplementedException();
      }
      
      public Manager FindById(int id)
      {
         throw new NotImplementedException();
      }
      
      public void Save(Manager entity)
      {
         throw new NotImplementedException();
      }
      
      public void SaveAll(Iterable<Manager> entities)
      {
         throw new NotImplementedException();
      }
      
      public Iterable<Manager> FindAllById(Iterable<int> ids)
      {
         throw new NotImplementedException();
      }
   
   }
}