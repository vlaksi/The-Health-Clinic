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

        List<Room> GetAllOperatingRooms();

        List<Room> GetAllOrdinations();

        List<Room> GetAvailablePatientsRooms();

        List<Room> GetAllRooms();

        void changeRoomInventory(Room entity, InventoryType inventory);


        Room findByNumberOfRoom(int numberOfRoom);
    }
}