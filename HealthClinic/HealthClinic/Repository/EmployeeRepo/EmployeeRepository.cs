// File:    EmployeeRepo.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 7:05:45 PM
// Purpose: Definition of Interface EmployeeRepo

using Repository.GenericCRUD;
using Model.Users;

namespace Repository.EmployeeRepo
{
    public interface EmployeeRepository : GenericInterfaceCRUDDao<Employee, int>
    {
        /// <summary>
        /// We change data of 'employee' and save that in storage.
        /// </summary>
        /// <param name="employee"> employee with new data </param>
        void makeUpdateFor(Employee employee);
    }
}
