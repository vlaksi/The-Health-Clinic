// File:    MedicineRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 7:03:17 PM
// Purpose: Definition of Interface MedicineRepository

using System;

namespace Repository
{
   public interface MedicineRepository : CRUDDao<T,ID>
   {
   }
}