// File:    BusinessHoursRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 7:05:45 PM
// Purpose: Definition of Interface BusinessHoursRepository

using System;

namespace Repository.BusinessHoursRepo
{
   public interface BusinessHoursRepository : Repository.GenericCRUD.GenericInterfaceCRUDDao<T,ID>
   {
      /// Metoda koja za prosledjene doktore ponovo vraca osvezen prikaz njihovog stanja radnog kalendara u skladistu podataka.
      BusinessHours GetUpdatedBusinessHours(List<Doctors> doctors);
   
   }
}