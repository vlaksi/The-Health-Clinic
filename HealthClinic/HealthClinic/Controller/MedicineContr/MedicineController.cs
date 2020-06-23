// File:    MedicineController.cs
// Author:  Vaxi
// Created: Sunday, May 3, 2020 8:58:30 PM
// Purpose: Definition of Class MedicineController

using Model.Medicine;
using Service.MedicineServ;
using System;
using System.Collections.Generic;

namespace Controller.MedicineContr
{
    public class MedicineController
    {
        public MedicineService medicineService = new MedicineService();


        public List<Medicine> readAllMedicine()
        {
            return medicineService.readAllMedicine();
        }

        public void saveAllMedicine(List<Medicine> medicinesForSave)
        {
            medicineService.saveAllMedicine(medicinesForSave);
        }

        public Medicine ValidateMedicine(Medicine medicine)
        {
            throw new NotImplementedException();
        }

        public Medicine GetMedicine(Medicine medicine)
        {
            throw new NotImplementedException();
        }

        public void RemoveMedicine(Medicine medicine)
        {
            medicineService.RemoveMedicine(medicine);
        }

        public void EditMedicine(Medicine medicine)
        {
            medicineService.EditMedicine(medicine);
        }

        public void AddMedicine(Medicine medicine)
        {
            medicineService.AddMedicine(medicine);
        }


    }
}