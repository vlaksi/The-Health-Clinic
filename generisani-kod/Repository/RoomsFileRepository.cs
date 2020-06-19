// File:    RoomsFileRepository.cs
// Author:  Filip Zukovic
// Created: Monday, May 4, 2020 9:27:25 PM
// Purpose: Definition of Class RoomsFileRepository

using System;

namespace Repository
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
      
      public int Count()
      {
         throw new NotImplementedException();
      }
      
      public void Delete(Rooms entity)
      {
         throw new NotImplementedException();
      }
      
      public void DeleteAll()
      {
         throw new NotImplementedException();
      }
      
      public void DeleteById(int identificator)
      {
         throw new NotImplementedException();
      }
      
      public Boolean ExistsById(int id)
      {
         throw new NotImplementedException();
      }
      
      public Iterable<Rooms> FindAll()
      {
         throw new NotImplementedException();
      }
      
      public Rooms FindById(int id)
      {
         throw new NotImplementedException();
      }
      
      public void Save(Rooms entity)
      {
         throw new NotImplementedException();
      }
      
      public void SaveAll(Iterable<Rooms> entities)
      {
         throw new NotImplementedException();
      }
      
      public Iterable<Rooms> FindAllById(Iterable<int> ids)
      {
         throw new NotImplementedException();
      }
      
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