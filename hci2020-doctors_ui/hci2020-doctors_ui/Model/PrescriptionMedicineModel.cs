using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hci2020_doctors_ui.Model
{
    public class PrescriptionMedicineModel : MedicineModel
    {
		private int quantity;
		public int Quantity
		{
			get { return quantity; }
			set { quantity = value; OnPropertyChanged("Quantity"); }
		}

		private string frequency;

		public string Frequency
		{
			get { return frequency; }
			set { frequency = value; OnPropertyChanged("Frequency"); }
		}


		public PrescriptionMedicineModel(string name, int quantity, string frequency) : base(0, name, 0)
		{
			Quantity = quantity;
			Frequency = frequency;
		}
	}
}
