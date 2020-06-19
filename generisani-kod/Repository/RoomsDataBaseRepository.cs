// File:    RoomsDataBaseRepository.cs
// Author:  Vaxi
// Created: Monday, May 4, 2020 9:27:25 PM
// Purpose: Definition of Class RoomsDataBaseRepository

using System;

namespace Repository
{
   public class RoomsDataBaseRepository<Rooms,int> : RoomsRepository where Rooms : T
    where int : ID
   {
      public void Delete(T entity)
      {
         throw new NotImplementedException();
      }
      
      public void DeleteById(ID identificator)
      {
         throw new NotImplementedException();
      }
      
      public Boolean ExistsById(ID id)
      {
         throw new NotImplementedException();
      }
      
      public T FindById(ID id)
      {
         throw new NotImplementedException();
      }
      
      public void Save(T entity)
      {
         throw new NotImplementedException();
      }
      
      public void SaveAll(Iterable<T> entities)
      {
         throw new NotImplementedException();
      }
      
      public Iterable<T> FindAllById(Iterable<ID> ids)
      {
         throw new NotImplementedException();
      }
      
      public int Count()
      {
         throw new NotImplementedException();
      }
      
      public void DeleteAll()
      {
         throw new NotImplementedException();
      }
      
      public Iterable<T> FindAll()
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
      
      public bool AccommodatePatient(Patient patient, DateTime startDate, DateTime endDate, Model.Rooms.Room room)
      {
         throw new NotImplementedException();
      }
      
      public List<Room> GetAllRooms()
      {
         throw new NotImplementedException();
      }
      
      public bool TransferPatient(Model.Rooms.Room newRoom)
      {
         throw new NotImplementedException();
      }
   
   }
}