// File:    RoomsFileRepositoryFactory.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 6:21:09 PM
// Purpose: Definition of Class RoomsFileRepositoryFactory

using System;

namespace Repository.RoomsRepo
{
    public class RoomsFileRepositoryFactory : RoomsRepositoryFactory
    {
        private RoomsFileRepository roomsFileRepository;

        public RoomsRepository CreateRoomsRepository()
        {
            if (roomsFileRepository == null)
                roomsFileRepository = new RoomsFileRepository();

            return roomsFileRepository;
        }


    }
}