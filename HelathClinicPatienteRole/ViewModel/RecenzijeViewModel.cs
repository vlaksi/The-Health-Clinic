using HealthClinic.Controller.AppReviewContr;
using HelathClinicPatienteRole.Model;
using Model.Survey;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HelathClinicPatienteRole.ViewModel
{
    class RecenzijeViewModel : INotifyPropertyChanged
    {
        private List<AppReview> _RecenzijeList;
        private AppReviewController appReviewController = new AppReviewController();

        public RecenzijeViewModel()
        {
            _RecenzijeList = appReviewController.GetAllAppReviews();
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
        private static RecenzijeViewModel instance = null;
        private static readonly object padlock = new object();


        public static RecenzijeViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new RecenzijeViewModel();
                    }
                    return instance;
                }
            }
        }
        #endregion

    }
}
