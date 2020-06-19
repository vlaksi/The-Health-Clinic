// File:    OperationDataBaseRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 5:16:42 PM
// Purpose: Definition of Class OperationDataBaseRepository

using System;

namespace Repository.TermRepo
{
   public class OperationDataBaseRepository<Operation,int> : OperationRepository where Operation : T
    where int : ID
   {
   }
}