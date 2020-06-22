// File:    CheckupService.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:34:11 PM
// Purpose: Definition of Class CheckupService

using Model.Calendar;
using Model.Users;
using Repository.TermRepo;
using System;
using System.Collections.Generic;

namespace Service.TermServ
{
    public class CheckupService
    {
        public ITermRepositoryFactory iTermRepositoryFactory;

        private int isChosenDoctorFree;

        public List<Checkup> readAllCheckups()
        {
            // TODO: Proveriti kako ovo ide preko ovog Factorija
            CheckupFileRepository repoCheckup = new CheckupFileRepository();

            List<Checkup> retCheckup = new List<Checkup>();
            retCheckup = (List<Checkup>)repoCheckup.FindAll();

            return retCheckup;
        }

        public void saveAllCheckups(List<Checkup> chekupsForSave)
        {
            CheckupFileRepository repoCheckup = new CheckupFileRepository();

            repoCheckup.SaveAll(chekupsForSave);
        }
        /// Get all upcoming checkups for user if ID is provided, if not, get all upcoming checkups in general. Similarly to Mongoose's find.
        public List<Checkup> GetAllUpcomingCheckups(int userId)
        {
            throw new NotImplementedException();
        }

        /// Get all past checkups for user if ID is provided, if not, get all past checkups in general. Similarly to Mongoose's find.
        public List<Checkup> GetAllPastCheckups(int userId)
        {
            throw new NotImplementedException();
        }

        public Checkup ScheduleCheckup(Checkup newCheckup)
        {
            throw new NotImplementedException();
        }

        public Checkup EditCheckup(Checkup newCheckup)
        {
            throw new NotImplementedException();
        }

        public bool CancelCheckup(Checkup checkup)
        {
            throw new NotImplementedException();
        }


        // TODO: Resiti ovo, stvarno ne znam sta se desava ovde
        //public DateTime SuggestCheckup(PatientModel patient, List<Checkup>[] pastCheckups)
        //{
        //    calendarService.suggestingAnCheckup(PatientModel patient, Checkup[] allPastCheckups);
        //}

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

        public DateTime GetFirstFreeDate(Model.Users.Doctor doctor)
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