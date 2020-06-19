// File:    RoomsDataBaseRepository.cs
// Author:  Vaxi
// Created: Monday, May 4, 2020 9:27:25 PM
// Purpose: Definition of Class RoomsDataBaseRepository

using System;

namespace Repository.RoomsRepo
{
   public class RoomsDataBaseRepository<Rooms,int> : RoomsRepository where Rooms : T
    where int : ID
   {
      public List<OperatingRoom> GetAllOperatingRooms()
      {
         throw new NotImplementedException();
      }
      
      public List<Room> GetAvailableRooms(DateTime startDate, DateTime endDate)
      {
         throw new NotImplementedException();
      }
      
      public bool AccommodatePatient(Patient patient, DateTime startDate, DateTime endDate, Model.Rooms.Room room)
      {
         throw new NotImplementedException();
      }
      
      public List<Room> GetAllRooms()
      {
         throw new NotImplementedException();
      }
      
      public bool TransferPatient(Model.Rooms.Room newRoom)
      {
         throw new NotImplementedException();
      }
   
   }
}