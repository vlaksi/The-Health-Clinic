// File:    SecretaryFileRepositoryFactory.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 5:47:48 PM
// Purpose: Definition of Class SecretaryFileRepositoryFactory

using System;

namespace Repository.UserRepo
{
   public class SecretaryFileRepositoryFactory : IUserRepositoryFacotory
   {
      public IUserRepository CreateIUserRepository()
      {
         throw new NotImplementedException();
      }
   
   }
}