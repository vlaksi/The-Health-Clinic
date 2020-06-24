// File:    Report.cs
// Author:  Vaxi
// Created: Tuesday, April 21, 2020 9:36:51 AM
// Purpose: Definition of Class Report

using System;
using System.Collections.Generic;

namespace Model.Calendar
{
    public class Report
    {
        private string patientsReport;

        public string PatientsReport
        {
            get { return patientsReport; }
            set { patientsReport = value; }
        }

        private string doctorsRemark;

        public string DoctorsRemark
        {
            get { return doctorsRemark; }
            set { doctorsRemark = value; }
        }

        private List<string> commonMedicalConditions;

        public List<string> CommonMedicalConditions
        {
            get { return commonMedicalConditions; }
            set { commonMedicalConditions = value; }
        }

        private List<string> observations;

        public List<string> Observations
        {
            get { return observations; }
            set { observations = value; }
        }

        private int termId;

        public int TermId
        {
            get { return termId; }
            set { termId = value; }
        }


    }
}