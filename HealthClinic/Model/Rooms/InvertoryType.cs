// File:    InvertoryType.cs
// Author:  Vaxi
// Created: Friday, April 17, 2020 12:50:01 AM
// Purpose: Definition of Class InvertoryType

using System;

namespace Model.Rooms
{
   public class InvertoryType
   {
      private string name;
      private int quantity;
      
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
      
      public int Quantity
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
   
   }
}