// File:    IUserRepository.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:12:31 AM
// Purpose: Definition of Interface IUserRepository

using System;

namespace Repository.UserRepo
{
   public interface IUserRepository : Repository.GenericCRUD.GenericInterfaceCRUDDao<T,ID>
   {
   }
}