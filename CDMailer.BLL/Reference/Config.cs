using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDMailer.BLL
{
    public class Config
    {
        public ConfUI UI { get; set; }
        public String ExeVersion { get; set; }


        public class ConfUI
        {
            public string ContactsFile { get; set; }
            public string OutputFolder { get; set; }
            public REF.Scope GeneratePerContact { get; set; }
            public int PrintBuffer { get; set; }
            public REF.PrintMethod PrintMethod { get; set; }
            public string Printer { get; set; }
            public string EnvelopSize { get; set; }
        }
    }
}


