// File:    MedicineDataBaseRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 5:16:42 PM
// Purpose: Definition of Class MedicineDataBaseRepository

using Model.Medicine;
using System;
using System.Collections.Generic;

namespace Repository.MedicineRepo
{
    public class MedicineDataBaseRepository : MedicineRepository
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(Medicine entity)
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

        public IEnumerable<Medicine> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Medicine> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public Medicine FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void makeUpdateFor(Medicine medicine)
        {
            throw new NotImplementedException();
        }

        public void Save(Medicine entity)
        {
            throw new NotImplementedException();
        }

        public void SaveAll(IEnumerable<Medicine> entities)
        {
            throw new NotImplementedException();
        }
    }
}