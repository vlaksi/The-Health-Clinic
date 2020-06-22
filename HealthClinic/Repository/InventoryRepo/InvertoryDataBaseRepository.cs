// File:    InvertoryDataBaseRepository.cs
// Author:  Vaxi
// Created: Monday, May 4, 2020 9:27:25 PM
// Purpose: Definition of Class InvertoryDataBaseRepository

using System;
using System.Collections.Generic;
using Model.Rooms;

namespace Repository.InventoryRepo
{
    public class InvertoryDataBaseRepository : InvertoryRepository
    {
        public Invertory AddInvertory(Invertory invertory)
        {
            throw new NotImplementedException();
        }

        public Invertory SellInvertory(Invertory invertory)
        {
            throw new NotImplementedException();
        }

        public Room MoveInvertory(Invertory invertory, Room room)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(Invertory entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int identificator)
        {
            throw new NotImplementedException();
        }

        public bool ExistsById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Invertory> FindAll()
        {
            throw new NotImplementedException();
        }

        public Invertory FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Invertory entity)
        {
            throw new NotImplementedException();
        }

        public void SaveAll(IEnumerable<Invertory> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Invertory> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}