// File:    RegisteredUser.cs
// Author:  Vaxi
// Created: Wednesday, April 1, 2020 9:43:16 PM
// Purpose: Definition of Class RegisteredUser

using System;

namespace Model.Users
{
   public class RegisteredUser : Person
   {
      private String username;
      private String[] password;
      private String photo;
      
      public String Photo
      {
         get
         {
            return photo;
         }
         set
         {
            this.photo = value;
         }
      }
      
      public String username;
      public String password;
      
      public Residence residence;
   
   }
}