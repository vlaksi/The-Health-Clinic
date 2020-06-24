// File:    OperationFileRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 5:16:42 PM
// Purpose: Definition of Class OperationFileRepository

using Model.Calendar;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Repository.TermRepo
{

    public class OperationFileRepository : OperationRepository
    {
        private string filePath = @"./../../../HealthClinic/FileStorage/operation.json";

        public int Count()
        {
            List<Operation> allOperations = (List<Operation>)FindAll();
            return allOperations.Count;
        }

        public void Delete(Operation entity)
        {
            DeleteById(entity.Id);
        }

        public void DeleteAll()
        {
            List<Operation> emptyList = new List<Operation>();
            SaveAll(emptyList);
        }

        public void DeleteById(int identificator)
        {
            List<Operation> allOperations = (List<Operation>)FindAll();
            Operation toRemove = null;

            foreach (Operation operation in allOperations)
                if (operation.Id == identificator)
                    toRemove = operation;

            if (toRemove != null)
            {
                allOperations.Remove(toRemove);
                SaveAll(allOperations);
            }
        }

        public bool ExistsById(int id)
        {
            List<Operation> allOperations = (List<Operation>)FindAll();

            foreach (Operation operation in allOperations)
                if (operation.Id == id)
                    return true;

            return false;
        }

        public IEnumerable<Operation> FindAll()
        {
            List<Operation> allOperations = JsonConvert.DeserializeObject<List<Operation>>(File.ReadAllText(filePath));

            if (allOperations == null) allOperations = new List<Operation>();

            return allOperations;
        }

        public IEnumerable<Operation> FindAllById(IEnumerable<int> ids)
        {
            List<Operation> allOperations = (List<Operation>)FindAll();
            List<Operation> matchingOperations = new List<Operation>();

            foreach (Operation operation in allOperations)
                if (ids.Contains(operation.Id))
                    matchingOperations.Add(operation);

            return matchingOperations;
        }

        public Operation FindById(int id)
        {
            List<Operation> allOperations = (List<Operation>)FindAll();

            foreach (Operation operation in allOperations)
                if (operation.Id == id)
                    return operation;

            return null;
        }

        public void Save(Operation entity)
        {
            if (ExistsById(entity.Id))
                Delete(entity);
            else
                entity.Id = GenerateId();

            List<Operation> allOperations = (List<Operation>)FindAll();
            allOperations.Add(entity);
            SaveAll(allOperations);
        }

        public void SaveAll(IEnumerable<Operation> entities)
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
            List<Operation> allOperations = (List<Operation>)FindAll();
            if (allOperations.Count == 0) return 1;
            foreach (Operation operation in allOperations)
            {
                if (operation.Id > maxId) maxId = operation.Id;
            }

            return maxId + 1;
        }
    }
}