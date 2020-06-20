using hci2020_doctors_ui.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace hci2020_doctors_ui.ViewModel
{
    public class SearchViewModel : BaseViewModel
    {
        private ObservableCollection<PatientModel> patients;

        public ObservableCollection<PatientModel> Patients
        {
            get { return patients; }
            set { patients = value; }
        }

        private ObservableCollection<PatientModel> displayPatients;

        public ObservableCollection<PatientModel> DisplayPatients
        {
            get { return displayPatients; }
            set { displayPatients = value; OnPropertyChanged("DisplayPatients"); }
        }

        private PatientModel navigate;

        public PatientModel Navigate
        {
            get { return navigate; }
            set { navigate = value; OnPropertyChanged("Navigate"); }
        }

        public RelayCommand NavigateToPatientProfile { get; set; }

        public void NavigateTo(object param)
        {
            string name = (string)param;
            foreach (PatientModel pat in Patients)
            {
                if (pat.Name == name)
                {
                    Navigate = pat;
                    return;
                }
            }
        }

        private string searchTerm;

        public string SearchTerm
        {
            get { return searchTerm; }
            set { searchTerm = value; OnPropertyChanged("SearchTerm"); }
        }


        public RelayCommand SearchPatientsCommand { get; set; }
        public void Search(object param)
        {
            if (SearchTerm == "") DisplayPatients = new ObservableCollection<PatientModel>(Patients);
            ObservableCollection<PatientModel> temp = new ObservableCollection<PatientModel>();

            foreach (PatientModel patient in Patients)
            {
                if (patient.Name.ToLower().Contains(SearchTerm.ToLower()))
                {
                    temp.Add(patient);
                }
            }

            if (temp.Count == 0)
            {
                DisplayPatients = new ObservableCollection<PatientModel>(Patients);
            }
            else
            {
                DisplayPatients = new ObservableCollection<PatientModel>(temp);
            }
        }


        private static SearchViewModel instance;
        public static SearchViewModel Instance
        {
            get
            {
                if (instance == null)
                    instance = new SearchViewModel();
                return instance;
            }
        }

        public SearchViewModel()
        {
            PatientModel patient1 = new PatientModel()
            {
                Name = "Petar Perić",
                Birth = new DateTime(1994, 7, 15),
                Gender = (string)Application.Current.Resources["MaleLabel"],
                Email = "petarperic@email.com",
                Phone = "065/1234-51-23",
                BloodType = "A-",
                Allergies = (string)Application.Current.Resources["PeanutsLabel"],
                Diseases = (string)Application.Current.Resources["NoneLabel"],
                Accommodate = (string)Application.Current.Resources["AtHomeLabel"],
                GeneralPracticioner = "Stevica Stević",
                Terms = new ObservableCollection<Appointment>()
                {
                    new Appointment()
                    {
                        Id = 1,
                        Patient = "Petar Perić",
                        AppointmentDate = "14/06/2019",
                        AppointmentStartTime = "12:20PM",
                        AppointmentEndTime = "1:20PM",
                        AppointmentType = AppointmentTypes.Checkup,
                        Doctor = "Stevica Stević",
                        SpecialtyType = SpecialtyType.Cardiac,
                        Report = new MedicalReportModel()
                        {
                            CommonConditions = new ObservableCollection<string>()
                            {
                                (string)Application.Current.Resources["AlcoholLabel"],
                                (string)Application.Current.Resources["StrokeLabel"],
                                (string)Application.Current.Resources["Fever"]
                            },
                            DoctorsRemark = "Patient was feeling rather ill and unstable. Left him to rest until tomorrow",
                            Observations  = new ObservableCollection<string>()
                            {
                                (string)Application.Current.Resources["ClearLabel"],
                                (string)Application.Current.Resources["ShallowLabel"],
                                "127/90",
                                "60",
                                "37",
                                (string)Application.Current.Resources["NormalLabel"]
                            },
                            PatientsReport = "Did not speak."
                        }
                    },
                    new Appointment()
                    {
                        Id = 2,
                        Patient = "Petar Perić",
                        AppointmentDate = "15/07/2019",
                        AppointmentStartTime = "8:00AM",
                        AppointmentEndTime = "9:20AM",
                        AppointmentType = AppointmentTypes.Operation,
                        Doctor = "Stevica Stević",
                        SpecialtyType = SpecialtyType.Cardiac,
                        Report = new MedicalReportModel()
                        {
                            CommonConditions = new ObservableCollection<string>()
                            {
                                (string)Application.Current.Resources["AlcoholLabel"],
                                (string)Application.Current.Resources["StrokeLabel"],
                                (string)Application.Current.Resources["Fever"]
                            },
                            DoctorsRemark = "Patient was feeling rather ill and unstable. Left him to rest until tomorrow",
                            Observations  = new ObservableCollection<string>()
                            {
                                (string)Application.Current.Resources["ClearLabel"],
                                (string)Application.Current.Resources["ShallowLabel"],
                                "127/90",
                                "60",
                                "37",
                                (string)Application.Current.Resources["NormalLabel"]
                            },
                            PatientsReport = "Did not speak."
                        }
                    },
                    new Appointment()
                    {
                        Id = 3,
                        Patient = "Petar Perić",
                        AppointmentDate = "24/09/2019",
                        AppointmentStartTime = "11:20AM",
                        AppointmentEndTime = "1:00PM",
                        AppointmentType = AppointmentTypes.Checkup,
                        Doctor = "Stevica Stević",
                        SpecialtyType = SpecialtyType.Cardiac,
                        Report = new MedicalReportModel()
                        {
                            CommonConditions = new ObservableCollection<string>()
                            {
                                 (string)Application.Current.Resources["AlcoholLabel"],
                                (string)Application.Current.Resources["StrokeLabel"],
                                (string)Application.Current.Resources["Fever"]
                            },
                            DoctorsRemark = "Patient was feeling rather ill and unstable. Left him to rest until tomorrow",
                            Observations  = new ObservableCollection<string>()
                            {
                                (string)Application.Current.Resources["ClearLabel"],
                                (string)Application.Current.Resources["ShallowLabel"],
                                "127/90",
                                "60",
                                "37",
                                (string)Application.Current.Resources["NormalLabel"]
                            },
                            PatientsReport = "Did not speak."
                        }
                    },
                },
                Therapy = new ObservableCollection<PrescriptionMedicineModel>()
                {
                    new PrescriptionMedicineModel(WritePrescriptionViewModel.Instance.MedicineCollection[1].Name, 3, "Once a day"),
                    new PrescriptionMedicineModel(WritePrescriptionViewModel.Instance.MedicineCollection[5].Name, 3, "Every 6 hours"),
                },
                Id = 1
            };
            PatientModel patient2 = new PatientModel()
            {
                Name = "Ildika Kisz",
                Birth = new DateTime(1991, 9, 7),
                Gender = (string)Application.Current.Resources["FemaleLabel"],
                Phone = "064/2134-13-99",
                Email = "ildikak@email.com",
                BloodType = "0+",
                Allergies = (string)Application.Current.Resources["NoneLabel"],
                Diseases = "Diabetes",
                Accommodate = (string)Application.Current.Resources["RoomLabel"] + " 1237",
                GeneralPracticioner = "Jovan Jovanović",
                Terms = new ObservableCollection<Appointment>()
                {
                    new Appointment()
                    {
                        Id = 4,
                        Patient = "Ildika Kisz",
                        AppointmentDate = "07/12/2019",
                        AppointmentStartTime = "2:30PM",
                        AppointmentEndTime = "3:30PM",
                        AppointmentType = AppointmentTypes.Checkup,
                        Doctor = "Stevica Stević",
                        SpecialtyType = SpecialtyType.Neurological,
                        Report = new MedicalReportModel()
                        {
                            CommonConditions = new ObservableCollection<string>()
                            {
                                 (string)Application.Current.Resources["AlcoholLabel"],
                                (string)Application.Current.Resources["StrokeLabel"],
                                (string)Application.Current.Resources["Fever"]
                            },
                            DoctorsRemark = "Patient was feeling rather ill and unstable. Left him to rest until tomorrow",
                            Observations  = new ObservableCollection<string>()
                            {
                                (string)Application.Current.Resources["ClearLabel"],
                                (string)Application.Current.Resources["ShallowLabel"],
                                "127/90",
                                "60",
                                "37",
                                (string)Application.Current.Resources["NormalLabel"]
                            },
                            PatientsReport = "Did not speak."
                        }
                    },
                    new Appointment()
                    {
                        Id = 5,
                        Patient = "Ildika Kisz",
                        AppointmentDate = "14/12/2019",
                        AppointmentStartTime = "8:00AM",
                        AppointmentEndTime = "9:20AM",
                        AppointmentType = AppointmentTypes.Operation,
                        Doctor = "Stevica Stević",
                        SpecialtyType = SpecialtyType.Neurological,
                        Report = new MedicalReportModel()
                        {
                            CommonConditions = new ObservableCollection<string>()
                            {
                                 (string)Application.Current.Resources["AlcoholLabel"],
                                (string)Application.Current.Resources["StrokeLabel"],
                                (string)Application.Current.Resources["Fever"]
                            },
                            DoctorsRemark = "Patient was feeling rather ill and unstable. Left him to rest until tomorrow",
                            Observations  = new ObservableCollection<string>()
                            {
                                (string)Application.Current.Resources["ClearLabel"],
                                (string)Application.Current.Resources["ShallowLabel"],
                                "127/90",
                                "60",
                                "37",
                                (string)Application.Current.Resources["NormalLabel"]
                            },
                            PatientsReport = "Did not speak."
                        }
                    },
                    new Appointment()
                    {
                        Id = 6,
                        Patient = "Ildika Kisz",
                        AppointmentDate = "24/03/2020",
                        AppointmentStartTime = "11:20AM",
                        AppointmentEndTime = "1:00PM",
                        AppointmentType = AppointmentTypes.Checkup,
                        Doctor = "Jovan Jovanović",
                        SpecialtyType = SpecialtyType.General,
                        Report = new MedicalReportModel()
                        {
                            CommonConditions = new ObservableCollection<string>()
                            {
                                 (string)Application.Current.Resources["AlcoholLabel"],
                                (string)Application.Current.Resources["StrokeLabel"],
                                (string)Application.Current.Resources["Fever"]
                            },
                            DoctorsRemark = "Patient was feeling rather ill and unstable. Left him to rest until tomorrow",
                            Observations  = new ObservableCollection<string>()
                            {
                                (string)Application.Current.Resources["ClearLabel"],
                                (string)Application.Current.Resources["ShallowLabel"],
                                "127/90",
                                "60",
                                "37",
                                (string)Application.Current.Resources["NormalLabel"]
                            },
                            PatientsReport = "Did not speak."
                        }
                    },
                },
                Therapy = new ObservableCollection<PrescriptionMedicineModel>()
                {
                    new PrescriptionMedicineModel(WritePrescriptionViewModel.Instance.MedicineCollection[2].Name, 6, "Every night before bed"),
                    new PrescriptionMedicineModel(WritePrescriptionViewModel.Instance.MedicineCollection[1].Name, 4, "Every 6 hours"),
                },
                Id = 2
            };
            PatientModel patient3 = new PatientModel()
            {
                Name = "Ilija Stevanović",
                Birth = new DateTime(1959, 1, 14),
                Gender = (string)Application.Current.Resources["MaleLabel"],
                Email = "stevanovic@email.com",
                Phone = "062/5711-24-18",
                BloodType = "AB-",
                Allergies = "Penicilin",
                Diseases = "Diabetes",
                Accommodate = (string)Application.Current.Resources["RoomLabel"] + " 3512",
                GeneralPracticioner = "Petar Ilić",
                Terms = new ObservableCollection<Appointment>()
                {
                    new Appointment()
                    {
                        Id = 8,
                        Patient = "Ilija Stevanović",
                        AppointmentDate = "17/2/2019",
                        AppointmentStartTime = "4:30PM",
                        AppointmentEndTime = "5:30PM",
                        AppointmentType = AppointmentTypes.Checkup,
                        Doctor = "Marko Marković",
                        SpecialtyType = SpecialtyType.Neurological,
                        Report = new MedicalReportModel()
                        {
                            CommonConditions = new ObservableCollection<string>()
                            {
                                 (string)Application.Current.Resources["AlcoholLabel"],
                                (string)Application.Current.Resources["StrokeLabel"],
                                (string)Application.Current.Resources["Fever"]
                            },
                            DoctorsRemark = "Patient was feeling rather ill and unstable. Left him to rest until tomorrow",
                            Observations  = new ObservableCollection<string>()
                            {
                                (string)Application.Current.Resources["ClearLabel"],
                                (string)Application.Current.Resources["ShallowLabel"],
                                "127/90",
                                "60",
                                "37",
                                (string)Application.Current.Resources["NormalLabel"]
                            },
                            PatientsReport = "Did not speak."
                        }
                    },
                    new Appointment()
                    {
                        Id = 9,
                        Patient = "Ilija Stevanović",
                        AppointmentDate = "24/2/2019",
                        AppointmentStartTime = "8:00AM",
                        AppointmentEndTime = "9:20AM",
                        AppointmentType = AppointmentTypes.Operation,
                        Doctor = "Stevica Stević",
                        SpecialtyType = SpecialtyType.Neurological,
                        Report = new MedicalReportModel()
                        {
                            CommonConditions = new ObservableCollection<string>()
                            {
                                 (string)Application.Current.Resources["AlcoholLabel"],
                                (string)Application.Current.Resources["StrokeLabel"],
                                (string)Application.Current.Resources["Fever"]
                            },
                            DoctorsRemark = "Patient was feeling rather ill and unstable. Left him to rest until tomorrow",
                            Observations  = new ObservableCollection<string>()
                            {
                                (string)Application.Current.Resources["ClearLabel"],
                                (string)Application.Current.Resources["ShallowLabel"],
                                "127/90",
                                "60",
                                "37",
                                (string)Application.Current.Resources["NormalLabel"]
                            },
                            PatientsReport = "Did not speak."
                        }
                    },
                    new Appointment()
                    {
                        Id = 10,
                        Patient = "Ilija Stevanović",
                        AppointmentDate = "1/6/2019",
                        AppointmentStartTime = "11:20AM",
                        AppointmentEndTime = "1:00PM",
                        AppointmentType = AppointmentTypes.Checkup,
                        Doctor = "Jovan Jovanović",
                        SpecialtyType = SpecialtyType.General,
                        Report = new MedicalReportModel()
                        {
                            CommonConditions = new ObservableCollection<string>()
                            {
                                 (string)Application.Current.Resources["AlcoholLabel"],
                                (string)Application.Current.Resources["StrokeLabel"],
                                (string)Application.Current.Resources["Fever"]
                            },
                            DoctorsRemark = "Patient was feeling rather ill and unstable. Left him to rest until tomorrow",
                            Observations  = new ObservableCollection<string>()
                            {
                                (string)Application.Current.Resources["ClearLabel"],
                                (string)Application.Current.Resources["ShallowLabel"],
                                "127/90",
                                "60",
                                "37",
                                (string)Application.Current.Resources["NormalLabel"]
                            },
                            PatientsReport = "Did not speak."
                        }
                    },
                    new Appointment()
                    {
                        Id = 11,
                        Patient = "Ilija Stevanović",
                        AppointmentDate = "5/8/2019",
                        AppointmentStartTime = "11:20AM",
                        AppointmentEndTime = "1:00PM",
                        AppointmentType = AppointmentTypes.Checkup,
                        Doctor = "Petar Ilić",
                        SpecialtyType = SpecialtyType.General,
                        Report = new MedicalReportModel()
                        {
                            CommonConditions = new ObservableCollection<string>()
                            {
                                 (string)Application.Current.Resources["AlcoholLabel"],
                                (string)Application.Current.Resources["StrokeLabel"],
                                (string)Application.Current.Resources["Fever"]
                            },
                            DoctorsRemark = "Patient was feeling rather ill and unstable. Left him to rest until tomorrow",
                            Observations  = new ObservableCollection<string>()
                            {
                                (string)Application.Current.Resources["ClearLabel"],
                                (string)Application.Current.Resources["ShallowLabel"],
                                "127/90",
                                "60",
                                "37",
                                (string)Application.Current.Resources["NormalLabel"]
                            },
                            PatientsReport = "Did not speak."
                        }
                    },
                    new Appointment()
                    {
                        Id = 12,
                        Patient = "Ilija Stevanović",
                        AppointmentDate = "14/9/2019",
                        AppointmentStartTime = "11:20AM",
                        AppointmentEndTime = "1:00PM",
                        AppointmentType = AppointmentTypes.Checkup,
                        Doctor = "Petar Ilić",
                        SpecialtyType = SpecialtyType.General,
                        Report = new MedicalReportModel()
                        {
                            CommonConditions = new ObservableCollection<string>()
                            {
                                 (string)Application.Current.Resources["AlcoholLabel"],
                                (string)Application.Current.Resources["StrokeLabel"],
                                (string)Application.Current.Resources["Fever"]
                            },
                            DoctorsRemark = "Patient was feeling rather ill and unstable. Left him to rest until tomorrow",
                            Observations  = new ObservableCollection<string>()
                            {
                                (string)Application.Current.Resources["ClearLabel"],
                                (string)Application.Current.Resources["ShallowLabel"],
                                "127/90",
                                "60",
                                "37",
                                (string)Application.Current.Resources["NormalLabel"]
                            },
                            PatientsReport = "Did not speak."
                        }
                    },
                },
                Therapy = new ObservableCollection<PrescriptionMedicineModel>()
                {
                    new PrescriptionMedicineModel(WritePrescriptionViewModel.Instance.MedicineCollection[2].Name, 6, "Every night before bed"),
                    new PrescriptionMedicineModel(WritePrescriptionViewModel.Instance.MedicineCollection[1].Name, 4, "Every 6 hours"),
                },
                Id = 3
            };
            PatientModel patient4 = new PatientModel()
            {
                Name = "Ivana Živanović",
                Birth = new DateTime(1979, 4, 9),
                Gender = (string)Application.Current.Resources["FemaleLabel"],
                Email = "ivanaziva@email.com",
                Phone = "064/2341-14-91",
                BloodType = "B+",
                Allergies = (string)Application.Current.Resources["SunLabel"],
                Diseases = (string)Application.Current.Resources["NoneLabel"],
                Accommodate = (string)Application.Current.Resources["AtHomeLabel"],
                GeneralPracticioner = "Petar Ilić",
                Terms = new ObservableCollection<Appointment>()
                {
                    new Appointment()
                    {
                        Id = 13,
                        Patient = "Ivana Živanović",
                        AppointmentDate = "14/4/2019",
                        AppointmentStartTime =  "4:30PM",
                        AppointmentEndTime = "5:30PM",
                        AppointmentType = AppointmentTypes.Checkup,
                        Doctor = "Marko Marković",
                        SpecialtyType = SpecialtyType.Oncological,
                        Report = new MedicalReportModel()
                        {
                            CommonConditions = new ObservableCollection<string>()
                            {
                                 (string)Application.Current.Resources["AlcoholLabel"],
                                (string)Application.Current.Resources["StrokeLabel"],
                                (string)Application.Current.Resources["Fever"]
                            },
                            DoctorsRemark = "Patient was feeling rather ill and unstable. Left him to rest until tomorrow",
                            Observations  = new ObservableCollection<string>()
                            {
                                (string)Application.Current.Resources["ClearLabel"],
                                (string)Application.Current.Resources["ShallowLabel"],
                                "127/90",
                                "60",
                                "37",
                                (string)Application.Current.Resources["NormalLabel"]
                            },
                            PatientsReport = "Did not speak."
                        }
                    },
                    new Appointment()
                    {
                        Id = 14,
                        Patient = "Ivana Živanović",
                        AppointmentDate = "24/6/2019",
                        AppointmentStartTime = "8:00AM",
                        AppointmentEndTime = "9:20AM",
                        AppointmentType = AppointmentTypes.Operation,
                        Doctor = "Stevica Stević",
                        SpecialtyType = SpecialtyType.Oncological,
                        Report = new MedicalReportModel()
                        {
                            CommonConditions = new ObservableCollection<string>()
                            {
                                 (string)Application.Current.Resources["AlcoholLabel"],
                                (string)Application.Current.Resources["StrokeLabel"],
                                (string)Application.Current.Resources["Fever"]
                            },
                            DoctorsRemark = "Patient was feeling rather ill and unstable. Left him to rest until tomorrow",
                            Observations  = new ObservableCollection<string>()
                            {
                                (string)Application.Current.Resources["ClearLabel"],
                                (string)Application.Current.Resources["ShallowLabel"],
                                "127/90",
                                "60",
                                "37",
                                (string)Application.Current.Resources["NormalLabel"]
                            },
                            PatientsReport = "Did not speak."
                        }
                    },
                    new Appointment()
                    {
                        Id = 15,
                        Patient = "Ivana Živanović",
                        AppointmentDate = "1/9/2019",
                        AppointmentStartTime = "11:20AM",
                        AppointmentEndTime = "1:00PM",
                        AppointmentType = AppointmentTypes.Checkup,
                        Doctor = "Ivona Ilić",
                        SpecialtyType = SpecialtyType.General,
                        Report = new MedicalReportModel()
                        {
                            CommonConditions = new ObservableCollection<string>()
                            {
                                 (string)Application.Current.Resources["AlcoholLabel"],
                                (string)Application.Current.Resources["StrokeLabel"],
                                (string)Application.Current.Resources["Fever"]
                            },
                            DoctorsRemark = "Patient was feeling rather ill and unstable. Left him to rest until tomorrow",
                            Observations  = new ObservableCollection<string>()
                            {
                                (string)Application.Current.Resources["ClearLabel"],
                                (string)Application.Current.Resources["ShallowLabel"],
                                "127/90",
                                "60",
                                "37",
                                (string)Application.Current.Resources["NormalLabel"]
                            },
                            PatientsReport = "Did not speak."
                        }
                    },
                    new Appointment()
                    {
                        Id = 16,
                        Patient = "Ivana Živanović",
                        AppointmentDate = "5/11/2019",
                        AppointmentStartTime = "11:20AM",
                        AppointmentEndTime = "1:00PM",
                        AppointmentType = AppointmentTypes.Checkup,
                        Doctor = "Petar Ilić",
                        SpecialtyType = SpecialtyType.General,
                        Report = new MedicalReportModel()
                        {
                            CommonConditions = new ObservableCollection<string>()
                            {
                                 (string)Application.Current.Resources["AlcoholLabel"],
                                (string)Application.Current.Resources["StrokeLabel"],
                                (string)Application.Current.Resources["Fever"]
                            },
                            DoctorsRemark = "Patient was feeling rather ill and unstable. Left him to rest until tomorrow",
                            Observations  = new ObservableCollection<string>()
                            {
                                (string)Application.Current.Resources["ClearLabel"],
                                (string)Application.Current.Resources["ShallowLabel"],
                                "127/90",
                                "60",
                                "37",
                                (string)Application.Current.Resources["NormalLabel"]
                            },
                            PatientsReport = "Did not speak."
                        }
                    },
                },
                Therapy = new ObservableCollection<PrescriptionMedicineModel>()
                {
                    new PrescriptionMedicineModel(WritePrescriptionViewModel.Instance.MedicineCollection[3].Name, 1, "Every night before bed"),
                    new PrescriptionMedicineModel(WritePrescriptionViewModel.Instance.MedicineCollection[2].Name, 3, "Every 6 hours"),
                },
                Id = 4
            };

            Patients = new ObservableCollection<PatientModel>()
            {
                patient1,
                patient2,
                patient3,
                patient4
            };
            SearchTerm = "";
            DisplayPatients = new ObservableCollection<PatientModel>();
            NavigateToPatientProfile = new RelayCommand(NavigateTo);
            SearchPatientsCommand = new RelayCommand(Search);
        }

    }
}
