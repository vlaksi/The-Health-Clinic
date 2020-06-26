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

        public List<Doctor> GetAllSpecialistsBySpecialty(SpecialtyType specialtyType)
        {
            return doctorRepository.GetAllSpecialistsBySpecialty(specialtyType);
        }

        //treba provjeriti i da li doktor ima zakazane termine u tom periodu
        public bool IsDoctorFree(int doctorId, DateTime dateStart, DateTime dateEnd)
        {
            Doctor doctor = doctorRepository.FindById(doctorId);
            if (dateStart.Date > doctor.BusinessHours.FromDate || dateEnd.Date < doctor.BusinessHours.ToDate)
            {
                if (dateStart.Hour > doctor.BusinessHours.FromHour.Hour || dateEnd.Hour < doctor.BusinessHours.ToHour.Hour)
                {
                    return true;
                }
            }
            return false;
        }


    }
}