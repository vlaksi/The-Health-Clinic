// File:    SecretaryRepository.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:12:56 AM
// Purpose: Definition of Interface SecretaryRepository

using Model.Users;
using Repository.GenericCRUD;
using System;

namespace HealthClinic.Repository.UserRepo.SecretaryRepo
{
   public interface SecretaryRepository : GenericInterfaceCRUDDao<Secretary, int>
   {

   }
}