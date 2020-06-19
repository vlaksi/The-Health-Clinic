// File:    RoomHistoryRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 7:05:43 PM
// Purpose: Definition of Interface RoomHistoryRepository

using System;

namespace Repository.RoomHistoryRepo
{
   public interface RoomHistoryRepository : Repository.GenericCRUD.GenericInterfaceCRUDDao<T,ID>
   {
   }
}