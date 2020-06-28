// File:    Checkup.cs
// Author:  Vaxi
// Created: Tuesday, April 14, 2020 2:47:47 PM
// Purpose: Definition of Class Checkup

using Model.Users;
using System;

namespace Model.Calendar
{
    public class Checkup : Term
    {
        private string checkupName;
        private string checkupStatus;
        private int ordinationId;
        private int doctorId;

        public string CheckupName
        {
            get { return checkupName; }
            set
            {
                checkupName = value;
                OnPropertyChanged("CheckupName");
            }
        }

        public string CheckupStatus
        {
            get { return checkupStatus; }
            set
            {
                checkupStatus = value;
                OnPropertyChanged("CheckupStatus");
            }
        }

        public int DoctorId
        {
            get { return doctorId; }
            set
            {
                doctorId = value;
                OnPropertyChanged("Doctor");
            }
        }
        public int OrdinationId
        {
            get { return ordinationId; }
            set
            {
                ordinationId = value;
                OnPropertyChanged("Doctor");
            }
        }
    }
}