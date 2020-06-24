// File:    DoctorFileRepository.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:19:32 AM
// Purpose: Definition of Class DoctorFileRepository

using Model.BusinessHours;
using Model.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repository.UserRepo
{
    public class DoctorFileRepository : DoctorRepository
    {
        private void OpenFile()
        {
            throw new NotImplementedException();
        }

        private void CloseFile()
        {
            throw new NotImplementedException();
        }

        private string filePath;

        public List<Specialist> GetAllSpecialistsBySpecialty(String specialty)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> FindMatchedDoctors(BusinessHoursModel bussinesHours)
        {
            throw new NotImplementedException();
        }

        public void SetDoctorsBusinessHours(List<Doctor> doctors, BusinessHoursModel businessHours)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetAllDoctors()
        {
            List<Doctor> allDoctors;

            string relativePath = @"./../../../HealthClinic/FileStorage/doctors.json";
            allDoctors = JsonConvert.DeserializeObject<List<Doctor>>(File.ReadAllText(relativePath));

            if (allDoctors == null) allDoctors = new List<Doctor>();

            return allDoctors;
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        // TODO: Proveriti da li ovo ovako moze li mora bas doktor a ne registered user da se prosledjuje
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

        public IEnumerable<RegisteredUser> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}