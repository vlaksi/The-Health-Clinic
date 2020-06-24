using Model.Calendar;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.Service.TermServ
{
    class TermService
    {
        public DateTime SuggestCheckup(PatientModel patient, List<Checkup>[] pastCheckups)
        {
            throw new NotImplementedException();
        }

        public bool IsChosenDoctorFreeInChosenInterval(List<DateTime> dateInterval, Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public DateTime GetFirstFreeDateFromChosenInterval(List<DateTime> interval)
        {
            throw new NotImplementedException();
        }

        public bool IsChosenDoctorFree()
        {
            throw new NotImplementedException();
        }

        public DateTime GetFirstFreeDate(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public bool IsAnyDoctorFreeForChosenDate(List<DateTime> interval)
        {
            throw new NotImplementedException();
        }

        public int NumberOfFreeDoctors()
        {
            throw new NotImplementedException();
        }

        public Doctor GetFreeDoctor(List<Doctor> doctors)
        {
            throw new NotImplementedException();
        }

        public Doctor GetFirstFreeDoctor()
        {
            throw new NotImplementedException();
        }

    }
}
