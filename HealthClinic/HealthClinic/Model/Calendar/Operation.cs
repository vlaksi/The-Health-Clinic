// File:    Operation.cs
// Author:  Vaxi
// Created: Saturday, April 4, 2020 11:54:28 PM
// Purpose: Definition of Class Operation

using System;

namespace Model.Calendar
{
    /// Operacija je dogadjaj koji se desava i evidentira u Kalendaru.
    public class Operation : Term
    {
        private Model.Rooms.OperatingRoom operatingRoom;

        public Model.Rooms.OperatingRoom OperatingRoom
        {
            get { return operatingRoom; }
            set { operatingRoom = value; }
        }

        private Model.Users.Specialist specialist;

        public Model.Users.Specialist Specialist
        {
            get { return specialist; }
            set { specialist = value; }
        }


    }
}