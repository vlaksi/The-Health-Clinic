// File:    ITermRepositoryFactory.cs
// Author:  Filip Zukovic
// Created: Friday, May 29, 2020 5:37:17 PM
// Purpose: Definition of Interface ITermRepositoryFactory

using System;

namespace Service
{
   public interface ITermRepositoryFactory
   {
      OperationRepository CreateoperationRepository();
   
   }
}