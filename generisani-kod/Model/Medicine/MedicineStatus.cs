// File:    MedicineStatus.cs
// Author:  Vaxi
// Created: Saturday, April 4, 2020 10:20:10 PM
// Purpose: Definition of Enum MedicineStatus

using System;

namespace Model.Medicine
{
   public enum MedicineStatus
   {
      validated,
      rejected,
      waiting,
      missing
   }
}