using Model.BusinessHours;

namespace Model.Users
{
    public class Employee : RegisteredUser
    {
		private string _jobPosition;
        private EmployeeType employeeType;

        public EmployeeType EmployeeType
        {
            get { return employeeType; }
            set { employeeType = value; }
        }


        private BusinessHoursModel _businessHours;

		public BusinessHoursModel BusinessHours
		{
			get { return _businessHours; }
			set { _businessHours = value; OnPropertyChanged("BusinessHours"); }
		}


		public string JobPosition
		{
			get { return _jobPosition; }
			set { _jobPosition = value; OnPropertyChanged("JobPosition"); }
		}

	}

	public enum EmployeeType
    {
		Doctor,
		Secretary
    }
}
