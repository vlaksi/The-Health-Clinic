// File:    OperationService.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:28:47 PM
// Purpose: Definition of Class OperationService

using Model.Calendar;
using Repository.TermRepo;
using System;
using System.Collections.Generic;

namespace Service.TermServ
{
    public class OperationService
    {
        public ITermRepositoryFactory iTermRepositoryFactory;
        public OperationFileRepository operationFileRepository;

        public OperationService()
        {
            operationFileRepository = new OperationFileRepository();
        }

        /// Get all upcoming operations for user if ID is provided, if not, get all upcoming operations in general. Similarly to Mongoose's find.
        public List<Operation> GetAllUpcomingOperations(int userId)
        {
            List<Operation> result = new List<Operation>();

            foreach (Operation op in operationFileRepository.FindAll())
            {
                // vraca i za ljekara i za pacijenta
                if ((op.MedicalRecord.PatientId == userId || op.MedicalRecord.Doctor.Id == userId) && DateTime.Compare(op.StartTime, DateTime.Now) > 0)
                {
                    result.Add(op);
                }
            }

            return result;
        }

        /// Get all past operations for user if ID is provided, if not, get all past operations in general. Similarly to Mongoose's find.
        public List<Operation> GetAllPastOperations(int userId)
        {
            List<Operation> result = new List<Operation>();

            foreach (Operation op in operationFileRepository.FindAll())
            {
                // vraca i za ljekara i za pacijenta
                if ((op.MedicalRecord.PatientId == userId || op.MedicalRecord.Doctor.Id == userId) && DateTime.Compare(op.StartTime, DateTime.Now) < 0)
                {
                    result.Add(op);
                }
            }

            return result;
        }

        public void ScheduleOperation(Operation newOp)
        {
            operationFileRepository.Save(newOp);
        }

        public void EditOperation(Operation newOp)
        {
            operationFileRepository.Update(newOp);
        }

        public bool CancelOperation(Operation operation)
        {
            throw new NotImplementedException();
        }


    }
}