using SekretarWPF.Data;
using Syncfusion.UI.Xaml.Schedule;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows;
using Syncfusion.Pdf.Grid;
using System.Data;
using System.Windows.Automation;
using System.Threading;
using System.Windows.Media;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows.Media.Imaging;
using Model.Users;

namespace SekretarWPF
{
    public partial class UserControlCalendar : UserControl
    {

        CustomEditor customeEditor;
        public UserControlCalendar()
        {
            InitializeComponent();
            customeEditor = new CustomEditor(this.sfSchedule.Appointments, this.checkBoxCheckUp, this.checkBoxOperation);
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            customeEditor.Owner = window;
            this.checkBoxCheckUp.IsChecked = true;
            this.checkBoxOperation.IsChecked = true;
        }

        private void buttonDodaj_Click(object sender, RoutedEventArgs e)
        {
            this.AddnewAppointment(new Appointment());
        }

        void Schedule_AppointmentEditorOpening(object sender, AppointmentEditorOpeningEventArgs e)
        {
            e.Cancel = true;
            if (e.Action == EditorAction.Add)
            {
                this.AddnewAppointment(new Appointment() { StartTime = e.StartTime, EndTime = e.StartTime });
            }
            else
                this.EditAppointment(e.Appointment as Appointment);
        }

        private void EditAppointment(Appointment appointment)
        {
            customeEditor.Appointment = appointment;
            customeEditor.EditAppointment();
            customeEditor.ShowDialog();
        }

        private void AddnewAppointment(Appointment newappointment)
        {
            customeEditor.Appointment = newappointment;
            customeEditor.AddAppointment();
            if (customeEditor.ShowDialog() == true)
                this.sfSchedule.Appointments.Add(newappointment);
        }

        private void CalendarEdit_DateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DateTime selectedDate = datePicker.Date;
            if(!sfSchedule.VisibleDates[0].Equals(selectedDate))
            {
                sfSchedule.MoveToDate(selectedDate);
            }
        }

        private void sfSchedule_VisibleDatesChanging(object sender, VisibleDatesChangingEventArgs e)
        {
            DateTime selectedDate = sfSchedule.VisibleDates[0];
            if(!datePicker.Date.Equals(selectedDate))
            {
                datePicker.Date = selectedDate;
            }
        }

        private void CheckBox_Checked_CheckUp(object sender, RoutedEventArgs e)
        {
            foreach (Appointment appointment in DummyData.checkUps)
            {
                this.sfSchedule.Appointments.Add(appointment);
            }
        }

        private void CheckBox_Unchecked_CheckUp(object sender, RoutedEventArgs e)
        {
            foreach (Appointment appointment in DummyData.checkUps)
            {
                this.sfSchedule.Appointments.Remove(appointment);
            }
        }

        private void CheckBox_Checked_Operation(object sender, RoutedEventArgs e)
        {
            foreach (Appointment appointment in DummyData.operations)
            {
                this.sfSchedule.Appointments.Add(appointment);
            }
        }

        private void CheckBox_Unchecked_Operation(object sender, RoutedEventArgs e)
        {
            foreach (Appointment appointment in DummyData.operations)
            {
                this.sfSchedule.Appointments.Remove(appointment);
            }
        }

        private void sfSchedule_AppointmentDeleting(object sender, AppointmentDeletingEventArgs e)
        {
            Appointment appointment = e.Appointment as Appointment;
            if(appointment.AppointmentType == AppointmentTypes.CheckUp)
            {
                DummyData.removeCheckup(appointment);
            } else
            {
                DummyData.removeOpeation(appointment);
            }

        }
    }
}
