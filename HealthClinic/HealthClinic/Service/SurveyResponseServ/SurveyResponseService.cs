// File:    SurveyResponseService.cs
// Author:  Vaxi
// Created: Tuesday, May 19, 2020 11:39:18 PM
// Purpose: Definition of Class SurveyResponseService

using Model.Survey;
using Model.Users;
using Repository.SurveyResponseRepo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

//TODO: Resiti ove interakcije sa repo, preko factory patterna
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

        public void saveAllSurveyResponses(List<SurveyResponse> surveysToSave)
        {
            SurveyResponseFileRepository surveyRepo = new SurveyResponseFileRepository();
            surveyRepo.SaveAll(surveysToSave);
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

        public List<SurveyResponse> GetSurveysForDoctor(Doctor doctor)
        {
            SurveyResponseFileRepository surveyRepo = new SurveyResponseFileRepository();

            List<SurveyResponse> allSurveys = (List<SurveyResponse>)surveyRepo.FindAll();
            List<SurveyResponse> resultSurveys = new List<SurveyResponse>();

            foreach (SurveyResponse sr in allSurveys)
            {
                if (sr.DoctorId == doctor.Id)
                {
                    resultSurveys.Add(sr);

                }
            }

            return resultSurveys;
        }

        public void AddSurveyResponse(SurveyResponse surveyToSave)
        {
            SurveyResponseFileRepository surveyRepo = new SurveyResponseFileRepository();

            surveyRepo.Save(surveyToSave);
        }

        public SurveyResponse GetStatisticsForDoctor(Doctor doctor)
        {
            List<SurveyResponse> allSurveys = this.GetSurveysForDoctor(doctor);

            int quality = 0;
            int security = 0;
            int kindness = 0;
            int professionalism = 0;
            string comment = "";

            foreach (SurveyResponse survey in allSurveys)
            {
                quality += (int)survey.Quality;
                security += (int)survey.Security;
                kindness += (int)survey.Kindness;
                professionalism += (int)survey.Professionalism;
                comment += survey.Comment + "\n";
            }

            SurveyResponse result = new SurveyResponse()
            {
                Quality = (Rate)Enum.ToObject(typeof(Rate), Convert.ToInt32(Math.Floor((double)quality / allSurveys.Count))),
                Security = (Rate)Enum.ToObject(typeof(Rate), Convert.ToInt32(Math.Floor((double)security / allSurveys.Count))),
                Kindness = (Rate)Enum.ToObject(typeof(Rate), Convert.ToInt32(Math.Floor((double)kindness / allSurveys.Count))),
                Professionalism = (Rate)Enum.ToObject(typeof(Rate), Convert.ToInt32(Math.Floor((double)professionalism / allSurveys.Count))),
                Comment = comment
            };

            return result;
        }
    }
}