using hci2020_doctors_ui.ViewModel;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace hci2020_doctors_ui.View
{
    /// <summary>
    /// Interaction logic for WritePrescription.xaml
    /// </summary>
    public partial class WritePrescription : UserControl
    {
        public WritePrescription()
        {
            InitializeComponent();
        }

        private async void patientProfile_click(object sender, RoutedEventArgs e)
        {
            await Task.Delay(250);
            (Window.GetWindow(this) as MainWindow).MainFrameContent.Content = new PatientProfile();
            (Window.GetWindow(this) as MainWindow).DataContext = new PatientsProfileViewModel(HomeViewModel.Instance.Navigate);
        }

        private void checkIfEmpty(object sender, RoutedEventArgs e)
        {
            if (medicineName.Text == "" || int.Parse(quantity.Text) == 0 || frequency.Text == "")
            {
                MessageBox.Show("Please fill in all the form fields.");
                frequency.Text = "";
                quantity.Text = "0";
            }
        }

        private void frequency_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            //Check if anything in the form is empty
            if(WritePrescriptionViewModel.Instance.PrescriptionMedicineCollection.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("Please add some medicines to the prescription before submitting.", "Add Medicines", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

            WritePrescriptionViewModel.Instance.SubmitCommand.Execute("");
            System.Windows.Forms.MessageBox.Show("Successfuly changed patient's therapy!", "Prescription Written", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
