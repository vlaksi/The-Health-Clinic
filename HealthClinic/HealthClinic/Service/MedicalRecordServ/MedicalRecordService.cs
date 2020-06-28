// File:    MedicalRecordService.cs
// Author:  Vaxi
// Created: Sunday, May 3, 2020 11:34:56 AM
// Purpose: Definition of Class MedicalRecordService

using HealthClinic.Repository.UserRepo.PatientRepo;
using Model.Calendar;
using Model.MedicalRecord;
using Model.Users;
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

        public List<MedicalRecord> GetMedicalRecordByPatientName(string Name)
        {
            List<MedicalRecord> allRecords = GetAllMedicalRecords();
            List<MedicalRecord> result = new List<MedicalRecord>();

            PatientFileRepository patientFileRepository = new PatientFileRepository();
            PatientModel patient;

            foreach (MedicalRecord mr in allRecords)
            {
                if (mr.PatientId != 0)
                {
                    patient = patientFileRepository.FindById(mr.PatientId);
                    if (patient.Name.ToLower().Contains(Name.ToLower()) || patient.Surname.ToLower().Contains(Name.ToLower()))
                    {
                        result.Add(mr);
                    }
                }
            }
            return result;
        }

        public MedicalRecord GetMedicalRecordByPatientId(int Id)
        {
            MedicalRecord result = null;
            foreach (MedicalRecord mr in medicalRecordRepository.FindAll())
            {
                if (mr.PatientId == Id)
                {
                    result = mr;
                    break;
                }
            }

            return result;
        }

        public MedicalRecord GetMedicalRecordById(int Id)
        {
            MedicalRecord result = null;
            foreach (MedicalRecord mr in medicalRecordRepository.FindAll())
            {
                if (mr.MedicalRecordId == Id)
                {
                    result = mr;
                    break;
                }
            }

            return result;
        }

        public void SaveReport(MedicalRecord mr, Report report)
        {
            mr.Reports.Add(report);
            medicalRecordRepository.Save(mr);
        }

        public List<MedicalRecord> GetAllMedicalRecords()
        {
            return (List<MedicalRecord>)medicalRecordRepository.FindAll();
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

        public void DeleteMedicalRecord(int id)
        {
            medicalRecordRepository.DeleteById(id);
        }
    }
}