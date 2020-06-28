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

        public void setBusinessHoursForEmployees(List<Employee> employees, BusinessHoursModel businessHours)
        {
            // TODO: Proveriti za Factory kako ide
            EmployeeFileRepository employeeFileRepository = new EmployeeFileRepository();

            employeeFileRepository.setBusinessHoursForEmployees(employees, businessHours);
        }
        public List<Employee> getAllFreeEmployees(BusinessHoursModel businessHours)
        {
            // Odraditi prebacivanje preko servisa lekara i servisa sekretara
            return null;
        }

        public void makeUpdateFor(Employee employee)
        {
            // TODO: Proveriti kako ovo ide preko ovog Factorija
            DoctorFileRepository repoForDoctors = new DoctorFileRepository();
            SecretaryFileRepository repoForSecretary = new SecretaryFileRepository();

            if (employee.JobPosition == "Doctor")
                repoForDoctors.makeUpdateFor(getDoctorFromEmployee(employee));


            if (employee.JobPosition == "Secretary")
                repoForSecretary.makeUpdateFor(getSecretaryFromEmployee(employee));
        }

        public void addEmployee(Employee employee)
        {
            // TODO: Proveriti kako ovo ide preko ovog Factorija
            DoctorFileRepository repoForDoctors = new DoctorFileRepository();
            SecretaryFileRepository repoForSecretary = new SecretaryFileRepository();

            if (employee.JobPosition == "Doctor")
                repoForDoctors.Save(getDoctorFromEmployee(employee));


            if (employee.JobPosition == "Secretary")
                repoForSecretary.Save(getSecretaryFromEmployee(employee));


        }

        private Doctor getDoctorFromEmployee(Employee employee)
        {
            Doctor retDoc = new Doctor();

            retDoc.EmployeeType = EmployeeType.Doctor;
            retDoc.AbleToPrescribeTreatments = true;
            retDoc.AbleToValidateMedicines = false;
            retDoc.Adress = ( employee.Adress is null ) ? "" : employee.Adress;
            retDoc.Biography = (employee.Biography is null) ? "" : employee.Biography;
            retDoc.Birthday = (employee.Birthday == DateTime.MinValue) ? (new DateTime(2020,12,30)) : employee.Birthday;
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

        public void removeEmployee(Employee employee)
        {
            // TODO: Proveriti kako ovo ide preko ovog Factorija
            EmployeeFileRepository repoForEmployees = new EmployeeFileRepository();
            repoForEmployees.Delete(employee);
        }

        public List<Employee> readAllEmployees()
        {
            DoctorFileRepository doctorRepo = new DoctorFileRepository();
            SecretaryFileRepository secretaryRepo = new SecretaryFileRepository();
            List<Doctor> doctors = (List<Doctor>)doctorRepo.FindAll();
            List<Secretary> secretary = (List<Secretary>)secretaryRepo.FindAll();

            List<Employee> employees = new List<Employee>();
            employees.AddRange(doctors.Cast<Employee>().ToList());
            employees.AddRange(secretary.Cast<Employee>().ToList());

            return employees;
        }

        public void saveAllEmployees(List<Employee> employeesForSave)
        {

            DoctorFileRepository repoForDoctors = new DoctorFileRepository();
            SecretaryFileRepository repoForSecretary = new SecretaryFileRepository();

            List<Doctor> doctorsForSave = new List<Doctor>();
            List<Secretary> secretaryForSave = new List<Secretary>();

            foreach (Employee employee in employeesForSave)
            {
                if (employee.EmployeeType == EmployeeType.Doctor)
                    doctorsForSave.Add((Doctor)employee);
                else if (employee.EmployeeType == EmployeeType.Secretary)
                    secretaryForSave.Add((Secretary)employee);
            }

            repoForDoctors.SaveAll(doctorsForSave);
            repoForSecretary.SaveAll(secretaryForSave);

        }

    }
}
