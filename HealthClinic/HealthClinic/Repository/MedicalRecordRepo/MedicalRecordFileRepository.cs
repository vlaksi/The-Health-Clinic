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
using System.Collections.ObjectModel;
using Model.Medicine;


namespace Repository.MedicalRecordRepo
{
    public class MedicalRecordFileRepository : MedicalRecordRepository
    {
        private string filePath = @"./../../../HealthClinic/FileStorage/medicalRecords.json";
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
            List<MedicalRecord> allRecords = (List<MedicalRecord>)FindAll();
            return allRecords.Count;
        }

        public void Delete(MedicalRecord entity)
        {
            DeleteById(entity.MedicalRecordId);
        }

        public void DeleteAll()
        {
            List<MedicalRecord> emptyList = new List<MedicalRecord>();
            SaveAll(emptyList);
        }

        public void DeleteById(int identificator)
        {
            List<MedicalRecord> allRecords = (List<MedicalRecord>)FindAll();
            MedicalRecord toRemove = null;

            foreach (MedicalRecord record in allRecords)
                if (record.MedicalRecordId == identificator)
                    toRemove = record;

            if (toRemove != null)
            {
                allRecords.Remove(toRemove);
                SaveAll(allRecords);
            }

        }

        public bool ExistsById(int id)
        {
            List<MedicalRecord> allRecords = (List<MedicalRecord>)FindAll();

            foreach (MedicalRecord record in allRecords)
                if (record.MedicalRecordId == id)
                    return true;

            return false;
        }

        public IEnumerable<MedicalRecord> FindAll()
        {
            List<MedicalRecord> allRecords = JsonConvert.DeserializeObject<List<MedicalRecord>>(File.ReadAllText(filePath));

            if (allRecords == null) allRecords = new List<MedicalRecord>();

            return allRecords;
        }

        public IEnumerable<MedicalRecord> FindAllById(IEnumerable<int> ids)
        {
            List<MedicalRecord> allRecords = (List<MedicalRecord>)FindAll();
            List<MedicalRecord> matchingRecords = new List<MedicalRecord>();

            foreach (MedicalRecord record in allRecords)
                if (ids.Contains(record.MedicalRecordId))
                    matchingRecords.Add(record);

            return matchingRecords;
        }

        public MedicalRecord FindById(int id)
        {
            List<MedicalRecord> allRecords = (List<MedicalRecord>)FindAll();

            foreach (MedicalRecord record in allRecords)
                if (record.MedicalRecordId == id)
                    return record;

            return null;
        }

        public void Save(MedicalRecord entity)
        {
            if (ExistsById(entity.MedicalRecordId))
            {
                Delete(entity);
            }
            else
            {
                entity.MedicalRecordId = GenerateId();
                entity.Treatments = new ObservableCollection<Treatment>();
            }

            List<MedicalRecord> allRecords = (List<MedicalRecord>)FindAll();
            allRecords.Add(entity);
            SaveAll(allRecords);
        }

        public void SaveAll(IEnumerable<MedicalRecord> entities)
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
            List<MedicalRecord> allRecords = (List<MedicalRecord>)FindAll();
            if (allRecords.Count == 0) return 1;
            foreach (MedicalRecord record in allRecords)
            {
                if (record.MedicalRecordId > maxId) maxId = record.MedicalRecordId;
            }

            return maxId + 1;
        }
    }
}