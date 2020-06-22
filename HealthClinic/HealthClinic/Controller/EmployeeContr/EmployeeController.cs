// File:    EmployeeContr.cs
// Author:  Vaxi
// Created: Sunday, May 3, 2020 11:47:00 AM
// Purpose: Definition of Class EmployeeContr

using Model.BusinessHours;
using Model.Users;
using Service.EmployeeServ;
using System.Collections.Generic;

namespace Controller.EmployeeContr
{
    public class EmployeeController
    {
        public EmployeeService employeeService = new EmployeeService();

        public void setBusinessHoursForEmployees(List<Employee> employees, BusinessHoursModel businessHours)
        {
            employeeService.setBusinessHoursForEmployees(employees, businessHours);
        }

        public List<Employee> getAllFreeEmployees(BusinessHoursModel businessHours)
        {
            return employeeService.getAllFreeEmployees(businessHours);
        }

        public void makeUpdateFor(Employee employee)
        {
            employeeService.makeUpdateFor(employee);
        }

        public void addEmployee(Employee employee)
        {
            employeeService.addEmployee(employee);
        }

        public void removeEmployee(Employee employee)
        {
            employeeService.removeEmployee(employee);
        }

        public List<Employee> readAllEmployees()
        {
            return employeeService.readAllEmployees();
        }

        public void saveAllEmployees(List<Employee> employeesForSave)
        {
            employeeService.saveAllEmployees(employeesForSave);
        }
    }
}
