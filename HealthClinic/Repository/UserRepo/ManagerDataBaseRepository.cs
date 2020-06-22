// File:    ManagerDataBaseRepository.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:19:33 AM
// Purpose: Definition of Class ManagerDataBaseRepository

using Model.Users;
using System;
using System.Collections.Generic;

namespace Repository.UserRepo
{
    public class ManagerDataBaseRepository : ManagerRepository
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(RegisteredUser entity)
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

        public IEnumerable<RegisteredUser> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegisteredUser> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public RegisteredUser FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(RegisteredUser entity)
        {
            throw new NotImplementedException();
        }

        public void SaveAll(IEnumerable<RegisteredUser> entities)
        {
            throw new NotImplementedException();
        }
    }
}