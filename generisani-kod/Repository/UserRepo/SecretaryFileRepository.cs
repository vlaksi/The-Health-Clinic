// File:    SecretaryFileRepository.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:19:34 AM
// Purpose: Definition of Class SecretaryFileRepository

using System;

namespace Repository.UserRepo
{
   public class SecretaryFileRepository<Secretary,int> : SecretaryRepository where Secretary : T
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