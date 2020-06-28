// File:    SurveyResponseFileRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 5:16:42 PM
// Purpose: Definition of Class SurveyResponseFileRepository

using Model.Survey;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Repository.SurveyResponseRepo
{
    public class SurveyResponseFileRepository : SurveyResponseRepository
    {
        //private string filePath = @"./../../../HealthClinic/FileStorage/survey-responses.json";
        private string filePath = @"./../../../../HealthClinic/FileStorage/survey-responses.json";

        private void OpenFile()
        {
            throw new NotImplementedException();
        }

        private void CloseFile()
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(SurveyResponse entity)
        {
            List<SurveyResponse> allSurveys = (List<SurveyResponse>)FindAll();
            Console.WriteLine(allSurveys[0].Id);
            for (int i = 0; i < allSurveys.Count; i++)
            {
                if (allSurveys[i].Id == entity.Id)
                {
                    allSurveys.RemoveAt(i);
                }
            }

            SaveAll(allSurveys);
            Console.WriteLine(allSurveys[0].Id);
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
            List<SurveyResponse> allSurveys;

            allSurveys = JsonConvert.DeserializeObject<List<SurveyResponse>>(File.ReadAllText(filePath));

            if (allSurveys == null) allSurveys = new List<SurveyResponse>();

            return allSurveys;
        }

        public SurveyResponse FindById(int id)
        {
            List<SurveyResponse> allSurveys = (List<SurveyResponse>)FindAll();
            foreach (SurveyResponse sr in allSurveys)
            {
                if (sr.Id == id)
                {
                    return sr;
                }
            }
            return null;
        }

        public void Save(SurveyResponse entity)
        {
            entity.Id = GenerateId();
            List<SurveyResponse> allSurveys = (List<SurveyResponse>)FindAll();
            allSurveys.Add(entity);
            SaveAll(allSurveys);
        }

        public int GenerateId()
        {
            int maxId = -1;
            List<SurveyResponse> allSurveys = (List<SurveyResponse>)FindAll();
            if (allSurveys.Count == 0) return 1;
            foreach (SurveyResponse sr in allSurveys)
            {
                if (sr.Id > maxId) maxId = sr.Id;
            }

            return maxId + 1;
        }

        public void SaveAll(IEnumerable<SurveyResponse> entities)
        {

            using (StreamWriter file = File.CreateText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, entities);
            }
        }

        public IEnumerable<SurveyResponse> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }



    }
}