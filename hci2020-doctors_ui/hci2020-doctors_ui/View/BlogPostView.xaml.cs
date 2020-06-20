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

namespace hci2020_doctors_ui.View
{
    /// <summary>
    /// Interaction logic for BlogPostView.xaml
    /// </summary>
    public partial class BlogPostView : UserControl
    {
        public BlogPostView()
        {
            InitializeComponent();
        }

        private void WriteBlogPost_Click(object sender, RoutedEventArgs e)
        {
            (Window.GetWindow(this) as MainWindow).MainFrameContent.Content = new WriteBlogPost();
            (Window.GetWindow(this) as MainWindow).DataContext = new WriteBlogPostViewModel();
        }
    }
}
