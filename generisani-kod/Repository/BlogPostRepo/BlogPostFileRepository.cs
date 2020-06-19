// File:    BlogPostFileRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 5:16:42 PM
// Purpose: Definition of Class BlogPostFileRepository

using System;

namespace Repository.BlogPostRepo
{
   public class BlogPostFileRepository<BlogPost,int> : BlogPostRepository where BlogPost : T
    where int : ID
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
   
   }
}