// File:    TermContextController.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 12:18:38 AM
// Purpose: Definition of Class TermContextController

using Model.Calendar;
using Service.TermServ;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Controller.TermContr
{
    public class TermContextController
    {

        private CheckupService checkupService = new CheckupService();
        private OperationService operationService = new OperationService();

        private ITermStrategy getControllerStrategy(Term term)
        {
            var testOperation = new Operation();
            var testCheckup = new Checkup();

            ITermStrategy controllerStrategy = null;

            if ((term.GetType()).IsInstanceOfType(testCheckup))
            {
                controllerStrategy = new CheckupStrategyControler();
            }
            else if ((term.GetType()).IsInstanceOfType(testOperation))
            {
                controllerStrategy = new OperationStrategyController();
            }

            return controllerStrategy;
        }

        public void CancelTerm(Term term)
        {
            getControllerStrategy(term).CancelTerm(term);
        }

        public void ScheduleTerm(Term Term)
        {
            getControllerStrategy(Term).ScheduleTerm(Term);
        }

        public void EditTerm(Term Term)
        {
            getControllerStrategy(Term).EditTerm(Term);
        }

        public List<Checkup> getAllCheckups()
        {
            return checkupService.getAllCheckups();
        }

        public List<Operation> getAllOperations()
        {
            return operationService.getAllOperations();
        }

        public Operation FindOperationById(int id)
        {
            return operationService.FindById(id);
        }

        public Checkup FindCheckupById(int id)
        {
            return checkupService.FindById(id);
        }

        public List<Checkup> getAllCheckupsForPatient(int medicalRecordId)
        {
            return checkupService.getAllCheckupsForPatient(medicalRecordId);
        }

        public List<Operation> getAllOperationsForPatient(int medicalRecordId)
        {
            return operationService.getAllOperationsForPatient(medicalRecordId);
        }
        public List<Checkup> getAllCheckupsForDoctor(int doctorId)
        {
            return checkupService.getAllCheckupsForDoctor(doctorId);
        }

        public List<Operation> getAllOperationsForDoctor(int doctorId)
        {
            return operationService.getAllOperationsForDoctor(doctorId);
        }
    }
}