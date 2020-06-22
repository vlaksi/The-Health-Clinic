// File:    BlogPostController.cs
// Author:  Vaxi
// Created: Sunday, May 3, 2020 12:05:17 PM
// Purpose: Definition of Class BlogPostController

using System;
using System.Collections.Generic;
using Model.BlogPost;
using Service.BlogPostServ;

namespace Controller.BlogPostContr
{
   public class BlogPostController
   {
      public BlogPostService blogPostService;

      public BlogPostModel CreateBlogPost(BlogPostModel blogPost)
      {
         throw new NotImplementedException();
      }
      
      public BlogPostModel UpdateBlogPost(BlogPostModel blogPost)
      {
         throw new NotImplementedException();
      }
      
      public BlogPostModel GetBlogPost(BlogPostModel blogPost)
      {
         throw new NotImplementedException();
      }
      
      public bool DeleteBlogPost(BlogPostModel blogPost)
      {
         throw new NotImplementedException();
      }
      
      public Comment WriteComment(Comment comment, BlogPostModel blogPost)
      {
         throw new NotImplementedException();
      }
      
      public List<Comment> GetAllComments(BlogPostModel blogPost)
      {
         throw new NotImplementedException();
      }
      
      public bool DeleteComment(Comment comment)
      {
         throw new NotImplementedException();
      }
      
   
   }
}