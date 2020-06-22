// File:    BusinessHoursDataBaseRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 5:16:42 PM
// Purpose: Definition of Class BusinessHoursDataBaseRepository

using Model.Users;
using System.Collections.Generic;

namespace Repository.EmployeeRepo
{
    public class EmployeeDataBaseRepository : EmployeeRepository
    {
        public int Count()
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Employee entity)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById(int identificator)
        {
            throw new System.NotImplementedException();
        }

        public bool ExistsById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Employee> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Employee> FindAllById(IEnumerable<int> ids)
        {
            throw new System.NotImplementedException();
        }

        public Employee FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void makeUpdateFor(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public void Save(Employee entity)
        {
            throw new System.NotImplementedException();
        }

        public void SaveAll(IEnumerable<Employee> entities)
        {
            throw new System.NotImplementedException();
        }
    }
}
