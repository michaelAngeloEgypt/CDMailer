using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CDMailer.BLL
{
    public static class PrinterUtils
    {
        #region REF
        /// <summary>
        /// <see cref="https://stackoverflow.com/questions/23751578/printing-envelopes-from-c-sharp"/>
        /// </summary>
        public static Dictionary<String, PaperSize> PaperSizes = new Dictionary<string, PaperSize>()
            {
                //default is A5 for envelops

                    { "A3",
                    new PaperSize("A3", 1170, 1650)},
                    {"A4",
                    new PaperSize("A4", 830, 1170)},
                    {"A5",
                    new PaperSize("A5", 580, 830)},
                    {"A6",
                    new PaperSize("A6", 410, 580)},
                    {"A7",
                    new PaperSize("A7", 290, 410)},
                    {"A8",
                    new PaperSize("A8", 200, 290)},
                    {"A9",
                    new PaperSize("A9", 150, 200)},
                    {"A10",
                    new PaperSize("A10", 100, 150)},
                    {"B3",
                    new PaperSize("B3", 1390, 1970)},
                    {"B4",
                    new PaperSize("B4", 980, 1390)},
                    {"B5",
                    new PaperSize("B5", 690, 980)},
                    {"B6",
                    new PaperSize("B6", 490, 690)},
                    {"B7",
                    new PaperSize("B7", 350, 490)},
                    {"B8",
                    new PaperSize("B8", 240, 350)},
                    {"B9",
                    new PaperSize("B9", 170, 240)},
                    {"B10",
                    new PaperSize("B10", 120, 170)},
                    {"C3",
                    new PaperSize("C3", 1280, 1800)},
                    {"C4",
                    new PaperSize("C4", 900, 1280)},
                    {"C5",
                    new PaperSize("C5", 640, 900)},
                    {"C6",
                    new PaperSize("C6", 450, 640)},
                    {"C7",
                    new PaperSize("C7", 320, 450)},
                    {"C8",
                    new PaperSize("C8", 220, 320)},
                    {"C9",
                    new PaperSize("C9", 160, 220)},
                    {"C10",
                    new PaperSize("C10", 110, 160)},
                    {"DL",
                    new PaperSize("C10", 430, 860)},
                    {"CUSTOM",
                    new PaperSize("CUSTOM", 0, 0)},
            };
        #endregion REF

        #region FREE
        //
        /// <summary>
        /// shows the dialog of the printer and opens the word document
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="printer"></param>
        public static void PrintWithDialog(string filename, string printer)
        {
            using (PrintDialog printDialog1 = new PrintDialog())
            {
                printDialog1.PrinterSettings.PrinterName = printer;
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo(filename);
                    //info.Arguments = “\”” + printDialog1.PrinterSettings.PrinterName + “\””;
                    info.Arguments = "\"" + printer + "\"";
                    info.CreateNoWindow = true;
                    info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    info.UseShellExecute = true;
                    info.Verb = "PrintTo";
                    System.Diagnostics.Process.Start(info);
                }
            }
        }
        /// <summary>
        /// opens the word document but doesn't show the dialog
        /// </summary>
        /// <param name="filename"></param>
        public static void PrintWithNoDialog(string filename, string printer)
        {
            ProcessStartInfo info = new ProcessStartInfo(filename);
            info.Verb = "PrintTo";
            info.Arguments = "\"" + printer + "\"";
            info.CreateNoWindow = true;
            info.UseShellExecute = true;
            info.WindowStyle = ProcessWindowStyle.Hidden;
            var process = Process.Start(info);
            if (process != null && process.HasExited != true)
                process.WaitForExit();
            else
                return;
        }
        /// <summary>
        /// </summary>
        /// <param name="filename"></param>
        public static void PrintWithInterop1(string filename)
        {
            /// <see cref="https://docs.microsoft.com/en-us/visualstudio/vsto/how-to-programmatically-print-documents"/>
            //--> this is for Word plugin

            Microsoft.Office.Interop.Word.Application wordInstance = new Microsoft.Office.Interop.Word.Application();
            //MemoryStream documentStream = getDocStream();
            System.IO.FileInfo wordFile = new FileInfo(filename);
            object fileObject = wordFile.FullName;
            object oMissing = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Word.Document doc = wordInstance.Documents.OpenNoRepairDialog(ref fileObject, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            //doc.Activate();
            doc.PrintOut(oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);
        }
        /// <summary>
        /// <see cref="https://stackoverflow.com/questions/878302/printing-using-word-interop-with-print-dialog"/>
        /// </summary>
        /// <param name="filename"></param>
        public static void PrintWithInterop2(string filename, string printer)
        {
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            wordApp.Visible = false;

            //PrintDialog pDialog = new PrintDialog();
            //if (pDialog.ShowDialog() == DialogResult.OK)
            //{
            //    Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Add(filename);
            //    wordApp.ActivePrinter = printer; //pDialog.PrinterSettings.PrinterName;
            //    wordApp.ActiveDocument.PrintOut(); //this will also work: doc.PrintOut();
            //    doc.Close(SaveChanges: false);
            //    doc = null;
            //}

            Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Add(filename);
            wordApp.ActivePrinter = printer; //pDialog.PrinterSettings.PrinterName;
            wordApp.ActiveDocument.PrintOut(); //this will also work: doc.PrintOut();
                                               //doc.Close(SaveChanges: false);
            doc = null;

            // <EDIT to include Jason's suggestion>
            ((Microsoft.Office.Interop.Word._Application)wordApp).Quit(SaveChanges: false);
            // </EDIT>

            // Original: wordApp.Quit(SaveChanges: false);
            wordApp = null;
        }
        //
        #endregion FREE

        #region PAID
        //
        /// <summary>
        /// <see cref=""/>
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="printer"></param>
        public static void PrintWithAspose(string filename, string printer)
        {
            var doc = new Aspose.Words.Document(filename);
            doc.Print(printer);
        }

        /// <summary>
        /// <see cref="https://www.gnostice.com/nl_article.asp?id=296&t=Print_select_pages_of_DOCX"/>
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="printer"></param>
        public static void PrintWithGnostice(string filename, string printer)
        {
            Gnostice.Documents.Controls.WinForms.DocumentPrinter dp = new Gnostice.Documents.Controls.WinForms.DocumentPrinter();
            dp.PrintDocument.PrinterSettings.PrinterName = printer;
            dp.LoadDocument(filename);
            dp.Print();
            dp.CloseDocument();
        }
        /// <summary>
        /// <see cref="https://www.e-iceblue.com/Tutorials/Spire.Doc/Spire.Doc-Program-Guide/Print-a-Word-Document-Programmatically-in-5-Steps.html"/>
        /// <see cref="https://www.e-iceblue.com/Tutorials/Spire.Doc/Spire.Doc-Program-Guide/Document-Operation/Print-word-document-without-showing-print-processing-dialog.html"/>
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="printer"></param>
        public static void PrintWithSpire(string filename, string printer, bool isEnvelop = false, PaperSize paperSize = null, Margins margins = null)
        {
            if (paperSize == null)
                paperSize = PaperSizes["A4"];

            Spire.Doc.Document doc = new Spire.Doc.Document();
            //Load word document 
            doc.LoadFromFile(filename);
            // Instantiated System.Windows.Forms.PrintDialog object .
            //PrintDialog dialog = new PrintDialog();
            //dialog.AllowPrintToFile = true;
            //dialog.AllowCurrentPage = true;
            //dialog.AllowSomePages = true;
            //dialog.UseEXDialog = true;
            //// associate System.Windows.Forms.PrintDialog object with Spire.Doc.Document  
            //doc.PrintDialog = dialog;
            System.Drawing.Printing.PrintDocument printDoc = doc.PrintDocument;
            doc.PrintDocument.PrinterSettings.PrinterName = printer;
            if (doc.PrintDocument.PrinterSettings.CanDuplex)
                doc.PrintDocument.PrinterSettings.Duplex = Duplex.Vertical;
            System.Drawing.Printing.PrintController printController = new System.Drawing.Printing.StandardPrintController();
            printDoc.PrintController = printController;
            printDoc.PrinterSettings.DefaultPageSettings.PaperSize = paperSize;
            if (isEnvelop)
            {
                printDoc.PrinterSettings.DefaultPageSettings.Landscape = true;
                if (margins != null)
                    printDoc.PrinterSettings.DefaultPageSettings.Margins = margins;
            }

            //Background printing  
            printDoc.Print();
        }
        //
        #endregion PAID
    }
}
