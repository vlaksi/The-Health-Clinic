// File:    DoctorFileRepositoryFactory.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 5:47:52 PM
// Purpose: Definition of Class DoctorFileRepositoryFactory

using System;

namespace HealthClinic.Repository.UserRepo.DoctorRepo
{
    public class DoctorFileRepositoryFactory : DoctorRepositoryFactory
    {
        private DoctorFileRepository doctorFileRepository;

        public DoctorRepository CreateDoctorRepository()
        {
            if (doctorFileRepository == null)
                doctorFileRepository = new DoctorFileRepository();

            return doctorFileRepository;
        }
    }
}