// File:    BlogPostRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 7:05:47 PM
// Purpose: Definition of Interface BlogPostRepository

using System;

namespace Repository.BlogPostRepo
{
   public interface BlogPostRepository : Repository.GenericCRUD.GenericInterfaceCRUDDao<T,ID>
   {
      List<Comment> GetComments(int blogPostId);
   
   }
}