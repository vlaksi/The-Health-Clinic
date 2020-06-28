// File:    PatientFileRepositoryFactory.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 5:47:50 PM
// Purpose: Definition of Class PatientFileRepositoryFactory

using System;

namespace HealthClinic.Repository.UserRepo.PatientRepo
{
    public class PatientFileRepositoryFactory : PatientRepositoryFactory
    {
        public PatientRepository CreatePatientRepository()
        {
            return new PatientFileRepository();
        }
    }
}