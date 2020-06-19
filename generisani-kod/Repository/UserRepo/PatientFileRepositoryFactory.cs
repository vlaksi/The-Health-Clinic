// File:    PatientFileRepositoryFactory.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 5:47:50 PM
// Purpose: Definition of Class PatientFileRepositoryFactory

using System;

namespace Repository.UserRepo
{
   public class PatientFileRepositoryFactory : IUserRepositoryFacotory
   {
      public IUserRepository CreateIUserRepository()
      {
         throw new NotImplementedException();
      }
   
   }
}