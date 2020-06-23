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
using System.CodeDom;
using System.Collections.ObjectModel;
using Model.Medicine;


namespace Repository.MedicalRecordRepo
{
    public class MedicalRecordFileRepository : MedicalRecordRepository
    {
        // Igor - ne radi mi ovako :/
        private string filePath = @"./../../../HealthClinic/FileStorage/medicalRecords.json";
        //private string filePath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())))) + @"\HealthClinic\FileStorage\medicalRecords.json";

        private void OpenFile()
        {
            throw new NotImplementedException();
        }

        private void CloseFile()
        {
            throw new NotImplementedException();
        }

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
            DeleteById(entity.Id);
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
                if (record.Id == identificator)
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
                if (record.Id == id)
                    return true;

            return false;
        }

        public IEnumerable<MedicalRecord> FindAll()
        {
            List<MedicalRecord> allRecords = JsonConvert.DeserializeObject<List<MedicalRecord>>(File.ReadAllText(filePath));

            if (allRecords == null) allRecords = new List<MedicalRecord>();

            return allRecords;
        }

        public MedicalRecord FindById(int id)
        {
            List<MedicalRecord> allRecords = (List<MedicalRecord>)FindAll();

            foreach (MedicalRecord record in allRecords)
                if (record.Id == id)
                    return record;

            return null;
        }

        public void Save(MedicalRecord entity)
        {
            if (ExistsById(entity.Id))
            {
                Delete(entity);
            }
            else
            {
                entity.Id = GenerateId();
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

        public IEnumerable<MedicalRecord> FindAllById(IEnumerable<int> ids)
        {
            List<MedicalRecord> allRecords = (List<MedicalRecord>)FindAll();
            List<MedicalRecord> matchingRecords = new List<MedicalRecord>();

            foreach (MedicalRecord record in allRecords)
                if (ids.Contains(record.Id))
                    matchingRecords.Add(record);

            return matchingRecords;
        }

        public int GenerateId()
        {
            int maxId = -1;
            List<MedicalRecord> allRecords = (List<MedicalRecord>)FindAll();
            if (allRecords.Count == 0) return 1;
            foreach (MedicalRecord record in allRecords)
            {
                if (record.Id > maxId) maxId = record.Id;
            }

            return maxId + 1;
        }
    }
}