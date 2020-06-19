// File:    InvertoryDataBaseRepository.cs
// Author:  Igorr
// Created: Monday, May 4, 2020 9:27:25 PM
// Purpose: Definition of Class InvertoryDataBaseRepository

using System;

namespace Repository
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
      
      public int Count()
      {
         throw new NotImplementedException();
      }
      
      public void Delete(T entity)
      {
         throw new NotImplementedException();
      }
      
      public void DeleteAll()
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
      
      public Iterable<T> FindAll()
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
   
   }
}