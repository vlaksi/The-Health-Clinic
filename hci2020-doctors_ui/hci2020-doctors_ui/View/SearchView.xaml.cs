using hci2020_doctors_ui.ViewModel;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace hci2020_doctors_ui.View
{
    /// <summary>
    /// Interaction logic for SearchView.xaml
    /// </summary>
    public partial class SearchView : UserControl
    {
        public SearchView()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            (Window.GetWindow(this) as MainWindow).DataContext = new PatientsProfileViewModel(SearchViewModel.Instance.Navigate);
            (Window.GetWindow(this) as MainWindow).MainFrameContent.Content = new PatientProfile();
        }

    }
}
