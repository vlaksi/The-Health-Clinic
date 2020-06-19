// File:    RoomHistoryRepositoryFactory.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 6:22:32 PM
// Purpose: Definition of Interface RoomHistoryRepositoryFactory

using System;

namespace Repository.RoomHistoryRepo
{
   public interface RoomHistoryRepositoryFactory
   {
      RoomHistoryRepository CreateRoomHistoryRepository();
   
   }
}