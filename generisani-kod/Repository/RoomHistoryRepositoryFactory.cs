// File:    RoomHistoryRepositoryFactory.cs
// Author:  Pufke
// Created: Friday, May 29, 2020 6:22:32 PM
// Purpose: Definition of Interface RoomHistoryRepositoryFactory

using System;

namespace Repository
{
   public interface RoomHistoryRepositoryFactory
   {
      RoomHistoryRepository CreateRoomHistoryRepository();
   
   }
}