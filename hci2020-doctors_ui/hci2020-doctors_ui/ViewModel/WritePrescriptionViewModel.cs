using hci2020_doctors_ui.Model;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;

namespace hci2020_doctors_ui.ViewModel
{
    public class WritePrescriptionViewModel : BaseViewModel
    {
        #region Properties
        public ObservableCollection<MedicineModel> medicineCollection;
        public ObservableCollection<MedicineModel> MedicineCollection
        {
            get
            {
                return medicineCollection;
            }
            set
            {
                medicineCollection = value; OnPropertyChanged("MedicineCollection");
            }
        }

        private MedicineModel selectedMedicine;
        public MedicineModel SelectedMedicine
        {
            get
            {
                return selectedMedicine;
            }
            set
            {
                if (value != null)
                {
                    selectedMedicine = value;
                    OnPropertyChanged("SelectedMedicine");
                }
            }
        }

        private string medicineName;

        private PatientModel patient;

        public PatientModel Patient
        {
            get { return patient; }
            set { patient = value; OnPropertyChanged("Patient"); }
        }


        public string MedicineName
        {
            get { return medicineName; }
            set
            {
                if (value != null)
                {
                    medicineName = value;
                    OnPropertyChanged("MedicineName");
                }
            }
        }

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
            set
            {
                frequency = value;
                OnPropertyChanged("Frequency");
            }
        }

        private string instructions;

        public string Instructions
        {
            get { return instructions; }
            set { instructions = value; OnPropertyChanged("Instructions"); }
        }

        private ObservableCollection<MedicineModel> medicinesWaitingApproval;

        public ObservableCollection<MedicineModel> MedicinesWaitingApproval
        {
            get { return medicinesWaitingApproval; }
            set { medicinesWaitingApproval = value; OnPropertyChanged("MedicinesWaitingApproval"); }
        }

        private ObservableCollection<PrescriptionMedicineModel> prescriptionMedicineCollection;
        public ObservableCollection<PrescriptionMedicineModel> PrescriptionMedicineCollection
        {
            get { return prescriptionMedicineCollection; }
            set { prescriptionMedicineCollection = value; OnPropertyChanged("PrescriptionMedicineCollection"); }
        }
        #endregion

        #region Commands
        public RelayCommand AddCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand SubmitCommand { get; set; }
        public RelayCommand AddToListCommand { get; set; }

        private void PrintMedicines()
        {
            foreach (PrescriptionMedicineModel med in PrescriptionMedicineCollection)
            {
                Console.WriteLine("\tName: " + med.Name);
                Console.WriteLine("\tQuantity: " + med.Quantity);
                Console.WriteLine("\tFrequency: " + med.Frequency);
            }
        }

        public void SubmitPrescription(object param)
        {
            Console.WriteLine("~~~ Prescription has been submitted ~~~");
            PrintMedicines();
            Console.WriteLine("Instructions: ");
            Console.WriteLine("\t" + Instructions);
            Patient.Therapy = PrescriptionMedicineCollection;
            PrescriptionMedicineCollection = new ObservableCollection<PrescriptionMedicineModel>();
        }

        //Dodavanje u listu za terapiju
        public void AddMedicine(object param)
        {
            if (SelectedMedicine == null || Frequency.Trim() == "" || Quantity == 0)
            {
                return;
            }

            try
            {
                //Check if it's new
                foreach (PrescriptionMedicineModel med in PrescriptionMedicineCollection)
                {
                    if (string.Compare(SelectedMedicine.Name, med.Name) == 0)
                    {
                        med.Quantity += Quantity;
                        med.Frequency = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Frequency.Trim());
                        return;
                    }
                }

                //If it's a new medicine, add it to the list
                PrescriptionMedicineModel newMedicine = new PrescriptionMedicineModel(SelectedMedicine.Name, Quantity, CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Frequency.Trim()));
                PrescriptionMedicineCollection.Add(newMedicine);
                Console.WriteLine("Succesfully added " + selectedMedicine.Name + " to prescription");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DeleteMedicine(object param)
        {
            string name = (string)param;
            foreach (PrescriptionMedicineModel med in PrescriptionMedicineCollection)
            {
                if (string.Compare(name, med.Name) == 0)
                {
                    PrescriptionMedicineCollection.Remove(med);
                    Console.WriteLine("Successfully removed " + name);
                    return;
                }
            }
        }

        #endregion

        #region Constructor
        public WritePrescriptionViewModel(PatientModel patient)
        {
            Quantity = 0;
            Frequency = " ";
            Patient = patient;

            AddCommand = new RelayCommand(AddMedicine);
            DeleteCommand = new RelayCommand(DeleteMedicine);
            SubmitCommand = new RelayCommand(SubmitPrescription);

            // Svi lijekovi

            //Validirani
            MedicineModel lyrica = new MedicineModel()
            {
                Id = 14,
                Name = "Lyrica",
                Price = 140,
                Status = MedicineStatus.Validated
            };
            MedicineModel aspirine = new MedicineModel()
            {
                Id = 2,
                Name = "Aspirine",
                Price = 30,
                Status = MedicineStatus.Validated
            };
            MedicineModel paracetamol = new MedicineModel()
            {
                Id = 3,
                Name = "Paracetamol",
                Price = 40,
                Status = MedicineStatus.Validated
            };
            MedicineModel lipitor = new MedicineModel()
            {
                Id = 7,
                Name = "Lipitor",
                Price = 210,
                Status = MedicineStatus.Validated
            };
            MedicineModel synthroid = new MedicineModel()
            {
                Id = 8,
                Name = "Synthroid",
                Price = 120,
                Status = MedicineStatus.Validated
            };
            MedicineModel nexium = new MedicineModel()
            {
                Id = 11,
                Name = "Nexium",
                Price = 100,
                Status = MedicineStatus.Validated
            };
            MedicineModel advairDiskus = new MedicineModel()
            {
                Id = 12,
                Name = "Advair Diskus",
                Price = 40,
                Status = MedicineStatus.Validated
            };
            MedicineModel bromazepan = new MedicineModel()
            {
                Id = 1,
                Name = "Bromazepan",
                Price = 20,
                Status = MedicineStatus.Validated
            };
            MedicineModel vicodin = new MedicineModel()
            {
                Id = 4,
                Name = "Vicodin",
                Price = 10,
                Status = MedicineStatus.Validated
            };
            MedicineModel levoxyl = new MedicineModel()
            {
                Id = 5,
                Name = "Levoxyl",
                Price = 60,
                Status = MedicineStatus.Validated
            };
            MedicineModel amoxil = new MedicineModel()
            {
                Id = 6,
                Name = "Amoxil",
                Price = 220,
                Status = MedicineStatus.Validated
            };
            MedicineModel crestor = new MedicineModel()
            {
                Id = 9,
                Name = "Crestor",
                Price = 150,
                Status = MedicineStatus.Validated
            };
            MedicineCollection = new ObservableCollection<MedicineModel>()
            {
                lyrica,
                aspirine,
                paracetamol,
                lipitor,
                synthroid,
                nexium,
                advairDiskus,
                bromazepan,
                vicodin,
                levoxyl,
                amoxil,
                crestor
            };

            //Na čekanju
            MedicineModel ventolin = new MedicineModel()
            {
                Id = 10,
                Name = "Ventolin",
                Price = 90,
                Status = MedicineStatus.Waiting
            };
            MedicineModel vyvanse = new MedicineModel()
            {
                Id = 13,
                Name = "Vyvanse",
                Price = 80,
                Status = MedicineStatus.Waiting
            };
            MedicineModel januvia = new MedicineModel()
            {
                Id = 15,
                Name = "Januvia",
                Price = 175,
                Status = MedicineStatus.Waiting
            };
            MedicinesWaitingApproval = new ObservableCollection<MedicineModel>()
            {
                ventolin,
                vyvanse,
                januvia
            };

            //Za terapiju
            PrescriptionMedicineCollection = new ObservableCollection<PrescriptionMedicineModel>();
        }

        private static WritePrescriptionViewModel instance;
        public static WritePrescriptionViewModel Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new WritePrescriptionViewModel(new PatientModel());
                }
                return instance;
            }
            set
            {
                instance = value;
            }
        }
        #endregion
    }
}
