// File:    Medicine.cs
// Author:  Vaxi
// Created: Wednesday, April 1, 2020 10:18:00 PM
// Purpose: Definition of Class Medicine

using HealthClinic.Utilities;
using Model.Users;
using System;
using System.Collections.Generic;

namespace Model.Medicine
{
    public class Medicine : ObservableObject
    {
        #region Attributes

        private int _id;
        private string _medicineName;
        private string _manufacturer;
        private DateTime _expirationDate;
        private int _price;
        private int _quantity;

        private SpecialtyType _specialtyType;
        private MedicineStatus _medicineStatus;
        private List<Alergen> _alergen;
        private List<Ingredient> _ingredient;
        private string _medicineType;
        private string _sideEffects;

        #endregion

        #region Properties
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                this._id = value;
            }
        }
        public string Name
        {
            get
            {
                return _medicineName;
            }
            set
            {
                this._medicineName = value;
            }
        }
        public string Manufacturer
        {
            get
            {
                return _manufacturer;
            }
            set
            {
                this._manufacturer = value;
            }
        }
        public DateTime ExpirationDate
        {
            get
            {
                return _expirationDate;
            }
            set
            {
                this._expirationDate = value;
            }
        }
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                if (value != _quantity)
                {
                    _quantity = value;
                    OnPropertyChanged("Quantity");
                }
            }
        }
        public int Price
        {
            get { return _price; }
            set
            {
                if (value != _price)
                {
                    _price = value;
                    OnPropertyChanged("Price");
                }
            }
        }
        public SpecialtyType SpecialtyType
        {
            get { return _specialtyType; }
            set { _specialtyType = value; }
        }
        public MedicineStatus MedicineStatus
        {
            get { return _medicineStatus; }
            set { _medicineStatus = value; OnPropertyChanged("MedicineStatus"); }
        }

        public List<Alergen> Alergen
        {
            get
            {
                if (_alergen == null)
                    _alergen = new List<Alergen>();
                return _alergen;
            }
            set
            {
                RemoveAllAlergen();
                if (value != null)
                {
                    foreach (Alergen oAlergen in value)
                        AddAlergen(oAlergen);
                }
            }
        }
        public List<Ingredient> Ingredient
        {
            get
            {
                if (_ingredient == null)
                    _ingredient = new List<Ingredient>();
                return _ingredient;
            }
            set
            {
                RemoveAllIngredient();
                if (value != null)
                {
                    foreach (Ingredient oIngredient in value)
                        AddIngredient(oIngredient);
                }
            }
        }

        public string MedicineType
        {
            get { return _medicineType; }
            set
            {
                if (value != _medicineType)
                {
                    _medicineType = value;
                    OnPropertyChanged("MedicineType");
                }

            }
        }
        public string SideEffects
        {
            get { return _sideEffects; }
            set
            {
                if (value != _sideEffects)
                {
                    _sideEffects = value;
                    OnPropertyChanged("SideEffects");
                }
            }
        }

        #endregion

        #region Manipulation with property: Alergen

        /// <summary>
        /// Add a new Alergen in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddAlergen(Alergen newAlergen)
        {
            if (newAlergen == null)
                return;
            if (this._alergen == null)
                this._alergen = new List<Alergen>();
            if (!this._alergen.Contains(newAlergen))
                this._alergen.Add(newAlergen);
        }

        /// <summary>
        /// Remove an existing Alergen from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveAlergen(Alergen oldAlergen)
        {
            if (oldAlergen == null)
                return;
            if (this._alergen != null)
                if (this._alergen.Contains(oldAlergen))
                    this._alergen.Remove(oldAlergen);
        }

        /// <summary>
        /// Remove all instances of Alergen from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllAlergen()
        {
            if (_alergen != null)
                _alergen.Clear();
        }

        #endregion

        #region Manipulation with property: Ingredient

        /// <summary>
        /// Add a new Ingredient in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddIngredient(Ingredient newIngredient)
        {
            if (newIngredient == null)
                return;
            if (this._ingredient == null)
                this._ingredient = new List<Ingredient>();
            if (!this._ingredient.Contains(newIngredient))
                this._ingredient.Add(newIngredient);
        }

        /// <summary>
        /// Remove an existing Ingredient from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveIngredient(Ingredient oldIngredient)
        {
            if (oldIngredient == null)
                return;
            if (this._ingredient != null)
                if (this._ingredient.Contains(oldIngredient))
                    this._ingredient.Remove(oldIngredient);
        }

        /// <summary>
        /// Remove all instances of Ingredient from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllIngredient()
        {
            if (_ingredient != null)
                _ingredient.Clear();
        }

        #endregion

    }
}