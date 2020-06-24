// File:    RoomsService.cs
// Author:  Vaxi
// Created: Sunday, May 3, 2020 9:00:10 PM
// Purpose: Definition of Class RoomsService

using Model.Rooms;
using Model.Users;
using Repository.RoomsRepo;
using System;
using System.Collections.Generic;

namespace Service.RoomServ
{
    public class RoomsService
    {
        public RoomsRepositoryFactory roomsRepositoryFactory;

        public void makeUpdateFor(Room room)
        {
            RoomsFileRepository fileRepository = new RoomsFileRepository();
            fileRepository.makeUpdateFor(room);
        }

        public void addRoom(Room room)
        {
            // TODO: Proveriti kako ovo ide preko ovog Factorija
            RoomsFileRepository roomsFileRepository = new RoomsFileRepository();
            roomsFileRepository.Save(room);
        }

        public void removeRoom(Room room)
        {
            // TODO: Proveriti kako ovo ide preko ovog Factorija
            RoomsFileRepository roomsFileRepository = new RoomsFileRepository();
            roomsFileRepository.Delete(room);
        }

        public void removeRoomById(int id)
        {
            // TODO: Proveriti kako ovo ide preko ovog Factorija
            RoomsFileRepository roomsFileRepository = new RoomsFileRepository();
            roomsFileRepository.DeleteById(id);
        }

        public Room findById(int id)
        {
            // TODO: Proveriti kako ovo ide preko ovog Factorija
            RoomsFileRepository roomsFileRepository = new RoomsFileRepository();
            return roomsFileRepository.FindById(id);
        }

        public void saveAllRooms(List<Room> roomsForSave)
        {
            RoomsFileRepository repoForRooms = new RoomsFileRepository();
            repoForRooms.SaveAll(roomsForSave);
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
            // TODO: Proveriti kako ovo ide preko factorija
            RoomsFileRepository repoForRooms = new RoomsFileRepository();

            List<Room> retRooms = new List<Room>();
            retRooms = (List<Room>)repoForRooms.FindAll();

            return retRooms;
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