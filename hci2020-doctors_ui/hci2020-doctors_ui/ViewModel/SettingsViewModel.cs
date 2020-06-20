using hci2020_doctors_ui.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace hci2020_doctors_ui.ViewModel
{
    class SettingsViewModel : BaseViewModel, IDataErrorInfo
    {
        #region Properties
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged("Email"); }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged("Password"); }
        }

        private string selectedLanguage;

        public string SelectedLanguage
        {
            get { return selectedLanguage; }
            set { selectedLanguage = value; OnPropertyChanged("SelectedLanguage"); }
        }


        private string confirmPassword;

        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set { confirmPassword = value; OnPropertyChanged("ConfirmPassword"); }
        }

        private ObservableCollection<string> languages;

        public ObservableCollection<string> Languages
        {
            get
            {
                return new ObservableCollection<string>()
            {
                (string)Application.Current.Resources["Serbian"],
                (string)Application.Current.Resources["English"] };
            }
            set { languages = value; OnPropertyChanged("Languages"); }
        }

        private bool _enabled = false;
        public bool IsEnabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                _enabled = value;
                OnPropertyChanged("IsEnabled");
            }
        }
        #endregion
        #region Commands
        public RelayCommand SaveChangesCommand { get; set; }

        #endregion

        private static SettingsViewModel instance;

        public static SettingsViewModel Instance
        {
            get
            {
                if (instance == null)
                    instance = new SettingsViewModel();
                return instance;
            }
            set { instance = value; }
        }


        public SettingsViewModel()
        {
            Password = "";
            ConfirmPassword = "";
            Email = "peroperic@gmail.com";
            SelectedLanguage = "English";
            Languages = new ObservableCollection<string>()
            {
                (string)Application.Current.Resources["Serbian"],
                (string)Application.Current.Resources["English"],
            };
            this.PropertyChanged += PropertyChangedMethod;
        }

        private void PropertyChangedMethod(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "SelectedLanguage":
                    if (SelectedLanguage == "Serbian" || SelectedLanguage == "Srpski") Properties.Settings.Default.languageCode = "sr-Latn-RS";
                    if (SelectedLanguage == "English" || SelectedLanguage == "Engleski") Properties.Settings.Default.languageCode = "en-US";
                    Properties.Settings.Default.Save();
                    Console.WriteLine("Language changed!");
                    Personalization.Instance.ChangeLanguage();
                    WriteReportViewModel.Instance.CommonMedicalConditionsFiltered = new ObservableCollection<string>()
                    {
                (string)Application.Current.Resources["AlcoholLabel"],
                (string)Application.Current.Resources["StrokeLabel"],
                (string)Application.Current.Resources["Fever"],
                (string)Application.Current.Resources["Drug Dependence"],
                (string)Application.Current.Resources["Seizure(s) - Cerebral"],
                (string)Application.Current.Resources["Seizure(s) - Alcohol related"],
                (string)Application.Current.Resources["Heart Disease"],
                (string)Application.Current.Resources["Motor Function/Ability Impaired"],
                (string)Application.Current.Resources["Visual Acuity Impairment"],
                (string)Application.Current.Resources["Visual Field Impairment"],
                (string)Application.Current.Resources["Mental or Emotional Illness"],
                (string)Application.Current.Resources["Dementia or Alzheimer's"],
                (string)Application.Current.Resources["Sleep Apnea"],
                (string)Application.Current.Resources["Narcolepsy"],
                (string)Application.Current.Resources["Diabetes or Hypoglicemia"],
                (string)Application.Current.Resources["Blackout or Loss of Awareness"],
                (string)Application.Current.Resources["Bone or Join deformity"],
                (string)Application.Current.Resources["Loss of Memory"],
                (string)Application.Current.Resources["Skin Disease"],
                (string)Application.Current.Resources["Intestinal Troubles"],
                (string)Application.Current.Resources["Skin Disease"],
                (string)Application.Current.Resources["Swollen or Painful Joints"],
                (string)Application.Current.Resources["Chronic Cough"],
                (string)Application.Current.Resources["Car or Sea Sickness"],
                (string)Application.Current.Resources["Rapid Gain/Loss of Weight"]
            };
                    break;
                case "IsEnabled":
                    Console.WriteLine("Theme changed!");
                    Personalization.Instance.ChangeTheme();
                    break;
            }

        }

        public string Error { get { return null; } }
        public string this[string name]
        {
            get
            {
                string result = null;
                switch (name)
                {
                    case "ConfirmPassword":
                        if (!String.Equals(Password, ConfirmPassword))
                        {
                            result = "Passwords must match.";
                        }
                        break;
                }
                return result;
            }
        }
    }
}
