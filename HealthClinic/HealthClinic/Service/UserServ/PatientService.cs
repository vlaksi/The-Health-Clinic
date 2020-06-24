// File:    PatientService.cs
// Author:  Vaxi
// Created: Friday, April 17, 2020 12:11:31 AM
// Purpose: Definition of Class PatientService

using Model.Survey;
using Model.Users;
using Repository.UserRepo;
using System;
using System.Collections.Generic;

namespace Service.UserServ
{
   public class PatientService
   {
      public IUserRepositoryFacotory iUserRepositoryFacotory;

      public int RateClinic()
      {
         throw new NotImplementedException();
      }
      
      public SurveyResponse FillFeedbackForm()
      {
         throw new NotImplementedException();
      }

      public List<PatientModel> GetAllPatients()
      {
          PatientFileRepository patientFileRepo = new PatientFileRepository();
          return patientFileRepo.GetAllPatients();    
      }
   }
}