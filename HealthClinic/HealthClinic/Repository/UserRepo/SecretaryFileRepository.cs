// File:    SecretaryFileRepository.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:19:34 AM
// Purpose: Definition of Class SecretaryFileRepository

using Model.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repository.UserRepo
{
    public class SecretaryFileRepository : SecretaryRepository
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

        public List<Secretary> getAllSecretaries()
        {
            List<Secretary> allSecretary;

            allSecretary = JsonConvert.DeserializeObject<List<Secretary>>(File.ReadAllText(filePath));

            if (allSecretary == null) allSecretary = new List<Secretary>();

            return allSecretary;
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

        public void SaveAllSecretaries(IEnumerable<Secretary> entities)
        {
            using (StreamWriter file = File.CreateText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, entities);
            }
        }

        public IEnumerable<RegisteredUser> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        private string filePath = @"./../../../../HealthClinic/FileStorage/secretary.json";



    }
}