using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hci2020_doctors_ui.Model
{
    public class CommentModel : ObservableObject
    {
		private string content;

		public string Content
		{
			get { return content; }
			set { content = value; }
		}

		private DateTime publishDate;

		public DateTime PublishDate
		{
			get { return publishDate; }
			set { publishDate = value; }
		}

		private UserModel user;

		public UserModel User
		{
			get { return user; }
			set { user = value; }
		}



	}
}
