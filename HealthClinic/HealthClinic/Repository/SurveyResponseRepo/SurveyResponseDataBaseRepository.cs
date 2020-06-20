// File:    SurveyResponseDataBaseRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 5:16:42 PM
// Purpose: Definition of Class SurveyResponseDataBaseRepository

using Model.Survey;
using System;
using System.Collections.Generic;

namespace Repository.SurveyResponseRepo
{
    public class SurveyResponseDataBaseRepository : SurveyResponseRepository
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(SurveyResponse entity)
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

        public IEnumerable<SurveyResponse> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SurveyResponse> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public SurveyResponse FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(SurveyResponse entity)
        {
            throw new NotImplementedException();
        }

        public void SaveAll(IEnumerable<SurveyResponse> entities)
        {
            throw new NotImplementedException();
        }
    }
}