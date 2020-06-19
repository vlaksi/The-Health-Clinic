// File:    ITermRepositoryFactory.cs
// Author:  Pufke
// Created: Friday, May 29, 2020 5:37:17 PM
// Purpose: Definition of Interface ITermRepositoryFactory

using System;

namespace Repository
{
   public interface ITermRepositoryFactory
   {
      OperationRepository CreateoperationRepository();
   
   }
}