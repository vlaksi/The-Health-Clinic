// File:    BusinessHoursHistory.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 6:37:09 PM
// Purpose: Definition of Class BusinessHoursHistory

using System;

namespace Model.BusinessHours
{
   public class BusinessHoursHistory
   {
      public System.Collections.Generic.List<BusinessHoursModel> businessHours;
      
      /// <summary>
      /// Property for collection of BusinessHours
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<BusinessHoursModel> BusinessHours
      {
         get
         {
            if (businessHours == null)
               businessHours = new System.Collections.Generic.List<BusinessHoursModel>();
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
            this.businessHours = new System.Collections.Generic.List<BusinessHoursModel>();
         if (!this.businessHours.Contains(newBusinessHours))
            this.businessHours.Add(newBusinessHours);
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
               this.businessHours.Remove(oldBusinessHours);
      }
      
      /// <summary>
      /// Remove all instances of BusinessHours from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllBusinessHours()
      {
         if (businessHours != null)
            businessHours.Clear();
      }
   
   }
}