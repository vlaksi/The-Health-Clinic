using HelathClinicPatienteRole.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HelathClinicPatienteRole.Dialogs
{
    /// <summary>
    /// Interaction logic for PreporukaTerminaDialog.xaml
    /// </summary>
    public partial class PreporukaTerminaDialog : Window
    { 
        private static bool izabranPrioritetDatum;
        public static bool IzabranPrioritetDatum { get => izabranPrioritetDatum; set => izabranPrioritetDatum = value; }
       
        private static bool izabranPrioritetLekar;
        public static bool IzabranPrioritetLekar { get => izabranPrioritetLekar; set => izabranPrioritetLekar = value; }

        public PreporukaTerminaDialog()
        {
            InitializeComponent();
        }

		private void lekarChecked(object sender, RoutedEventArgs e)
		{
		
			if (lekarCheckedCB.IsChecked == true)
			{     
                izabranPrioritetLekar = true;
               
            }
            else
            {    
                izabranPrioritetLekar = false;

            }
        }

		private void datumChecked(object sender, RoutedEventArgs e)
		{

			if (datumCheckedCB.IsChecked == true)
			{
                
                izabranPrioritetDatum = true;

            }
            else { 
                izabranPrioritetDatum = false;

            }
        }

        #region Singlton
        private static PreporukaTerminaDialog instance = null;
        private static readonly object padlock = new object();


        public static PreporukaTerminaDialog Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new PreporukaTerminaDialog();
                    }
                    return instance;
                }
            }
        }
        #endregion
    }
}
