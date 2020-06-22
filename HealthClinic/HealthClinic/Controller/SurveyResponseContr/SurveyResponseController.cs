// File:    SurveyResponseController.cs
// Author:  Vaxi
// Created: Tuesday, May 19, 2020 11:39:18 PM
// Purpose: Definition of Class SurveyResponseController

using Model.Survey;
using Service.SurveyResponseServ;
using System;
using System.Collections.Generic;

namespace Controller.SurveyResponseContr
{
    public class SurveyResponseController
    {
        public SurveyResponseService surveyResponseService = new SurveyResponseService();

        public List<SurveyResponse> GetAllSurveyResponses()
        {
            return surveyResponseService.GetAllSurveyResponses();
        }

        public void AddSurveyResponses(List<SurveyResponse>surveysToSave)
        {
            surveyResponseService.AddSurveyResponses(surveysToSave);
        }

        public void DeleteSurveyResponse(SurveyResponse forDeletion)
        {
            surveyResponseService.DeleteSurveyResponse(forDeletion);
        }


    }
}