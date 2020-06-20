using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace hci2020_doctors_ui.ViewModel
{
    public class LoginViewModel
    {
        private static LoginViewModel instance;

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public RelayCommand LoginCommand { get;set; }


        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login);
        }
        public static LoginViewModel Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoginViewModel();
                return instance;
            }
        }

        private void Login(object param)
        {
            try
            {
                MessageBox.Show("Successful login");
            }
            catch (Exception ex)
            {
                var pero = ex.Message;
                MessageBox.Show("Error ocurred while logging in.");
            }
        }
    }
}
