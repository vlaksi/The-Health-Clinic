// File:    MedicalRecordController.cs
// Author:  Vaxi
// Created: Sunday, May 3, 2020 11:34:56 AM
// Purpose: Definition of Class MedicalRecordController

using System;

namespace Controller.MedicalRecordContr
{
   public class MedicalRecordController
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
      
      public Service.MedicalRecordServ.MedicalRecordService medicalRecordService;
   
   }
}