// File:    PatientModelFileRepository.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:19:32 AM
// Purpose: Definition of Class PatientModelFileRepository

using Model.BusinessHours;
using Model.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HealthClinic.Repository.UserRepo.PatientRepo
{
    public class PatientFileRepository : PatientRepository
    {
        private string filePath = @"./../../../HealthClinic/FileStorage/patients.json";

        public int Count()
        {
            List<PatientModel> allPatientModels = (List<PatientModel>)FindAll();
            return allPatientModels.Count;
        }

        public void Delete(PatientModel entity)
        {
            DeleteById(entity.Id);
        }

        public void DeleteAll()
        {
            List<PatientModel> emptyList = new List<PatientModel>();
            SaveAll(emptyList);
        }

        public void DeleteById(int identificator)
        {
            List<PatientModel> allPatientModels = (List<PatientModel>)FindAll();
            PatientModel toRemove = null;

            foreach (PatientModel patient in allPatientModels)
                if (patient.Id == identificator)
                    toRemove = patient;

            if (toRemove != null)
            {
                allPatientModels.Remove(toRemove);
                SaveAll(allPatientModels);
            }
        }

        public bool ExistsById(int id)
        {
            List<PatientModel> allPatientModels = (List<PatientModel>)FindAll();

            foreach (PatientModel patient in allPatientModels)
                if (patient.Id == id)
                    return true;

            return false;
        }

        public IEnumerable<PatientModel> FindAll()
        {
            List<PatientModel> allPatientModels = JsonConvert.DeserializeObject<List<PatientModel>>(File.ReadAllText(filePath));

            if (allPatientModels == null) allPatientModels = new List<PatientModel>();

            return allPatientModels;
        }

        public IEnumerable<PatientModel> FindAllById(IEnumerable<int> ids)
        {
            List<PatientModel> allPatientModels = (List<PatientModel>)FindAll();
            List<PatientModel> matchingPatientModels = new List<PatientModel>();

            foreach (PatientModel patient in allPatientModels)
                if (ids.Contains(patient.Id))
                    matchingPatientModels.Add(patient);

            return matchingPatientModels;
        }

        public PatientModel FindById(int id)
        {
            List<PatientModel> allPatientModels = (List<PatientModel>)FindAll();

            foreach (PatientModel patient in allPatientModels)
                if (patient.Id == id)
                    return patient;

            return null;
        }

        public List<PatientModel> FindMatchedPatientModels(BusinessHoursModel bussinesHours)
        {
            throw new NotImplementedException();
        }

        public List<Specialist> GetAllSpecialistsBySpecialty(string specialty)
        {
            throw new NotImplementedException();
        }

        public void Save(PatientModel entity)
        {
            if (ExistsById(entity.Id))
                Delete(entity);
            else
                entity.Id = GenerateId();

            List<PatientModel> allPatientModels = (List<PatientModel>)FindAll();
            allPatientModels.Add(entity);
            SaveAll(allPatientModels);
        }

        public void SaveAll(IEnumerable<PatientModel> entities)
        {
            using (StreamWriter file = File.CreateText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, entities);
            }
        }

        public void SetPatientModelsBusinessHours(List<PatientModel> patients, BusinessHoursModel businessHours)
        {
            throw new NotImplementedException();
        }

        public int GenerateId()
        {
            int maxId = -1;
            List<PatientModel> allPatientModels = (List<PatientModel>)FindAll();
            if (allPatientModels.Count == 0) return 1;
            foreach (PatientModel patient in allPatientModels)
            {
                if (patient.Id > maxId) maxId = patient.Id;
            }
            return maxId + 1;
        }

        public bool ExistsByJmbg(string jmbg)
        {
            List<PatientModel> allPatientModels = (List<PatientModel>)FindAll();

            foreach (PatientModel patient in allPatientModels)
            {
                if (patient.Jmbg.Equals(jmbg))
                {
                    return true;
                }
            }

            return false;
        }



       
    }
}