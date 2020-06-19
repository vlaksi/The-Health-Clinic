// File:    RoomHistoryFileRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 5:16:42 PM
// Purpose: Definition of Class RoomHistoryFileRepository

using System;

namespace Repository
{
   public class RoomHistoryFileRepository<RoomHistory,int> : RoomHistoryRepository where RoomHistory : T
    where int : ID
   {
      private void OpenFIle()
      {
         throw new NotImplementedException();
      }
      
      private void CloseFIle()
      {
         throw new NotImplementedException();
      }
      
      private string filePath;
   
   }
}