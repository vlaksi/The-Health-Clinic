// File:    RoomsHistoryService.cs
// Author:  Vaxi
// Created: Tuesday, May 19, 2020 11:41:51 PM
// Purpose: Definition of Class RoomsHistoryService

using Model.Patient;
using Model.Rooms;
using Repository.RoomHistoryRepo;
using System;

namespace Service.RoomHistoryServ
{
   public class RoomsHistoryService
   {
      public RoomHistoryRepositoryFactory roomHistoryRepositoryFactory;

      public RoomsHistory GetRoomHistory(Room room)
      {
         throw new NotImplementedException();
      }
      
      public void UpdateRoomHistory(Room room)
      {
         throw new NotImplementedException();
      }
      
      public void DeleteRoomHistory(Room room)
      {
         throw new NotImplementedException();
      }
      
      public RoomsHistory AddRoomHistory(Room room)
      {
         throw new NotImplementedException();
      }
      
   
   }
}