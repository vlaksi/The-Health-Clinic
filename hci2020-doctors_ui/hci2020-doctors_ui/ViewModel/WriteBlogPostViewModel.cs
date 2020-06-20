using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace hci2020_doctors_ui.ViewModel
{
    public class WriteBlogPostViewModel
    {

        public List<string> BlogPostTypeCollection { get; set; }
        public string SelectedBlogPostType { get; set; }
        public WriteBlogPostViewModel()
        {
            BlogPostTypeCollection = new List<string>()
            {
                "Lifestyle",
                "COVID-19",
                (string)Application.Current.Resources["GeneralHealthLabel"],
                (string)Application.Current.Resources["Dentist"],
                (string)Application.Current.Resources["EpidemiologistLabel"],
            };

            SelectedBlogPostType = "";
        }
    }
}
