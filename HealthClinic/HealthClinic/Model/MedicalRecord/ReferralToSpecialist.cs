// File:    ReferralToSpecialist.cs
// Author:  Vaxi
// Created: Wednesday, April 29, 2020 4:39:55 PM
// Purpose: Definition of Class ReferralToSpecialist

using System;

namespace Model.MedicalRecord
{
    public class ReferralToSpecialist
    {

        private DateTime validFromDate;

        public DateTime ValidFromDate
        {
            get { return validFromDate; }
            set { validFromDate = value; }
        }

        private DateTime validToDate;

        public DateTime ValidToDate
        {
            get { return validToDate; }
            set { validToDate = value; }
        }

        private int specialistId;

        public int SpecialistId
        {
            get { return specialistId; }
            set { specialistId = value; }
        }


        public int nonspecialist;
        public int NonspecialistId
        {
            get
            {
                return nonspecialist;
            }
            set
            {
                nonspecialist = value;
            }
        }

    }
}