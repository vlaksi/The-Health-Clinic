// File:    OperationService.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:28:47 PM
// Purpose: Definition of Class OperationService

using HealthClinic.Repository.TermRepo;
using Model.Calendar;
using Repository.TermRepo;
using System;
using System.Collections.Generic;

namespace Service.TermServ
{
    public class OperationService
    {
        private OperationRepositoryFactory operationRepositoryFactory;
        private OperationRepository operationRepository;

        public OperationService()
        {
            operationRepositoryFactory = new OperationFileRepositoryFactory();
            operationRepository = operationRepositoryFactory.CreateOperationRepository();
        }

        public void ScheduleOperation(Operation operation)
        {
            operationRepository.Save(operation);
        }

        public void EditOperation(Operation operation)
        {
            throw new NotImplementedException();
        }
        
        public void CancelOperation(Operation operation)
        {
            operationRepository.Delete(operation);
        }

        public List<Operation> getAllOperations()
        {
            return (List<Operation>) operationRepository.FindAll();
        }
    }
}