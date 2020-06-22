// File:    InvertoryType.cs
// Author:  Vaxi
// Created: Friday, April 17, 2020 12:50:01 AM
// Purpose: Definition of Class InvertoryType

using HealthClinic.Utilities;
using System;

namespace Model.Rooms
{
    public class InventoryType : ObservableObject
    {
        #region Attributes

        private string _inventoryName;
        private int _inventoryQuantity;

        #endregion

        #region Properties

        public string InventoryName
        {
            get
            {
                return _inventoryName;
            }
            set
            {
                if (value != _inventoryName)
                {
                    _inventoryName = value;
                    //OnPropertyChanged("InventoryName");
                }
            }
        }

        public int Quantity
        {
            get
            {
                return _inventoryQuantity;
            }
            set
            {
                if (value != _inventoryQuantity)
                {
                    _inventoryQuantity = value;
                    //OnPropertyChanged("Quantity");
                }
            }
        }

        #endregion
    }
}