// File:    BlogPostService.cs
// Author:  Vaxi
// Created: Sunday, May 3, 2020 12:05:17 PM
// Purpose: Definition of Class BlogPostService

using System;
using System.Collections.Generic;
using Model.BlogPost;
using Repository.BlogPostRepo;

namespace Service.BlogPostServ
{
   public class BlogPostService
   {
      public BlogPostRepositoryFactory blogPostRepositoryFacotory;

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
      
      public List<Comment> GetAllComents(BlogPostModel blogPost)
      {
         throw new NotImplementedException();
      }
      
      public bool DeleteComment(Comment comment)
      {
         throw new NotImplementedException();
      }
      
   
   }
}