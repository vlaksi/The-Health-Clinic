// File:    InvertoryFileRepository.cs
// Author:  Vaxi
// Created: Monday, May 4, 2020 9:27:25 PM
// Purpose: Definition of Class InvertoryFileRepository

using System;

namespace Repository.InventoryRepo
{
   public class InvertoryFileRepository<Rooms,int> : InvertoryRepository where Rooms : T
    where int : ID
   {
      private void OpenFIle()
      {
         throw new NotImplementedException();
      }
      
      private void CloseFile()
      {
         throw new NotImplementedException();
      }
      
      private string filePath;
      
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