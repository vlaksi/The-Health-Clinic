// File:    Review.cs
// Author:  Vaxi
// Created: Thursday, April 2, 2020 4:48:58 PM
// Purpose: Definition of Class Review

using System;

namespace Model.Patient
{
   public class Review
   {
      private System.DateTime publishDate;
      private String comment;
      private int rating;
      
      public System.DateTime PublishDate
      {
         get
         {
            return publishDate;
         }
         set
         {
            this.publishDate = value;
         }
      }
      
      public String Comment
      {
         get
         {
            return comment;
         }
         set
         {
            this.comment = value;
         }
      }
      
      public int Rating
      {
         get
         {
            return rating;
         }
         set
         {
            this.rating = value;
         }
      }
      
      public Model.Users.PatientModel[] patient;
   
   }
}