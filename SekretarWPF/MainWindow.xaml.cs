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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SekretarWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Window logInWindow;

        public MainWindow()
        {
            InitializeComponent();

            this.Visibility = Visibility.Hidden;
            logInWindow = new LogInWindow(this);
            logInWindow.Show();

            UserControl usc = new UserControlCalendar();
            GridMain.Children.Add(usc);
            }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemCalendar":
                    usc = new UserControlCalendar();
                    GridMain.Children.Clear();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemPatients":
                    usc = new UserControlPatients();
                    GridMain.Children.Clear();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemProfile":
                    usc = new UserControlProfile();
                    GridMain.Children.Clear();
                    GridMain.Children.Add(usc);
                    break;
                
                default:
                    break;
            }
        }

        private void LogOut_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            bool? Result = new MessageBoxCustom("Log out from system?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();

            if (Result.Value)
            {
                this.Visibility = Visibility.Hidden;
                this.logInWindow.Visibility = Visibility.Visible;
            }
        }
    }
}
