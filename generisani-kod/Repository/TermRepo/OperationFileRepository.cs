// File:    OperationFileRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 5:16:42 PM
// Purpose: Definition of Class OperationFileRepository

using System;

namespace Repository.TermRepo
{
   public class OperationFileRepository<Operation,int> : OperationRepository where Operation : T
    where int : ID
   {
      private string OpenFile()
      {
         throw new NotImplementedException();
      }
      
      private string CloseFile()
      {
         throw new NotImplementedException();
      }
      
      private string filePath;
   
   }
}