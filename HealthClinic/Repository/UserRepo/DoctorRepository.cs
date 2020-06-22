// File:    DoctorRepository.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:12:52 AM
// Purpose: Definition of Interface DoctorRepository

using Model.Users;
using System;
using System.Collections.Generic;
using Model.BusinessHours;

namespace Repository.UserRepo
{
   public interface DoctorRepository : IUserRepository
   {
      List<Specialist> GetAllSpecialistsBySpecialty(String specialty);
      
      List<Doctor> FindMatchedDoctors(BusinessHoursModel bussinesHours);
      
      void SetDoctorsBusinessHours(List<Doctor> doctors, BusinessHoursModel businessHours);
   
   }
}