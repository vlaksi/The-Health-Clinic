// File:    Ingredient.cs
// Author:  Igorr
// Created: Friday, April 17, 2020 12:19:37 AM
// Purpose: Definition of Class Ingredient

using System;

namespace Model.Medicine
{
   public class Ingredient
   {
      private String code;
      private String name;
      
      public String Code
      {
         get
         {
            return code;
         }
         set
         {
            this.code = value;
         }
      }
      
      public String Name
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
   
   }
}