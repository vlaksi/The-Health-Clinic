// File:    Room.cs
// Author:  Vaxi
// Created: Wednesday, April 1, 2020 10:18:08 PM
// Purpose: Definition of Class Room

using HealthClinic.Model.Rooms;
using HealthClinic.Utilities;
using System;
using System.Collections.Generic;

namespace Model.Rooms
{
    public class Room : ObservableObject
    {
        #region Attributes
        private double size;
        private int _numberOfRoom;
        private string _department;
        private string _purpose;
        private int floor;
        private bool full = false;
        private List<InventoryType> _roomInventory;
        private PhysicalWork _physicalWork;
        private int capacity;
        private RoomType roomType;
        private int patientsAccommodated;
        private int roomId;
        #endregion



        #region Properties
        public int RoomId
        {
            get { return roomId; }
            set { roomId = value; }
        }
        public int PatientsAccommodated
        {
            get { return patientsAccommodated; }
            set { patientsAccommodated = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }


        public RoomType RoomType
        {
            get { return roomType; }
            set { roomType = value; }
        }

        public string Purpose
        {
            get { return _purpose; }
            set { _purpose = value; OnPropertyChanged("Purpose"); }
        }

        public string Department
        {
            get { return _department; }
            set { _department = value; OnPropertyChanged("Department"); }
        }

        public double Size
        {
            get
            {
                return size;
            }
            set
            {
                this.size = value;
            }
        }

        public int NumberOfRoom
        {
            get
            {
                return _numberOfRoom;
            }
            set
            {
                this._numberOfRoom = value;
            }
        }

        public int Floor
        {
            get
            {
                return floor;
            }
            set
            {
                this.floor = value;
            }
        }

        public bool Full
        {
            get
            {
                if (capacity == patientsAccommodated) return true;
                return false;
            }
            set
            {
                this.full = value;
            }
        }

        /// <summary>
        /// Property for collection of InventoryType
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public List<InventoryType> RoomInventory
        {
            get
            {
                if (_roomInventory == null)
                    _roomInventory = new List<InventoryType>();
                return _roomInventory;
            }
            set
            {
                //RemoveAllInventoryAmount();
                if (value != null)
                {
                    //foreach (InventoryType oInventoryAmount in value)
                    //    AddInventoryAmount(oInventoryAmount);
                    _roomInventory = value;
                    //OnPropertyChanged("RoomInventory");
                }
            }
        }

        public PhysicalWork PhysicalWork
        {
            get { return _physicalWork; }
            set { _physicalWork = value; OnPropertyChanged("PhysicalWork"); }
        }

        #endregion

        #region Manipulation with property: InventoryAmount

        /// <summary>
        /// Add a new InventoryAmount in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddInventoryAmount(InventoryType newInventoryAmount)
        {
            if (newInventoryAmount == null)
                return;
            if (this._roomInventory == null)
                this._roomInventory = new List<InventoryType>();
            if (!this._roomInventory.Contains(newInventoryAmount))
                this._roomInventory.Add(newInventoryAmount);
        }

        /// <summary>
        /// Remove an existing InventoryAmount from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveInventoryAmount(InventoryType oldInventoryAmount)
        {
            if (oldInventoryAmount == null)
                return;
            if (this._roomInventory != null)
                if (this._roomInventory.Contains(oldInventoryAmount))
                    this._roomInventory.Remove(oldInventoryAmount);
        }

        /// <summary>
        /// Remove all instances of InventoryAmount from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllInventoryAmount()
        {
            if (_roomInventory != null)
                _roomInventory.Clear();
        }

        #endregion

    }

    public enum RoomType
    {
        PatientRoom,
        Ordination,
        OperatingRoom,
    }
}