// File:    DoctorFileRepositoryFactory.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 5:47:52 PM
// Purpose: Definition of Class DoctorFileRepositoryFactory

using System;

namespace Repository.UserRepo
{
   public class DoctorFileRepositoryFactory : IUserRepositoryFacotory
   {
      public IUserRepository CreateIUserRepository()
      {
         throw new NotImplementedException();
      }
   
   }
}