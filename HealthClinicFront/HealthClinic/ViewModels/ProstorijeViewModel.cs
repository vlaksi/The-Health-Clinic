
using HealthClinic.Dialogs;
using HealthClinic.Utilities;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.ComponentModel;
using System.Drawing;
using HealthClinic.Views.Dialogs.Brisanje;
using Syncfusion.Pdf.Tables;
using System.Data;
using HealthClinic.Views.Dialogs.ProduzeneInformacije;
using Model.Rooms;
using HealthClinic.Model.Rooms;

namespace HealthClinic.ViewModels
{
    public class ProstorijeViewModel:ObservableObject
    {

        public ProstorijeViewModel()
        {
            PieChart();
            ucitavanjeProstorija();

            
            DodajProstorijuCommand = new RelayCommand(DodajProstoriju);
            IzmeniProstorijuCommand = new RelayCommand(IzmeniProstoriju);
            IzbrisiProstorijuCommand = new RelayCommand(IzbrisiProstoriju);

            GenerisiIzvestajProstorijaCommand = new RelayCommand(GenerisiIzvestaj);
            SpisakOpremeCommand = new RelayCommand(PrikaziSpisakOpreme);
            ZauzetostAktivnostCommand = new RelayCommand(PrikaziZauzetostAktivnost);

            KalendarObject = new Calendar();
            PodesavanjeZauzetihDatumaIzabraneProstorije();

            // Zelim da renoviranje bude prvo selektovano u radio button grupi
            Renoviranje = true;

            // potvrdjujem izmenjene podatke
            PotvrdaIzmenePodatakaCommand = new RelayCommand(PotvrdaIzmenePodataka);

            // potvrdjujem dodavanje podataka
            PotvrdaDodavanjaPodatakaCommand = new RelayCommand(PotvrdaDodavanjaPodataka);

            // potvrdjujem brisanje podataka
            PotvrdaBrisanjaPodatakaCommand = new RelayCommand(PotvrdaBrisanjaPodataka);

            odredjivanjeMogucihTipovaProstorije();

            // Potvrdjujem uneto podesavanje za odredjivanje aktivnosti i radova u narednom periodu izabrane prostorije
            PotvrdiZauzetostAktivnostCommand = new RelayCommand(PotvrdiZauzetostAktivnost);

            // prikaz fizickih radova nad prostorijom u narednom periodu
            PrikaziFizickeRadoveCommand = new RelayCommand(PrikaziFizickeRadove);

            // dodavanje opreme
            DodajOpremuCommand = new RelayCommand(DodajOpremu);

            // uklanjanje opreme
            UkloniOpremuCommand = new RelayCommand(UkloniOpremu);
        }
        
        #region Prostorija koja sluzi za dodavanje u listu prostorija

        private Room _prostorijaZaDodavanje;

        public Room ProstorijaZaDodavanje
        {
            get { return _prostorijaZaDodavanje; }
            set { _prostorijaZaDodavanje = value; OnPropertyChanged("ProstorijaZaDodavanje"); }
        }

        #endregion

        #region Radio buttoni u dijalogu dugmeta tabele

        private bool _renoviranje;
        private bool _spajanje;
        private bool _deljenje;

        public bool Renoviranje
        {
            get { return _renoviranje; }
            set 
            { 
                _renoviranje = value;
                if (_renoviranje == true)
                {
                    podesiPropertije();
                }
                OnPropertyChanged("Renoviranje");
            }
        }

        private void podesiPropertije()
        {
            PrikazTipaRenoviranja = Visibility.Visible;
            PrikazNoveProstorije = Visibility.Collapsed;
            PrikazDrugeNoveProstorije = Visibility.Collapsed;
            PrikazSobeSaKojomSpajamo = Visibility.Collapsed;
        }

        public bool Spajanje
        {
            get { return _spajanje; }
            set 
            { 
                _spajanje = value;
                if(_spajanje == true)
                {
                    PrikazNoveProstorije = Visibility.Visible;
                    PrikazSobeSaKojomSpajamo = Visibility.Visible;
                    PrikazDrugeNoveProstorije = Visibility.Collapsed;
                    PrikazTipaRenoviranja = Visibility.Collapsed;
                }
                OnPropertyChanged("Spajanje");
            }
        }

        public bool Deljenje
        {
            get { return _deljenje; }
            set 
            { 
                _deljenje = value;
                if(_deljenje == true)
                {
                    PrikazNoveProstorije = Visibility.Visible;
                    PrikazDrugeNoveProstorije = Visibility.Visible;
                    PrikazTipaRenoviranja = Visibility.Collapsed;
                    PrikazSobeSaKojomSpajamo = Visibility.Collapsed;
                }
                OnPropertyChanged("Deljenje");
            }
        }
        
        #endregion

        #region Prikazi odredjenih fildova

        private Visibility _prikazProstorijeSaKojomSpajamo;

        public Visibility PrikazSobeSaKojomSpajamo
        {
            get { return _prikazProstorijeSaKojomSpajamo; }
            set { _prikazProstorijeSaKojomSpajamo = value; OnPropertyChanged("PrikazSobeSaKojomSpajamo"); }
        }


        private Visibility _prikazTipaRenoviranja;

        public Visibility PrikazTipaRenoviranja
        {
            get { return _prikazTipaRenoviranja; }
            set { _prikazTipaRenoviranja = value; OnPropertyChanged("PrikazTipaRenoviranja"); }
        }

        private Visibility _prikazNoveProstorije;

        public Visibility PrikazNoveProstorije
        {
            get { return _prikazNoveProstorije; }
            set { _prikazNoveProstorije = value; OnPropertyChanged("PrikazNoveProstorije"); }
        }


        private Visibility _prikazDrugeNoveProstorije;

        public Visibility PrikazDrugeNoveProstorije
        {
            get { return _prikazDrugeNoveProstorije; }
            set { _prikazDrugeNoveProstorije = value; OnPropertyChanged("PrikazDrugeNoveProstorije"); }
        }





        #endregion

        #region Kalendar u dijalogu dugmeta tabele

        private Calendar _kalendarObject;

        public Calendar KalendarObject
        {
            get { return _kalendarObject; }
            set 
            { 
                _kalendarObject = value;
                OnPropertyChanged("KalendarObject");
            }
        }

        private void PodesavanjeZauzetihDatumaIzabraneProstorije()
        {
            KalendarObject.BlackoutDates.Add(new CalendarDateRange(new DateTime(1990,1,1),DateTime.Now.Date));

            // TODO: Napraviti da se stave pravi datumi kada je prostorija zauzeta
            KalendarObject.BlackoutDates.Add(new CalendarDateRange(new DateTime(2020, 6, 2), new DateTime(2020, 6, 15)));
        }


        #endregion

        #region Selektovana prostorija

        private Room _selektovanaProstorija;


        // Bajndujem na SelectedItem u tabeli i dalje radim sa njim sta hocu
        // mogu ga dalje prikazivati
        // a moze se i proslediti u dijalog
        // tako sto se .DatContext tog dijalog postavi na this
        public Room SelektovanaProstorija
        {
            get { return _selektovanaProstorija; }
            set 
            { 
                _selektovanaProstorija = value;
                OnPropertyChanged("SelektovanaProstorija");
            }
        }


        #endregion

        #region Prostorija za izmene

        private Room _prostorijaZaIzmenu;
        /// <summary>
        /// Algoritam izmene prostorije: http://prntscr.com/sul6bj
        /// </summary>
        public Room ProstorijaZaIzmenu
        {
            get { return _prostorijaZaIzmenu; }
            set { _prostorijaZaIzmenu = value; OnPropertyChanged("ProstorijaZaIzmenu"); }
        }



        #endregion

        #region Trenutno aktivni prozor

        /// <summary>
        /// Promenljiva u kojoj cuvam trenutno otvoreni prozor
        /// kako bih kasnije u komandama u zavisnosti od komande
        /// recimo zatvorio trenutni prozor
        /// </summary>
        private Window _trenutniProzor;

        public Window TrenutniProzor
        {
            get { return _trenutniProzor; }
            set { _trenutniProzor = value; }
        }

        #endregion

        #region Komande

        public RelayCommand PotvrdaBrisanjaPodatakaCommand { get; private set; }
        public RelayCommand PotvrdaDodavanjaPodatakaCommand { get; private set; }
        public RelayCommand PotvrdaIzmenePodatakaCommand { get; private set; }
        public RelayCommand ZauzetostAktivnostCommand { get; private set; }
        public RelayCommand SpisakOpremeCommand { get; private set; }
        public RelayCommand GenerisiIzvestajProstorijaCommand { get; private set; }
        public RelayCommand DodajProstorijuCommand { get; private set; }
        public RelayCommand IzmeniProstorijuCommand { get; private set; }
        public RelayCommand IzbrisiProstorijuCommand { get; private set; }
        public RelayCommand PotvrdiZauzetostAktivnostCommand { get; private set; }
        public RelayCommand PrikaziFizickeRadoveCommand { get; private set; }
        public RelayCommand DodajOpremuCommand { get; private set; }
        public RelayCommand UkloniOpremuCommand { get; private set; }

        #endregion

        #region Funkcije koje komande koriste

        public void PotvrdaBrisanjaPodataka(object obj)
        {
            if (SelektovanaProstorija is null)
                return;

            foreach (Room trenutnaProstorija in Prostorije)
            {
                if(trenutnaProstorija.NumberOfRoom == SelektovanaProstorija.NumberOfRoom)
                {
                    MessageBox.Show("Uspesno ste izbrisali sobu broj " + trenutnaProstorija.NumberOfRoom);
                    podesiBrojOdredjenihProstorija(trenutnaProstorija, -1);
                    Prostorije.Remove(trenutnaProstorija);

                    break;
                }
            }

            this.TrenutniProzor.Close();
        }

        public void PotvrdaDodavanjaPodataka(object ojb)
        {
            if (!validnaProstorija(ProstorijaZaDodavanje))
                return;

            // dodajem prostoriju za dodavanje ukoliko je odgovor bio potvrdan
            Prostorije.Add(ProstorijaZaDodavanje);
            podesiBrojOdredjenihProstorija(ProstorijaZaDodavanje, 1);
            this.TrenutniProzor.Close();
        }

        public void PotvrdaIzmenePodataka(object obj)
        {
            // regulisem da prvo povecam kolicinu novo izmenjenog tipa prostorije
            podesiBrojOdredjenihProstorija(ProstorijaZaIzmenu, 1);

            //podesiBrojOdredjenihLekova(SelektovaniLek, -1);
            podesiBrojOdredjenihProstorija(SelektovanaProstorija, -1);

            if (!validnaProstorija(ProstorijaZaIzmenu))
                return;

            // selektovani objekat prima vrednosti od menjanog objekta
            SelektovanaProstorija.NumberOfRoom = ProstorijaZaIzmenu.NumberOfRoom;
            SelektovanaProstorija.Purpose = ProstorijaZaIzmenu.Purpose;
            SelektovanaProstorija.Department = ProstorijaZaIzmenu.Department;
            this.TrenutniProzor.Close();
        }
        
        public void PotvrdiZauzetostAktivnost(object obj)
        {
            
            if (Renoviranje)
            {   // preuzimam od pomocne promenljive podatke iz forme
                SelektovanaProstorija.PhysicalWork.NameOfWork = TrenutniFizickiRad.NameOfWork;
                SelektovanaProstorija.PhysicalWork.FromDate = TrenutniFizickiRad.FromDate;
                SelektovanaProstorija.PhysicalWork.ToDate = TrenutniFizickiRad.ToDate;
            }
            else if (Deljenje)
            {
                MessageBox.Show("deljenje" + BrojNoveSobe +" " + BrojDrugeNoveSobe);
                // obrisem trenutno selektovanu prostoriju
                foreach (Room trenutnaProstorija in Prostorije)
                {
                    if (trenutnaProstorija.NumberOfRoom == SelektovanaProstorija.NumberOfRoom)
                    {
                        podesiBrojOdredjenihProstorija(trenutnaProstorija, -1);
                        Prostorije.Remove(trenutnaProstorija);

                        break;
                    }
                }

                // dodam ove dve nove
                Room p1 = new Room()
                {
                    NumberOfRoom = int.Parse(BrojNoveSobe),
                    Purpose ="soba za pacijente"
                    
                };

                Room p2 = new Room()
                {
                    NumberOfRoom = int.Parse(BrojDrugeNoveSobe),
                    Purpose = "soba za pacijente"

                };
                Prostorije.Add(p1);
                Prostorije.Add(p2);
                podesiBrojOdredjenihProstorija(p1, 1);
                podesiBrojOdredjenihProstorija(p2, 1);

            }
            else if (Spajanje)
            {
                // prvo moram uklonite ove 2 prostorije
                foreach (Room trenutnaProstorija in Prostorije)
                {
                    if (trenutnaProstorija.NumberOfRoom == SelektovanaProstorija.NumberOfRoom)
                    {
                        podesiBrojOdredjenihProstorija(trenutnaProstorija, -1);
                        Prostorije.Remove(trenutnaProstorija);

                        break;
                    }
                }
                // namerno 2 fora kako ne bih doslo do errora zbog brisanja
                foreach (Room trenutnaProstorija in Prostorije)
                {
                    if (trenutnaProstorija.NumberOfRoom == int.Parse(BrojSobeSaKojomVrsimoSpajanje))
                    {
                        podesiBrojOdredjenihProstorija(trenutnaProstorija, -1);
                        Prostorije.Remove(trenutnaProstorija);

                        break;
                    }
                }

                // dodajem prostoriju
                Room tempProstorija = new Room()
                {
                    NumberOfRoom = int.Parse(BrojNoveSobe),
                    Purpose = NamenaProstorije
                };

                Prostorije.Add(tempProstorija);
                podesiBrojOdredjenihProstorija(tempProstorija, 1);

            }


            this.TrenutniProzor.Close();
        }

        public void PrikaziZauzetostAktivnost(object obj)
        {

            instanciranjeFizickihRadova();
      
            TrenutniProzor = new ZauzetostAktivnostDijalog();
            TrenutniProzor.DataContext = this;             // kako bi povezao i ViewModel Zaposlenih za ovaj dijalog
            TrenutniProzor.ShowDialog();
        }

        public void PrikaziSpisakOpreme(object obj)
        {
            SpisakOpreme = new ObservableCollection<InventoryType>();

            TrenutnaOprema = new InventoryType();
            if(SelektovanaProstorija.RoomInventory is null)
            {
                SelektovanaProstorija.RoomInventory = new List<InventoryType>();

            }

            // preuzimanje od prave opreme prostorije
            foreach (InventoryType oprema in SelektovanaProstorija.RoomInventory)
            {
                SpisakOpreme.Add(oprema);
            }
            

            TrenutniProzor = new SpisakOpremeDijalog();
            TrenutniProzor.DataContext = this;             // kako bi povezao i ViewModel Zaposlenih za ovaj dijalog
            TrenutniProzor.ShowDialog();
        }

        public void GenerisiIzvestaj(object obj)
        {
            using (PdfDocument doc = new PdfDocument())
            {
                //Add a page to the document
                PdfPage page = doc.Pages.Add();

                // Create a PdfLightTable.
                PdfLightTable pdfLightTable = new PdfLightTable();

                // Initialize DataTable to assign as DateSource to the light table.
                DataTable table = new DataTable();

                //Include columns to the DataTable.
                table.Columns.Add("Odeljenje");

                table.Columns.Add("BrojSobe");

                table.Columns.Add("Namena");

                //Include rows to the DataTable.
                foreach (Room prostorija in Prostorije)
                {
                    table.Rows.Add(new string[] { prostorija.Department, prostorija.NumberOfRoom.ToString(), prostorija.Purpose  });
                }


                //Assign data source.
                pdfLightTable.DataSource = table;

                //Draw PdfLightTable.
                pdfLightTable.Draw(page, new PointF(0, 0));

                //Save the document
                doc.Save("C:\\Users\\Vaxi\\Desktop\\6-semestar\\HCI\\projekat\\Vaksi\\HealthClinic\\IzvestajProstorija.pdf");

                doc.Close();
            }
            MessageBox.Show("Uspesno kreiran izvestaj prostorija, mozete ga pogledati u tekucem direktorijumu");
        }

        public void DodajProstoriju(object obj)
        {
            // kreiramo novi objekat koji cemo kasnije u slucaju potvrde dodavanja dodati u listu prostorija
            ProstorijaZaDodavanje = new Room();

            // prikaz dijaloga za dodavanje
            TrenutniProzor = new DodajProstorijuDijalog();
            TrenutniProzor.DataContext = this;
            TrenutniProzor.ShowDialog();

        }

        public void IzmeniProstoriju(object obj)
        {
            // Prostorija za izmenu/stimanje preuzima podatke od selektovane prostorije
            if (!(SelektovanaProstorija is null))
            {
                ProstorijaZaIzmenu = new Room() { Department = SelektovanaProstorija.Department, NumberOfRoom = SelektovanaProstorija.NumberOfRoom, Purpose = SelektovanaProstorija.Purpose };
            }
            else
            {
                return;
            }
            // podesavanje prikaza dijaloga izmene
            TrenutniProzor = new IzmeniProstorijuDijalog();
            TrenutniProzor.DataContext = this;
            TrenutniProzor.ShowDialog();
        }

        public void IzbrisiProstoriju(object obj)
        {
            if (SelektovanaProstorija is null)
                return;

            // TODO: Mozda dodati nekad da pise tacno koju prostoriju brisemo ali u nekim buducim verzijama
            TrenutniProzor = new ObrisiProstorijuDijalog();
            TrenutniProzor.DataContext = this;
            TrenutniProzor.ShowDialog();
        }

        public void PrikaziFizickeRadove(object obj)
        {
            if (SelektovanaProstorija.PhysicalWork is null)
            {
                MessageBox.Show("Izabrana prostorija u narednom periodu nema zakazanih fizickih radova");
                return;
            }else if(SelektovanaProstorija.PhysicalWork.NameOfWork is null)
            {
                MessageBox.Show("Izabrana prostorija u narednom periodu nema zakazanih fizickih radova");
                return;
            }
                

            TrenutniProzor = new FizickiRadoviDijalog();
            TrenutniProzor.DataContext = this;
            TrenutniProzor.ShowDialog();
        }

        public void DodajOpremu(object obj)
        {
            foreach (InventoryType oprema in SpisakOpreme)
            {
                if (oprema.InventoryName == TrenutnaOprema.InventoryName)
                {
                    oprema.Quantity += TrenutnaOprema.Quantity;
                    return;
                }
            }

            // ako dodjem dovde znaci da moram celu tu trenutnu opremu dodati jer je nema u spisku opreme
            InventoryType opremaZaDodavanje = new InventoryType()
            {
                InventoryName = TrenutnaOprema.InventoryName,
                Quantity = TrenutnaOprema.Quantity
            };
            // i kolekciji i zapravo selektovanom dodam
            SpisakOpreme.Add(opremaZaDodavanje);
            SelektovanaProstorija.RoomInventory.Add(opremaZaDodavanje);
            
        }

        public void UkloniOpremu(object obj)
        {
            foreach (InventoryType oprema in SpisakOpreme)
            {
                if (oprema.InventoryName == TrenutnaOprema.InventoryName)
                {
                    oprema.Quantity -= TrenutnaOprema.Quantity;
                    if(oprema.Quantity <= 0)
                    {
                        // uklonim iz prave opreme
                        foreach (InventoryType opremaPrava in SelektovanaProstorija.RoomInventory)
                        {
                            if(opremaPrava.InventoryName == oprema.InventoryName)
                            {
                                SelektovanaProstorija.RoomInventory.Remove(opremaPrava);
                                break;
                            }
                        }
                        // ali i iz observable liste
                        SpisakOpreme.Remove(oprema);
                    }
                    return;
                }
            }
            // ako sam dosao do ovoga onda znaci da te opreme zapravo i nema u listi
            MessageBox.Show("Pokusao si ukloniti opremu koju klinika trenutno nema u posedovanju");
        }


        #endregion

        #region Tabela

        private ObservableCollection<Room> _prostorije;

        public ObservableCollection<Room> Prostorije
        {
            get { return _prostorije; }
            set { _prostorije = value; OnPropertyChanged("Prostorije"); }
        }

        private void ucitavanjeProstorija()
        {
            Prostorije = new ObservableCollection<Room>();
            Prostorije.Add(new Room() { Department = "interno", NumberOfRoom = 12, Purpose = "operaciona sala"});
            Prostorije.Add(new Room() { Department = "interno", NumberOfRoom = 1, Purpose = "soba za preglede" });
            Prostorije.Add(new Room() { Department = "interno", NumberOfRoom = 2, Purpose = "soba za pacijente"});
            Prostorije.Add(new Room() { Department = "decije", NumberOfRoom = 3, Purpose = "soba za pacijente" });
            Prostorije.Add(new Room() { Department = "decije", NumberOfRoom = 9, Purpose = "operaciona sala"});
            Prostorije.Add(new Room() { Department = "otorinolaringologija", NumberOfRoom = 8, Purpose = "soba za preglede" });
            Prostorije.Add(new Room() { Department = "interno", NumberOfRoom = 7, Purpose = "operaciona sala"});

            foreach (Room prostorija in Prostorije)
            {
                podesiBrojOdredjenihProstorija(prostorija, 1);
            }
        }


        


        #endregion

        #region Podesavanje broja odredjenog tipa prostorije

        /// <summary>
        /// Podesavam trenutni broj odredjenog tipa prostorije.
        /// </summary>
        /// <param name="prostorija"></param>
        /// <param name="koeficijentPravca"> Prosledjuje se broj koji govori koliko povecavam/smanjujem broj odredjenih prostorija</param>
        private void podesiBrojOdredjenihProstorija(Room prostorija, int koeficijentPravca)
        {
            if (prostorija.Purpose == "soba za preglede")
            {
                if (this.UkupnoSobaZaPreglede is null)
                    BrojacSobaZaPreglede = 1;
                else
                    BrojacSobaZaPreglede += koeficijentPravca;
                this.UkupnoSobaZaPreglede = new ChartValues<int>() { BrojacSobaZaPreglede };

            }
            else if (prostorija.Purpose == "soba za pacijente")
            {
                if (this.UkupnoSobaZaPacijente is null)
                    BrojacSobaZaPacijente = 1;
                else
                    BrojacSobaZaPacijente += koeficijentPravca;
                this.UkupnoSobaZaPacijente = new ChartValues<int>() { BrojacSobaZaPacijente };
            }
            else if (prostorija.Purpose == "operaciona sala")
            {
                if (this.UkupnoOperacionihSala is null)
                    BrojacOperacionihSala = 1;
                else
                    BrojacOperacionihSala += koeficijentPravca;
                this.UkupnoOperacionihSala = new ChartValues<int>() { BrojacOperacionihSala };
            }
        }

        #endregion

        #region Deo vezan za grafikon

        private ChartValues<int> _ukupnoSobaZaPacijente;
        private ChartValues<int> _ukupnoSobaZaPreglede;
        private ChartValues<int> _ukupnoOperacionihSala;


        public ChartValues<int> UkupnoSobaZaPacijente
        {
            get { return _ukupnoSobaZaPacijente; }
            set { _ukupnoSobaZaPacijente = value; OnPropertyChanged("UkupnoSobaZaPacijente"); }
        }

        public ChartValues<int> UkupnoSobaZaPreglede
        {
            get { return _ukupnoSobaZaPreglede; }
            set { _ukupnoSobaZaPreglede = value; OnPropertyChanged("UkupnoSobaZaPreglede"); }
        }

        public ChartValues<int> UkupnoOperacionihSala
        {
            get { return _ukupnoOperacionihSala; }
            set { _ukupnoOperacionihSala = value; OnPropertyChanged("UkupnoOperacionihSala"); }
        }


        public Func<ChartPoint, string> PointLabel { get; set; }

        private void PieChart()
        {
            PointLabel = chartPoint => string.Format("{0}({1:P})", chartPoint.Y, chartPoint.Participation);
        }

        #endregion

        #region Moguci tipovi prostorija

        private ObservableCollection<string> _moguciTipoviProstorije;

        public ObservableCollection<string> MoguciTipoviProstorije
        {
            get { return _moguciTipoviProstorije; }
            set { _moguciTipoviProstorije = value; OnPropertyChanged("MoguciTipoviProstorije"); }
        }

        private void odredjivanjeMogucihTipovaProstorije()
        {
            MoguciTipoviProstorije = new ObservableCollection<string>();
            MoguciTipoviProstorije.Add("soba za pacijente");
            MoguciTipoviProstorije.Add("soba za preglede");
            MoguciTipoviProstorije.Add("operaciona sala");
            
        }

        #endregion

        #region Brojaci odredjenog tipa prostorije

        /// <summary>
        /// Potreban mi je i brojac koji ce se upisivati u cart,
        /// ne moze direktno i samo brojac da bude ali ni cart.
        /// </summary>
        private int _brojacSobaZaPreglede;
        private int _brojacSobaZaPacijente;
        private int _brojacOperacionihSala;


        public int BrojacSobaZaPreglede
        {
            get { return _brojacSobaZaPreglede; }
            set { _brojacSobaZaPreglede = value; OnPropertyChanged("BrojacSobaZaPreglede"); }
        }

        public int BrojacSobaZaPacijente
        {
            get { return _brojacSobaZaPacijente; }
            set { _brojacSobaZaPacijente = value; OnPropertyChanged("BrojacSobaZaPacijente"); }
        }

        public int BrojacOperacionihSala
        {
            get { return _brojacOperacionihSala; }
            set { _brojacOperacionihSala = value; OnPropertyChanged("BrojacOperacionihSala"); }
        }


        #endregion

        #region Validiranje prostorije

        private bool validnaProstorija(Room prostorija)
        {
            if(prostorija.NumberOfRoom <= 0 )
            {
                MessageBox.Show("Niste popunili polje za broj sobe");
                return false;
            }

            if (prostorija.Purpose is null)
            {
                MessageBox.Show("Niste popunili namenu sobe(tip prostorije)");
                return false;
            }

            if (prostorija.Department is null)
            {
                MessageBox.Show("Niste popunili polje za odeljenje na kojem se nalazi soba");
                return false;
            }

            // TODO: Kada saznas kako dobiti koje trenutno validacione probleme ima app, ovde to mogu hendlovati

            return true;
        }

        #endregion

        #region Singlton pattern
        private static ProstorijeViewModel instance = null;
        private static readonly object padlock = new object();


        public static ProstorijeViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ProstorijeViewModel();
                    }
                    return instance;
                }
            }
        }
        #endregion

        #region Spisak opreme odredjene prostorije
        private ObservableCollection<InventoryType> _spisakOpreme;

        public ObservableCollection<InventoryType> SpisakOpreme
        {
            get { return _spisakOpreme; }
            set { _spisakOpreme = value; OnPropertyChanged("SpisakOpreme"); }
        }


        #endregion

        #region Trenutna oprema

        private InventoryType _trenutnaOprema;

        public InventoryType TrenutnaOprema
        {
            get { return _trenutnaOprema; }
            set { _trenutnaOprema = value; OnPropertyChanged("TrenutnaOprema"); }
        }
        #endregion

        #region Fizicki radovi za dodavanje/prikaz
        private PhysicalWork _trenutniFizickiRad;

        public PhysicalWork TrenutniFizickiRad
        {
            get { return _trenutniFizickiRad; }
            set { _trenutniFizickiRad = value; OnPropertyChanged("TrenutniFizickiRad"); }
        }

        private void instanciranjeFizickihRadova()
        {
            if (TrenutniFizickiRad is null)
            {
                TrenutniFizickiRad = new PhysicalWork()
                {
                    FromDate = new DateTime(2020, 1, 1),
                    ToDate = new DateTime(2020, 12, 12)
                };
            }

            // instanciram fizicke radove selektovane prostorije
            if (SelektovanaProstorija.PhysicalWork is null)
            {
                SelektovanaProstorija.PhysicalWork = new PhysicalWork();
            }
        }

        #endregion

        #region Soba(samo broj trenutno) sa kojom vrsimo spajanje
        private string _brojSobeSaKojomVrsimoSpajanje;

        public string BrojSobeSaKojomVrsimoSpajanje
        {
            get { return _brojSobeSaKojomVrsimoSpajanje; }
            set { _brojSobeSaKojomVrsimoSpajanje = value; OnPropertyChanged("BrojSobeSaKojomVrsimoSpajanje"); }
        }

        #endregion

        #region Broj nove sobe u spajanju + druge nove sobe za deljenje

        private string _brojNoveSobe;
        private string _brojDrugeNoveSobe;


        public string BrojNoveSobe
        {
            get { return _brojNoveSobe; }
            set { _brojNoveSobe = value; OnPropertyChanged("BrojNoveSobe"); }
        }

        public string BrojDrugeNoveSobe
        {
            get { return _brojDrugeNoveSobe; }
            set { _brojDrugeNoveSobe = value; OnPropertyChanged("BrojDrugeNoveSobe"); }
        }

        #endregion

        #region Namena prostorije prilikom spajanja prostorija
        private string _namenaProstorije;

        public string NamenaProstorije
        {
            get { return _namenaProstorije; }
            set { _namenaProstorije = value; OnPropertyChanged("NamenaProstorije"); }
        }

        #endregion
    }

}

