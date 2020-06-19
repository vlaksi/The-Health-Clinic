// File:    OperationDataBaseRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 5:16:42 PM
// Purpose: Definition of Class OperationDataBaseRepository

using System;

namespace Repository
{
   public class OperationDataBaseRepository<Operation,int> : OperationRepository where Operation : T
    where int : ID
   {
      public int Count()
      {
         throw new NotImplementedException();
      }
      
      public void Delete(Operation entity)
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
      
      public Iterable<Operation> FindAll()
      {
         throw new NotImplementedException();
      }
      
      public Operation FindById(int id)
      {
         throw new NotImplementedException();
      }
      
      public void Save(Operation entity)
      {
         throw new NotImplementedException();
      }
      
      public void SaveAll(Iterable<Operation> entities)
      {
         throw new NotImplementedException();
      }
      
      public Iterable<Operation> FindAllById(Iterable<int> ids)
      {
         throw new NotImplementedException();
      }
   
   }
}