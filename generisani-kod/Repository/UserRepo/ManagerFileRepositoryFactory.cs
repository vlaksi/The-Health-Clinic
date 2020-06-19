// File:    ManagerFileRepositoryFactory.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 5:47:50 PM
// Purpose: Definition of Class ManagerFileRepositoryFactory

using System;

namespace Repository.UserRepo
{
   public class ManagerFileRepositoryFactory : IUserRepositoryFacotory
   {
      public IUserRepository CreateIUserRepository()
      {
         throw new NotImplementedException();
      }
   
   }
}