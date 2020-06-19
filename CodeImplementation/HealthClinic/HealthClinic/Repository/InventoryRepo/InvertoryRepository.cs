// File:    InvertoryRepository.cs
// Author:  Vaxi
// Created: Monday, May 4, 2020 9:26:35 PM
// Purpose: Definition of Interface InvertoryRepository

using System;
using Repository.GenericCRUD;
using Model.Rooms;

namespace Repository.InventoryRepo
{
   public interface InvertoryRepository : GenericInterfaceCRUDDao<Invertory,int>
   {
      Room MoveInvertory(Invertory invertory, Room room);
      
      Invertory SellInvertory(Invertory invertory);
      
      Invertory AddInvertory(Invertory invertory);
   
   }
}