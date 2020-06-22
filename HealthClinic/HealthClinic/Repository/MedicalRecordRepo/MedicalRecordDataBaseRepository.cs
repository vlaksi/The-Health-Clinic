// File:    MedicalRecordDataBaseRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 5:16:42 PM
// Purpose: Definition of Class MedicalRecordDataBaseRepository

using System;
using System.Collections.Generic;
using Model.Calendar;
using Model.MedicalRecord;

namespace Repository.MedicalRecordRepo
{
    public class MedicalRecordDataBaseRepository : MedicalRecordRepository
    {

        public void SaveReport(Report report)
        {
            throw new NotImplementedException();
        }

        public void SaveReferral(ReferralToSpecialist referral)
        {
            throw new NotImplementedException();
        }

        public void Delete(MedicalRecord entity)
        {
            throw new NotImplementedException();
        }

        public int Count()
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

        public IEnumerable<MedicalRecord> FindAll()
        {
            throw new NotImplementedException();
        }

        public MedicalRecord FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(MedicalRecord entity)
        {
            throw new NotImplementedException();
        }

        public void SaveAll(IEnumerable<MedicalRecord> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MedicalRecord> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(string identificator)
        {
            throw new NotImplementedException();
        }

        public bool ExistsById(string id)
        {
            throw new NotImplementedException();
        }

        public MedicalRecord FindById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MedicalRecord> FindAllById(IEnumerable<string> ids)
        {
            throw new NotImplementedException();
        }
    }
}