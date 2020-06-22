// File:    Term.cs
// Author:  Vaxi
// Created: Sunday, April 5, 2020 12:02:01 AM
// Purpose: Definition of Class Term

using HealthClinic.Utilities;
//using Syncfusion.UI.Xaml.Schedule;
using System.ComponentModel;

namespace Model.Calendar
{

    //public class Term : ScheduleAppointment, INotifyPropertyChanged
    public class Term : ObservableObject
    {
        /*
         * Naslijedjeni od strane ScheduleAppointment 
         * private System.DateTime startTime;
        private System.DateTime endTime;

        public System.DateTime StartTime
        {
           get
           {
              return startTime;
           }
           set
           {
              this.startTime = value;
           }
        }
        public System.DateTime EndTime
        {
           get
           {
              return endTime;
           }
           set
           {
              this.endTime = value;
           }
        }*/

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