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
            List<Checkup> allCheckups = new List<Checkup>();

            string relativePath = @"./../../../HealthClinic/FileStorage/checkup.json";
            allCheckups = JsonConvert.DeserializeObject<List<Checkup>>(File.ReadAllText(relativePath));

            return allCheckups;
        }

        public Term FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Term entity)
        {
            throw new NotImplementedException();
        }


        public void SaveAll(IEnumerable<Checkup> entities)
        {
            string relativePath = @"./../../../HealthClinic/FileStorage/checkup.json";

            using (StreamWriter file = File.CreateText(relativePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, entities);
            }

        }

        public IEnumerable<Term> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }


        private string filePath;



    }
}