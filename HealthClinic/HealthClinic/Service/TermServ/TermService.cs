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

        public SuggestCheckupDTO SuggestCheckup(SuggestCheckupDTO suggestCheckupDTO)
        {
            
            if (suggestCheckupDTO.PriorityDoctor)
            {   
                suggestCheckupDTO.StartInterval = GetFirstFreeTermChosenDoctor(suggestCheckupDTO);
                return suggestCheckupDTO;
               
            } else if (suggestCheckupDTO.PriorityDate)
            {
                //Prvo proveravamo da li je izabrani doktor slobodan u nekom od termina
                if (GetFirstFreeTermChosenDoctor(suggestCheckupDTO) != DateTime.MinValue)//Ako jeste predlazemo njega
                {
                    return suggestCheckupDTO;
                }
                else//Ako nije trazimo prvog slobodnog lekara u tom vremenskom intervalu i njega predlazemo
                {
                    return GetFirstFreeDoctorForChosenInterval(suggestCheckupDTO);
                } 
            }
            return suggestCheckupDTO;
        }


        public SuggestCheckupDTO GetFirstFreeDoctorForChosenInterval(SuggestCheckupDTO suggestCheckupDTO)
        {
            List<Doctor> listOfAllDoctors = doctorService.GetAllDoctors();
            foreach (Doctor doctor in listOfAllDoctors)
            {
                suggestCheckupDTO.DoctorID = doctor.Id;
                while (suggestCheckupDTO.StartInterval < suggestCheckupDTO.EndInterval)
                {
                    suggestCheckupDTO.StartInterval = suggestCheckupDTO.StartInterval.AddHours(1);
                   
                    if (doctorService.IsDoctorFree(suggestCheckupDTO.DoctorID, suggestCheckupDTO.StartInterval, suggestCheckupDTO.StartInterval.AddHours(1)))
                    {
                        return suggestCheckupDTO;
                    }
                }
            }
            suggestCheckupDTO.DoctorID = -1;

            return suggestCheckupDTO;
        }

        public DateTime GetFirstFreeTermChosenDoctor(SuggestCheckupDTO suggestCheckupDTO)
        {
  
            while (suggestCheckupDTO.StartInterval < suggestCheckupDTO.EndInterval)
            {
                suggestCheckupDTO.StartInterval = suggestCheckupDTO.StartInterval.AddHours(1);

                if (doctorService.IsDoctorFree(suggestCheckupDTO.DoctorID, suggestCheckupDTO.StartInterval, suggestCheckupDTO.StartInterval.AddHours(1)))
                {
                    return suggestCheckupDTO.StartInterval;                 
                }
            }
            //Ako je prioritet doktor, i taj doktor nije slobodan u izabranom temrinu, tada trazimo prvi slobodan termin izvan izabranog intervala
            while(suggestCheckupDTO.StartInterval < DateTime.MaxValue)
            {
                suggestCheckupDTO.StartInterval = suggestCheckupDTO.StartInterval.AddHours(1);

                if (doctorService.IsDoctorFree(suggestCheckupDTO.DoctorID, suggestCheckupDTO.StartInterval, suggestCheckupDTO.StartInterval.AddHours(1)))
                {
                    return suggestCheckupDTO.StartInterval;
                }
            }
            return DateTime.MinValue;
        }


    }
}
