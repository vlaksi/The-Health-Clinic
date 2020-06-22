// File:    OperationStrategyController.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:28:47 PM
// Purpose: Definition of Class OperationStrategyController

using Model.Calendar;
using Service.TermServ;
using System;
using System.Collections.Generic;

namespace Controller.TermContr
{
    public class OperationStrategyController : ITermStrategy
    {
        public OperationService operationService;

        public bool CancelTerm(Term term)
        {
            return operationService.CancelOperation((Operation)term);
        }

        public void EditTerm(Term newTerm)
        {
            operationService.EditOperation((Operation)newTerm);
        }

        public void ScheduleTerm(Term newTerm)
        {
            operationService.ScheduleOperation((Operation)newTerm);
        }

        /// Get all past operations for user if ID is provided, if not, get all past operations in general. Similarly to Mongoose's find.
        public List<Operation> GetAllPastTerm(int userId)
        {
            return operationService.GetAllPastOperations(userId);
        }

        /// Get all upcoming operations for user if ID is provided, if not, get all upcoming operations in general. Similarly to Mongoose's find.
        public List<Operation> GetAllUpcomingTerm(int userId)
        {
            return operationService.GetAllUpcomingOperations(userId);
        }

        // Nisam znao kako da rijesim ovo, jer se ne moze kastovati operation nazad u term - Igor
        List<Term> ITermStrategy.GetAllPastTerm(int userId)
        {
            throw new NotImplementedException();
        }
        List<Term> ITermStrategy.GetAllUpcomingTerm(int userId)
        {
            throw new NotImplementedException();
        }

    }
}