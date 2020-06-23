// File:    SurveyResponseDataBaseRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 5:16:42 PM
// Purpose: Definition of Class SurveyResponseDataBaseRepository

using Model.Survey;
using System;
using System.Collections.Generic;

namespace Repository.AppReviewRepo
{
    public class AppReviewDataBaseRepository : AppReviewRepository
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(AppReview entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int identificator)
        {
            throw new NotImplementedException();
        }

        public bool ExistsById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AppReview> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AppReview> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public AppReview FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(AppReview entity)
        {
            throw new NotImplementedException();
        }

        public void SaveAll(IEnumerable<AppReview> entities)
        {
            throw new NotImplementedException();
        }
    }
}