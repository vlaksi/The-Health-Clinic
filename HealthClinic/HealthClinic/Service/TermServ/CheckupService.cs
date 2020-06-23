// File:    CheckupService.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:34:11 PM
// Purpose: Definition of Class CheckupService

using Model.Calendar;
using Model.Users;
using Repository.TermRepo;
using System;
using System.Collections.Generic;

namespace Service.TermServ
{
    public class CheckupService
    {
        private CheckupRepositoryFactory checkupRepositoryFactory;
        private CheckupRepository checkupRepository;

        public CheckupService()
        {
            checkupRepositoryFactory = new CheckupFileRepositoryFactory();
            checkupRepository = checkupRepositoryFactory.CreateCheckupRepository();
        }

        public void CancelCheckup(Checkup checkup)
        {
            checkupRepository.Delete(checkup);
        }

        public void EditCheckup(Checkup checkup)
        {
            throw new NotImplementedException();
        }

        public void ScheduleCheckup(Checkup checkup)
        {
            checkupRepository.Save(checkup);
        }

        public List<Checkup> getAllCheckups()
        {
            return (List<Checkup>)checkupRepository.FindAll();
        }

    }
}