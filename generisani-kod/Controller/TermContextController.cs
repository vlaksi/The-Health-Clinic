// File:    TermContextController.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 12:18:38 AM
// Purpose: Definition of Class TermContextController

using System;

namespace Controller
{
   /// Ako budemo hteli da prebacimo na one dot rule, samo bi mogli ubaciti metode koje pozivaju iTermStrategy.odredjenaMetoda() i time resiti taj problem.
   public class TermContextController
   {
      public TermContextController(Term term)
      {
         if(term instaceof Operation)
            iTermStrategy = new OperationStrategyController();
         else if(term instanceof Checkup)
            iTermStrategy = new CheckupStrategyController();
      }
      
      public ITermStrategy iTermStrategy;
   
   }
}