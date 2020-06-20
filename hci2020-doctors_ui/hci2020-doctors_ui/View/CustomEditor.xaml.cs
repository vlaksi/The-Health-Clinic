using hci2020_doctors_ui.Model;
using hci2020_doctors_ui.ViewModel;
using Syncfusion.UI.Xaml.Schedule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace hci2020_doctors_ui.View
{
    /// <summary>
    /// Interaction logic for CustomEditor.xaml
    /// </summary>
    public partial class CustomEditor : Window
    {
        public CustomEditor()
        {
            InitializeComponent();
            this.DataContext = CalendarViewModel.Instance;
            this.Loaded += CustomEditor_Loaded;
            this.Closing += CustomEditor_Closing;
        }

        private void CustomEditor_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }

        private void CustomEditor_Loaded(object sender, RoutedEventArgs e)
        {
            this.apptype.ItemsSource = Enum.GetValues(typeof(AppointmentTypes));
            this.apptype.SelectedIndex = 0;
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Hidden;
            CalendarViewModel.Instance.DeleteCommand.Execute(CalendarViewModel.Instance.Appointment);
        }

        internal void EditAppointment()
        {
            this.Visibility = Visibility.Visible;
            this.delete.Visibility = Visibility.Visible;
        }

        internal void AddAppointment()
        {
            this.apptype.SelectedIndex = 0;
            this.Visibility = Visibility.Visible;
            this.delete.Visibility = Visibility.Collapsed;
        }

    }
}
