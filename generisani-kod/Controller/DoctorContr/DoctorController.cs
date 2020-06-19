// File:    DoctorController.cs
// Author:  Vaxi
// Created: Sunday, May 3, 2020 11:47:00 AM
// Purpose: Definition of Class DoctorController

using System;

namespace Controller.DoctorContr
{
   public class DoctorController
   {
      public void SaveUpdatedDoctor(doctor doctor)
      {
         throw new NotImplementedException();
      }
      
      public doctor GetSelectedDoctor()
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
      
      public Service.UserServ.DoctorService doctorService;
   
   }
}