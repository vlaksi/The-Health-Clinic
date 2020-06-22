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
      
      /// <summary>
      /// Property for collection of Model.Users.Patient
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
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
      
      /// <summary>
      /// Add a new Model.Users.Patient in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddPatient(Model.Users.PatientModel newPatient)
      {
         if (newPatient == null)
            return;
         if (this.patient == null)
            this.patient = new System.Collections.Generic.List<PatientModel>();
         if (!this.patient.Contains(newPatient))
            this.patient.Add(newPatient);
      }
      
      /// <summary>
      /// Remove an existing Model.Users.Patient from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemovePatient(Model.Users.PatientModel oldPatient)
      {
         if (oldPatient == null)
            return;
         if (this.patient != null)
            if (this.patient.Contains(oldPatient))
               this.patient.Remove(oldPatient);
      }
      
      /// <summary>
      /// Remove all instances of Model.Users.Patient from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllPatient()
      {
         if (patient != null)
            patient.Clear();
      }
      public System.Collections.Generic.List<PatientRoom> patientRoom;
      
      /// <summary>
      /// Property for collection of Model.Rooms.PatientRoom
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
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
      
      /// <summary>
      /// Add a new Model.Rooms.PatientRoom in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddPatientRoom(Model.Rooms.PatientRoom newPatientRoom)
      {
         if (newPatientRoom == null)
            return;
         if (this.patientRoom == null)
            this.patientRoom = new System.Collections.Generic.List<PatientRoom>();
         if (!this.patientRoom.Contains(newPatientRoom))
            this.patientRoom.Add(newPatientRoom);
      }
      
      /// <summary>
      /// Remove an existing Model.Rooms.PatientRoom from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemovePatientRoom(Model.Rooms.PatientRoom oldPatientRoom)
      {
         if (oldPatientRoom == null)
            return;
         if (this.patientRoom != null)
            if (this.patientRoom.Contains(oldPatientRoom))
               this.patientRoom.Remove(oldPatientRoom);
      }
      
      /// <summary>
      /// Remove all instances of Model.Rooms.PatientRoom from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllPatientRoom()
      {
         if (patientRoom != null)
            patientRoom.Clear();
      }
   
   }
}