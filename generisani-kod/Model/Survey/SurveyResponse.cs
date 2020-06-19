// File:    SurveyResponse.cs
// Author:  Vaxi
// Created: Wednesday, April 29, 2020 6:50:06 PM
// Purpose: Definition of Class SurveyResponse

using System;

namespace Model.Survey
{
   public class SurveyResponse
   {
      private Rate quality;
      private Rate security;
      private Rate kindness;
      private Rate professionalism;
      private string comment;
      
      public Rate Quality
      {
         get
         {
            return quality;
         }
         set
         {
            this.quality = value;
         }
      }
      
      public Rate Security
      {
         get
         {
            return security;
         }
         set
         {
            this.security = value;
         }
      }
      
      public Rate Kidness
      {
         get
         {
            return kindness;
         }
         set
         {
            this.kindness = value;
         }
      }
      
      public Rate Professionalism
      {
         get
         {
            return professionalism;
         }
         set
         {
            this.professionalism = value;
         }
      }
      
      public string Comment
      {
         get
         {
            return comment;
         }
         set
         {
            this.comment = value;
         }
      }
      
      public System.Collections.Generic.List<Doctor> doctors;
      
      /// <summary>
      /// Property for collection of Model.Users.Doctor
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Doctor> Doctors
      {
         get
         {
            if (doctors == null)
               doctors = new System.Collections.Generic.List<Doctor>();
            return doctors;
         }
         set
         {
            RemoveAllDoctors();
            if (value != null)
            {
               foreach (Model.Users.Doctor oDoctor in value)
                  AddDoctors(oDoctor);
            }
         }
      }
      
      /// <summary>
      /// Add a new Model.Users.Doctor in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddDoctors(Model.Users.Doctor newDoctor)
      {
         if (newDoctor == null)
            return;
         if (this.doctors == null)
            this.doctors = new System.Collections.Generic.List<Doctor>();
         if (!this.doctors.Contains(newDoctor))
         {
            this.doctors.Add(newDoctor);
            newDoctor.AddSurveyResponses(this);      
         }
      }
      
      /// <summary>
      /// Remove an existing Model.Users.Doctor from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveDoctors(Model.Users.Doctor oldDoctor)
      {
         if (oldDoctor == null)
            return;
         if (this.doctors != null)
            if (this.doctors.Contains(oldDoctor))
            {
               this.doctors.Remove(oldDoctor);
               oldDoctor.RemoveSurveyResponses(this);
            }
      }
      
      /// <summary>
      /// Remove all instances of Model.Users.Doctor from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllDoctors()
      {
         if (doctors != null)
         {
            System.Collections.ArrayList tmpDoctors = new System.Collections.ArrayList();
            foreach (Model.Users.Doctor oldDoctor in doctors)
               tmpDoctors.Add(oldDoctor);
            doctors.Clear();
            foreach (Model.Users.Doctor oldDoctor in tmpDoctors)
               oldDoctor.RemoveSurveyResponses(this);
            tmpDoctors.Clear();
         }
      }
      public Model.Users.Patient patient;
      
      /// <summary>
      /// Property for Model.Users.Patient
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
      public Model.Users.Patient Patient
      {
         get
         {
            return patient;
         }
         set
         {
            if (this.patient == null || !this.patient.Equals(value))
            {
               if (this.patient != null)
               {
                  Model.Users.Patient oldPatient = this.patient;
                  this.patient = null;
                  oldPatient.RemoveSurveyResponses(this);
               }
               if (value != null)
               {
                  this.patient = value;
                  this.patient.AddSurveyResponses(this);
               }
            }
         }
      }
   
   }
}