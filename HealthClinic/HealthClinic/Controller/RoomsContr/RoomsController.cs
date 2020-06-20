// File:    RoomsController.cs
// Author:  Vaxi
// Created: Sunday, May 3, 2020 9:00:10 PM
// Purpose: Definition of Class RoomsController

using Model.Rooms;
using Model.Users;
using Service.RoomServ;
using System;
using System.Collections.Generic;

namespace Controller.RoomsContr
{
    public abstract class RoomsController
    {
        public RoomsService roomsService;

        public bool AccommodatePatient(PatientModel patient, DateTime startDate, DateTime endDate, Room room)
        {
            throw new NotImplementedException();
        }

        public Room CreateRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public Room RenovateRoom(Room room, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public abstract List<Room> GetAvailableRooms(DateTime startDate, DateTime endDate);

        public abstract List<Room> GetAllRooms();

        public abstract bool TransferPatient(Room newRoom);

        public List<OperatingRoom> GetFreeOperationRooms(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }


    }
}