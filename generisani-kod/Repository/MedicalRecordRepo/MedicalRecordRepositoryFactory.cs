// File:    MedicalRecordRepositoryFactory.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 8:32:26 PM
// Purpose: Definition of Interface MedicalRecordRepositoryFactory

using System;

namespace Repository.MedicalRecordRepo
{
   public interface MedicalRecordRepositoryFactory
   {
      MedicalRecordRepository CreateMedicalRecordRepository();
   
   }
}