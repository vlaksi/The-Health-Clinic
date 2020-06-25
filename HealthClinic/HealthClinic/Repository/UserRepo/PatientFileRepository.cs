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
        private string filePath = @"./../../../HealthClinic/FileStorage/patients.json";

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
        public PatientModel FindPatientById(int id)
        {
            List<PatientModel> allPatients = GetAllPatients();

            foreach (PatientModel patient in allPatients)
            {
                if (patient.Id == id)
                {
                    return patient;
                }
            }
            return null;
        }

        public void SavePatient(PatientModel patientForSave)
        {
            List<PatientModel> allPatients = GetAllPatients();
            allPatients.Add(patientForSave);

            using (StreamWriter file = File.CreateText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, allPatients);
            }
        }

        public void SavePatients(List<PatientModel> patientsForSave)
        {
            using (StreamWriter file = File.CreateText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, patientsForSave);
            }
        }

        public void EditPatient(PatientModel patientForEdit)
        {
            List<PatientModel> allPatients = GetAllPatients();
            PatientModel patientForRemove = null;

            foreach (PatientModel patient in allPatients)
            {
                if (patient.Id == patientForEdit.Id)
                {
                    patientForRemove = patient;
                    allPatients.Add(patientForEdit);
                    break;
                }
            }
            allPatients.Remove(patientForRemove);
            SavePatients(allPatients);
        }

        public List<PatientModel> GetAllPatients()
        {
            List<PatientModel>  allPatients = JsonConvert.DeserializeObject<List<PatientModel>>(File.ReadAllText(filePath));

            if (allPatients == null) allPatients = new List<PatientModel>();

            return allPatients;
        }

    

    }
}