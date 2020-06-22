// File:    SurveyResponse.cs
// Author:  Vaxi
// Created: Wednesday, April 29, 2020 6:50:06 PM
// Purpose: Definition of Class SurveyResponse

using HealthClinic.Utilities;
using Model.Users;
using System;
using System.Collections.ObjectModel;

namespace Model.Survey
{
    public class SurveyResponse : ObservableObject
    {

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        private Rate quality;
        private Rate security;
        private Rate kindness;
        private Rate professionalism;
        private string comment;

        public Rate Quality
        {
            get
            {
                return quality;
            }
            set
            {
                this.quality = value;
                OnPropertyChanged("Quality");
            }
        }
        public Rate Security
        {
            get
            {
                return security;
            }
            set
            {
                this.security = value;
                OnPropertyChanged("Security");
            }
        }
        public Rate Kindness
        {
            get
            {
                return kindness;
            }
            set
            {
                this.kindness = value;
                OnPropertyChanged("Kindness");
            }
        }
        public Rate Professionalism
        {
            get
            {
                return professionalism;
            }
            set
            {
                this.professionalism = value;
                OnPropertyChanged("Professionalism");
            }
        }
        public string Comment
        {
            get
            {
                return comment;
            }
            set
            {
                this.comment = value;
                OnPropertyChanged("Comment");
            }
        }

        private ObservableCollection<int> doctors;
        public ObservableCollection<int> Doctors { get { return doctors; } set { doctors = value; OnPropertyChanged("Doctors"); } }

        private int patientId;

        /// <summary>
        /// Property for Model.Users.Patient
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
        public int PatientId
        {
            get
            {
                return patientId;
            }
            set
            {
                patientId = value; OnPropertyChanged("PatientId");
            }
        }

    }
}