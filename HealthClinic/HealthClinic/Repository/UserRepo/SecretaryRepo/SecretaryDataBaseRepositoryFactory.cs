// File:    SecretaryDataBaseRepositoryFactory.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 5:47:48 PM
// Purpose: Definition of Class SecretaryDataBaseRepositoryFactory

using System;

namespace HealthClinic.Repository.UserRepo.SecretaryRepo
{
    public class SecretaryDataBaseRepositoryFactory : SecretaryRepositoryFactory
    {
        public SecretaryRepository CreateSecretaryRepository()
        {
            return new SecretaryDataBaseRepository();
        }
    }
}