// File:    BlogPostRepositoryFacotory.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 6:15:47 PM
// Purpose: Definition of Interface BlogPostRepositoryFacotory

using System;

namespace Repository.BlogPostRepo
{
   public interface BlogPostRepositoryFactory
   {
      BlogPostRepository CreateBlogPostRepository();
   
   }
}