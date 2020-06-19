// File:    PatientFileRepository.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:19:33 AM
// Purpose: Definition of Class PatientFileRepository

using System;

namespace Repository.UserRepo
{
   public class PatientFileRepository<Patient,int> : PatientRepository where Patient : T
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
   
   }
}