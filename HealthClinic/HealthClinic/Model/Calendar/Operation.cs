// File:    Operation.cs
// Author:  Vaxi
// Created: Saturday, April 4, 2020 11:54:28 PM
// Purpose: Definition of Class Operation

using Model.Users;
using System;

namespace Model.Calendar
{
    /// Operacija je dogadjaj koji se desava i evidentira u Kalendaru.
    public class Operation : Term
    {
        #region Attributes
        private int operatingRoomId;
        private int specialistId;
        #endregion
        
        #region Properties
        public int OperatingRoomId
        {
            get { return operatingRoomId; }
            set { operatingRoomId = value; }
        }
        public int SpecialistId
        {
            get { return specialistId; }
            set { specialistId = value; }
        }
        #endregion
    }
}