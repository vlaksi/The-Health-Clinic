using hci2020_doctors_ui.ViewModel;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace hci2020_doctors_ui.View
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            LoginViewModel vm = new LoginViewModel();
            DataContext = vm;
        }

        private async void Login_Clicked(object sender, RoutedEventArgs e)
        {
            await Task.Delay(200);
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void MinimizeApp(object sender, RoutedEventArgs e)
        {
            try
            {
                this.WindowState = WindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void CloseApp(object sender, RoutedEventArgs e)
        {
            try
            {
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            email.Focus();
            email.SelectAll();
        }
    }
}
