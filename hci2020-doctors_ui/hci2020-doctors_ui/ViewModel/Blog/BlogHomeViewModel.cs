using hci2020_doctors_ui.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hci2020_doctors_ui.ViewModel
{
    public class BlogHomeViewModel : BaseViewModel
    {
        private static BlogHomeViewModel instance;
        public static BlogHomeViewModel Instance
        {
            get
            {
                if (instance == null)
                    instance = new BlogHomeViewModel();
                return instance;
            }
        }

        //ovome pristupamo i navigiramo toj stranici
        private BlogPostModel navigate;

        public BlogPostModel Navigate
        {
            get { return navigate; }
            set { navigate = value; }
        }



        public RelayCommand NavigateToBlogPost { get; set; }

        public void NavigateTo(object param)
        {
            string title = (string)param;
            Console.WriteLine("Title - " + title);
            foreach (BlogPostModel bp in Blogs)
            {
                if (bp.Title == title)
                {
                    Console.WriteLine("Found it!");
                    Navigate = bp;
                    return;
                }
            }
            if (coverBlog.Title == title)
            {
                Navigate = CoverBlog;
                return;
            }
        }

        public BlogHomeViewModel()
        {
            LoadBlogs();
            NavigateToBlogPost = new RelayCommand(NavigateTo);
        }

        public void LoadBlogs()
        {
            UserModel petarp = new UserModel()
            {
                Email = "petarperic@gmail.com",
                Name = "Petar Perić"
            };
            UserModel miroslavd = new UserModel()
            {
                Name = "Miroslav Đukić"
            };
            UserModel jelenai = new UserModel()
            {
                Name = "Jelena Ilić"
            };
            UserModel branislavi = new UserModel()
            {
                Name = "Branislav Ivanković"
            };
            UserModel aleksandras = new UserModel()
            {
                Name = "Aleksandra Stojanović"
            };

            CommentModel comment1 = new CommentModel()
            {
                User = petarp,
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed sed facilisis augue. Sed fringilla aliquam lobortis.",
                PublishDate = DateTime.Now
            };
            CommentModel comment2 = new CommentModel()
            {
                User = aleksandras,
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed sed facilisis augue. Sed fringilla aliquam lobortis.",
                PublishDate = DateTime.Now
            };
            CommentModel comment3 = new CommentModel()
            {
                User = miroslavd,
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed sed facilisis augue. Sed fringilla aliquam lobortis.",
                PublishDate = DateTime.Now
            };
            CommentModel comment4 = new CommentModel()
            {
                User = jelenai,
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed sed facilisis augue. Sed fringilla aliquam lobortis.",
                PublishDate = DateTime.Now
            };
            CommentModel comment5 = new CommentModel()
            {
                User = branislavi,
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed sed facilisis augue. Sed fringilla aliquam lobortis.",
                PublishDate = DateTime.Now
            };

            BlogPostModel blog1 = new BlogPostModel()
            {
                Title = "A Huge Breakthrough in Epidemiology",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed sed facilisis augue. Sed fringilla aliquam lobortis. Nunc suscipit sem quis est volutpat pharetra pulvinar a odio. Integer libero nibh, aliquam sit amet felis eget, consequat elementum quam. Nam scelerisque, orci at auctor vulputate, diam magna varius nisi, a imperdiet nibh arcu at arcu. \nInteger et felis ultrices, dapibus ipsum vitae, bibendum nisl. Quisque vel enim ipsum. Nulla cursus dolor vel ex rhoncus, in molestie sem pellentesque. Nunc aliquet posuere ante non ultricies. Nam justo felis, porta non sollicitudin id, venenatis ut felis. In massa eros, maximus ac elementum a, faucibus sit amet neque. In eu tristique elit, in finibus ipsum.\nLorem ipsum dolor sit amet, consectetur adipiscing elit. Sed sed facilisis augue. Sed fringilla aliquam lobortis. Nunc suscipit sem quis est volutpat pharetra pulvinar a odio. Integer libero nibh, aliquam sit amet felis eget, consequat elementum quam. Nam scelerisque, orci at auctor vulputate, diam magna varius nisi, a imperdiet nibh arcu at arcu. Integer et felis ultrices, dapibus ipsum vitae, bibendum nisl. Quisque vel enim ipsum. Nulla cursus dolor vel ex rhoncus, in molestie sem pellentesque. Nunc aliquet posuere ante non ultricies. Nam justo felis, porta non sollicitudin id, venenatis ut felis. In massa eros, maximus ac elementum a, faucibus sit amet neque. In eu tristique elit, in finibus ipsum.\nLorem ipsum dolor sit amet, consectetur adipiscing elit. Sed sed facilisis augue. Sed fringilla aliquam lobortis. Nunc suscipit sem quis est volutpat pharetra pulvinar a odio. Integer libero nibh, aliquam sit amet felis eget, consequat elementum quam. Nam scelerisque, orci at auctor vulputate, diam magna varius nisi, a imperdiet nibh arcu at arcu. Integer et felis ultrices, dapibus ipsum vitae, bibendum nisl. Quisque vel enim ipsum. Nulla cursus dolor vel ex rhoncus, in molestie sem pellentesque. Nunc aliquet posuere ante non ultricies. Nam justo felis, porta non sollicitudin id, venenatis ut felis. In massa eros, maximus ac elementum a, faucibus sit amet neque. In eu tristique elit, in finibus ipsum.",
                DisplayText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed sed facilisis augue. Sed fringilla aliquam lobortis. Nunc suscipit sem quis est volutpat pharetra pulvinar a odio...",
                DatePublished = DateTime.Now,
                Type = BlogType.Science,
                Author = "Petar Perić",
                Comments = new ObservableCollection<CommentModel>()
                {
                    comment2,comment3,comment4
                }
            };
            BlogPostModel blog2 = new BlogPostModel()
            {
                Title = "5 best practices for keeping your immunity strong",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed sed facilisis augue. Sed fringilla aliquam lobortis. Nunc suscipit sem quis est volutpat pharetra pulvinar a odio. Integer libero nibh, aliquam sit amet felis eget, consequat elementum quam. Nam scelerisque, orci at auctor vulputate, diam magna varius nisi, a imperdiet nibh arcu at arcu. Integer et felis ultrices, dapibus ipsum vitae, bibendum nisl. Quisque vel enim ipsum. Nulla cursus dolor vel ex rhoncus, in molestie sem pellentesque. Nunc aliquet posuere ante non ultricies. Nam justo felis, porta non sollicitudin id, venenatis ut felis. In massa eros, maximus ac elementum a, faucibus sit amet neque. In eu tristique elit, in finibus ipsum.",
                DatePublished = DateTime.Now,
                Type = BlogType.Lifestyle,
                Author = "Miroslav Đukić",
                Comments = new ObservableCollection<CommentModel>()
                {
                    comment1,comment5,comment4
                }
            };
            BlogPostModel blog3 = new BlogPostModel()
            {
                Title = "How to prevent Coronavirus by yourself",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed sed facilisis augue. Sed fringilla aliquam lobortis. Nunc suscipit sem quis est volutpat pharetra pulvinar a odio. Integer libero nibh, aliquam sit amet felis eget, consequat elementum quam. Nam scelerisque, orci at auctor vulputate, diam magna varius nisi, a imperdiet nibh arcu at arcu. Integer et felis ultrices, dapibus ipsum vitae, bibendum nisl. Quisque vel enim ipsum. Nulla cursus dolor vel ex rhoncus, in molestie sem pellentesque. Nunc aliquet posuere ante non ultricies. Nam justo felis, porta non sollicitudin id, venenatis ut felis. In massa eros, maximus ac elementum a, faucibus sit amet neque. In eu tristique elit, in finibus ipsum.",
                DatePublished = DateTime.Now,
                Type = BlogType.COVID19,
                Author = "Jelena Ilić",
                Comments = new ObservableCollection<CommentModel>()
                {
                    comment3,comment5,comment1
                }

            };
            BlogPostModel blog4 = new BlogPostModel()
            {
                Title = "Viruses Crash Course from a Lead Virusologist",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed sed facilisis augue. Sed fringilla aliquam lobortis. Nunc suscipit sem quis est volutpat pharetra pulvinar a odio. Integer libero nibh, aliquam sit amet felis eget, consequat elementum quam. Nam scelerisque, orci at auctor vulputate, diam magna varius nisi, a imperdiet nibh arcu at arcu. Integer et felis ultrices, dapibus ipsum vitae, bibendum nisl. Quisque vel enim ipsum. Nulla cursus dolor vel ex rhoncus, in molestie sem pellentesque. Nunc aliquet posuere ante non ultricies. Nam justo felis, porta non sollicitudin id, venenatis ut felis. In massa eros, maximus ac elementum a, faucibus sit amet neque. In eu tristique elit, in finibus ipsum.",
                DatePublished = DateTime.Now,
                Type = BlogType.Science,
                Author = "Branislav Ivanković",
                Comments = new ObservableCollection<CommentModel>()
                {
                    comment3,comment1,comment5
                }
            };
            BlogPostModel blog5 = new BlogPostModel()
            {
                Title = "How to pick a perfect toothbrush for your teeth",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed sed facilisis augue. Sed fringilla aliquam lobortis. Nunc suscipit sem quis est volutpat pharetra pulvinar a odio. Integer libero nibh, aliquam sit amet felis eget, consequat elementum quam. Nam scelerisque, orci at auctor vulputate, diam magna varius nisi, a imperdiet nibh arcu at arcu. Integer et felis ultrices, dapibus ipsum vitae, bibendum nisl. Quisque vel enim ipsum. Nulla cursus dolor vel ex rhoncus, in molestie sem pellentesque. Nunc aliquet posuere ante non ultricies. Nam justo felis, porta non sollicitudin id, venenatis ut felis. In massa eros, maximus ac elementum a, faucibus sit amet neque. In eu tristique elit, in finibus ipsum.",
                DatePublished = DateTime.Now,
                Type = BlogType.Dentist,
                Author = "Aleksandra Stojanović",
                Comments = new ObservableCollection<CommentModel>()
                {
                    comment3,comment2,comment5
                }
            };

            CoverBlog = blog1;

            Blogs = new ObservableCollection<BlogPostModel>
            {
                blog2,
                blog3,
                blog4,
                blog5
            };
        }

        #region Properties
        private ObservableCollection<BlogPostModel> blogs;

        public ObservableCollection<BlogPostModel> Blogs
        {
            get { return blogs; }
            set { blogs = value; OnPropertyChanged("Blogs"); }
        }

        private BlogPostModel coverBlog;

        public BlogPostModel CoverBlog
        {
            get { return coverBlog; }
            set { coverBlog = value; }
        }
        #endregion
    }
}
