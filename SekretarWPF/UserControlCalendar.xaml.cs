using SekretarWPF.Data;
using Syncfusion.UI.Xaml.Schedule;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows;
using Syncfusion.Pdf.Grid;
using System.Data;
using System.Windows.Automation;
using System.Threading;
using System.Windows.Media;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows.Media.Imaging;
using Model.Users;

namespace SekretarWPF
{
    public partial class UserControlCalendar : UserControl
    {

        CustomEditor customeEditor;
        public UserControlCalendar()
        {
            InitializeComponent();
            customeEditor = new CustomEditor(this.sfSchedule.Appointments, this.checkBoxCheckUp, this.checkBoxOperation);
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            customeEditor.Owner = window;
            this.checkBoxCheckUp.IsChecked = true;
            this.checkBoxOperation.IsChecked = true;
            
        }

        private void buttonDodaj_Click(object sender, RoutedEventArgs e)
        {
            this.AddnewAppointment(new Appointment());
        }

        void Schedule_AppointmentEditorOpening(object sender, AppointmentEditorOpeningEventArgs e)
        {
            e.Cancel = true;
            if (e.Action == EditorAction.Add)
            {
                this.AddnewAppointment(new Appointment() { StartTime = e.StartTime, EndTime = e.StartTime });
            }
            else
                this.EditAppointment(e.Appointment as Appointment);
        }

        private void EditAppointment(Appointment appointment)
        {
            customeEditor.Appointment = appointment;
            customeEditor.EditAppointment();
            customeEditor.ShowDialog();
        }

        private void AddnewAppointment(Appointment newappointment)
        {
            customeEditor.Appointment = newappointment;
            customeEditor.AddAppointment();
            if (customeEditor.ShowDialog() == true)
                this.sfSchedule.Appointments.Add(newappointment);
        }

        private void CalendarEdit_DateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DateTime selectedDate = datePicker.Date;
            if(!sfSchedule.VisibleDates[0].Equals(selectedDate))
            {
                sfSchedule.MoveToDate(selectedDate);
            }
        }

        private void sfSchedule_VisibleDatesChanging(object sender, VisibleDatesChangingEventArgs e)
        {
            DateTime selectedDate = sfSchedule.VisibleDates[0];
            if(!datePicker.Date.Equals(selectedDate))
            {
                datePicker.Date = selectedDate;
            }
        }

        private void CheckBox_Checked_CheckUp(object sender, RoutedEventArgs e)
        {
            foreach (Appointment appointment in DummyData.checkUps)
            {
                this.sfSchedule.Appointments.Add(appointment);
            }
        }

        private void CheckBox_Unchecked_CheckUp(object sender, RoutedEventArgs e)
        {
            foreach (Appointment appointment in DummyData.checkUps)
            {
                this.sfSchedule.Appointments.Remove(appointment);
            }
        }

        private void CheckBox_Checked_Operation(object sender, RoutedEventArgs e)
        {
            foreach (Appointment appointment in DummyData.operations)
            {
                this.sfSchedule.Appointments.Add(appointment);
            }
        }

        private void CheckBox_Unchecked_Operation(object sender, RoutedEventArgs e)
        {
            foreach (Appointment appointment in DummyData.operations)
            {
                this.sfSchedule.Appointments.Remove(appointment);
            }
        }

        private void sfSchedule_AppointmentDeleting(object sender, AppointmentDeletingEventArgs e)
        {
            Appointment appointment = e.Appointment as Appointment;
            if(appointment.AppointmentType == AppointmentTypes.CheckUp)
            {
                DummyData.checkUps.Remove(appointment);
            } else
            {
                DummyData.operations.Remove(appointment);
            }

        }

        private void buttonPDF_Click(object sender, RoutedEventArgs e)
        {
            using (PdfDocument document = new PdfDocument())
            {
                //Adds page settings
                document.PageSettings.Orientation = PdfPageOrientation.Portrait;
                document.PageSettings.Margins.All = 50;
                //Adds a page to the document
                PdfPage page = document.Pages.Add();
                PdfGraphics graphics = page.Graphics;


                RectangleF bounds = new RectangleF(176, 0, 390, 130);
            
                PdfBrush solidBrush = new PdfSolidBrush(new PdfColor(126, 151, 173));
                bounds = new RectangleF(0, bounds.Bottom + 90, graphics.ClientSize.Width, 30);
                //Draws a rectangle to place the heading in that region.
                graphics.DrawRectangle(solidBrush, bounds);
                //Creates a font for adding the heading in the page
                PdfFont subHeadingFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 14);
                //Creates a text element to add the invoice number
                PdfTextElement element = new PdfTextElement("Weekly report", subHeadingFont);
                element.Brush = PdfBrushes.White;
            
                //Draws the heading on the page
                PdfLayoutResult result = element.Draw(page, new PointF(10, bounds.Top + 8));
                var cal = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
                string currentDate = "From " + DateTime.Now.Date.AddDays(-1 * ((int)cal.GetDayOfWeek(DateTime.Now)-1)).ToString("MM/dd/yyyy") + " To " + DateTime.Now.ToString("MM/dd/yyyy");
                //Measures the width of the text to place it in the correct location
                SizeF textSize = subHeadingFont.MeasureString(currentDate);
                PointF textPosition = new PointF(graphics.ClientSize.Width - textSize.Width - 10, result.Bounds.Y);
                //Draws the date by using DrawString method
                graphics.DrawString(currentDate, subHeadingFont, element.Brush, textPosition);
                PdfFont timesRoman = new PdfStandardFont(PdfFontFamily.TimesRoman, 10);

                //Creates the datasource for the table
                DataTable invoiceDetails = DummyData.getAppointmentsAsTable();
                //Creates a PDF grid
                PdfGrid grid = new PdfGrid();
                //Adds the data source
                grid.DataSource = invoiceDetails;
                //Creates the grid cell styles
                PdfGridCellStyle cellStyle = new PdfGridCellStyle();
                cellStyle.Borders.All = PdfPens.White;
                PdfGridRow header = grid.Headers[0];
                //Creates the header style
                PdfGridCellStyle headerStyle = new PdfGridCellStyle();
                headerStyle.Borders.All = new PdfPen(new PdfColor(126, 151, 173));
                headerStyle.BackgroundBrush = new PdfSolidBrush(new PdfColor(126, 151, 173));
                headerStyle.TextBrush = PdfBrushes.White;
                headerStyle.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 14f, PdfFontStyle.Regular);

                //Adds cell customizations
                for (int i = 0; i < header.Cells.Count; i++)
                {
                    header.Cells[i].StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
                }

                //Applies the header style
                header.ApplyStyle(headerStyle);
                cellStyle.Borders.Bottom = new PdfPen(new PdfColor(217, 217, 217), 0.70f);
                cellStyle.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 12f);
                cellStyle.TextBrush = new PdfSolidBrush(new PdfColor(131, 130, 136));
                //Creates the layout format for grid
                PdfGridLayoutFormat layoutFormat = new PdfGridLayoutFormat();
                // Creates layout format settings to allow the table pagination
                layoutFormat.Layout = PdfLayoutType.Paginate;
                //Draws the grid to the PDF page.
                PdfGridLayoutResult gridResult = grid.Draw(page, new RectangleF(new PointF(0, result.Bounds.Bottom + 40), new SizeF(graphics.ClientSize.Width, graphics.ClientSize.Height - 100)), layoutFormat);

                //Saves and closes the document.
                document.Save("WeeklyReport.pdf");
                document.Close(true);

                new MessageBoxCustom("Report for this week has been saved as \"WeeklyReport.pdf\".", MessageType.Success, MessageButtons.Ok).ShowDialog();

            }
        }

        private void demoMode()
        {
            buttonDemo.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(211, 47, 47));
            Appointment checkUp1 = new Appointment();

            var timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(1000) };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                timer.Stop();
                buttonDodaj.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(211, 47, 47));
            };

            var timer1 = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(1500) };
            timer1.Start();
            timer1.Tick += (sender, args) =>
            {
                timer1.Stop();
                this.buttonDodaj.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(25, 118, 210));
                CustomEditor ed = new CustomEditor();
                ed.Show();
                ed.demoMode();
            };

            var timer2 = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(10500) };
            timer2.Start();
            timer2.Tick += (sender, args) =>
            {
                timer2.Stop();
                DateTime currentdate = DateTime.Now.Date;
                checkUp1 = new Appointment()
                {
                    AppointmentImageURI = new BitmapImage(new Uri("pack://application:,,,/SekretarWPF;Component/Assets/CheckUp.png")),
                    AppointmentType = AppointmentTypes.CheckUp,
                    StartTime = currentdate.AddHours(3),
                    AppointmentTime = currentdate.AddHours(3).ToString("hh:mm tt"),
                    EndTime = currentdate.AddHours(5),
                    AppointmentBackground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(211, 47, 47))
                };
                checkUp1.Doctor = "Doctor1";
                checkUp1.Patient = "Patient2";
                checkUp1.Ordination = "Ordination3";
                DummyData.checkUps.Add(checkUp1);
                this.sfSchedule.Appointments.Add(checkUp1);
            };

            var timer3 = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(12000) };
            timer3.Start();
            timer3.Tick += (sender, args) =>
            {
                timer3.Stop();
                buttonDemo.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(25, 118, 210));
                DummyData.checkUps.Remove(checkUp1);
                this.sfSchedule.Appointments.Remove(checkUp1);
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            demoMode();
        }
    }
}
