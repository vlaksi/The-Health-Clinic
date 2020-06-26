// File:    RoomsService.cs
// Author:  Vaxi
// Created: Sunday, May 3, 2020 9:00:10 PM
// Purpose: Definition of Class RoomsService

using Model.Calendar;
using Model.MedicalRecord;
using Model.Rooms;
using Model.Users;
using Repository.RoomsRepo;
using Service.TermServ;
using System;
using System.Collections.Generic;

namespace Service.RoomServ
{
    public class RoomsService
    {
        public RoomsRepositoryFactory roomsRepositoryFactory;
        private CheckupService checkupService = new CheckupService();
        private OperationService operationService = new OperationService();

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

        public List<Room> GetAllOperatingRooms()
        {
            RoomsFileRepository roomsFileRepository = new RoomsFileRepository();
            return roomsFileRepository.GetAllOperatingRooms();
        }



        public List<Room> GetAllOrdinations()
        {
            RoomsFileRepository roomsFileRepository = new RoomsFileRepository();
            return roomsFileRepository.GetAllOrdinations();
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

        public bool AccommodatePatient(MedicalRecord medicalRecord, Room room)
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

        public List<Room> GetAvailablePatientsRooms()
        {
            RoomsFileRepository roomsFileRepository = new RoomsFileRepository();
            return roomsFileRepository.GetAvailablePatientsRooms();
        }

        public List<Room> GetAllRooms()
        {
            // TODO: Proveriti kako ovo ide preko factorija
            RoomsFileRepository repoForRooms = new RoomsFileRepository();

            List<Room> retRooms = new List<Room>();
            retRooms = (List<Room>)repoForRooms.FindAll();

            return retRooms;
        }

        public List<Room> GetFreeOperationRooms(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public bool IsRoomFree(int roomId, DateTime dateStart, DateTime dateEnd)
        {
            RoomsFileRepository roomRepository = new RoomsFileRepository();
            Room room = roomRepository.FindById(roomId);

            //Da li u sobi ima termina u tom periodu
            //trebalo bi napraviti metodu da vraca bas za sobu ali me mrzilo
            List<Checkup> allCheckups = checkupService.getAllCheckups();
            List<Checkup> checkupsInRoom = new List<Checkup>();
            foreach (Checkup c in allCheckups)
            {
                if (c.OrdinationId == roomId)
                {
                    allCheckups.Add(c);
                }
            }

            List<Operation> allOperations = operationService.getAllOperations();
            List<Operation> operationsInRoom = new List<Operation>();
            foreach (Operation o in allOperations)
            {
                if (o.OperatingRoomId == roomId)
                {
                    allOperations.Add(o);
                }
            }

            foreach (Checkup checkup in checkupsInRoom)
            {
                if (checkup.StartTime <= dateStart || checkup.EndTime >= dateEnd)
                {
                    return false;
                }
            }

            foreach (Operation operation in operationsInRoom)
            {
                if (operation.StartTime <= dateStart || operation.EndTime >= dateEnd)
                {
                    return false;
                }
            }

            // Ako je sve ovo zadovoljeno, slobodna je
            return true;
        }


    }
}