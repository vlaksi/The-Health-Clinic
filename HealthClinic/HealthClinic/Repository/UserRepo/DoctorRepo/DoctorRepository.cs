// File:    DoctorRepository.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:12:52 AM
// Purpose: Definition of Interface DoctorRepository

using Model.Users;
using System;
using System.Collections.Generic;
using Model.BusinessHours;
using Repository.GenericCRUD;

namespace HealthClinic.Repository.UserRepo.DoctorRepo
{
    public interface DoctorRepository : GenericInterfaceCRUDDao<Doctor, int>
    {
        List<Doctor> GetAllSpecialistsBySpecialty(SpecialtyType specialtyType);

        List<Doctor> FindMatchedDoctors(BusinessHoursModel bussinesHours);

        void SetDoctorsBusinessHours(List<Doctor> doctors, BusinessHoursModel businessHours);

        List<Doctor> getAllFreeDoctors(BusinessHoursModel businessHours);

        void makeUpdateFor(Doctor entity);
    }
}