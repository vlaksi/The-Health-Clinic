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
<<<<<<< HEAD
        private int medicalRecordId;
        private string gender;
        private String parentsName;
        private String healthInsuranceNumber;
        private String healthInsuranceCarrier;
=======
        #region Attributes
        private int medicalRecordId;
>>>>>>> igor-backend
        private ObservableCollection<Treatment> treatments;
        private int doctorId;
        private List<int> terms;
        private List<ReferralToSpecialist> referralToSpecialist;
        private int patientId;
        private List<Report> reports;
<<<<<<< HEAD


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
=======
        private int roomId;
        private DateTime accommodationStart;
        private DateTime accommodationEnd;
        private bool isAccommodated;
        #endregion
        #region Properties
        public DateTime AccommodationStart
        {
            get { return accommodationStart; }
            set { accommodationStart = value; }
        }

        public DateTime AccommodationEnd
        {
            get
            {
                return accommodationEnd;
            }
            set { accommodationEnd = value; }
        }

        public bool IsAccommodated
        {
            get
            {
                if (DateTime.Compare(AccommodationEnd, DateTime.Now) < 1) isAccommodated = false;
                return isAccommodated;
            }
            set { isAccommodated = value; OnPropertyChanged("IsAccommodated"); }
        }

        public int RoomId
>>>>>>> igor-backend
        {
            get { return roomId; }
            set { roomId = value; OnPropertyChanged("RoomId"); }
        }
<<<<<<< HEAD
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
=======

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
>>>>>>> igor-backend
        {
            get { return medicalRecordId; }
            set { medicalRecordId = value; OnPropertyChanged("MedicalRecordId"); }
        }
        public int DoctorId
        {
            get { return doctorId; }
            set { doctorId = value; OnPropertyChanged("DoctorId"); }
        }
        public int PatientId
        {
            get { return patientId; }
            set { patientId = value; OnPropertyChanged("PatientId"); }
        }
        public ObservableCollection<Treatment> Treatments
        {
            get { if (treatments == null) treatments = new ObservableCollection<Treatment>(); return treatments; }
            set { treatments = value; OnPropertyChanged("Treatments"); }
        }
        #endregion
        // Terms
        public List<int> Terms
        {
            get
            {
                if (terms == null)
                    terms = new List<int>();
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
        #region terms
        public void AddTerm(int newTerm)
        {
            if (newTerm == 0)
                return;
            if (this.terms == null)
                this.terms = new List<int>();
            if (!this.terms.Contains(newTerm))
            {
                this.terms.Add(newTerm);
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
                tmpTerm.Clear();
            }
        }
        #endregion

        public List<ReferralToSpecialist> ReferralToSpecialist
        {
            get
            {
                if (referralToSpecialist == null)
                    referralToSpecialist = new List<ReferralToSpecialist>();
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
        #endregion

        #region referrals
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
<<<<<<< HEAD

=======
        #endregion
>>>>>>> igor-backend

    }
}