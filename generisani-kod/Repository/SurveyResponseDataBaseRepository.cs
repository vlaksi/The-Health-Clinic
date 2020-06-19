// File:    SurveyResponseDataBaseRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 5:16:42 PM
// Purpose: Definition of Class SurveyResponseDataBaseRepository

using System;

namespace Repository
{
   public class SurveyResponseDataBaseRepository<SurveyResponse,int> : SurveyResponseRepository where SurveyResponse : T
    where int : ID
   {
      public Iterable<SurveyResponse> FindAllById(Iterable<int> ids)
      {
         throw new NotImplementedException();
      }
      
      public int Count()
      {
         throw new NotImplementedException();
      }
      
      public void Delete<T>(SurveyResponse entity)
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
      
      public Boolean ExistsById(int id)
      {
         throw new NotImplementedException();
      }
      
      public Iterable<SurveyResponse> FindAll()
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
      
      public void SaveAll(Iterable<SurveyResponse> entities)
      {
         throw new NotImplementedException();
      }
   
   }
}