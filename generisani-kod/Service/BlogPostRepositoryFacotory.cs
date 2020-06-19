// File:    BlogPostRepositoryFacotory.cs
// Author:  Filip Zukovic
// Created: Friday, May 29, 2020 6:15:47 PM
// Purpose: Definition of Interface BlogPostRepositoryFacotory

using System;

namespace Service
{
   public interface BlogPostRepositoryFacotory
   {
      BlogPostRepository CreateBlogPostRepository();
   
   }
}