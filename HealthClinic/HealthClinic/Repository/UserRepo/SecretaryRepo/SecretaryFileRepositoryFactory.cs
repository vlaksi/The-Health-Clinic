// File:    SecretaryFileRepositoryFactory.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 5:47:48 PM
// Purpose: Definition of Class SecretaryFileRepositoryFactory

using System;

namespace HealthClinic.Repository.UserRepo.SecretaryRepo
{
    public class SecretaryFileRepositoryFactory : SecretaryRepositoryFactory
    {
        public SecretaryRepository CreateSecretaryRepository()
        {
            return new SecretaryFileRepository();
        }
    }
}