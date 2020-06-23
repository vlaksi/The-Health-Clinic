using Controller.MedicalRecordContr;
using Controller.PatientContr;
using HelathClinicPatienteRole.Model;
using Model.MedicalRecord;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HelathClinicPatienteRole.ViewModel
{
    class KartonPatientViewModel
    {
        private MedicalRecord _MedicinskiKarton;
        private MedicalRecordController medicalRecordController = new MedicalRecordController();
        public KartonPatientViewModel()
        {
            _MedicinskiKarton = medicalRecordController.GetMedicalRecordByPatientId(1);
            PatientController pc = new PatientController();
        }

        public MedicalRecord MedicinskiKarton
        {
            get { return _MedicinskiKarton; }
            set { _MedicinskiKarton = value; }
        }

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
    }
}
