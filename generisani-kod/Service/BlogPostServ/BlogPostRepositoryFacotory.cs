// File:    BlogPostRepositoryFacotory.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 6:15:47 PM
// Purpose: Definition of Interface BlogPostRepositoryFacotory

using System;

namespace Service.BlogPostServ
{
   public interface BlogPostRepositoryFacotory
   {
      BlogPostRepository CreateBlogPostRepository();
   
   }
}