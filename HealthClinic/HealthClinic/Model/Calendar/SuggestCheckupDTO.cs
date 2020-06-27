using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.Model.Calendar
{
    public class SuggestCheckupDTO
    {
        private int doctorID;
        private DateTime startInterval;
        private DateTime endInterval;
        private bool priorityDoctor;
        private bool priorityDate;

        #region Properties
        public int DoctorID { 
            get { return doctorID; }
            set { doctorID = value; }
        }
        public DateTime StartInterval
        {
            get { return startInterval; }
            set { startInterval = value; }
        }
        public DateTime EndInterval
        {
            get { return endInterval; }
            set { endInterval = value; }
        }
        public bool PriorityDoctor
        {
            get { return priorityDoctor; }
            set { priorityDoctor = value; }
        }
        public bool PriorityDate
        {
            get { return priorityDate; }
            set { priorityDate = value; }
        }

        #endregion

    }
}
