// File:    DoctorController.cs
// Author:  Vaxi
// Created: Sunday, May 3, 2020 11:47:00 AM
// Purpose: Definition of Class DoctorController

using Model.Calendar;
using Model.MedicalRecord;
using Model.Medicine;
using Model.Users;
using Service.UserServ;
using System;
using System.Collections.Generic;

namespace Controller.DoctorContr
{
   public class DoctorController
   {
      public DoctorService doctorService = new DoctorService();

      public List<Doctor> GetAllDoctors()
      {
         return doctorService.GetAllDoctors();
      }

      public void SaveUpdatedDoctor(Doctor doctor)
      {
         throw new NotImplementedException();
      }
      
      public Doctor GetSelectedDoctor()
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
      
      public List<Specialist> GetAllSpecialistsBySpecialty(String specialty)
      {
         throw new NotImplementedException();
      }
      
   
   }
}