using C_Validation_ByCustom;
using Controller.PatientContr;
using HelathClinicPatienteRole.ViewModel.Commands;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HelathClinicPatienteRole.ViewModel
{
    class LoginViewModel : ObservableObject
    {
        private string _username; // PAZI username je ustvari JMBG !!!
        private string _password;
        private string _name;
        private string _surname;
        private string _phoneNumber;
        private string _mail;
        private PatientController patientController;
        private static PatientModel _ulogovaniPacijent;
       
        public LoginViewModel()
        {
            patientController = new PatientController();
            LoginCommand = new RelayCommand(Login);
            RegisterDialogCommand = new RelayCommand(RegisterDialog);
            RegisterCommand = new RelayCommand(Register);
        }
        #region Register Command

        public RelayCommand RegisterCommand { get; private set; }

        public void Register(object obj)
        {
            //Trebaa napraviti u kontroloeru pacijenta metodu za registraciju i ovde je pozvati
            MessageBox.Show("JMBG " + Username + "Password " + Password +
                "Name " + Name + "Surname " + Surname + "PhoneNumber " + PhoneNumber +
                "Mail " + Mail);

        }

        #endregion
        #region Show Register Dialog command

        public RelayCommand RegisterDialogCommand { get; private set; }

        public void RegisterDialog(object obj)
        {

            var s = new RegisterPacijent();
            s.DataContext = this;
            s.ShowDialog();

        }

        #endregion

        #region Login Command

        public RelayCommand LoginCommand { get; private set; }

        public void Login(object obj)
        {

            if (Username is null)
            {
                MessageBox.Show("Niste uneli JMBG!");
                return;
            }
            if (Password is null)
            {
                MessageBox.Show("Niste uneli šifru!");
                return;
            }

            if(patientController.PatientLogin(Username, Password))
            {
                PatientMainWindow patientMainWindow = new PatientMainWindow();
                this.Visibility = Visibility.Hidden;
                patientMainWindow.Show();

                var win = new WizardWindow();
                win.ShowDialog();

                _ulogovaniPacijent = patientController.FindByJmbg(Username);
                Console.WriteLine(_ulogovaniPacijent.Jmbg);
            }
            else
            {
                MessageBox.Show("Uneli ste pogrešan JMBG ili šifru!");
            }
        
        }

        #endregion

        #region Propertis
      

        public PatientModel UlogovaniPacijent
        {
            get { return _ulogovaniPacijent; }
            set { _ulogovaniPacijent = value;
            }
        }

        public string Username
        {
            get { return _username; }
            set
            {
                OnPropertyChanged(ref _username, value);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                OnPropertyChanged(ref _password, value);
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                OnPropertyChanged(ref _name, value);
            }
        }
        public string Surname
        {
            get { return _surname; }
            set
            {
                OnPropertyChanged(ref _surname, value);
            }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                OnPropertyChanged(ref _phoneNumber, value);
            }
        }
        public string Mail
        {
            get { return _mail; }
            set
            {
                OnPropertyChanged(ref _mail, value);
            }
        }
        #endregion

        #region ICommand
        private ICommand mUpdater;
        public ICommand UpdateCommand
        {
            get
            {
                if (mUpdater == null)
                    mUpdater = new Updater();
                return mUpdater;
            }
            set
            {
                mUpdater = value;
            }
        }

        public Visibility Visibility { get; private set; }

        private class Updater : ICommand
        {
            #region ICommand Members  

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {

            }

            #endregion
        }
        #endregion

        #region Singlton
        private static LoginViewModel instance = null;
        private static readonly object padlock = new object();


        public static LoginViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        Console.WriteLine("kreira se isntanca");
                        instance = new LoginViewModel();
                    }
                    return instance;
                }
            }
        }
        #endregion

    }
}
