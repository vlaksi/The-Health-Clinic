using hci2020_doctors_ui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hci2020_doctors_ui.ViewModel
{
    public class BlogSmallPreviewViewModel
    {
		private BlogPostModel blog;

		public BlogPostModel Blog
		{
			get { return blog; }
			set { blog = value; }
		}

		private string title;

		public string Title
		{
			get { return title; }
			set { title = value; }
		}


	}
}
