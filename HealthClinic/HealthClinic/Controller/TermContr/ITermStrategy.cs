// File:    ITermStrategy.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 12:18:34 AM
// Purpose: Definition of Interface ITermStrategy

using Model.Calendar;
using System;
using System.Collections.Generic;

namespace Controller.TermContr
{
    public interface ITermStrategy
    {
        void ScheduleTerm(Term newTerm);

        void EditTerm(Term newTerm);

        void CancelTerm(Term term);

    }
}