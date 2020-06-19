// File:    SurveyResponseFileRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 5:16:42 PM
// Purpose: Definition of Class SurveyResponseFileRepository

using System;

namespace Repository.SurveyResponseRepo
{
   public class SurveyResponseFileRepository<SurveyResponse,int> : SurveyResponseRepository where SurveyResponse : T
    where int : ID
   {
      private void OpenFile()
      {
         throw new NotImplementedException();
      }
      
      private void CloseFile()
      {
         throw new NotImplementedException();
      }
      
      private string filePath;
   
   }
}