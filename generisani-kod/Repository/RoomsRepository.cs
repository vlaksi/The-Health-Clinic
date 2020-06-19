// File:    RoomsRepository.cs
// Author:  Filip Zukovic
// Created: Monday, May 4, 2020 9:26:35 PM
// Purpose: Definition of Interface RoomsRepository

using System;

namespace Repository
{
   public interface RoomsRepository : CRUDDao<T,ID>
   {
      List<OperatingRoom> GetAllOperatingRooms();
      
      List<Room> GetAvailableRooms(DateTime startDate, DateTime endDate);
      
      bool AccommodatePatient(Patient patient, DateTime startDate, DateTime endDate, Model.Rooms.Room room);
      
      List<Room> GetAllRooms();
      
      bool TransferPatient(Model.Rooms.Room newRoom);
   
   }
}