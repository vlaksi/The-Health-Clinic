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
        //TODO SREDITI OVO
        public void SavePatient(PatientModel patientForSave)
        {
            List<PatientModel> allPatients = GetAllPatients();
            PatientModel patientForRemove = null ;
            string filePath = @"./../../../HealthClinic/FileStorage/patients.json";

            foreach (PatientModel patient in allPatients)
            {
                if(patient.Id == patientForSave.Id)
                {
                    patientForRemove = patient;
                    
                    allPatients.Add(patientForSave);
                    break;
                }
            }
            allPatients.Remove(patientForRemove);

            using (StreamWriter file = File.CreateText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, allPatients);
            }
        }
        public List<PatientModel> GetAllPatients()
        {
            string relativePath = @"./../../../HealthClinic/FileStorage/patients.json";
            List<PatientModel>  allPatients = JsonConvert.DeserializeObject<List<PatientModel>>(File.ReadAllText(relativePath));

            if (allPatients == null) allPatients = new List<PatientModel>();

            return allPatients;
        }

        private string filePath;

    }
}