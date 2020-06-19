// File:    SurveyResponseRepositoryFactory.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 5:52:08 PM
// Purpose: Definition of Interface SurveyResponseRepositoryFactory

using System;

namespace Repository.SurveyResponseRepo
{
   public interface SurveyResponseRepositoryFactory
   {
      SurveyResponseRepository CreateSurveyResponseRepository();
   
   }
}