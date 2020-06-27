// File:    PatientDataBaseRepository.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:19:33 AM
// Purpose: Definition of Class PatientDataBaseRepository

using Model.Users;
using System;
using System.Collections.Generic;

namespace HealthClinic.Repository.UserRepo.PatientRepo
{
    public class PatientDataBaseRepository : PatientRepository
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(PatientModel entity)
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

        public bool ExistsByJmbg(string jmbg)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PatientModel> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PatientModel> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public PatientModel FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(PatientModel entity)
        {
            throw new NotImplementedException();
        }

        public void SaveAll(IEnumerable<PatientModel> entities)
        {
            throw new NotImplementedException();
        }
    }
}