// File:    InvertoryRepository.cs
// Author:  Vaxi
// Created: Monday, May 4, 2020 9:26:35 PM
// Purpose: Definition of Interface InvertoryRepository

using System;

namespace Repository.InventoryRepo
{
   public interface InvertoryRepository : Repository.GenericCRUD.GenericInterfaceCRUDDao<T,ID>
   {
      Room MoveInvertory(Invertory invertory, Room room);
      
      Invertory SellInvertory(Invertory invertory);
      
      Invertory AddInvertory(Invertory invertory);
   
   }
}