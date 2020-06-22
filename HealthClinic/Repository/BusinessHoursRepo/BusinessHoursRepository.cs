// File:    BusinessHoursRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 7:05:45 PM
// Purpose: Definition of Interface BusinessHoursRepository

using System;
using Repository.GenericCRUD;
using Model.BusinessHours;
using Model.Users;
using System.Collections.Generic;

namespace Repository.BusinessHoursRepo
{
   public interface BusinessHoursRepository : GenericInterfaceCRUDDao<BusinessHoursModel,int>
   {
      /// Metoda koja za prosledjene doktore ponovo vraca osvezen prikaz njihovog stanja radnog kalendara u skladistu podataka.
      BusinessHoursModel GetUpdatedBusinessHours(List<Doctor> doctors);
   
   }
}