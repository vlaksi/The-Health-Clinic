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

namespace Repository.TermRepo
{
    public class CheckupFileRepository : CheckupRepository
    {

        private string filePath = @"./../../../HealthClinic/FileStorage/checkup.json";

        private void OpenFile()
        {
            throw new NotImplementedException();
        }

        private void CloseFile()
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(Term entity)
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

        public IEnumerable<Checkup> FindAll()
        {

            List<Checkup> allCheckups = JsonConvert.DeserializeObject<List<Checkup>>(File.ReadAllText(filePath));

            if (allCheckups == null) allCheckups = new List<Checkup>();

            return allCheckups;
        }

        public Term FindById(int id)
        {
            throw new NotImplementedException();
        }

        public int Save(Checkup entity)
        {
            entity.Id = GenerateId();

            List<Checkup> allCheckups = (List<Checkup>)FindAll();
            allCheckups.Add(entity);
            SaveAll(allCheckups);

            return entity.Id;
        }

        public void SaveAll(IEnumerable<Checkup> entities)
        {

            using (StreamWriter file = File.CreateText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, entities);
            }
        }

        public IEnumerable<Term> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Term> GenericInterfaceCRUDDao<Term, int>.FindAll()
        {
            throw new NotImplementedException();
        }

        public void SaveAll(IEnumerable<Term> entities)
        {
            throw new NotImplementedException();
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

        public void Save(Term entity)
        {
            throw new NotImplementedException();
        }
    }
}