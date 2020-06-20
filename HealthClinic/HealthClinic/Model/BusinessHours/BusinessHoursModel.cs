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
        public ArrayList _doctor;

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

        /// <summary>
        /// Property for collection of Model.Users.Doctor
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public ArrayList Doctor
        {
            get
            {
                if (_doctor == null)
                    _doctor = new ArrayList();
                return _doctor;
            }
            set
            {
                RemoveAllDoctor();
                if (value != null)
                {
                    foreach (Doctor oDoctor in value)
                        AddDoctor(oDoctor);
                }
            }
        }

        #endregion

        #region Manipulation with property Doctor

        /// <summary>
        /// Add a new Model.Users.Doctor in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddDoctor(Doctor newDoctor)
        {
            if (newDoctor == null)
                return;
            if (this._doctor == null)
                this._doctor = new ArrayList();
            if (!this._doctor.Contains(newDoctor))
            {
                this._doctor.Add(newDoctor);
                newDoctor.AddBusinessHours(this);
            }
        }

        /// <summary>
        /// Remove an existing Model.Users.Doctor from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveDoctor(Doctor oldDoctor)
        {
            if (oldDoctor == null)
                return;
            if (this._doctor != null)
                if (this._doctor.Contains(oldDoctor))
                {
                    this._doctor.Remove(oldDoctor);
                    oldDoctor.RemoveBusinessHours(this);
                }
        }

        /// <summary>
        /// Remove all instances of Model.Users.Doctor from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllDoctor()
        {
            if (_doctor != null)
            {
                ArrayList tmpDoctor = new ArrayList();
                foreach (Doctor oldDoctor in _doctor)
                    tmpDoctor.Add(oldDoctor);
                _doctor.Clear();
                foreach (Model.Users.Doctor oldDoctor in tmpDoctor)
                    oldDoctor.RemoveBusinessHours(this);
                tmpDoctor.Clear();
            }
        }

        #endregion
    }
}