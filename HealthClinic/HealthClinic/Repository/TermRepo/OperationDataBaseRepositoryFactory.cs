// File:    OperationDataBaseRepositoryFactory.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 5:39:34 PM
// Purpose: Definition of Class OperationDataBaseRepositoryFactory

using HealthClinic.Repository.TermRepo;
using System;

namespace Repository.TermRepo
{
    public class OperationDataBaseRepositoryFactory : OperationRepositoryFactory
    {
        public OperationRepository CreateOperationRepository()
        {
            throw new NotImplementedException();
        }
    }
}