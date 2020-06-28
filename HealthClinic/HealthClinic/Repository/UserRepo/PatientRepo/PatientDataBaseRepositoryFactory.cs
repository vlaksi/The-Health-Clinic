// File:    PatientDataBaseRepositoryFactory.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 5:47:49 PM
// Purpose: Definition of Class PatientDataBaseRepositoryFactory

using System;

namespace HealthClinic.Repository.UserRepo.PatientRepo
{
    public class PatientDataBaseRepositoryFactory : PatientRepositoryFactory
    {
        public PatientRepository CreatePatientRepository()
        {
            return new PatientDataBaseRepository(); 
        }
    }
}