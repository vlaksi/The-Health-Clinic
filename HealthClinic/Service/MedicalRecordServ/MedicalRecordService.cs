// File:    MedicalRecordService.cs
// Author:  Vaxi
// Created: Sunday, May 3, 2020 11:34:56 AM
// Purpose: Definition of Class MedicalRecordService

using Model.MedicalRecord;
using Repository.MedicalRecordRepo;
using System;

namespace Service.MedicalRecordServ
{
   public class MedicalRecordService
   {
      public MedicalRecordRepositoryFactory medicalRecordRepositoryFactory;

      public MedicalRecord GetMedicalRecord(String patientId)
      {
         throw new NotImplementedException();
      }
      
      public MedicalRecord CreateMedicalRecord(MedicalRecord mr)
      {
         throw new NotImplementedException();
      }
      
      public MedicalRecord UpdateMedicalRecord(MedicalRecord mr)
      {
         throw new NotImplementedException();
      }
      
      public bool DeleteMedicalRecord(MedicalRecord mr)
      {
         throw new NotImplementedException();
      }
      
   
   }
}