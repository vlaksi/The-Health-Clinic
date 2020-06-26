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
        private string filePath = @".\FileStorage\rooms.json";

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

        private void OpenFIle()
        {
            throw new NotImplementedException();
        }

        private void CloseFile()
        {
            throw new NotImplementedException();
        }

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
            List<Room> allRooms = (List<Room>)FindAll();

            foreach (Room tempRoom in allRooms)
            {
                // Room is uniq by number of room for now
                if (tempRoom.NumberOfRoom.Equals(entity.NumberOfRoom))
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
                if (tempRoom.NumberOfRoom.Equals(identificator))
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
            throw new NotImplementedException();
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
            Room retRoom = new Room();

            foreach (Room tempRoom in allRooms)
            {
                // Room is uniq by number of room for now
                if (tempRoom.NumberOfRoom.Equals(id))
                {
                    retRoom = tempRoom;
                    break;
                }

            }

            return retRoom;
        }

        public void Save(Room entity)
        {
            List<Room> allRooms = (List<Room>)FindAll();
            allRooms.Add(entity);

            // I want immediately to save changes
            SaveAll(allRooms);
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