// File:    RoomHistoryRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 7:05:43 PM
// Purpose: Definition of Interface RoomHistoryRepository

using System;
using Repository.GenericCRUD;
using Model.Patient;

namespace Repository.RoomHistoryRepo
{
   public interface RoomHistoryRepository : GenericInterfaceCRUDDao<RoomsHistory,int>
   {
   }
}