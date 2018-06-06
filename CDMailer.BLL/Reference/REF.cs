using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDMailer.BLL
{
    public static class REF
    {
        public enum GeneratePerContact
        {
            Letter,
            Envelop,
            LetterAndEnvelop
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
            public const string CleanFileExtension = "CLEAN.xlsx";
            public const string EnvelopTemplate = "[FirstName] [LastName] - Envelop.docx";
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
