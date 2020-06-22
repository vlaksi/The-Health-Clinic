// File:    MedicalRecordFileRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 5:16:42 PM
// Purpose: Definition of Class MedicalRecordFileRepository

using System;
using Model.MedicalRecord;
using Model.Calendar;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace Repository.MedicalRecordRepo
{
    public class MedicalRecordFileRepository : MedicalRecordRepository
    {
        
        public MedicalRecordFileRepository()
        {
            filePath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()))));
            filePath += @"\HealthClinic\FileStorage\medicalRecords.json";
        }

        private void OpenFile()
        {
            throw new NotImplementedException();
        }

        private void CloseFile()
        {
            throw new NotImplementedException();
        }

        private string filePath;

        public void SaveReport(Report report)
        {
            throw new NotImplementedException();
        }

        public void SaveReferral(ReferralToSpecialist referral)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            List<MedicalRecord> allRecords = (List<MedicalRecord>)FindAll();
            return allRecords.Count;
        }

        public void Delete(MedicalRecord entity)
        {
            DeleteById(entity.Jmbg);
        }

        public void DeleteAll()
        {
            System.IO.File.WriteAllText(filePath, string.Empty);
        }

        public void DeleteById(string identificator)
        {
            List<MedicalRecord> allRecords = (List<MedicalRecord>)FindAll();
            MedicalRecord toRemove = null;

            foreach (MedicalRecord record in allRecords)
                if (record.Jmbg.Equals(identificator))
                    toRemove = record;

            if (toRemove != null)
            {
                allRecords.Remove(toRemove);
                DeleteAll();
                SaveAll(allRecords);
            }

        }

        public bool ExistsById(string id)
        {
            List<MedicalRecord> allRecords = (List<MedicalRecord>)FindAll();

            foreach (MedicalRecord record in allRecords)
                if (record.Jmbg.Equals(id))
                    return true;

            return false;
        }

        public IEnumerable<MedicalRecord> FindAll()
        {
            List<MedicalRecord> medicalRecords = new List<MedicalRecord>();

            medicalRecords = JsonConvert.DeserializeObject<List<MedicalRecord>>(File.ReadAllText(filePath));

            return medicalRecords;
        }

        public MedicalRecord FindById(string id)
        {
            List<MedicalRecord> allRecords = (List<MedicalRecord>)FindAll();

            foreach (MedicalRecord record in allRecords)
                if (record.Jmbg.Equals(id))
                    return record;

            return null;
        }

        public void Save(MedicalRecord entity)
        {

            using (StreamWriter file = File.CreateText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, entity);
            }

        }

        public void SaveAll(IEnumerable<MedicalRecord> entities)
        {

            using (StreamWriter file = File.CreateText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, entities);
            }

        }

        public IEnumerable<MedicalRecord> FindAllById(IEnumerable<string> ids)
        {
            List<MedicalRecord> allRecords = (List<MedicalRecord>)FindAll();
            List<MedicalRecord> matchingRecords = new List<MedicalRecord>();

            foreach (MedicalRecord record in allRecords)
                if (ids.Contains(record.Jmbg))
                    matchingRecords.Add(record);

            return matchingRecords;
        }
    }
}