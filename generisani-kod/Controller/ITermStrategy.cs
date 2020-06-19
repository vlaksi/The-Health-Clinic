// File:    ITermStrategy.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 12:18:34 AM
// Purpose: Definition of Interface ITermStrategy

using System;

namespace Controller
{
   public interface ITermStrategy
   {
      /// Get all upcoming operations for user if ID is provided, if not, get all upcoming operations in general. Similarly to Mongoose's find.
      List<Term> GetAllUpcomingTerm(int userId);
      
      /// Get all past operations for user if ID is provided, if not, get all past operations in general. Similarly to Mongoose's find.
      List<Term> GetAllPastTerm(int userId);
      
      Term ScheduleTerm(Term newTerm);
      
      Term EditTerm(Term newTerm);
      
      bool CancelTerm(Term term);
   
   }
}