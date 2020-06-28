// File:    CheckupStrategyControler.cs
// Author:  Vaxi
// Created: Wednesday, May 20, 2020 12:34:11 PM
// Purpose: Definition of Class CheckupStrategyControler

using HealthClinic.Model.Calendar;
using HealthClinic.Service.TermServ;
using Model.Calendar;
using Service.TermServ;
using System;
using System.Collections.Generic;

namespace Controller.TermContr
{
    public class CheckupStrategyControler : ITermStrategy
    {
        private CheckupService checkupService = new CheckupService();
        private TermService termService = new TermService();

        public void CancelTerm(Term term)
        {
            checkupService.CancelCheckup((Checkup)term);
        }

        public void EditTerm(Term newTerm)
        {
            checkupService.EditCheckup((Checkup)newTerm);
        }

        public void ScheduleTerm(Term newTerm)
        {
            checkupService.ScheduleCheckup((Checkup)newTerm);
        }

        public List<Checkup> GetAllCheckups(int medicineRecordId)
        {
           return checkupService.getAllCheckupsForPatient(medicineRecordId);
        }

        public DateTime SuggestCheckup(SuggestCheckupDTO suggestCheckupDTO)
        {
           return termService.SuggestCheckup(suggestCheckupDTO);
        }
    }
}