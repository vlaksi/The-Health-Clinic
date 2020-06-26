using Model.Survey;
using Newtonsoft.Json;
using Repository.AppReviewRepo;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repository.SurveyResponseRepo
{
    public class AppReviewFileRepository : AppReviewRepository
    {

        private string filePath = @"./../../../HealthClinic/FileStorage/appReview.json";


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
              List<AppReview> allAppReviews;

              allAppReviews = JsonConvert.DeserializeObject<List<AppReview>>(File.ReadAllText(filePath));

              if (allAppReviews == null) allAppReviews = new List<AppReview>();

              return allAppReviews;
         
        }

        public AppReview FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(AppReview entity)
        {
             List<AppReview> allAppReviews = (List<AppReview>)FindAll();
             allAppReviews.Add(entity);
             SaveAll(allAppReviews);
        
        }

        public int GenerateId()
        {
            throw new NotImplementedException();
        }

        public void SaveAll(IEnumerable<AppReview> entities)
        {

              using (StreamWriter file = File.CreateText(filePath))
              {
                  JsonSerializer serializer = new JsonSerializer();
                  serializer.Serialize(file, entities);
              }
       
        }

        public IEnumerable<AppReview> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }



    }
}