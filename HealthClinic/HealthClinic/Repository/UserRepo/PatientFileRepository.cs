// File:    PatientFileRepository.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:19:33 AM
// Purpose: Definition of Class PatientFileRepository

using Model.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repository.UserRepo
{
    public class PatientFileRepository : PatientRepository
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

        public List<PatientModel> GetAllPatients()
        {
            List<PatientModel> entites = new List<PatientModel>();
            entites.Add(new PatientModel { Id = 1 , Name = "Marko", Surname = "Markovic", PhoneNumber= "0602545687" , Adress = "Narodnog Fronta, Novi Sad", Birthday= new DateTime(1980, 1, 1, 0, 0, 0), Biography="IT radnik vec 20 godina, veoma fizicki aktivan", Jmbg = "0105998800079", Password="12345678" });
            string filePath = @"./../../../HealthClinic/FileStorage/patients.json";
            using (StreamWriter file = File.CreateText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, entites);
            }

            string relativePath = @"./../../../HealthClinic/FileStorage/patients.json";
            List<PatientModel>  allPatients = JsonConvert.DeserializeObject<List<PatientModel>>(File.ReadAllText(relativePath));

            if (allPatients == null) allPatients = new List<PatientModel>();

            return allPatients;
        }

        private string filePath;

    }
}