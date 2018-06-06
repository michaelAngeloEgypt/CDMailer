using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CDMailer.BLL
{
    public static class Engine
    {
        #region PROP
        public static Config Config { get; set; }
        public static ExecutionStatus Status { get; set; }
        public static ExecutionVariables Variables { get; set; }
        #endregion PROP

        #region DLG
        public delegate void EventHandler(String mes);
        public static event EventHandler UpdateStatusEvent;

        public delegate void MarkCompletedEventHandler(string finalMessage);
        public static event MarkCompletedEventHandler MarkCompletedEvent;
        #endregion DLG

        static string contactsFolder = "";
        public enum ExecutionResult
        {
            ErrorOccured,
            Successful,
            PartialPass,
        }
        public class ExecutionStatus
        {
            public static ExecutionResult Result;
            public static string Message = String.Empty;

            public static void Reset()
            {
                Result = ExecutionResult.ErrorOccured;
                Message = String.Empty;
            }
        }

        static Engine()
        {
            Config = new Config();
            Variables = new ExecutionVariables();
            REF.Mapping.GetRefs(Path.Combine(REF.templatesPath, "Mapping.csv"));
        }

        public static void Reset()
        {
            REF.Reset();
            ExecutionStatus.Reset();
            Variables.Reset();
        }
        public static void ReadContacts()
        {
            try
            {
                Variables.Contacts.AddRange(ReadRecords(Config.UI.ContactsFile));
            }
            catch (Exception x)
            {
                if (x is ApplicationException)
                    CallMarkCompleted(x.Message);
                else
                    CallMarkCompleted("Something went wrong in the middle of the process. Please check the logs.txt file.");

                XLogger.Error(x);
            }
        }
        public static void DoTask(Config config)
        {
            try
            {
                contactsFolder = Path.GetDirectoryName(config.UI.ContactsFile);
                Variables.Contacts.AddRange(ReadRecords(config.UI.ContactsFile));
                Engine.ExecutionStatus.Result = GenerateMessages(REF.templatesPath, config.UI.OutputFolder, config.UI.GeneratePerContact, Variables.Contacts);
            }
            catch (Exception x)
            {
                if (x is ApplicationException)
                    CallMarkCompleted(x.Message);
                else
                    CallMarkCompleted("Something went wrong in the middle of the process. Please check the logs.txt file.");

                XLogger.Error(x);
            }
        }
        /// <summary>
        /// <see cref="https://wurstkoffer.wordpress.com/2013/05/18/c-printing-to-word-programmatically-in-3-way/"/>
        /// </summary>
        /// <param name="documents"></param>
        public static void PrintAll(List<string> documents, string printer)
        {
            try
            {
                foreach (var filename in documents)
                {
                    //wait
                    //Print1(filename, printer);
                    Print2(filename);
                    //Print3(filename);
                }
            }
            catch (Exception x)
            {
                if (x is ApplicationException)
                    CallMarkCompleted(x.Message);
                else
                    CallMarkCompleted("Something went wrong while printing. Please check the logs.txt file.");

                XLogger.Error(x);
            }
        }

        private static void Print1(string filename, string printer)
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
        /// shows the dialog of the printer and opens the word document
        /// </summary>
        /// <param name="filename"></param>
        private static void Print2(string filename)
        {
            ProcessStartInfo info2 = new ProcessStartInfo(filename);
            info2.Verb = "Print";
            info2.CreateNoWindow = true;
            info2.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(info2);
        }
        private static void Print3(string filename)
        {
            Microsoft.Office.Interop.Word.Application wordInstance = new Microsoft.Office.Interop.Word.Application();
            //MemoryStream documentStream = getDocStream();
            FileInfo wordFile = new FileInfo(filename);
            object fileObject = wordFile.FullName;
            object oMissing = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Word.Document doc = wordInstance.Documents.Open(ref fileObject, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            doc.Activate();
            doc.PrintOut(oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);
        }

        private static List<Contact> ReadRecords_Manual(string contactsFilepath)
        {
            try
            {
                var res = new List<Contact>();
                var contactsLines = File.ReadAllLines(contactsFilepath);
                foreach (var line in contactsLines.Skip(1))
                {
                    var lineParts = line.Split(',').ToList();
                    Contact contact = null;
                    contact = new Contact(line);
                    res.Add(contact);
                }

                return res;
            }
            catch (Exception x)
            {
                x.Data.Add("contactsFilepath", contactsFilepath);
                throw;
            }
        }
        private static ExecutionResult GenerateMessages(string templatesFolder, string outputFolder, REF.GeneratePerContact generatePerContact, List<Contact> contacts)
        {
            var successfulContacts = new List<String>();
            var failedContacts = new List<String>();

            Contact contact = new Contact();

            for (int i = 0; i < contacts.Count; i++)
            {
                try
                {
                    contact = contacts[i];
                    CallUpdateStatus($"Processing contact {i + 1} of {contacts.Count} contacts");
                    var templateFile = Path.ChangeExtension(Path.Combine(templatesFolder, contact.CDMailerTemplate), ".docx");

                    GenerateContactCore(outputFolder, generatePerContact, contact, templateFile);

                    if (!File.Exists(templateFile))
                        throw new ApplicationException($"Missing template file: {templateFile}");
                    successfulContacts.Add(contact.OppName);
                }
                catch (Exception x)
                {
                    if (!x.Data.Contains("contact.OppName")) x.Data.Add("contact.OppName", contact.OppName);
                    XLogger.Error(x);
                    failedContacts.Add(contact.OppName);
                }
            }

            if (successfulContacts.Count == contacts.Count())
            {
                CallUpdateStatus("Operation passed and filled templates are generated in the Output folder");
                return ExecutionResult.Successful;
            }
            else if (failedContacts.Count == contacts.Count())
            {
                CallUpdateStatus("There was a problem in generating all the contacts files");
                return ExecutionResult.ErrorOccured;
            }
            else
            {
                CallUpdateStatus($"There was a problem generating some of the contact files. Successfully generated {successfulContacts.Count} contact files and failed to generate {failedContacts.Count} files. \nThese are the failed contacts:\n\n{String.Join("\n", failedContacts)}");
                return ExecutionResult.PartialPass;
            }
        }

        private static void GenerateContactCore(string outputFolder, REF.GeneratePerContact generatePerContact, Contact contact, string templateFile)
        {
            switch (generatePerContact)
            {
                case REF.GeneratePerContact.Letter:
                    GenerateFilled(outputFolder, contact, templateFile);
                    break;
                case REF.GeneratePerContact.Envelop:
                    GenerateFilled(outputFolder, contact, REF.envelopFile);
                    break;
                case REF.GeneratePerContact.LetterAndEnvelop:
                    GenerateFilled(outputFolder, contact, templateFile);
                    GenerateFilled(outputFolder, contact, REF.envelopFile);
                    break;
                default:
                    break;
            }
        }

        public static ExecutionResult GenerateContact(string outputFolder, Contact contact, REF.GeneratePerContact generatePerContact, string templateFile)
        {
            try
            {
                GenerateContactCore(outputFolder, generatePerContact, contact, templateFile);
                CallUpdateStatus("Operation passed and filled templates are generated in the Output folder");
                return ExecutionResult.Successful;
            }
            catch (Exception x)
            {
                XLogger.Error(x);
                CallUpdateStatus("There was a problem in generating all the contacts files");
                return ExecutionResult.ErrorOccured;
            }
        }
        private static void GenerateFilled(string outputFolder, Contact contact, string templateFile)
        {
            if (!contact.CDMailerTemplate.Contains("[") && !contact.CDMailerTemplate.Contains("]"))
                throw new ApplicationException("Invalid template column");

            //if (contact.FirstName.Contains("Beth"))
            //    1.ToString();

            var isEnvelop = Path.GetFileName(templateFile).MatchesString(REF.Constants.EnvelopTemplate);
            string filledTemplate = !isEnvelop ? GetFilledTemplate(contact) : GetFilledTemplate(contact, REF.Constants.EnvelopTemplate);

            var envlopContacts = contact.GetAddressContacts();
            for (int i = 0; i < envlopContacts.Count; i++)
            {
                string generatedFilenameEnvelop = $"{filledTemplate} - {i + 1}.docx";
                string generatedFilePathEnvelop = Path.Combine(outputFolder, generatedFilenameEnvelop);
                DocxTemplate.InsertTextInPlaceholders(templateFile, generatedFilePathEnvelop, !isEnvelop ? contact as Object : envlopContacts[i] as Object);
            }
        }
        private static string GetFilledTemplate(Contact contact, string template = null)
        {
            //if (contact.FirstName.StartsWith("Donna"))
            //    1.ToString();

            var filledTemplate = string.IsNullOrEmpty(template) ? contact.CDMailerTemplate : template;
            var reg = new Regex(@"\[.*?\]");
            var matches = reg.Matches(contact.CDMailerTemplate);
            foreach (var requiredVar in matches)
            {
                var mappedVar = contact.GetMappedVar(requiredVar.ToString().Trim(new char[] { '[', ']' }));
                filledTemplate = filledTemplate.Replace(requiredVar.ToString(), mappedVar);
            }

            return filledTemplate;
        }

        private static List<Contact> ReadRecords(string contactsFilepath)
        {
            try
            {
                var res = new List<Contact>();
                if (String.IsNullOrWhiteSpace(contactsFilepath) || !File.Exists(contactsFilepath))
                    throw new ArgumentNullException("contactsFilepath");

                var csvConfig = new Configuration() { Delimiter = ",", HasHeaderRecord = true, IgnoreBlankLines = true, HeaderValidated = null, };
                csvConfig.RegisterClassMap(new ContactMap());
                using (var csv = new CsvReader(new StreamReader(contactsFilepath), csvConfig))
                {
                    var records = csv.GetRecords<Contact>().ToList();
                    res.AddRange(records);
                }

                res.ForEach(r => r.AdjustFields());
                return res;
            }
            catch (IOException io)
            {
                io.Data.Add("contactsFilepath", contactsFilepath);
                var x = new ApplicationException("An error occured while reading the csv file. Please make sure it is not open in Excel.", io);
                throw x;
            }
            catch (Exception x)
            {
                x.Data.Add("contactsFilepath", contactsFilepath);
                throw;
            }
        }

        private static void CallUpdateStatus(string msg)
        {
            UpdateStatusEvent?.Invoke(msg);
        }
        private static void CallMarkCompleted(string msg)
        {
            MarkCompletedEvent?.Invoke(msg);
        }

    }
}
