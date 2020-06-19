// File:    BlogPostRepositoryFacotory.cs
// Author:  Pufke
// Created: Friday, May 29, 2020 6:15:47 PM
// Purpose: Definition of Interface BlogPostRepositoryFacotory

using System;

namespace Repository
{
   public interface BlogPostRepositoryFacotory
   {
      BlogPostRepository CreateBlogPostRepository();
   
   }
}