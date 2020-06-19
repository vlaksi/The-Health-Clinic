// File:    BusinessHoursRepositoryFactory.cs
// Author:  Pufke
// Created: Friday, May 29, 2020 6:25:18 PM
// Purpose: Definition of Interface BusinessHoursRepositoryFactory

using System;

namespace Repository
{
   public interface BusinessHoursRepositoryFactory
   {
      BusinessHoursRepository CreateBusinessHoursRepository();
   
   }
}