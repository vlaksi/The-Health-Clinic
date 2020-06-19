// File:    InvertoryDataBaseRepository.cs
// Author:  Vaxi
// Created: Monday, May 4, 2020 9:27:25 PM
// Purpose: Definition of Class InvertoryDataBaseRepository

using System;

namespace Repository.InventoryRepo
{
   public class InvertoryDataBaseRepository<Rooms,int> : InvertoryRepository where Rooms : T
    where int : ID
   {
      public Invertory AddInvertory(Invertory invertory)
      {
         throw new NotImplementedException();
      }
      
      public Invertory SellInvertory(Invertory invertory)
      {
         throw new NotImplementedException();
      }
      
      public Room MoveInvertory(Invertory invertory, Room room)
      {
         throw new NotImplementedException();
      }
   
   }
}