// File:    ManagerFileRepository.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:19:33 AM
// Purpose: Definition of Class ManagerFileRepository

using System;

namespace Repository.UserRepo
{
   public class ManagerFileRepository<Manager,int> : ManagerRepository where Manager : T
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