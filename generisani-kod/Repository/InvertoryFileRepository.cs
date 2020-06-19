// File:    InvertoryFileRepository.cs
// Author:  Igorr
// Created: Monday, May 4, 2020 9:27:25 PM
// Purpose: Definition of Class InvertoryFileRepository

using System;

namespace Repository
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
   
   }
}