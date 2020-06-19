// File:    Checkup.cs
// Author:  Vaxi
// Created: Tuesday, April 14, 2020 2:47:47 PM
// Purpose: Definition of Class Checkup

using System;

namespace Model.Calendar
{
   public class Checkup : Term
   {
      public Model.Rooms.Ordination ordination;
      public Model.Users.Doctor doctor;
   
   }
}