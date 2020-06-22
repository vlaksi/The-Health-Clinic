using HealthClinic.Utilities;
using System;

namespace HealthClinic.Model.Rooms
{
    public class PhysicalWork : ObservableObject
    {
		private string _nameOfWork;
		private DateTime _fromDate;
		private DateTime _toDate;


		public string NameOfWork
		{
			get { return _nameOfWork; }
			set { _nameOfWork = value; OnPropertyChanged("NameOfWork"); }
		}

		public DateTime FromDate
		{
			get { return _fromDate; }
			set { _fromDate = value; OnPropertyChanged("FromDate"); }
		}

		public DateTime ToDate
		{
			get { return _toDate; }
			set { _toDate = value; OnPropertyChanged("ToDate"); }
		}
	}
}
