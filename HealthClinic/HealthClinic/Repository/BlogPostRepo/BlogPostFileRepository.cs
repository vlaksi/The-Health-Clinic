// File:    BlogPostFileRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 5:16:42 PM
// Purpose: Definition of Class BlogPostFileRepository

using Model.BlogPost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repository.BlogPostRepo
{
    public class BlogPostFileRepository : BlogPostRepository
    {
        private string filePath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())))) + @"\HealthClinic\FileStorage\blogs.json";

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
            List<BlogPostModel> allBlogs = (List<BlogPostModel>)FindAll();
            return allBlogs.Count;
        }

        public void Delete(BlogPostModel entity)
        {
            DeleteById(entity.Id);
        }

        public void DeleteAll()
        {
            List<BlogPostModel> emptyList = new List<BlogPostModel>();
            SaveAll(emptyList);
        }

        public void DeleteById(int identificator)
        {
            List<BlogPostModel> allBlogs = (List<BlogPostModel>)FindAll();
            BlogPostModel toRemove = null;

            foreach (BlogPostModel blog in allBlogs)
                if (blog.Id == identificator)
                    toRemove = blog;

            if (toRemove != null)
            {
                allBlogs.Remove(toRemove);
                SaveAll(allBlogs);
            }
        }

        public bool ExistsById(int id)
        {
            List<BlogPostModel> allBlogs = (List<BlogPostModel>)FindAll();

            foreach (BlogPostModel blog in allBlogs)
                if (blog.Id == id)
                    return true;

            return false;
        }

        public IEnumerable<BlogPostModel> FindAll()
        {
            List<BlogPostModel> allBlogs = JsonConvert.DeserializeObject<List<BlogPostModel>>(File.ReadAllText(filePath));

            if (allBlogs == null) allBlogs = new List<BlogPostModel>();

            return allBlogs;
        }

        public BlogPostModel FindById(int id)
        {
            List<BlogPostModel> allBlogs = (List<BlogPostModel>)FindAll();

            foreach (BlogPostModel blog in allBlogs)
                if (blog.Id == id)
                    return blog;

            return null;
        }

        public void Save(BlogPostModel entity)
        {
            if (ExistsById(entity.Id))
            {
                Delete(entity);
            }
            else
            {
                entity.Id = GenerateId();
            }

            List<BlogPostModel> allBlogs = (List<BlogPostModel>)FindAll();
            allBlogs.Add(entity);
            SaveAll(allBlogs);
        }

        public int GenerateId()
        {
            int maxId = -1;
            List<BlogPostModel> allBlogs = (List<BlogPostModel>)FindAll();
            if (allBlogs.Count == 0) return 1;
            foreach (BlogPostModel blog in allBlogs)
            {
                if (blog.Id > maxId) maxId = blog.Id;
            }

            return maxId + 1;
        }

        public void SaveAll(IEnumerable<BlogPostModel> entities)
        {
            using (StreamWriter file = File.CreateText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, entities);
            }
        }

        public IEnumerable<BlogPostModel> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public void SaveComment(BlogPostModel blogPost, Comment comment)
        {
            blogPost.AddComment(comment);
            Save(blogPost);
        }

        public void DeleteComment(BlogPostModel blogPost, Comment comment)
        {
            foreach (Comment coms in blogPost.Comment)
            {
                if (coms.Equals(comment))
                {
                    blogPost.Comment.Remove(comment);
                    Save(blogPost);
                }
            }

        }
    }
}