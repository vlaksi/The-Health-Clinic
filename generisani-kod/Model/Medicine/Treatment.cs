// File:    Treatment.cs
// Author:  Vaxi
// Created: Sunday, April 5, 2020 5:30:42 PM
// Purpose: Definition of Class Treatment

using System;

namespace Model.Medicine
{
   public class Treatment
   {
      private System.DateTime dateTimeStart;
      private System.DateTime dateTimeEnd;
      private String instructions;
      
      public System.DateTime DateTimeStart
      {
         get
         {
            return dateTimeStart;
         }
         set
         {
            this.dateTimeStart = value;
         }
      }
      
      public System.DateTime DateTimeEnd
      {
         get
         {
            return dateTimeEnd;
         }
         set
         {
            this.dateTimeEnd = value;
         }
      }
      
      public String Instructions
      {
         get
         {
            return instructions;
         }
         set
         {
            this.instructions = value;
         }
      }
      
      public Medicine[] medicine;
   
   }
}