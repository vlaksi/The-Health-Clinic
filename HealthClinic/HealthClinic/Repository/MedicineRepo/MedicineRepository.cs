// File:    MedicineRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 7:03:17 PM
// Purpose: Definition of Interface MedicineRepository

using System;
using Repository.GenericCRUD;
using Model.Medicine;

namespace Repository.MedicineRepo
{
   public interface MedicineRepository :GenericInterfaceCRUDDao<Medicine,int>
   {
        void makeUpdateFor(Medicine medicine);
   }
}