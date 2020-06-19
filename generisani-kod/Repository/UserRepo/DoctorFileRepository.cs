// File:    DoctorFileRepository.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:19:32 AM
// Purpose: Definition of Class DoctorFileRepository

using System;

namespace Repository.UserRepo
{
   public class DoctorFileRepository<Doctor,int> : DoctorRepository where Doctor : T
    where int : ID
   {
      private void OpenFile()
      {
         throw new NotImplementedException();
      }
      
      private void CloseFile()
      {
         throw new NotImplementedException();
      }
      
      private string filePath;
      
      public List<Specialist> GetAllSpecialistsBySpecialty(String specialty)
      {
         throw new NotImplementedException();
      }
   
   }
}