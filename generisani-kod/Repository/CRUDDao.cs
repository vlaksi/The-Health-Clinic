// File:    CRUDDao.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 4:51:43 PM
// Purpose: Definition of Interface CRUDDao

using System;

namespace Repository
{
   public interface CRUDDao<T,ID>
   {
      int Count();
      
      void Delete(T entity);
      
      void DeleteAll();
      
      void DeleteById(ID identificator);
      
      Boolean ExistsById(ID id);
      
      Iterable<T> FindAll();
      
      T FindById(ID id);
      
      void Save(T entity);
      
      void SaveAll(Iterable<T> entities);
      
      Iterable<T> FindAllById(Iterable<ID> ids);
   
   }
}