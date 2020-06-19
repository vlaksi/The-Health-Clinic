// File:    InvertoryRepository.cs
// Author:  Igorr
// Created: Monday, May 4, 2020 9:26:35 PM
// Purpose: Definition of Interface InvertoryRepository

using System;

namespace Repository
{
   public interface InvertoryRepository : CRUDDao<T,ID>
   {
      Room MoveInvertory(Invertory invertory, Room room);
      
      Invertory SellInvertory(Invertory invertory);
      
      Invertory AddInvertory(Invertory invertory);
   
   }
}