namespace Lakshya_Yatra
{
    partial class BirthdayWishes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rbDate = new System.Windows.Forms.RadioButton();
            this.rbMonth = new System.Windows.Forms.RadioButton();
            this.panelDate = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.panelMonth = new System.Windows.Forms.Panel();
            this.cbMonth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnExportToCSV = new System.Windows.Forms.Button();
            this.dgvBirthdays = new System.Windows.Forms.DataGridView();
            this.chkCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.First_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Last_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mobile_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Birth_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblCurrentYear = new System.Windows.Forms.Label();
            this.panelDate.SuspendLayout();
            this.panelMonth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBirthdays)).BeginInit();
            this.SuspendLayout();
            // 
            // rbDate
            // 
            this.rbDate.AutoSize = true;
            this.rbDate.Location = new System.Drawing.Point(135, 32);
            this.rbDate.Name = "rbDate";
            this.rbDate.Size = new System.Drawing.Size(55, 18);
            this.rbDate.TabIndex = 1;
            this.rbDate.TabStop = true;
            this.rbDate.Text = "Date";
            this.rbDate.UseVisualStyleBackColor = true;
            // 
            // rbMonth
            // 
            this.rbMonth.AutoSize = true;
            this.rbMonth.Location = new System.Drawing.Point(50, 32);
            this.rbMonth.Name = "rbMonth";
            this.rbMonth.Size = new System.Drawing.Size(64, 18);
            this.rbMonth.TabIndex = 0;
            this.rbMonth.TabStop = true;
            this.rbMonth.Text = "Month";
            this.rbMonth.UseVisualStyleBackColor = true;
            this.rbMonth.CheckedChanged += new System.EventHandler(this.rbMonth_CheckedChanged);
            // 
            // panelDate
            // 
            this.panelDate.Controls.Add(this.dateTimePicker1);
            this.panelDate.Controls.Add(this.label2);
            this.panelDate.Location = new System.Drawing.Point(37, 60);
            this.panelDate.Name = "panelDate";
            this.panelDate.Size = new System.Drawing.Size(319, 54);
            this.panelDate.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(62, 13);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(244, 22);
            this.dateTimePicker1.TabIndex = 3;
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
            // panelMonth
            // 
            this.panelMonth.Controls.Add(this.lblCurrentYear);
            this.panelMonth.Controls.Add(this.cbMonth);
            this.panelMonth.Controls.Add(this.label1);
            this.panelMonth.Location = new System.Drawing.Point(37, 60);
            this.panelMonth.Name = "panelMonth";
            this.panelMonth.Size = new System.Drawing.Size(278, 54);
            this.panelMonth.TabIndex = 4;
            // 
            // cbMonth
            // 
            this.cbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMonth.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMonth.FormattingEnabled = true;
            this.cbMonth.Location = new System.Drawing.Point(65, 13);
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.Size = new System.Drawing.Size(148, 22);
            this.cbMonth.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 34;
            this.label1.Text = "Month :";
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(365, 71);
            this.btnShow.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(108, 31);
            this.btnShow.TabIndex = 6;
            this.btnShow.Text = "&Show";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnExportToCSV
            // 
            this.btnExportToCSV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnExportToCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportToCSV.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportToCSV.Location = new System.Drawing.Point(485, 71);
            this.btnExportToCSV.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.btnExportToCSV.Name = "btnExportToCSV";
            this.btnExportToCSV.Size = new System.Drawing.Size(138, 31);
            this.btnExportToCSV.TabIndex = 7;
            this.btnExportToCSV.Text = "&Export to TXT";
            this.btnExportToCSV.UseVisualStyleBackColor = false;
            this.btnExportToCSV.Click += new System.EventHandler(this.btnExportToTXT_Click);
            // 
            // dgvBirthdays
            // 
            this.dgvBirthdays.AllowUserToAddRows = false;
            this.dgvBirthdays.AllowUserToDeleteRows = false;
            this.dgvBirthdays.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBirthdays.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvBirthdays.ColumnHeadersHeight = 25;
            this.dgvBirthdays.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBirthdays.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chkCol,
            this.First_Name,
            this.Last_Name,
            this.Mobile_No,
            this.Birth_Date});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBirthdays.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvBirthdays.EnableHeadersVisualStyles = false;
            this.dgvBirthdays.Location = new System.Drawing.Point(37, 133);
            this.dgvBirthdays.Name = "dgvBirthdays";
            this.dgvBirthdays.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBirthdays.ShowEditingIcon = false;
            this.dgvBirthdays.Size = new System.Drawing.Size(702, 406);
            this.dgvBirthdays.TabIndex = 8;
            // 
            // chkCol
            // 
            this.chkCol.DataPropertyName = "Checked";
            this.chkCol.HeaderText = "Select";
            this.chkCol.Name = "chkCol";
            // 
            // First_Name
            // 
            this.First_Name.DataPropertyName = "First_Name";
            this.First_Name.HeaderText = "First Name";
            this.First_Name.Name = "First_Name";
            this.First_Name.ReadOnly = true;
            // 
            // Last_Name
            // 
            this.Last_Name.DataPropertyName = "Last_Name";
            this.Last_Name.HeaderText = "Last Name";
            this.Last_Name.Name = "Last_Name";
            this.Last_Name.ReadOnly = true;
            // 
            // Mobile_No
            // 
            this.Mobile_No.DataPropertyName = "Mobile_No";
            this.Mobile_No.HeaderText = "Mobile No";
            this.Mobile_No.Name = "Mobile_No";
            this.Mobile_No.ReadOnly = true;
            // 
            // Birth_Date
            // 
            this.Birth_Date.DataPropertyName = "Birth_Date";
            this.Birth_Date.HeaderText = "Birth Date";
            this.Birth_Date.Name = "Birth_Date";
            this.Birth_Date.ReadOnly = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(662, 71);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(108, 31);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblCurrentYear
            // 
            this.lblCurrentYear.AutoSize = true;
            this.lblCurrentYear.Location = new System.Drawing.Point(219, 16);
            this.lblCurrentYear.Name = "lblCurrentYear";
            this.lblCurrentYear.Size = new System.Drawing.Size(35, 14);
            this.lblCurrentYear.TabIndex = 36;
            this.lblCurrentYear.Text = "Year";
            // 
            // BirthdayWishes
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(785, 551);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvBirthdays);
            this.Controls.Add(this.btnExportToCSV);
            this.Controls.Add(this.rbDate);
            this.Controls.Add(this.rbMonth);
            this.Controls.Add(this.panelMonth);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.panelDate);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "BirthdayWishes";
            this.Text = "Birthday Wishes";
            this.Load += new System.EventHandler(this.BirthdayWishes_Load);
            this.panelDate.ResumeLayout(false);
            this.panelDate.PerformLayout();
            this.panelMonth.ResumeLayout(false);
            this.panelMonth.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBirthdays)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbDate;
        private System.Windows.Forms.RadioButton rbMonth;
        private System.Windows.Forms.Panel panelDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelMonth;
        private System.Windows.Forms.ComboBox cbMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnExportToCSV;
        private System.Windows.Forms.DataGridView dgvBirthdays;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn First_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Last_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mobile_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Birth_Date;
        private System.Windows.Forms.Label lblCurrentYear;
    }
}