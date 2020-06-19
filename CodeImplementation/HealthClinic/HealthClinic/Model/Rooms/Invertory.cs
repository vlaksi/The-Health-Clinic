// File:    Invertory.cs
// Author:  Vaxi
// Created: Wednesday, April 1, 2020 10:21:26 PM
// Purpose: Definition of Class Invertory

using System;

namespace Model.Rooms
{
   public class Invertory
   {
      private int quantityInStorage;
      
      public int QuantityInStorage
      {
         get
         {
            return quantityInStorage;
         }
         set
         {
            this.quantityInStorage = value;
         }
      }
      
      public System.Collections.Generic.List<InvertoryType> invertoryType;
      
      /// <summary>
      /// Property for collection of InvertoryType
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<InvertoryType> InvertoryType
      {
         get
         {
            if (invertoryType == null)
               invertoryType = new System.Collections.Generic.List<InvertoryType>();
            return invertoryType;
         }
         set
         {
            RemoveAllInvertoryType();
            if (value != null)
            {
               foreach (InvertoryType oInvertoryType in value)
                  AddInvertoryType(oInvertoryType);
            }
         }
      }
      
      /// <summary>
      /// Add a new InvertoryType in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddInvertoryType(InvertoryType newInvertoryType)
      {
         if (newInvertoryType == null)
            return;
         if (this.invertoryType == null)
            this.invertoryType = new System.Collections.Generic.List<InvertoryType>();
         if (!this.invertoryType.Contains(newInvertoryType))
            this.invertoryType.Add(newInvertoryType);
      }
      
      /// <summary>
      /// Remove an existing InvertoryType from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveInvertoryType(InvertoryType oldInvertoryType)
      {
         if (oldInvertoryType == null)
            return;
         if (this.invertoryType != null)
            if (this.invertoryType.Contains(oldInvertoryType))
               this.invertoryType.Remove(oldInvertoryType);
      }
      
      /// <summary>
      /// Remove all instances of InvertoryType from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllInvertoryType()
      {
         if (invertoryType != null)
            invertoryType.Clear();
      }
   
   }
}