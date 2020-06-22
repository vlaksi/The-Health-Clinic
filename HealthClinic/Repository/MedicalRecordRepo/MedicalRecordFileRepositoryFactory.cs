// File:    MedicalRecordFileRepositoryFactory.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 8:35:15 PM
// Purpose: Definition of Class MedicalRecordFileRepositoryFactory

using System;

namespace Repository.MedicalRecordRepo
{
    public class MedicalRecordFileRepositoryFactory : MedicalRecordRepositoryFactory
    {
        public MedicalRecordRepository CreateMedicalRecordRepository()
        {
            throw new NotImplementedException();
        }
    }
}