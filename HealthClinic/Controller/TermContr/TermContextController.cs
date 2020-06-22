// File:    TermContextController.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 12:18:38 AM
// Purpose: Definition of Class TermContextController

using Model.Calendar;
using System;

namespace Controller.TermContr
{
    /// Ako budemo hteli da prebacimo na one dot rule, samo bi mogli ubaciti metode koje pozivaju iTermStrategy.odredjenaMetoda() i time resiti taj problem.
    public class TermContextController
    {
        public ITermStrategy iTermStrategy;

        public TermContextController(Term term)
        {
            var testOperation = new Operation();
            var testCheckup = new Checkup();
            // posto parametar isinstanceoftype ocekuje objekat ne mozemo direktno klasu proslediti
            // pa cisto pravimo objekat da bi mogli zadovoljiti parametar metode
            if ((term.GetType()).IsInstanceOfType(testOperation))
            {
                iTermStrategy = new OperationStrategyController();
            }
            else if ((term.GetType()).IsInstanceOfType(testCheckup)){
                iTermStrategy = new CheckupStrategyControler();
            }

        }


    }
}