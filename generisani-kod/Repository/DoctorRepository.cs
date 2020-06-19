// File:    DoctorRepository.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:12:52 AM
// Purpose: Definition of Interface DoctorRepository

using System;

namespace Repository
{
   public interface DoctorRepository : IUserRepository
   {
      List<Specialist> GetAllSpecialistsBySpecialty(String specialty);
      
      List<Doctor> FindMatchedDoctors(BussinesHours bussinesHours);
      
      void SetDoctorsBusinessHours(List<Doctor> doctors, BusinessHours businessHours);
   
   }
}