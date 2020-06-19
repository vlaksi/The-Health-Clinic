// File:    SecretaryDataBaseRepository.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:19:34 AM
// Purpose: Definition of Class SecretaryDataBaseRepository

using System;

namespace Repository
{
   public class SecretaryDataBaseRepository<Secretary,int> : SecretaryRepository where Secretary : T
    where int : ID
   {
      public int Count()
      {
         throw new NotImplementedException();
      }
      
      public void Delete(Secretary entity)
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
      
      public Iterable<Secretary> FindAll()
      {
         throw new NotImplementedException();
      }
      
      public Secretary FindById(int id)
      {
         throw new NotImplementedException();
      }
      
      public void Save(Secretary entity)
      {
         throw new NotImplementedException();
      }
      
      public void SaveAll(Iterable<Secretary> entities)
      {
         throw new NotImplementedException();
      }
      
      public Iterable<Secretary> FindAllById(Iterable<int> ids)
      {
         throw new NotImplementedException();
      }
   
   }
}