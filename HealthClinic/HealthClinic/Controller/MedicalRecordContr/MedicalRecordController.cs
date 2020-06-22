// File:    MedicalRecordController.cs
// Author:  Vaxi
// Created: Sunday, May 3, 2020 11:34:56 AM
// Purpose: Definition of Class MedicalRecordController

using Model.MedicalRecord;
using Service.MedicalRecordServ;
using System;
using System.Collections.Generic;

namespace Controller.MedicalRecordContr
{
    public class MedicalRecordController
    {
        public MedicalRecordService medicalRecordService = new MedicalRecordService();

        public List<MedicalRecord> GetAllMedicalRecords()
        {
            return medicalRecordService.GetAllMedicalRecords();
        }

        public MedicalRecord GetMedicalRecord(int Id)
        {
            return medicalRecordService.GetMedicalRecord(Id);
        }

        public void CreateMedicalRecord(MedicalRecord mr)
        {
            medicalRecordService.CreateMedicalRecord(mr);
        }

        public void UpdateMedicalRecord(MedicalRecord mr)
        {
            medicalRecordService.UpdateMedicalRecord(mr);
        }

        public void DeleteMedicalRecord(MedicalRecord mr)
        {
            medicalRecordService.DeleteMedicalRecord(mr);
        }


    }
}