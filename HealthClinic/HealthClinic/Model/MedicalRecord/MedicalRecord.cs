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
        #region Attributes
        private int medicalRecordId;
        private ObservableCollection<Treatment> treatments;
        private int doctorId;
        private List<int> checkups;
        private List<int> operations;
        private List<ReferralToSpecialist> referralToSpecialist;
        private int patientId;
        private List<Report> reports;
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
                if (DateTime.Compare(AccommodationEnd, DateTime.Now) < 1)
                {
                    isAccommodated = false;
                    AccommodationEnd = default;
                    AccommodationStart = default;
                }
                return isAccommodated;
            }
            set { isAccommodated = value; OnPropertyChanged("IsAccommodated"); }
        }

        public int RoomId
        {
            get { return roomId; }
            set { roomId = value; OnPropertyChanged("RoomId"); }
        }

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
        public List<int> Checkups
        {
            get
            {
                if (checkups == null)
                    checkups = new List<int>();
                return checkups;
            }
            set
            {
                RemoveAllCheckups();
                if (value != null)
                {
                    foreach (int oTerm in value)
                        AddCheckup(oTerm);
                }
            }
        }
        public List<int> Operations
        {
            get
            {
                if (operations == null)
                    operations = new List<int>();
                return operations;
            }
            set
            {
                RemoveAllOperations();
                if (value != null)
                {
                    foreach (int oTerm in value)
                        AddOperation(oTerm);
                }
            }
        }
        #region checkups
        public void AddCheckup(int newCheckup)
        {
            if (newCheckup == 0)
                return;
            if (this.checkups == null)
                this.checkups = new List<int>();
            if (!this.checkups.Contains(newCheckup))
            {
                this.checkups.Add(newCheckup);
            }
        }
        public void RemoveCheckup(int oldCheckup)
        {
            if (oldCheckup == 0)
                return;
            if (this.checkups != null)
                if (this.checkups.Contains(oldCheckup))
                {
                    this.checkups.Remove(oldCheckup);
                }
        }
        public void RemoveAllCheckups()
        {
            if (checkups != null)
            {
                System.Collections.ArrayList tmpTerm = new System.Collections.ArrayList();
                foreach (int oldTerm in checkups)
                    tmpTerm.Add(oldTerm);
                checkups.Clear();
                tmpTerm.Clear();
            }
        }
        #endregion

        #region operations
        public void AddOperation(int newOperation)
        {
            if (newOperation == 0)
                return;
            if (this.operations == null)
                this.operations = new List<int>();
            if (!this.operations.Contains(newOperation))
            {
                this.operations.Add(newOperation);
            }
        }
        public void RemoveOperation(int oldOperation)
        {
            if (oldOperation == 0)
                return;
            if (this.operations != null)
                if (this.operations.Contains(oldOperation))
                {
                    this.operations.Remove(oldOperation);
                }
        }
        public void RemoveAllOperations()
        {
            if (operations != null)
            {
                System.Collections.ArrayList tmpTerm = new System.Collections.ArrayList();
                foreach (int oldTerm in operations)
                    tmpTerm.Add(oldTerm);
                operations.Clear();
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
        #endregion

    }
}