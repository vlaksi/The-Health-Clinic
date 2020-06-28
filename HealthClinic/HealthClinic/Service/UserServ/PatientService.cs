// File:    PatientService.cs
// Author:  Vaxi
// Created: Friday, April 17, 2020 12:11:31 AM
// Purpose: Definition of Class PatientService

using HealthClinic.Repository.UserRepo.PatientRepo;
using Model.MedicalRecord;
using Model.Survey;
using Model.Users;
using Service.MedicalRecordServ;
using Service.SurveyResponseServ;
using System;
using System.Collections.Generic;

namespace Service.UserServ
{
    public class PatientService
    {
        private PatientRepositoryFactory patientRepositoryFactory;
        private PatientRepository patientRepository;
        private MedicalRecordService medicalRecordService;
        private SurveyResponseService surveyResponseService;

        public PatientService()
        {
            surveyResponseService = new SurveyResponseService();
            patientRepositoryFactory = new PatientFileRepositoryFactory();
            patientRepository = patientRepositoryFactory.CreatePatientRepository();
            medicalRecordService = new MedicalRecordService();
        }

        public int RateClinic()
        {
            throw new NotImplementedException();
        }

        public void FillFeedbackForm(SurveyResponse surveyResponse)
        {
            surveyResponseService.AddSurveyResponse(surveyResponse);
        }

        public PatientModel FindById(int id)
        {
            return patientRepository.FindById(id);
        }

        public bool PatientLogin(string jmbg, string password)
        {
            List<PatientModel> allPatients = FindAll();

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
            MedicalRecord medicalRecord = new MedicalRecord();        
            
            medicalRecord.PatientId = GenerateId();
            medicalRecordService.CreateMedicalRecord(medicalRecord);
            patientForRegistration.MedicalRecordId = medicalRecord.MedicalRecordId;

            if (!patientRepository.ExistsByJmbg(patientForRegistration.Jmbg))
            {
                SavePatient(patientForRegistration);
                return true;
            }
            return false;
        }

        
        public PatientModel FindByJmbg(string jmbg)
        {
            List<PatientModel> allPatientModels = (List<PatientModel>)FindAll();

            foreach (PatientModel patient in allPatientModels)
            {
                if (patient.Jmbg.Equals(jmbg))
                {
                    return patient;
                }
            }

            return null;
        }

        public List<PatientModel> FindAll()
        {
            return (List <PatientModel>)patientRepository.FindAll();
        
        }

        public void SavePatient(PatientModel patient)
        {
            patientRepository.Save(patient);
        }

        public void EditPatient(PatientModel patientForEdit)
        {
            List<PatientModel> allPatients = (List<PatientModel>)FindAll();
            PatientModel patientForRemove = null;

            foreach (PatientModel patient in allPatients)
            {
                if (patient.Id == patientForEdit.Id)
                {
                    patientForRemove = patient;
                    allPatients.Add(patientForEdit);
                    break;
                }
            }

            allPatients.Remove(patientForRemove);
            patientRepository.SaveAll(allPatients);
        }

        public int GenerateId()
        {
            PatientFileRepository patientFileRepository = new PatientFileRepository();
            return patientFileRepository.GenerateId();
        }

        public void deletePatientUserAccount(PatientModel patient)
        {
            patient.Password = null;
            patient.Username = null;
            SavePatient(patient);
        }

        public void deletePatient(PatientModel patient)
        {
            medicalRecordService.DeleteMedicalRecord(patient.MedicalRecordId);
            patientRepository.Delete(patient);
        }

    }
}