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

    // Helper funkcija za .ToString() enumeracije, koristi se u formatu MedicineStatusExtensions.ToFriendlyString(medStatus)
    public static class MedicineStatusExtensions
    {
        public static string ToFriendlyString(this MedicineStatus me)
        {
            switch (me)
            {
                case MedicineStatus.validated:
                    return "Validated";
                case MedicineStatus.rejected:
                    return "Rejected";
                case MedicineStatus.waiting:
                    return "Waiting";
                case MedicineStatus.missing:
                    return "Missing";
                default:
                    return "MedicineStatus default";
            }
        }
    }
}