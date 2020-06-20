using hci2020_doctors_ui.Model;
using hci2020_doctors_ui.ViewModel;
using Syncfusion.UI.Xaml.Schedule;
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

namespace hci2020_doctors_ui.View
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class CalendarView : UserControl
    {
        CustomEditor customEditor;
        double XPosition;
        double YPosition;
        Appointment copiedAppointment;
        public Appointment Appointment { get; set; }
        public DateTime CurrentSelectedDate { get; set; }

        public CalendarView()
        {
            InitializeComponent();
            DataContext = CalendarViewModel.Instance;
            customEditor = new CustomEditor();
            customEditor.Owner = Window.GetWindow(this) as MainWindow;
            customEditor.DataContext = this.DataContext;
        }

        void Schedule_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            XPosition = e.GetPosition(this).X;
            YPosition = e.GetPosition(this).Y;
        }

        void Schedule_AppointmentEditorOpening(object sender, AppointmentEditorOpeningEventArgs e)
        {
            e.Cancel = true;
            if (e.Action == EditorAction.Add)
            {
                CalendarViewModel.Instance.StartTime = e.StartTime;
                CalendarViewModel.Instance.EndTime = e.StartTime;
                this.AddnewAppointment(new Appointment() { StartTime = e.StartTime, EndTime = e.StartTime });
            }
            else
                this.EditAppointment(e.Appointment as Appointment);
        }

        private void EditAppointment(Appointment appointment)
        {

            CalendarViewModel.Instance.Appointment = appointment;   //Ovaj brisemo iz liste
            CalendarViewModel.Instance.EditMode = true;   //Ovaj brisemo iz liste
            CalendarViewModel.Instance.StartDate = appointment.StartTime;
            CalendarViewModel.Instance.StartTime = appointment.StartTime;
            CalendarViewModel.Instance.EndTime = appointment.EndTime;
            CalendarViewModel.Instance.Location = appointment.Location;
            CalendarViewModel.Instance.Patient = appointment.Patient;
            CalendarViewModel.Instance.Apptype = appointment.AppointmentType;
            customEditor.EditAppointment();
            customEditor.ShowDialog();
        }

        private void AddnewAppointment(Appointment newappointment)
        {
            customEditor.AddAppointment();
        }


        void pasteButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.copiedAppointment != null)
            {
                Appointment app = this.copiedAppointment;
                TimeSpan appTimeDiff = app.EndTime - app.StartTime;
                Appointment appointment = new Appointment
                {
                    Subject = app.Subject,
                    Location = app.Location,
                    AppointmentType = app.AppointmentType,
                    AppointmentBackground = CalendarViewModel.SetBackground(app.AppointmentType),
                    AppointmentStartTime = app.AppointmentStartTime,
                    AppointmentEndTime = ((DateTime)this.CurrentSelectedDate.Add(appTimeDiff)).ToString("hh:mm tt"),
                    StartTime = (DateTime)this.CurrentSelectedDate,
                    EndTime = ((DateTime)this.CurrentSelectedDate).Add(appTimeDiff),
                    Patient = app.Patient
                };

                CalendarViewModel.Instance.PasteCommand.Execute(appointment);
            }
        }

        void copyButton_Click(object sender, RoutedEventArgs e)
        {
            copiedAppointment = (Appointment)Schedule.SelectedAppointment;            
        }

        void editButton_Click(object sender, RoutedEventArgs e)
        {
            customEditor.EditAppointment();
            this.EditAppointment(this.Schedule.SelectedAppointment as Appointment);
        }

        void addButton_Click(object sender, RoutedEventArgs e)
        {
            customEditor.AddAppointment();
            if (CurrentSelectedDate != null)
                this.AddnewAppointment(new Appointment() { StartTime = CurrentSelectedDate, EndTime = CurrentSelectedDate });
        }

        private void sideCalendar_DisplayDateChanged(object sender, CalendarDateChangedEventArgs e)
        {
            DateTime selectedDate = sideCalendar.DisplayDate;
            if (!Schedule.VisibleDates[0].Equals(selectedDate))
            {
                Schedule.MoveToDate(selectedDate);
            }
        }
        private void Schedule_VisibleDatesChanging(object sender, VisibleDatesChangingEventArgs e)
        {
            DateTime selectedDate = Schedule.VisibleDates[0];
            if (!sideCalendar.SelectedDate.Equals(selectedDate))
            {
                sideCalendar.SelectedDate = selectedDate;
            }
        }

        private void Schedule_AppointmentDeleting(object sender, AppointmentDeletingEventArgs e)
        {
            CalendarViewModel.Instance.DeleteCommand.Execute((Appointment)e.Appointment);
        }
    }
}
