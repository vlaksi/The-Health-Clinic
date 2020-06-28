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
using System.Linq;

namespace HealthClinic.Repository.UserRepo.DoctorRepo
{
    public class DoctorFileRepository : DoctorRepository
    {
        private string filePath = @"./../../../HealthClinic/FileStorage/doctors.json";

        public int Count()
        {
            List<Doctor> allDoctors = (List<Doctor>)FindAll();
            return allDoctors.Count;
        }

        public void Delete(Doctor entity)
        {
            DeleteById(entity.Id);
        }

        public void DeleteAll()
        {
            List<Doctor> emptyList = new List<Doctor>();
            SaveAll(emptyList);
        }

        public void DeleteById(int identificator)
        {
            List<Doctor> allDoctors = (List<Doctor>)FindAll();
            Doctor toRemove = null;

            foreach (Doctor doctor in allDoctors)
                if (doctor.Id == identificator)
                    toRemove = doctor;

            if (toRemove != null)
            {
                allDoctors.Remove(toRemove);
                SaveAll(allDoctors);
            }
        }

        public bool ExistsById(int id)
        {
            List<Doctor> allDoctors = (List<Doctor>)FindAll();

            foreach (Doctor doctor in allDoctors)
                if (doctor.Id == id)
                    return true;

            return false;
        }

        public IEnumerable<Doctor> FindAll()
        {
            List<Doctor> allDoctors = JsonConvert.DeserializeObject<List<Doctor>>(File.ReadAllText(filePath));

            if (allDoctors == null) allDoctors = new List<Doctor>();

            return allDoctors;
        }

        public IEnumerable<Doctor> FindAllById(IEnumerable<int> ids)
        {
            List<Doctor> allDoctors = (List<Doctor>)FindAll();
            List<Doctor> matchingDoctors = new List<Doctor>();

            foreach (Doctor doctor in allDoctors)
                if (ids.Contains(doctor.Id))
                    matchingDoctors.Add(doctor);

            return matchingDoctors;
        }

        public Doctor FindById(int id)
        {
            List<Doctor> allDoctors = (List<Doctor>)FindAll();

            foreach (Doctor doctor in allDoctors)
                if (doctor.Id == id)
                    return doctor;

            return null;
        }

        public List<Doctor> FindMatchedDoctors(BusinessHoursModel bussinesHours)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetAllSpecialistsBySpecialty(SpecialtyType specialtyType)
        {
            List<Doctor> results = new List<Doctor>();
            List<Doctor> allDoctors = (List<Doctor>)FindAll();
            foreach(Doctor doctor in allDoctors)
            {
                if(doctor.SpecialtyType == specialtyType)
                {
                    results.Add(doctor);
                }
            }

            return results;
        }

        public void Save(Doctor entity)
        {
            if (ExistsById(entity.Id))
                Delete(entity);
            else
                entity.Id = GenerateId();

            List<Doctor> allDoctors = (List<Doctor>)FindAll();
            allDoctors.Add(entity);
            SaveAll(allDoctors);
        }

        public void SaveAll(IEnumerable<Doctor> entities)
        {
          
            using (StreamWriter file = File.CreateText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, entities);
            }
        }

        public void SetDoctorsBusinessHours(List<Doctor> doctors, BusinessHoursModel businessHours)
        {
            throw new NotImplementedException();
        }

        public int GenerateId()
        {
            int maxId = -1;
            List<Doctor> allDoctors = (List<Doctor>)FindAll();
            if (allDoctors.Count == 0) return 1;
            foreach (Doctor doctor in allDoctors)
            {
                if (doctor.Id > maxId) maxId = doctor.Id;
            }

            return maxId + 1;
        }
    }
}