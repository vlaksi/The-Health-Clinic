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

        private ObservableCollection<Doctor> doctors;

        /// <summary>
        /// Property for collection of Model.Users.Doctor
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public ObservableCollection<Doctor> Doctors
        {
            get
            {
                if (doctors == null)
                    doctors = new ObservableCollection<Doctor>();
                return doctors;
            }
            set
            {
                RemoveAllDoctors();
                if (value != null)
                {
                    foreach (Doctor oDoctor in value)
                        AddDoctors(oDoctor);
                }
                OnPropertyChanged("Doctors");
            }
        }

        /// <summary>
        /// Add a new Model.Users.Doctor in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddDoctors(Doctor newDoctor)
        {
            if (newDoctor == null)
                return;
            if (this.doctors == null)
                this.doctors = new ObservableCollection<Doctor>();
            if (!this.doctors.Contains(newDoctor))
            {
                this.doctors.Add(newDoctor);
                newDoctor.AddSurveyResponses(this);
            }
        }

        /// <summary>
        /// Remove an existing Model.Users.Doctor from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveDoctors(Doctor oldDoctor)
        {
            if (oldDoctor == null)
                return;
            if (this.doctors != null)
                if (this.doctors.Contains(oldDoctor))
                {
                    this.doctors.Remove(oldDoctor);
                    oldDoctor.RemoveSurveyResponses(this);
                }
        }

        /// <summary>
        /// Remove all instances of Model.Users.Doctor from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllDoctors()
        {
            if (doctors != null)
            {
                System.Collections.ArrayList tmpDoctors = new System.Collections.ArrayList();
                foreach (Model.Users.Doctor oldDoctor in doctors)
                    tmpDoctors.Add(oldDoctor);
                doctors.Clear();
                foreach (Model.Users.Doctor oldDoctor in tmpDoctors)
                    oldDoctor.RemoveSurveyResponses(this);
                tmpDoctors.Clear();
            }
        }
        private PatientModel patient;

        /// <summary>
        /// Property for Model.Users.Patient
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
        public PatientModel Patient
        {
            get
            {
                return patient;
            }
            set
            {
                if (this.patient == null || !this.patient.Equals(value))
                {
                    if (this.patient != null)
                    {
                        Model.Users.PatientModel oldPatient = this.patient;
                        this.patient = null;
                        oldPatient.RemoveSurveyResponses(this);
                    }
                    if (value != null)
                    {
                        this.patient = value;
                        this.patient.AddSurveyResponses(this);
                    }
                }
            }
        }

    }
}