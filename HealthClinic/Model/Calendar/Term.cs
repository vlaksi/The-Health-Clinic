// File:    Term.cs
// Author:  Vaxi
// Created: Sunday, April 5, 2020 12:02:01 AM
// Purpose: Definition of Class Term

using HealthClinic.Utilities;
using System;

namespace Model.Calendar
{
   public class Term : ObservableObject
    {
      private System.DateTime startTime;
      private System.DateTime endTime;
      private int id;

      public System.DateTime StartTime
      {
         get
         {
            return startTime;
         }
         set
         {
            this.startTime = value;
            OnPropertyChanged("StartTime");
         }
      }
      
      public System.DateTime EndTime
      {
         get
         {
            return endTime;
         }
         set
         {
            this.endTime = value;
            OnPropertyChanged("EndTime");
         }
      }
      
      public int Id
      {
         get
         {
                return id;
         }
         set
         {
               this.id = value;
               OnPropertyChanged("Id");
         }
      }
      
      public Report report;
      public Model.Users.SpecialtyType specialtyType;
      public Model.MedicalRecord.MedicalRecord medicalRecord;
      
      /// <summary>
      /// Property for Model.MedicalRecord.MedicalRecord
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
      public Model.MedicalRecord.MedicalRecord MedicalRecord
      {
         get
         {
            return medicalRecord;
         }
         set
         {
            if (this.medicalRecord == null || !this.medicalRecord.Equals(value))
            {
               if (this.medicalRecord != null)
               {
                  Model.MedicalRecord.MedicalRecord oldMedicalRecord = this.medicalRecord;
                  this.medicalRecord = null;
                  oldMedicalRecord.RemoveTerm(this);
               }
               if (value != null)
               {
                  this.medicalRecord = value;
                  this.medicalRecord.AddTerm(this);
               }
            }
         }
      }
   
   }
}