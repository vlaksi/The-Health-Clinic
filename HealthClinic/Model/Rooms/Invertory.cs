// File:    Invertory.cs
// Author:  Vaxi
// Created: Wednesday, April 1, 2020 10:21:26 PM
// Purpose: Definition of Class Invertory

using System;
using System.Collections.Generic;

namespace Model.Rooms
{
    public class Invertory
    {
        #region Attributes

        private int quantityInStorage;
        public List<InventoryType> invertoryType;

        #endregion

        #region Properties

        public int QuantityInStorage
        {
            get
            {
                return quantityInStorage;
            }
            set
            {
                this.quantityInStorage = value;
            }
        }

        /// <summary>
        /// Property for collection of InvertoryType
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public List<InventoryType> InvertoryType
        {
            get
            {
                if (invertoryType == null)
                    invertoryType = new List<InventoryType>();
                return invertoryType;
            }
            set
            {
                RemoveAllInvertoryType();
                if (value != null)
                {
                    foreach (InventoryType oInvertoryType in value)
                        AddInvertoryType(oInvertoryType);
                }
            }
        }

        #endregion

        #region Manipulation with property: InventoryType

        /// <summary>
        /// Add a new InvertoryType in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddInvertoryType(InventoryType newInvertoryType)
        {
            if (newInvertoryType == null)
                return;
            if (this.invertoryType == null)
                this.invertoryType = new List<InventoryType>();
            if (!this.invertoryType.Contains(newInvertoryType))
                this.invertoryType.Add(newInvertoryType);
        }

        /// <summary>
        /// Remove an existing InvertoryType from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveInvertoryType(InventoryType oldInvertoryType)
        {
            if (oldInvertoryType == null)
                return;
            if (this.invertoryType != null)
                if (this.invertoryType.Contains(oldInvertoryType))
                    this.invertoryType.Remove(oldInvertoryType);
        }

        /// <summary>
        /// Remove all instances of InvertoryType from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllInvertoryType()
        {
            if (invertoryType != null)
                invertoryType.Clear();
        }

        #endregion
    }
}