// File:    ManagerRepository.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:12:53 AM
// Purpose: Definition of Interface ManagerRepository

using Model.Users;
using Repository.GenericCRUD;
using System;

namespace HealthClinic.Repository.UserRepo.ManagerRepo
{
   public interface ManagerRepository : GenericInterfaceCRUDDao<Manager, int>
   {

   }
}