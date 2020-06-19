// File:    OperationFileRepository.cs
// Author:  Igorr
// Created: Saturday, May 2, 2020 5:16:42 PM
// Purpose: Definition of Class OperationFileRepository

using System;

namespace Repository
{
   public class OperationFileRepository<Operation,int> : OperationRepository where Operation : T
    where int : ID
   {
      private string OpenFile()
      {
         throw new NotImplementedException();
      }
      
      private string CloseFile()
      {
         throw new NotImplementedException();
      }
      
      private string filePath;
      
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