using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDMailer.BLL
{
    public static class Lookups
    {
        #region CLS
        //
        //
        #endregion CLS

        public enum GeneratePerContact
        {
            Letter,
            Envelop,
            LetterAndEnvelop
        }

        static Lookups()
        {
        }
        public static void Reset()
        {
        }

        public static class Constants
        {
            public const string CleanFileExtension = "CLEAN.xlsx";
            public const string EnvelopTemplate = "[FirstName] [LastName] - Envelop.docx";
        }
    }
}
