// File:    RoomsRepositoryFactory.cs
// Author:  Pufke
// Created: Friday, May 29, 2020 6:20:47 PM
// Purpose: Definition of Interface RoomsRepositoryFactory

using System;

namespace Repository
{
   public interface RoomsRepositoryFactory
   {
      RoomsRepository CreateRoomsRepository();
   
   }
}