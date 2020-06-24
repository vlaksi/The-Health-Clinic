// File:    OperationFileRepositoryFactory.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 5:39:34 PM
// Purpose: Definition of Class OperationFileRepositoryFactory

using HealthClinic.Repository.TermRepo;
using System;

namespace Repository.TermRepo
{
    public class OperationFileRepositoryFactory : OperationRepositoryFactory
    {
        private OperationFileRepository operationFileRepository;

        public OperationRepository CreateOperationRepository()
        {
            if (operationFileRepository == null)
                operationFileRepository = new OperationFileRepository();

            return operationFileRepository;
        }
    }
}