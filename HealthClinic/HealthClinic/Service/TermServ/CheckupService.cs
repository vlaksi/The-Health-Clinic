// File:    CheckupService.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:34:11 PM
// Purpose: Definition of Class CheckupService

using Model.Calendar;
using Model.Users;
using Repository.TermRepo;
using Service.UserServ;
using System;
using System.Collections.Generic;

namespace Service.TermServ
{
    public class CheckupService
    {
        private CheckupRepositoryFactory checkupRepositoryFactory;
        private CheckupRepository checkupRepository;
        private DoctorService doctorService;
        public CheckupService()
        {
            checkupRepositoryFactory = new CheckupFileRepositoryFactory();
            checkupRepository = checkupRepositoryFactory.CreateCheckupRepository();
            doctorService = new DoctorService();
        }

        public void CancelCheckup(Checkup checkup)
        {
            checkupRepository.Delete(checkup);
        }

        public void EditCheckup(Checkup checkup)
        {
            List<Checkup> allCheckups = (List<Checkup>)checkupRepository.FindAll();
            Checkup checkupForEdit = new Checkup();
            
            foreach(Checkup c in allCheckups)
            {
                if(c.Id == checkup.Id)
                {
                    checkupForEdit = c;
                    break;
                }
            }

            CancelCheckup(checkupForEdit);
            ScheduleCheckup(checkup);


        }

        public void ScheduleCheckup(Checkup checkup)
        {   
           if(doctorService.IsDoctorFree(checkup.Doctor, checkup.StartTime))
           {
                checkupRepository.Save(checkup);
           }
        }

        public List<Checkup> getAllCheckups()
        {
            return (List<Checkup>)checkupRepository.FindAll();
        }

    }
}