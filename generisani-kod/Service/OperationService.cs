// File:    OperationService.cs
// Author:  Igorr
// Created: Wednesday, May 20, 2020 12:28:47 PM
// Purpose: Definition of Class OperationService

using System;

namespace Service
{
   public class OperationService
   {
      /// Get all upcoming operations for user if ID is provided, if not, get all upcoming operations in general. Similarly to Mongoose's find.
      public List<Operation> GetAllUpcomingOperations(int userId)
      {
         throw new NotImplementedException();
      }
      
      /// Get all past operations for user if ID is provided, if not, get all past operations in general. Similarly to Mongoose's find.
      public List<Operation> GetAllPastOperations(int userId)
      {
         throw new NotImplementedException();
      }
      
      public Operation ScheduleOperation(Operation newOp)
      {
         throw new NotImplementedException();
      }
      
      public Operation EditOperation(Operation newOp)
      {
         throw new NotImplementedException();
      }
      
      public bool CancelOperation(Operation operation)
      {
         throw new NotImplementedException();
      }
      
      public ITermRepositoryFactory iTermRepositoryFactory;
   
   }
}