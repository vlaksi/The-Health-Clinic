// File:    InvertoryService.cs
// Author:  Vaxi
// Created: Monday, June 1, 2020 2:20:04 PM
// Purpose: Definition of Class InvertoryService

using Model.Rooms;
using Repository.InventoryRepo;
using System;

namespace Service.InventoryServ
{
    public class InvertoryService
    {
        public InvertoryRepositoryFactory invertoryRepositoryFactory;

        public Room MoveInvertory(Invertory invertory, Room room)
        {
            throw new NotImplementedException();
        }

        public Invertory SellInvertory(Invertory invertory)
        {
            throw new NotImplementedException();
        }

        public Invertory AddInvertory(Invertory invertory)
        {
            throw new NotImplementedException();
        }


    }
}