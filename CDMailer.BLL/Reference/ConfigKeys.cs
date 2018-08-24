using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDMailer.BLL
{
    public class ConfigKeys
    {
        public class Config
        {
            public const string ExeVersion = "Config.ExeVersion";
        }

        public class UI
        {
            public const string ContactsFile = "UI.ContactsFile";
            public const string OutputFolder = "UI.OutputFolder";
            public const string GeneratePerContact = "UI.GeneratePerContact";

            public class Print
            {
                public const string EnvelopSize = "UI.Print.EnvelopSize";
                public const string EnvelopWidth = "UI.Print.EnvelopWidth";
                public const string EnvelopHeight = "UI.Print.EnvelopHeight";
                public const string EnvelopMarginLeft = "UI.Print.EnvelopMarginLeft";
                public const string EnvelopMarginRight = "UI.Print.EnvelopMarginRight";
                public const string EnvelopMarginTop = "UI.Print.EnvelopMarginTop";
                public const string EnvelopMarginBottom = "UI.Print.EnvelopMarginBottom";

                public const string PostcardSize = "UI.Print.PostcardSize";
                public const string PostcardWidth = "UI.Print.PostcardWidth";
                public const string PostcardHeight = "UI.Print.PostcardHeight";
                public const string PostcardMarginLeft = "UI.Print.PostcardMarginLeft";
                public const string PostcardMarginRight = "UI.Print.PostcardMarginRight";
                public const string PostcardMarginTop = "UI.Print.PostcardMarginTop";
                public const string PostcardMarginBottom = "UI.Print.PostcardMarginBottom";
            }
        }
    }
}
