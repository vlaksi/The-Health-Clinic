// File:    OperationStrategyController.cs
// Author:  Igorr
// Created: Wednesday, May 20, 2020 12:28:47 PM
// Purpose: Definition of Class OperationStrategyController

using System;

namespace Controller
{
   public class OperationStrategyController : ITermStrategy
   {
      public bool CancelTerm(Term term)
      {
         throw new NotImplementedException();
      }
      
      public Term EditTerm(Term newTerm)
      {
         throw new NotImplementedException();
      }
      
      public Term ScheduleTerm(Term newTerm)
      {
         throw new NotImplementedException();
      }
      
      /// Get all past operations for user if ID is provided, if not, get all past operations in general. Similarly to Mongoose's find.
      public List<Term> GetAllPastTerm(int userId)
      {
         throw new NotImplementedException();
      }
      
      /// Get all upcoming operations for user if ID is provided, if not, get all upcoming operations in general. Similarly to Mongoose's find.
      public List<Term> GetAllUpcomingTerm(int userId)
      {
         throw new NotImplementedException();
      }
      
      public Service.OperationService operationService;
   
   }
}