// File:    IUserRepositoryFacotory.cs
// Author:  Pufke
// Created: Friday, May 29, 2020 5:46:07 PM
// Purpose: Definition of Interface IUserRepositoryFacotory

using System;

namespace Repository
{
   public interface IUserRepositoryFacotory
   {
      IUserRepository CreateIUserRepository();
   
   }
}