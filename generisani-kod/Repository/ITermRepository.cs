// File:    ITermRepository.cs
// Author:  Pufke
// Created: Thursday, May 21, 2020 5:47:14 PM
// Purpose: Definition of Interface ITermRepository

using System;

namespace Repository
{
   public interface ITermRepository : CRUDDao<T,ID>
   {
   }
}