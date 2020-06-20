using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace hci2020_doctors_ui.Model
{
    public class BlogPostModel : ObservableObject
    {

		public BlogPostModel()
		{
		}

		public string Title
		{
			get { return title; }
			set { title = value; OnPropertyChanged("Title"); }
		}
		public string Content
		{
			get { return content; }
			set { content = value; OnPropertyChanged("Content"); }
		}
		public DateTime DatePublished
		{
			get { return datePublished; }
			set { datePublished = value; }
		}
		public BlogType Type
		{
			get { return type; }
			set { type = value; }
		}

        /* Dodati komentare */
        public string Author
		{
			get { return author; }
			set { author = value; }
		}

		private string displayText;

		public string DisplayText
		{
			get { return displayText; }
			set { displayText = value; OnPropertyChanged("DisplayText"); }
		}

		private ObservableCollection<CommentModel> comments;

		public ObservableCollection<CommentModel> Comments
		{
			get { return comments; }
			set { comments = value; OnPropertyChanged("Comments"); }
		}



		private string title;
		private string content;
		private DateTime datePublished;
		private BlogType type;
		private string author;

	}
}
