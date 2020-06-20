using hci2020_doctors_ui.Model;
using hci2020_doctors_ui.View;
using hci2020_doctors_ui.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace hci2020_doctors_ui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region ViewModels
        HomeViewModel homeViewModel;
        WritePrescriptionViewModel writePrescriptionViewModel;
        CalendarViewModel calendarViewModel;
        SearchViewModel searchViewModel;
        PatientsProfileViewModel patientsProfileViewModel;
        ScheduleViewModel scheduleViewModel;
        #endregion

        #region Views
        Home homeView;
        WritePrescription writePrescriptionView;
        CalendarView calendarView;
        #endregion


        public MainWindow()
        {
            // license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjU1MzMyQDMxMzgyZTMxMmUzMEJTZDFjUWlFNDJyMTZ2SWRNMEt5K2dHUmpEWmJEVHNrT1BaNENuTDBVR0E9");

            InitializeComponent();
            //Set up language dictionary
            ResourceDictionary dict = new ResourceDictionary();
            dict.Source = new Uri("..\\Resources\\StringResources.xaml", UriKind.Relative);
            Application.Current.Resources.MergedDictionaries.Add(dict);

            //Set up theme dictionary
            ResourceDictionary dict2 = new ResourceDictionary();
            dict2.Source = new Uri("..\\Resources\\LightTheme.xaml", UriKind.Relative);
            Application.Current.Resources.MergedDictionaries.Add(dict2);

            //Instantiate Views
            calendarView = new CalendarView();
            homeView = new Home();
            writePrescriptionView = new WritePrescription();

            //Instantiate VMs
            calendarViewModel = CalendarViewModel.Instance;
            homeViewModel = HomeViewModel.Instance;
            writePrescriptionViewModel = new WritePrescriptionViewModel(new PatientModel());
            searchViewModel = new SearchViewModel();
            patientsProfileViewModel = new PatientsProfileViewModel(new PatientModel());
            scheduleViewModel = new ScheduleViewModel();

            MainFrameContent.Content = homeView;
        }

        private void HomeView_Clicked(object sender, RoutedEventArgs e)
        {
            MainFrameContent.Content = homeView;
            DataContext = homeViewModel;
        }

        private void CalendarView_Clicked(object sender, RoutedEventArgs e)
        {
            MainFrameContent.Content = calendarView;
        }

        private void ScheduleView_Clicked(object sender, RoutedEventArgs e)
        {
            MainFrameContent.Content = new ScheduleView();
            DataContext = scheduleViewModel;
        }
        private void BlogHomeView_Clicked(object sender, RoutedEventArgs e)
        {
            MainFrameContent.Content = new BlogHome();
        }

        private void SearchView_Clicked(object sender, RoutedEventArgs e)
        {
            MainFrameContent.Content = new SearchView();
            DataContext = searchViewModel;
        }


        private void MinimizeApp(object sender, RoutedEventArgs e)
        {
            try
            {
                this.WindowState = WindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void CloseApp(object sender, RoutedEventArgs e)
        {
            try
            {
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AppWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //ranije iz nekog razloga nije ucitavao podatke na pocetnoj stranici. ovo rijesava taj problem.
            homeViewBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
        }

        
    }
}
