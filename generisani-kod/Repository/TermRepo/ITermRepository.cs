// File:    ITermRepository.cs
// Author:  Vaxi
// Created: Thursday, May 21, 2020 5:47:14 PM
// Purpose: Definition of Interface ITermRepository

using System;

namespace Repository.TermRepo
{
   public interface ITermRepository : Repository.GenericCRUD.GenericInterfaceCRUDDao<T,ID>
   {
   }
}