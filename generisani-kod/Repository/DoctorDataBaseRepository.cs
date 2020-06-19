// File:    DoctorDataBaseRepository.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:19:32 AM
// Purpose: Definition of Class DoctorDataBaseRepository

using System;

namespace Repository
{
   public class DoctorDataBaseRepository<Doctor,int> : DoctorRepository where Doctor : T
    where int : ID
   {
      public int Count()
      {
         throw new NotImplementedException();
      }
      
      public void Delete(Doctor entity)
      {
         throw new NotImplementedException();
      }
      
      public void DeleteAll()
      {
         throw new NotImplementedException();
      }
      
      public void DeleteById(int identificator)
      {
         throw new NotImplementedException();
      }
      
      public Boolean ExistsById(int id)
      {
         throw new NotImplementedException();
      }
      
      public Iterable<Doctor> FindAll()
      {
         throw new NotImplementedException();
      }
      
      public Doctor FindById(int id)
      {
         throw new NotImplementedException();
      }
      
      public void Save(Doctor entity)
      {
         throw new NotImplementedException();
      }
      
      public void SaveAll(Iterable<Doctor> entities)
      {
         throw new NotImplementedException();
      }
      
      public Iterable<Doctor> FindAllById(Iterable<int> ids)
      {
         throw new NotImplementedException();
      }
      
      public List<Specialist> GetAllSpecialistsBySpecialty(String specialty)
      {
         throw new NotImplementedException();
      }
   
   }
}