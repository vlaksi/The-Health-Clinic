using Controller.BlogPostContr;
using HealthClinic.Utilities;
using HelathClinicPatienteRole.Dialogs;
using HelathClinicPatienteRole.ViewModel.Commands;
using Model.BlogPost;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelathClinicPatienteRole.ViewModel
{
    class BlogViewModel : INotifyPropertyChanged
    {
        List<BlogPostModel> allBlogPosts;
        BlogPostController blogPostController;

        public BlogViewModel()
        {
            blogPostController = new BlogPostController();
            ProcitajViseDialogCommand = new RelayCommand(ProcitajViseDialog);

            allBlogPosts = blogPostController.GetAllBlogPosts();
            
        }

        public List<BlogPostModel> AllBlogPosts
        {
            get { return allBlogPosts; }
            set { allBlogPosts = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        #region Procitaj vise dialog

        public RelayCommand ProcitajViseDialogCommand { get; private set; }

        public void ProcitajViseDialog(object obj)
        {
            var s = new ProcitajVise();
            s.ShowDialog();

        }

        #endregion
    }
}
