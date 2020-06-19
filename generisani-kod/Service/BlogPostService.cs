// File:    BlogPostService.cs
// Author:  Igorr
// Created: Sunday, May 3, 2020 12:05:17 PM
// Purpose: Definition of Class BlogPostService

using System;

namespace Service
{
   public class BlogPostService
   {
      public BlogPost CreateBlogPost(BlogPost blogPost)
      {
         throw new NotImplementedException();
      }
      
      public BlogPost UpdateBlogPost(BlogPost blogPost)
      {
         throw new NotImplementedException();
      }
      
      public BlogPost GetBlogPost(BlogPost blogPost)
      {
         throw new NotImplementedException();
      }
      
      public bool DeleteBlogPost(BlogPost blogPost)
      {
         throw new NotImplementedException();
      }
      
      public Comment WriteComment(Comment comment, BlogPost blogPost)
      {
         throw new NotImplementedException();
      }
      
      public List<Comment> GetAllComents(BlogPost blogPost)
      {
         throw new NotImplementedException();
      }
      
      public bool DeleteComment(Comment comment)
      {
         throw new NotImplementedException();
      }
      
      public BlogPostRepositoryFacotory blogPostRepositoryFacotory;
   
   }
}