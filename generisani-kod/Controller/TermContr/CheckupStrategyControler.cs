// File:    CheckupStrategyControler.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:34:11 PM
// Purpose: Definition of Class CheckupStrategyControler

using System;

namespace Controller.TermContr
{
   public class CheckupStrategyControler : ITermStrategy
   {
      public DateTime SuggestCheckup(Patient patient, List<Checkup>[] pastCheckups)
      {
        calendarService.suggestingAnCheckup(Patient patient, Chekup[] allPastCheckups);
      }
      
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
      
      public Service.TermServ.CheckupService checkupService;
   
   }
}