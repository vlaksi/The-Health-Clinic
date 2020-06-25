// File:    ManagerDataBaseRepository.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:19:33 AM
// Purpose: Definition of Class ManagerDataBaseRepository

using Model.Users;
using System;
using System.Collections.Generic;

namespace HealthClinic.Repository.UserRepo.ManagerRepo
{
    public class ManagerDataBaseRepository : ManagerRepository
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(Manager entity)
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

        public IEnumerable<Manager> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Manager> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public Manager FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Manager entity)
        {
            throw new NotImplementedException();
        }

        public void SaveAll(IEnumerable<Manager> entities)
        {
            throw new NotImplementedException();
        }
    }
}