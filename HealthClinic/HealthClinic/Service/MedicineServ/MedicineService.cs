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

        public Medicine ValidateMedicine(Medicine medicine)
        {
            throw new NotImplementedException();
        }

        public Medicine GetMedicine(Medicine medicine)
        {
            throw new NotImplementedException();
        }

        public bool RemoveMedicine(Medicine medicine)
        {
            throw new NotImplementedException();
        }

        public Medicine EditMedicine(Medicine medicine)
        {
            throw new NotImplementedException();
        }

        public Medicine AddMedicine(Medicine medicine)
        {
            throw new NotImplementedException();
        }


    }
}