using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace hci2020_doctors_ui.View
{
    /// <summary>
    /// Interaction logic for Schedule.xaml
    /// </summary>
    public partial class ScheduleView : UserControl
    {
        public List<string> PatientList { get; set; }

        public ScheduleView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (doctor.Text == "" || patient.Text == "" || appointmenttype.Text == "" || specialty.Text == "" || room.Text == "" || (int)floor.SelectedValue == 0)
            {
                MessageBox.Show("Please fill in all the form fields.");
            }
        }
    }
}
