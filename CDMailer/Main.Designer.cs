namespace CDMailer
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnOutputFolder = new System.Windows.Forms.Button();
            this.txtOutputFolder = new System.Windows.Forms.TextBox();
            this.gbInputs = new System.Windows.Forms.GroupBox();
            this.btnCustom = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.rbGenLetterAndEnvelop = new System.Windows.Forms.RadioButton();
            this.rbGenEnvelop = new System.Windows.Forms.RadioButton();
            this.rbGenLetter = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContactsFile = new System.Windows.Forms.TextBox();
            this.btnContactsFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboPrinters = new System.Windows.Forms.ComboBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.btnGO = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.bgwProcess = new System.ComponentModel.BackgroundWorker();
            this.gbPrinting = new System.Windows.Forms.GroupBox();
            this.tcPrintingOptions = new System.Windows.Forms.TabControl();
            this.tpEnvelop = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtEnvelopMarginBottom = new System.Windows.Forms.TextBox();
            this.txtEnvelopMarginTop = new System.Windows.Forms.TextBox();
            this.txtEnvelopMarginRight = new System.Windows.Forms.TextBox();
            this.txtEnvelopMarginLeft = new System.Windows.Forms.TextBox();
            this.txtEnvelopHeight = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtEnvelopWidth = new System.Windows.Forms.TextBox();
            this.cboEnvelopSizes = new System.Windows.Forms.ComboBox();
            this.tpPostcard = new System.Windows.Forms.TabPage();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txtPostcardMarginBottom = new System.Windows.Forms.TextBox();
            this.txtPostcardMarginTop = new System.Windows.Forms.TextBox();
            this.txtPostcardMarginRight = new System.Windows.Forms.TextBox();
            this.txtPostcardMarginLeft = new System.Windows.Forms.TextBox();
            this.txtPostcardHeight = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtPostcardWidth = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.cboPostcardSizes = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gpPrintScope = new System.Windows.Forms.Panel();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.numPrintBuffer = new System.Windows.Forms.NumericUpDown();
            this.gpPrintMethod = new System.Windows.Forms.Panel();
            this.rbSpire = new System.Windows.Forms.RadioButton();
            this.rbGnostice = new System.Windows.Forms.RadioButton();
            this.rbAspose = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.bgwProcess2 = new System.ComponentModel.BackgroundWorker();
            this.bgwProcess3 = new System.ComponentModel.BackgroundWorker();
            this.loadingCircle1 = new CDMailer.LoadingCircle();
            this.gbInputs.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbPrinting.SuspendLayout();
            this.tcPrintingOptions.SuspendLayout();
            this.tpEnvelop.SuspendLayout();
            this.tpPostcard.SuspendLayout();
            this.gpPrintScope.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrintBuffer)).BeginInit();
            this.gpPrintMethod.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOutputFolder
            // 
            this.btnOutputFolder.Location = new System.Drawing.Point(792, 66);
            this.btnOutputFolder.Name = "btnOutputFolder";
            this.btnOutputFolder.Size = new System.Drawing.Size(75, 23);
            this.btnOutputFolder.TabIndex = 9;
            this.btnOutputFolder.Text = "Browse";
            this.btnOutputFolder.UseVisualStyleBackColor = true;
            this.btnOutputFolder.Click += new System.EventHandler(this.btnOutputFolder_Click);
            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.Location = new System.Drawing.Point(128, 68);
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.ReadOnly = true;
            this.txtOutputFolder.Size = new System.Drawing.Size(647, 20);
            this.txtOutputFolder.TabIndex = 8;
            // 
            // gbInputs
            // 
            this.gbInputs.Controls.Add(this.btnCustom);
            this.gbInputs.Controls.Add(this.label2);
            this.gbInputs.Controls.Add(this.rbGenLetterAndEnvelop);
            this.gbInputs.Controls.Add(this.rbGenEnvelop);
            this.gbInputs.Controls.Add(this.rbGenLetter);
            this.gbInputs.Controls.Add(this.label3);
            this.gbInputs.Controls.Add(this.txtContactsFile);
            this.gbInputs.Controls.Add(this.btnContactsFile);
            this.gbInputs.Controls.Add(this.label1);
            this.gbInputs.Controls.Add(this.txtOutputFolder);
            this.gbInputs.Controls.Add(this.btnOutputFolder);
            this.gbInputs.Location = new System.Drawing.Point(32, 25);
            this.gbInputs.Name = "gbInputs";
            this.gbInputs.Size = new System.Drawing.Size(909, 150);
            this.gbInputs.TabIndex = 10;
            this.gbInputs.TabStop = false;
            this.gbInputs.Text = "Inputs";
            // 
            // btnCustom
            // 
            this.btnCustom.Location = new System.Drawing.Point(758, 106);
            this.btnCustom.Name = "btnCustom";
            this.btnCustom.Size = new System.Drawing.Size(109, 23);
            this.btnCustom.TabIndex = 28;
            this.btnCustom.Text = "Custom";
            this.btnCustom.UseVisualStyleBackColor = true;
            this.btnCustom.Click += new System.EventHandler(this.btnCustom_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Generate";
            // 
            // rbGenLetterAndEnvelop
            // 
            this.rbGenLetterAndEnvelop.AutoSize = true;
            this.rbGenLetterAndEnvelop.Location = new System.Drawing.Point(310, 112);
            this.rbGenLetterAndEnvelop.Name = "rbGenLetterAndEnvelop";
            this.rbGenLetterAndEnvelop.Size = new System.Drawing.Size(103, 17);
            this.rbGenLetterAndEnvelop.TabIndex = 19;
            this.rbGenLetterAndEnvelop.Tag = "LetterAndEnvelop";
            this.rbGenLetterAndEnvelop.Text = "Letter + Envelop";
            this.rbGenLetterAndEnvelop.UseVisualStyleBackColor = true;
            // 
            // rbGenEnvelop
            // 
            this.rbGenEnvelop.AutoSize = true;
            this.rbGenEnvelop.Location = new System.Drawing.Point(213, 112);
            this.rbGenEnvelop.Name = "rbGenEnvelop";
            this.rbGenEnvelop.Size = new System.Drawing.Size(86, 17);
            this.rbGenEnvelop.TabIndex = 18;
            this.rbGenEnvelop.Tag = "Envelop";
            this.rbGenEnvelop.Text = "Envelop only";
            this.rbGenEnvelop.UseVisualStyleBackColor = true;
            // 
            // rbGenLetter
            // 
            this.rbGenLetter.AutoSize = true;
            this.rbGenLetter.Checked = true;
            this.rbGenLetter.Location = new System.Drawing.Point(128, 112);
            this.rbGenLetter.Name = "rbGenLetter";
            this.rbGenLetter.Size = new System.Drawing.Size(74, 17);
            this.rbGenLetter.TabIndex = 17;
            this.rbGenLetter.TabStop = true;
            this.rbGenLetter.Tag = "Letter";
            this.rbGenLetter.Text = "Letter only";
            this.rbGenLetter.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Input csv path";
            // 
            // txtContactsFile
            // 
            this.txtContactsFile.Location = new System.Drawing.Point(128, 32);
            this.txtContactsFile.Name = "txtContactsFile";
            this.txtContactsFile.ReadOnly = true;
            this.txtContactsFile.Size = new System.Drawing.Size(647, 20);
            this.txtContactsFile.TabIndex = 14;
            // 
            // btnContactsFile
            // 
            this.btnContactsFile.Location = new System.Drawing.Point(792, 32);
            this.btnContactsFile.Name = "btnContactsFile";
            this.btnContactsFile.Size = new System.Drawing.Size(75, 23);
            this.btnContactsFile.TabIndex = 15;
            this.btnContactsFile.Text = "Browse";
            this.btnContactsFile.UseVisualStyleBackColor = true;
            this.btnContactsFile.Click += new System.EventHandler(this.btnContactsFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Output Folder";
            // 
            // cboPrinters
            // 
            this.cboPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrinters.FormattingEnabled = true;
            this.cboPrinters.Location = new System.Drawing.Point(74, 23);
            this.cboPrinters.Name = "cboPrinters";
            this.cboPrinters.Size = new System.Drawing.Size(343, 21);
            this.cboPrinters.TabIndex = 25;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(768, 42);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(95, 112);
            this.btnPrint.TabIndex = 24;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtResult);
            this.groupBox3.Location = new System.Drawing.Point(36, 407);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(906, 100);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Results";
            // 
            // txtResult
            // 
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.Location = new System.Drawing.Point(3, 16);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(900, 81);
            this.txtResult.TabIndex = 0;
            this.txtResult.Text = "";
            // 
            // btnGO
            // 
            this.btnGO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGO.Location = new System.Drawing.Point(866, 183);
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(75, 23);
            this.btnGO.TabIndex = 20;
            this.btnGO.Text = "GO";
            this.btnGO.UseVisualStyleBackColor = true;
            this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(961, 161);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 22;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Visible = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // bgwProcess
            // 
            this.bgwProcess.WorkerReportsProgress = true;
            this.bgwProcess.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwProcess_DoWork);
            this.bgwProcess.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwProcess_RunWorkerCompleted);
            // 
            // gbPrinting
            // 
            this.gbPrinting.Controls.Add(this.tcPrintingOptions);
            this.gbPrinting.Controls.Add(this.btnPrint);
            this.gbPrinting.Controls.Add(this.label10);
            this.gbPrinting.Controls.Add(this.label7);
            this.gbPrinting.Controls.Add(this.label5);
            this.gbPrinting.Controls.Add(this.gpPrintScope);
            this.gbPrinting.Controls.Add(this.label4);
            this.gbPrinting.Controls.Add(this.numPrintBuffer);
            this.gbPrinting.Controls.Add(this.cboPrinters);
            this.gbPrinting.Location = new System.Drawing.Point(36, 213);
            this.gbPrinting.Name = "gbPrinting";
            this.gbPrinting.Size = new System.Drawing.Size(905, 176);
            this.gbPrinting.TabIndex = 24;
            this.gbPrinting.TabStop = false;
            this.gbPrinting.Text = "Printing";
            // 
            // tcPrintingOptions
            // 
            this.tcPrintingOptions.Controls.Add(this.tpEnvelop);
            this.tcPrintingOptions.Controls.Add(this.tpPostcard);
            this.tcPrintingOptions.Location = new System.Drawing.Point(440, 23);
            this.tcPrintingOptions.Name = "tcPrintingOptions";
            this.tcPrintingOptions.SelectedIndex = 0;
            this.tcPrintingOptions.Size = new System.Drawing.Size(321, 131);
            this.tcPrintingOptions.TabIndex = 31;
            // 
            // tpEnvelop
            // 
            this.tpEnvelop.BackColor = System.Drawing.SystemColors.Control;
            this.tpEnvelop.Controls.Add(this.label11);
            this.tpEnvelop.Controls.Add(this.label16);
            this.tpEnvelop.Controls.Add(this.label17);
            this.tpEnvelop.Controls.Add(this.label18);
            this.tpEnvelop.Controls.Add(this.txtEnvelopMarginBottom);
            this.tpEnvelop.Controls.Add(this.txtEnvelopMarginTop);
            this.tpEnvelop.Controls.Add(this.txtEnvelopMarginRight);
            this.tpEnvelop.Controls.Add(this.txtEnvelopMarginLeft);
            this.tpEnvelop.Controls.Add(this.txtEnvelopHeight);
            this.tpEnvelop.Controls.Add(this.label19);
            this.tpEnvelop.Controls.Add(this.txtEnvelopWidth);
            this.tpEnvelop.Controls.Add(this.cboEnvelopSizes);
            this.tpEnvelop.Location = new System.Drawing.Point(4, 22);
            this.tpEnvelop.Name = "tpEnvelop";
            this.tpEnvelop.Padding = new System.Windows.Forms.Padding(3);
            this.tpEnvelop.Size = new System.Drawing.Size(313, 105);
            this.tpEnvelop.TabIndex = 0;
            this.tpEnvelop.Text = "Envelop";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(150, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 13);
            this.label11.TabIndex = 61;
            this.label11.Text = "T";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(220, 59);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(14, 13);
            this.label16.TabIndex = 60;
            this.label16.Text = "B";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(80, 59);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(15, 13);
            this.label17.TabIndex = 59;
            this.label17.Text = "R";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(10, 60);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(13, 13);
            this.label18.TabIndex = 58;
            this.label18.Text = "L";
            // 
            // txtEnvelopMarginBottom
            // 
            this.txtEnvelopMarginBottom.Location = new System.Drawing.Point(223, 75);
            this.txtEnvelopMarginBottom.Name = "txtEnvelopMarginBottom";
            this.txtEnvelopMarginBottom.Size = new System.Drawing.Size(64, 20);
            this.txtEnvelopMarginBottom.TabIndex = 57;
            this.txtEnvelopMarginBottom.Text = "0";
            this.txtEnvelopMarginBottom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMargin_KeyPress);
            // 
            // txtEnvelopMarginTop
            // 
            this.txtEnvelopMarginTop.Location = new System.Drawing.Point(153, 75);
            this.txtEnvelopMarginTop.Name = "txtEnvelopMarginTop";
            this.txtEnvelopMarginTop.Size = new System.Drawing.Size(64, 20);
            this.txtEnvelopMarginTop.TabIndex = 56;
            this.txtEnvelopMarginTop.Text = "0";
            this.txtEnvelopMarginTop.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMargin_KeyPress);
            // 
            // txtEnvelopMarginRight
            // 
            this.txtEnvelopMarginRight.Location = new System.Drawing.Point(83, 75);
            this.txtEnvelopMarginRight.Name = "txtEnvelopMarginRight";
            this.txtEnvelopMarginRight.Size = new System.Drawing.Size(64, 20);
            this.txtEnvelopMarginRight.TabIndex = 55;
            this.txtEnvelopMarginRight.Text = "0";
            this.txtEnvelopMarginRight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMargin_KeyPress);
            // 
            // txtEnvelopMarginLeft
            // 
            this.txtEnvelopMarginLeft.Location = new System.Drawing.Point(13, 75);
            this.txtEnvelopMarginLeft.Name = "txtEnvelopMarginLeft";
            this.txtEnvelopMarginLeft.Size = new System.Drawing.Size(64, 20);
            this.txtEnvelopMarginLeft.TabIndex = 54;
            this.txtEnvelopMarginLeft.Text = "0";
            this.txtEnvelopMarginLeft.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMargin_KeyPress);
            // 
            // txtEnvelopHeight
            // 
            this.txtEnvelopHeight.Location = new System.Drawing.Point(210, 28);
            this.txtEnvelopHeight.Name = "txtEnvelopHeight";
            this.txtEnvelopHeight.ReadOnly = true;
            this.txtEnvelopHeight.Size = new System.Drawing.Size(64, 20);
            this.txtEnvelopHeight.TabIndex = 53;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(197, 32);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(12, 13);
            this.label19.TabIndex = 52;
            this.label19.Text = "x";
            // 
            // txtEnvelopWidth
            // 
            this.txtEnvelopWidth.Location = new System.Drawing.Point(129, 28);
            this.txtEnvelopWidth.Name = "txtEnvelopWidth";
            this.txtEnvelopWidth.ReadOnly = true;
            this.txtEnvelopWidth.Size = new System.Drawing.Size(64, 20);
            this.txtEnvelopWidth.TabIndex = 51;
            // 
            // cboEnvelopSizes
            // 
            this.cboEnvelopSizes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEnvelopSizes.FormattingEnabled = true;
            this.cboEnvelopSizes.Location = new System.Drawing.Point(13, 27);
            this.cboEnvelopSizes.Name = "cboEnvelopSizes";
            this.cboEnvelopSizes.Size = new System.Drawing.Size(109, 21);
            this.cboEnvelopSizes.TabIndex = 49;
            this.cboEnvelopSizes.SelectedIndexChanged += new System.EventHandler(this.cboEnvelopSizes_SelectedIndexChanged);
            // 
            // tpPostcard
            // 
            this.tpPostcard.BackColor = System.Drawing.SystemColors.Control;
            this.tpPostcard.Controls.Add(this.label21);
            this.tpPostcard.Controls.Add(this.label22);
            this.tpPostcard.Controls.Add(this.label23);
            this.tpPostcard.Controls.Add(this.label24);
            this.tpPostcard.Controls.Add(this.txtPostcardMarginBottom);
            this.tpPostcard.Controls.Add(this.txtPostcardMarginTop);
            this.tpPostcard.Controls.Add(this.txtPostcardMarginRight);
            this.tpPostcard.Controls.Add(this.txtPostcardMarginLeft);
            this.tpPostcard.Controls.Add(this.txtPostcardHeight);
            this.tpPostcard.Controls.Add(this.label25);
            this.tpPostcard.Controls.Add(this.txtPostcardWidth);
            this.tpPostcard.Controls.Add(this.label26);
            this.tpPostcard.Controls.Add(this.cboPostcardSizes);
            this.tpPostcard.Location = new System.Drawing.Point(4, 22);
            this.tpPostcard.Name = "tpPostcard";
            this.tpPostcard.Padding = new System.Windows.Forms.Padding(3);
            this.tpPostcard.Size = new System.Drawing.Size(313, 105);
            this.tpPostcard.TabIndex = 1;
            this.tpPostcard.Text = "Postcard";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(150, 60);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(14, 13);
            this.label21.TabIndex = 61;
            this.label21.Text = "T";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(220, 59);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(14, 13);
            this.label22.TabIndex = 60;
            this.label22.Text = "B";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(80, 59);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(15, 13);
            this.label23.TabIndex = 59;
            this.label23.Text = "R";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(10, 60);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(13, 13);
            this.label24.TabIndex = 58;
            this.label24.Text = "L";
            // 
            // txtPostcardMarginBottom
            // 
            this.txtPostcardMarginBottom.Location = new System.Drawing.Point(223, 75);
            this.txtPostcardMarginBottom.Name = "txtPostcardMarginBottom";
            this.txtPostcardMarginBottom.Size = new System.Drawing.Size(64, 20);
            this.txtPostcardMarginBottom.TabIndex = 57;
            this.txtPostcardMarginBottom.Text = "150";
            this.txtPostcardMarginBottom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMargin_KeyPress);
            // 
            // txtPostcardMarginTop
            // 
            this.txtPostcardMarginTop.Location = new System.Drawing.Point(153, 75);
            this.txtPostcardMarginTop.Name = "txtPostcardMarginTop";
            this.txtPostcardMarginTop.Size = new System.Drawing.Size(64, 20);
            this.txtPostcardMarginTop.TabIndex = 56;
            this.txtPostcardMarginTop.Text = "150";
            this.txtPostcardMarginTop.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMargin_KeyPress);
            // 
            // txtPostcardMarginRight
            // 
            this.txtPostcardMarginRight.Location = new System.Drawing.Point(83, 75);
            this.txtPostcardMarginRight.Name = "txtPostcardMarginRight";
            this.txtPostcardMarginRight.Size = new System.Drawing.Size(64, 20);
            this.txtPostcardMarginRight.TabIndex = 55;
            this.txtPostcardMarginRight.Text = "125";
            this.txtPostcardMarginRight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMargin_KeyPress);
            // 
            // txtPostcardMarginLeft
            // 
            this.txtPostcardMarginLeft.Location = new System.Drawing.Point(13, 75);
            this.txtPostcardMarginLeft.Name = "txtPostcardMarginLeft";
            this.txtPostcardMarginLeft.Size = new System.Drawing.Size(64, 20);
            this.txtPostcardMarginLeft.TabIndex = 54;
            this.txtPostcardMarginLeft.Text = "125";
            this.txtPostcardMarginLeft.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMargin_KeyPress);
            // 
            // txtPostcardHeight
            // 
            this.txtPostcardHeight.Location = new System.Drawing.Point(210, 28);
            this.txtPostcardHeight.Name = "txtPostcardHeight";
            this.txtPostcardHeight.ReadOnly = true;
            this.txtPostcardHeight.Size = new System.Drawing.Size(64, 20);
            this.txtPostcardHeight.TabIndex = 53;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(197, 32);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(12, 13);
            this.label25.TabIndex = 52;
            this.label25.Text = "x";
            // 
            // txtPostcardWidth
            // 
            this.txtPostcardWidth.Location = new System.Drawing.Point(129, 28);
            this.txtPostcardWidth.Name = "txtPostcardWidth";
            this.txtPostcardWidth.ReadOnly = true;
            this.txtPostcardWidth.Size = new System.Drawing.Size(64, 20);
            this.txtPostcardWidth.TabIndex = 51;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(10, 11);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(130, 13);
            this.label26.TabIndex = 50;
            this.label26.Text = "*Envelop && Postcard Size:";
            // 
            // cboPostcardSizes
            // 
            this.cboPostcardSizes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPostcardSizes.FormattingEnabled = true;
            this.cboPostcardSizes.Location = new System.Drawing.Point(13, 27);
            this.cboPostcardSizes.Name = "cboPostcardSizes";
            this.cboPostcardSizes.Size = new System.Drawing.Size(109, 21);
            this.cboPostcardSizes.TabIndex = 49;
            this.cboPostcardSizes.SelectedIndexChanged += new System.EventHandler(this.cboPostcardSizes_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(437, 156);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(314, 13);
            this.label10.TabIndex = 39;
            this.label10.Text = "*Used only for Envelops. Other documents are A4 with 0 margins.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "wait";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Printer:";
            // 
            // gpPrintScope
            // 
            this.gpPrintScope.Controls.Add(this.radioButton6);
            this.gpPrintScope.Controls.Add(this.label8);
            this.gpPrintScope.Controls.Add(this.radioButton4);
            this.gpPrintScope.Controls.Add(this.radioButton5);
            this.gpPrintScope.Location = new System.Drawing.Point(29, 90);
            this.gpPrintScope.Name = "gpPrintScope";
            this.gpPrintScope.Size = new System.Drawing.Size(322, 60);
            this.gpPrintScope.TabIndex = 31;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(197, 31);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(113, 17);
            this.radioButton6.TabIndex = 35;
            this.radioButton6.Tag = "LetterAndEnvelop";
            this.radioButton6.Text = "Letters + Envelops";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Printing Target:";
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Checked = true;
            this.radioButton4.Location = new System.Drawing.Point(15, 30);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(79, 17);
            this.radioButton4.TabIndex = 26;
            this.radioButton4.TabStop = true;
            this.radioButton4.Tag = "Letter";
            this.radioButton4.Text = "Letters only";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(100, 31);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(91, 17);
            this.radioButton5.TabIndex = 27;
            this.radioButton5.Tag = "Envelop";
            this.radioButton5.Text = "Envelops only";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(118, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "seconds between documents (max 20)";
            // 
            // numPrintBuffer
            // 
            this.numPrintBuffer.Location = new System.Drawing.Point(73, 60);
            this.numPrintBuffer.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numPrintBuffer.Name = "numPrintBuffer";
            this.numPrintBuffer.Size = new System.Drawing.Size(38, 20);
            this.numPrintBuffer.TabIndex = 28;
            // 
            // gpPrintMethod
            // 
            this.gpPrintMethod.Controls.Add(this.rbSpire);
            this.gpPrintMethod.Controls.Add(this.rbGnostice);
            this.gpPrintMethod.Controls.Add(this.rbAspose);
            this.gpPrintMethod.Controls.Add(this.radioButton1);
            this.gpPrintMethod.Controls.Add(this.radioButton2);
            this.gpPrintMethod.Location = new System.Drawing.Point(963, 202);
            this.gpPrintMethod.Name = "gpPrintMethod";
            this.gpPrintMethod.Size = new System.Drawing.Size(304, 100);
            this.gpPrintMethod.TabIndex = 30;
            this.gpPrintMethod.Visible = false;
            // 
            // rbSpire
            // 
            this.rbSpire.AutoSize = true;
            this.rbSpire.Checked = true;
            this.rbSpire.Location = new System.Drawing.Point(193, 30);
            this.rbSpire.Name = "rbSpire";
            this.rbSpire.Size = new System.Drawing.Size(49, 17);
            this.rbSpire.TabIndex = 30;
            this.rbSpire.TabStop = true;
            this.rbSpire.Tag = "PrintWithSpire";
            this.rbSpire.Text = "Spire";
            this.rbSpire.UseVisualStyleBackColor = true;
            // 
            // rbGnostice
            // 
            this.rbGnostice.AutoSize = true;
            this.rbGnostice.Location = new System.Drawing.Point(108, 53);
            this.rbGnostice.Name = "rbGnostice";
            this.rbGnostice.Size = new System.Drawing.Size(67, 17);
            this.rbGnostice.TabIndex = 29;
            this.rbGnostice.Tag = "PrintWithGnostice";
            this.rbGnostice.Text = "Gnostice";
            this.rbGnostice.UseVisualStyleBackColor = true;
            // 
            // rbAspose
            // 
            this.rbAspose.AutoSize = true;
            this.rbAspose.Location = new System.Drawing.Point(108, 30);
            this.rbAspose.Name = "rbAspose";
            this.rbAspose.Size = new System.Drawing.Size(60, 17);
            this.rbAspose.TabIndex = 28;
            this.rbAspose.Tag = "PrintWithAspose";
            this.rbAspose.Text = "Aspose";
            this.rbAspose.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(15, 30);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(72, 17);
            this.radioButton1.TabIndex = 26;
            this.radioButton1.Tag = "PrintWithNoDialog";
            this.radioButton1.Text = "No Dialog";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(15, 53);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(58, 17);
            this.radioButton2.TabIndex = 27;
            this.radioButton2.Tag = "PrintWithInterop";
            this.radioButton2.Text = "Interop";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // bgwProcess2
            // 
            this.bgwProcess2.WorkerReportsProgress = true;
            this.bgwProcess2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwProcess2_DoWork);
            this.bgwProcess2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwProcess2_RunWorkerCompleted);
            // 
            // bgwProcess3
            // 
            this.bgwProcess3.WorkerReportsProgress = true;
            this.bgwProcess3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwProcess3_DoWork);
            this.bgwProcess3.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwProcess3_RunWorkerCompleted);
            // 
            // loadingCircle1
            // 
            this.loadingCircle1.Active = false;
            this.loadingCircle1.Color = System.Drawing.Color.DarkGray;
            this.loadingCircle1.InnerCircleRadius = 6;
            this.loadingCircle1.Location = new System.Drawing.Point(833, 183);
            this.loadingCircle1.Name = "loadingCircle1";
            this.loadingCircle1.OuterCircleRadius = 7;
            this.loadingCircle1.RotationSpeed = 100;
            this.loadingCircle1.Size = new System.Drawing.Size(27, 23);
            this.loadingCircle1.SpokeCount = 9;
            this.loadingCircle1.SpokeThickness = 4;
            this.loadingCircle1.TabIndex = 23;
            this.loadingCircle1.Text = "Working";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 537);
            this.Controls.Add(this.gbPrinting);
            this.Controls.Add(this.loadingCircle1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnGO);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gpPrintMethod);
            this.Controls.Add(this.gbInputs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Cash Discoveries Mailer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.gbInputs.ResumeLayout(false);
            this.gbInputs.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.gbPrinting.ResumeLayout(false);
            this.gbPrinting.PerformLayout();
            this.tcPrintingOptions.ResumeLayout(false);
            this.tpEnvelop.ResumeLayout(false);
            this.tpEnvelop.PerformLayout();
            this.tpPostcard.ResumeLayout(false);
            this.tpPostcard.PerformLayout();
            this.gpPrintScope.ResumeLayout(false);
            this.gpPrintScope.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrintBuffer)).EndInit();
            this.gpPrintMethod.ResumeLayout(false);
            this.gpPrintMethod.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOutputFolder;
        private System.Windows.Forms.TextBox txtOutputFolder;
        private System.Windows.Forms.GroupBox gbInputs;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox txtResult;
        private System.Windows.Forms.Button btnGO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtContactsFile;
        private System.Windows.Forms.Button btnContactsFile;
        private System.Windows.Forms.Button btnReset;
        private LoadingCircle loadingCircle1;
        private System.ComponentModel.BackgroundWorker bgwProcess;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbGenLetterAndEnvelop;
        private System.Windows.Forms.RadioButton rbGenEnvelop;
        private System.Windows.Forms.RadioButton rbGenLetter;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ComboBox cboPrinters;
        private System.Windows.Forms.GroupBox gbPrinting;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numPrintBuffer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel gpPrintScope;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.Panel gpPrintMethod;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton rbGnostice;
        private System.Windows.Forms.RadioButton rbAspose;
        private System.Windows.Forms.Button btnCustom;
        private System.ComponentModel.BackgroundWorker bgwProcess2;
        private System.Windows.Forms.RadioButton rbSpire;
        private System.ComponentModel.BackgroundWorker bgwProcess3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabControl tcPrintingOptions;
        private System.Windows.Forms.TabPage tpEnvelop;
        private System.Windows.Forms.TabPage tpPostcard;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtEnvelopMarginBottom;
        private System.Windows.Forms.TextBox txtEnvelopMarginTop;
        private System.Windows.Forms.TextBox txtEnvelopMarginRight;
        private System.Windows.Forms.TextBox txtEnvelopMarginLeft;
        private System.Windows.Forms.TextBox txtEnvelopHeight;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtEnvelopWidth;
        private System.Windows.Forms.ComboBox cboEnvelopSizes;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtPostcardMarginBottom;
        private System.Windows.Forms.TextBox txtPostcardMarginTop;
        private System.Windows.Forms.TextBox txtPostcardMarginRight;
        private System.Windows.Forms.TextBox txtPostcardMarginLeft;
        private System.Windows.Forms.TextBox txtPostcardHeight;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtPostcardWidth;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox cboPostcardSizes;
    }
}

