// File:    SurveyResponseRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 7:05:48 PM
// Purpose: Definition of Interface SurveyResponseRepository

using System;
using Repository.GenericCRUD;
using Model.Survey;

namespace Repository.AppReviewRepo
{
   public interface AppReviewRepository : GenericInterfaceCRUDDao<AppReview, int>
   {

   }
}