// File:    GenericInterfaceCRUDDao.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 4:51:43 PM
// Purpose: Definition of Interface GenericInterfaceCRUDDao

using System;
using System.Collections.Generic;

namespace Repository.GenericCRUD
{
   public interface GenericInterfaceCRUDDao<T,ID>
   {
      int Count();
      
      void Delete(T entity);
      
      void DeleteAll();
      
      void DeleteById(ID identificator);
      
      Boolean ExistsById(ID id);
      
      IEnumerable<T> FindAll();
      
      T FindById(ID id);
      
      void Save(T entity);
      
      void SaveAll(IEnumerable<T> entities);
      
      IEnumerable<T> FindAllById(IEnumerable<ID> ids);
   
   }
}