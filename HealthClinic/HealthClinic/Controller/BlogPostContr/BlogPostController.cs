// File:    BlogPostController.cs
// Author:  Vaxi
// Created: Sunday, May 3, 2020 12:05:17 PM
// Purpose: Definition of Class BlogPostController

using System;
using System.Collections.Generic;
using Model.BlogPost;
using Service.BlogPostServ;

namespace Controller.BlogPostContr
{
    public class BlogPostController
    {
        public BlogPostService blogPostService = new BlogPostService();

        public List<BlogPostModel> GetAllBlogPosts()
        {
            return blogPostService.GetAllBlogPosts();
        }

        public void CreateBlogPost(BlogPostModel blogPost)
        {
            blogPostService.CreateBlogPost(blogPost);
        }

        public void UpdateBlogPost(BlogPostModel blogPost)
        {
            blogPostService.UpdateBlogPost(blogPost);
        }

        public BlogPostModel GetBlogPostById(int id)
        {
            return blogPostService.GetBlogPostById(id);
        }

        public bool DeleteBlogPostById(int id)
        {
            return blogPostService.DeleteBlogPostById(id);
        }

        public void WriteComment(Comment comment, BlogPostModel blogPost)
        {
            blogPostService.WriteComment(comment, blogPost);
        }

        public bool DeleteComment(BlogPostModel blogPost, Comment comment)
        {
            return blogPostService.DeleteComment(blogPost, comment);
        }

        public List<BlogPostModel> GetBlogPostsForDoctor(int id)
        {
            return blogPostService.GetBlogPostsForDoctor(id);
        }
    }
}