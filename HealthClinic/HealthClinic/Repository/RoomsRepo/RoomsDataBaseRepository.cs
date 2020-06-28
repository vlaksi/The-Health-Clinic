// File:    RoomsDataBaseRepository.cs
// Author:  Vaxi
// Created: Monday, May 4, 2020 9:27:25 PM
// Purpose: Definition of Class RoomsDataBaseRepository

using Model.Rooms;
using Model.Users;
using System;
using System.Collections.Generic;

namespace Repository.RoomsRepo
{
    public class RoomsDataBaseRepository : RoomsRepository
    {
        public List<Room> GetAllOperatingRooms()
        {
            throw new NotImplementedException();
        }

        public List<Room> GetAvailableRooms(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public bool AccommodatePatient(PatientModel patient, DateTime startDate, DateTime endDate, Room room)
        {
            throw new NotImplementedException();
        }

        public List<Room> GetAllRooms()
        {
            throw new NotImplementedException();
        }

        public bool TransferPatient(Room newRoom)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(Room entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int identificator)
        {
            throw new NotImplementedException();
        }

        public bool ExistsById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Room> FindAll()
        {
            throw new NotImplementedException();
        }

        public Room FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Room entity)
        {
            throw new NotImplementedException();
        }

        public void SaveAll(IEnumerable<Room> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Room> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public void makeUpdateFor(Room room)
        {
            throw new NotImplementedException();
        }

        public List<Room> GetAllOrdinations()
        {
            throw new NotImplementedException();
        }

        public List<Room> GetAvailablePatientsRooms()
        {
            throw new NotImplementedException();
        }

        public void changeRoomInventory(Room entity, InventoryType inventory)
        {
            throw new NotImplementedException();
        }

        public Room findByNumberOfRoom(int numberOfRoom)
        {
            throw new NotImplementedException();
        }
    }
}