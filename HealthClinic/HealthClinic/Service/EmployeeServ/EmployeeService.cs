// File:    EmployeeService.cs
// Author:  Vaxi
// Created: Sunday, May 3, 2020 8:58:30 PM
// Purpose: Definition of Class EmployeeService

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
            // TODO: Proveriti za Factory kako ide
            EmployeeFileRepository employeeFileRepository = new EmployeeFileRepository();

            return employeeFileRepository.getAllFreeEmployees(businessHours);
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
            // TODO: Proveriti kako ovo ide preko ovog Factorija
            EmployeeFileRepository repoForEmployees = new EmployeeFileRepository();

            List<Employee> retEmployees = new List<Employee>();
            retEmployees = (List<Employee>)repoForEmployees.FindAll();

            return retEmployees;
        }

        public void saveAllEmployees(List<Employee> employeesForSave)
        {
            EmployeeFileRepository repoForEmployees = new EmployeeFileRepository();

            repoForEmployees.SaveAll(employeesForSave);
        }

    }
}
