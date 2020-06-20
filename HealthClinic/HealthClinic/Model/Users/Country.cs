// File:    Country.cs
// Author:  Vaxi
// Created: Wednesday, April 8, 2020 1:15:57 PM
// Purpose: Definition of Class Country

using System;

namespace Model.Users
{
   public class Country
   {
      private int name;
      
      public int Name
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
      
      public System.Collections.Generic.List<Residence> residence;
      
      /// <summary>
      /// Property for collection of Residence
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Residence> Residence
      {
         get
         {
            if (residence == null)
               residence = new System.Collections.Generic.List<Residence>();
            return residence;
         }
         set
         {
            RemoveAllResidence();
            if (value != null)
            {
               foreach (Residence oResidence in value)
                  AddResidence(oResidence);
            }
         }
      }
      
      /// <summary>
      /// Add a new Residence in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddResidence(Residence newResidence)
      {
         if (newResidence == null)
            return;
         if (this.residence == null)
            this.residence = new System.Collections.Generic.List<Residence>();
         if (!this.residence.Contains(newResidence))
            this.residence.Add(newResidence);
      }
      
      /// <summary>
      /// Remove an existing Residence from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveResidence(Residence oldResidence)
      {
         if (oldResidence == null)
            return;
         if (this.residence != null)
            if (this.residence.Contains(oldResidence))
               this.residence.Remove(oldResidence);
      }
      
      /// <summary>
      /// Remove all instances of Residence from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllResidence()
      {
         if (residence != null)
            residence.Clear();
      }
   
   }
}