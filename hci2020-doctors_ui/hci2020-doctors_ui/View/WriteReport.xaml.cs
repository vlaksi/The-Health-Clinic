using hci2020_doctors_ui.ViewModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace hci2020_doctors_ui.View
{
    /// <summary>
    /// Interaction logic for WriteReport.xaml
    /// </summary>
    public partial class WriteReport : UserControl
    {
        public WriteReport()
        {
            InitializeComponent();
        }
        private void UIElement_OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private async void patientRecord_Click(object sender, RoutedEventArgs e)
        {
            await Task.Delay(250);
            (Window.GetWindow(this) as MainWindow).MainFrameContent.Content = new PatientProfile();
            (Window.GetWindow(this) as MainWindow).DataContext = new PatientsProfileViewModel(HomeViewModel.Instance.Navigate);
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(purpose.Text))
            {
                System.Windows.Forms.MessageBox.Show("Please select purpose of the report.", "Purpose", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrEmpty(doctorsRemarks.Text))
            {
                System.Windows.Forms.MessageBox.Show("Please write your remarks.", "Remarks", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrEmpty(patientsRemarks.Text))
            {
                System.Windows.Forms.MessageBox.Show("Please write patient's report.", "Patient's report", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

            WriteReportViewModel.Instance.SubmitCommand.Execute("");
            System.Windows.Forms.MessageBox.Show("Successfuly submitted a new report!", "Report Submitted", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
        }
    }
}
