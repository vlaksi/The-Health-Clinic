// File:    RoomsService.cs
// Author:  Vaxi
// Created: Sunday, May 3, 2020 9:00:10 PM
// Purpose: Definition of Class RoomsService

using System;

namespace Service.RoomServ
{
   public abstract class RoomsService
   {
      public bool AccommodatePatient(Model.Users.Patient patient, DateTime startDate, DateTime endDate, Room room)
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
      
      public abstract List<Room> GetAvailableRooms(DateTime startDate, DateTime endDate);
      
      public abstract List<Room> GetAllRooms();
      
      public abstract bool TransferPatient(Model.Rooms.Room newRoom);
      
      public List<OperationRoom> GetFreeOperationRooms(DateTime start, DateTime end)
      {
         throw new NotImplementedException();
      }
      
      public Repository.RoomsRepo.RoomsRepositoryFactory roomsRepositoryFactory;
   
   }
}