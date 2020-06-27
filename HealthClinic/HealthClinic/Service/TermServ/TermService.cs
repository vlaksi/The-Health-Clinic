using HealthClinic.Model.Calendar;
using Model.Calendar;
using Model.Users;
using Service.UserServ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.Service.TermServ
{
    class TermService
    {
        DoctorService doctorService = new DoctorService();

        public DateTime SuggestCheckup(SuggestCheckupDTO suggestCheckupDTO)
        {
            //Ako je lekar nema ni jedan termin u zadatom intervalu odmah preporucujemo slobodan termin pacijentu
            if(doctorService.IsDoctorFree(suggestCheckupDTO.DoctorID, suggestCheckupDTO.StartInterval, suggestCheckupDTO.EndInterval))
            {
                return suggestCheckupDTO.StartInterval;
            }else
            {//Ako ima proveravamo da li ima bar jedan slobodan termin

            }
            return DateTime.Now;
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
