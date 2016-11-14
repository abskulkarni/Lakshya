namespace Lakshya_Yatra
{
    partial class BirthDateReport
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
            this.btnShow = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMonth = new System.Windows.Forms.ComboBox();
            this.panelMonth = new System.Windows.Forms.Panel();
            this.panelDate = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.rbMonth = new System.Windows.Forms.RadioButton();
            this.rbDate = new System.Windows.Forms.RadioButton();
            this.lblCurrentYear = new System.Windows.Forms.Label();
            this.panelMonth.SuspendLayout();
            this.panelDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(223, 151);
            this.btnShow.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(108, 31);
            this.btnShow.TabIndex = 35;
            this.btnShow.Text = "&Show";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 34;
            this.label1.Text = "Month :";
            // 
            // cbMonth
            // 
            this.cbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMonth.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMonth.FormattingEnabled = true;
            this.cbMonth.Location = new System.Drawing.Point(62, 12);
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.Size = new System.Drawing.Size(152, 22);
            this.cbMonth.TabIndex = 33;
            // 
            // panelMonth
            // 
            this.panelMonth.Controls.Add(this.lblCurrentYear);
            this.panelMonth.Controls.Add(this.cbMonth);
            this.panelMonth.Controls.Add(this.label1);
            this.panelMonth.Location = new System.Drawing.Point(59, 65);
            this.panelMonth.Name = "panelMonth";
            this.panelMonth.Size = new System.Drawing.Size(278, 54);
            this.panelMonth.TabIndex = 36;
            // 
            // panelDate
            // 
            this.panelDate.Controls.Add(this.dateTimePicker1);
            this.panelDate.Controls.Add(this.label2);
            this.panelDate.Location = new System.Drawing.Point(59, 65);
            this.panelDate.Name = "panelDate";
            this.panelDate.Size = new System.Drawing.Size(278, 54);
            this.panelDate.TabIndex = 37;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(72, 14);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 35;
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
            // rbMonth
            // 
            this.rbMonth.AutoSize = true;
            this.rbMonth.Location = new System.Drawing.Point(72, 37);
            this.rbMonth.Name = "rbMonth";
            this.rbMonth.Size = new System.Drawing.Size(64, 18);
            this.rbMonth.TabIndex = 38;
            this.rbMonth.TabStop = true;
            this.rbMonth.Text = "Month";
            this.rbMonth.UseVisualStyleBackColor = true;
            this.rbMonth.CheckedChanged += new System.EventHandler(this.rbMonth_CheckedChanged);
            // 
            // rbDate
            // 
            this.rbDate.AutoSize = true;
            this.rbDate.Location = new System.Drawing.Point(157, 37);
            this.rbDate.Name = "rbDate";
            this.rbDate.Size = new System.Drawing.Size(55, 18);
            this.rbDate.TabIndex = 39;
            this.rbDate.TabStop = true;
            this.rbDate.Text = "Date";
            this.rbDate.UseVisualStyleBackColor = true;
            // 
            // lblCurrentYear
            // 
            this.lblCurrentYear.AutoSize = true;
            this.lblCurrentYear.Location = new System.Drawing.Point(218, 16);
            this.lblCurrentYear.Name = "lblCurrentYear";
            this.lblCurrentYear.Size = new System.Drawing.Size(35, 14);
            this.lblCurrentYear.TabIndex = 35;
            this.lblCurrentYear.Text = "Year";
            // 
            // BirthDateReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 413);
            this.Controls.Add(this.rbDate);
            this.Controls.Add(this.rbMonth);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.panelMonth);
            this.Controls.Add(this.panelDate);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "BirthDateReport";
            this.Text = "Birth Date Report";
            this.Load += new System.EventHandler(this.BirthDateReport_Load);
            this.panelMonth.ResumeLayout(false);
            this.panelMonth.PerformLayout();
            this.panelDate.ResumeLayout(false);
            this.panelDate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMonth;
        private System.Windows.Forms.Panel panelMonth;
        private System.Windows.Forms.Panel panelDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbMonth;
        private System.Windows.Forms.RadioButton rbDate;
        private System.Windows.Forms.Label lblCurrentYear;
    }
}