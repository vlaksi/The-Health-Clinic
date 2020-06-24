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
        public OperationService operationService = new OperationService();

        public void CancelTerm(Term term)
        {
            operationService.CancelOperation((Operation)term);
        }

        public void EditTerm(Term newTerm)
        {
            throw new NotImplementedException();
        }

        public void ScheduleTerm(Term newTerm)
        {
            operationService.ScheduleOperation((Operation)newTerm);
        }

    }
}