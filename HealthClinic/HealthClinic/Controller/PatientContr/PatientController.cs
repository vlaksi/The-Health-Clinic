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
<<<<<<< HEAD
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
            return patientService.PatientLogin(jmbg, password);
      }

      public bool PatientRegister(PatientModel patientForRegistration)
      {
           return patientService.PatientRegister(patientForRegistration);
      }

        public PatientModel FindByJmbg(string jmbg)
      {
            return patientService.FindByJmbg(jmbg); 
      }

      public List<PatientModel> GetAllPatients()
      {
         return patientService.FindAll();
      }

      public void SavePatient(PatientModel patient)
      {
         patientService.SavePatient(patient);
      }

      public void EditPatient(PatientModel patientForEdit)
      {
         patientService.EditPatient(patientForEdit);
      }
=======
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
            return patientService.PatientLogin(jmbg, password);
        }

        public PatientModel FindById(int id)
        {
            return patientService.FindById(id);
        }

        public bool PatientRegister(PatientModel patientForRegistration)
        {
            return patientService.PatientRegister(patientForRegistration);
        }

        public PatientModel FindByJmbg(string jmbg)
        {
            return patientService.FindByJmbg(jmbg);
        }

        public List<PatientModel> GetAllPatients()
        {
            return patientService.FindAll();
        }

        public void SavePatient(PatientModel patient)
        {
            patientService.SavePatient(patient);
        }

        public void EditPatient(PatientModel patientForEdit)
        {
            patientService.EditPatient(patientForEdit);
        }
>>>>>>> igor-backend


    }
}