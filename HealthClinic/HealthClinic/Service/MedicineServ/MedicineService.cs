// File:    MedicineService.cs
// Author:  Vaxi
// Created: Sunday, May 3, 2020 8:58:30 PM
// Purpose: Definition of Class MedicineService

using Model.Medicine;
using Repository.MedicineRepo;
using System;
using System.Collections.Generic;

namespace Service.MedicineServ
{
    public class MedicineService
    {
        public MedicineRepositoryFactory medicineRepositoryFactory;

        public List<Medicine> readAllMedicine()
        {
            // TODO: Proveriti kako ovo ide preko ovog Factorija
            MedicineFileRepository repoForMedicine = new MedicineFileRepository();

            List<Medicine> retMedicine = new List<Medicine>();
            retMedicine = (List<Medicine>)repoForMedicine.FindAll();

            return retMedicine;
        }

        public void saveAllMedicine(List<Medicine> medicinesForSave)
        {
            MedicineFileRepository repoForMedicine = new MedicineFileRepository();

            repoForMedicine.SaveAll(medicinesForSave);
        }

        public List<Medicine> GetAvailableMedicines()
        {
            MedicineFileRepository repoForMedicine = new MedicineFileRepository();
            List<Medicine> allMedicines = (List<Medicine>)repoForMedicine.FindAll();
            List<Medicine> result = new List<Medicine>();

            foreach (Medicine med in allMedicines)
            {
                if (med.MedicineStatus == MedicineStatus.validated && med.Quantity > 0)
                {
                    result.Add(med);
                }
            }
            return result;
        }

        public List<Medicine> GetMedicinesAwaitingApproval()
        {
            MedicineFileRepository repoForMedicine = new MedicineFileRepository();
            List<Medicine> allMedicines = (List<Medicine>)repoForMedicine.FindAll();
            List<Medicine> result = new List<Medicine>();
            foreach (Medicine med in allMedicines)
            {
                if (med.MedicineStatus == MedicineStatus.waiting)
                {
                    result.Add(med);
                }
            }

            return result;
        }

        public void ValidateMedicine(Medicine medicine)
        {
            MedicineFileRepository repoForMedicine = new MedicineFileRepository();
            repoForMedicine.ValidateMedicine(medicine);
        }

        public Medicine GetMedicine(Medicine medicine)
        {
            throw new NotImplementedException();
        }

        public void RemoveMedicine(Medicine medicine)
        {
            // TODO: Proveriti kako ovo ide preko ovog Factorija
            MedicineFileRepository repoForEmployees = new MedicineFileRepository();
            repoForEmployees.Delete(medicine);

        }

        public void EditMedicine(Medicine medicine)
        {
            // TODO: Proveriti kako ovo ide preko ovog Factorija
            MedicineFileRepository repoForEmployees = new MedicineFileRepository();
            repoForEmployees.makeUpdateFor(medicine);

        }

        public void AddMedicine(Medicine medicine)
        {
            // TODO: Proveriti kako ovo ide preko ovog Factorija
            MedicineFileRepository repoForEmployees = new MedicineFileRepository();
            repoForEmployees.Save(medicine);

        }


    }
}