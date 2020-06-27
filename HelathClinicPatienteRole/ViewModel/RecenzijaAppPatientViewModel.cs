using Controller.PatientContr;
using HealthClinic.Controller.AppReviewContr;
using HelathClinicPatienteRole.Model;
using HelathClinicPatienteRole.ViewModel.Commands;
using Model.Survey;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HelathClinicPatienteRole.ViewModel
{
    public class RecenzijaAppPatientViewModel : INotifyPropertyChanged
    {
        private List<AppReview> _RecenzijeList;
        private string noviKomentar;
        private PatientModel _prijavljeniKorisnik;
        private PatientController patientController;

        private AppReviewController appReviewController = new AppReviewController();
        public RecenzijaAppPatientViewModel()
        {
            patientController = new PatientController();
            _prijavljeniKorisnik = LoginViewModel.Instance.UlogovaniPacijent;

            OstaviRecenzijuCommand = new RelayCommand(OstaviRecenziju);


            _RecenzijeList = appReviewController.GetAllAppReviews();
        }

        #region Ostavi recenziju

        private bool recenzijaOstavljena;
        public RelayCommand OstaviRecenzijuCommand { get; private set; }

        public void OstaviRecenziju(object obj)
        {
            if (recenzijaOstavljena)
            {
                MessageBox.Show("Već ste ostavili vašu recenziju!");
                return;
            }
            if (NoviKomentar == null)
            {
                MessageBox.Show("Morate uneti vaš komentar! ");
                return;
            }

            AppReview novaRecenzija = new AppReview();
          
            novaRecenzija.Patient = _prijavljeniKorisnik;
            novaRecenzija.ReviewText = NoviKomentar;


            appReviewController.AddAppReview(novaRecenzija);
           // Recenzije.Add(novaRecenzija);
            //Otkomentarisi polje ako hoces da onemogucis ostavljanje vise recenzija
            recenzijaOstavljena = true;
            MessageBox.Show("Uspesno ste ostavili recenziju ");

        }

        #endregion

        # region ICommand
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

        #region Properties

        public string NoviKomentar
        {
            get
            {
                return noviKomentar;
            }
            set { noviKomentar = value; }
        }

        public List<AppReview> Recenzije
        {
            get
            {
                return _RecenzijeList;
            }
            set { _RecenzijeList = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion

        #region Singlton
        private static RecenzijaAppPatientViewModel instance = null;
        private static readonly object padlock = new object();


        public static RecenzijaAppPatientViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new RecenzijaAppPatientViewModel();
                    }
                    return instance;
                }
            }
        }
        #endregion

    }
}
