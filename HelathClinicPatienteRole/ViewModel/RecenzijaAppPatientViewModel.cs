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
    class RecenzijaAppPatientViewModel : INotifyPropertyChanged
    {
        private List<AppReview> _RecenzijeList;
        private string noviKomentar;
        private AppReviewController appReviewController = new AppReviewController();
        public RecenzijaAppPatientViewModel()
        {
           OstaviRecenzijuCommand = new RelayCommand(OstaviRecenziju);


            _RecenzijeList = appReviewController.GetAllAppReviews();

            /* new ObservableCollection<AppReview>
        {
            new Recenzije{Korisnik = "Pero Mikić",Recenzija="Veoma dobra aplikacija, vrlo mi olakšava zakazivanje pregleda kao i pregled svih ostalih informacija koje me zanimaju. Blog vam je odličan!" },
            new Recenzije{Korisnik = "Pero Mikić",Recenzija="Veoma dobra aplikacija, vrlo mi olakšava zakazivanje pregleda kao i pregled svih ostalih informacija koje me zanimaju. Blog vam je odličan!" },
            new Recenzije{Korisnik = "Pero Mikić",Recenzija="Veoma dobra aplikacija, vrlo mi olakšava zakazivanje pregleda kao i pregled svih ostalih informacija koje me zanimaju. Blog vam je odličan!" },
        };*/
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
            PatientModel patient = new PatientModel { Id = 1, Name = "Marko", Surname = "Markovic", PhoneNumber = "0602545687", Adress = "Narodnog Fronta, Novi Sad", Birthday = new DateTime(1980, 1, 1, 0, 0, 0), Biography = "IT radnik vec 20 godina, veoma fizicki aktivan" };
            novaRecenzija.Patient = patient;
            novaRecenzija.ReviewText = NoviKomentar;


            appReviewController.AddAppReview(novaRecenzija);
            Recenzije.Add(novaRecenzija);
            //Otkomentarisi polje ako hoces da onemogucis ostavljanje vise recenzija
            // recenzijaOstavljena = true;
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

        #region Selektovana recenzija

        private AppReview _selektovanaRecenzija;

        public AppReview SelektovanaRecenzija
        {
            get { return _selektovanaRecenzija; }
            set { _selektovanaRecenzija = value; OnPropertyChanged("SelektovanaRecenzija"); }
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
