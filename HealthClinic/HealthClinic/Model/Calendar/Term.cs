// File:    Term.cs
// Author:  Vaxi
// Created: Sunday, April 5, 2020 12:02:01 AM
// Purpose: Definition of Class Term

using HealthClinic.Utilities;
using System;
using System.ComponentModel;

namespace Model.Calendar
{

    //public class Term : ScheduleAppointment, INotifyPropertyChanged
    public class Term : ObservableObject
    {
        private int id;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                this.id = value;
            }
        }

        private DateTime startTime;
        public DateTime StarTime
        {
            get
            {
                return startTime;
            }
            set
            {
                startTime = value;
            }
        }

        private DateTime endTime;
        public DateTime EndTime
        {
            get
            {
                return endTime;
            }
            set
            {
                endTime = value;
            }
        }

        private Report report;

        public Report Report
        {
            get { return report; }
            set { report = value; }
        }

        private Model.Users.SpecialtyType specialtyType;

        public Model.Users.SpecialtyType SpecialtyType
        {
            get { return specialtyType; }
            set { specialtyType = value; }
        }


        private Model.MedicalRecord.MedicalRecord medicalRecord;

        public Model.MedicalRecord.MedicalRecord MedicalRecord
        {
            get
            {
                return medicalRecord;
            }
            set

            {
                if (this.medicalRecord == null || !this.medicalRecord.Equals(value))
                {
                    if (this.medicalRecord != null)
                    {
                        Model.MedicalRecord.MedicalRecord oldMedicalRecord = this.medicalRecord;
                        this.medicalRecord = null;
                        oldMedicalRecord.RemoveTerm(this.Id);
                    }
                    if (value != null)
                    {
                        this.medicalRecord = value;
                        this.medicalRecord.AddTerm(this.Id);
                    }
                }
            }
        }

    }
}