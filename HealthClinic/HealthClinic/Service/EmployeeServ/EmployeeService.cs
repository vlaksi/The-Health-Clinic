// File:    EmployeeService.cs
// Author:  Vaxi
// Created: Sunday, May 3, 2020 8:58:30 PM
// Purpose: Definition of Class EmployeeService

using HealthClinic.Repository.UserRepo.DoctorRepo;
using HealthClinic.Repository.UserRepo.SecretaryRepo;
using Model.BusinessHours;
using Model.Users;
using Repository.EmployeeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service.EmployeeServ
{
    public class EmployeeService
    {
        public EmployeeRepositoryFactory employeeRepositoryFactory;
        private DoctorRepositoryFactory doctorRepositoryFactory;
        private SecretaryRepositoryFactory secretaryRepositoryFactory;

        private DoctorRepository doctorRepository;
        private SecretaryRepository secretaryRepository;

        public EmployeeService()
        {
            doctorRepositoryFactory = new DoctorFileRepositoryFactory();
            doctorRepository = doctorRepositoryFactory.CreateDoctorRepository();

            secretaryRepositoryFactory = new SecretaryFileRepositoryFactory();
            secretaryRepository = secretaryRepositoryFactory.CreateSecretaryRepository();
        }

        public void setBusinessHoursForEmployees(List<Employee> employees, BusinessHoursModel businessHours)
        {
            List<Secretary> secretaries;
            List<Doctor> doctors;
            parseEmployeesToDctorsAndSecretaries(employees, out secretaries, out doctors);

            doctorRepository.SetDoctorsBusinessHours(doctors, businessHours);
            secretaryRepository.SetSecretarysBusinessHours(secretaries, businessHours);
        }


        public List<Employee> getAllFreeEmployees(BusinessHoursModel businessHours)
        {
            List<Employee> freeEmployees = new List<Employee>();

            freeEmployees.AddRange(doctorRepository.getAllFreeDoctors(businessHours));
            freeEmployees.AddRange(secretaryRepository.getAllFreeSecretaries(businessHours));

            return freeEmployees;
        }

        public void makeUpdateFor(Employee employee)
        {

            if (employee.JobPosition == "Doctor")
                doctorRepository.makeUpdateFor(getDoctorFromEmployee(employee));


            if (employee.JobPosition == "Secretary")
                secretaryRepository.makeUpdateFor(getSecretaryFromEmployee(employee));
        }

        public void addEmployee(Employee employee)
        {
            if (employee.JobPosition == "Doctor")
                doctorRepository.Save(getDoctorFromEmployee(employee));


            if (employee.JobPosition == "Secretary")
                secretaryRepository.Save(getSecretaryFromEmployee(employee));

        }



        public void removeEmployee(Employee employee)
        {

            if (employee.JobPosition == "Doctor")
                doctorRepository.DeleteById(getDoctorFromEmployee(employee).Id);


            if (employee.JobPosition == "Secretary")
                secretaryRepository.DeleteById(getSecretaryFromEmployee(employee).Id);
        }

        public List<Employee> readAllEmployees()
        {
            List<Doctor> doctors = (List<Doctor>)doctorRepository.FindAll();
            List<Secretary> secretary = (List<Secretary>)secretaryRepository.FindAll();

            List<Employee> employees = new List<Employee>();
            employees.AddRange(doctors.Cast<Employee>().ToList());
            employees.AddRange(secretary.Cast<Employee>().ToList());

            return employees;
        }

        public void saveAllEmployees(List<Employee> employeesForSave)
        {

            List<Doctor> doctorsForSave = new List<Doctor>();
            List<Secretary> secretaryForSave = new List<Secretary>();

            foreach (Employee employee in employeesForSave)
            {
                if (employee.EmployeeType == EmployeeType.Doctor)
                    doctorsForSave.Add((Doctor)employee);
                else if (employee.EmployeeType == EmployeeType.Secretary)
                    secretaryForSave.Add((Secretary)employee);
            }

            doctorRepository.SaveAll(doctorsForSave);
            secretaryRepository.SaveAll(secretaryForSave);

        }


        #region Helper methods

        private void parseEmployeesToDctorsAndSecretaries(List<Employee> employees, out List<Secretary> secretaries, out List<Doctor> doctors)
        {
            secretaries = new List<Secretary>();
            doctors = new List<Doctor>();
            foreach (Employee employee in employees)
            {
                if (employee.JobPosition == "Doctor")
                    doctors.Add(getDoctorFromEmployee(employee));


                if (employee.JobPosition == "Secretary")
                    secretaries.Add(getSecretaryFromEmployee(employee));
            }
        }

        private Doctor getDoctorFromEmployee(Employee employee)
        {
            Doctor retDoc = new Doctor();

            retDoc.EmployeeType = EmployeeType.Doctor;
            retDoc.AbleToPrescribeTreatments = true;
            retDoc.AbleToValidateMedicines = false;
            retDoc.Adress = (employee.Adress is null) ? "" : employee.Adress;
            retDoc.Biography = (employee.Biography is null) ? "" : employee.Biography;
            retDoc.Birthday = (employee.Birthday == DateTime.MinValue) ? (new DateTime(2020, 12, 30)) : employee.Birthday;
            retDoc.BusinessHours = (employee.BusinessHours is null) ? (new BusinessHoursModel()) : employee.BusinessHours;
            retDoc.Email = (employee.Email is null) ? "" : employee.Email;
            retDoc.Gender = (employee.Gender is null) ? "" : employee.Gender;
            retDoc.Jmbg = (employee.Jmbg is null) ? "" : employee.Jmbg;
            retDoc.JobPosition = (employee.JobPosition is null) ? "" : employee.JobPosition;
            retDoc.Name = (employee.Name is null) ? "" : employee.Name;
            retDoc.ParentsName = (employee.ParentsName is null) ? "" : employee.ParentsName;
            retDoc.Password = (employee.Password is null) ? "" : employee.Password;
            retDoc.PhoneNumber = (employee.PhoneNumber is null) ? "" : employee.PhoneNumber;
            retDoc.Username = (employee.Username is null) ? "" : employee.Username;
            retDoc.Surname = (employee.Surname is null) ? "" : employee.Surname;
            retDoc.Id = (employee.Id <= 0) ? 9999 : employee.Id;
            return retDoc;
        }

        private Secretary getSecretaryFromEmployee(Employee employee)
        {
            Secretary retSecretary = new Secretary();


            retSecretary.EmployeeType = EmployeeType.Secretary;
            retSecretary.Adress = (employee.Adress is null) ? "" : employee.Adress;
            retSecretary.Biography = (employee.Biography is null) ? "" : employee.Biography;
            retSecretary.Birthday = (employee.Birthday == DateTime.MinValue) ? (new DateTime(2020, 12, 30)) : employee.Birthday;
            retSecretary.BusinessHours = (employee.BusinessHours is null) ? (new BusinessHoursModel()) : employee.BusinessHours;
            retSecretary.Email = (employee.Email is null) ? "" : employee.Email;
            retSecretary.Gender = (employee.Gender is null) ? "" : employee.Gender;
            retSecretary.Jmbg = (employee.Jmbg is null) ? "" : employee.Jmbg;
            retSecretary.JobPosition = (employee.JobPosition is null) ? "" : employee.JobPosition;
            retSecretary.Name = (employee.Name is null) ? "" : employee.Name;
            retSecretary.ParentsName = (employee.ParentsName is null) ? "" : employee.ParentsName;
            retSecretary.Password = (employee.Password is null) ? "" : employee.Password;
            retSecretary.PhoneNumber = (employee.PhoneNumber is null) ? "" : employee.PhoneNumber;
            retSecretary.Username = (employee.Username is null) ? "" : employee.Username;
            retSecretary.Surname = (employee.Surname is null) ? "" : employee.Surname;
            retSecretary.Id = (employee.Id <= 0) ? 9999 : employee.Id;

            return retSecretary;
        }

        #endregion
    }
}
