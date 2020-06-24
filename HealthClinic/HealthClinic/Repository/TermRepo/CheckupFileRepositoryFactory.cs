// File:    CheckupFileRepositoryFactory.cs
// Author:  Vaxi
// Created: Friday, May 29, 2020 5:40:44 PM
// Purpose: Definition of Class CheckupFileRepositoryFactory

using System;

namespace Repository.TermRepo
{
    public class CheckupFileRepositoryFactory : CheckupRepositoryFactory
    {
        private CheckupFileRepository checkupFileRepository;

        public CheckupRepository CreateCheckupRepository()
        {
            if (checkupFileRepository == null)
                checkupFileRepository = new CheckupFileRepository();

            return checkupFileRepository;
        }
    }
}