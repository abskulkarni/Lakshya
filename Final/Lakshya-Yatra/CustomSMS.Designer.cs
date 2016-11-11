namespace Lakshya_Yatra
{
    partial class CustomSMS
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbAlternateMobile = new System.Windows.Forms.RadioButton();
            this.rbMobileNumber = new System.Windows.Forms.RadioButton();
            this.rbDate = new System.Windows.Forms.RadioButton();
            this.rbYear = new System.Windows.Forms.RadioButton();
            this.panelDate = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.panelYear = new System.Windows.Forms.Panel();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExportToTXT = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnSendSMS = new System.Windows.Forms.Button();
            this.dgvMobileNumbers = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.RichTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panelSMS = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panelDate.SuspendLayout();
            this.panelYear.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMobileNumbers)).BeginInit();
            this.panelSMS.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbAlternateMobile);
            this.panel1.Controls.Add(this.rbMobileNumber);
            this.panel1.Location = new System.Drawing.Point(29, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 47);
            this.panel1.TabIndex = 0;
            // 
            // rbAlternateMobile
            // 
            this.rbAlternateMobile.AutoSize = true;
            this.rbAlternateMobile.Location = new System.Drawing.Point(142, 14);
            this.rbAlternateMobile.Name = "rbAlternateMobile";
            this.rbAlternateMobile.Size = new System.Drawing.Size(127, 18);
            this.rbAlternateMobile.TabIndex = 2;
            this.rbAlternateMobile.TabStop = true;
            this.rbAlternateMobile.Text = "Alternate Mobile";
            this.rbAlternateMobile.UseVisualStyleBackColor = true;
            // 
            // rbMobileNumber
            // 
            this.rbMobileNumber.AutoSize = true;
            this.rbMobileNumber.Location = new System.Drawing.Point(18, 14);
            this.rbMobileNumber.Name = "rbMobileNumber";
            this.rbMobileNumber.Size = new System.Drawing.Size(118, 18);
            this.rbMobileNumber.TabIndex = 1;
            this.rbMobileNumber.TabStop = true;
            this.rbMobileNumber.Text = "Mobile Number";
            this.rbMobileNumber.UseVisualStyleBackColor = true;
            this.rbMobileNumber.CheckedChanged += new System.EventHandler(this.rbMobileNumber_CheckedChanged);
            // 
            // rbDate
            // 
            this.rbDate.AutoSize = true;
            this.rbDate.Location = new System.Drawing.Point(85, 9);
            this.rbDate.Name = "rbDate";
            this.rbDate.Size = new System.Drawing.Size(55, 18);
            this.rbDate.TabIndex = 5;
            this.rbDate.TabStop = true;
            this.rbDate.Text = "Date";
            this.rbDate.UseVisualStyleBackColor = true;
            // 
            // rbYear
            // 
            this.rbYear.AutoSize = true;
            this.rbYear.Location = new System.Drawing.Point(13, 9);
            this.rbYear.Name = "rbYear";
            this.rbYear.Size = new System.Drawing.Size(53, 18);
            this.rbYear.TabIndex = 4;
            this.rbYear.TabStop = true;
            this.rbYear.Text = "Year";
            this.rbYear.UseVisualStyleBackColor = true;
            this.rbYear.CheckedChanged += new System.EventHandler(this.rbYear_CheckedChanged);
            // 
            // panelDate
            // 
            this.panelDate.Controls.Add(this.dateTimePicker1);
            this.panelDate.Controls.Add(this.label2);
            this.panelDate.Location = new System.Drawing.Point(34, 111);
            this.panelDate.Name = "panelDate";
            this.panelDate.Size = new System.Drawing.Size(329, 51);
            this.panelDate.TabIndex = 6;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(72, 14);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(244, 22);
            this.dateTimePicker1.TabIndex = 7;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 14);
            this.label2.TabIndex = 34;
            this.label2.Text = "Date :";
            // 
            // panelYear
            // 
            this.panelYear.Controls.Add(this.cbYear);
            this.panelYear.Controls.Add(this.label1);
            this.panelYear.Location = new System.Drawing.Point(34, 111);
            this.panelYear.Name = "panelYear";
            this.panelYear.Size = new System.Drawing.Size(278, 54);
            this.panelYear.TabIndex = 8;
            // 
            // cbYear
            // 
            this.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYear.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbYear.FormattingEnabled = true;
            this.cbYear.Location = new System.Drawing.Point(83, 13);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(148, 22);
            this.cbYear.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 14);
            this.label1.TabIndex = 34;
            this.label1.Text = "Year :";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbDate);
            this.panel2.Controls.Add(this.rbYear);
            this.panel2.Location = new System.Drawing.Point(158, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(154, 40);
            this.panel2.TabIndex = 3;
            // 
            // btnExportToTXT
            // 
            this.btnExportToTXT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnExportToTXT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportToTXT.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportToTXT.Location = new System.Drawing.Point(160, 174);
            this.btnExportToTXT.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.btnExportToTXT.Name = "btnExportToTXT";
            this.btnExportToTXT.Size = new System.Drawing.Size(120, 31);
            this.btnExportToTXT.TabIndex = 11;
            this.btnExportToTXT.Text = "&Export to TXT";
            this.btnExportToTXT.UseVisualStyleBackColor = false;
            this.btnExportToTXT.Click += new System.EventHandler(this.btnExportToTXT_Click);
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(40, 174);
            this.btnShow.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(108, 31);
            this.btnShow.TabIndex = 10;
            this.btnShow.Text = "&Show";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnSendSMS
            // 
            this.btnSendSMS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSendSMS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendSMS.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendSMS.Location = new System.Drawing.Point(655, 279);
            this.btnSendSMS.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.btnSendSMS.Name = "btnSendSMS";
            this.btnSendSMS.Size = new System.Drawing.Size(108, 31);
            this.btnSendSMS.TabIndex = 13;
            this.btnSendSMS.Text = "Send S&MS";
            this.btnSendSMS.UseVisualStyleBackColor = false;
            this.btnSendSMS.Click += new System.EventHandler(this.btnSendSMS_Click);
            // 
            // dgvMobileNumbers
            // 
            this.dgvMobileNumbers.AllowUserToAddRows = false;
            this.dgvMobileNumbers.AllowUserToDeleteRows = false;
            this.dgvMobileNumbers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMobileNumbers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMobileNumbers.Location = new System.Drawing.Point(40, 211);
            this.dgvMobileNumbers.Name = "dgvMobileNumbers";
            this.dgvMobileNumbers.ReadOnly = true;
            this.dgvMobileNumbers.Size = new System.Drawing.Size(240, 392);
            this.dgvMobileNumbers.TabIndex = 46;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(106, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 47;
            this.label3.Text = "Yatra :";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(369, 279);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(108, 31);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessage.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Location = new System.Drawing.Point(369, 14);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(394, 261);
            this.txtMessage.TabIndex = 12;
            this.txtMessage.Text = "";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 26);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(392, 23);
            this.progressBar1.TabIndex = 48;
            // 
            // panelSMS
            // 
            this.panelSMS.Controls.Add(this.label4);
            this.panelSMS.Controls.Add(this.progressBar1);
            this.panelSMS.Location = new System.Drawing.Point(369, 332);
            this.panelSMS.Name = "panelSMS";
            this.panelSMS.Size = new System.Drawing.Size(397, 53);
            this.panelSMS.TabIndex = 49;
            this.panelSMS.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "Sending SMS...";
            // 
            // CustomSMS
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(831, 615);
            this.Controls.Add(this.panelSMS);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvMobileNumbers);
            this.Controls.Add(this.btnSendSMS);
            this.Controls.Add(this.btnExportToTXT);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelDate);
            this.Controls.Add(this.panelYear);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CustomSMS";
            this.Text = "Custom SMS";
            this.Load += new System.EventHandler(this.CustomSMS_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelDate.ResumeLayout(false);
            this.panelDate.PerformLayout();
            this.panelYear.ResumeLayout(false);
            this.panelYear.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMobileNumbers)).EndInit();
            this.panelSMS.ResumeLayout(false);
            this.panelSMS.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbAlternateMobile;
        private System.Windows.Forms.RadioButton rbMobileNumber;
        private System.Windows.Forms.RadioButton rbDate;
        private System.Windows.Forms.RadioButton rbYear;
        private System.Windows.Forms.Panel panelDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelYear;
        private System.Windows.Forms.ComboBox cbYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExportToTXT;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnSendSMS;
        private System.Windows.Forms.DataGridView dgvMobileNumbers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.RichTextBox txtMessage;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panelSMS;
        private System.Windows.Forms.Label label4;
    }
}