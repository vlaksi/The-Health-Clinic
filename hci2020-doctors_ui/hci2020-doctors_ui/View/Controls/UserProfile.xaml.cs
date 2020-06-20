using hci2020_doctors_ui.ViewModel;
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

namespace hci2020_doctors_ui.View.Controls
{
    /// <summary>
    /// Interaction logic for UserProfile.xaml
    /// </summary>
    public partial class UserProfile : UserControl
    {
        public UserProfile()
        {
            InitializeComponent();
        }

        private void settings_mouseDown(object sender, MouseButtonEventArgs e)
        {
            (Window.GetWindow(this) as MainWindow).MainFrameContent.Content = new Settings();
            (Window.GetWindow(this) as MainWindow).DataContext = SettingsViewModel.Instance;
        }
    }
}
