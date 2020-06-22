// File:    Patient.cs
// Author:  Vaxi
// Created: Friday, March 20, 2020 4:32:04 PM
// Purpose: Definition of Class Patient

using Model.Patient;
using Model.Survey;
using System;

namespace Model.Users
{
   public class PatientModel : RegisteredUser
   {
      private bool isAccommodated;
      
      public System.Collections.Generic.List<SurveyResponse> surveyResponses;
      
      /// <summary>
      /// Property for collection of SurveyResponse
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<SurveyResponse> SurveyResponses
      {
         get
         {
            if (surveyResponses == null)
               surveyResponses = new System.Collections.Generic.List<SurveyResponse>();
            return surveyResponses;
         }
         set
         {
            RemoveAllSurveyResponses();
            if (value != null)
            {
               foreach (SurveyResponse oSurveyResponse in value)
                  AddSurveyResponses(oSurveyResponse);
            }
         }
      }
      
      /// <summary>
      /// Add a new SurveyResponse in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddSurveyResponses(SurveyResponse newSurveyResponse)
      {
         if (newSurveyResponse == null)
            return;
         if (this.surveyResponses == null)
            this.surveyResponses = new System.Collections.Generic.List<SurveyResponse>();
         if (!this.surveyResponses.Contains(newSurveyResponse))
         {
            this.surveyResponses.Add(newSurveyResponse);
            newSurveyResponse.PatientId = this.Id;
         }
      }
      
      /// <summary>
      /// Remove an existing SurveyResponse from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveSurveyResponses(SurveyResponse oldSurveyResponse)
      {
         if (oldSurveyResponse == null)
            return;
         if (this.surveyResponses != null)
            if (this.surveyResponses.Contains(oldSurveyResponse))
            {
               this.surveyResponses.Remove(oldSurveyResponse);
               oldSurveyResponse.PatientId = 0;
                }
      }
      
      /// <summary>
      /// Remove all instances of SurveyResponse from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllSurveyResponses()
      {
         if (surveyResponses != null)
         {
            System.Collections.ArrayList tmpSurveyResponses = new System.Collections.ArrayList();
            foreach (SurveyResponse oldSurveyResponse in surveyResponses)
               tmpSurveyResponses.Add(oldSurveyResponse);
            surveyResponses.Clear();
            foreach (SurveyResponse oldSurveyResponse in tmpSurveyResponses)
               oldSurveyResponse.PatientId = 0;
                tmpSurveyResponses.Clear();
         }
      }
      public RoomsHistory[] roomsHistory;
   
   }
}