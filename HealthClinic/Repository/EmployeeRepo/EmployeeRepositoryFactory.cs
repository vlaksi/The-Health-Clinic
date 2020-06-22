// File:    EmployeeRepositoryFactory.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 6:25:18 PM
// Purpose: Definition of Interface EmployeeRepositoryFactory

namespace Repository.EmployeeRepo
{
    public interface EmployeeRepositoryFactory
    {
        EmployeeRepository CreateEmployeeRepository();
    }
}
