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
            List<Medicine> allMedicines = (List<Medicine>)FindAll();

            foreach (Medicine tempMed in allMedicines)
            {
                // For now medicine is uniq by name, but need to change it
                if (tempMed.Name.Equals(entity.Name))
                {
                    allMedicines.Remove(tempMed);
                    break;
                }

            }

            // I want immediately to save changes
            SaveAll(allMedicines);
        }

        public void ValidateMedicine(Medicine medicine)
        {
            List<Medicine> allMedicines = (List<Medicine>)FindAll();

            foreach (Medicine tempMed in allMedicines)
            {
                if (tempMed.Id.Equals(medicine.Id))
                {
                    tempMed.MedicineStatus = MedicineStatus.validated;
                    break;
                }

            }
            SaveAll(allMedicines);
        }


        public int GenerateId()
        {
            int maxId = -1;
            List<Medicine> allMedicines = (List<Medicine>)FindAll();
            if (allMedicines == null || allMedicines.Count == 0) return 1;
            foreach (Medicine med in allMedicines)
            {
                if (med.Id > maxId) maxId = med.Id;
            }

            return maxId + 1;
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

            if (allMedicine == null) allMedicine = new List<Medicine>();

            return allMedicine;
        }

        public Medicine FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Medicine entity)
        {
            List<Medicine> allMedicines = (List<Medicine>)FindAll();
            entity.Id = GenerateId();
            allMedicines.Add(entity);

            // I want immediately to save changes
            SaveAll(allMedicines);

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

        public void makeUpdateFor(Medicine medicine)
        {
            List<Medicine> allMedicines = (List<Medicine>)FindAll();

            foreach (Medicine tempMed in allMedicines)
            {
                // For now medicine is uniq by name, but need to change it
                if (tempMed.Name.Equals(medicine.Name))
                {

                    tempMed.MedicineType = medicine.MedicineType;
                    tempMed.Quantity = medicine.Quantity;
                    tempMed.Price = medicine.Price;
                    tempMed.Manufacturer = medicine.Manufacturer;
                    tempMed.SideEffects = medicine.SideEffects;

                    tempMed.Alergen = new List<Alergen>();
                    tempMed.Alergen.AddRange(medicine.Alergen);

                    tempMed.ExpirationDate = medicine.ExpirationDate;

                    break;
                }
            }

            // I want immediately to save changes
            SaveAll(allMedicines);
        }

        private string filePath;

    }
}