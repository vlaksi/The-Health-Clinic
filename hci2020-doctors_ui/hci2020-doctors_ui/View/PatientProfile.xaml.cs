using hci2020_doctors_ui.Model;
using hci2020_doctors_ui.ViewModel;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Lists;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using Color = System.Windows.Media.Color;

namespace hci2020_doctors_ui.View
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class PatientProfile : System.Windows.Controls.UserControl
    {
        public PatientProfile()
        {
            InitializeComponent();
        }

        private void writePrescription_Click(object sender, RoutedEventArgs e)
        {
            (Window.GetWindow(this) as MainWindow).MainFrameContent.Content = new WritePrescription();
            WritePrescriptionViewModel.Instance.Patient = PatientsProfileViewModel.Instance.Patient;
            (Window.GetWindow(this) as MainWindow).DataContext = WritePrescriptionViewModel.Instance;
        }

        private void writeReport_Click(object sender, RoutedEventArgs e)
        {
            (Window.GetWindow(this) as MainWindow).MainFrameContent.Content = new WriteReport();
            WriteReportViewModel.Instance.Patient = PatientsProfileViewModel.Instance.Patient;
            (Window.GetWindow(this) as MainWindow).DataContext = WriteReportViewModel.Instance;
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var btn = sender as System.Windows.Controls.Button;
            btn.Command.Execute(btn.CommandParameter);
            (Window.GetWindow(this) as MainWindow).DataContext = new PDFReportViewModel(PatientsProfileViewModel.Instance.Patient, PatientsProfileViewModel.Instance.AppointmentBinding);
            await Task.Delay(250);
            (Window.GetWindow(this) as MainWindow).MainFrameContent.Content = new PDFReportView();


            // Generate PDF 
            WordDocument wordDocument = new WordDocument();
            wordDocument.EnsureMinimal();
            wordDocument.LastSection.PageSetup.Margins.All = 100;
            wordDocument.LastSection.PageSetup.Margins.Top = 20;

            //Get last paragraph
            IWParagraph paragraph = wordDocument.LastParagraph;

            //Create styles
            WParagraphStyle paragraphStyle = wordDocument.Styles.FindByName("Normal") as WParagraphStyle;
            paragraphStyle.CharacterFormat.Font = new Font("Helvetica", 10);
            //paragraphStyle.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Justify;
            paragraphStyle.ParagraphFormat.AfterSpacing = 6f;
            paragraphStyle = wordDocument.AddParagraphStyle("Heading") as WParagraphStyle;
            paragraphStyle.ApplyBaseStyle("Normal");
            paragraphStyle.CharacterFormat.FontSize = 14f;
            paragraphStyle.CharacterFormat.TextColor = System.Drawing.Color.FromArgb(255, 21, 96, 251);

            //Add text
            WSection section = wordDocument.LastSection;
            section.PageSetup.PageSize = new SizeF(612, 792);

            paragraph = section.AddParagraph();
            paragraph.AppendText((string)System.Windows.Application.Current.Resources["PatientInfoLabel"]);
            paragraph.ApplyStyle("Heading");
            paragraph = section.AddParagraph();
            IWTable patientInfo = section.AddTable();
            paragraph.ParagraphFormat.AfterSpacing = 0;
            paragraph.ParagraphFormat.LineSpacing = 5f;
            patientInfo.ResetCells(1, 1);
            patientInfo.TableFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.None;
            patientInfo.TableFormat.IsAutoResized = true;
            paragraph = patientInfo[0, 0].AddParagraph();
            paragraph.ListFormat.ClearFormatting();
            paragraph.AppendText((string)System.Windows.Application.Current.Resources["FullNameLabel"] + "\t\t\t\t\t" + PatientsProfileViewModel.Instance.Patient.Name);
            paragraph.ListFormat.ContinueListNumbering();

            paragraph.AppendBreak(BreakType.LineBreak);
            paragraph.ListFormat.ClearFormatting();
            paragraph.AppendText((string)System.Windows.Application.Current.Resources["BirthLabel"] + "\t\t\t\t\t" + PatientsProfileViewModel.Instance.Patient.Birth.ToShortDateString());
            paragraph.ListFormat.ContinueListNumbering();
            paragraph.AppendBreak(BreakType.LineBreak);
            paragraph.ListFormat.ClearFormatting();
            paragraph.AppendText((string)System.Windows.Application.Current.Resources["GenderLabel"] + "\t\t\t\t\t" + PatientsProfileViewModel.Instance.Patient.Gender);
            paragraph.ListFormat.ContinueListNumbering();

            paragraph = section.AddParagraph();
            IWTable row2 = section.AddTable();
            paragraph.ParagraphFormat.AfterSpacing = 0;
            paragraph.ParagraphFormat.LineSpacing = 5f;
            row2.ResetCells(2, 2);
            row2.TableFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.None;
            row2.TableFormat.IsAutoResized = true;
            paragraph = row2[0, 0].AddParagraph(); //doctorInCharge
            paragraph.ListFormat.ClearFormatting();
            paragraph.AppendText((string)System.Windows.Application.Current.Resources["DoctorinChargeLabel"]);
            paragraph.ListFormat.ContinueListNumbering();
            paragraph.AppendBreak(BreakType.LineBreak);
            paragraph.ListFormat.ClearFormatting();
            paragraph.AppendText(PatientsProfileViewModel.Instance.AppointmentBinding.Doctor);
            paragraph.ListFormat.ContinueListNumbering();

            paragraph = row2[0, 1].AddParagraph(); //Clinic
            paragraph.ListFormat.ClearFormatting();
            paragraph.AppendText((string)System.Windows.Application.Current.Resources["ClinicInfoLabel"]);
            paragraph.ListFormat.ContinueListNumbering();
            paragraph.AppendBreak(BreakType.LineBreak);
            paragraph.ListFormat.ClearFormatting();
            paragraph.AppendText("Street XY, Novi Sad, The Health Clinic");
            paragraph.ListFormat.ContinueListNumbering();

            IWTable row3 = section.AddTable();
            paragraph.ParagraphFormat.AfterSpacing = 0;
            paragraph.ParagraphFormat.LineSpacing = 12f;
            row3.ResetCells(2, 2);
            row3.TableFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.None;
            row3.TableFormat.IsAutoResized = true;
            paragraph = row3[0, 0].AddParagraph(); //Datetime
            paragraph.ListFormat.ClearFormatting();
            paragraph.AppendText((string)System.Windows.Application.Current.Resources["DateTimeLabel"]);
            paragraph.ListFormat.ContinueListNumbering();
            paragraph.AppendBreak(BreakType.LineBreak);
            paragraph.ListFormat.ClearFormatting();
            paragraph.AppendText(PatientsProfileViewModel.Instance.AppointmentBinding.AppointmentStartTime + " " + PatientsProfileViewModel.Instance.AppointmentBinding.AppointmentDate);
            paragraph.ListFormat.ContinueListNumbering();

            paragraph = row3[0, 1].AddParagraph(); //Purpose
            paragraph.ListFormat.ClearFormatting();
            paragraph.AppendText((string)System.Windows.Application.Current.Resources["PurposeLabel"]);
            paragraph.ListFormat.ContinueListNumbering();
            paragraph.AppendBreak(BreakType.LineBreak);
            paragraph.ListFormat.ClearFormatting();
            paragraph.AppendText(PatientsProfileViewModel.Instance.AppointmentBinding.SpecialtyType + " " + PatientsProfileViewModel.Instance.AppointmentBinding.AppointmentType);
            paragraph.ListFormat.ContinueListNumbering();

            paragraph = section.AddParagraph();

            // SECTION: Patients Report
            paragraph.AppendText((string)System.Windows.Application.Current.Resources["PatientsRemarksLabel"]);
            paragraph.ApplyStyle("Heading");
            paragraph = section.AddParagraph();
            paragraph.AppendText(PatientsProfileViewModel.Instance.AppointmentBinding.Report.PatientsReport);
            paragraph = section.AddParagraph();

            IWTable table = section.AddTable();
            table.ResetCells(2, 2);
            table.TableFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.None;
            table.TableFormat.IsAutoResized = true;
            paragraph = table[0, 0].AddParagraph(); //naslov
                                                    // SECTION: Conditions
            paragraph.AppendText((string)System.Windows.Application.Current.Resources["ObservationsLabel"]);
            paragraph.ApplyStyle("Heading");
            paragraph = table[1, 0].AddParagraph(); //labele
            paragraph.ListFormat.ClearFormatting();
            paragraph.AppendText((string)System.Windows.Application.Current.Resources["AirwayLabel"] + "\t\t\t" + PatientsProfileViewModel.Instance.AppointmentBinding.Report.Observations[0]);
            paragraph.ListFormat.ContinueListNumbering();

            paragraph = table[1, 0].AddParagraph();
            paragraph.AppendText((string)System.Windows.Application.Current.Resources["BreathingLabel"] + "\t\t" + PatientsProfileViewModel.Instance.AppointmentBinding.Report.Observations[1]);
            paragraph.ListFormat.ContinueListNumbering();

            paragraph = table[1, 0].AddParagraph();
            paragraph.AppendText((string)System.Windows.Application.Current.Resources["BloodPressureLabel"] + "\t\t" + PatientsProfileViewModel.Instance.AppointmentBinding.Report.Observations[2]);
            paragraph.ListFormat.ContinueListNumbering();

            paragraph = table[1, 0].AddParagraph();
            paragraph.AppendText((string)System.Windows.Application.Current.Resources["TemperatureLabel"] + "\t\t" + PatientsProfileViewModel.Instance.AppointmentBinding.Report.Observations[4]);
            paragraph.ListFormat.ContinueListNumbering();

            paragraph = table[1, 0].AddParagraph();
            paragraph.AppendText((string)System.Windows.Application.Current.Resources["HeartRateLabel"] + "\t\t" + PatientsProfileViewModel.Instance.AppointmentBinding.Report.Observations[3]);
            paragraph.ListFormat.ContinueListNumbering();

            paragraph = table[1, 0].AddParagraph();
            paragraph.AppendText((string)System.Windows.Application.Current.Resources["PupilsLabel"] + "\t\t\t" + PatientsProfileViewModel.Instance.AppointmentBinding.Report.Observations[5]);
            paragraph.ListFormat.ContinueListNumbering();


            // SECTION: Conditions
            paragraph = table[0, 1].AddParagraph(); //naslov
            paragraph.AppendText((string)System.Windows.Application.Current.Resources["CommonConditionsLabel"]);
            paragraph.ApplyStyle("Heading");

            paragraph = table[1, 1].AddParagraph(); //commonConditions
            paragraph.ApplyStyle("Normal");
            paragraph.ListFormat.ClearFormatting();


            foreach (string cond in PatientsProfileViewModel.Instance.AppointmentBinding.Report.CommonConditions)
            {
                paragraph.AppendText(cond);
                paragraph.ApplyStyle("Normal");
                paragraph.ListFormat.ContinueListNumbering();
                paragraph = table[1, 1].AddParagraph();
            }

            paragraph = section.AddParagraph();
            paragraph = section.AddParagraph();
            // SECTION: Doctors Remark
            paragraph.AppendText((string)System.Windows.Application.Current.Resources["DoctorsRemarksLabel"]);
            paragraph.ApplyStyle("Heading");
            paragraph = section.AddParagraph();
            paragraph.AppendText(PatientsProfileViewModel.Instance.AppointmentBinding.Report.DoctorsRemark);

            //Convert Word document to PDF
            DocToPDFConverter converter = new DocToPDFConverter();
            PdfDocument document = converter.ConvertToPDF(wordDocument);

            //Save PDF
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Files(.*pdf)|*.pdf";
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = ".pdf";
            //DialogResult.OK
            if ((saveFileDialog.ShowDialog() == DialogResult.OK) && saveFileDialog.CheckPathExists)
            {
                document.Save(saveFileDialog.FileName);
                document.Close(true);
                if (System.Windows.Forms.MessageBox.Show((string)System.Windows.Application.Current.Resources["PreviewPDF"], (string)System.Windows.Application.Current.Resources["PreviewPDFMessage"], MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Process proc = new Process();
                    proc.StartInfo.FileName = saveFileDialog.FileName;
                    proc.Start();
                }
            }
        }

        private async void GenerateStatusReport_Click(object sender, RoutedEventArgs e)
        {
            if (DateTime.Compare(PatientsProfileViewModel.Instance.StartDate, PatientsProfileViewModel.Instance.EndDate) > 0)
            {
                System.Windows.Forms.MessageBox.Show((string)System.Windows.Application.Current.Resources["DatesInvalid"], (string)System.Windows.Application.Current.Resources["DatesInvalidMessage"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            await Task.Delay(1000);

            if (PatientsProfileViewModel.Instance.AppointmentsInSelectedPeriod.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show((string)System.Windows.Application.Current.Resources["NoTerms"], (string)System.Windows.Application.Current.Resources["NoTermsMessage"], MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            await Task.Delay(500);

            // Generate PDF 
            WordDocument wordDocument = new WordDocument();
            wordDocument.EnsureMinimal();
            wordDocument.LastSection.PageSetup.Margins.All = 100;
            wordDocument.LastSection.PageSetup.Margins.Top = 20;

            //Get last paragraph
            IWParagraph paragraph = wordDocument.LastParagraph;

            //Create styles
            WParagraphStyle paragraphStyle = wordDocument.Styles.FindByName("Normal") as WParagraphStyle;
            paragraphStyle.CharacterFormat.Font = new Font("Helvetica", 10);
            //paragraphStyle.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Justify;
            paragraphStyle.ParagraphFormat.AfterSpacing = 6f;
            paragraphStyle = wordDocument.AddParagraphStyle("Heading") as WParagraphStyle;
            paragraphStyle.ApplyBaseStyle("Normal");
            paragraphStyle.CharacterFormat.FontSize = 14f;
            paragraphStyle.CharacterFormat.TextColor = System.Drawing.Color.FromArgb(255, 21, 96, 251);

            
            for (int i = 0; i < PatientsProfileViewModel.Instance.AppointmentsInSelectedPeriod.Count; i++)
            {

                Appointment currentApp = PatientsProfileViewModel.Instance.AppointmentsInSelectedPeriod[i];

                if (i != 0)
                {
                    paragraph.AppendBreak(BreakType.PageBreak);
                }


                //Add text
                WSection section = wordDocument.LastSection;
                section.PageSetup.PageSize = new SizeF(612, 792);

                paragraph = section.AddParagraph();
                paragraph.AppendText((string)System.Windows.Application.Current.Resources["PatientInfoLabel"]);
                paragraph.ApplyStyle("Heading");
                paragraph = section.AddParagraph();
                IWTable patientInfo = section.AddTable();
                paragraph.ParagraphFormat.AfterSpacing = 0;
                paragraph.ParagraphFormat.LineSpacing = 5f;
                patientInfo.ResetCells(1, 1);
                patientInfo.TableFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.None;
                patientInfo.TableFormat.IsAutoResized = true;
                paragraph = patientInfo[0, 0].AddParagraph();
                paragraph.ListFormat.ClearFormatting();
                paragraph.AppendText((string)System.Windows.Application.Current.Resources["FullNameLabel"] + "\t\t\t\t\t" + PatientsProfileViewModel.Instance.Patient.Name);
                paragraph.ListFormat.ContinueListNumbering();
                
                paragraph.AppendBreak(BreakType.LineBreak);
                paragraph.ListFormat.ClearFormatting();
                paragraph.AppendText((string)System.Windows.Application.Current.Resources["BirthLabel"] + "\t\t\t\t\t" + PatientsProfileViewModel.Instance.Patient.Birth.ToShortDateString());
                paragraph.ListFormat.ContinueListNumbering();
                paragraph.AppendBreak(BreakType.LineBreak);
                paragraph.ListFormat.ClearFormatting();
                paragraph.AppendText((string)System.Windows.Application.Current.Resources["GenderLabel"] + "\t\t\t\t\t" + PatientsProfileViewModel.Instance.Patient.Gender);
                paragraph.ListFormat.ContinueListNumbering();
                
                paragraph = section.AddParagraph();
                IWTable row2 = section.AddTable();
                paragraph.ParagraphFormat.AfterSpacing = 0;
                paragraph.ParagraphFormat.LineSpacing = 5f;
                row2.ResetCells(2, 2);
                row2.TableFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.None;
                row2.TableFormat.IsAutoResized = true;
                paragraph = row2[0, 0].AddParagraph(); //doctorInCharge
                paragraph.ListFormat.ClearFormatting();
                paragraph.AppendText((string)System.Windows.Application.Current.Resources["DoctorinChargeLabel"]);
                paragraph.ListFormat.ContinueListNumbering();
                paragraph.AppendBreak(BreakType.LineBreak);
                paragraph.ListFormat.ClearFormatting();
                paragraph.AppendText(currentApp.Doctor);
                paragraph.ListFormat.ContinueListNumbering();

                paragraph = row2[0, 1].AddParagraph(); //Clinic
                paragraph.ListFormat.ClearFormatting();
                paragraph.AppendText((string)System.Windows.Application.Current.Resources["ClinicInfoLabel"]);
                paragraph.ListFormat.ContinueListNumbering();
                paragraph.AppendBreak(BreakType.LineBreak);
                paragraph.ListFormat.ClearFormatting();
                paragraph.AppendText("Street XY, Novi Sad, The Health Clinic");
                paragraph.ListFormat.ContinueListNumbering();

                IWTable row3 = section.AddTable();
                paragraph.ParagraphFormat.AfterSpacing = 0;
                paragraph.ParagraphFormat.LineSpacing = 12f;
                row3.ResetCells(2, 2);
                row3.TableFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.None;
                row3.TableFormat.IsAutoResized = true;
                paragraph = row3[0, 0].AddParagraph(); //Datetime
                paragraph.ListFormat.ClearFormatting();
                paragraph.AppendText((string)System.Windows.Application.Current.Resources["DateTimeLabel"]);
                paragraph.ListFormat.ContinueListNumbering();
                paragraph.AppendBreak(BreakType.LineBreak);
                paragraph.ListFormat.ClearFormatting();
                paragraph.AppendText(currentApp.AppointmentStartTime + " " + currentApp.AppointmentDate);
                paragraph.ListFormat.ContinueListNumbering();

                paragraph = row3[0, 1].AddParagraph(); //Purpose
                paragraph.ListFormat.ClearFormatting();
                paragraph.AppendText((string)System.Windows.Application.Current.Resources["PurposeLabel"]);
                paragraph.ListFormat.ContinueListNumbering();
                paragraph.AppendBreak(BreakType.LineBreak);
                paragraph.ListFormat.ClearFormatting();
                paragraph.AppendText(currentApp.SpecialtyType + " " + currentApp.AppointmentType);
                paragraph.ListFormat.ContinueListNumbering();

                paragraph = section.AddParagraph();

                // SECTION: Patients Report
                paragraph.AppendText((string)System.Windows.Application.Current.Resources["PatientsRemarksLabel"]);
                paragraph.ApplyStyle("Heading");
                paragraph = section.AddParagraph();
                paragraph.AppendText(currentApp.Report.PatientsReport);
                paragraph = section.AddParagraph();

                IWTable table = section.AddTable();
                table.ResetCells(2, 2);
                table.TableFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.None;
                table.TableFormat.IsAutoResized = true;
                paragraph = table[0, 0].AddParagraph(); //naslov
                                                        // SECTION: Conditions
                paragraph.AppendText((string)System.Windows.Application.Current.Resources["ObservationsLabel"]);
                paragraph.ApplyStyle("Heading");
                paragraph = table[1, 0].AddParagraph(); //labele
                paragraph.ListFormat.ClearFormatting();
                paragraph.AppendText((string)System.Windows.Application.Current.Resources["AirwayLabel"] + "\t\t\t" + currentApp.Report.Observations[0]);
                paragraph.ListFormat.ContinueListNumbering();

                paragraph = table[1, 0].AddParagraph();
                paragraph.AppendText((string)System.Windows.Application.Current.Resources["BreathingLabel"] + "\t\t" + currentApp.Report.Observations[1]);
                paragraph.ListFormat.ContinueListNumbering();

                paragraph = table[1, 0].AddParagraph();
                paragraph.AppendText((string)System.Windows.Application.Current.Resources["BloodPressureLabel"] + "\t\t" + currentApp.Report.Observations[2]);
                paragraph.ListFormat.ContinueListNumbering();

                paragraph = table[1, 0].AddParagraph();
                paragraph.AppendText((string)System.Windows.Application.Current.Resources["TemperatureLabel"] + "\t\t" + currentApp.Report.Observations[4]);
                paragraph.ListFormat.ContinueListNumbering();

                paragraph = table[1, 0].AddParagraph();
                paragraph.AppendText((string)System.Windows.Application.Current.Resources["HeartRateLabel"] + "\t\t" + currentApp.Report.Observations[3]);
                paragraph.ListFormat.ContinueListNumbering();

                paragraph = table[1, 0].AddParagraph();
                paragraph.AppendText((string)System.Windows.Application.Current.Resources["PupilsLabel"] + "\t\t\t" + currentApp.Report.Observations[5]);
                paragraph.ListFormat.ContinueListNumbering();


                // SECTION: Conditions
                paragraph = table[0, 1].AddParagraph(); //naslov
                paragraph.AppendText((string)System.Windows.Application.Current.Resources["CommonConditionsLabel"]);
                paragraph.ApplyStyle("Heading");

                paragraph = table[1, 1].AddParagraph(); //commonConditions
                paragraph.ApplyStyle("Normal");
                paragraph.ListFormat.ClearFormatting();
                foreach (string cond in currentApp.Report.CommonConditions)
                {
                    paragraph.AppendText(cond);
                    paragraph.ApplyStyle("Normal");
                    paragraph.ListFormat.ContinueListNumbering();
                    paragraph = table[1, 1].AddParagraph();
                }
                
                paragraph = section.AddParagraph();
                paragraph = section.AddParagraph();
                // SECTION: Doctors Remark
                paragraph.AppendText((string)System.Windows.Application.Current.Resources["DoctorsRemarksLabel"]);
                paragraph.ApplyStyle("Heading");
                paragraph = section.AddParagraph();
                paragraph.AppendText(currentApp.Report.DoctorsRemark);
            }

            //Convert Word document to PDF
            DocToPDFConverter converter = new DocToPDFConverter();
            PdfDocument document = converter.ConvertToPDF(wordDocument);

            //Save PDF
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Files(.*pdf)|*.pdf";
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = ".pdf";
            //DialogResult.OK
            if ((saveFileDialog.ShowDialog() == DialogResult.OK) && saveFileDialog.CheckPathExists)
            {
                document.Save(saveFileDialog.FileName);
                document.Close(true);
                if (System.Windows.Forms.MessageBox.Show((string)System.Windows.Application.Current.Resources["PreviewPDF"], (string)System.Windows.Application.Current.Resources["PreviewPDFMessage"], MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Process proc = new Process();
                    proc.StartInfo.FileName = saveFileDialog.FileName;
                    proc.Start();
                }
            }
            //Reset
            //PatientsProfileViewModel.Instance.AppointmentsInSelectedPeriod = new System.Collections.ObjectModel.ObservableCollection<Appointment>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (Window.GetWindow(this) as MainWindow).MainFrameContent.Content = new AccommodatePatientView();
            (Window.GetWindow(this) as MainWindow).DataContext = new AccommodatePatientViewModel(PatientsProfileViewModel.Instance.Patient);
        }
    }
}
