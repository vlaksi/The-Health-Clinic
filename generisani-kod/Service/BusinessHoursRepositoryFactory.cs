// File:    BusinessHoursRepositoryFactory.cs
// Author:  Filip Zukovic
// Created: Friday, May 29, 2020 6:25:18 PM
// Purpose: Definition of Interface BusinessHoursRepositoryFactory

using System;

namespace Service
{
   public interface BusinessHoursRepositoryFactory
   {
      BusinessHoursRepository CreateBusinessHoursRepository();
   
   }
}