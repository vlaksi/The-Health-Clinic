// File:    DoctorService.cs
// Author:  Vaxi
// Created: Sunday, May 3, 2020 11:47:00 AM
// Purpose: Definition of Class DoctorService

using Model.Calendar;
using Model.MedicalRecord;
using Model.Medicine;
using Model.Users;
using Repository.UserRepo;
using System;
using System.Collections.Generic;

namespace Service.UserServ
{
   public class DoctorService
   {
      public IUserRepositoryFacotory iUserRepositoryFacotory;

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
      
   
   }
}