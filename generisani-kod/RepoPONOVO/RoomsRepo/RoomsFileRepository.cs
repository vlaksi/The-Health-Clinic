// File:    RoomsFileRepository.cs
// Author:  Vaxi
// Created: Monday, May 4, 2020 9:27:25 PM
// Purpose: Definition of Class RoomsFileRepository

using System;

namespace Repository.RoomsRepo
{
   public class RoomsFileRepository<Rooms,int> : RoomsRepository where Rooms : T
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
      
      public List<OperatingRoom> GetAllOperatingRooms()
      {
         throw new NotImplementedException();
      }
      
      public List<Room> GetAvailableRooms(DateTime startDate, DateTime endDate)
      {
         throw new NotImplementedException();
      }
      
      public bool AccommodatePatient(Patient patient, DateTime startDate, DateTime endDate, Room room)
      {
         throw new NotImplementedException();
      }
      
      public List<Room> GetAllRooms()
      {
         throw new NotImplementedException();
      }
      
      public bool TransferPatient(Room newRoom)
      {
         throw new NotImplementedException();
      }
   
   }
}