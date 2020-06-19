// File:    MedicalRecordFileRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 5:16:42 PM
// Purpose: Definition of Class MedicalRecordFileRepository

using System;

namespace Repository.MedicalRecordRepo
{
   public class MedicalRecordFileRepository<MedicalRecord,int> : MedicalRecordRepository where MedicalRecord : T
    where int : ID
   {
      private void OpenFile()
      {
         throw new NotImplementedException();
      }
      
      private void CloseFile()
      {
         throw new NotImplementedException();
      }
      
      private string filePath;
      
      public void SaveReport(Report report)
      {
         throw new NotImplementedException();
      }
      
      public void SaveReferral(ReferralToSpecialist referral)
      {
         throw new NotImplementedException();
      }
   
   }
}