// File:    RoomsHistory.cs
// Author:  Vaxi
// Created: Wednesday, April 29, 2020 4:30:47 PM
// Purpose: Definition of Class RoomsHistory

using Model.Rooms;
using Model.Users;
using System;

namespace Model.Patient
{
   public class RoomsHistory
   {
      private DateTime fromDate;
      private DateTime toDate;
      
      public DateTime FromDate
      {
         get
         {
            return fromDate;
         }
         set
         {
            this.fromDate = value;
         }
      }
      
      public DateTime ToDate
      {
         get
         {
            return toDate;
         }
         set
         {
            this.toDate = value;
         }
      }
      
      public System.Collections.Generic.List<PatientModel> patient;
      
      public System.Collections.Generic.List<PatientModel> Patient
      {
         get
         {
            if (patient == null)
               patient = new System.Collections.Generic.List<PatientModel>();
            return patient;
         }
         set
         {
            RemoveAllPatient();
            if (value != null)
            {
               foreach (Model.Users.PatientModel oPatient in value)
                  AddPatient(oPatient);
            }
         }
      }

      public void AddPatient(Model.Users.PatientModel newPatient)
      {
         if (newPatient == null)
            return;
         if (this.patient == null)
            this.patient = new System.Collections.Generic.List<PatientModel>();
         if (!this.patient.Contains(newPatient))
            this.patient.Add(newPatient);
      }

      public void RemovePatient(Model.Users.PatientModel oldPatient)
      {
         if (oldPatient == null)
            return;
         if (this.patient != null)
            if (this.patient.Contains(oldPatient))
               this.patient.Remove(oldPatient);
      }
      
      public void RemoveAllPatient()
      {
         if (patient != null)
            patient.Clear();
      }
      public System.Collections.Generic.List<PatientRoom> patientRoom;
      
      public System.Collections.Generic.List<PatientRoom> PatientRoom
      {
         get
         {
            if (patientRoom == null)
               patientRoom = new System.Collections.Generic.List<PatientRoom>();
            return patientRoom;
         }
         set
         {
            RemoveAllPatientRoom();
            if (value != null)
            {
               foreach (Model.Rooms.PatientRoom oPatientRoom in value)
                  AddPatientRoom(oPatientRoom);
            }
         }
      }
      

      public void AddPatientRoom(Model.Rooms.PatientRoom newPatientRoom)
      {
         if (newPatientRoom == null)
            return;
         if (this.patientRoom == null)
            this.patientRoom = new System.Collections.Generic.List<PatientRoom>();
         if (!this.patientRoom.Contains(newPatientRoom))
            this.patientRoom.Add(newPatientRoom);
      }

      public void RemovePatientRoom(Model.Rooms.PatientRoom oldPatientRoom)
      {
         if (oldPatientRoom == null)
            return;
         if (this.patientRoom != null)
            if (this.patientRoom.Contains(oldPatientRoom))
               this.patientRoom.Remove(oldPatientRoom);
      }
      
      public void RemoveAllPatientRoom()
      {
         if (patientRoom != null)
            patientRoom.Clear();
      }
   
   }
}