// File:    DoctorDataBaseRepositoryFactory.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 5:47:52 PM
// Purpose: Definition of Class DoctorDataBaseRepositoryFactory

using System;

namespace HealthClinic.Repository.UserRepo.DoctorRepo
{
    public class DoctorDataBaseRepositoryFactory : DoctorRepositoryFactory
    {
        public DoctorRepository CreateDoctorRepository()
        {
            return new DoctorDataBaseRepository();
        }
    }
}