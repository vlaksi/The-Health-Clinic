// File:    SurveyResponseService.cs
// Author:  Vaxi
// Created: Tuesday, May 19, 2020 11:39:18 PM
// Purpose: Definition of Class SurveyResponseService

using Model.Survey;
using Repository.SurveyResponseRepo;
using System;
using System.Collections.Generic;

namespace Service.SurveyResponseServ
{
    public class SurveyResponseService
    {
        public SurveyResponseRepositoryFactory surveyResponseRepositoryFactory;

        public List<SurveyResponse> GetAllSurveyResponses()
        {
            SurveyResponseFileRepository surveyRepo = new SurveyResponseFileRepository();

            List<SurveyResponse> surveys = new List<SurveyResponse>();
            surveys = (List<SurveyResponse>)surveyRepo.FindAll();

            return surveys;
        }

        public void AddSurveyResponses(List<SurveyResponse> surveysToSave)
        {
            SurveyResponseFileRepository surveyRepo = new SurveyResponseFileRepository();

            surveyRepo.SaveAll(surveysToSave);
        }

        public void DeleteSurveyResponse(SurveyResponse forDeletion)
        {
            SurveyResponseFileRepository surveyRepo = new SurveyResponseFileRepository();

            surveyRepo.Delete(forDeletion);
        }


    }
}