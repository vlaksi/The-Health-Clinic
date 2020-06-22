// File:    Comment.cs
// Author:  Vaxi
// Created: Wednesday, April 1, 2020 7:47:22 PM
// Purpose: Definition of Class Comment

using System;

namespace Model.BlogPost
{
   public class Comment
   {
      private String content;
      private System.DateTime publishDate;
      
      public String Content
      {
         get
         {
            return content;
         }
         set
         {
            this.content = value;
         }
      }
      
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
      
      public Model.Users.RegisteredUser registeredUser;
   
   }
}