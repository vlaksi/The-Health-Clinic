// File:    PatientController.cs
// Author:  Vaxi
// Created: Friday, April 17, 2020 12:11:31 AM
// Purpose: Definition of Class PatientController

using Model.Survey;
using Model.Users;
using Service.UserServ;
using System;
using System.Collections.Generic;

namespace Controller.PatientContr
{
   public class PatientController
   {
      public PatientService patientService = new PatientService();

      public int RateClinic()
      {
         throw new NotImplementedException();
      }
      
      public SurveyResponse FillFeedbackForm()
      {
         throw new NotImplementedException();
      }

      public bool PatientLogin(string jmbg, string password)
      {
            List<PatientModel> allPatients = GetAllPatients();

            foreach(PatientModel patient in allPatients)
            {
                if(patient.Jmbg.Equals(jmbg) && patient.Password.Equals(password))
                {
                    return true;
                }
            }
            return false;
      }

      public List<PatientModel> GetAllPatients()
      {
         return patientService.GetAllPatients();
      }



   }
}