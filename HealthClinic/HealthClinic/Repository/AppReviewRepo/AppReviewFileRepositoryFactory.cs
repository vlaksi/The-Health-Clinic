// File:    SurveyResponseFileRepositoryFactory.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 5:52:56 PM
// Purpose: Definition of Class SurveyResponseFileRepositoryFactory

using Repository.AppReviewRepo;
using System;

namespace Repository.AppReviewRepo
{
    public class AppReviewFileRepositoryFactory : AppReviewRepositoryFactory
    {
        public AppReviewRepository CreateAppReviewRepository()
        {
            throw new NotImplementedException();
        }
    }
}