// File:    CheckupFileRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 5:16:42 PM
// Purpose: Definition of Class CheckupFileRepository

using Model.Calendar;
using Newtonsoft.Json;
using Repository.GenericCRUD;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Repository.TermRepo
{
    public class CheckupFileRepository : CheckupRepository
    {
        private string filePath = @".\FileStorage\checkup.json";

        public int Count()
        {
            List<Checkup> allCheckups = (List<Checkup>)FindAll();
            return allCheckups.Count;
        }

        public void Delete(Checkup entity)
        {
            DeleteById(entity.Id);
        }

        public void DeleteAll()
        {
            List<Checkup> emptyList = new List<Checkup>();
            SaveAll(emptyList);
        }

        public void DeleteById(int identificator)
        {
            List<Checkup> allCheckups = (List<Checkup>)FindAll();
            Checkup toRemove = null;

            foreach (Checkup checkup in allCheckups)
                if (checkup.Id == identificator)
                    toRemove = checkup;

            if (toRemove != null)
            {
                allCheckups.Remove(toRemove);
                SaveAll(allCheckups);
            }
        }

        public bool ExistsById(int id)
        {
            List<Checkup> allCheckups = (List<Checkup>)FindAll();

            foreach (Checkup checkup in allCheckups)
                if (checkup.Id == id)
                    return true;

            return false;
        }

        public IEnumerable<Checkup> FindAll()
        {
            List<Checkup> allCheckups = JsonConvert.DeserializeObject<List<Checkup>>(File.ReadAllText(filePath));

            if (allCheckups == null) allCheckups = new List<Checkup>();

            return allCheckups;
        }

        public IEnumerable<Checkup> FindAllById(IEnumerable<int> ids)
        {
            List<Checkup> allCheckups = (List<Checkup>)FindAll();
            List<Checkup> matchingCheckups = new List<Checkup>();

            foreach (Checkup checkup in allCheckups)
                if (ids.Contains(checkup.Id))
                    matchingCheckups.Add(checkup);

            return matchingCheckups;
        }

        public Checkup FindById(int id)
        {
            List<Checkup> allCheckups = (List<Checkup>)FindAll();

            foreach (Checkup checkup in allCheckups)
                if (checkup.Id == id)
                    return checkup;

            return null;
        }

        public void Save(Checkup entity)
        {
            if (ExistsById(entity.Id))
                Delete(entity);
            else
                entity.Id = GenerateId();

            List<Checkup> allCheckups = (List<Checkup>)FindAll();
            allCheckups.Add(entity);
            SaveAll(allCheckups);
        }

        public void SaveAll(IEnumerable<Checkup> entities)
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
            List<Checkup> allCheckups = (List<Checkup>)FindAll();
            if (allCheckups.Count == 0) return 1;
            foreach (Checkup checkup in allCheckups)
            {
                if (checkup.Id > maxId) maxId = checkup.Id;
            }

            return maxId + 1;
        }
    }
}