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

        public void Delete(Employee entity)
        {
            throw new NotImplementedException();
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

        public IEnumerable<Employee> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public Employee FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Employee entity)
        {
            throw new NotImplementedException();
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
