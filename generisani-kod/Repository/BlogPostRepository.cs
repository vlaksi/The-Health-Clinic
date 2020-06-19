// File:    BlogPostRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 7:05:47 PM
// Purpose: Definition of Interface BlogPostRepository

using System;

namespace Repository
{
   public interface BlogPostRepository : CRUDDao<T,ID>
   {
      List<Comment> GetComments(int blogPostId);
   
   }
}