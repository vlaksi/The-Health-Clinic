// File:    ReferralToSpecialist.cs
// Author:  Vaxi
// Created: Wednesday, April 29, 2020 4:39:55 PM
// Purpose: Definition of Class ReferralToSpecialist

using System;

namespace Model.MedicalRecord
{
   public class ReferralToSpecialist
   {
      private DateTime validFromDate;
      private DateTime validToDate;
      
      public Model.Users.Doctor nonspecialist;
      
      /// <summary>
      /// Property for Model.Users.Doctor
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
      public Model.Users.Doctor Nonspecialist
      {
         get
         {
            return nonspecialist;
         }
         set
         {
            if (this.nonspecialist == null || !this.nonspecialist.Equals(value))
            {
               if (this.nonspecialist != null)
               {
                  Model.Users.Doctor oldDoctor = this.nonspecialist;
                  this.nonspecialist = null;
                  oldDoctor.RemoveReferralsFromMe(this);
               }
               if (value != null)
               {
                  this.nonspecialist = value;
                  this.nonspecialist.AddReferralsFromMe(this);
               }
            }
         }
      }
   
   }
}