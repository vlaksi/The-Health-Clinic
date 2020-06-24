// File:    BlogPostModel.cs
// Author:  Vaxi
// Created: Sunday, April 5, 2020 7:22:10 PM
// Purpose: Definition of Class BlogPostModel

using Model.Users;
using System;
using System.Collections.Generic;

namespace Model.BlogPost
{
    public class BlogPostModel
    {
        #region Attributes
        private string title;
        private string content;
        private DateTime datePublished;
        private DateTime dateLastEdited;
        private int id;
        private String type;
        private List<Comment> comment;
        private int doctor;
        #endregion

        #region Properties
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                this.title = value;
            }
        }

        public string Content
        {
            get
            {
                return content;
            }
            set
            {
                this.content = value;
            }
        }

        public DateTime DatePublished
        {
            get
            {
                return datePublished;
            }
            set
            {
                this.datePublished = value;
            }
        }

        public DateTime DateLastEdited
        {
            get
            {
                if (dateLastEdited == null) return datePublished;
                return dateLastEdited;
            }
            set
            {
                this.dateLastEdited = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                this.type = value;
            }
        }

        
        public List<Comment> Comment
        {
            get
            {
                if (comment == null)
                    comment = new List<Comment>();
                return comment;
            }
            set
            {
                RemoveAllComment();
                if (value != null)
                {
                    foreach (Comment oComment in value)
                        AddComment(oComment);
                }
            }
        }
        public int Doctor
        {
            get
            {
                return doctor;
            }
            set
            {
                doctor = value;
            }
        }
        #endregion

        #region Manipulating with Comments        
        public void AddComment(Comment newComment)
        {
            if (newComment == null)
                return;
            if (this.comment == null)
                this.comment = new System.Collections.Generic.List<Comment>();
            if (!this.comment.Contains(newComment))
                this.comment.Add(newComment);
        }

        public void RemoveComment(Comment oldComment)
        {
            if (oldComment == null)
                return;
            if (this.comment != null)
                if (this.comment.Contains(oldComment))
                    this.comment.Remove(oldComment);
        }

        
        public void RemoveAllComment()
        {
            if (comment != null)
                comment.Clear();
        }
        #endregion
        

    }
}