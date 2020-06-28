// File:    CheckupService.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:34:11 PM
// Purpose: Definition of Class CheckupService

using Model.Calendar;
using Model.MedicalRecord;
using Model.Users;
using Repository.TermRepo;
using Service.MedicalRecordServ;
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
        private MedicalRecordService medicalRecordService;
        public CheckupService()
        {
            checkupRepositoryFactory = new CheckupFileRepositoryFactory();
            checkupRepository = checkupRepositoryFactory.CreateCheckupRepository();
            doctorService = new DoctorService();
            medicalRecordService = new MedicalRecordService();
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
           if(doctorService.IsDoctorFree(checkup.DoctorId, checkup.StartTime, checkup.EndTime))
           {
                MedicalRecord medicalRecord = medicalRecordService.GetMedicalRecordById(checkup.MedicalRecordId);
        
                medicalRecord.Checkups.Add(checkup.Id);
                medicalRecordService.UpdateMedicalRecord(medicalRecord);

                checkupRepository.Save(checkup);
           }
        }

        public List<Checkup> getAllCheckups()
        {
            return (List<Checkup>)checkupRepository.FindAll();
        }

        public List<Checkup> getAllCheckupsForPatient(int medicalRecordId)
        {
            List<Checkup> allCheckups = (List<Checkup>)checkupRepository.FindAll();
            List<Checkup> result = new List<Checkup>();
            foreach (Checkup checkup in allCheckups)
            {
                if (checkup.MedicalRecordId == medicalRecordId)
                {
                    result.Add(checkup);
                }
            }
            return result;
        }

        public Checkup FindById(int id)
        {
            return checkupRepository.FindById(id);
        }

        public List<Checkup> getAllCheckupsForDoctor(int doctorId)
        {
            List<Checkup> allCheckups = (List<Checkup>)checkupRepository.FindAll();
            List<Checkup> result = new List<Checkup>();
            foreach (Checkup checkup in allCheckups)
            {
                if (checkup.DoctorId == doctorId)
                {
                    result.Add(checkup);
                }
            }
            return result;
        }
    }
}