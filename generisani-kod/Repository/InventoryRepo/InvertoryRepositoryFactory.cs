// File:    InvertoryRepositoryFactory.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 6:20:47 PM
// Purpose: Definition of Interface InvertoryRepositoryFactory

using System;

namespace Repository.InventoryRepo
{
   public interface InvertoryRepositoryFactory
   {
      InvertoryRepository CreateInvertoryRepository();
   
   }
}