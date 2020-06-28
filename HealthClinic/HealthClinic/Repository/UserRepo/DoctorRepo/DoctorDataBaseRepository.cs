// File:    DoctorDataBaseRepository.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:19:32 AM
// Purpose: Definition of Class DoctorDataBaseRepository

using Model.BusinessHours;
using Model.Users;
using System;
using System.Collections.Generic;

namespace HealthClinic.Repository.UserRepo.DoctorRepo
{
    public class DoctorDataBaseRepository : DoctorRepository
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(Doctor entity)
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

        public IEnumerable<Doctor> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public Doctor FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> FindMatchedDoctors(BusinessHoursModel bussinesHours)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> getAllFreeDoctors(BusinessHoursModel businessHours)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetAllSpecialistsBySpecialty(SpecialtyType specialtyType)
        {
            throw new NotImplementedException();
        }

        public void makeUpdateFor(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public void Save(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public void SaveAll(IEnumerable<Doctor> entities)
        {
            throw new NotImplementedException();
        }

        public void SetDoctorsBusinessHours(List<Doctor> doctors, BusinessHoursModel businessHours)
        {
            throw new NotImplementedException();
        }
    }
}