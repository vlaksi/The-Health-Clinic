// File:    MedicalRecordRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 7:05:49 PM
// Purpose: Definition of Interface MedicalRecordRepository

using System;
using Repository.GenericCRUD;
using Model.Calendar;
using Model.MedicalRecord;

namespace Repository.MedicalRecordRepo
{
   public interface MedicalRecordRepository : GenericInterfaceCRUDDao<MedicalRecord,int>
   {
   
   }
}