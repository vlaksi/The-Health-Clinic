// File:    Alergen.cs
// Author:  Vaxi
// Created: Friday, April 17, 2020 12:19:37 AM
// Purpose: Definition of Class Alergen

using System;

namespace Model.Medicine
{
   public class Alergen
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