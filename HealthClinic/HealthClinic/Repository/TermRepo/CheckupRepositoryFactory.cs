// File:    ITermRepositoryFactory.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 5:37:17 PM
// Purpose: Definition of Interface ITermRepositoryFactory

using System;

namespace Repository.TermRepo
{
   public interface CheckupRepositoryFactory
   {
        CheckupRepository CreateCheckupRepository();
    }
}