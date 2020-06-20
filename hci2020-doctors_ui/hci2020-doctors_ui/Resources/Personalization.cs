using hci2020_doctors_ui.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace hci2020_doctors_ui.Resources
{
    public class Personalization
    {

        private static Personalization instance;

        public static Personalization Instance
        {
            get
            {
                if (instance == null) instance = new Personalization();
                return instance;
            }
            set { instance = value; }
        }


        public void ChangeLanguage()
        {
            ResourceDictionary dict = new ResourceDictionary();
            switch (SettingsViewModel.Instance.SelectedLanguage)
            {
                case "English":
                case "Engleski":
                    dict.Source = new Uri("..\\Resources\\StringResources.xaml", UriKind.Relative);
                    break;
                case "Serbian":
                case "Srpski":
                    dict.Source = new Uri("..\\Resources\\StringResources.sr.xaml", UriKind.Relative);
                    break;
                default:
                    dict.Source = new Uri("..\\Resources\\StringResources.xaml", UriKind.Relative);
                    break;
            }
            Application.Current.Resources.MergedDictionaries.Add(dict);
        }

        public void ChangeTheme()
        {
            ResourceDictionary dict = new ResourceDictionary();
            if (SettingsViewModel.Instance.IsEnabled)
            {
                dict.Source = new Uri("..\\Resources\\DarkTheme.xaml", UriKind.Relative);
            }
            else
            {
                dict.Source = new Uri("..\\Resources\\LightTheme.xaml", UriKind.Relative);
            }
            Application.Current.Resources.MergedDictionaries.Add(dict);
        }
    }
}
