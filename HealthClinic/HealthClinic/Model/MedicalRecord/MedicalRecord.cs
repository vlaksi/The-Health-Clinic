// File:    MedicalRecord.cs
// Author:  Vaxi
// Created: Sunday, April 5, 2020 12:42:49 PM
// Purpose: Definition of Class MedicalRecord

using HealthClinic.Utilities;
using Model.Medicine;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Model.MedicalRecord
{
    public class MedicalRecord : ObservableObject
    {
        private int id;

        private string name;
        private string surname;
        private string address;
        private string gender;
        private string jmbg;
        private DateTime dateOfBirth;
        private String parentsName;
        private String healthInsuranceNumber;
        private String phone;
        private String healthInsuranceCarrier;
        private ObservableCollection<Treatment> treatments;
        private Doctor doctor;
        private List<int> terms;
<<<<<<< HEAD
        private List<ReferralToSpecialist> referralToSpecialist;
=======
        public List<ReferralToSpecialist> referralToSpecialist;
>>>>>>> pufke-backend
        private int patientId;

        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                this.surname = value; OnPropertyChanged("Surname");
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                this.address = value; OnPropertyChanged("Address");
            }
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
        public string Jmbg
        {
            get
            {
                return jmbg;
            }
            set
            {
                this.jmbg = value; OnPropertyChanged("Jmbg");
            }
        }
        public DateTime DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }
            set
            {
                this.dateOfBirth = value; OnPropertyChanged("DateOfBirth");
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
        public String Phone
        {
            get
            {
                return phone;
            }
            set
            {
                this.phone = value; OnPropertyChanged("Phone");
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

        //Referrals
<<<<<<< HEAD
        #region Referrals
        
=======
>>>>>>> pufke-backend
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
<<<<<<< HEAD
        #endregion
=======
>>>>>>> pufke-backend
    }
}