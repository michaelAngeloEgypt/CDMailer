﻿using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

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
                Variables.Contacts.Clear();
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
        public static ExecutionResult DoCustom(string outputFolder, List<Contact> contacts, REF.Scope generatePerContact, string templateFile)
        {
            var successfulContacts = new List<Contact>();
            var failedContacts = new List<Contact>();

            Contact contact = new Contact();

            for (int i = 0; i < contacts.Count; i++)
            {
                try
                {
                    contact = contacts[i];
                    CallUpdateStatus($"Processing contact {i + 1} of {contacts.Count} contacts");

                    GenerateContactCore(outputFolder, generatePerContact, contact, templateFile);

                    if (!File.Exists(templateFile))
                        throw new ApplicationException($"Missing template file: {templateFile}");
                    successfulContacts.Add(contact);
                }
                catch (Exception x)
                {
                    if (!x.Data.Contains("outputFolder")) x.Data.Add("outputFolder", outputFolder);
                    if (!x.Data.Contains("generatePerContact")) x.Data.Add("generatePerContact", generatePerContact);
                    if (!x.Data.Contains("templateFile")) x.Data.Add("templateFile", templateFile);
                    if (!x.Data.Contains("contact.OppName")) x.Data.Add("contact.OppName", contact.OppName);
                    XLogger.Error(x);
                    failedContacts.Add(contact);
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
                CallUpdateStatus($"There was a problem generating some of the contact files. Successfully generated {successfulContacts.Count} contact files and failed to generate {failedContacts.Count} files. \nBelow are the failed contacts:\n\n{String.Join("\n", failedContacts)}");
                return ExecutionResult.PartialPass;
            }
        }
        /// <summary>
        /// <see cref="https://wurstkoffer.wordpress.com/2013/05/18/c-printing-to-word-programmatically-in-3-way/"/>
        /// </summary>
        /// <param name="documents"></param>
        public static void PrintAll(List<string> documents)
        {
            try
            {
                var paperSize = PrinterUtils.PaperSizes["A4"];
                var filename = string.Empty;
                for (int i = 0; i < documents.Count; i++)
                {
                    filename = documents[i];
                    CallUpdateStatus($"Sending document {i + 1} of {documents.Count} to the printer");

                    bool isLandscape = false;
                    Margins margins = null;
                    var isEnvelop = REF.Constants.envelopIDs.Any(t => filename.ContainsString(t));
                    var isPostcard = REF.Constants.postcardIDs.Any(t => filename.ContainsString(t));

                    if (isEnvelop)
                    {
                        paperSize = !Config.UI.EnvelopSize.Equals("CUSTOM") ? PrinterUtils.PaperSizes[Config.UI.EnvelopSize] :
                          new System.Drawing.Printing.PaperSize("CUSTOM", Config.UI.EnvelopWidth, Config.UI.EnvelopHeight);
                        margins = new Margins(Config.UI.EnvelopMarginLeft, Config.UI.EnvelopMarginRight, Config.UI.EnvelopMarginTop, Config.UI.EnvelopMarginBottom);
                    }
                    /*
                    else if (isPostcard)
                    {
                        paperSize = !Config.UI.PostcardSize.Equals("CUSTOM") ? PrinterUtils.PaperSizes[Config.UI.EnvelopSize] :
                           new System.Drawing.Printing.PaperSize("CUSTOM", Config.UI.EnvelopWidth, Config.UI.EnvelopHeight);
                        margins = new Margins(Config.UI.PostcardMarginLeft, Config.UI.PostcardMarginRight, Config.UI.PostcardMarginTop, Config.UI.PostcardMarginBottom);
                        isLandscape = true;
                    }
                    */

                    switch (Config.UI.PrintMethod)
                    {
                        case REF.PrintMethod.PrintWithNoDialog:
                            PrinterUtils.PrintWithNoDialog(filename, Config.UI.Printer);
                            break;
                        case REF.PrintMethod.PrintWithInterop:
                            PrinterUtils.PrintWithInterop2(filename, Config.UI.Printer);
                            break;
                        case REF.PrintMethod.PrintWithAspose:
                            PrinterUtils.PrintWithAspose(filename, Config.UI.Printer);
                            break;
                        case REF.PrintMethod.PrintWithGnostice:
                            PrinterUtils.PrintWithGnostice(filename, Config.UI.Printer);
                            break;
                        case REF.PrintMethod.PrintWithSpire:
                            PrinterUtils.PrintWithSpire(filename, Config.UI.Printer, isLandscape, paperSize, margins);
                            break;
                        default:
                            break;
                    }

                    Thread.Sleep(Config.UI.PrintBuffer * 1000);
                }

                CallUpdateStatus("Operation passed and all documents have been sent to the printer");
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
        private static ExecutionResult GenerateMessages(string templatesFolder, string outputFolder, REF.Scope generatePerContact, List<Contact> contacts)
        {
            var successfulContacts = new List<Contact>();
            var failedContacts = new List<Contact>();

            Contact contact = new Contact();

            var templateFile = "";
            for (int i = 0; i < contacts.Count; i++)
            {
                try
                {
                    templateFile = "";
                    contact = contacts[i];
                    CallUpdateStatus($"Processing contact {i + 1} of {contacts.Count} contacts");
                    if (!string.IsNullOrEmpty(contact.CDMailerTemplate))
                        templateFile = Path.ChangeExtension(Path.Combine(templatesFolder, contact.CDMailerTemplate), ".docx");

                    GenerateContactCore(outputFolder, generatePerContact, contact, templateFile);

                    if (!File.Exists(templateFile))
                        throw new ApplicationException($"Missing template file: {templateFile}");
                    successfulContacts.Add(contact);
                }
                catch (Exception x)
                {
                    if (!x.Data.Contains("outputFolder")) x.Data.Add("outputFolder", outputFolder);
                    if (!x.Data.Contains("generatePerContact")) x.Data.Add("generatePerContact", generatePerContact);
                    if (!x.Data.Contains("templateFile")) x.Data.Add("templateFile", templateFile);
                    if (!x.Data.Contains("contact.OppName")) x.Data.Add("contact.OppName", contact.OppName);
                    XLogger.Error(x);
                    failedContacts.Add(contact);
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
                CallUpdateStatus($"There was a problem generating some of the contact files. Successfully generated {successfulContacts.Count} contact files and failed to generate {failedContacts.Count} files. \nBelow are the failed contacts, make sure they have a valid template assigned:\n\n{String.Join("\n", failedContacts)}");
                return ExecutionResult.PartialPass;
            }
        }

        private static void GenerateContactCore(string outputFolder, REF.Scope generatePerContact, Contact contact, string templateFile)
        {
            switch (generatePerContact)
            {
                case REF.Scope.Letter:
                    GenerateFilled(outputFolder, contact, templateFile);
                    break;
                case REF.Scope.Envelop:
                    GenerateFilled(outputFolder, contact, REF.envelopFile);
                    break;
                case REF.Scope.LetterAndEnvelop:
                    GenerateFilled(outputFolder, contact, templateFile);
                    GenerateFilled(outputFolder, contact, REF.envelopFile);
                    break;
                default:
                    break;
            }
        }

        public static ExecutionResult GenerateContact(string outputFolder, Contact contact, REF.Scope generatePerContact, string templateFile)
        {
            try
            {
                GenerateContactCore(outputFolder, generatePerContact, contact, templateFile);
                CallUpdateStatus("Operation passed and filled templates are generated in the Output folder");
                return ExecutionResult.Successful;
            }
            catch (Exception x)
            {
                if (!x.Data.Contains("outputFolder")) x.Data.Add("outputFolder", outputFolder);
                if (!x.Data.Contains("generatePerContact")) x.Data.Add("generatePerContact", generatePerContact);
                if (!x.Data.Contains("templateFile")) x.Data.Add("templateFile", templateFile);
                if (!x.Data.Contains("contact.OppName")) x.Data.Add("contact.OppName", contact.OppName);
                XLogger.Error(x);
                CallUpdateStatus("There was a problem in generating all the contacts files");
                return ExecutionResult.ErrorOccured;
            }
        }
        private static void GenerateFilled(string outputFolder, Contact contact, string templateFile)
        {
            if (string.IsNullOrEmpty(contact.CDMailerTemplate) && string.IsNullOrEmpty(templateFile))
            {
                var x = new ApplicationException("Invalid template column");
                x.Data.Add("contact.FirstName", contact.FirstName);
                x.Data.Add("contact.LastName", contact.LastName);
                x.Data.Add("contact.Template", contact.Template);
                throw x;
            }

            //if (contact.FirstName.Contains("Beth"))
            //    1.ToString();

            var filename = Path.GetFileNameWithoutExtension(templateFile);
            var isEnvelop = REF.Constants.envelopFiles.Any(t => Path.GetFileNameWithoutExtension(t).MatchesString(filename));
            //string filledTemplateName = !isEnvelop ? GetFilledTemplateName(contact) : GetFilledTemplateName(contact, filename);
            string filledTemplateName = GetFilledTemplateName(contact, filename);

            var envelopContacts = contact.GetAddressContacts();
            for (int i = 0; i < envelopContacts.Count; i++)
            {
                string generatedFilenameEnvelop = $"{filledTemplateName} - {i + 1}.docx";
                string generatedFilePathEnvelop = Path.Combine(outputFolder, generatedFilenameEnvelop);
                DocxTemplate.InsertTextInPlaceholders(templateFile, generatedFilePathEnvelop, !isEnvelop ? contact as Object : envelopContacts[i] as Object);
            }
        }
        private static string GetFilledTemplateName(Contact contact, string template = null)
        {
            var filledTemplate = string.IsNullOrEmpty(template) ? contact.CDMailerTemplate : template;
            var reg = new Regex(@"\[.*?\]");
            var matches = reg.Matches(filledTemplate);
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

                var csvConfig = new Configuration()
                {
                    Delimiter = ",",
                    HasHeaderRecord = true,
                    IgnoreBlankLines = true,
                    HeaderValidated = null,
                    MissingFieldFound = null,
                    DetectColumnCountChanges = false,
                };
                //csvConfig.MissingFieldFound = (headerNames, index, context) =>
                //{
                //    var mes = $"Field with names ['{string.Join("', '", headerNames)}'] at index '{index}' was not found.";
                //    var x = new ApplicationException(mes);
                //    x.Data.Add("contactsFilepath", contactsFilepath);
                //    XLogger.Error(x);
                //};
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
                var x = new ApplicationException("An error occured while reading the csv file. Please make sure it is not open in Excel and that it follows the standard Apptivo format.", io);
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
