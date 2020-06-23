// File:    CheckupDataBaseRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 5:16:42 PM
// Purpose: Definition of Class CheckupDataBaseRepository

using Model.Calendar;
using System;
using System.Collections.Generic;

namespace Repository.TermRepo
{
    public class CheckupDataBaseRepository : CheckupRepository
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(Checkup entity)
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

        public IEnumerable<Checkup> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Checkup> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public Checkup FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Checkup entity)
        {
            throw new NotImplementedException();
        }

        public void SaveAll(IEnumerable<Checkup> entities)
        {
            throw new NotImplementedException();
        }
    }
}