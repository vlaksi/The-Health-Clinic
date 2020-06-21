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
using System.Windows.Shapes;

namespace SekretarWPF
{

    public partial class ChangePasswordDialog : Window
    {
        public ChangePasswordDialog()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        

        private void confirmPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(password.Password) && !string.IsNullOrEmpty(confirmPassword.Password))
            {
                if (password.Password.Equals(confirmPassword.Password))
                {
                    if(password.Password.Length < 8)
                    {
                        passError.Text = "Passwords must be at least 8 characters!";
                    } else
                    {
                        btnOk.IsEnabled = true;
                        passError.Visibility = Visibility.Hidden;
                        return;
                    }
                } else
                {
                    passError.Text = "Passwords does not match!";
                }
            } else
            {
                passError.Text = "Enter passwords!";
            }
            btnOk.IsEnabled = false;
            passError.Visibility = Visibility.Visible;
        }

        private void password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(password.Password) && !string.IsNullOrEmpty(confirmPassword.Password))
            {
                if (password.Password.Equals(confirmPassword.Password))
                {
                    if (password.Password.Length < 8)
                    {
                        passError.Text = "Passwords must be at least 8 characters!";
                    }
                    else
                    {
                        btnOk.IsEnabled = true;
                        passError.Visibility = Visibility.Hidden;
                        return;
                    }
                }
                else
                {
                    passError.Text = "Passwords does not match!";
                }
            }
            else
            {
                passError.Text = "Enter passwords!";
            }
            btnOk.IsEnabled = false;
            passError.Visibility = Visibility.Visible;
        }
    }
}
