﻿using CsvHelper;
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
            Variables.Reset();
        }
        public static void DoTask(Config config)
        {
            try
            {
                var templatesPath = Path.Combine(Environment.CurrentDirectory, "templates");
                contactsFolder = Path.GetDirectoryName(config.UI.ContactsFile);
                Variables.Contacts.AddRange(ReadRecords(config.UI.ContactsFile));
                Engine.ExecutionStatus.Result = GenerateMessages(templatesPath, config.UI.OutputFolder, config.UI.GeneratePerContact, Variables.Contacts);
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
        private static ExecutionResult GenerateMessages(string templatesFolder, string outputFolder, Lookups.GeneratePerContact generatePerContact, List<Contact> contacts)
        {
            var successfulContacts = new List<String>();
            var failedContacts = new List<String>();

            Contact contact = new Contact();
            var envelopFile = Path.Combine(templatesFolder, "[OppName] Envelop.docx");
            if (!File.Exists(envelopFile))
                throw new ApplicationException($"Missing envelop template file: {envelopFile}");

            for (int i = 0; i < contacts.Count; i++)
            {
                try
                {
                    contact = contacts[i];
                    CallUpdateStatus($"Processing contact {i + 1} of {contacts.Count} contacts");
                    var templateFile = Path.ChangeExtension(Path.Combine(templatesFolder, contact.Template), ".docx");

                    switch (generatePerContact)
                    {
                        case Lookups.GeneratePerContact.Letter:
                            GenerateFilled(outputFolder, contact, templateFile);
                            break;
                        case Lookups.GeneratePerContact.Envelop:
                            GenerateFilled(outputFolder, contact, envelopFile);
                            break;
                        case Lookups.GeneratePerContact.LetterAndEnvelop:
                            GenerateFilled(outputFolder, contact, templateFile);
                            GenerateFilled(outputFolder, contact, envelopFile);
                            break;
                        default:
                            break;
                    }

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

        private static void GenerateFilled(string outputFolder, Contact contact, string templateFile)
        {
            var requiredVar =
            contact.Template.Split(new string[] { "[", "]" }, StringSplitOptions.None)[1]
.Split('-')[0]
.Trim();
            var mappedVar = contact.GetMappedVar(requiredVar);
            string generatedFilename = Path.GetFileName(templateFile.Replace($"[{requiredVar}]", mappedVar));
            string generatedFilePath = Path.Combine(outputFolder, generatedFilename);
            //File.Copy(templateFile, generatedFilePath);
            DocxTemplate.InsertTextInPlaceholders(templateFile, generatedFilePath, contact);
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

                res.ForEach(r => r.TrimFields());
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
