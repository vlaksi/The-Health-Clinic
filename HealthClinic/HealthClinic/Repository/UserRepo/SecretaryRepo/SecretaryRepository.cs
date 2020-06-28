// File:    SecretaryRepository.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:12:56 AM
// Purpose: Definition of Interface SecretaryRepository

using Model.BusinessHours;
using Model.Users;
using Repository.GenericCRUD;
using System;
using System.Collections.Generic;

namespace HealthClinic.Repository.UserRepo.SecretaryRepo
{
   public interface SecretaryRepository : GenericInterfaceCRUDDao<Secretary, int>
   {
        void SetSecretarysBusinessHours(List<Secretary> doctors, BusinessHoursModel businessHours);

        void makeUpdateFor(Secretary entity);

        List<Secretary> getAllFreeSecretaries(BusinessHoursModel businessHours);
    }
}