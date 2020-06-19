// File:    MedicalRecord.cs
// Author:  Vaxi
// Created: Sunday, April 5, 2020 12:42:49 PM
// Purpose: Definition of Class MedicalRecord

using System;

namespace Model.MedicalRecord
{
   public class MedicalRecord
   {
      private string name;
      private string surname;
      private string address;
      private string gender;
      private string jmbg;
      private DateTime dateOfBirth;
      private String parentsName;
      private String healthInsuranceNumber;
      private String phone;
      private String healthInsuranceCarrier;
      
      public string Name
      {
         get
         {
            return name;
         }
         set
         {
            this.name = value;
         }
      }
      
      public string Surname
      {
         get
         {
            return surname;
         }
         set
         {
            this.surname = value;
         }
      }
      
      public string Address
      {
         get
         {
            return address;
         }
         set
         {
            this.address = value;
         }
      }
      
      public string Gender
      {
         get
         {
            return gender;
         }
         set
         {
            this.gender = value;
         }
      }
      
      public string Jmbg
      {
         get
         {
            return jmbg;
         }
         set
         {
            this.jmbg = value;
         }
      }
      
      public DateTime DateOfBirth
      {
         get
         {
            return dateOfBirth;
         }
         set
         {
            this.dateOfBirth = value;
         }
      }
      
      public String ParentsName
      {
         get
         {
            return parentsName;
         }
         set
         {
            this.parentsName = value;
         }
      }
      
      public String HealthInsuranceNumber
      {
         get
         {
            return healthInsuranceNumber;
         }
         set
         {
            this.healthInsuranceNumber = value;
         }
      }
      
      public String Phone
      {
         get
         {
            return phone;
         }
         set
         {
            this.phone = value;
         }
      }
      
      public String HealthInsuranceCarrier
      {
         get
         {
            return healthInsuranceCarrier;
         }
         set
         {
            this.healthInsuranceCarrier = value;
         }
      }
      
      public Model.Medicine.Treatment[] treatment;
      public System.Collections.Generic.List<ReferralToSpecialist> referralToSpecialist;
      
      /// <summary>
      /// Property for collection of ReferralToSpecialist
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<ReferralToSpecialist> ReferralToSpecialist
      {
         get
         {
            if (referralToSpecialist == null)
               referralToSpecialist = new System.Collections.Generic.List<ReferralToSpecialist>();
            return referralToSpecialist;
         }
         set
         {
            RemoveAllReferralToSpecialist();
            if (value != null)
            {
               foreach (ReferralToSpecialist oReferralToSpecialist in value)
                  AddReferralToSpecialist(oReferralToSpecialist);
            }
         }
      }
      
      /// <summary>
      /// Add a new ReferralToSpecialist in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddReferralToSpecialist(ReferralToSpecialist newReferralToSpecialist)
      {
         if (newReferralToSpecialist == null)
            return;
         if (this.referralToSpecialist == null)
            this.referralToSpecialist = new System.Collections.Generic.List<ReferralToSpecialist>();
         if (!this.referralToSpecialist.Contains(newReferralToSpecialist))
            this.referralToSpecialist.Add(newReferralToSpecialist);
      }
      
      /// <summary>
      /// Remove an existing ReferralToSpecialist from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveReferralToSpecialist(ReferralToSpecialist oldReferralToSpecialist)
      {
         if (oldReferralToSpecialist == null)
            return;
         if (this.referralToSpecialist != null)
            if (this.referralToSpecialist.Contains(oldReferralToSpecialist))
               this.referralToSpecialist.Remove(oldReferralToSpecialist);
      }
      
      /// <summary>
      /// Remove all instances of ReferralToSpecialist from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllReferralToSpecialist()
      {
         if (referralToSpecialist != null)
            referralToSpecialist.Clear();
      }
      public Model.Users.Doctor doctor;
      public Patient patient;
      public System.Collections.Generic.List<Term> term;
      
      /// <summary>
      /// Property for collection of Term
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Term> Term
      {
         get
         {
            if (term == null)
               term = new System.Collections.Generic.List<Term>();
            return term;
         }
         set
         {
            RemoveAllTerm();
            if (value != null)
            {
               foreach (Term oTerm in value)
                  AddTerm(oTerm);
            }
         }
      }
      
      /// <summary>
      /// Add a new Term in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddTerm(Term newTerm)
      {
         if (newTerm == null)
            return;
         if (this.term == null)
            this.term = new System.Collections.Generic.List<Term>();
         if (!this.term.Contains(newTerm))
         {
            this.term.Add(newTerm);
            newTerm.MedicalRecord = this;
         }
      }
      
      /// <summary>
      /// Remove an existing Term from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveTerm(Term oldTerm)
      {
         if (oldTerm == null)
            return;
         if (this.term != null)
            if (this.term.Contains(oldTerm))
            {
               this.term.Remove(oldTerm);
               oldTerm.MedicalRecord = null;
            }
      }
      
      /// <summary>
      /// Remove all instances of Term from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllTerm()
      {
         if (term != null)
         {
            System.Collections.ArrayList tmpTerm = new System.Collections.ArrayList();
            foreach (Term oldTerm in term)
               tmpTerm.Add(oldTerm);
            term.Clear();
            foreach (Term oldTerm in tmpTerm)
               oldTerm.MedicalRecord = null;
            tmpTerm.Clear();
         }
      }
   
   }
}