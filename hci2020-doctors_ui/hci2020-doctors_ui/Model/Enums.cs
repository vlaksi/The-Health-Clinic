using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hci2020_doctors_ui.Model
{
   public enum SpecialtyType
    {
        General,
        Cardiac,
        Dermatological,
        Otolaryngological,
        Oncological,
        Neurological
    };

    public enum MedicineStatus
    {
        Waiting,
        Validated,
        Rejected,
        Missing
    };

    public enum BlogType
    {
        Lifestyle,
        COVID19,
        Science,
        Dentist
    };

}
