using Controller.SurveyResponseContr;
using Model.Survey;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HealthClinic.ViewModels
{
    public class RecenzijaViewModel : ObservableObject
    {

        public RecenzijaViewModel()
        {
            ucitajSveLekove();

            MessageBox.Show(getTextForMessageBox());
        }

        #region Kontroler

        SurveyResponseController surveyResponseController = new SurveyResponseController();

        #endregion

        #region Sve ankete

        private ObservableCollection<SurveyResponse> _rezultatiAnkete;

        public  ObservableCollection<SurveyResponse> RezultatiAnkete
        {
            get { return _rezultatiAnkete; }
            set { _rezultatiAnkete = value; OnPropertyChanged("RezultatiAnkete"); }
        }


        #endregion

        #region Ucitaj/sacuvaj sve lekove iz fajlova

        private void ucitajSveLekove()
        {
            

            // iscitam ih sve
            List<SurveyResponse> tempLekovi = new List<SurveyResponse>();
            tempLekovi = surveyResponseController.GetAllSurveyResponses();

            // a onda to dodam u listu koja se prikazuje na frontu
            RezultatiAnkete = new ObservableCollection<SurveyResponse>();
            foreach (SurveyResponse medicine in tempLekovi)
            {
                RezultatiAnkete.Add(medicine);
            }
        }

        private void sacuvajSveLekove()
        {

            List<SurveyResponse> tempLekovi = new List<SurveyResponse>();
            foreach (SurveyResponse medicine1 in RezultatiAnkete)
            {
                tempLekovi.Add(medicine1);
            }

            surveyResponseController.saveAllSurveyResponses(tempLekovi);
        }

        #endregion

        private string getTextForMessageBox()
        {
            string retVal="Trenutni front je u izradi, jedini prikaz trenutnog stanja anketa je sledeci: \n\n";

            foreach (SurveyResponse surveyResponse in RezultatiAnkete)
            {
                if (surveyResponse.DoctorId <= 0)
                    break;

                retVal += "Doktor sa id-em: " + surveyResponse.DoctorId + " je dobio ocenu: " + surveyResponse.Mark + " sa komentarom: \n" + surveyResponse.Comment+"\n\n";

                retVal += "\n";
            }

            return retVal;
        }
    }
}
