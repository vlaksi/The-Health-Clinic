// File:    DoctorDataBaseRepository.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:19:32 AM
// Purpose: Definition of Class DoctorDataBaseRepository

using Model.BusinessHours;
using Model.Users;
using System;
using System.Collections.Generic;

namespace Repository.UserRepo
{
    public class DoctorDataBaseRepository : DoctorRepository
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

        public List<Doctor> FindMatchedDoctors(BusinessHoursModel bussinesHours)
        {
            throw new NotImplementedException();
        }

        public List<Specialist> GetAllSpecialistsBySpecialty(string specialty)
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

        public void SetDoctorsBusinessHours(List<Doctor> doctors, BusinessHoursModel businessHours)
        {
            throw new NotImplementedException();
        }
    }
}