// File:    SecretaryFileRepository.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:19:32 AM
// Purpose: Definition of Class SecretaryFileRepository

using Model.BusinessHours;
using Model.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HealthClinic.Repository.UserRepo.SecretaryRepo
{
    public class SecretaryFileRepository : SecretaryRepository
    {
        //private string filePath = @".\FileStorage\secretary.json";
        private string filePath = @"./../../../../HealthClinic/FileStorage/secretary.json";

        public int Count()
        {
            List<Secretary> allSecretarys = (List<Secretary>)FindAll();
            return allSecretarys.Count;
        }

        public void Delete(Secretary entity)
        {
            DeleteById(entity.Id);
        }

        public void DeleteAll()
        {
            List<Secretary> emptyList = new List<Secretary>();
            SaveAll(emptyList);
        }

        public void DeleteById(int identificator)
        {
            List<Secretary> allSecretarys = (List<Secretary>)FindAll();
            Secretary toRemove = null;

            foreach (Secretary secretary in allSecretarys)
                if (secretary.Id == identificator)
                    toRemove = secretary;

            if (toRemove != null)
            {
                allSecretarys.Remove(toRemove);
                SaveAll(allSecretarys);
            }
        }

        public bool ExistsById(int id)
        {
            List<Secretary> allSecretarys = (List<Secretary>)FindAll();

            foreach (Secretary secretary in allSecretarys)
                if (secretary.Id == id)
                    return true;

            return false;
        }

        public IEnumerable<Secretary> FindAll()
        {
            List<Secretary> allSecretarys = JsonConvert.DeserializeObject<List<Secretary>>(File.ReadAllText(filePath));

            if (allSecretarys == null) allSecretarys = new List<Secretary>();

            return allSecretarys;
        }

        public IEnumerable<Secretary> FindAllById(IEnumerable<int> ids)
        {
            List<Secretary> allSecretarys = (List<Secretary>)FindAll();
            List<Secretary> matchingSecretarys = new List<Secretary>();

            foreach (Secretary secretary in allSecretarys)
                if (ids.Contains(secretary.Id))
                    matchingSecretarys.Add(secretary);

            return matchingSecretarys;
        }

        public Secretary FindById(int id)
        {
            List<Secretary> allSecretarys = (List<Secretary>)FindAll();

            foreach (Secretary secretary in allSecretarys)
                if (secretary.Id == id)
                    return secretary;

            return null;
        }

        public Secretary FindByUsername(String username)
        {
            List<Secretary> allSecretaries = (List<Secretary>)FindAll();

            foreach (Secretary secretary in allSecretaries)
                if (secretary.Username == username)
                    return secretary;

            return null;
        }


        public List<Secretary> FindMatchedSecretarys(BusinessHoursModel bussinesHours)
        {
            throw new NotImplementedException();
        }

        public List<Specialist> GetAllSpecialistsBySpecialty(string specialty)
        {
            throw new NotImplementedException();
        }

        public void makeUpdateFor(Secretary entity)
        {
            Secretary entityForUpdate = FindByUsername(entity.Username);

            entityForUpdate.Name = (entity.Name is null) ? "" : entity.Name;
            entityForUpdate.JobPosition = (entity.JobPosition == "Doctor") ? "Doctor" : "Secretary";
            entityForUpdate.Surname = (entity.Surname is null) ? "" : entity.Surname;
            entityForUpdate.Password = (entity.Password is null) ? "" : entity.Password;

            Save(entityForUpdate);
        }


        public void Save(Secretary entity)
        {
            if (ExistsById(entity.Id))
                Delete(entity);
            else
                entity.Id = GenerateId();

            List<Secretary> allSecretarys = (List<Secretary>)FindAll();
            allSecretarys.Add(entity);
            SaveAll(allSecretarys);
        }

        public void SaveAll(IEnumerable<Secretary> entities)
        {
            using (StreamWriter file = File.CreateText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, entities);
            }
        }

        public void SetSecretarysBusinessHours(List<Secretary> secretaries, BusinessHoursModel businessHours)
        {
            List<Secretary> allSecretaries = (List<Secretary>)FindAll();

            foreach (Secretary tempEntityForChange in secretaries)
            {
                foreach (Employee employee in allSecretaries)
                {
                    if (tempEntityForChange.Username.Equals(employee.Username))
                    {
                        employee.BusinessHours = new BusinessHoursModel();
                        employee.BusinessHours.FromDate = businessHours.FromDate;
                        employee.BusinessHours.ToDate = businessHours.ToDate;
                        employee.BusinessHours.FromHour = businessHours.FromHour;
                        employee.BusinessHours.ToHour = businessHours.ToHour;
                        break;
                    }
                }
            }

            // I want immediately to save changes
            SaveAll(allSecretaries);
        }

        public List<Secretary> getAllFreeSecretaries(BusinessHoursModel businessHours)
        {

            List<Secretary> freeSecretaries = new List<Secretary>();

            foreach (Secretary secretary in FindAll())
            {
                if(secretary.BusinessHours is null)
                {
                    secretary.BusinessHours = new BusinessHoursModel();
                    secretary.BusinessHours.FromDate = DateTime.Today;
                    secretary.BusinessHours.ToDate = DateTime.Today;
                    secretary.BusinessHours.FromHour = DateTime.Today;
                    secretary.BusinessHours.ToHour = DateTime.Today;
                }

                // Check for range of doctor business hours
                if (businessHours.FromDate > secretary.BusinessHours.FromDate && businessHours.FromDate < secretary.BusinessHours.ToDate)
                    continue;

                if (businessHours.ToDate > secretary.BusinessHours.FromDate && businessHours.ToDate < secretary.BusinessHours.ToDate)
                    continue;

                // doctor.BusinessHours.FromDate - doctor.BusinessHours.ToDate
                // businessHours.FromDate - businessHours.ToDate

                freeSecretaries.Add(secretary);
            }

            return freeSecretaries;
        }

        public int GenerateId()
        {
            int maxId = -1;
            List<Secretary> allSecretarys = (List<Secretary>)FindAll();
            if (allSecretarys.Count == 0) return 1;
            foreach (Secretary secretary in allSecretarys)
            {
                if (secretary.Id > maxId) maxId = secretary.Id;
            }

            return maxId + 1;
        }
    }
}