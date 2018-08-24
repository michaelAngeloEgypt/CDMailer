using CDMailer.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Windows.Forms;

namespace CDMailer
{
    public partial class Main : Form
    {
        private string defaultPrinter = string.Empty;

        delegate void SetTextCallback(string text);
        delegate void SetCompletedCallback(string finalMessage);

        private UI myUI = new UI();
        class UI
        {
            public Main o;
            public string ContactsFile { get { return o.txtContactsFile.Text; } set { o.txtContactsFile.Text = value; } }
            public string OutputFolder { get { return o.txtOutputFolder.Text; } set { o.txtOutputFolder.Text = value; } }
            public REF.Scope GeneratePerContact
            {
                get
                {
                    var selectedTag = o.gbInputs.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Tag.ToString();
                    return (REF.Scope)Enum.Parse(typeof(REF.Scope), selectedTag);
                }
                set
                {
                    var selectedCheckbox = o.gbInputs.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Tag.Equals(value.ToString()));
                    selectedCheckbox.Checked = true;
                }
            }
            public REF.Scope PrintPerContact
            {
                get
                {
                    var selectedTag = o.gpPrintScope.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Tag.ToString();
                    return (REF.Scope)Enum.Parse(typeof(REF.Scope), selectedTag);
                }
                set
                {
                    var selectedCheckbox = o.gpPrintScope.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Tag.Equals(value.ToString()));
                    selectedCheckbox.Checked = true;
                }
            }
            public REF.PrintMethod PrintMethod
            {
                get
                {
                    var selectedTag = o.gpPrintMethod.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Tag.ToString();
                    return (REF.PrintMethod)Enum.Parse(typeof(REF.PrintMethod), selectedTag);
                }
                set
                {
                    var selectedCheckbox = o.gpPrintMethod.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Tag.Equals(value.ToString()));
                    selectedCheckbox.Checked = true;
                }
            }
            public int PrintBuffer { get { return int.Parse(o.numPrintBuffer.Value.ToString()); } set { o.numPrintBuffer.Value = value; } }
            public string Printer
            {
                get
                {
                    var res = "";
                    o.Invoke((MethodInvoker)delegate ()
                    {
                        res = !o.cboPrinters.SelectedValue.ToString().Equals("DEFAULT") ? o.cboPrinters.SelectedValue.ToString() : o.defaultPrinter;
                    });
                    return res;
                }
            }

            public string EnvelopSize
            {
                get
                {
                    var res = "";
                    o.Invoke((MethodInvoker)delegate ()
                    {
                        res = o.cboEnvelopSizes.SelectedValue.ToString();
                    });
                    return res;
                }
                set
                {
                    o.Invoke((MethodInvoker)delegate ()
                    {
                        o.cboEnvelopSizes.SelectedIndex = o.cboEnvelopSizes.Items.IndexOf(value);
                    });
                }
            }
            public int EnvelopWidth
            {
                get
                {
                    var res = 0;
                    o.Invoke((MethodInvoker)delegate ()
                    {
                        int.TryParse(o.txtEnvelopWidth.Text, out res);
                    });
                    return res;
                }
                set
                {
                    o.Invoke((MethodInvoker)delegate ()
                    {
                        o.txtEnvelopWidth.Text = value.ToString();
                    });
                }
            }
            public int EnvelopHeight
            {
                get
                {
                    var res = 0;
                    o.Invoke((MethodInvoker)delegate ()
                    {
                        int.TryParse(o.txtEnvelopHeight.Text, out res);
                    });
                    return res;
                }
                set
                {
                    o.Invoke((MethodInvoker)delegate ()
                    {
                        o.txtEnvelopHeight.Text = value.ToString();
                    });
                }
            }
            public int EnvelopMarginLeft
            {
                get
                {
                    var res = 0;
                    o.Invoke((MethodInvoker)delegate ()
                    {
                        res = int.Parse(o.txtEnvelopMarginLeft.Text);
                    });
                    return res;
                }
                set
                {
                    o.Invoke((MethodInvoker)delegate ()
                    {
                        o.txtEnvelopMarginLeft.Text = value.ToString();
                    });
                }
            }
            public int EnvelopMarginRight
            {
                get
                {
                    var res = 0;
                    o.Invoke((MethodInvoker)delegate ()
                    {
                        res = int.Parse(o.txtEnvelopMarginRight.Text);
                    });
                    return res;
                }
                set
                {
                    o.Invoke((MethodInvoker)delegate ()
                    {
                        o.txtEnvelopMarginRight.Text = value.ToString();
                    });
                }
            }
            public int EnvelopMarginTop
            {
                get
                {
                    var res = 0;
                    o.Invoke((MethodInvoker)delegate ()
                    {
                        res = int.Parse(o.txtEnvelopMarginTop.Text);
                    });
                    return res;
                }
                set
                {
                    o.Invoke((MethodInvoker)delegate ()
                    {
                        o.txtEnvelopMarginTop.Text = value.ToString();
                    });
                }
            }
            public int EnvelopMarginBottom
            {
                get
                {
                    var res = 0;
                    o.Invoke((MethodInvoker)delegate ()
                    {
                        res = int.Parse(o.txtEnvelopMarginBottom.Text);
                    });
                    return res;
                }
                set
                {
                    o.Invoke((MethodInvoker)delegate ()
                    {
                        o.txtEnvelopMarginBottom.Text = value.ToString();
                    });
                }
            }

            public string PostcardSize
            {
                get
                {
                    var res = "";
                    o.Invoke((MethodInvoker)delegate ()
                    {
                        res = o.cboPostcardSizes.SelectedValue.ToString();
                    });
                    return res;
                }
                set
                {
                    o.Invoke((MethodInvoker)delegate ()
                    {
                        o.cboPostcardSizes.SelectedIndex = o.cboPostcardSizes.Items.IndexOf(value);
                    });
                }
            }
            public int PostcardWidth
            {
                get
                {
                    var res = 0;
                    o.Invoke((MethodInvoker)delegate ()
                    {
                        int.TryParse(o.txtPostcardWidth.Text, out res);
                    });
                    return res;
                }
                set
                {
                    o.Invoke((MethodInvoker)delegate ()
                    {
                        o.txtPostcardWidth.Text = value.ToString();
                    });
                }
            }
            public int PostcardHeight
            {
                get
                {
                    var res = 0;
                    o.Invoke((MethodInvoker)delegate ()
                    {
                        int.TryParse(o.txtPostcardHeight.Text, out res);
                    });
                    return res;
                }
                set
                {
                    o.Invoke((MethodInvoker)delegate ()
                    {
                        o.txtPostcardHeight.Text = value.ToString();
                    });
                }
            }
            public int PostcardMarginLeft
            {
                get
                {
                    var res = 0;
                    o.Invoke((MethodInvoker)delegate ()
                    {
                        res = int.Parse(o.txtPostcardMarginLeft.Text);
                    });
                    return res;
                }
                set
                {
                    o.Invoke((MethodInvoker)delegate ()
                    {
                        o.txtPostcardMarginLeft.Text = value.ToString();
                    });
                }
            }
            public int PostcardMarginRight
            {
                get
                {
                    var res = 0;
                    o.Invoke((MethodInvoker)delegate ()
                    {
                        res = int.Parse(o.txtPostcardMarginRight.Text);
                    });
                    return res;
                }
                set
                {
                    o.Invoke((MethodInvoker)delegate ()
                    {
                        o.txtPostcardMarginRight.Text = value.ToString();
                    });
                }
            }
            public int PostcardMarginTop
            {
                get
                {
                    var res = 0;
                    o.Invoke((MethodInvoker)delegate ()
                    {
                        res = int.Parse(o.txtPostcardMarginTop.Text);
                    });
                    return res;
                }
                set
                {
                    o.Invoke((MethodInvoker)delegate ()
                    {
                        o.txtPostcardMarginTop.Text = value.ToString();
                    });
                }
            }
            public int PostcardMarginBottom
            {
                get
                {
                    var res = 0;
                    o.Invoke((MethodInvoker)delegate ()
                    {
                        res = int.Parse(o.txtPostcardMarginBottom.Text);
                    });
                    return res;
                }
                set
                {
                    o.Invoke((MethodInvoker)delegate ()
                    {
                        o.txtPostcardMarginBottom.Text = value.ToString();
                    });
                }
            }

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
                    GeneratePerContact = GeneratePerContact,
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
        private void UpdateProgress(String Message)
        {
            if (this.txtResult.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(UpdateProgress);
                this.Invoke(d, new object[] { Message });
            }
            else
            {
                this.txtResult.Text = Message;
                XLogger.Info(Message);
            }
        }
        private void MarkCompleted(string finalMessage)
        {
            //String finalMessage = "Completed the Process";

            if (this.txtResult.InvokeRequired)
            {
                SetCompletedCallback d = new SetCompletedCallback(MarkCompleted);
                this.Invoke(d, new Object[] { finalMessage });
            }
            else
            {
                this.txtResult.Text = finalMessage;
            }

            loadingCircle1.Active = false;
            //btnStartStop.Text = "START";
            //btnStartStop.Enabled = true;
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

            listPrinters();
            listPaperSizes();
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
                if (config.AppSettings.Settings.AllKeys.Contains(ConfigKeys.UI.GeneratePerContact))
                    myUI.GeneratePerContact = (REF.Scope)Enum.Parse(typeof(REF.Scope), config.AppSettings.Settings[ConfigKeys.UI.GeneratePerContact].Value);
                else
                    missingKeys.Add(ConfigKeys.UI.GeneratePerContact);
                //------------------------------------------------------------------------------------------
                //------------------------------------------------------------------------------------------
                if (config.AppSettings.Settings.AllKeys.Contains(ConfigKeys.UI.Print.PostcardSize))
                    myUI.PostcardSize = config.AppSettings.Settings[ConfigKeys.UI.Print.PostcardSize].Value;
                else
                    missingKeys.Add(ConfigKeys.UI.Print.PostcardSize);
                //------------------------------------------------------------------------------------------
                if (config.AppSettings.Settings.AllKeys.Contains(ConfigKeys.UI.Print.PostcardWidth))
                    myUI.PostcardWidth = int.Parse(config.AppSettings.Settings[ConfigKeys.UI.Print.PostcardWidth].Value);
                else
                    missingKeys.Add(ConfigKeys.UI.Print.PostcardWidth);
                //------------------------------------------------------------------------------------------
                if (config.AppSettings.Settings.AllKeys.Contains(ConfigKeys.UI.Print.PostcardHeight))
                    myUI.PostcardHeight = int.Parse(config.AppSettings.Settings[ConfigKeys.UI.Print.PostcardHeight].Value);
                else
                    missingKeys.Add(ConfigKeys.UI.Print.PostcardHeight);
                //------------------------------------------------------------------------------------------
                if (config.AppSettings.Settings.AllKeys.Contains(ConfigKeys.UI.Print.PostcardMarginLeft))
                    myUI.PostcardMarginLeft = int.Parse(config.AppSettings.Settings[ConfigKeys.UI.Print.PostcardMarginLeft].Value);
                else
                    missingKeys.Add(ConfigKeys.UI.Print.PostcardMarginLeft);
                //------------------------------------------------------------------------------------------
                if (config.AppSettings.Settings.AllKeys.Contains(ConfigKeys.UI.Print.PostcardMarginRight))
                    myUI.PostcardMarginRight = int.Parse(config.AppSettings.Settings[ConfigKeys.UI.Print.PostcardMarginRight].Value);
                else
                    missingKeys.Add(ConfigKeys.UI.Print.PostcardMarginRight);
                //------------------------------------------------------------------------------------------
                if (config.AppSettings.Settings.AllKeys.Contains(ConfigKeys.UI.Print.PostcardMarginTop))
                    myUI.PostcardMarginTop = int.Parse(config.AppSettings.Settings[ConfigKeys.UI.Print.PostcardMarginTop].Value);
                else
                    missingKeys.Add(ConfigKeys.UI.Print.PostcardMarginTop);
                //------------------------------------------------------------------------------------------
                if (config.AppSettings.Settings.AllKeys.Contains(ConfigKeys.UI.Print.PostcardMarginBottom))
                    myUI.PostcardMarginBottom = int.Parse(config.AppSettings.Settings[ConfigKeys.UI.Print.PostcardMarginBottom].Value);
                else
                    missingKeys.Add(ConfigKeys.UI.Print.PostcardMarginBottom);
                //------------------------------------------------------------------------------------------
                //------------------------------------------------------------------------------------------
                if (config.AppSettings.Settings.AllKeys.Contains(ConfigKeys.UI.Print.PostcardSize))
                    myUI.PostcardSize = config.AppSettings.Settings[ConfigKeys.UI.Print.PostcardSize].Value;
                else
                    missingKeys.Add(ConfigKeys.UI.Print.PostcardSize);
                //------------------------------------------------------------------------------------------
                if (config.AppSettings.Settings.AllKeys.Contains(ConfigKeys.UI.Print.PostcardWidth))
                    myUI.PostcardWidth = int.Parse(config.AppSettings.Settings[ConfigKeys.UI.Print.PostcardWidth].Value);
                else
                    missingKeys.Add(ConfigKeys.UI.Print.PostcardWidth);
                //------------------------------------------------------------------------------------------
                if (config.AppSettings.Settings.AllKeys.Contains(ConfigKeys.UI.Print.PostcardHeight))
                    myUI.PostcardHeight = int.Parse(config.AppSettings.Settings[ConfigKeys.UI.Print.PostcardHeight].Value);
                else
                    missingKeys.Add(ConfigKeys.UI.Print.PostcardHeight);
                //------------------------------------------------------------------------------------------
                if (config.AppSettings.Settings.AllKeys.Contains(ConfigKeys.UI.Print.PostcardMarginLeft))
                    myUI.PostcardMarginLeft = int.Parse(config.AppSettings.Settings[ConfigKeys.UI.Print.PostcardMarginLeft].Value);
                else
                    missingKeys.Add(ConfigKeys.UI.Print.PostcardMarginLeft);
                //------------------------------------------------------------------------------------------
                if (config.AppSettings.Settings.AllKeys.Contains(ConfigKeys.UI.Print.PostcardMarginRight))
                    myUI.PostcardMarginRight = int.Parse(config.AppSettings.Settings[ConfigKeys.UI.Print.PostcardMarginRight].Value);
                else
                    missingKeys.Add(ConfigKeys.UI.Print.PostcardMarginRight);
                //------------------------------------------------------------------------------------------
                if (config.AppSettings.Settings.AllKeys.Contains(ConfigKeys.UI.Print.PostcardMarginTop))
                    myUI.PostcardMarginTop = int.Parse(config.AppSettings.Settings[ConfigKeys.UI.Print.PostcardMarginTop].Value);
                else
                    missingKeys.Add(ConfigKeys.UI.Print.PostcardMarginTop);
                //------------------------------------------------------------------------------------------
                if (config.AppSettings.Settings.AllKeys.Contains(ConfigKeys.UI.Print.PostcardMarginBottom))
                    myUI.PostcardMarginBottom = int.Parse(config.AppSettings.Settings[ConfigKeys.UI.Print.PostcardMarginBottom].Value);
                else
                    missingKeys.Add(ConfigKeys.UI.Print.PostcardMarginBottom);
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
                if (!config.AppSettings.Settings.AllKeys.Contains(ConfigKeys.UI.GeneratePerContact))
                    config.AppSettings.Settings.Add(ConfigKeys.UI.GeneratePerContact, myUI.GeneratePerContact.ToString());
                else
                    config.AppSettings.Settings[ConfigKeys.UI.GeneratePerContact].Value = myUI.GeneratePerContact.ToString();
                //------------------------------------------------------------------------------------------
                //------------------------------------------------------------------------------------------
                if (!config.AppSettings.Settings.AllKeys.Contains(ConfigKeys.UI.Print.EnvelopSize))
                    config.AppSettings.Settings.Add(ConfigKeys.UI.Print.EnvelopSize, myUI.EnvelopSize.ToString());
                else
                    config.AppSettings.Settings[ConfigKeys.UI.Print.EnvelopSize].Value = myUI.EnvelopSize.ToString();
                //------------------------------------------------------------------------------------------
                if (!config.AppSettings.Settings.AllKeys.Contains(ConfigKeys.UI.Print.EnvelopWidth))
                    config.AppSettings.Settings.Add(ConfigKeys.UI.Print.EnvelopWidth, myUI.EnvelopWidth.ToString());
                else
                    config.AppSettings.Settings[ConfigKeys.UI.Print.EnvelopWidth].Value = myUI.EnvelopWidth.ToString();
                //------------------------------------------------------------------------------------------
                if (!config.AppSettings.Settings.AllKeys.Contains(ConfigKeys.UI.Print.EnvelopHeight))
                    config.AppSettings.Settings.Add(ConfigKeys.UI.Print.EnvelopHeight, myUI.EnvelopHeight.ToString());
                else
                    config.AppSettings.Settings[ConfigKeys.UI.Print.EnvelopHeight].Value = myUI.EnvelopHeight.ToString();
                //------------------------------------------------------------------------------------------
                if (!config.AppSettings.Settings.AllKeys.Contains(ConfigKeys.UI.Print.EnvelopMarginLeft))
                    config.AppSettings.Settings.Add(ConfigKeys.UI.Print.EnvelopMarginLeft, myUI.EnvelopMarginLeft.ToString());
                else
                    config.AppSettings.Settings[ConfigKeys.UI.Print.EnvelopMarginLeft].Value = myUI.EnvelopMarginLeft.ToString();
                //------------------------------------------------------------------------------------------
                if (!config.AppSettings.Settings.AllKeys.Contains(ConfigKeys.UI.Print.EnvelopMarginRight))
                    config.AppSettings.Settings.Add(ConfigKeys.UI.Print.EnvelopMarginRight, myUI.EnvelopMarginRight.ToString());
                else
                    config.AppSettings.Settings[ConfigKeys.UI.Print.EnvelopMarginRight].Value = myUI.EnvelopMarginRight.ToString();
                //------------------------------------------------------------------------------------------
                if (!config.AppSettings.Settings.AllKeys.Contains(ConfigKeys.UI.Print.EnvelopMarginTop))
                    config.AppSettings.Settings.Add(ConfigKeys.UI.Print.EnvelopMarginTop, myUI.EnvelopMarginTop.ToString());
                else
                    config.AppSettings.Settings[ConfigKeys.UI.Print.EnvelopMarginTop].Value = myUI.EnvelopMarginTop.ToString();
                //------------------------------------------------------------------------------------------
                if (!config.AppSettings.Settings.AllKeys.Contains(ConfigKeys.UI.Print.EnvelopMarginBottom))
                    config.AppSettings.Settings.Add(ConfigKeys.UI.Print.EnvelopMarginBottom, myUI.EnvelopMarginBottom.ToString());
                else
                    config.AppSettings.Settings[ConfigKeys.UI.Print.EnvelopMarginBottom].Value = myUI.EnvelopMarginBottom.ToString();
                //------------------------------------------------------------------------------------------
                //------------------------------------------------------------------------------------------
                if (!config.AppSettings.Settings.AllKeys.Contains(ConfigKeys.UI.Print.PostcardSize))
                    config.AppSettings.Settings.Add(ConfigKeys.UI.Print.PostcardSize, myUI.PostcardSize.ToString());
                else
                    config.AppSettings.Settings[ConfigKeys.UI.Print.PostcardSize].Value = myUI.PostcardSize.ToString();
                //------------------------------------------------------------------------------------------
                if (!config.AppSettings.Settings.AllKeys.Contains(ConfigKeys.UI.Print.PostcardWidth))
                    config.AppSettings.Settings.Add(ConfigKeys.UI.Print.PostcardWidth, myUI.PostcardWidth.ToString());
                else
                    config.AppSettings.Settings[ConfigKeys.UI.Print.PostcardWidth].Value = myUI.PostcardWidth.ToString();
                //------------------------------------------------------------------------------------------
                if (!config.AppSettings.Settings.AllKeys.Contains(ConfigKeys.UI.Print.PostcardHeight))
                    config.AppSettings.Settings.Add(ConfigKeys.UI.Print.PostcardHeight, myUI.PostcardHeight.ToString());
                else
                    config.AppSettings.Settings[ConfigKeys.UI.Print.PostcardHeight].Value = myUI.PostcardHeight.ToString();
                //------------------------------------------------------------------------------------------
                if (!config.AppSettings.Settings.AllKeys.Contains(ConfigKeys.UI.Print.PostcardMarginLeft))
                    config.AppSettings.Settings.Add(ConfigKeys.UI.Print.PostcardMarginLeft, myUI.PostcardMarginLeft.ToString());
                else
                    config.AppSettings.Settings[ConfigKeys.UI.Print.PostcardMarginLeft].Value = myUI.PostcardMarginLeft.ToString();
                //------------------------------------------------------------------------------------------
                if (!config.AppSettings.Settings.AllKeys.Contains(ConfigKeys.UI.Print.PostcardMarginRight))
                    config.AppSettings.Settings.Add(ConfigKeys.UI.Print.PostcardMarginRight, myUI.PostcardMarginRight.ToString());
                else
                    config.AppSettings.Settings[ConfigKeys.UI.Print.PostcardMarginRight].Value = myUI.PostcardMarginRight.ToString();
                //------------------------------------------------------------------------------------------
                if (!config.AppSettings.Settings.AllKeys.Contains(ConfigKeys.UI.Print.PostcardMarginTop))
                    config.AppSettings.Settings.Add(ConfigKeys.UI.Print.PostcardMarginTop, myUI.PostcardMarginTop.ToString());
                else
                    config.AppSettings.Settings[ConfigKeys.UI.Print.PostcardMarginTop].Value = myUI.PostcardMarginTop.ToString();
                //------------------------------------------------------------------------------------------
                if (!config.AppSettings.Settings.AllKeys.Contains(ConfigKeys.UI.Print.PostcardMarginBottom))
                    config.AppSettings.Settings.Add(ConfigKeys.UI.Print.PostcardMarginBottom, myUI.PostcardMarginBottom.ToString());
                else
                    config.AppSettings.Settings[ConfigKeys.UI.Print.PostcardMarginBottom].Value = myUI.PostcardMarginBottom.ToString();
                //------------------------------------------------------------------------------------------
                //------------------------------------------------------------------------------------------

                config.Save(ConfigurationSaveMode.Modified);
            }
            catch (Exception x)
            {
                XLogger.Error(x);
                MessageBox.Show(MSG.UnableToSaveConfig);
            }
        }

        private void DetachEvents()
        {
            Engine.UpdateStatusEvent -= UpdateProgress;
            Engine.MarkCompletedEvent -= MarkCompleted;
        }
        private void AttachEvents()
        {
            Engine.UpdateStatusEvent += UpdateProgress;
            Engine.MarkCompletedEvent += MarkCompleted;
        }
        private void listPrinters()
        {
            var printers = new List<string>();
            var printerQuery = new ManagementObjectSearcher("SELECT * from Win32_Printer");
            foreach (var printer in printerQuery.Get())
            {
                var name = printer.GetPropertyValue("Name");
                var status = printer.GetPropertyValue("Status");
                var isDefault = printer.GetPropertyValue("Default");
                var isNetworkPrinter = printer.GetPropertyValue("Network");

                Console.WriteLine("{0} (Status: {1}, Default: {2}, Network: {3}",
                            name, status, isDefault, isNetworkPrinter);

                printers.Add(name.ToString());

                if (bool.Parse(isDefault.ToString()))
                    defaultPrinter = name.ToString();
            }
            printers.Insert(0, "DEFAULT");
            cboPrinters.DataSource = printers;
            cboPrinters.SelectedIndex = 0;
        }
        private void listPaperSizes()
        {
            cboEnvelopSizes.DataSource = PrinterUtils.PaperSizes.Keys.ToList();
            cboEnvelopSizes.SelectedIndex = cboEnvelopSizes.Items.IndexOf("A4");

            cboPostcardSizes.DataSource = PrinterUtils.PaperSizes.Keys.ToList();
            cboPostcardSizes.SelectedIndex = cboPostcardSizes.Items.IndexOf("A5");
        }

        private void btnContactsFile_Click(object sender, EventArgs e)
        {
            var dlgOpenSheet = new Ookii.Dialogs.VistaOpenFileDialog()
            {
                DefaultExt = ".csv",
                Multiselect = false,
                Title = "Please select the input csv coming from Apptivo",
            };

            if (dlgOpenSheet.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                myUI.ContactsFile = dlgOpenSheet.FileName;
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
                DetachEvents();
            }
        }
        private bool ValidateInputs(out string err)
        {
            err = "";

            if (String.IsNullOrEmpty(err) &&
                    (String.IsNullOrWhiteSpace(myUI.ContactsFile) || String.IsNullOrWhiteSpace(myUI.OutputFolder)))
                err = "Please fill all the inputs";

            if (String.IsNullOrEmpty(err) && !Directory.Exists(myUI.OutputFolder))
                err = "The output folder is invalid. Please rechek it";

            return String.IsNullOrEmpty(err);
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
                    AttachEvents();
                    DoProcess();
                }
            }
            catch (Exception x) { XLogger.Error(x); }

        }
        private void bgwProcess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            loadingCircle1.Active = false;
            DetachEvents();
            //UpdateProgress();
        }
        private void bgwProcess2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                BackgroundWorker worker = sender as BackgroundWorker;

                if ((worker.CancellationPending == true))
                    e.Cancel = true;
                else
                {
                    AttachEvents();
                    DoCustom();
                }
            }
            catch (Exception x) { XLogger.Error(x); }
        }
        private void bgwProcess2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            loadingCircle1.Active = false;
            DetachEvents();
            //UpdateProgress();
        }
        private void bgwProcess3_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                BackgroundWorker worker = sender as BackgroundWorker;

                if ((worker.CancellationPending == true))
                    e.Cancel = true;
                else
                {
                    AttachEvents();
                    DoPrint();
                }
            }
            catch (Exception x) { XLogger.Error(x); }
        }
        private void bgwProcess3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            loadingCircle1.Active = false;
            DetachEvents();
            //UpdateProgress();
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            string err = "";
            if (!ValidateInputs(out err))
            {
                myUI.SignalError(err);
                return;
            }

            if (bgwProcess.IsBusy != true)
            {
                loadingCircle1.Active = true;
                Reset();
                bgwProcess.RunWorkerAsync();
            }
        }
        private void btnCustom_Click(object sender, EventArgs e)
        {
            if (bgwProcess2.IsBusy != true)
            {
                loadingCircle1.Active = true;
                Reset();
                bgwProcess2.RunWorkerAsync();
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            string err = "";
            if (!ValidateInputs(out err))
            {
                myUI.SignalError(err);
                return;
            }

            if (bgwProcess3.IsBusy != true)
            {
                loadingCircle1.Active = true;
                Reset();
                bgwProcess3.RunWorkerAsync();
            }
        }

        private void DoProcess()
        {
            try
            {
                var config = myUI.BuildConfig();
                if (!File.Exists(REF.envelopFile))
                    throw new ApplicationException($"Missing envelop template file: {REF.envelopFile}");

                Engine.Variables.ExecutionTime.Start();
                Stopwatch timer = Stopwatch.StartNew();
                XLogger.Info("BEGIN:\t Task Execution");

                Engine.DoTask(config);

                var elapsed = timer.Elapsed.ToStandardElapsedFormat();
                XLogger.Info($"END:{elapsed}\t Task Execution");
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
        private void DoCustom()
        {
            try
            {
                if (string.IsNullOrEmpty(myUI.ContactsFile))
                {
                    MessageBox.Show("Please select an input csv file first!");
                    return;
                }
                if (string.IsNullOrEmpty(myUI.OutputFolder))
                {
                    MessageBox.Show("Please set the output folder first!");
                    return;
                }

                Engine.Config = myUI.BuildConfig();
                Engine.ReadContacts();
                if (Engine.Variables.Contacts.Count == 0)
                {
                    MessageBox.Show("The selected input csv has no contacts, or it is currently open in Excel, or it doesn't follow the correct format. Please check.");
                    return;
                }

                Custom sc = new Custom();
                sc.ShowDialog();
                if (sc.DialogResult == DialogResult.OK)
                {
                    var contacts = new List<Contact>();
                    if (sc.SelectedContact == REF.Constants.AllContacts)
                        contacts.AddRange(Engine.Variables.Contacts);
                    else
                    {
                        var matchingContact = Engine.Variables.Contacts.FirstOrDefault(c => c.ContactName.MatchesString(sc.SelectedContact));
                        if (matchingContact == null)
                        {
                            MessageBox.Show("Something went wrong.");
                            return;
                        }
                        else
                            contacts.Add(matchingContact);
                    }

                    var templateFile = Path.Combine(REF.templatesPath, $"{sc.SelectedTemplate}.docx");
                    Engine.DoCustom(Engine.Config.UI.OutputFolder, contacts, sc.GeneratePerContact, templateFile);

                    ////--> use DoCustom here
                    //foreach (var contact in contacts)
                    //    Engine.ExecutionStatus.Result = Engine.GenerateContact(Engine.Config.UI.OutputFolder, contact, sc.GeneratePerContact, templateFile);
                }
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
        private void DoPrint()
        {
            Engine.Config.UI.PrintBuffer = myUI.PrintBuffer;
            Engine.Config.UI.PrintMethod = myUI.PrintMethod;
            Engine.Config.UI.Printer = myUI.Printer;
            //
            Engine.Config.UI.EnvelopSize = myUI.EnvelopSize;
            Engine.Config.UI.EnvelopWidth = myUI.EnvelopWidth;
            Engine.Config.UI.EnvelopHeight = myUI.EnvelopHeight;
            Engine.Config.UI.EnvelopMarginLeft = myUI.EnvelopMarginLeft;
            Engine.Config.UI.EnvelopMarginRight = myUI.EnvelopMarginRight;
            Engine.Config.UI.EnvelopMarginTop = myUI.EnvelopMarginTop;
            Engine.Config.UI.EnvelopMarginBottom = myUI.EnvelopMarginBottom;
            //
            Engine.Config.UI.PostcardSize = myUI.PostcardSize;
            Engine.Config.UI.PostcardWidth = myUI.PostcardWidth;
            Engine.Config.UI.PostcardHeight = myUI.PostcardHeight;
            Engine.Config.UI.PostcardMarginLeft = myUI.PostcardMarginLeft;
            Engine.Config.UI.PostcardMarginRight = myUI.PostcardMarginRight;
            Engine.Config.UI.PostcardMarginTop = myUI.PostcardMarginTop;
            Engine.Config.UI.PostcardMarginBottom = myUI.PostcardMarginBottom;


            var finalDocuments = new List<string>();
            var documentsToPrint = Directory.GetFiles(myUI.OutputFolder, "*.docx").ToList();
            documentsToPrint.RemoveAll(d => d.Contains("~$"));
            switch (myUI.PrintPerContact)
            {
                case REF.Scope.Letter:
                    finalDocuments.AddRange(documentsToPrint.Except(documentsToPrint.Where(d => d.ContainsString(REF.Constants.EnvelopID))));
                    break;
                case REF.Scope.Envelop:
                    finalDocuments.AddRange(documentsToPrint.Where(d => d.ContainsString(REF.Constants.EnvelopID)));
                    break;
                case REF.Scope.LetterAndEnvelop:
                    finalDocuments.AddRange(documentsToPrint);
                    break;
                default:
                    break;
            }
            if (finalDocuments.Count() == 0)
                MessageBox.Show("No suitable Word documents were found in the output folder");

            Engine.PrintAll(finalDocuments);
        }

        private void cboEnvelopSizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedSize = PrinterUtils.PaperSizes[myUI.EnvelopSize];
            if (selectedSize.PaperName == "CUSTOM")
            {
                txtEnvelopWidth.ReadOnly = false;
                txtEnvelopHeight.ReadOnly = false;
            }
            else
            {
                myUI.EnvelopWidth = selectedSize.Width;
                myUI.EnvelopHeight = selectedSize.Height;

                this.Invoke((MethodInvoker)delegate ()
                {
                    txtEnvelopWidth.ReadOnly = true;
                    txtEnvelopHeight.ReadOnly = true;
                });
            }
        }
        private void cboPostcardSizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedSize = PrinterUtils.PaperSizes[myUI.PostcardSize];
            if (selectedSize.PaperName == "CUSTOM")
            {
                txtPostcardWidth.ReadOnly = false;
                txtPostcardHeight.ReadOnly = false;
            }
            else
            {
                myUI.PostcardWidth = selectedSize.Width;
                myUI.PostcardHeight = selectedSize.Height;

                this.Invoke((MethodInvoker)delegate ()
                {
                    txtPostcardWidth.ReadOnly = true;
                    txtPostcardHeight.ReadOnly = true;
                });
            }
        }


        private void txtMargin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!MyExtensions.isNumber(e.KeyChar, (sender as TextBox).Text))
                e.Handled = true;
        }
    }
}
