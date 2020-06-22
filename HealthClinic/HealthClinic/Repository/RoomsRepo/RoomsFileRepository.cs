// File:    RoomsFileRepository.cs
// Author:  Vaxi
// Created: Monday, May 4, 2020 9:27:25 PM
// Purpose: Definition of Class RoomsFileRepository

using Model.Rooms;
using Model.Users;
using System;
using System.Collections.Generic;

namespace Repository.RoomsRepo
{
    public class RoomsFileRepository : RoomsRepository
    {
        private void OpenFIle()
        {
            throw new NotImplementedException();
        }

        private void CloseFile()
        {
            throw new NotImplementedException();
        }

        private string filePath;

        public List<OperatingRoom> GetAllOperatingRooms()
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
    }
}