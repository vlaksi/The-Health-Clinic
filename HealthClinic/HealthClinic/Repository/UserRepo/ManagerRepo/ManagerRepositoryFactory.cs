using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.Repository.UserRepo.ManagerRepo
{
    interface ManagerRepositoryFactory
    {
        ManagerRepository CreateManagerRepository();
    }
}
