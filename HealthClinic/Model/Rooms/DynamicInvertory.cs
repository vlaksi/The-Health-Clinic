// File:    DynamicInvertory.cs
// Author:  Vaxi
// Created: Friday, April 17, 2020 12:53:38 AM
// Purpose: Definition of Class DynamicInvertory

using System;

namespace Model.Rooms
{
   /// Inventar za koji se neki pacijent moze 'zauzimati'.
   public class DynamicInvertory : Invertory
   {
      private System.DateTime inUseFrom;
      private System.DateTime inUseTo;
      private DinamicInvertoryType dynamicInvertoryType;
      
      public System.DateTime InUseFrom
      {
         get
         {
            return inUseFrom;
         }
         set
         {
            this.inUseFrom = value;
         }
      }
      
      public System.DateTime InUseTo
      {
         get
         {
            return inUseTo;
         }
         set
         {
            this.inUseTo = value;
         }
      }
      
      public DinamicInvertoryType DynamicInvertoryType
      {
         get
         {
            return dynamicInvertoryType;
         }
         set
         {
            this.dynamicInvertoryType = value;
         }
      }
   
   }
}