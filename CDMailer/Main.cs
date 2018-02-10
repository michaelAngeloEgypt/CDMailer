using CDMailer.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CDMailer
{


    public partial class Main : Form
    {
        private UI myUI = new UI();
        class UI
        {
            public Main o;
            public string ContactsFile { get { return o.txtContactsFile.Text; } set { o.txtContactsFile.Text = value; } }
            public string OutputFolder { get { return o.txtOutputFolder.Text; } set { o.txtOutputFolder.Text = value; } }
            public string Result { get { return o.txtResult.Text; } set { o.txtResult.Text = value; } }

            public void SignalError(string msg)
            {
                o.txtResult.ForeColor = Color.Red;
                o.txtResult.Text = msg;
            }
            public void SignalWarning(string msg)
            {
                o.txtResult.ForeColor = Color.Yellow;
                o.txtResult.Text = msg;
            }
            public void SignalSuccess(string msg)
            {
                o.txtResult.ForeColor = Color.Green;
                o.txtResult.Text = msg;
            }
            public void ClearSignals()
            {
                o.txtResult.ForeColor = Color.Black;
                o.txtResult.Text = null;
            }

            public Config BuildConfig()
            {
                Config conf = new Config();
                conf.UI = new Config.ConfUI()
                {
                    ContactsFile = ContactsFile,
                    OutputFolder = OutputFolder,
                };
                return conf;
            }
        }

        private void UpdateProgress()
        {
            switch (Engine.ExecutionStatus.Result)
            {
                case Engine.ExecutionResult.ErrorOccured:
                    myUI.SignalError(MSG.FailedToGenerateOutput);
                    break;
                case Engine.ExecutionResult.Successful:
                    myUI.SignalSuccess(MSG.GenerationSuccessful);
                    break;
            }
        }


        public Main()
        {
            myUI.o = this;
            InitializeComponent();
            XLogger.Application = "CDMailer";
        }
        private void Main_Shown(object sender, EventArgs e)
        {
            string exeVersion = "";
            if (!LoadSettings(out exeVersion))
                MessageBox.Show(@"Unable to read app settings. Please check the log file");

            Engine.Config = myUI.BuildConfig();
            Engine.Config.ExeVersion = exeVersion;
            Engine.Variables.BeginTimestamp = DateTime.Now;

            XLogger.Application = String.Format("CDMailer||{0}||{1}", Engine.Config.ExeVersion, Engine.Variables.ExecutionTimestamp);
            this.Text = "Cash Discoveries Mailer||" + Engine.Config.ExeVersion;
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }
        private bool LoadSettings(out string exeVersion)
        {
            exeVersion = "";
            try
            {
                List<String> missingKeys = new List<string>();
                Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                exeVersion = ConfigurationManager.AppSettings[ConfigKeys.Config.ExeVersion];

                //------------------------------------------------------------------------------------------
                if (config.AppSettings.Settings.AllKeys.Contains(ConfigKeys.UI.ContactsFile))
                    myUI.ContactsFile = config.AppSettings.Settings[ConfigKeys.UI.ContactsFile].Value;
                else
                    missingKeys.Add(ConfigKeys.UI.ContactsFile);
                //------------------------------------------------------------------------------------------
                if (config.AppSettings.Settings.AllKeys.Contains(ConfigKeys.UI.OutputFolder))
                    myUI.OutputFolder = config.AppSettings.Settings[ConfigKeys.UI.OutputFolder].Value;
                else
                    missingKeys.Add(ConfigKeys.UI.OutputFolder);
                //------------------------------------------------------------------------------------------


                if (missingKeys.Count > 0)
                    throw new ApplicationException("the following config keys are missing, they will be inserted on application exit: " + String.Join(", ", missingKeys));
                return true;
            }
            catch (Exception x)
            {
                XLogger.Error(x);
                return false;
            }
        }
        private void SaveSettings()
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

                if (!config.AppSettings.Settings.AllKeys.Contains(ConfigKeys.UI.ContactsFile))
                    config.AppSettings.Settings.Add(ConfigKeys.UI.ContactsFile, myUI.ContactsFile);
                else
                    config.AppSettings.Settings[ConfigKeys.UI.ContactsFile].Value = myUI.ContactsFile;
                //------------------------------------------------------------------------------------------
                if (!config.AppSettings.Settings.AllKeys.Contains(ConfigKeys.UI.OutputFolder))
                    config.AppSettings.Settings.Add(ConfigKeys.UI.OutputFolder, myUI.OutputFolder);
                else
                    config.AppSettings.Settings[ConfigKeys.UI.OutputFolder].Value = myUI.OutputFolder;
                //------------------------------------------------------------------------------------------

                config.Save(ConfigurationSaveMode.Modified);
            }
            catch (Exception x)
            {
                XLogger.Error(x);
                MessageBox.Show(MSG.UnableToSaveConfig);
            }
        }

        private void btnOutputFolder_Click(object sender, EventArgs e)
        {
            try
            {
                var dlgOpenFolder = new Ookii.Dialogs.VistaFolderBrowserDialog()
                {
                    UseDescriptionForTitle = true,
                    Description = "Please select the generated messages output folder",
                    ShowNewFolderButton = false,
                    RootFolder = System.Environment.SpecialFolder.MyComputer,
                    //NewStyle = false,
                };
                if (!String.IsNullOrEmpty(myUI.ContactsFile))
                    dlgOpenFolder.SelectedPath = Path.GetDirectoryName(myUI.ContactsFile);

                if (dlgOpenFolder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (!Directory.Exists(dlgOpenFolder.SelectedPath))
                        MessageBox.Show(MSG.InvalidFolderPath);
                    else
                        myUI.OutputFolder = dlgOpenFolder.SelectedPath;
                }
            }
            catch (Exception x)
            {
                XLogger.Error(x);
            }
        }
        private void btnContactsFile_Click(object sender, EventArgs e)
        {
            var dlgOpenSheet = new Ookii.Dialogs.VistaOpenFileDialog()
            {
                DefaultExt = ".csv",
                Multiselect = false,
                Title = "Please select the generated messages output folder",
            };

            if (dlgOpenSheet.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                myUI.ContactsFile = dlgOpenSheet.FileName;
        }
        private void btnGO_Click(object sender, EventArgs e)
        {
            if (bgwProcess.IsBusy != true)
            {
                loadingCircle1.Active = true;
                Reset();
                bgwProcess.RunWorkerAsync();
            }
        }

        private void DoProcess()
        {
            try
            {
                var config = myUI.BuildConfig();
                Engine.DoTask(config);
            }
            catch (Exception x)
            {
                Engine.ExecutionStatus.Result = Engine.ExecutionResult.ErrorOccured;
                if (x is ApplicationException)
                    Engine.ExecutionStatus.Message = x.Message;
                else
                    Engine.ExecutionStatus.Message = MSG.UnknownError;

                XLogger.Error(x);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            if (!String.IsNullOrEmpty(txtResult.Text))
            {
                Engine.Reset();
                myUI.ClearSignals();
            }
        }

        private void bgwProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                BackgroundWorker worker = sender as BackgroundWorker;

                if ((worker.CancellationPending == true))
                    e.Cancel = true;
                else
                {
                    DoProcess();
                }
            }
            catch (Exception x) { XLogger.Error(x); }

        }
        private void bgwProcess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            loadingCircle1.Active = false;
            UpdateProgress();
        }
    }
}
