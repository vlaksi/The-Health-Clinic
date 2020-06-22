// File:    CheckupFileRepository.cs
// Author:  Vaxi
// Created: Saturday, May 2, 2020 5:16:42 PM
// Purpose: Definition of Class CheckupFileRepository

using Model.Calendar;
using System;
using System.Collections.Generic;

namespace Repository.TermRepo
{
    public class CheckupFileRepository : CheckupRepository
    {
        private void OpenFile()
        {
            throw new NotImplementedException();
        }

        private void CloseFile()
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(Term entity)
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

        public bool ExistsById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Term> FindAll()
        {
            throw new NotImplementedException();
        }

        public Term FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Term entity)
        {
            throw new NotImplementedException();
        }

        public void SaveAll(IEnumerable<Term> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Term> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        private string filePath;



    }
}