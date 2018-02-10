using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public enum ExecutionResult
        {
            ErrorOccured,
            Successful,
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
        }

        public static void Reset()
        {
            Lookups.Reset();
            ExecutionStatus.Reset();
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
