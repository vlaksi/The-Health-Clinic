using Controller.BlogPostContr;
using Model.BlogPost;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Doctors_UI_Console
{
    public class BlogFunctionalities
    {

        private static BlogPostController blogPostController = new BlogPostController();

        public static void VisitBlog()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("\n~~~ Welcome to Health Clinic's Blog! ~~~~");
                Console.WriteLine("\t1. Preview blog posts");
                Console.WriteLine("\t2. Write new blog post");
                Console.WriteLine("\t3. Check your blog posts");
                Console.WriteLine("\t\tWhat do you wish to do? ");
                Console.Write("\t\t>> ");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        PreviewBlogs();
                        break;
                    case "2":
                        Console.Clear();
                        WriteBlogPost();
                        break;
                    case "3":
                        Console.Clear();
                        PreviewYourBlogPosts();
                        break;
                    case "x":
                        return;
                    default:
                        break;
                }
            }
        }

        private static void PreviewYourBlogPosts()
        {
            List<BlogPostModel> myBlogs = blogPostController.GetBlogPostsForDoctor(LoggedIn.doctorLoggedIn.Id);
            if (myBlogs.Count == 0)
            {
                Console.WriteLine("\t\tYou haven't written any blogs.");
                Thread.Sleep(3000);
                return;
            }
            else
            {
                Console.WriteLine("\t\tYour blog posts");
                //Dodati ispis ljekara
                foreach (BlogPostModel blog in myBlogs)
                {
                    PrintBlog(blog);
                }
            }
        }

        private static void WriteBlogPost()
        {
            // Napraviti staticko polje koji ce oznacavati trenutno ulogovanog doktora
            Console.WriteLine("\t~~~ Welcome, Petar Peric ~~~");
            //Console.WriteLine("\t~~~ Welcome, " + doctor.Name + " ~~~");
            Console.WriteLine("\tReady to write another blog post?");

            Console.Write("\n\tWhat's the title going to be? ");
            string title = Console.ReadLine();

            Console.Write("\tWhat's the topic of today's post? ");
            string type = Console.ReadLine();

            Console.WriteLine("\n\tHere's a place to share your thoughts. \\/ ");
            string content = Console.ReadLine();

            BlogPostModel blog = new BlogPostModel()
            {
                Title = title,
                Content = content,
                Type = type,
                DatePublished = DateTime.Now,
                //Doctor = 
            };

            blogPostController.CreateBlogPost(blog);
            Console.WriteLine("\t\tYour blog has been created! Check it out on home page.");
        }

        public static void PreviewBlogs()
        {
            List<BlogPostModel> allBlogPosts = blogPostController.GetAllBlogPosts();
            if (allBlogPosts.Count == 0)
            {
                Console.WriteLine("\t\tUnfortunately, there are no blog posts available.");
            }
            else
            {
                //Dodati ispis ljekara
                foreach (BlogPostModel blog in allBlogPosts)
                {
                    PrintBlog(blog);
                }
            }
        }

        #region Helpers
        public static void PrintBlog(BlogPostModel blog)
        {
            Console.WriteLine("\t~~~~~ " + blog.Title + " ~~~~~");
            Console.Write("\t\t\t\tTopic: " + blog.Type);
            Console.WriteLine(", by " + blog.Doctor);
            Console.WriteLine("\t\t\t\tPublished: " + blog.DatePublished.ToShortDateString());
            Console.WriteLine("\n" + blog.Content);
            if (blog.Comment.Count != 0)
            {
                Console.WriteLine("\n\tComments: ");
                foreach (Comment comment in blog.Comment)
                {
                    Console.WriteLine("\t\t" + comment.registeredUser.Name + " " + comment.PublishDate.ToShortDateString());
                    Console.WriteLine("\t\t" + comment.Content);
                }
            }
            else
            {
                Console.WriteLine("\n\t\tNo comments...");
            }
            Console.WriteLine("\n\n");
        }
        #endregion

    }
}