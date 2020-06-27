// File:    DoctorService.cs
// Author:  Vaxi
// Created: Sunday, May 3, 2020 11:47:00 AM
// Purpose: Definition of Class DoctorService

using HealthClinic.Repository.UserRepo.DoctorRepo;
using Model.Calendar;
using Model.MedicalRecord;
using Model.Medicine;
using Model.Users;
using Service.TermServ;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Service.UserServ
{
    public class DoctorService
    {
        private DoctorRepositoryFactory doctorRepositoryFactory;
        private DoctorRepository doctorRepository;
        private CheckupService checkupService;
        private OperationService operationService;
        public DoctorService()
        {
            doctorRepositoryFactory = new DoctorFileRepositoryFactory();
            doctorRepository = doctorRepositoryFactory.CreateDoctorRepository();

        }
        public List<Doctor> GetAllDoctors()
        {
            return (List<Doctor>)doctorRepository.FindAll();
        }
        public bool isEmailTaken(string email)
        {
            List<Doctor> allDoctors = GetAllDoctors();
            foreach(Doctor doctor in allDoctors)
            {
                if (doctor.Email.Equals(email))
                {
                    return true;
                }
            }
            return false;
        }
        public void AddDoctor(Doctor doctor)
        {
            doctorRepository.Save(doctor);
        }

        public Doctor FindById(int id)
        {
            return doctorRepository.FindById(id);
        }

        public void SaveUpdatedDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public Doctor DoctorLogin(string email, string password)
        {
            List<Doctor> allDoctors = (List<Doctor>)doctorRepository.FindAll();

            foreach (Doctor doctor in allDoctors)
            {
                if (doctor.Email.Equals(email) && doctor.Password.Equals(password))
                {
                    return doctor;
                }
            }
            return null;
        }

        public List<Doctor> GetAllSpecialistsBySpecialty(SpecialtyType specialtyType)
        {
            return doctorRepository.GetAllSpecialistsBySpecialty(specialtyType);
        }

        //treba provjeriti i da li doktor ima zakazane termine u tom periodu
        public bool IsDoctorFree(int doctorId, DateTime dateStart, DateTime dateEnd)
        {
            checkupService = new CheckupService();
            operationService = new OperationService();

            Doctor doctor = doctorRepository.FindById(doctorId);
            //Da li se taj termin nalazi unutar radnog vremena
            if (dateStart.Date > doctor.BusinessHours.FromDate && dateEnd.Date < doctor.BusinessHours.ToDate
                && dateStart.Hour > doctor.BusinessHours.FromHour.Hour && dateEnd.Hour < doctor.BusinessHours.ToHour.Hour)
            {
                //Da li doktor nema termina u tom periodu
                List<Checkup> checkups = checkupService.getAllCheckupsForDoctor(doctorId);
                foreach(Checkup checkup in checkups)
                {
                    if (checkup.StartTime == dateStart) return false;
                    if (checkup.EndTime == dateEnd) return false;
                    //this = checkup
                    //test = start,end
                    if (checkup.StartTime < dateStart)
                    {
                        if (checkup.EndTime > dateStart && checkup.EndTime < dateEnd)
                            return false; // Condition 1

                        if (checkup.EndTime > dateEnd)
                            return false; // Condition 3
                    }
                    else
                    {
                        if (dateEnd > checkup.StartTime && dateEnd < checkup.EndTime)
                            return false; // Condition 2

                        if (dateEnd > checkup.EndTime)
                            return false; // Condition 4
                    }
                }

                List<Operation> operations = operationService.getAllOperationsForDoctor(doctorId);
                foreach (Operation operation in operations)
                {
                    if (operation.StartTime == dateStart) return false;
                    if (operation.EndTime == dateEnd) return false;
                    //this = checkup
                    //test = start,end
                    if (operation.StartTime < dateStart)
                    {
                        if (operation.EndTime > dateStart && operation.EndTime < dateEnd)
                            return false; // Condition 1

                        if (operation.EndTime > dateEnd)
                            return false; // Condition 3
                    }
                    else
                    {
                        if (dateEnd > operation.StartTime && dateEnd < operation.EndTime)
                            return false; // Condition 2

                        if (dateEnd > operation.EndTime)
                            return false; // Condition 4
                    }
                }

                // Ako je sve ovo zadovoljeno, slobodan je
                return true;
            }
            return false;
        }

    }
}