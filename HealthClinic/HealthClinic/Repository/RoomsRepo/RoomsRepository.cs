// File:    RoomsRepository.cs
// Author:  Vaxi
// Created: Monday, May 4, 2020 9:26:35 PM
// Purpose: Definition of Interface RoomsRepository

using System;
using Repository.GenericCRUD;
using Model.Users;
using Model.Rooms;
using System.Collections.Generic;

namespace Repository.RoomsRepo
{
    public interface RoomsRepository : GenericInterfaceCRUDDao<Room, int>
    {

        void makeUpdateFor(Room room);

        List<OperatingRoom> GetAllOperatingRooms();

        List<Room> GetAvailableRooms(DateTime startDate, DateTime endDate);

        bool AccommodatePatient(PatientModel patient, DateTime startDate, DateTime endDate, Room room);

        List<Room> GetAllRooms();

        bool TransferPatient(Room newRoom);

    }
}