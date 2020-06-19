// File:    CheckupService.cs
// Author:  Igorr
// Created: Wednesday, May 20, 2020 12:34:11 PM
// Purpose: Definition of Class CheckupService

using System;

namespace Service
{
   public class CheckupService
   {
      private int isChosenDoctorFree;
      
      /// Get all upcoming checkups for user if ID is provided, if not, get all upcoming checkups in general. Similarly to Mongoose's find.
      public sealed List<Checkup> GetAllUpcomingCheckups(int userId)
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
      
      public DateTime SuggestCheckup(Patient patient, List<Checkup>[] pastCheckups)
      {
        calendarService.suggestingAnCheckup(Patient patient, Chekup[] allPastCheckups);
      }
      
      public bool IsChosenDoctorFreeInChosenInterval(List<DataTime> dateInterval, Model.Users.Doctor doctor)
      {
         throw new NotImplementedException();
      }
      
      public DateTime GetFirstFreeDateFromChosenInterval(List<DataTime> interval)
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
      
      public Model.Users.Doctor GetFreeDoctor(List<Doctors> doctors)
      {
         throw new NotImplementedException();
      }
      
      public Model.Users.Doctor GetFirstFreeDoctor()
      {
         throw new NotImplementedException();
      }
      
      public ITermRepositoryFactory iTermRepositoryFactory;
   
   }
}