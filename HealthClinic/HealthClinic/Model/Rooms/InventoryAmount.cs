// File:    InventoryAmount.cs
// Author:  Vaxi
// Created: Wednesday, April 29, 2020 4:21:06 PM
// Purpose: Definition of Class InventoryAmount

using System;

namespace Model.Rooms
{
   public class InventoryAmount
   {
      private int quantity;
      
      public int QuantityOfThisInventory
      {
         get
         {
            return quantity;
         }
         set
         {
            this.quantity = value;
         }
      }
      
      public System.Collections.Generic.List<Invertory> invertory;
      
      /// <summary>
      /// Property for collection of Invertory
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Invertory> Invertory
      {
         get
         {
            if (invertory == null)
               invertory = new System.Collections.Generic.List<Invertory>();
            return invertory;
         }
         set
         {
            RemoveAllInvertory();
            if (value != null)
            {
               foreach (Invertory oInvertory in value)
                  AddInvertory(oInvertory);
            }
         }
      }
      
      /// <summary>
      /// Add a new Invertory in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddInvertory(Invertory newInvertory)
      {
         if (newInvertory == null)
            return;
         if (this.invertory == null)
            this.invertory = new System.Collections.Generic.List<Invertory>();
         if (!this.invertory.Contains(newInvertory))
            this.invertory.Add(newInvertory);
      }
      
      /// <summary>
      /// Remove an existing Invertory from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveInvertory(Invertory oldInvertory)
      {
         if (oldInvertory == null)
            return;
         if (this.invertory != null)
            if (this.invertory.Contains(oldInvertory))
               this.invertory.Remove(oldInvertory);
      }
      
      /// <summary>
      /// Remove all instances of Invertory from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllInvertory()
      {
         if (invertory != null)
            invertory.Clear();
      }
   
   }
}