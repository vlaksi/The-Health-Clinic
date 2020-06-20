using hci2020_doctors_ui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hci2020_doctors_ui.ViewModel
{
    public class BlogPostViewModel : BaseViewModel
    {

        private BlogPostModel blogpost;

        private string commentContent;

        public string CommentContent
        {
            get { return commentContent; }
            set { commentContent = value; OnPropertyChanged("CommentContent"); }
        }


        public RelayCommand AddCommentCommand { get; set; }

        public void AddComment(object param) {
            
            BlogPost.Comments.Add(new CommentModel()
            {
                User = new UserModel()
                {
                    Name = "Petar Peric" //podesiti da trenutno ulogovani user dodaje komentar
                },
                Content = (string)param,
                PublishDate = DateTime.Now
            });
            CommentContent = "";
        }

        public BlogPostModel BlogPost
        {
            get { return  blogpost; }
            set {  blogpost = value; OnPropertyChanged("BlogPost"); }
        }

        public BlogPostViewModel(BlogPostModel bp)
        {
            BlogPost = bp;
            AddCommentCommand = new RelayCommand(AddComment);
        }
    }
}
