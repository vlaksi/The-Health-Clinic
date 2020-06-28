// File:    
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
        private RoomsRepository roomsRepository;

        private CheckupService checkupService = new CheckupService();
        private OperationService operationService = new OperationService();

        public RoomsService()
        {
            roomsRepositoryFactory = new RoomsFileRepositoryFactory();
            roomsRepository = roomsRepositoryFactory.CreateRoomsRepository();
        }

        public void changeRoomInventory(Room room, InventoryType inventory)
        {
            roomsRepository.changeRoomInventory(room, inventory);
        }

        public void makeUpdateFor(Room room)
        {
            roomsRepository.makeUpdateFor(room);
        }

        public void addRoom(Room room)
        {
            roomsRepository.Save(room);
        }

        public void removeRoom(Room room)
        {
            roomsRepository.Delete(room);
        }

        public void removeRoomById(int id)
        {
            roomsRepository.DeleteById(id);
        }

        public List<Room> GetAllOperatingRooms()
        {
            return roomsRepository.GetAllOperatingRooms();
        }

        public List<Room> GetAllOrdinations()
        {
            return roomsRepository.GetAllOrdinations();
        }

        public Room findById(int id)
        {
            return roomsRepository.FindById(id);
        }

        public Room findByNumberOfRoom(int numberOfRoom)
        {
            return roomsRepository.findByNumberOfRoom(numberOfRoom);
        }

        public void saveAllRooms(List<Room> roomsForSave)
        {
            roomsRepository.SaveAll(roomsForSave);
        }

        public List<Room> GetAvailableRooms(DateTime startDate, DateTime endDate)
        {
            return null;
        }

        public List<Room> GetAvailablePatientsRooms()
        {
            return roomsRepository.GetAvailablePatientsRooms();
        }

        public List<Room> GetAllRooms()
        {
            List<Room> retRooms = new List<Room>();
            retRooms = (List<Room>)roomsRepository.FindAll();

            return retRooms;
        }

        public List<Room> GetFreeOperationRooms(DateTime start, DateTime end)
        {
            List<Room> allRooms = (List<Room>)roomsRepository.FindAll();
            List<Room> result = new List<Room>();
            foreach (Room room in allRooms)
            {
                if (room.RoomType == RoomType.OperatingRoom && IsRoomFree(room.RoomId, start, end))
                {
                    result.Add(room);
                }
            }
            return result;
        }

        public List<Room> GetFreeOrdinations(DateTime start, DateTime end)
        {
            List<Room> allRooms = (List<Room>)roomsRepository.FindAll();
            List<Room> result = new List<Room>();
            foreach (Room room in allRooms)
            {
                if (room.RoomType == RoomType.Ordination && IsRoomFree(room.RoomId, start, end))
                {
                    result.Add(room);
                }
            }
            return result;
        }

        public bool IsRoomFree(int roomId, DateTime dateStart, DateTime dateEnd)
        {
            Room room = roomsRepository.FindById(roomId);

            //Da li u sobi ima termina u tom periodu
            //trebalo bi napraviti metodu da vraca bas za sobu ali me mrzilo
            List<Checkup> allCheckups = checkupService.getAllCheckups();
            List<Checkup> checkupsInRoom = new List<Checkup>();
            foreach (Checkup c in allCheckups)
            {
                if (c.OrdinationId == roomId)
                {
                    checkupsInRoom.Add(c);
                }
            }

            List<Operation> allOperations = operationService.getAllOperations();
            List<Operation> operationsInRoom = new List<Operation>();
            foreach (Operation o in allOperations)
            {
                if (o.OperatingRoomId == roomId)
                {
                    operationsInRoom.Add(o);
                }
            }

            foreach (Checkup checkup in checkupsInRoom)
            {
                if (checkup.StartTime == dateStart) return false;
                if (checkup.EndTime == dateEnd) return false;

                if (checkup.StartTime < dateStart)
                {
                    if (checkup.EndTime > dateStart && checkup.EndTime < dateEnd)
                        return false; // Condition 1

                    if (checkup.EndTime > dateEnd)
                        return false; // Condition 3
                }
                else
                {
                    if (dateEnd > checkup.StartTime && dateEnd < checkup.EndTime)
                        return false; // Condition 2

                    if (dateEnd > checkup.EndTime)
                        return false; // Condition 4
                }
            }

            foreach (Operation operation in operationsInRoom)
            {
                if (operation.StartTime == dateStart) return false;
                if (operation.EndTime == dateEnd) return false;

                if (operation.StartTime < dateStart)
                {
                    if (operation.EndTime > dateStart && operation.EndTime < dateEnd)
                        return false; // Condition 1

                    if (operation.EndTime > dateEnd)
                        return false; // Condition 3
                }
                else
                {
                    if (dateEnd > operation.StartTime && dateEnd < operation.EndTime)
                        return false; // Condition 2

                    if (dateEnd > operation.EndTime)
                        return false; // Condition 4

                }

                // Ako je sve ovo zadovoljeno, slobodna je
            }
            return true;
        }

    }
}