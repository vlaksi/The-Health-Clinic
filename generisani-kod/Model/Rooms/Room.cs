// File:    Room.cs
// Author:  Vaxi
// Created: Wednesday, April 1, 2020 10:18:08 PM
// Purpose: Definition of Class Room

using System;

namespace Model.Rooms
{
   public class Room
   {
      private double size;
      private int number;
      private int floor;
      private bool full = false;
      
      public double Size
      {
         get
         {
            return size;
         }
         set
         {
            this.size = value;
         }
      }
      
      public int Number
      {
         get
         {
            return number;
         }
         set
         {
            this.number = value;
         }
      }
      
      public int Floor
      {
         get
         {
            return floor;
         }
         set
         {
            this.floor = value;
         }
      }
      
      public bool Full
      {
         get
         {
            return full;
         }
         set
         {
            this.full = value;
         }
      }
      
      public System.Collections.Generic.List<InventoryAmount> inventoryAmount;
      
      /// <summary>
      /// Property for collection of InventoryAmount
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<InventoryAmount> InventoryAmount
      {
         get
         {
            if (inventoryAmount == null)
               inventoryAmount = new System.Collections.Generic.List<InventoryAmount>();
            return inventoryAmount;
         }
         set
         {
            RemoveAllInventoryAmount();
            if (value != null)
            {
               foreach (InventoryAmount oInventoryAmount in value)
                  AddInventoryAmount(oInventoryAmount);
            }
         }
      }
      
      /// <summary>
      /// Add a new InventoryAmount in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddInventoryAmount(InventoryAmount newInventoryAmount)
      {
         if (newInventoryAmount == null)
            return;
         if (this.inventoryAmount == null)
            this.inventoryAmount = new System.Collections.Generic.List<InventoryAmount>();
         if (!this.inventoryAmount.Contains(newInventoryAmount))
            this.inventoryAmount.Add(newInventoryAmount);
      }
      
      /// <summary>
      /// Remove an existing InventoryAmount from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveInventoryAmount(InventoryAmount oldInventoryAmount)
      {
         if (oldInventoryAmount == null)
            return;
         if (this.inventoryAmount != null)
            if (this.inventoryAmount.Contains(oldInventoryAmount))
               this.inventoryAmount.Remove(oldInventoryAmount);
      }
      
      /// <summary>
      /// Remove all instances of InventoryAmount from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllInventoryAmount()
      {
         if (inventoryAmount != null)
            inventoryAmount.Clear();
      }
   
   }
}