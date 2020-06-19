// File:    ManagerDataBaseRepository.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:19:33 AM
// Purpose: Definition of Class ManagerDataBaseRepository

using System;

namespace Repository.UserRepo
{
   public class ManagerDataBaseRepository<Manager,int> : ManagerRepository where Manager : T
    where int : ID
   {
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