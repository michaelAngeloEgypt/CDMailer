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
            this.label9 = new System.Windows.Forms.Label();
            this.cboEnvelopSizes = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gpPrintScope = new System.Windows.Forms.Panel();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.gpPrintMethod = new System.Windows.Forms.Panel();
            this.rbSpire = new System.Windows.Forms.RadioButton();
            this.rbGnostice = new System.Windows.Forms.RadioButton();
            this.rbAspose = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.numPrintBuffer = new System.Windows.Forms.NumericUpDown();
            this.bgwProcess2 = new System.ComponentModel.BackgroundWorker();
            this.bgwProcess3 = new System.ComponentModel.BackgroundWorker();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.loadingCircle1 = new CDMailer.LoadingCircle();
            this.label10 = new System.Windows.Forms.Label();
            this.gbInputs.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbPrinting.SuspendLayout();
            this.gpPrintScope.SuspendLayout();
            this.gpPrintMethod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrintBuffer)).BeginInit();
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
            this.btnPrint.Location = new System.Drawing.Point(566, 103);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(302, 36);
            this.btnPrint.TabIndex = 24;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtResult);
            this.groupBox3.Location = new System.Drawing.Point(33, 384);
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
            this.gbPrinting.Controls.Add(this.label10);
            this.gbPrinting.Controls.Add(this.txtHeight);
            this.gbPrinting.Controls.Add(this.label6);
            this.gbPrinting.Controls.Add(this.txtWidth);
            this.gbPrinting.Controls.Add(this.label9);
            this.gbPrinting.Controls.Add(this.cboEnvelopSizes);
            this.gbPrinting.Controls.Add(this.label7);
            this.gbPrinting.Controls.Add(this.label5);
            this.gbPrinting.Controls.Add(this.gpPrintScope);
            this.gbPrinting.Controls.Add(this.label4);
            this.gbPrinting.Controls.Add(this.numPrintBuffer);
            this.gbPrinting.Controls.Add(this.btnPrint);
            this.gbPrinting.Controls.Add(this.cboPrinters);
            this.gbPrinting.Location = new System.Drawing.Point(36, 213);
            this.gbPrinting.Name = "gbPrinting";
            this.gbPrinting.Size = new System.Drawing.Size(905, 165);
            this.gbPrinting.TabIndex = 24;
            this.gbPrinting.TabStop = false;
            this.gbPrinting.Text = "Printing";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(563, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "*Envelop && Postcard Size:";
            // 
            // cboEnvelopSizes
            // 
            this.cboEnvelopSizes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEnvelopSizes.FormattingEnabled = true;
            this.cboEnvelopSizes.Location = new System.Drawing.Point(566, 76);
            this.cboEnvelopSizes.Name = "cboEnvelopSizes";
            this.cboEnvelopSizes.Size = new System.Drawing.Size(109, 21);
            this.cboEnvelopSizes.TabIndex = 34;
            this.cboEnvelopSizes.SelectedIndexChanged += new System.EventHandler(this.cboEnvelopSizes_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(423, 26);
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
            this.gpPrintScope.Location = new System.Drawing.Point(29, 74);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(500, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "seconds between documents (max 20)";
            // 
            // numPrintBuffer
            // 
            this.numPrintBuffer.Location = new System.Drawing.Point(455, 23);
            this.numPrintBuffer.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numPrintBuffer.Name = "numPrintBuffer";
            this.numPrintBuffer.Size = new System.Drawing.Size(38, 20);
            this.numPrintBuffer.TabIndex = 28;
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
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(682, 77);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.ReadOnly = true;
            this.txtWidth.Size = new System.Drawing.Size(64, 20);
            this.txtWidth.TabIndex = 36;
            this.txtWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumbersOnly);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(750, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "x";
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(763, 77);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.ReadOnly = true;
            this.txtHeight.Size = new System.Drawing.Size(64, 20);
            this.txtHeight.TabIndex = 38;
            this.txtHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumbersOnly);
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(563, 142);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(312, 13);
            this.label10.TabIndex = 39;
            this.label10.Text = "*Used only for Envelops and Postcards. Other documents are A4";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 520);
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
            this.gpPrintScope.ResumeLayout(false);
            this.gpPrintScope.PerformLayout();
            this.gpPrintMethod.ResumeLayout(false);
            this.gpPrintMethod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrintBuffer)).EndInit();
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
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboEnvelopSizes;
        private System.ComponentModel.BackgroundWorker bgwProcess3;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label10;
    }
}

