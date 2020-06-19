// File:    MedicalRecordRepositoryFactory.cs
// Author:  Filip Zukovic
// Created: Friday, May 29, 2020 8:32:26 PM
// Purpose: Definition of Interface MedicalRecordRepositoryFactory

using System;

namespace Repository
{
   public interface MedicalRecordRepositoryFactory
   {
      MedicalRecordRepository CreateMedicalRecordRepository();
   
   }
}