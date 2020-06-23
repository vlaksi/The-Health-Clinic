using HealthClinic.Utilities;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Survey
{
    public class AppReview : ObservableObject
    {
        private string reviewText;
        private PatientModel patient;

        public PatientModel Patient
        {
            get { return patient; }
            set
            {
                patient = value;
                OnPropertyChanged("Patient");
            }
        }

        public string ReviewText
        {
            get { return reviewText; }
            set
            {
                reviewText = value;
                OnPropertyChanged("ReviewText");
            }
        }
    }
}
