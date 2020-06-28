// File:    ManagerFileRepository.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:19:33 AM
// Purpose: Definition of Class ManagerFileRepository

using Model.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HealthClinic.Repository.UserRepo.ManagerRepo
{
    public class ManagerFileRepository : ManagerRepository
    {
        private string filePath = @".\FileStorage\manager.json";

        public int Count()
        {
            List<Manager> allManagers = (List<Manager>)FindAll();
            return allManagers.Count;
        }

        public void Delete(Manager entity)
        {
            DeleteById(entity.Id);
        }

        public void DeleteAll()
        {
            List<Manager> emptyList = new List<Manager>();
            SaveAll(emptyList);
        }

        public void DeleteById(int identificator)
        {
            List<Manager> allManagers = (List<Manager>)FindAll();
            Manager toRemove = null;

            foreach (Manager manager in allManagers)
                if (manager.Id == identificator)
                    toRemove = manager;

            if (toRemove != null)
            {
                allManagers.Remove(toRemove);
                SaveAll(allManagers);
            }
        }

        public bool ExistsById(int id)
        {
            List<Manager> allManagers = (List<Manager>)FindAll();

            foreach (Manager manager in allManagers)
                if (manager.Id == id)
                    return true;

            return false;
        }

        public IEnumerable<Manager> FindAll()
        {
            List<Manager> allManagers = JsonConvert.DeserializeObject<List<Manager>>(File.ReadAllText(filePath));

            if (allManagers == null) allManagers = new List<Manager>();

            return allManagers;
        }

        public IEnumerable<Manager> FindAllById(IEnumerable<int> ids)
        {
            List<Manager> allManagers = (List<Manager>)FindAll();
            List<Manager> matchingManagers = new List<Manager>();

            foreach (Manager manager in allManagers)
                if (ids.Contains(manager.Id))
                    matchingManagers.Add(manager);

            return matchingManagers;
        }

        public Manager FindById(int id)
        {
            List<Manager> allManagers = (List<Manager>)FindAll();

            foreach (Manager manager in allManagers)
                if (manager.Id == id)
                    return manager;

            return null;
        }

        public void Save(Manager entity)
        {
            if (ExistsById(entity.Id))
                Delete(entity);
            else
                entity.Id = GenerateId();

            List<Manager> allManagers = (List<Manager>)FindAll();
            allManagers.Add(entity);
            SaveAll(allManagers);
        }

        public void SaveAll(IEnumerable<Manager> entities)
        {
            using (StreamWriter file = File.CreateText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, entities);
            }
        }

        public int GenerateId()
        {
            int maxId = -1;
            List<Manager> allManagers = (List<Manager>)FindAll();
            if (allManagers.Count == 0) return 1;
            foreach (Manager manager in allManagers)
            {
                if (manager.Id > maxId) maxId = manager.Id;
            }

            return maxId + 1;
        }
    }
}