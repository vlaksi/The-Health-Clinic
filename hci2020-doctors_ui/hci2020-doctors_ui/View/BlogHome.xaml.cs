using hci2020_doctors_ui.Model;
using hci2020_doctors_ui.View.Controls;
using hci2020_doctors_ui.ViewModel;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace hci2020_doctors_ui.View
{
    /// <summary>
    /// Interaction logic for BlogHome.xaml
    /// </summary>
    public partial class BlogHome : UserControl
    {
        public BlogHome()
        {
            InitializeComponent();
            DataContext = BlogHomeViewModel.Instance;
        }

        private void WriteBlogPost_Click(object sender, RoutedEventArgs e)
        {
            (Window.GetWindow(this) as MainWindow).MainFrameContent.Content = new WriteBlogPost();
            (Window.GetWindow(this) as MainWindow).DataContext = new WriteBlogPostViewModel();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            await Task.Delay(250);
            (Window.GetWindow(this) as MainWindow).MainFrameContent.Content = new BlogPostView();
            (Window.GetWindow(this) as MainWindow).DataContext = new BlogPostViewModel(BlogHomeViewModel.Instance.Navigate);
        }
    }
}
