// File:    BlogPostFileRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 5:16:42 PM
// Purpose: Definition of Class BlogPostFileRepository

using Model.BlogPost;
using System;
using System.Collections.Generic;

namespace Repository.BlogPostRepo
{
    public class BlogPostFileRepository : BlogPostRepository
    {
        private string filePath;

        public List<Comment> GetComments(int blogPostId)
        {
            throw new NotImplementedException();
        }

        public void OpenFile()
        {
            throw new NotImplementedException();
        }

        public void CloseFile()
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(BlogPostModel entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int identificator)
        {
            throw new NotImplementedException();
        }

        public bool ExistsById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BlogPostModel> FindAll()
        {
            throw new NotImplementedException();
        }

        public BlogPostModel FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(BlogPostModel entity)
        {
            throw new NotImplementedException();
        }

        public void SaveAll(IEnumerable<BlogPostModel> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BlogPostModel> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}