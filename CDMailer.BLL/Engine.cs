using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
        }

        public static void Reset()
        {
            Lookups.Reset();
            ExecutionStatus.Reset();
        }
        public static void DoTask(Config config)
        {
            try
            {
                var templatesPath = Path.Combine(Environment.CurrentDirectory, "templates");
                contactsFolder = Path.GetDirectoryName(config.UI.ContactsFile);
                Variables.Contacts.AddRange(ReadRecords(config.UI.ContactsFile));
                Engine.ExecutionStatus.Result = GenerateMessages(templatesPath, config.UI.OutputFolder, Variables.Contacts);
            }
            catch
            { throw; }
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
        private static ExecutionResult GenerateMessages(string templatesFolder, string outputFolder, List<Contact> contacts)
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
                    var templateFile = Path.ChangeExtension(Path.Combine(templatesFolder, contact.Template), ".docx");
                    if (!File.Exists(templateFile))
                    {
                        XLogger.Info($"Missing template file: {templateFile}");
                        continue;
                    }
                    var requiredVar =
                    contact.Template.Split(new string[] { "[", "]" }, StringSplitOptions.None)[1]
      .Split('-')[0]
      .Trim();
                    var mappedVar = contact.GetMappedVar(requiredVar);
                    string generatedFilename = string.Concat(contact.Template.Replace($"[{requiredVar}]", mappedVar), ".docx");
                    string generatedFilePath = Path.Combine(outputFolder, generatedFilename);
                    //File.Copy(templateFile, generatedFilePath);
                    DocxTemplate.InsertTextInPlaceholders(templateFile, generatedFilePath, contact);
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
                CallUpdateStatus($"There was a problem generating some of the contact files. Successfully generated {successfulContacts.Count} contact files and failed to generate {failedContacts.Count} files. \nThese are the failed contacts:\n{String.Join("\n", failedContacts)}");
                return ExecutionResult.PartialPass;
            }
        }

        private static List<Contact> ReadRecords(string contactsFilepath)
        {
            try
            {
                var res = new List<Contact>();
                if (String.IsNullOrWhiteSpace(contactsFilepath) || !File.Exists(contactsFilepath))
                    throw new ArgumentNullException("contactsFilepath");

                var csvConfig = new Configuration() { Delimiter = ",", HasHeaderRecord = true, IgnoreBlankLines = true };
                csvConfig.RegisterClassMap(new ContactMap());
                using (var csv = new CsvReader(new StreamReader(contactsFilepath), csvConfig))
                {
                    var records = csv.GetRecords<Contact>().ToList();
                    res.AddRange(records);
                }

                return res;
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
