// File:    SecretaryDataBaseRepository.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:19:34 AM
// Purpose: Definition of Class SecretaryDataBaseRepository

using Model.BusinessHours;
using Model.Users;
using System;
using System.Collections.Generic;

namespace HealthClinic.Repository.UserRepo.SecretaryRepo
{
    public class SecretaryDataBaseRepository : SecretaryRepository
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(Secretary entity)
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

        public IEnumerable<Secretary> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Secretary> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public Secretary FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Secretary> getAllFreeSecretaries(BusinessHoursModel businessHours)
        {
            throw new NotImplementedException();
        }

        public void makeUpdateFor(Secretary entity)
        {
            throw new NotImplementedException();
        }

        public void Save(Secretary entity)
        {
            throw new NotImplementedException();
        }

        public void SaveAll(IEnumerable<Secretary> entities)
        {
            throw new NotImplementedException();
        }

        public void SetSecretarysBusinessHours(List<Secretary> doctors, BusinessHoursModel businessHours)
        {
            throw new NotImplementedException();
        }
    }
}