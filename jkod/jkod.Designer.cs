namespace jkod
{
    partial class jkodForm
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
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxSizeSuffix = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSkip = new System.Windows.Forms.TextBox();
            this.chkVerbose = new System.Windows.Forms.CheckBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cbxBytesPerLine = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxColumnWidth = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxBaseList = new System.Windows.Forms.ComboBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtOutput
            // 
            this.txtOutput.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.Location = new System.Drawing.Point(12, 25);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(723, 328);
            this.txtOutput.TabIndex = 0;
            this.txtOutput.WordWrap = false;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(753, 40);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(117, 28);
            this.btnOpen.TabIndex = 8;
            this.btnOpen.Text = "Open File...";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxSizeSuffix);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSkip);
            this.groupBox1.Controls.Add(this.chkVerbose);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.cbxBytesPerLine);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbxColumnWidth);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbxBaseList);
            this.groupBox1.Location = new System.Drawing.Point(12, 359);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(866, 81);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // cbxSizeSuffix
            // 
            this.cbxSizeSuffix.FormattingEnabled = true;
            this.cbxSizeSuffix.Items.AddRange(new object[] {
            "B",
            "KB",
            "MB"});
            this.cbxSizeSuffix.Location = new System.Drawing.Point(593, 43);
            this.cbxSizeSuffix.Name = "cbxSizeSuffix";
            this.cbxSizeSuffix.Size = new System.Drawing.Size(39, 21);
            this.cbxSizeSuffix.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(484, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Skip Ahead:";
            // 
            // txtSkip
            // 
            this.txtSkip.Location = new System.Drawing.Point(487, 43);
            this.txtSkip.Name = "txtSkip";
            this.txtSkip.Size = new System.Drawing.Size(100, 20);
            this.txtSkip.TabIndex = 5;
            // 
            // chkVerbose
            // 
            this.chkVerbose.AutoSize = true;
            this.chkVerbose.Location = new System.Drawing.Point(724, 47);
            this.chkVerbose.Name = "chkVerbose";
            this.chkVerbose.Size = new System.Drawing.Size(118, 17);
            this.chkVerbose.TabIndex = 7;
            this.chkVerbose.Text = "Hide duplicate lines";
            this.chkVerbose.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(767, 17);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cbxBytesPerLine
            // 
            this.cbxBytesPerLine.Items.AddRange(new object[] {
            "16",
            "32",
            "64",
            "128"});
            this.cbxBytesPerLine.Location = new System.Drawing.Point(350, 43);
            this.cbxBytesPerLine.Name = "cbxBytesPerLine";
            this.cbxBytesPerLine.Size = new System.Drawing.Size(121, 21);
            this.cbxBytesPerLine.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(347, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Bytes Per Line:";
            // 
            // cbxColumnWidth
            // 
            this.cbxColumnWidth.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8"});
            this.cbxColumnWidth.Location = new System.Drawing.Point(213, 43);
            this.cbxColumnWidth.Name = "cbxColumnWidth";
            this.cbxColumnWidth.Size = new System.Drawing.Size(73, 21);
            this.cbxColumnWidth.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Column Width (bytes):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Base:";
            // 
            // cbxBaseList
            // 
            this.cbxBaseList.Items.AddRange(new object[] {
            "Octal (base 8)",
            "Hexadecimal (base 16)",
            "Signed Decimal (base 10)"});
            this.cbxBaseList.Location = new System.Drawing.Point(9, 43);
            this.cbxBaseList.Name = "cbxBaseList";
            this.cbxBaseList.Size = new System.Drawing.Size(179, 21);
            this.cbxBaseList.TabIndex = 2;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "dump";
            this.saveFileDialog1.Filter = "Dump file|*.dump|Text file|*.txt|All files|*.*";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(753, 87);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 28);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save File...";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // jkodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 445);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.txtOutput);
            this.Name = "jkodForm";
            this.Text = "jkod";
            this.Load += new System.EventHandler(this.jkod_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxBaseList;
        private System.Windows.Forms.ComboBox cbxBytesPerLine;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxColumnWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbxSizeSuffix;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSkip;
        private System.Windows.Forms.CheckBox chkVerbose;
    }
}

