using SekretarWPF.Data;
using Syncfusion.UI.Xaml.Schedule;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SekretarWPF
{
    /// <summary>
    /// Interaction logic for CustomEditor.xaml
    /// </summary>
    public partial class CustomEditor : Window, INotifyPropertyChanged
    {

        private CheckBox checkBoxCheckUp;
        private CheckBox checkBoxOperations;

        public ScheduleAppointmentCollection Appointments { get; set; }

        private Appointment _appointment;
        public Appointment Appointment
        {
            get { return _appointment; }
            set
            {
                _appointment = value;
                this.OnPropertyChanged("Appointment");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public CustomEditor()
        {
            InitializeComponent();
            this.DataContext = this;
            this.Loaded += CustomEditor_Loaded;
            this.Closing += CustomEditor_Closing;
        }

        public CustomEditor(ScheduleAppointmentCollection appointments, CheckBox checkBoxCheckUps, CheckBox checkBoxOperations) : this()
        {
            this.Appointments = appointments;
            this.checkBoxCheckUp = checkBoxCheckUps;
            this.checkBoxOperations = checkBoxOperations;
        }

        private void CustomEditor_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }

        private void CustomEditor_Loaded(object sender, RoutedEventArgs e)
        {
            this.rbCheckUp.IsChecked = true;
        }

        private void OnPropertyChanged(String name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            Appointment appointment = this.Appointment;
            DateTime date = (DateTime)this.editstarttime.SelectedTime;
            appointment.StartTime = ((DateTime)this.editstartmonth.SelectedDate).Date.Add(new TimeSpan(date.Hour, date.Minute, date.Second));
            appointment.AppointmentTime = appointment.StartTime.ToString("hh:mm tt");
            DateTime date1 = (DateTime)this.editendtime.SelectedTime;
            appointment.EndTime = ((DateTime)this.editendmonth.SelectedDate).Date.Add(new TimeSpan(date1.Hour, date1.Minute, date1.Second));
            if (appointment.StartTime == appointment.EndTime)
                appointment.EndTime = appointment.EndTime.AddHours(1);

            appointment.AppointmentType = getSelectedType();

            SetImageForAppointment(appointment);
            SetColorForAppointment(appointment);


            appointment.Patient = ((ComboBoxItemAdv)cbPatient.SelectedItem).Content.ToString();

            if (appointment.AppointmentType == AppointmentTypes.CheckUp)
            {
                appointment.Doctor = ((ComboBoxItemAdv)cbDoctor.SelectedItem).Content.ToString();
                appointment.Ordination = ((ComboBoxItemAdv)cbOrdination.SelectedItem).Content.ToString();
                DummyData.saveCheckup(appointment);
                this.checkBoxCheckUp.IsChecked = true;
            }
            else
            {
                appointment.Specialist = ((ComboBoxItemAdv)cbSpecialist.SelectedItem).Content.ToString();
                appointment.OperatingRoom = ((ComboBoxItemAdv)cbOperatingRoom.SelectedItem).Content.ToString();
                DummyData.saveOperation(appointment);
                this.checkBoxOperations.IsChecked = true;
            }

            if (!this.Appointments.Contains(appointment))
            {
                this.Appointments.Add(appointment);

            }

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Hidden;
            if (this.Appointment != null)
            {
                this.Appointments.Remove(this.Appointment);
                if(this.Appointment.AppointmentType == AppointmentTypes.CheckUp)
                {
                    DummyData.removeCheckup(this.Appointment);
                } else
                {
                    DummyData.removeOpeation(this.Appointment);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        internal void EditAppointment()
        {
            setSelectedType();

            this.Visibility = Visibility.Visible;
            this.delete.Visibility = Visibility.Visible;
        }

        internal void AddAppointment()
        {
            this.rbCheckUp.IsChecked = true;

            this.cbPatient.SelectedIndex = 0;
            this.cbDoctor.SelectedIndex = 0;
            this.cbOrdination.SelectedIndex = 0;
            this.cbSpecialist.SelectedIndex = 0;
            this.cbOperatingRoom.SelectedIndex = 0;

            this.Visibility = Visibility.Visible;
            this.delete.Visibility = Visibility.Collapsed;
        }

        private AppointmentTypes getSelectedType()
        {
            bool operationChecked = this.rbOperation.IsChecked ?? false;

            if (operationChecked)
            {
                return AppointmentTypes.Operation;
            }
            else
            {
                return AppointmentTypes.CheckUp;
            }
        }

        private void setSelectedType()
        {
            if (this.Appointment.AppointmentType == AppointmentTypes.Operation)
            {
                this.rbOperation.IsChecked = true;
            }
            else
            {
                this.rbCheckUp.IsChecked = true;
            }
        }

        public void SetImageForAppointment(Appointment appointment)
        {
            switch (appointment.AppointmentType)
            {
                case AppointmentTypes.CheckUp:
                    {
                        appointment.AppointmentImageURI = new BitmapImage(new Uri("pack://application:,,,/SekretarWPF;Component/Assets/CheckUp.png"));
                        break;
                    }
                case AppointmentTypes.Operation:
                    {
                        appointment.AppointmentImageURI = new BitmapImage(new Uri("pack://application:,,,/SekretarWPF;Component/Assets/Operation.png"));
                        break;
                    }
            }
        }

        public void SetColorForAppointment(Appointment appointment)
        {
            switch (appointment.AppointmentType)
            {
                case AppointmentTypes.CheckUp:
                    {
                        appointment.AppointmentBackground = new SolidColorBrush(Color.FromRgb(211, 47, 47));
                        break;
                    }
                case AppointmentTypes.Operation:
                    {
                        appointment.AppointmentBackground = new SolidColorBrush(Color.FromRgb(56, 142, 60));
                        break;
                    }
            }
        }

        private void CheckUp_Checked(object sender, RoutedEventArgs e)
        {
            this.CheckUp_Panel.Visibility = Visibility.Visible;
            this.Operation_Panel.Visibility = Visibility.Collapsed;
        }

        private void Operation_Checked(object sender, RoutedEventArgs e)
        {
            this.CheckUp_Panel.Visibility = Visibility.Collapsed;
            this.Operation_Panel.Visibility = Visibility.Visible;
        }
        
    }
}
