// File:    MedicalRecordRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 7:05:49 PM
// Purpose: Definition of Interface MedicalRecordRepository

using System;

namespace Repository
{
   public interface MedicalRecordRepository : CRUDDao<T,ID>
   {
      void SaveReport(Report report);
      
      void SaveReferral(ReferralToSpecialist referral);
   
   }
}