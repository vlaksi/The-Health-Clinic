// File:    Doctor.cs
// Author:  Vaxi
// Created: Wednesday, April 1, 2020 9:43:20 PM
// Purpose: Definition of Class Doctor

using Model.MedicalRecord;
using Model.Survey;
using Model.BlogPost;
using Model.BusinessHours;
using System;

namespace Model.Users
{
   public class Doctor : RegisteredUser
   {
      private bool ableToValidateMedicines = false;
      private bool ableToPrescribeTreatments = false;
      
      public bool AbleToValidateMedicines
      {
         get
         {
            return ableToValidateMedicines;
         }
         set
         {
            this.ableToValidateMedicines = value;
         }
      }
      
      public bool AbleToPrescribeTreatments
      {
         get
         {
            return ableToPrescribeTreatments;
         }
         set
         {
            this.ableToPrescribeTreatments = value;
         }
      }
      
      public Model.Rooms.Ordination ordination;
      public System.Collections.ArrayList referralsFromMe;
      
      /// <summary>
      /// Property for collection of ReferralToSpecialist
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.ArrayList ReferralsFromMe
      {
         get
         {
            if (referralsFromMe == null)
               referralsFromMe = new System.Collections.ArrayList();
            return referralsFromMe;
         }
         set
         {
            RemoveAllReferralsFromMe();
            if (value != null)
            {
               foreach (ReferralToSpecialist oReferralToSpecialist in value)
                  AddReferralsFromMe(oReferralToSpecialist);
            }
         }
      }
      
      /// <summary>
      /// Add a new ReferralToSpecialist in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddReferralsFromMe(ReferralToSpecialist newReferralToSpecialist)
      {
         if (newReferralToSpecialist == null)
            return;
         if (this.referralsFromMe == null)
            this.referralsFromMe = new System.Collections.ArrayList();
         if (!this.referralsFromMe.Contains(newReferralToSpecialist))
         {
            this.referralsFromMe.Add(newReferralToSpecialist);
            newReferralToSpecialist.Nonspecialist = this;
         }
      }
      
      /// <summary>
      /// Remove an existing ReferralToSpecialist from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveReferralsFromMe(ReferralToSpecialist oldReferralToSpecialist)
      {
         if (oldReferralToSpecialist == null)
            return;
         if (this.referralsFromMe != null)
            if (this.referralsFromMe.Contains(oldReferralToSpecialist))
            {
               this.referralsFromMe.Remove(oldReferralToSpecialist);
               oldReferralToSpecialist.Nonspecialist = null;
            }
      }
      
      /// <summary>
      /// Remove all instances of ReferralToSpecialist from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllReferralsFromMe()
      {
         if (referralsFromMe != null)
         {
            System.Collections.ArrayList tmpReferralsFromMe = new System.Collections.ArrayList();
            foreach (ReferralToSpecialist oldReferralToSpecialist in referralsFromMe)
               tmpReferralsFromMe.Add(oldReferralToSpecialist);
            referralsFromMe.Clear();
            foreach (ReferralToSpecialist oldReferralToSpecialist in tmpReferralsFromMe)
               oldReferralToSpecialist.Nonspecialist = null;
            tmpReferralsFromMe.Clear();
         }
      }
      public BlogPostModel[] blogPost;
      public System.Collections.ArrayList businessHours;
      
      /// <summary>
      /// Property for collection of BusinessHours
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.ArrayList BusinessHours
      {
         get
         {
            if (businessHours == null)
               businessHours = new System.Collections.ArrayList();
            return businessHours;
         }
         set
         {
            RemoveAllBusinessHours();
            if (value != null)
            {
               foreach (BusinessHoursModel oBusinessHours in value)
                  AddBusinessHours(oBusinessHours);
            }
         }
      }
      
      /// <summary>
      /// Add a new BusinessHours in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddBusinessHours(BusinessHoursModel newBusinessHours)
      {
         if (newBusinessHours == null)
            return;
         if (this.businessHours == null)
            this.businessHours = new System.Collections.ArrayList();
         if (!this.businessHours.Contains(newBusinessHours))
         {
            this.businessHours.Add(newBusinessHours);
            newBusinessHours.AddDoctor(this);      
         }
      }
      
      /// <summary>
      /// Remove an existing BusinessHours from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveBusinessHours(BusinessHoursModel oldBusinessHours)
      {
         if (oldBusinessHours == null)
            return;
         if (this.businessHours != null)
            if (this.businessHours.Contains(oldBusinessHours))
            {
               this.businessHours.Remove(oldBusinessHours);
               oldBusinessHours.RemoveDoctor(this);
            }
      }
      
      /// <summary>
      /// Remove all instances of BusinessHours from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllBusinessHours()
      {
         if (businessHours != null)
         {
            System.Collections.ArrayList tmpBusinessHours = new System.Collections.ArrayList();
            foreach (BusinessHoursModel oldBusinessHours in businessHours)
               tmpBusinessHours.Add(oldBusinessHours);
            businessHours.Clear();
            foreach (BusinessHoursModel oldBusinessHours in tmpBusinessHours)
               oldBusinessHours.RemoveDoctor(this);
            tmpBusinessHours.Clear();
         }
      }
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
            newSurveyResponse.AddDoctors(this);      
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
               oldSurveyResponse.RemoveDoctors(this);
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
               oldSurveyResponse.RemoveDoctors(this);
            tmpSurveyResponses.Clear();
         }
      }
   
   }
}