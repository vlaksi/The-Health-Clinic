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
    public class RoomsController
    {
        public RoomsService roomsService = new RoomsService();

        public void saveAllRooms(List<Room> roomsForSave)
        {
            roomsService.saveAllRooms(roomsForSave);
        }

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

        public List<Room> GetAvailableRooms(DateTime startDate, DateTime endDate)
        {
            return null;
        }

        public List<Room> GetAllRooms()
        {
            return roomsService.GetAllRooms();
        }

        public bool TransferPatient(Room newRoom)
        {
            return false;
        }

        public List<OperatingRoom> GetFreeOperationRooms(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }


    }
}