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
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.rbEnvelop = new System.Windows.Forms.RadioButton();
            this.rbLetter = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContactsFile = new System.Windows.Forms.TextBox();
            this.btnContactsFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.btnGO = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.bgwProcess = new System.ComponentModel.BackgroundWorker();
            this.btnPrintAll = new System.Windows.Forms.Button();
            this.cboPrinters = new System.Windows.Forms.ComboBox();
            this.loadingCircle1 = new CDMailer.LoadingCircle();
            this.gbInputs.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.gbInputs.Controls.Add(this.cboPrinters);
            this.gbInputs.Controls.Add(this.btnPrintAll);
            this.gbInputs.Controls.Add(this.label2);
            this.gbInputs.Controls.Add(this.radioButton3);
            this.gbInputs.Controls.Add(this.rbEnvelop);
            this.gbInputs.Controls.Add(this.rbLetter);
            this.gbInputs.Controls.Add(this.label3);
            this.gbInputs.Controls.Add(this.txtContactsFile);
            this.gbInputs.Controls.Add(this.btnContactsFile);
            this.gbInputs.Controls.Add(this.label1);
            this.gbInputs.Controls.Add(this.txtOutputFolder);
            this.gbInputs.Controls.Add(this.btnOutputFolder);
            this.gbInputs.Location = new System.Drawing.Point(32, 25);
            this.gbInputs.Name = "gbInputs";
            this.gbInputs.Size = new System.Drawing.Size(909, 154);
            this.gbInputs.TabIndex = 10;
            this.gbInputs.TabStop = false;
            this.gbInputs.Text = "Inputs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Generate per contact";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(310, 107);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(103, 17);
            this.radioButton3.TabIndex = 19;
            this.radioButton3.Tag = "LetterAndEnvelop";
            this.radioButton3.Text = "Letter + Envelop";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // rbEnvelop
            // 
            this.rbEnvelop.AutoSize = true;
            this.rbEnvelop.Location = new System.Drawing.Point(213, 107);
            this.rbEnvelop.Name = "rbEnvelop";
            this.rbEnvelop.Size = new System.Drawing.Size(86, 17);
            this.rbEnvelop.TabIndex = 18;
            this.rbEnvelop.Tag = "Envelop";
            this.rbEnvelop.Text = "Envelop only";
            this.rbEnvelop.UseVisualStyleBackColor = true;
            // 
            // rbLetter
            // 
            this.rbLetter.AutoSize = true;
            this.rbLetter.Checked = true;
            this.rbLetter.Location = new System.Drawing.Point(128, 107);
            this.rbLetter.Name = "rbLetter";
            this.rbLetter.Size = new System.Drawing.Size(74, 17);
            this.rbLetter.TabIndex = 17;
            this.rbLetter.TabStop = true;
            this.rbLetter.Tag = "Letter";
            this.rbLetter.Text = "Letter only";
            this.rbLetter.UseVisualStyleBackColor = true;
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
            this.txtContactsFile.Location = new System.Drawing.Point(128, 33);
            this.txtContactsFile.Name = "txtContactsFile";
            this.txtContactsFile.ReadOnly = true;
            this.txtContactsFile.Size = new System.Drawing.Size(647, 20);
            this.txtContactsFile.TabIndex = 14;
            // 
            // btnContactsFile
            // 
            this.btnContactsFile.Location = new System.Drawing.Point(792, 31);
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtResult);
            this.groupBox3.Location = new System.Drawing.Point(33, 238);
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
            this.btnGO.Location = new System.Drawing.Point(866, 209);
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(75, 23);
            this.btnGO.TabIndex = 20;
            this.btnGO.Text = "GO";
            this.btnGO.UseVisualStyleBackColor = true;
            this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(38, 344);
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
            // btnPrintAll
            // 
            this.btnPrintAll.Location = new System.Drawing.Point(443, 104);
            this.btnPrintAll.Name = "btnPrintAll";
            this.btnPrintAll.Size = new System.Drawing.Size(75, 23);
            this.btnPrintAll.TabIndex = 24;
            this.btnPrintAll.Text = "Print All";
            this.btnPrintAll.UseVisualStyleBackColor = true;
            this.btnPrintAll.Click += new System.EventHandler(this.btnPrintAll_Click);
            // 
            // cboPrinters
            // 
            this.cboPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrinters.FormattingEnabled = true;
            this.cboPrinters.Location = new System.Drawing.Point(524, 106);
            this.cboPrinters.Name = "cboPrinters";
            this.cboPrinters.Size = new System.Drawing.Size(343, 21);
            this.cboPrinters.TabIndex = 25;
            // 
            // loadingCircle1
            // 
            this.loadingCircle1.Active = false;
            this.loadingCircle1.Color = System.Drawing.Color.DarkGray;
            this.loadingCircle1.InnerCircleRadius = 6;
            this.loadingCircle1.Location = new System.Drawing.Point(833, 209);
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
            this.ClientSize = new System.Drawing.Size(998, 399);
            this.Controls.Add(this.loadingCircle1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnGO);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gbInputs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Cash Discoveries Mailer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.gbInputs.ResumeLayout(false);
            this.gbInputs.PerformLayout();
            this.groupBox3.ResumeLayout(false);
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
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton rbEnvelop;
        private System.Windows.Forms.RadioButton rbLetter;
        private System.Windows.Forms.Button btnPrintAll;
        private System.Windows.Forms.ComboBox cboPrinters;
    }
}

