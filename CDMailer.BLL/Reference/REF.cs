using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDMailer.BLL
{
    public static class REF
    {
        public enum Scope
        {
            Letter,
            Envelop,
            LetterAndEnvelop
        }
        public enum PrintMethod
        {
            PrintWithNoDialog,
            PrintWithInterop,
            PrintWithAspose,
            PrintWithGnostice,
            PrintWithSpire
        }



        static REF()
        {
        }
        public static void Reset()
        {
        }

        public static string templatesPath = Path.Combine(Environment.CurrentDirectory, "templates");
        public static string envelopFile = Path.Combine(templatesPath, REF.Constants.EnvelopTemplate);

        public static class Constants
        {
            public const string EnvelopID = "Envelop";
            public const string PostCard1ID = "Post Card 1";
            public const string PostCard2ID = "Post Card 2";
            public const string CleanFileExtension = "CLEAN.xlsx";
            public static string EnvelopTemplate = $"[FirstName] [LastName] - {EnvelopID}.docx";
            public static string PostCard1Template = $"[FirstName] [LastName] - {PostCard1ID}.docx";
            public static string PostCard2Template = $"[FirstName] [LastName] - {PostCard2ID}.docx";
            public static string AllContacts = "-------ALL-------";

            public static List<String> envelopFiles = new List<string>()
            {
                EnvelopTemplate, PostCard1Template, PostCard2Template
            };

    }

    public class Mapping
    {
        public string Apptivo { get; set; }
        public string CDMailer { get; set; }

        public static List<Mapping> refs { get; private set; }
        public static void GetRefs(string refPath)
        {
            try
            {
                refs.Clear();
                using (var sr = new StreamReader(refPath))
                {
                    var csv = new CsvHelper.CsvReader(sr);
                    var res = csv.GetRecords<Mapping>().ToList();
                    if (res != null && res.Count() > 0)
                        res.ForEach(r => refs.Add(r));
                }
            }
            catch (Exception x)
            {
                XLogger.Error(x);
            }
        }

        static Mapping()
        {
            refs = new List<Mapping>();
        }
    }

}
}
