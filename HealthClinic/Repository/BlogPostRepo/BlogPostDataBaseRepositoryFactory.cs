// File:    BlogPostDataBaseRepositoryFactory.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 6:19:06 PM
// Purpose: Definition of Class BlogPostDataBaseRepositoryFactory

using System;

namespace Repository.BlogPostRepo
{
    public class BlogPostDataBaseRepositoryFactory : BlogPostRepositoryFactory
    {
        public BlogPostRepository CreateBlogPostRepository()
        {
            throw new NotImplementedException();
        }
    }
}