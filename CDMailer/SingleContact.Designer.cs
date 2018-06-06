namespace CDMailer
{
    partial class SingleContact
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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboContactNames = new System.Windows.Forms.ComboBox();
            this.cboTemplateNames = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOutputFolder = new System.Windows.Forms.TextBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.rbEnvelop = new System.Windows.Forms.RadioButton();
            this.rbLetter = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(723, 126);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Contact Name";
            // 
            // cboContactNames
            // 
            this.cboContactNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboContactNames.FormattingEnabled = true;
            this.cboContactNames.Location = new System.Drawing.Point(124, 36);
            this.cboContactNames.Name = "cboContactNames";
            this.cboContactNames.Size = new System.Drawing.Size(281, 21);
            this.cboContactNames.TabIndex = 2;
            // 
            // cboTemplateNames
            // 
            this.cboTemplateNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTemplateNames.FormattingEnabled = true;
            this.cboTemplateNames.Location = new System.Drawing.Point(517, 36);
            this.cboTemplateNames.Name = "cboTemplateNames";
            this.cboTemplateNames.Size = new System.Drawing.Size(281, 21);
            this.cboTemplateNames.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(434, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Template Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Output Folder";
            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.Location = new System.Drawing.Point(124, 66);
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.ReadOnly = true;
            this.txtOutputFolder.Size = new System.Drawing.Size(674, 20);
            this.txtOutputFolder.TabIndex = 11;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(696, 96);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(103, 17);
            this.radioButton3.TabIndex = 23;
            this.radioButton3.Tag = "LetterAndEnvelop";
            this.radioButton3.Text = "Letter + Envelop";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // rbEnvelop
            // 
            this.rbEnvelop.AutoSize = true;
            this.rbEnvelop.Location = new System.Drawing.Point(599, 96);
            this.rbEnvelop.Name = "rbEnvelop";
            this.rbEnvelop.Size = new System.Drawing.Size(86, 17);
            this.rbEnvelop.TabIndex = 22;
            this.rbEnvelop.Tag = "Envelop";
            this.rbEnvelop.Text = "Envelop only";
            this.rbEnvelop.UseVisualStyleBackColor = true;
            // 
            // rbLetter
            // 
            this.rbLetter.AutoSize = true;
            this.rbLetter.Checked = true;
            this.rbLetter.Location = new System.Drawing.Point(514, 96);
            this.rbLetter.Name = "rbLetter";
            this.rbLetter.Size = new System.Drawing.Size(74, 17);
            this.rbLetter.TabIndex = 21;
            this.rbLetter.TabStop = true;
            this.rbLetter.Tag = "Letter";
            this.rbLetter.Text = "Letter only";
            this.rbLetter.UseVisualStyleBackColor = true;
            // 
            // SingleContact
            // 
            this.AcceptButton = this.btnGenerate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 161);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.rbEnvelop);
            this.Controls.Add(this.rbLetter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOutputFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboTemplateNames);
            this.Controls.Add(this.cboContactNames);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGenerate);
            this.Name = "SingleContact";
            this.Text = "Single Contact";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboContactNames;
        private System.Windows.Forms.ComboBox cboTemplateNames;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOutputFolder;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton rbEnvelop;
        private System.Windows.Forms.RadioButton rbLetter;
    }
}