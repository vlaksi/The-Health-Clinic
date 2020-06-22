// File:    OperationFileRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 5:16:42 PM
// Purpose: Definition of Class OperationFileRepository

using Model.Calendar;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repository.TermRepo
{
    
    public class OperationFileRepository : OperationRepository
    {
        private string filePath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())))) + @"\HealthClinic\FileStorage\operations.json";

        private string OpenFile()
        {
            throw new NotImplementedException();
        }

        private string CloseFile()
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            List<Term> allOps = (List<Term>)FindAll();
            return allOps.Count;
        }

        public void Delete(Term entity)
        {
            List<Operation> allOperations = (List<Operation>)FindAll();
            foreach(Operation op in allOperations)
            {
                if(op.Id == entity.Id)
                {
                    allOperations.Remove((Operation)entity);
                    break;
                }
            }

            SaveAll(allOperations);
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

        public IEnumerable<Term> FindAll()
        {
            List<Operation> allOps = new List<Operation>();
            allOps = JsonConvert.DeserializeObject<List<Operation>>(File.ReadAllText(filePath));
            return allOps;
        }

        public Term FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Operation op)
        {
            List<Operation> allOperations = (List<Operation>)FindAll();

            // TODO: Resiti ovo, ne radi zbog ugradjenog kalendara
            //foreach (Operation tempOp in allOperations)
            //{
            //    if (tempOp.Id.Equals(op.Id))
            //    {
            //        tempOp.EndTime = op.EndTime;
            //        tempOp.Location = op.Location;
            //        tempOp.MedicalRecord = op.MedicalRecord;
            //        tempOp.OperatingRoom = op.OperatingRoom;
            //        tempOp.Specialist = op.Specialist;
            //        tempOp.SpecialtyType = op.SpecialtyType;
            //        break;
            //    }
            //}
            SaveAll(allOperations);
        }

        // TODO: Proveriti, ali zbog polimorfizma, ovde se moglu klase naslednice od term-a proslediti i da sve radi bez problema
        public void Save(Term entity)
        {
            List<Operation> allOps = (List<Operation>)FindAll();
            allOps.Add((Operation)entity);
            SaveAll(allOps);
        }

        public void SaveAll(IEnumerable<Term> entities)
        {
            using (StreamWriter file = File.CreateText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, (IEnumerable<Operation>)entities);
            }
        }

        public IEnumerable<Term> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        

    }
}