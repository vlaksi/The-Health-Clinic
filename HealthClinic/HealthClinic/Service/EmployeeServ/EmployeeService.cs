// File:    EmployeeService.cs
// Author:  Vaxi
// Created: Sunday, May 3, 2020 8:58:30 PM
// Purpose: Definition of Class EmployeeService

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
