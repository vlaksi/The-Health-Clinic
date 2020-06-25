// File:    ManagerFileRepositoryFactory.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 5:47:50 PM
// Purpose: Definition of Class ManagerFileRepositoryFactory

using System;

namespace HealthClinic.Repository.UserRepo.ManagerRepo
{
    public class ManagerFileRepositoryFactory : ManagerRepositoryFactory
    {
        public ManagerRepository CreateManagerRepository()
        {
            return new ManagerFileRepository();
        }
    }
}