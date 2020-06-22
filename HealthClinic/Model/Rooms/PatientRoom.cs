// File:    PatientRoom.cs
// Author:  Vaxi
// Created: Wednesday, April 1, 2020 10:18:25 PM
// Purpose: Definition of Class PatientRoom

using Model.Patient;
using System;

namespace Model.Rooms
{
   /// Soba koja sluzi pacijentu nakon operacije za oporavak.
   public class PatientRoom : Room
   {
      private int capacity;
      public RoomsHistory[] roomsHistory; // TODO: Proveriti da li treba properti, i kako to resiti u PD

      public int Capacity
      {
         get
         {
            return capacity;
         }
         set
         {
            this.capacity = value;
         }
      }
      
      
   
   }
}