using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CDMailer.BLL
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OppName { get; set; }
        public string AssignedTo { get; set; }
        public string FsAddress { get; set; }
        public string Template { get; set; }
        public string A1_AddressLine1 { get; set; }
        public string A1_AddressLine2 { get; set; }
        public string A1_City { get; set; }
        public string A1_State { get; set; }
        public string A1_ZipCode { get; set; }
        public string A12_AddressLine1 { get; set; }
        public string A12_AddressLine2 { get; set; }
        public string A12_City { get; set; }
        public string A12_State { get; set; }
        public string A12_ZipCode { get; set; }
        public string A2_AddressLine1 { get; set; }
        public string A2_AddressLine2 { get; set; }
        public string A2_City { get; set; }
        public string A2_State { get; set; }
        public string A2_ZipCode { get; set; }
        public string A3_AddressLine1 { get; set; }
        public string A3_AddressLine2 { get; set; }
        public string A3_City { get; set; }
        public string A3_State { get; set; }
        public string A3_ZipCode { get; set; }
        public string A4_AddressLine1 { get; set; }
        public string A4_AddressLine2 { get; set; }
        public string A4_City { get; set; }
        public string A4_State { get; set; }
        public string A4_ZipCode { get; set; }
        public string A5_AddressLine1 { get; set; }
        public string A5_AddressLine2 { get; set; }
        public string A5_City { get; set; }
        public string A5_State { get; set; }
        public string A5_ZipCode { get; set; }
        public string A6_AddressLine1 { get; set; }
        public string A6_AddressLine2 { get; set; }
        public string A6_City { get; set; }
        public string A6_State { get; set; }
        public string A6_ZipCode { get; set; }
        public string A7_AddressLine1 { get; set; }
        public string A7_AddressLine2 { get; set; }
        public string A7_City { get; set; }
        public string A7_State { get; set; }
        public string A7_ZipCode { get; set; }
        public string A8_AddressLine1 { get; set; }
        public string A8_AddressLine2 { get; set; }
        public string A8_City { get; set; }
        public string A8_State { get; set; }
        public string A8_ZipCode { get; set; }
        public string A9_AddressLine1 { get; set; }
        public string A9_AddressLine2 { get; set; }
        public string A9_City { get; set; }
        public string A9_State { get; set; }
        public string A9_ZipCode { get; set; }
        //
        public string ContactName { get { return $"{FirstName?.Trim()} {LastName?.Trim()}"; } }
        public string CDMailerTemplate
        {
            get
            {
                if (REF.Mapping.refs.Count > 0)
                {
                    var matchingTemplate = REF.Mapping.refs.FirstOrDefault(m => m.Apptivo.MatchesString(Template));
                    if (matchingTemplate == null)
                        return "";

                    return matchingTemplate.CDMailer;
                }
                else
                    return "";
            }
        }

        public Contact() { }
        public Contact(string sourceLine)
        {
            try
            {
                var lineParts = sourceLine.Split(',').ToList();
                if (lineParts.Count < 11)
                    throw new ArgumentException("sourceLine should contain at least 11 columns seperated by comma", "sourceLine");

                int i = -1;
                FirstName = lineParts[++i].ReadContactString();
                LastName = lineParts[++i].ReadContactString();
                OppName = lineParts[++i].ReadContactString();
                FsAddress = lineParts[++i].ReadContactString();
                A1_AddressLine1 = lineParts[++i].ReadContactString();
                A1_AddressLine2 = lineParts[++i].ReadContactString();
                A1_City = lineParts[++i].ReadContactString();
                A1_State = lineParts[++i].ReadContactString();
                A1_ZipCode = lineParts[++i].ReadContactString();
                A2_AddressLine1 = lineParts[++i].ReadContactString();
                A2_AddressLine2 = lineParts[++i].ReadContactString();
                A2_City = lineParts[++i].ReadContactString();
                A2_State = lineParts[++i].ReadContactString();
                A2_ZipCode = lineParts[++i].ReadContactString();
                A3_AddressLine1 = lineParts[++i].ReadContactString();
                A3_AddressLine2 = lineParts[++i].ReadContactString();
                A3_City = lineParts[++i].ReadContactString();
                A3_State = lineParts[++i].ReadContactString();
                A3_ZipCode = lineParts[++i].ReadContactString();
                A4_AddressLine1 = lineParts[++i].ReadContactString();
                A4_AddressLine2 = lineParts[++i].ReadContactString();
                A4_City = lineParts[++i].ReadContactString();
                A4_State = lineParts[++i].ReadContactString();
                A4_ZipCode = lineParts[++i].ReadContactString();
                A5_AddressLine1 = lineParts[++i].ReadContactString();
                A5_AddressLine2 = lineParts[++i].ReadContactString();
                A5_City = lineParts[++i].ReadContactString();
                A5_State = lineParts[++i].ReadContactString();
                A5_ZipCode = lineParts[++i].ReadContactString();
                A6_AddressLine1 = lineParts[++i].ReadContactString();
                A6_AddressLine2 = lineParts[++i].ReadContactString();
                A6_City = lineParts[++i].ReadContactString();
                A6_State = lineParts[++i].ReadContactString();
                A6_ZipCode = lineParts[++i].ReadContactString();
                A7_AddressLine1 = lineParts[++i].ReadContactString();
                A7_AddressLine2 = lineParts[++i].ReadContactString();
                A7_City = lineParts[++i].ReadContactString();
                A7_State = lineParts[++i].ReadContactString();
                A7_ZipCode = lineParts[++i].ReadContactString();
                A8_AddressLine1 = lineParts[++i].ReadContactString();
                A8_AddressLine2 = lineParts[++i].ReadContactString();
                A8_City = lineParts[++i].ReadContactString();
                A8_State = lineParts[++i].ReadContactString();
                A8_ZipCode = lineParts[++i].ReadContactString();
                Template = lineParts[++i].ReadContactString();
            }
            catch (Exception x)
            {
                x.Data.Add("sourceLine", sourceLine);
                throw;
            }
        }

        public List<EnvelopContact> GetAddressContacts()
        {

            var res = new List<EnvelopContact>();
            for (int i = 1; i <= 8; i++)
            {
                var AddressProperties = new Dictionary<string, string>()
                {
                    { "AddressLine1", $"A{i}_AddressLine1"},
                    { "AddressLine2", $"A{i}_AddressLine2"},
                    { "City", $"A{i}_City"},
                    { "State", $"A{i}_State"},
                    { "ZipCode", $"A{i}_ZipCode"},
                };

                var eContact = new EnvelopContact()
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    OppName = OppName,
                };

                foreach (var kvp in AddressProperties)
                    eContact.SetPropertyValue(kvp.Key, this.GetPropertyValue(kvp.Value));

                var blanks = true;
                foreach (var kvp in AddressProperties)
                    blanks = blanks && string.IsNullOrWhiteSpace(eContact.GetPropertyStringValue(kvp.Key));

                if (!blanks)
                    res.Add(eContact);
            }
            return res;
        }
        internal string GetMappedVar(string varName)
        {
            var propInfo = this.GetType().GetProperty(varName);
            if (propInfo != null)
                return propInfo.GetValue(this) as string;
            else
                return "";
        }
        internal void AdjustFields()
        {
            Func<string, string> func1 = (x) => !String.IsNullOrWhiteSpace(x) ? x.Trim() : string.Empty;
            this.DoFunctionOnStringProperties(func1);

            Func<string, string> func2 = (x) => !String.IsNullOrWhiteSpace(x) && x.Trim().Length < 5 ? x.Trim().PadLeft(5, '0') : string.Empty;
            var zipCodes = this.GetPublicStringPropertiesNames().Where(p => p.Contains("ZipCode")).ToList();
            this.DoFunctionOnSomeStringProperties(zipCodes, func2);
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} - {OppName}";
        }
    }

    internal static class ContactExtender
    {
        public static string ReadContactString(this string source)
        {
            return string.IsNullOrWhiteSpace(source) ? string.Empty : source.Trim();
        }
    }

    public sealed class ContactMap : ClassMap<Contact>
    {
        public ContactMap()
        {
            //AutoMap();
            int i = -1;

            Map(x => x.FirstName).Index(++i);
            Map(x => x.LastName).Index(++i);
            Map(x => x.OppName).Index(++i);
            Map(x => x.AssignedTo).Index(++i);
            Map(x => x.FsAddress).Index(++i);
            Map(x => x.Template).Index(++i);
            Map(x => x.A1_AddressLine1).Index(++i);
            Map(x => x.A1_AddressLine2).Index(++i);
            Map(x => x.A1_City).Index(++i);
            Map(x => x.A1_State).Index(++i);
            Map(x => x.A1_ZipCode).Index(++i);
            Map(x => x.A12_AddressLine1).Index(++i);
            Map(x => x.A12_AddressLine2).Index(++i);
            Map(x => x.A12_City).Index(++i);
            Map(x => x.A12_State).Index(++i);
            Map(x => x.A12_ZipCode).Index(++i);
            Map(x => x.A2_AddressLine1).Index(++i);
            Map(x => x.A2_AddressLine2).Index(++i);
            Map(x => x.A2_City).Index(++i);
            Map(x => x.A2_State).Index(++i);
            Map(x => x.A2_ZipCode).Index(++i);
            Map(x => x.A3_AddressLine1).Index(++i);
            Map(x => x.A3_AddressLine2).Index(++i);
            Map(x => x.A3_City).Index(++i);
            Map(x => x.A3_State).Index(++i);
            Map(x => x.A3_ZipCode).Index(++i);
            Map(x => x.A4_AddressLine1).Index(++i);
            Map(x => x.A4_AddressLine2).Index(++i);
            Map(x => x.A4_City).Index(++i);
            Map(x => x.A4_State).Index(++i);
            Map(x => x.A4_ZipCode).Index(++i);
            Map(x => x.A5_AddressLine1).Index(++i);
            Map(x => x.A5_AddressLine2).Index(++i);
            Map(x => x.A5_City).Index(++i);
            Map(x => x.A5_State).Index(++i);
            Map(x => x.A5_ZipCode).Index(++i);
            Map(x => x.A6_AddressLine1).Index(++i);
            Map(x => x.A6_AddressLine2).Index(++i);
            Map(x => x.A6_City).Index(++i);
            Map(x => x.A6_State).Index(++i);
            Map(x => x.A6_ZipCode).Index(++i);
            Map(x => x.A7_AddressLine1).Index(++i);
            Map(x => x.A7_AddressLine2).Index(++i);
            Map(x => x.A7_City).Index(++i);
            Map(x => x.A7_State).Index(++i);
            Map(x => x.A7_ZipCode).Index(++i);
            Map(x => x.A8_AddressLine1).Index(++i);
            Map(x => x.A8_AddressLine2).Index(++i);
            Map(x => x.A8_City).Index(++i);
            Map(x => x.A8_State).Index(++i);
            Map(x => x.A8_ZipCode).Index(++i);
            Map(x => x.A9_AddressLine1).Index(++i);
            Map(x => x.A9_AddressLine2).Index(++i);
            Map(x => x.A9_City).Index(++i);
            Map(x => x.A9_State).Index(++i);
            Map(x => x.A9_ZipCode).Index(++i);
        }
    }
}
