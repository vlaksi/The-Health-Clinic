// File:    Residence.cs
// Author:  Vaxi
// Created: Wednesday, April 1, 2020 5:16:41 PM
// Purpose: Definition of Class Residence

using System;

namespace Model.Users
{
   public class Residence
   {
      private String name;
      private String municipality;
      private String address;
      private int flat;
      
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
      
      public String Municipality
      {
         get
         {
            return municipality;
         }
         set
         {
            this.municipality = value;
         }
      }
      
      public String Address
      {
         get
         {
            return address;
         }
         set
         {
            this.address = value;
         }
      }
      
      public int Flat
      {
         get
         {
            return flat;
         }
         set
         {
            this.flat = value;
         }
      }
   
   }
}