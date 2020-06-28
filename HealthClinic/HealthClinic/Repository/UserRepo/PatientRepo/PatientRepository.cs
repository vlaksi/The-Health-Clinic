// File:    PatientRepository.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:12:54 AM
// Purpose: Definition of Interface PatientRepository

using Model.Users;
using Repository.GenericCRUD;
using System;

namespace HealthClinic.Repository.UserRepo.PatientRepo
{
   public interface PatientRepository : GenericInterfaceCRUDDao<PatientModel, int>
   {
        bool ExistsByJmbg(string jmbg);

   }
}