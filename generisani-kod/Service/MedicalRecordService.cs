// File:    MedicalRecordService.cs
// Author:  Igorr
// Created: Sunday, May 3, 2020 11:34:56 AM
// Purpose: Definition of Class MedicalRecordService

using System;

namespace Service
{
   public class MedicalRecordService
   {
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
      
      public Repository.MedicalRecordRepositoryFactory medicalRecordRepositoryFactory;
   
   }
}