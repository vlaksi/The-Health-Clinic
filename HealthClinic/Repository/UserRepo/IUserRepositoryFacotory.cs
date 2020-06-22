// File:    IUserRepositoryFacotory.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 5:46:07 PM
// Purpose: Definition of Interface IUserRepositoryFacotory

using System;

namespace Repository.UserRepo
{
   public interface IUserRepositoryFacotory
   {
      IUserRepository CreateIUserRepository();
   
   }
}