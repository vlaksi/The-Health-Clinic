using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.ViewModels
{
    public class UcitavanjeViewModel
    {
        public Employee Zaposlen { get; set; } = new Employee()
        {
            Name = "Vlado",
            Surname = "Maksimovic",
            JobPosition = "Dr.",
            Password = "1234"
        };

    }
}
