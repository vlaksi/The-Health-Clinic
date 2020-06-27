// File:    BusinessHoursModel.cs
// Author:  Vaxi
// Created: Tuesday, April 21, 2020 8:27:16 PM
// Purpose: Definition of Class BusinessHoursModel

using HealthClinic.Utilities;
using Model.Users;
using System;
using System.Collections;

namespace Model.BusinessHours
{
    public class BusinessHoursModel : ObservableObject
    {
        #region Attributes

        private DateTime _fromDate;
        private DateTime _toDate;
        private DateTime _fromHour;
        private DateTime _toHour;

        #endregion

        #region Properties

        public DateTime FromDate
        {
            get { return _fromDate; }
            set
            {
                if (value != _fromDate)
                {
                    _fromDate = value;
                    OnPropertyChanged("FromDate");
                }
            }
        }
        public DateTime ToDate
        {
            get { return _toDate; }
            set
            {
                if (value != _toDate)
                {
                    _toDate = value;
                    OnPropertyChanged("ToDate");
                }
            }
        }
        public DateTime FromHour
        {
            get { return _fromHour; }
            set
            {
                if (value != _fromHour)
                {
                    _fromHour = value;
                    OnPropertyChanged("FromHour");
                }
            }
        }
        public DateTime ToHour
        {
            get { return _toHour; }
            set
            {
                if (value != _toHour)
                {
                    _toHour = value;
                    OnPropertyChanged("ToHour");
                }
            }
        }


        #endregion

       
    }
}