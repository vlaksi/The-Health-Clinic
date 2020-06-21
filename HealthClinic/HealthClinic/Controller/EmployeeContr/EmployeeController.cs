// File:    EmployeeContr.cs
// Author:  Vaxi
// Created: Sunday, May 3, 2020 11:47:00 AM
// Purpose: Definition of Class EmployeeContr

using Model.Users;
using Service.EmployeeServ;
using System.Collections.Generic;

namespace Controller.EmployeeContr
{
    public class EmployeeController
    {
        public EmployeeService employeeService = new EmployeeService();

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
