// File:    BlogPostService.cs
// Author:  Vaxi
// Created: Sunday, May 3, 2020 12:05:17 PM
// Purpose: Definition of Class BlogPostService

using System;
using System.Collections.Generic;
using Model.BlogPost;
using Repository.BlogPostRepo;

namespace Service.BlogPostServ
{
    public class BlogPostService
    {
        public BlogPostRepositoryFactory blogPostRepositoryFactory;
        public BlogPostFileRepository blogPostFileRepository = new BlogPostFileRepository();

        public void CreateBlogPost(BlogPostModel blogPost)
        {
            blogPostFileRepository.Save(blogPost);
        }

        public List<BlogPostModel> GetAllBlogPosts()
        {
            return (List<BlogPostModel>)blogPostFileRepository.FindAll();
        }

        public void UpdateBlogPost(BlogPostModel blogPost)
        {
            blogPostFileRepository.Save(blogPost);
        }

        public BlogPostModel GetBlogPostById(int id)
        {
            return blogPostFileRepository.FindById(id);
        }

        public bool DeleteBlogPostById(int id)
        {
            blogPostFileRepository.DeleteById(id);
            return true;
        }


        public void WriteComment(Comment comment, BlogPostModel blogPost)
        {
            blogPostFileRepository.SaveComment(blogPost, comment);
        }


        public bool DeleteComment(BlogPostModel blogPost, Comment comment)
        {
            blogPostFileRepository.DeleteComment(blogPost, comment);
            return true;
        }


    }
}