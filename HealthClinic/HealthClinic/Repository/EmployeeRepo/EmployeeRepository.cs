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

    }
}
