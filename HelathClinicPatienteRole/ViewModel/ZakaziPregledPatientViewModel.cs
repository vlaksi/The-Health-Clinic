using Controller.TermContr;
using DocumentFormat.OpenXml.Office2010.Word;
using HelathClinicPatienteRole.Dialogs;
using HelathClinicPatienteRole.Model;
using HelathClinicPatienteRole.ViewModel.Commands;
using Model.Calendar;
using Model.Users;
using System;
using Controller.DoctorContr;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Org.BouncyCastle.Asn1.Cms;
using Model.BusinessHours;
using HealthClinic.Repository.UserRepo.DoctorRepo;
using HealthClinic.Model.Calendar;

namespace HelathClinicPatienteRole.ViewModel
{
    class ZakaziPregledPatientViewModel : INotifyPropertyChanged
    {
        private List<Doctor> _DoctorList;
        private CheckupStrategyControler checkupStrategyControler;
        private DoctorController doctorController;
        private DoctorFileRepository doctorFr;
        private PatientModel _prijavljeniKorisnik;
        public ZakaziPregledPatientViewModel()
        {
            checkupStrategyControler = new CheckupStrategyControler();
            doctorController = new DoctorController();
            doctorFr = new DoctorFileRepository ();
            PirkaziPreporukaTerminaDialogCommand = new RelayCommand(PirkaziPreporukaTerminaDialog);
            ZakaziPregledCommand = new RelayCommand(ZakaziPregled);
            PreporukaTerminaCommand = new RelayCommand(PreporukaTermina);
            ZakaziPregledPreporukaTerminaCommand = new RelayCommand(ZakaziPregledPreporuka);
            _prijavljeniKorisnik = LoginViewModel.Instance.UlogovaniPacijent;

            _DoctorList = doctorController.GetAllDoctors();
        }

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

        #region Preporuka termina 

        public RelayCommand PreporukaTerminaCommand { get; private set; }

        public void PreporukaTermina(object obj)
        {
            if (SelektovaniDatumOd < DateTime.Now)
            {
                MessageBox.Show("Izabrani 'datum OD' je prošao!");
                return;
            }
            if (SelektovaniDatumDo.Date < SelektovaniDatumOd.Date)
            {
                MessageBox.Show("Nesipravan vremenski interval! 'Datum OD' mora biti manji od 'datuma DO'");
                return;
            }

            if (SelektovaniDatumDo.Date == SelektovaniDatumOd.Date)
            {
                MessageBox.Show("Potrebno je izabrati datumski opseg u minimalnom razmaku od jednog dana!");
                return;
            }

            if (SelektovaniLekar is null)
            {
                MessageBox.Show("Potrebno je izabrati lekara!");
                return;
            }
            if(!PreporukaTerminaDialog.IzabranPrioritetDatum && !PreporukaTerminaDialog.IzabranPrioritetLekar)
            {
                MessageBox.Show("Potrebno je izabrati prioritet!");
                return;
            }
            if (PreporukaTerminaDialog.IzabranPrioritetDatum && PreporukaTerminaDialog.IzabranPrioritetLekar)
            {
                MessageBox.Show("Dozvoljeno je izabrati samo jedan prioritet!");
                return;
            }

            //Podesavamo vremena za proveru da budu u okviru radnog vremena
            TimeSpan tsOd = new TimeSpan(07, 0, 0);
            TimeSpan tsDo = new TimeSpan(20, 0, 0);
            SelektovaniDatumOd = SelektovaniDatumOd.Date + tsOd;
            SelektovaniDatumDo = SelektovaniDatumDo.Date + tsDo;

            SuggestCheckupDTO suggestCheckupDTO = new SuggestCheckupDTO() { DoctorID = SelektovaniLekar.Id, StartInterval = SelektovaniDatumOd, EndInterval = SelektovaniDatumDo, PriorityDate = PreporukaTerminaDialog.IzabranPrioritetDatum, PriorityDoctor = PreporukaTerminaDialog.IzabranPrioritetLekar };
            suggestCheckupDTO = checkupStrategyControler.SuggestCheckup(suggestCheckupDTO);

            if (suggestCheckupDTO.DoctorID == -1)
            {
                MessageBox.Show("Nemamo ni jednog slobodnog lekara u izabranom terminu");
                return;
            }
   

            
            PreporucenTermin = "";
            PreporucenTermin += suggestCheckupDTO.StartInterval + "\n";
            PreporucenTermin += " Lekar " + doctorController.FindById(suggestCheckupDTO.DoctorID).Name;

            

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

        #region Zakazi pregled command

        public RelayCommand ZakaziPregledCommand { get; private set; }

        private static DateTime vremePrethodnoZakazanogPregleda;
        public void ZakaziPregled(object obj)
        {
            if (vremePrethodnoZakazanogPregleda.Day == DateTime.Now.Day)
            {
                MessageBox.Show("Nije moguće opet zakazati pregled! Potrebno je da prođe 24h od prethodno zakazanog pregleda!");
                return;
            }

            if (SelektovaniLekar is null)
            {
                MessageBox.Show("Niste selektovali ni jednog lekara!!!");
                return;
            }

            if (SelektovaniDatum < DateTime.Now)
            {
                MessageBox.Show("Izabrani datum mora da bude minimalno jedan dan veći od trenutnog datuma!");
                return;
            }
  
            DateTime termin = new DateTime(2020, SelektovaniDatum.Month, SelektovaniDatum.Day, SelektovanoVreme.Hour, 0, 0);
        
            if(doctorController.IsDoctorFree(SelektovaniLekar, termin, termin))
            {
                Checkup pregled = new Checkup { Id = 9, CheckupName = "Pregled kod lekara opšte prakse", StartTime = termin, CheckupStatus = "Zakazan", DoctorId = SelektovaniLekar.Id, MedicalRecordId = _prijavljeniKorisnik.MedicalRecordId };
                vremePrethodnoZakazanogPregleda = DateTime.Now;
                PocetnaPatientViewModel.Instance.Pregledi.Add(pregled);
                checkupStrategyControler.ScheduleTerm(pregled);
                MessageBox.Show("Usepsno ste zakazali pregled kod " + SelektovaniLekar.Name + SelektovaniLekar.Surname + ".");
            }
            else
            {
                MessageBox.Show("Izabrani lekar " + SelektovaniLekar.Name + " nije slobodan u tom terminu!");
            }
           // MessageBox.Show("Selektovano vreeme " + SelektovanoVreme.Hour);

          /* 
            BusinessHoursModel bh = new BusinessHoursModel() { FromDate = DateTime.Today, ToDate = DateTime.Today.AddDays(5), FromHour = DateTime.Today.AddDays(5).AddHours(5), ToHour = DateTime.Today.AddDays(5).AddHours(8) };

            Doctor doctor = new Doctor { Id = 0, Name = "Pero", Surname = "Peric", BusinessHours = bh };
            _DoctorList.Add(doctor);
            doctorFr.SaveAll(_DoctorList);*/
        }

        #endregion

        #region Zakazi pregled preporuka termina

        public RelayCommand ZakaziPregledPreporukaTerminaCommand { get; private set; }

    
        public void ZakaziPregledPreporuka(object obj)
        {
            if (vremePrethodnoZakazanogPregleda.Day == DateTime.Now.Day)
            {
                MessageBox.Show("Nije moguće opet zakazati pregled! Potrebno je da prođe 24h od prethodno zakazanog pregleda!");
                return;
            }

            if (PreporucenTermin == "")
            {
                MessageBox.Show("Morate prvo izgenerisati termin!");
                return;
            }

           
            MessageBox.Show("Usepsno ste zakazali pregled kod " + SelektovaniLekar.Name + " " + SelektovaniLekar.Surname + ".");
            Checkup pregled = new Checkup { Id = 9, CheckupName = "Pregled kod lekara opšte prakse", StartTime = SelektovaniDatum, CheckupStatus = "Zakazan", DoctorId = SelektovaniLekar.Id };
            vremePrethodnoZakazanogPregleda = DateTime.Now;
            PocetnaPatientViewModel.Instance.Pregledi.Add(pregled);
            checkupStrategyControler.ScheduleTerm(pregled);
        }

        #endregion

        #region Preporuka termina dialog

        public RelayCommand PirkaziPreporukaTerminaDialogCommand { get; private set; }

        public void PirkaziPreporukaTerminaDialog(object obj)
        {
            var s = new PreporukaTerminaDialog();
            s.ShowDialog();

        }

        #endregion

        #region Preporuceni Termin

        private String _preporuceniTermin ;

        public String PreporucenTermin
        {
            get { return _preporuceniTermin; }
            set { _preporuceniTermin = value; OnPropertyChanged("PreporucenTermin"); }
        }
        #endregion

        #region Selektovani Datum OD za preporuku termina

        private DateTime _selektovaniDatumOd = DateTime.Now;

        public DateTime SelektovaniDatumOd
        {
            get { return _selektovaniDatumOd; }
            set { _selektovaniDatumOd = value; OnPropertyChanged("SelektovaniDatumOd"); }
        }
        #endregion

        #region Selektovani Datum DO za preporuku termina

        private DateTime _selektovaniDatumDo = DateTime.Now;

        public DateTime SelektovaniDatumDo
        {
            get { return _selektovaniDatumDo; }
            set { _selektovaniDatumDo = value; OnPropertyChanged("SelektovaniDatumDo"); }
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

        #region Selektovano vreme za termin

        private DateTime _selektovanoVreme = DateTime.Now;

        public DateTime SelektovanoVreme
        {
            get { return _selektovanoVreme; }
            set { _selektovanoVreme = value; OnPropertyChanged("SelektovanoVreme"); }
        }
        #endregion

        public List<Doctor> Lekari
        {
            get
            {
                return _DoctorList;
            }
            set { _DoctorList = value; }
        }

        # region properzChange
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
        private static ZakaziPregledPatientViewModel instance = null;
        private static readonly object padlock = new object();


        public static ZakaziPregledPatientViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ZakaziPregledPatientViewModel();
                    }
                    return instance;
                }
            }
        }
        #endregion
    }
}
