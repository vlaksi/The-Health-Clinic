// File:    DoctorService.cs
// Author:  Vaxi
// Created: Sunday, May 3, 2020 11:47:00 AM
// Purpose: Definition of Class DoctorService

using HealthClinic.Repository.UserRepo.DoctorRepo;
using Model.Calendar;
using Model.MedicalRecord;
using Model.Medicine;
using Model.Users;
using System;
using System.Collections.Generic;

namespace Service.UserServ
{
    public class DoctorService
    {
      private DoctorRepositoryFactory doctorRepositoryFactory;
      private DoctorRepository doctorRepository;

      public DoctorService()
      {
            doctorRepositoryFactory = new DoctorFileRepositoryFactory();
            doctorRepository = doctorRepositoryFactory.CreateDoctorRepository();
      }
      public List<Doctor> GetAllDoctors()
      {
            return (List<Doctor>)doctorRepository.FindAll();
      }

      public void SaveUpdatedDoctor(Doctor doctor)
      {
         throw new NotImplementedException();
      }
      
      public List<Specialist> GetAllSpecialistsBySpecialty(String specialty)
      {
         throw new NotImplementedException();
      }
      
      public Treatment PrescribeTreatment(MedicalRecord mr, Treatment treatment)
      {
         throw new NotImplementedException();
      }
      
      public ReferralToSpecialist ReferToSpecialist(MedicalRecord mr, Specialist specialist)
      {
         throw new NotImplementedException();
      }
      
      public Report WriteReport(Report report)
      {
         throw new NotImplementedException();
      }
      public bool IsDoctorFree(int doctorId, DateTime date)
      {
            Doctor doctor = doctorRepository.FindById(doctorId);
            if (date.Date < doctor.BusinessHours.FromDate || date.Date > doctor.BusinessHours.ToDate)
            {
                if(date.Hour < doctor.BusinessHours.FromHour.Hour || date.Hour > doctor.BusinessHours.ToHour.Hour)
                {
                    return true;
                }
            }  
            return false;
      }
      
   
   }
}