// File:    Treatment.cs
// Author:  Vaxi
// Created: Sunday, April 5, 2020 5:30:42 PM
// Purpose: Definition of Class Treatment

using HealthClinic.Utilities;
using System;

namespace Model.Medicine
{
   public class Treatment : ObservableObject
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
            this.dateTimeStart = value; OnPropertyChanged("DateTimeStart");
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
            this.dateTimeEnd = value; OnPropertyChanged("DateTimeEnd");
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
            this.instructions = value; OnPropertyChanged("Instructions");
            }
      }
      
      public Medicine[] medicine;
   
   }
}