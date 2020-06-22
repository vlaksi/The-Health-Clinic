// File:    UserDTO.cs
// Author:  Filip Zukovic
// Created: Wednesday, May 20, 2020 5:04:06 PM
// Purpose: Definition of Class UserDTO

using System;

namespace Model.Users
{
   public class UserDTO
   {
      private String Username;
      private String Password;
      private String RepeatPassword;
      private String Name;
      private String Surname;
      private String Email;
      
      public String _Username
      {
         get
         {
            return Username;
         }
         set
         {
            this.Username = value;
         }
      }
      
      public String _Password
      {
         get
         {
            return Password;
         }
         set
         {
            this.Password = value;
         }
      }
      
      public String _RepeatPassword
      {
         get
         {
            return RepeatPassword;
         }
         set
         {
            this.RepeatPassword = value;
         }
      }
      
      public String _Name
      {
         get
         {
            return Name;
         }
         set
         {
            this.Name = value;
         }
      }
      
      public String _Surname
      {
         get
         {
            return Surname;
         }
         set
         {
            this.Surname = value;
         }
      }
      
      public String _Email
      {
         get
         {
            return Email;
         }
         set
         {
            this.Email = value;
         }
      }
   
   }
}