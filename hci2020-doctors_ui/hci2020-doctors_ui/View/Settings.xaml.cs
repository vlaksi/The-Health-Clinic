using hci2020_doctors_ui.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace hci2020_doctors_ui.View
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string email = emailField.Text;
            string password = passwordField.Text;
            string confirmPassword = confirmPasswordField.Text;

            List<string> parametres = new List<string>() { email, password, confirmPassword };

            Console.WriteLine("Clicked");
            SettingsViewModel.Instance.SaveChangesCommand.Execute(parametres);
        }
    }
}
