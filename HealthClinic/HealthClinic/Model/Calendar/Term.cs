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
        #region Attributes
        private Model.Users.SpecialtyType specialtyType;
        private int medicalRecordId;
        private DateTime endTime;
        private DateTime startTime;
        private int id;
        #endregion

        #region Properties
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
        public DateTime StartTime
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
        public Model.Users.SpecialtyType SpecialtyType
        {
            get { return specialtyType; }
            set { specialtyType = value; }
        }
        public int MedicalRecordId
        {
            get
            {
                return medicalRecordId;
            }
            set

            {
                medicalRecordId = value;
            }
        }
        #endregion
    }
}