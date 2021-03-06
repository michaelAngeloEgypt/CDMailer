﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDMailer.BLL
{
    public class ExecutionVariables
    {
        public bool CancellationPending { get; set; }
        public Stopwatch ExecutionTime;
        public DateTime BeginTimestamp { get; set; }

        public string ExecutionTimestamp { get { return BeginTimestamp.ToString("yyyyMMddHHmmss"); } }
        public string FilenameTimestamp { get { return $"{BeginTimestamp.ToString("yyyyMMdd")}_{BeginTimestamp.ToString("HHmmss")}"; } }


        public List<Contact> Contacts { get; private set; }

        public ExecutionVariables()
        {
            Reset();
        }
        public void Reset()
        {
            ExecutionTime = new Stopwatch();
            CancellationPending = false;
            BeginTimestamp = DateTime.Now;
            //OutputSheetPath = "";
            Contacts = new List<Contact>();
        }
    }
}
