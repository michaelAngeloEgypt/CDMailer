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
        public string CaseType { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Title { get; set; }
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
                CaseType = lineParts[++i].ReadContactString();
                AddressLine1 = lineParts[++i].ReadContactString();
                AddressLine2 = lineParts[++i].ReadContactString();
                City = lineParts[++i].ReadContactString();
                State = lineParts[++i].ReadContactString();
                ZipCode = lineParts[++i].ReadContactString();
                Title = lineParts[++i].ReadContactString();
                Template = lineParts[++i].ReadContactString();
            }
            catch (Exception x)
            {
                x.Data.Add("sourceLine", sourceLine);
                throw;
            }
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
            CaseType = !String.IsNullOrWhiteSpace(CaseType) ? CaseType.Trim() : string.Empty;
            AddressLine1 = !String.IsNullOrWhiteSpace(AddressLine1) ? AddressLine1.Trim() : string.Empty;
            AddressLine2 = !String.IsNullOrWhiteSpace(AddressLine2) ? AddressLine2.Trim() : string.Empty;
            City = !String.IsNullOrWhiteSpace(City) ? City.Trim() : string.Empty;
            State = !String.IsNullOrWhiteSpace(State) ? State.Trim() : string.Empty;
            ZipCode = !String.IsNullOrWhiteSpace(ZipCode) ? ZipCode.Trim() : string.Empty;
            Title = !String.IsNullOrWhiteSpace(Title) ? Title.Trim() : string.Empty;
            Template = !String.IsNullOrWhiteSpace(Template) ? Template.Trim() : string.Empty;
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
            Map(m => m.FirstName).Name("FirstName", "First Name");
            Map(m => m.LastName).Name("LastName", "Last Name");
            Map(m => m.OppName).Name("OppName", "Opp Name");
            Map(m => m.CaseType).Name("CaseType", "Case Type");
            Map(m => m.AddressLine1).Name("AddressLine1", ". - Address Line1");
            Map(m => m.AddressLine2).Name("AddressLine2", ". - Address Line2");
            Map(m => m.City).Name("City", ". - City");
            Map(m => m.State).Name("State", ". - State");
            Map(m => m.ZipCode).Name("ZipCode", ". - Zip Code");
            Map(m => m.Title).Name("Title", "Titles");
            Map(m => m.Template).Name("Template", "Template");
        }
    }
}
