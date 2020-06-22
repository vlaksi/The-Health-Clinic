// File:    CheckupStrategyControler.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:34:11 PM
// Purpose: Definition of Class CheckupStrategyControler

using Model.Calendar;
using Service.TermServ;
using System;
using System.Collections.Generic;

namespace Controller.TermContr
{
    public class CheckupStrategyControler : ITermStrategy
    {
        public CheckupService checkupService = new CheckupService();

        // TODO: Resiti i ovo, jer mi ni ovde nije jasno sta se desava
        //public DateTime SuggestCheckup(Patient patient, List<Checkup>[] pastCheckups)
        //{
        //  calendarService.suggestingAnCheckup(Patient patient, Chekup[] allPastCheckups);
        //}
        public List<Checkup> readAllCheckups()
        {
            return checkupService.readAllCheckups();
        }

        public void saveAllCheckups(List<Checkup> chekupsForSave)
        {
            checkupService.saveAllCheckups(chekupsForSave);
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


    }
}