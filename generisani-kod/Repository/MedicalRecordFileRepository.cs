// File:    MedicalRecordFileRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 5:16:42 PM
// Purpose: Definition of Class MedicalRecordFileRepository

using System;

namespace Repository
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
      
      public Iterable<MedicalRecord> FindAllById(Iterable<int> ids)
      {
         throw new NotImplementedException();
      }
      
      public int Count()
      {
         throw new NotImplementedException();
      }
      
      public void DeleteAll()
      {
         throw new NotImplementedException();
      }
      
      public void DeleteById(int identificator)
      {
         throw new NotImplementedException();
      }
      
      public Boolean ExistsById(int id)
      {
         throw new NotImplementedException();
      }
      
      public Iterable<MedicalRecord> FindAll()
      {
         throw new NotImplementedException();
      }
      
      public MedicalRecord FindById(int id)
      {
         throw new NotImplementedException();
      }
      
      public void Save(MedicalRecord entity)
      {
         throw new NotImplementedException();
      }
      
      public void SaveAll(Iterable<MedicalRecord> entities)
      {
         throw new NotImplementedException();
      }
      
      public void SaveReport(Report report)
      {
         throw new NotImplementedException();
      }
      
      public void SaveReferral(ReferralToSpecialist referral)
      {
         throw new NotImplementedException();
      }
      
      public void Delete(MedicalRecord entity)
      {
         throw new NotImplementedException();
      }
   
   }
}