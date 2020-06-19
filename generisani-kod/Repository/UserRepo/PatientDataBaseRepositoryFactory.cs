// File:    PatientDataBaseRepositoryFactory.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 5:47:49 PM
// Purpose: Definition of Class PatientDataBaseRepositoryFactory

using System;

namespace Repository.UserRepo
{
   public class PatientDataBaseRepositoryFactory : IUserRepositoryFacotory
   {
      public IUserRepository CreateIUserRepository()
      {
         throw new NotImplementedException();
      }
   
   }
}