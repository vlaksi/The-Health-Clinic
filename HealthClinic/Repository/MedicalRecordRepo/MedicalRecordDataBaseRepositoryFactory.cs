// File:    MedicalRecordDataBaseRepositoryFactory.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 8:35:52 PM
// Purpose: Definition of Class MedicalRecordDataBaseRepositoryFactory

using System;

namespace Repository.MedicalRecordRepo
{
    public class MedicalRecordDataBaseRepositoryFactory : MedicalRecordRepositoryFactory
    {
        public MedicalRecordRepository CreateMedicalRecordRepository()
        {
            throw new NotImplementedException();
        }
    }
}