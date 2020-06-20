
using hci2020_doctors_ui.ViewModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
namespace hci2020_doctors_ui.View
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Home : System.Windows.Controls.UserControl
    {
        public Home()
        {
            InitializeComponent();

        }

        private void PatientProfile_MouseDown(object sender, MouseButtonEventArgs e)
        {
           
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await Task.Delay(250);
            (Window.GetWindow(this) as MainWindow).DataContext = new PatientsProfileViewModel(HomeViewModel.Instance.Navigate);
            (Window.GetWindow(this) as MainWindow).MainFrameContent.Content = new PatientProfile();
        }

        private void ApproveMedicine_Click(object sender, RoutedEventArgs e)
        {
            //System.Windows.Forms.MessageBox.Show("Medicine successfully approved!", "Medicine Approved", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
        }

        private void DeclineMedicine_Click(object sender, RoutedEventArgs e)
        {
            //System.Windows.Forms.MessageBox.Show("Medicine successfully declined!", "Medicine Declined", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
        }
    }
}
