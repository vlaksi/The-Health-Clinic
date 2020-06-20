// File:    BusinessHoursModel.cs
// Author:  Vaxi
// Created: Tuesday, April 21, 2020 8:27:16 PM
// Purpose: Definition of Class BusinessHoursModel

using System;

namespace Model.BusinessHours
{
   public class BusinessHoursModel
   {
      private int fromHour;
      private int toHour;
      private DateTime fromDate;
      private DateTime toDate;
      
      public int FromHour
      {
         get
         {
            return fromHour;
         }
         set
         {
            this.fromHour = value;
         }
      }
      
      public int ToHour
      {
         get
         {
            return toHour;
         }
         set
         {
            this.toHour = value;
         }
      }
      
      public DateTime FromDate
      {
         get
         {
            return fromDate;
         }
         set
         {
            this.fromDate = value;
         }
      }
      
      public DateTime ToDate
      {
         get
         {
            return toDate;
         }
         set
         {
            this.toDate = value;
         }
      }
      
      public System.Collections.ArrayList doctor;
      
      /// <summary>
      /// Property for collection of Model.Users.Doctor
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.ArrayList Doctor
      {
         get
         {
            if (doctor == null)
               doctor = new System.Collections.ArrayList();
            return doctor;
         }
         set
         {
            RemoveAllDoctor();
            if (value != null)
            {
               foreach (Model.Users.Doctor oDoctor in value)
                  AddDoctor(oDoctor);
            }
         }
      }
      
      /// <summary>
      /// Add a new Model.Users.Doctor in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddDoctor(Model.Users.Doctor newDoctor)
      {
         if (newDoctor == null)
            return;
         if (this.doctor == null)
            this.doctor = new System.Collections.ArrayList();
         if (!this.doctor.Contains(newDoctor))
         {
            this.doctor.Add(newDoctor);
            newDoctor.AddBusinessHours(this);      
         }
      }
      
      /// <summary>
      /// Remove an existing Model.Users.Doctor from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveDoctor(Model.Users.Doctor oldDoctor)
      {
         if (oldDoctor == null)
            return;
         if (this.doctor != null)
            if (this.doctor.Contains(oldDoctor))
            {
               this.doctor.Remove(oldDoctor);
               oldDoctor.RemoveBusinessHours(this);
            }
      }
      
      /// <summary>
      /// Remove all instances of Model.Users.Doctor from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllDoctor()
      {
         if (doctor != null)
         {
            System.Collections.ArrayList tmpDoctor = new System.Collections.ArrayList();
            foreach (Model.Users.Doctor oldDoctor in doctor)
               tmpDoctor.Add(oldDoctor);
            doctor.Clear();
            foreach (Model.Users.Doctor oldDoctor in tmpDoctor)
               oldDoctor.RemoveBusinessHours(this);
            tmpDoctor.Clear();
         }
      }
   
   }
}