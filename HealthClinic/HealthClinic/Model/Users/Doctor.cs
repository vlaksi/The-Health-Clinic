// File:    Doctor.cs
// Author:  Vaxi
// Created: Wednesday, April 1, 2020 9:43:20 PM
// Purpose: Definition of Class Doctor

using Model.MedicalRecord;
using Model.Survey;
using Model.BlogPost;
using Model.BusinessHours;
using System;
using Model.Rooms;
using System.Collections;
using System.Collections.Generic;

namespace Model.Users
{
    public class Doctor : Employee
    {
        #region Attributes
        private bool ableToValidateMedicines = false;
        private bool ableToPrescribeTreatments = false;
        private SpecialtyType specialtyType;
        #endregion

        #region Properties

        public SpecialtyType SpecialtyType
        {
            get { return specialtyType; }
            set { specialtyType = value; }
        }

        public bool AbleToValidateMedicines
        {
            get
            {
                return ableToValidateMedicines;
            }
            set
            {
                this.ableToValidateMedicines = value;
            }
        }

        public bool AbleToPrescribeTreatments
        {
            get
            {
                return ableToPrescribeTreatments;
            }
            set
            {
                this.ableToPrescribeTreatments = value;
            }
        }
        
        #endregion
    }
}