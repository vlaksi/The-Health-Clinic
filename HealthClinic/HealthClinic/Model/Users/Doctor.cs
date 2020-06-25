// File:    Doctor.cs
// Author:  Vaxi
// Created: Wednesday, April 1, 2020 9:43:20 PM
// Purpose: Definition of Class Doctor

using Model.MedicalRecord;
using Model.Survey;
using Model.BlogPost;
using Model.BusinessHours;
using System;
using Model.Rooms;
using System.Collections;
using System.Collections.Generic;

namespace Model.Users
{
    public class Doctor : Employee
    {
        #region Attributes

        private bool ableToValidateMedicines = false;
        private bool ableToPrescribeTreatments = false;
        public Ordination ordination;
        public ArrayList referralsFromMe;
        public BlogPostModel[] blogPost;
        public List<SurveyResponse> surveyResponses;

        #endregion

        #region Properties

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
       
        /// <summary>
        /// Property for collection of ReferralToSpecialist
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public ArrayList ReferralsFromMe
        {
            get
            {
                if (referralsFromMe == null)
                    referralsFromMe = new ArrayList();
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
        /// Property for collection of SurveyResponse
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public List<SurveyResponse> SurveyResponses
        {
            get
            {
                if (surveyResponses == null)
                    surveyResponses = new List<SurveyResponse>();
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
        
        #endregion

        #region Manipulation with property: ReferralsFromMe

        /// <summary>
        /// Add a new ReferralToSpecialist in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddReferralsFromMe(ReferralToSpecialist newReferralToSpecialist)
        {
            if (newReferralToSpecialist == null)
                return;
            if (this.referralsFromMe == null)
                this.referralsFromMe = new ArrayList();
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
                ArrayList tmpReferralsFromMe = new ArrayList();
                foreach (ReferralToSpecialist oldReferralToSpecialist in referralsFromMe)
                    tmpReferralsFromMe.Add(oldReferralToSpecialist);
                referralsFromMe.Clear();
                foreach (ReferralToSpecialist oldReferralToSpecialist in tmpReferralsFromMe)
                    oldReferralToSpecialist.Nonspecialist = null;
                tmpReferralsFromMe.Clear();
            }
        }

        #endregion

        #region Manipulation with property: SurveyResponses

        /// <summary>
        /// Add a new SurveyResponse in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddSurveyResponses(SurveyResponse newSurveyResponse)
        {
            if (newSurveyResponse == null)
                return;
            if (this.surveyResponses == null)
                this.surveyResponses = new List<SurveyResponse>();
            if (!this.surveyResponses.Contains(newSurveyResponse))
            {
                this.surveyResponses.Add(newSurveyResponse);
                newSurveyResponse.Doctors.Add(this.Id);
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
                    oldSurveyResponse.Doctors.Remove(this.Id);
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
                ArrayList tmpSurveyResponses = new ArrayList();
                foreach (SurveyResponse oldSurveyResponse in surveyResponses)
                    tmpSurveyResponses.Add(oldSurveyResponse);
                surveyResponses.Clear();
                foreach (SurveyResponse oldSurveyResponse in tmpSurveyResponses)
                    oldSurveyResponse.Doctors.Remove(this.Id);
                tmpSurveyResponses.Clear();
            }
        }

        #endregion
    }
}