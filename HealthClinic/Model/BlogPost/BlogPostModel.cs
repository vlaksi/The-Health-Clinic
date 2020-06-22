// File:    BlogPostModel.cs
// Author:  Vaxi
// Created: Sunday, April 5, 2020 7:22:10 PM
// Purpose: Definition of Class BlogPostModel

using Model.Users;
using System;

namespace Model.BlogPost
{
   public class BlogPostModel
   {
      private String title;
      private String content;
      private DateTime datePublished;
      private DateTime dateLastEdited;
      private int id;
      private String type;
      private String cover;
      
      public String Title
      {
         get
         {
            return title;
         }
         set
         {
            this.title = value;
         }
      }
      
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
      
      public DateTime DatePublished
      {
         get
         {
            return datePublished;
         }
         set
         {
            this.datePublished = value;
         }
      }
      
      public DateTime DateLastEdited
      {
         get
         {
            return dateLastEdited;
         }
         set
         {
            this.dateLastEdited = value;
         }
      }
      
      public int Id
      {
         get
         {
            throw new NotImplementedException();
         }
         set
         {
            throw new NotImplementedException();
         }
      }
      
      public String Type
      {
         get
         {
            return type;
         }
         set
         {
            this.type = value;
         }
      }
      
      public String Cover
      {
         get
         {
            return cover;
         }
         set
         {
            this.cover = value;
         }
      }
      
      public System.Collections.Generic.List<Comment> comment;
      
      /// <summary>
      /// Property for collection of Comment
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Comment> Comment
      {
         get
         {
            if (comment == null)
               comment = new System.Collections.Generic.List<Comment>();
            return comment;
         }
         set
         {
            RemoveAllComment();
            if (value != null)
            {
               foreach (Comment oComment in value)
                  AddComment(oComment);
            }
         }
      }
      
      /// <summary>
      /// Add a new Comment in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddComment(Comment newComment)
      {
         if (newComment == null)
            return;
         if (this.comment == null)
            this.comment = new System.Collections.Generic.List<Comment>();
         if (!this.comment.Contains(newComment))
            this.comment.Add(newComment);
      }
      
      /// <summary>
      /// Remove an existing Comment from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveComment(Comment oldComment)
      {
         if (oldComment == null)
            return;
         if (this.comment != null)
            if (this.comment.Contains(oldComment))
               this.comment.Remove(oldComment);
      }
      
      /// <summary>
      /// Remove all instances of Comment from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllComment()
      {
         if (comment != null)
            comment.Clear();
      }
      public System.Collections.Generic.List<Doctor> doctor;
      
      /// <summary>
      /// Property for collection of Model.Users.Doctor
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Doctor> Doctor
      {
         get
         {
            if (doctor == null)
               doctor = new System.Collections.Generic.List<Doctor>();
            return doctor;
         }
         set
         {
            RemoveAllDoctor();
            if (value != null)
            {
               foreach (Model.Users.Doctor oDoctor in value)
                  AddDoctor(oDoctor);
            }
         }
      }
      
      /// <summary>
      /// Add a new Model.Users.Doctor in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddDoctor(Model.Users.Doctor newDoctor)
      {
         if (newDoctor == null)
            return;
         if (this.doctor == null)
            this.doctor = new System.Collections.Generic.List<Doctor>();
         if (!this.doctor.Contains(newDoctor))
            this.doctor.Add(newDoctor);
      }
      
      /// <summary>
      /// Remove an existing Model.Users.Doctor from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveDoctor(Model.Users.Doctor oldDoctor)
      {
         if (oldDoctor == null)
            return;
         if (this.doctor != null)
            if (this.doctor.Contains(oldDoctor))
               this.doctor.Remove(oldDoctor);
      }
      
      /// <summary>
      /// Remove all instances of Model.Users.Doctor from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllDoctor()
      {
         if (doctor != null)
            doctor.Clear();
      }
   
   }
}