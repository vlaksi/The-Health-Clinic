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

        public bool PatientLogin(string jmbg, string password)
        {
            List<PatientModel> allPatients = GetAllPatients();

            foreach (PatientModel patient in allPatients)
            {
                if (patient.Jmbg.Equals(jmbg) && patient.Password.Equals(password))
                {
                    return true;
                }
            }
            return false;
        }
        public bool PatientRegister(PatientModel patientForRegistration)
        {
            PatientFileRepository patientFileRepo = new PatientFileRepository();

            if (!patientFileRepo.ExistsByJmbg(patientForRegistration.Jmbg))
            {
                patientForRegistration.Id = patientFileRepo.GenerateId();
                SavePatient(patientForRegistration);
                return true;
            }
            return false;
        }

        public PatientModel FindByJmbg(string jmbg)
        {
            PatientFileRepository patientFileRepo = new PatientFileRepository();
            return patientFileRepo.FindByJmbg(jmbg);
        }


        public List<PatientModel> GetAllPatients()
        {
            PatientFileRepository patientFileRepo = new PatientFileRepository();
            return patientFileRepo.GetAllPatients();
        }

        public void SavePatient(PatientModel patient)
        {
            PatientFileRepository patientFileRepo = new PatientFileRepository();
            patientFileRepo.SavePatient(patient);
        }

        public void EditPatient(PatientModel patientForEdit)
        {
            PatientFileRepository patientFileRepo = new PatientFileRepository();
            patientFileRepo.EditPatient(patientForEdit);
        }

    }
}