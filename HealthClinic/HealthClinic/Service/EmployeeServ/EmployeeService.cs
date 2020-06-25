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
            // TODO: Proveriti za Factory kako ide
            EmployeeFileRepository employeeFileRepository = new EmployeeFileRepository();
            employeeFileRepository.makeUpdateFor(employee);
        }

        public void addEmployee(Employee employee)
        {
            // TODO: Proveriti kako ovo ide preko ovog Factorija
            EmployeeFileRepository repoForEmployees = new EmployeeFileRepository();
            repoForEmployees.Save(employee);

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
            EmployeeFileRepository repoForEmployees = new EmployeeFileRepository();

            repoForEmployees.SaveAll(employeesForSave);
        }

    }
}
