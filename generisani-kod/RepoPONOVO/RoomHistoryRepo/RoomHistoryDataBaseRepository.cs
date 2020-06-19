// File:    RoomHistoryDataBaseRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 5:16:42 PM
// Purpose: Definition of Class RoomHistoryDataBaseRepository

using System;

namespace Repository.RoomHistoryRepo
{
   public class RoomHistoryDataBaseRepository<RoomHistory,int> : RoomHistoryRepository where RoomHistory : T
    where int : ID
   {
      public Iterable<RoomHistory> FindAllById(Iterable<int> ids)
      {
         throw new NotImplementedException();
      }
      
      public int Count()
      {
         throw new NotImplementedException();
      }
      
      public void Delete<T>(RoomHistory entity)
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
      
      public Iterable<RoomHistory> FindAll()
      {
         throw new NotImplementedException();
      }
      
      public RoomHistory FindById(int id)
      {
         throw new NotImplementedException();
      }
      
      public void Save(RoomHistory entity)
      {
         throw new NotImplementedException();
      }
      
      public void SaveAll(Iterable<RoomHistory> entities)
      {
         throw new NotImplementedException();
      }
   
   }
}