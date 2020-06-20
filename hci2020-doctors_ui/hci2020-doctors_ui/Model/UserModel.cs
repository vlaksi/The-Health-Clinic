using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hci2020_doctors_ui.Model
{
    public class UserModel : ObservableObject
    {
		private string email;

		public string Email
		{
			get { return email; }
			set { email = value; OnPropertyChanged("Email"); }
		}

		private string password;

		public string Password
		{
			get { return password; }
			set { password = value; OnPropertyChanged("Password"); }
		}

		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}



	}
}
