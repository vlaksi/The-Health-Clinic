// File:    ManagerDataBaseRepositoryFactory.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 5:47:51 PM
// Purpose: Definition of Class ManagerDataBaseRepositoryFactory

using System;

namespace HealthClinic.Repository.UserRepo.ManagerRepo
{
    public class ManagerDataBaseRepositoryFactory : ManagerRepositoryFactory
    {
        public ManagerRepository CreateManagerRepository()
        {
            return new ManagerDataBaseRepository();
        }
    }
}