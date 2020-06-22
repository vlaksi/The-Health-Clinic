// File:    MedicalRecordService.cs
// Author:  Vaxi
// Created: Sunday, May 3, 2020 11:34:56 AM
// Purpose: Definition of Class MedicalRecordService

using Model.MedicalRecord;
using Repository.MedicalRecordRepo;
using System;
using System.Collections.Generic;

namespace Service.MedicalRecordServ
{
    public class MedicalRecordService
    {
        public MedicalRecordRepositoryFactory medicalRecordRepositoryFactory;
        public MedicalRecordRepository medicalRecordRepository;

        public MedicalRecordService()
        {
            medicalRecordRepositoryFactory = new MedicalRecordFileRepositoryFactory();
            medicalRecordRepository = medicalRecordRepositoryFactory.CreateMedicalRecordRepository();
        }

        public MedicalRecord GetMedicalRecord(int Id)
        {
            return medicalRecordRepository.FindById(Id);
        }

        public List<MedicalRecord> GetAllMedicalRecords()
        {
            return (List<MedicalRecord>) medicalRecordRepository.FindAll();
        }

        public void CreateMedicalRecord(MedicalRecord mr)
        {
            medicalRecordRepository.Save(mr);
        }

        public void UpdateMedicalRecord(MedicalRecord mr)
        {
            medicalRecordRepository.Save(mr);
        }

        public void DeleteMedicalRecord(MedicalRecord mr)
        {
            medicalRecordRepository.Delete(mr);
        }


    }
}