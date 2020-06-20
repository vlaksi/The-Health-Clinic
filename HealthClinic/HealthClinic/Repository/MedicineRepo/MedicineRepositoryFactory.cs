// File:    MedicineRepositoryFactory.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 5:59:55 PM
// Purpose: Definition of Interface MedicineRepositoryFactory

using System;

namespace Repository.MedicineRepo
{
   public interface MedicineRepositoryFactory
   {
      MedicineRepository CreateMedicineRepository();
   
   }
}