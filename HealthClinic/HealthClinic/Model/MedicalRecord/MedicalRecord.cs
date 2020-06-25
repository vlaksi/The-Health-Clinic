// File:    MedicalRecord.cs
// Author:  Vaxi
// Created: Sunday, April 5, 2020 12:42:49 PM
// Purpose: Definition of Class MedicalRecord

using HealthClinic.Utilities;
using Model.Calendar;
using Model.Medicine;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Model.MedicalRecord
{
    public class MedicalRecord : ObservableObject
    {
        private int medicalRecordId;
        private string gender;
        private String parentsName;
        private String healthInsuranceNumber;
        private String healthInsuranceCarrier;
        private ObservableCollection<Treatment> treatments;
        private Doctor doctor;
        private List<int> terms;
        public List<ReferralToSpecialist> referralToSpecialist;
        private int patientId;
        private List<Report> reports;


        public List<Report> Reports
        {
            get
            {
                if (reports == null) reports = new List<Report>();
                return reports;
            }
            set { reports = value; }
        }

        #region Properties
        public int MedicalRecordId
        {
            get { return medicalRecordId; }
            set { medicalRecordId = value; OnPropertyChanged("MedicalRecordId"); }
        }
       
        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                this.gender = value; OnPropertyChanged("Gender");
            }
        }
       
        public String ParentsName
        {
            get
            {
                return parentsName;
            }
            set
            {
                this.parentsName = value; OnPropertyChanged("ParentsName");
            }
        }
        public String HealthInsuranceNumber
        {
            get
            {
                return healthInsuranceNumber;
            }
            set
            {
                this.healthInsuranceNumber = value; OnPropertyChanged("HealthInsuranceNumber");
            }
        }

        public String HealthInsuranceCarrier
        {
            get
            {
                return healthInsuranceCarrier;
            }
            set
            {
                this.healthInsuranceCarrier = value; OnPropertyChanged("HealthInsuranceCarrier");
            }
        }
        public Doctor Doctor
        {
            get { return doctor; }
            set { doctor = value; OnPropertyChanged("Doctor"); }
        }
        public int PatientId
        {
            get { return patientId; }
            set { patientId = value; OnPropertyChanged("PatientId"); }
        }
        public ObservableCollection<Treatment> Treatments
        {
            get { return treatments; }
            set { treatments = value; OnPropertyChanged("Treatments"); }
        }
        #endregion
        // Terms
        public List<int> Terms
        {
            get
            {
                if (terms == null)
                    terms = new System.Collections.Generic.List<int>();
                return terms;
            }
            set
            {
                RemoveAllTerm();
                if (value != null)
                {
                    foreach (int oTerm in value)
                        AddTerm(oTerm);
                }
            }
        }
        public void AddTerm(int newTerm)
        {
            if (newTerm == 0)
                return;
            if (this.terms == null)
                this.terms = new System.Collections.Generic.List<int>();
            if (!this.terms.Contains(newTerm))
            {
                this.terms.Add(newTerm);
                //newTerm.MedicalRecord = this;      // ~~~ srediti ovo ~~~
            }
        }
        public void RemoveTerm(int oldTerm)
        {
            if (oldTerm == 0)
                return;
            if (this.terms != null)
                if (this.terms.Contains(oldTerm))
                {
                    this.terms.Remove(oldTerm);
                    //oldTerm.MedicalRecord = null;  // ~~~ srediti ovo ~~~
                }
        }
        public void RemoveAllTerm()
        {
            if (terms != null)
            {
                System.Collections.ArrayList tmpTerm = new System.Collections.ArrayList();
                foreach (int oldTerm in terms)
                    tmpTerm.Add(oldTerm);
                terms.Clear();
                /*foreach (Term oldTerm in tmpTerm)          // ~~~ srediti ovo ~~~
                    oldTerm.MedicalRecord = null;*/
                tmpTerm.Clear();
            }
        }

        public List<ReferralToSpecialist> ReferralToSpecialist
        {
            get
            {
                if (referralToSpecialist == null)
                    referralToSpecialist = new System.Collections.Generic.List<ReferralToSpecialist>();
                return referralToSpecialist;
            }
            set
            {
                RemoveAllReferralToSpecialist();
                if (value != null)
                {
                    foreach (ReferralToSpecialist oReferralToSpecialist in value)
                        AddReferralToSpecialist(oReferralToSpecialist);
                }
            }
        }
        public void AddReferralToSpecialist(ReferralToSpecialist newReferralToSpecialist)
        {
            if (newReferralToSpecialist == null)
                return;
            if (this.referralToSpecialist == null)
                this.referralToSpecialist = new System.Collections.Generic.List<ReferralToSpecialist>();
            if (!this.referralToSpecialist.Contains(newReferralToSpecialist))
                this.referralToSpecialist.Add(newReferralToSpecialist);
        }
        public void RemoveReferralToSpecialist(ReferralToSpecialist oldReferralToSpecialist)
        {
            if (oldReferralToSpecialist == null)
                return;
            if (this.referralToSpecialist != null)
                if (this.referralToSpecialist.Contains(oldReferralToSpecialist))
                    this.referralToSpecialist.Remove(oldReferralToSpecialist);
        }
        public void RemoveAllReferralToSpecialist()
        {
            if (referralToSpecialist != null)
                referralToSpecialist.Clear();
        }


    }
}