using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hci2020_doctors_ui.Model
{
    public class MedicineModel : ObservableObject
    {
		private int id;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private int price;

		public int Price
		{
			get { return price; }
			set { price = value; }
		}

		public MedicineModel(int id, string name, int price)
		{
			Id = id;
			Name = name;
			Price = price;
		}

		public MedicineModel()
		{
		}

		private MedicineStatus status;

		public MedicineStatus Status
		{
			get { return status; }
			set { status = value; OnPropertyChanged("Status"); }
		}

		private SpecialtyType type;

		public SpecialtyType Type
		{
			get { return type; }
			set { type = value; }
		}


	}
}
