using HelathClinicPatienteRole.Dialogs;
using HelathClinicPatienteRole.Model;
using HelathClinicPatienteRole.ViewModel.Commands;
using Model.Calendar;
using HealthClinic;
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
using Controller.TermContr;
using Model.Survey;
using Controller.SurveyResponseContr;
using Controller.DoctorContr;
using Controller.PatientContr;

namespace HelathClinicPatienteRole.ViewModel
{
    class PocetnaPatientViewModel : INotifyPropertyChanged
    {
        private List<Checkup> _PregledList;
        private List<Doctor> _LekariList;
        private List<SurveyResponse> _SurveyResponseList;
        private DoctorController doctorController;
        private PatientModel _prijavljeniKorisnik;
        private CheckupStrategyControler checkupStrategyControler;
        private PatientController patientController;

        public PocetnaPatientViewModel()
        {
            doctorController = new DoctorController();
            checkupStrategyControler = new CheckupStrategyControler();
            patientController = new PatientController();

            PirkaziIzmeniPregledDialogCommand = new RelayCommand(PirkaziIzmeniPregledDialog);
            PirkaziOtkaziPregledDialogCommand = new RelayCommand(PirkaziOtkaziPregledDialog);
            PirkaziAnketaLekaraDialogCommand = new RelayCommand(PirkaziAnketaLekaraDialog);
            ProcitajViseDialogCommand = new RelayCommand(ProcitajViseDialog);
            ObrisiPregledPotvrdiButtonCommand = new RelayCommand(ObrisiPregledPotvrdiButton);
            IzmeniPregledCommand = new RelayCommand(IzmeniPregled);
            PosaljiAnketuCommand = new RelayCommand(PosaljIAnketu);

            _prijavljeniKorisnik = LoginViewModel.Instance.UlogovaniPacijent;
            _LekariList = ZakaziPregledPatientViewModel.Instance.Lekari;
            _PregledList = checkupStrategyControler.GetAllCheckups(_prijavljeniKorisnik.MedicalRecordId);
            
        }


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

        #region Posalji anketu Command

        public RelayCommand PosaljiAnketuCommand { get; private set; }

        public void PosaljIAnketu(object obj)
        {
            //PatientModel patient = new PatientModel { Id = 1 , Name = "Marko", Surname = "Markovic", PhoneNumber= "0602545687" , Adress = "Narodnog Fronta, Novi Sad", Birthday= new DateTime(1980, 1, 1, 0, 0, 0), Biography="IT radnik vec 20 godina, veoma fizicki aktivan" };
            Doctor doctor = doctorController.FindById(SelektovaniPregled.DoctorId);
                SurveyResponse anketa = new SurveyResponse { Comment = Comment, Mark = SelektovaniMark, Doctor = doctor , PatientId = _prijavljeniKorisnik.Id};
            patientController.FillFeedbackForm(anketa);
            MessageBox.Show("Uspesno ste uradili anketu ! Vas Komentar je : " + Comment + " A ocena je : " + SelektovaniMark);
            return;

        }

        #endregion

        #region Izmeni pregled Command

        public RelayCommand IzmeniPregledCommand { get; private set; }

        public void IzmeniPregled(object obj)
        {
           
            if (SelektovaniLekar is null || SelektovaniDatum == DateTime.MinValue)
            {
                MessageBox.Show("Niste izmenili ni lekara ni datum!!!");
                return;
            }

            DateTime termin = new DateTime(2020, SelektovaniDatum.Month, SelektovaniDatum.Day, SelektovanoVreme.Hour, 0, 0);

            if (doctorController.IsDoctorFree(SelektovaniLekar, termin, termin))
            {
                Checkup pregled = new Checkup { Id = SelektovaniPregled.Id, CheckupName = SelektovaniPregled.CheckupName, StartTime = termin, CheckupStatus = SelektovaniPregled.CheckupStatus, DoctorId = SelektovaniLekar.Id,MedicalRecordId= _prijavljeniKorisnik.MedicalRecordId };
                checkupStrategyControler.EditTerm(pregled);
                MessageBox.Show("Usepsno ste izmenili pregled kod " + SelektovaniLekar.Name + SelektovaniLekar.Surname + ".");
            }
            else
            {
                MessageBox.Show("Izabrani lekar " + SelektovaniLekar.Name + " nije slobodan u tom terminu!");
            }

        }

        #endregion

        #region Comment

        private string _comment;

        public string Comment
        {
            get { return _comment; }
            set { _comment = value; OnPropertyChanged("Comment"); }
        }
        #endregion

        #region Selected Mark

        private int _selektovaniMark = 3;

        public int SelektovaniMark
        {
            get { return _selektovaniMark; }
            set { _selektovaniMark = value; OnPropertyChanged("SelektovaniMark"); }
        }
        #endregion

        #region Selektovani Lekar

        private Doctor _selektovaniLekar;

        public Doctor SelektovaniLekar
        {
            get { return _selektovaniLekar; }
            set { _selektovaniLekar = value; OnPropertyChanged("SelektovaniLekar"); }
        }
        #endregion

        #region Selektovani Datum

        private DateTime _selektovaniDatum = DateTime.Now;

        public DateTime SelektovaniDatum
        {
            get { return _selektovaniDatum; }
            set { _selektovaniDatum = value; OnPropertyChanged("SelektovaniDatum"); }
        }
        #endregion

        #region Obrisi pregled command

        public RelayCommand ObrisiPregledPotvrdiButtonCommand { get; private set; }

        public void ObrisiPregledPotvrdiButton(object obj)
        {
     
            if (SelektovaniPregled is null)
            {
                MessageBox.Show("Niste selektovali ni jedan pregled u tabeli!");
                return;
            }
               
            foreach (Checkup pregled in Pregledi)
            {
                if (pregled.Id == SelektovaniPregled.Id)
                {
                    pregled.CheckupStatus = "Otkazan";
                    MessageBox.Show("Uspesno ste otkazali " + pregled.CheckupName);
                    // Pregledi.Remove(pregled); //Ovo je komanda za brisanje 
                    //checkupStrategyControler.CancelTerm(pregled);
                    checkupStrategyControler.EditTerm(pregled);
                    break;
                }
            }

        }

        #endregion

        #region Procitaj vise dialog

        public RelayCommand ProcitajViseDialogCommand { get; private set; }

        public void ProcitajViseDialog(object obj)
        {
            var s = new ProcitajVise();
            s.ShowDialog();

        }

        #endregion

        #region Anketa lekara 

        public RelayCommand PirkaziAnketaLekaraDialogCommand { get; private set; }

        public void PirkaziAnketaLekaraDialog(object obj)
        {
            if (SelektovaniPregled is null)
            {
                MessageBox.Show("Niste selektovali ni jedan pregled u tabeli!");
                return;
            }
            if (SelektovaniPregled.CheckupStatus != "Obavljen")
            {
                MessageBox.Show("Selektovani pregled mora da ima status 'Obavljen'!");
                return;
            }
            var s = new AnketaPregledaDialog();
            s.DataContext = this;
            s.ShowDialog();

        }

        #endregion

        #region Izmeni pregled Dialog 

        public RelayCommand PirkaziIzmeniPregledDialogCommand { get; private set; }

        public void PirkaziIzmeniPregledDialog(object obj)
        {
            if (SelektovaniPregled is null)
            {
                MessageBox.Show("Niste selektovali ni jedan pregled u tabeli!");
                return;
            }
            if(SelektovaniPregled.CheckupStatus != "Zakazan")
            {
                MessageBox.Show("Selektovani pregled mora da ima status 'Zakazan'!");
                return;
            }

            var s = new IzmenaPregledaDialog();
             s.DataContext = this;             
             s.ShowDialog();
        }

        #endregion

        #region Otkazi pregled Dialog 
     
        public RelayCommand PirkaziOtkaziPregledDialogCommand { get; private set; }

        public void PirkaziOtkaziPregledDialog(object obj)
        {
            if (SelektovaniPregled is null)
            {
                MessageBox.Show("Niste selektovali ni jedan pregled u tabeli!");
                return;
            }
            if (SelektovaniPregled.CheckupStatus != "Zakazan")
            {
                MessageBox.Show("Selektovani pregled mora da ima status 'Zakazan'!");
                return;
            }
            var s = new OtkaziPregled();
            s.DataContext = this;
            s.ShowDialog();

        }

        #endregion

        #region Selektovani pregled

        private Checkup _selektovaniPregled;

        public Checkup SelektovaniPregled
        {
            get { return _selektovaniPregled; }
            set { _selektovaniPregled = value; OnPropertyChanged("SelektovaniPregled"); }
        }
        #endregion
        public List<Checkup> Pregledi
        {
            get
            {
                return _PregledList;
            }
            set { _PregledList = value;
               // checkupStrategyControler.saveAllCheckups(value);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        #region Selektovano vreme za termin

        private DateTime _selektovanoVreme = DateTime.Now;

        public DateTime SelektovanoVreme
        {
            get { return _selektovanoVreme; }
            set { _selektovanoVreme = value; OnPropertyChanged("SelektovanoVreme"); }
        }
        #endregion
        #region Singlton
        private static PocetnaPatientViewModel instance = null;
        private static readonly object padlock = new object();


        public static PocetnaPatientViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new PocetnaPatientViewModel();
                    }
                    return instance;
                }
            }
        }
        #endregion

        public List<Doctor> Lekari
        {
            get
            {
                return _LekariList;
            }
            set { _LekariList = value; }
        }
    }
}
