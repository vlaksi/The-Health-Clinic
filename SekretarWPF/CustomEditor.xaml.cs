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
                DummyData.checkUps.Add(appointment);
                this.checkBoxCheckUp.IsChecked = true;
            }
            else
            {
                appointment.Specialist = ((ComboBoxItemAdv)cbSpecialist.SelectedItem).Content.ToString();
                appointment.OperatingRoom = ((ComboBoxItemAdv)cbOperatingRoom.SelectedItem).Content.ToString();
                DummyData.operations.Add(appointment);
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
                    DummyData.checkUps.Remove(this.Appointment);
                } else
                {
                    DummyData.operations.Remove(this.Appointment);
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

        public void demoMode()
        {
            var timer1a = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(1000) };
            timer1a.Start();
            timer1a.Tick += (sender, args) =>
            {
                timer1a.Stop();
                editstartmonth.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(211, 47, 47));
            };

            var timer2a = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(1500) };
            timer2a.Start();
            timer2a.Tick += (sender, args) =>
            {
                timer2a.Stop();
                editstartmonth.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
            };

            var timer3a = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(2000) };
            timer3a.Start();
            timer3a.Tick += (sender, args) =>
            {
                timer3a.Stop();
                editstarttime.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(211, 47, 47));
            };

            var timer4a = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(2500) };
            timer4a.Start();
            timer4a.Tick += (sender, args) =>
            {
                timer4a.Stop();
                editstarttime.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
            };

            var timer5a = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(3000) };
            timer5a.Start();
            timer5a.Tick += (sender, args) =>
            {
                timer5a.Stop();
                editendmonth.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(211, 47, 47));
            };

            var timer6a = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(3500) };
            timer6a.Start();
            timer6a.Tick += (sender, args) =>
            {
                timer6a.Stop();
                editendmonth.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
            };

            var timer7a = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(4000) };
            timer7a.Start();
            timer7a.Tick += (sender, args) =>
            {
                timer7a.Stop();
                editendtime.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(211, 47, 47));
            };

            var timer8a = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(4500) };
            timer8a.Start();
            timer8a.Tick += (sender, args) =>
            {
                timer8a.Stop();
                editendtime.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
            };

            var timer1 = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(5000) };
            timer1.Start();
            timer1.Tick += (sender, args) =>
            {
                timer1.Stop();
                cbPatient.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(211, 47, 47));
            };

            var timer2 = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(5500) };
            timer2.Start();
            timer2.Tick += (sender, args) =>
            {
                timer2.Stop();
                cbPatient.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
            };

            var timer3 = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(6000) };
            timer3.Start();
            timer3.Tick += (sender, args) =>
            {
                timer3.Stop();
                cbDoctor.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(211, 47, 47));
            };

            var timer4 = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(6500) };
            timer4.Start();
            timer4.Tick += (sender, args) =>
            {
                timer4.Stop();
                cbDoctor.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
            };

            var timer5 = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(7000) };
            timer5.Start();
            timer5.Tick += (sender, args) =>
            {
                timer5.Stop();
                cbOrdination.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(211, 47, 47));
            };

            var timer6 = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(7500) };
            timer6.Start();
            timer6.Tick += (sender, args) =>
            {
                timer6.Stop();
                cbOrdination.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
            };

            var timer7 = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(8000) };
            timer7.Start();
            timer7.Tick += (sender, args) =>
            {
                timer7.Stop();
                save.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(211, 47, 47));
            };

            var timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(8500) };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                timer.Stop();
                this.Close();
            };
            
        }
        
    }
}
