// File:    MedicineFileRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 5:16:42 PM
// Purpose: Definition of Class MedicineFileRepository

using System;

namespace Repository.MedicineRepo
{
   public class MedicineFileRepository<Medicine,int> : MedicineRepository where Medicine : T
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