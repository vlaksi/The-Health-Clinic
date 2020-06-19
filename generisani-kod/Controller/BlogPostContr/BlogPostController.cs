// File:    BlogPostController.cs
// Author:  Vaxi
// Created: Sunday, May 3, 2020 12:05:17 PM
// Purpose: Definition of Class BlogPostController

using System;

namespace Controller.BlogPostContr
{
   public class BlogPostController
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
      
      public List<Comment> GetAllComments(BlogPost blogPost)
      {
         throw new NotImplementedException();
      }
      
      public bool DeleteComment(Comment comment)
      {
         throw new NotImplementedException();
      }
      
      public Service.BlogPostServ.BlogPostService blogPostService;
   
   }
}