// File:    RoomsFileRepository.cs
// Author:  Vaxi
// Created: Monday, May 4, 2020 9:27:25 PM
// Purpose: Definition of Class RoomsFileRepository

using HealthClinic.Model.Rooms;
using Model.Rooms;
using Model.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repository.RoomsRepo
{
    public class RoomsFileRepository : RoomsRepository
    {
        private string filePath = @"./../../../../HealthClinic/FileStorage/rooms.json";

        public void makeUpdateFor(Room room)
        {
            List<Room> allRooms = (List<Room>)FindAll();

            foreach (Room tempRoom in allRooms)
            {
                // For now, room is uniq by number of room, but we need to change that !
                if (tempRoom.NumberOfRoom.Equals(room.NumberOfRoom))
                {
                    tempRoom.Department = room.Department;
                    tempRoom.Purpose = room.Purpose;

                    if(tempRoom.PhysicalWork is null)
                    {
                        tempRoom.PhysicalWork = new PhysicalWork();
                    }

                    if(!(room.PhysicalWork is null))
                    {
                        tempRoom.PhysicalWork.FromDate = room.PhysicalWork.FromDate;
                        tempRoom.PhysicalWork.ToDate = room.PhysicalWork.ToDate;
                        tempRoom.PhysicalWork.NameOfWork = room.PhysicalWork.NameOfWork;
                    }
                    

                    tempRoom.RoomInventory = new List<InventoryType>();
                    if(!(room.RoomInventory is null))
                        tempRoom.RoomInventory.AddRange(room.RoomInventory);

                    break;
                }
            }

            // I want immediately to save changes
            SaveAll(allRooms);

        }

        public List<Room> GetAllOrdinations()
        {
            List<Room> allRooms = (List<Room>)FindAll();
            List<Room> result = new List<Room>();

            foreach (Room room in allRooms)
            {
                if (room.RoomType == RoomType.Ordination)
                {
                    result.Add(room);
                }
            }

            return result;
        }

        private void OpenFIle()
        {
            throw new NotImplementedException();
        }

        private void CloseFile()
        {
            throw new NotImplementedException();
        }

        public List<Room> GetAllOperatingRooms()
        {
            List<Room> allRooms = (List<Room>)FindAll();
            List<Room> result = new List<Room>();

            foreach(Room room in allRooms)
            {
                if(room.RoomType == RoomType.OperatingRoom)
                {
                    result.Add(room);
                }
            }

            return result;
        }

        public List<Room> GetAvailablePatientsRooms()
        {
            List<Room> allRooms = (List<Room>)FindAll();
            List<Room> available = new List<Room>();
            foreach(Room room in allRooms)
            {
                if(room.RoomType == RoomType.PatientRoom && !room.Full)
                {
                    available.Add(room);
                }
            }
            return available;
        }


        public List<Room> GetAllRooms()
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(Room entity)
        {
            List<Room> allRooms = (List<Room>)FindAll();

            foreach (Room tempRoom in allRooms)
            {
                // Room is uniq by number of room for now
                if (tempRoom.RoomId.Equals(entity.RoomId))
                {
                    allRooms.Remove(tempRoom);
                    break;
                }

            }

            // I want immediately to save changes
            SaveAll(allRooms);
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int identificator)
        {
            List<Room> allRooms = (List<Room>)FindAll();

            foreach (Room tempRoom in allRooms)
            {
                // Room is uniq by number of room for now
                if (tempRoom.RoomId.Equals(identificator))
                {
                    allRooms.Remove(tempRoom);
                    break;
                }

            }

            // I want immediately to save changes
            SaveAll(allRooms);
        }

        public bool ExistsById(int id)
        {
            List<Room> allRooms = (List<Room>)FindAll();

            foreach (Room room in allRooms)
                if (room.RoomId == id)
                    return true;

            return false;
        }

        public IEnumerable<Room> FindAll()
        {
            List<Room> allRooms = new List<Room>();

            // read file into a string and deserialize JSON to a type
            allRooms = JsonConvert.DeserializeObject<List<Room>>(File.ReadAllText(filePath));

            return allRooms;
        }

        public Room FindById(int id)
        {
            List<Room> allRooms = (List<Room>)FindAll();
            Room retRoom = null;

            foreach (Room tempRoom in allRooms)
            {
                // Room is uniq by number of room for now
                if (tempRoom.RoomId.Equals(id))
                {
                    retRoom = tempRoom;
                    break;
                }

            }

            return retRoom;
        }

        public void Save(Room entity)
        {
            if (ExistsById(entity.RoomId))
            {
                Delete(entity);
            }
            else
            {
                entity.RoomId = GenerateId();
            }

            List<Room> allRooms = (List<Room>)FindAll();
            allRooms.Add(entity);
            SaveAll(allRooms);
        }

        public int GenerateId()
        {
            int maxId = -1;
            List<Room> allRooms = (List<Room>)FindAll();
            if (allRooms.Count == 0) return 1;
            foreach (Room room in allRooms)
            {
                if (room.RoomId > maxId) maxId = room.RoomId;
            }

            return maxId + 1;
        }

        public void SaveAll(IEnumerable<Room> entities)
        {

            // serialize JSON directly to a file
            using (StreamWriter file = File.CreateText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, entities);
            }
        }

        public IEnumerable<Room> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        
    }
}