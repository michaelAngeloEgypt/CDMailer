using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CDMailer.BLL
{
    public static class PrinterUtils
    {
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

        /// <summary>
        /// <see cref="https://www.e-iceblue.com/Tutorials/Spire.Doc/Spire.Doc-Program-Guide/Print-a-Word-Document-Programmatically-in-5-Steps.html"/>
        /// <see cref="https://www.e-iceblue.com/Tutorials/Spire.Doc/Spire.Doc-Program-Guide/Document-Operation/Print-word-document-without-showing-print-processing-dialog.html"/>
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="printer"></param>
        public static void PrintWithSpire(string filename, string printer)
        {
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
            System.Drawing.Printing.PrintController printController = new System.Drawing.Printing.StandardPrintController();
            printDoc.PrintController = printController;
            //Background printing  
            printDoc.Print();
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
        //
        #endregion PAID
    }
}
