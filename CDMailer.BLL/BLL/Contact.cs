using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDMailer.BLL
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OppName { get; set; }
        public string FsAddress { get; set; }
        public string A1_AddressLine1 { get; set; }
        public string A1_AddressLine2 { get; set; }
        public string A1_City { get; set; }
        public string A1_State { get; set; }
        public string A1_ZipCode { get; set; }
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
        public string Template { get; set; }

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

        internal List<EnvelopContact> GetAddressContacts()
        {

            var res = new List<EnvelopContact>();
            for (int i = 1; i <= 8; i++)
            {
                var AddressProperties = new Dictionary<string, string>()
                {
                    { "AddressLine1", $"A{i}_AddressLine1" },
                    { "AddressLine2", $"A{i}_AddressLine2" },
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

        internal void TrimFields()
        {
            FirstName = !String.IsNullOrWhiteSpace(FirstName) ? FirstName.Trim() : string.Empty;
            LastName = !String.IsNullOrWhiteSpace(LastName) ? LastName.Trim() : string.Empty;
            OppName = !String.IsNullOrWhiteSpace(OppName) ? OppName.Trim() : string.Empty;
            FsAddress = !String.IsNullOrWhiteSpace(FsAddress) ? FsAddress.Trim() : string.Empty;
            A1_AddressLine1 = !String.IsNullOrWhiteSpace(A1_AddressLine1) ? A1_AddressLine1.Trim() : string.Empty;
            A1_AddressLine2 = !String.IsNullOrWhiteSpace(A1_AddressLine2) ? A1_AddressLine2.Trim() : string.Empty;
            A1_City = !String.IsNullOrWhiteSpace(A1_City) ? A1_City.Trim() : string.Empty;
            A1_State = !String.IsNullOrWhiteSpace(A1_State) ? A1_State.Trim() : string.Empty;
            A1_ZipCode = !String.IsNullOrWhiteSpace(A1_ZipCode) ? A1_ZipCode.Trim() : string.Empty;
            A2_AddressLine1 = !String.IsNullOrWhiteSpace(A2_AddressLine1) ? A2_AddressLine1.Trim() : string.Empty;
            A2_AddressLine2 = !String.IsNullOrWhiteSpace(A2_AddressLine2) ? A2_AddressLine2.Trim() : string.Empty;
            A2_City = !String.IsNullOrWhiteSpace(A2_City) ? A2_City.Trim() : string.Empty;
            A2_State = !String.IsNullOrWhiteSpace(A2_State) ? A2_State.Trim() : string.Empty;
            A2_ZipCode = !String.IsNullOrWhiteSpace(A2_ZipCode) ? A2_ZipCode.Trim() : string.Empty;
            A3_AddressLine1 = !String.IsNullOrWhiteSpace(A3_AddressLine1) ? A3_AddressLine1.Trim() : string.Empty;
            A3_AddressLine2 = !String.IsNullOrWhiteSpace(A3_AddressLine2) ? A3_AddressLine2.Trim() : string.Empty;
            A3_City = !String.IsNullOrWhiteSpace(A3_City) ? A3_City.Trim() : string.Empty;
            A3_State = !String.IsNullOrWhiteSpace(A3_State) ? A3_State.Trim() : string.Empty;
            A3_ZipCode = !String.IsNullOrWhiteSpace(A3_ZipCode) ? A3_ZipCode.Trim() : string.Empty;
            A4_AddressLine1 = !String.IsNullOrWhiteSpace(A4_AddressLine1) ? A4_AddressLine1.Trim() : string.Empty;
            A4_AddressLine2 = !String.IsNullOrWhiteSpace(A4_AddressLine2) ? A4_AddressLine2.Trim() : string.Empty;
            A4_City = !String.IsNullOrWhiteSpace(A4_City) ? A4_City.Trim() : string.Empty;
            A4_State = !String.IsNullOrWhiteSpace(A4_State) ? A4_State.Trim() : string.Empty;
            A4_ZipCode = !String.IsNullOrWhiteSpace(A4_ZipCode) ? A4_ZipCode.Trim() : string.Empty;
            A5_AddressLine1 = !String.IsNullOrWhiteSpace(A5_AddressLine1) ? A5_AddressLine1.Trim() : string.Empty;
            A5_AddressLine2 = !String.IsNullOrWhiteSpace(A5_AddressLine2) ? A5_AddressLine2.Trim() : string.Empty;
            A5_City = !String.IsNullOrWhiteSpace(A5_City) ? A5_City.Trim() : string.Empty;
            A5_State = !String.IsNullOrWhiteSpace(A5_State) ? A5_State.Trim() : string.Empty;
            A5_ZipCode = !String.IsNullOrWhiteSpace(A5_ZipCode) ? A5_ZipCode.Trim() : string.Empty;
            A6_AddressLine1 = !String.IsNullOrWhiteSpace(A6_AddressLine1) ? A6_AddressLine1.Trim() : string.Empty;
            A6_AddressLine2 = !String.IsNullOrWhiteSpace(A6_AddressLine2) ? A6_AddressLine2.Trim() : string.Empty;
            A6_City = !String.IsNullOrWhiteSpace(A6_City) ? A6_City.Trim() : string.Empty;
            A6_State = !String.IsNullOrWhiteSpace(A6_State) ? A6_State.Trim() : string.Empty;
            A6_ZipCode = !String.IsNullOrWhiteSpace(A6_ZipCode) ? A6_ZipCode.Trim() : string.Empty;
            A7_AddressLine1 = !String.IsNullOrWhiteSpace(A7_AddressLine1) ? A7_AddressLine1.Trim() : string.Empty;
            A7_AddressLine2 = !String.IsNullOrWhiteSpace(A7_AddressLine2) ? A7_AddressLine2.Trim() : string.Empty;
            A7_City = !String.IsNullOrWhiteSpace(A7_City) ? A7_City.Trim() : string.Empty;
            A7_State = !String.IsNullOrWhiteSpace(A7_State) ? A7_State.Trim() : string.Empty;
            A7_ZipCode = !String.IsNullOrWhiteSpace(A7_ZipCode) ? A7_ZipCode.Trim() : string.Empty;
            A8_AddressLine1 = !String.IsNullOrWhiteSpace(A8_AddressLine1) ? A8_AddressLine1.Trim() : string.Empty;
            A8_AddressLine2 = !String.IsNullOrWhiteSpace(A8_AddressLine2) ? A8_AddressLine2.Trim() : string.Empty;
            A8_City = !String.IsNullOrWhiteSpace(A8_City) ? A8_City.Trim() : string.Empty;
            A8_State = !String.IsNullOrWhiteSpace(A8_State) ? A8_State.Trim() : string.Empty;
            A8_ZipCode = !String.IsNullOrWhiteSpace(A8_ZipCode) ? A8_ZipCode.Trim() : string.Empty;
            Template = !String.IsNullOrWhiteSpace(Template) ? Template.Trim() : string.Empty;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
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
            Map(x => x.FsAddress).Index(++i);
            Map(x => x.A1_AddressLine1).Index(++i);
            Map(x => x.A1_AddressLine2).Index(++i);
            Map(x => x.A1_City).Index(++i);
            Map(x => x.A1_State).Index(++i);
            Map(x => x.A1_ZipCode).Index(++i);
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
            Map(x => x.Template).Index(++i);
        }
    }
}
