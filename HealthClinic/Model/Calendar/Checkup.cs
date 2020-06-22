// File:    Checkup.cs
// Author:  Vaxi
// Created: Tuesday, April 14, 2020 2:47:47 PM
// Purpose: Definition of Class Checkup

using Model.Users;
using System;

namespace Model.Calendar
{
   public class Checkup : Term
   {
      private string checkupName;
      private string checkupStatus;
      public Model.Rooms.Ordination ordination;
      public Model.Users.Doctor doctor;

      public string CheckupName
      {
         get { return checkupName; }
         set { checkupName = value;
              OnPropertyChanged("CheckupName");
            }
      }

      public string CheckupStatus
        {
         get { return checkupStatus; }
         set { checkupStatus = value;
               OnPropertyChanged("CheckupStatus");
            }
        }

        public Doctor Doctor
        {
         get { return doctor; }
         set { doctor = value;
                OnPropertyChanged("Doctor");
            }
      }
    }
}