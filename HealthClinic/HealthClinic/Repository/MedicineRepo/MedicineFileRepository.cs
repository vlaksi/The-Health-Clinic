// File:    MedicineFileRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 5:16:42 PM
// Purpose: Definition of Class MedicineFileRepository

using Model.Medicine;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repository.MedicineRepo
{
    public class MedicineFileRepository : MedicineRepository
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

        public void Delete(Medicine entity)
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

        public IEnumerable<Medicine> FindAll()
        {
            List<Medicine> allMedicine = new List<Medicine>();

            string currentPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()))));
            currentPath += @"\HealthClinic\FileStorage\medicine.json";

            // read file into a string and deserialize JSON to a type
            allMedicine = JsonConvert.DeserializeObject<List<Medicine>>(File.ReadAllText(currentPath));

            return allMedicine;
        }

        public Medicine FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Medicine entity)
        {
            string currentPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()))));
            currentPath += @"\HealthClinic\FileStorage\medicine.json";

            // serialize JSON directly to a file
            using (StreamWriter file = File.CreateText(currentPath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, entity);
            }

        }

        public void SaveAll(IEnumerable<Medicine> entities)
        {

            string currentPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()))));
            currentPath += @"\HealthClinic\FileStorage\medicine.json";

            // serialize JSON directly to a file
            using (StreamWriter file = File.CreateText(currentPath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, entities);
            }
        }

        public IEnumerable<Medicine> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        private string filePath;

    }
}