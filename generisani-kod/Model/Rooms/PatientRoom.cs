// File:    PatientRoom.cs
// Author:  Vaxi
// Created: Wednesday, April 1, 2020 10:18:25 PM
// Purpose: Definition of Class PatientRoom

using System;

namespace Model.Rooms
{
   /// Soba koja sluzi pacijentu nakon operacije za oporavak.
   public class PatientRoom : Room
   {
      private int capacity;
      
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
      
      public RoomsHistory[] roomsHistory;
   
   }
}