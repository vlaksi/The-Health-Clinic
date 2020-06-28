using Model.BusinessHours;
using Model.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EmployeeRepo
{
    class EmployeeFileRepository : EmployeeRepository
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public void setBusinessHoursForEmployees(List<Employee> employeesForSettingBH, BusinessHoursModel businessHours)
        {

            List<Employee> allEmployees = (List<Employee>)FindAll();

            

            foreach (Employee tempEmployeeForChange in employeesForSettingBH)
            {
                foreach (Employee employee in allEmployees)
                {
                    if (tempEmployeeForChange.Username.Equals(employee.Username))
                    {
                        employee.BusinessHours = new BusinessHoursModel();
                        employee.BusinessHours.FromDate = businessHours.FromDate;
                        employee.BusinessHours.ToDate = businessHours.ToDate;
                        employee.BusinessHours.FromHour = businessHours.FromHour;
                        employee.BusinessHours.ToHour = businessHours.ToHour;
                        break;
                    }
                }
            }

            // I want immediately to save changes
            SaveAll(allEmployees);
        }

        public void Delete(Employee entity)
        {
            List<Employee> allEmployees = (List<Employee>)FindAll();

            foreach (Employee tempEmployee in allEmployees)
            {   // I delte Employee with corresponding username because it's unique identificator of Employee
                if (tempEmployee.Username.Equals(entity.Username))
                {
                    allEmployees.Remove(tempEmployee);
                    break;
                }
            }

            // I want immediately to save changes
            SaveAll(allEmployees);

        }

        public List<Employee> getAllFreeEmployees(BusinessHoursModel businessHours)
        {
            List<Employee> allEmployees = (List<Employee>)FindAll();
            List<Employee> freeEmployees = new List<Employee>();

            foreach (Employee tempEmployee in allEmployees)
            {

                /*
                 * If businessHours is range 20.04 - 25.04
                 * and my ToDate is 19.04, a im free at businessHours range
                 */
                if(tempEmployee.BusinessHours.ToDate < businessHours.FromDate)
                {
                    freeEmployees.Add(tempEmployee);
                }

            }

            return freeEmployees;
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int identificator)
        {
            throw new NotImplementedException();
        }

        public bool ExistsById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> FindAll()
        {
            List<Employee> allEmployees = new List<Employee>();

            string currentPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()))));
            currentPath += @"\HealthClinic\FileStorage\employees.json";

            // read file into a string and deserialize JSON to a type
            allEmployees = JsonConvert.DeserializeObject<List<Employee>>(File.ReadAllText(currentPath));

            return allEmployees;
        }

        public IEnumerable<Doctor> FindAllDoctors()
        {
            //List<Employee> allEmployees = new List<Employee>();

            string currentPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()))));
            currentPath += @"\HealthClinic\FileStorage\employees.json";

            // read file into a string and deserialize JSON to a type
            List<Doctor> allEmployees = JsonConvert.DeserializeObject<List<Doctor>>(File.ReadAllText(currentPath));

            return allEmployees;
        }

        public IEnumerable<Employee> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public Employee FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void makeUpdateFor(Employee employee)
        {
            List<Employee> allEmployees = (List<Employee>)FindAll();

            foreach (Employee tempEmployee in allEmployees)
            {
                // Important: Username is uniq so i compare by username !
                if (tempEmployee.Username.Equals(employee.Username))
                {
                    tempEmployee.Name = employee.Name;
                    tempEmployee.Surname = employee.Surname;
                    tempEmployee.PhoneNumber = employee.Name;
                    tempEmployee.JobPosition = employee.JobPosition;
                    tempEmployee.Biography = employee.Biography;
                    tempEmployee.Adress = employee.Adress;
                    tempEmployee.Birthday = employee.Birthday;
                    if(!(employee.BusinessHours is null))
                    {
                        tempEmployee.BusinessHours.FromDate = employee.BusinessHours.FromDate;
                        tempEmployee.BusinessHours.ToDate = employee.BusinessHours.ToDate;
                    }
                    
                    tempEmployee.Password = employee.Password;
                    break;

                }
            }

            // I want immediately to save changes
            SaveAll(allEmployees);

        }

        public void Save(Employee entity)
        {
            List<Employee> allEmployees = (List<Employee>)FindAll();
            allEmployees.Add(entity);

            // I want immediately to save changes
            SaveAll(allEmployees);
        }

        public void SaveAll(IEnumerable<Employee> entities)
        {
            string currentPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()))));
            currentPath += @"\HealthClinic\FileStorage\employees.json";

            // serialize JSON directly to a file
            using (StreamWriter file = File.CreateText(currentPath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, entities);
            }
        }
    }
}
