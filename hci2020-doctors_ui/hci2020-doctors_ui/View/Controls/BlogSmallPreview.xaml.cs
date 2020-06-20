using hci2020_doctors_ui.Model;
using hci2020_doctors_ui.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace hci2020_doctors_ui.View.Controls
{
    /// <summary>
    /// Interaction logic for BlogSmallPreview.xaml
    /// </summary>
    public partial class BlogSmallPreview : UserControl
    {
        public static readonly DependencyProperty BlogProperty = DependencyProperty.Register("Blog", typeof(BlogPostModel), typeof(BlogSmallPreview), new FrameworkPropertyMetadata(null));
        public BlogPostModel Blog
        {
            get { return (BlogPostModel)GetValue(BlogProperty); }
            set { SetValue(BlogProperty, value); }
        }

        private string author;

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }




        public BlogSmallPreview()
        {
            InitializeComponent();
            DataContext = BlogHomeViewModel.Instance;
        }
    }
}
