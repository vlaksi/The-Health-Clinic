// File:    RoomHistoryRepositoryFactory.cs
// Author:  Filip Zukovic
// Created: Friday, May 29, 2020 6:22:32 PM
// Purpose: Definition of Interface RoomHistoryRepositoryFactory

using System;

namespace Service
{
   public interface RoomHistoryRepositoryFactory
   {
      RoomHistoryRepository CreateRoomHistoryRepository();
   
   }
}