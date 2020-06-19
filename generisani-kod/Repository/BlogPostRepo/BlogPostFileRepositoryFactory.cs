// File:    BlogPostFileRepositoryFactory.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 6:19:05 PM
// Purpose: Definition of Class BlogPostFileRepositoryFactory

using System;

namespace Repository.BlogPostRepo
{
   public class BlogPostFileRepositoryFactory : BlogPostRepositoryFacotory
   {
      public BlogPostRepository CreateBlogPostRepository()
      {
         throw new NotImplementedException();
      }
   
   }
}