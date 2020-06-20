// File:    RoomsRepositoryFactory.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 6:20:47 PM
// Purpose: Definition of Interface RoomsRepositoryFactory

using System;

namespace Repository.RoomsRepo
{
   public interface RoomsRepositoryFactory
   {
      RoomsRepository CreateRoomsRepository();
   
   }
}