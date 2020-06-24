// File:    BlogPostRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 7:05:47 PM
// Purpose: Definition of Interface BlogPostRepository

using System;
using System.Collections.Generic;
using Model.BlogPost;
using Repository.GenericCRUD;

namespace Repository.BlogPostRepo
{
   public interface BlogPostRepository : GenericInterfaceCRUDDao<BlogPostModel,int>
   {
        void SaveComment(BlogPostModel blogPost, Comment comment);
        void DeleteComment(BlogPostModel blogPost, Comment comment);
   }
}