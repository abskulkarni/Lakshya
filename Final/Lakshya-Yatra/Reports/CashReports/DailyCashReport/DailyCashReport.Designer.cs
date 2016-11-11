using Lakshya_Yatra.Reports.CashReports.DailyCashReport;
namespace Lakshya_Yatra
{
    partial class DailyCashReport
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
            this.components = new System.ComponentModel.Container();
            this.dtDailyCashReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsDailyCashReport = new Lakshya_Yatra.Reports.CashReports.DailyCashReport.dsDailyCashReport();
            this.btnShow = new System.Windows.Forms.Button();
            this.dtpRegistrationDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabRegistrationDate = new System.Windows.Forms.TabPage();
            this.tabYearly = new System.Windows.Forms.TabPage();
            this.rbThisYear = new System.Windows.Forms.RadioButton();
            this.rbLastYear = new System.Windows.Forms.RadioButton();
            this.rbRange = new System.Windows.Forms.RadioButton();
            this.cbFromYear = new System.Windows.Forms.ComboBox();
            this.cbToYear = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelYearRange = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dtDailyCashReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDailyCashReport)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabRegistrationDate.SuspendLayout();
            this.tabYearly.SuspendLayout();
            this.panelYearRange.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtDailyCashReportBindingSource
            // 
            this.dtDailyCashReportBindingSource.DataMember = "dtDailyCashReport";
            this.dtDailyCashReportBindingSource.DataSource = this.dsDailyCashReport;
            // 
            // dsDailyCashReport
            // 
            this.dsDailyCashReport.DataSetName = "dsDailyCashReport";
            this.dsDailyCashReport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnShow
            // 
            this.btnShow.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(462, 206);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(106, 27);
            this.btnShow.TabIndex = 7;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // dtpRegistrationDate
            // 
            this.dtpRegistrationDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpRegistrationDate.Location = new System.Drawing.Point(131, 25);
            this.dtpRegistrationDate.Name = "dtpRegistrationDate";
            this.dtpRegistrationDate.Size = new System.Drawing.Size(256, 22);
            this.dtpRegistrationDate.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 14);
            this.label2.TabIndex = 54;
            this.label2.Text = "Registration Date";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabRegistrationDate);
            this.tabControl1.Controls.Add(this.tabYearly);
            this.tabControl1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(24, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(548, 161);
            this.tabControl1.TabIndex = 0;
            // 
            // tabRegistrationDate
            // 
            this.tabRegistrationDate.Controls.Add(this.dtpRegistrationDate);
            this.tabRegistrationDate.Controls.Add(this.label2);
            this.tabRegistrationDate.Location = new System.Drawing.Point(4, 23);
            this.tabRegistrationDate.Name = "tabRegistrationDate";
            this.tabRegistrationDate.Padding = new System.Windows.Forms.Padding(3);
            this.tabRegistrationDate.Size = new System.Drawing.Size(540, 134);
            this.tabRegistrationDate.TabIndex = 0;
            this.tabRegistrationDate.Text = "Registration Datewise";
            this.tabRegistrationDate.UseVisualStyleBackColor = true;
            // 
            // tabYearly
            // 
            this.tabYearly.Controls.Add(this.panelYearRange);
            this.tabYearly.Controls.Add(this.rbRange);
            this.tabYearly.Controls.Add(this.rbLastYear);
            this.tabYearly.Controls.Add(this.rbThisYear);
            this.tabYearly.Location = new System.Drawing.Point(4, 23);
            this.tabYearly.Name = "tabYearly";
            this.tabYearly.Padding = new System.Windows.Forms.Padding(3);
            this.tabYearly.Size = new System.Drawing.Size(540, 134);
            this.tabYearly.TabIndex = 1;
            this.tabYearly.Text = "Yearly";
            this.tabYearly.UseVisualStyleBackColor = true;
            // 
            // rbThisYear
            // 
            this.rbThisYear.AutoSize = true;
            this.rbThisYear.Location = new System.Drawing.Point(25, 21);
            this.rbThisYear.Name = "rbThisYear";
            this.rbThisYear.Size = new System.Drawing.Size(82, 18);
            this.rbThisYear.TabIndex = 2;
            this.rbThisYear.TabStop = true;
            this.rbThisYear.Text = "This Year";
            this.rbThisYear.UseVisualStyleBackColor = true;
            // 
            // rbLastYear
            // 
            this.rbLastYear.AutoSize = true;
            this.rbLastYear.Location = new System.Drawing.Point(130, 21);
            this.rbLastYear.Name = "rbLastYear";
            this.rbLastYear.Size = new System.Drawing.Size(84, 18);
            this.rbLastYear.TabIndex = 3;
            this.rbLastYear.TabStop = true;
            this.rbLastYear.Text = "Last Year";
            this.rbLastYear.UseVisualStyleBackColor = true;
            // 
            // rbRange
            // 
            this.rbRange.AutoSize = true;
            this.rbRange.Location = new System.Drawing.Point(232, 21);
            this.rbRange.Name = "rbRange";
            this.rbRange.Size = new System.Drawing.Size(65, 18);
            this.rbRange.TabIndex = 4;
            this.rbRange.TabStop = true;
            this.rbRange.Text = "Range";
            this.rbRange.UseVisualStyleBackColor = true;
            this.rbRange.CheckedChanged += new System.EventHandler(this.rbRange_CheckedChanged);
            // 
            // cbFromYear
            // 
            this.cbFromYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFromYear.FormattingEnabled = true;
            this.cbFromYear.Location = new System.Drawing.Point(13, 10);
            this.cbFromYear.Name = "cbFromYear";
            this.cbFromYear.Size = new System.Drawing.Size(111, 22);
            this.cbFromYear.TabIndex = 5;
            // 
            // cbToYear
            // 
            this.cbToYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbToYear.FormattingEnabled = true;
            this.cbToYear.Location = new System.Drawing.Point(170, 10);
            this.cbToYear.Name = "cbToYear";
            this.cbToYear.Size = new System.Drawing.Size(111, 22);
            this.cbToYear.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "To";
            // 
            // panelYearRange
            // 
            this.panelYearRange.Controls.Add(this.cbToYear);
            this.panelYearRange.Controls.Add(this.label1);
            this.panelYearRange.Controls.Add(this.cbFromYear);
            this.panelYearRange.Location = new System.Drawing.Point(6, 45);
            this.panelYearRange.Name = "panelYearRange";
            this.panelYearRange.Size = new System.Drawing.Size(295, 38);
            this.panelYearRange.TabIndex = 7;
            // 
            // DailyCashReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 733);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnShow);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DailyCashReport";
            this.Text = "Daily Cash Report";
            this.Load += new System.EventHandler(this.DailyCashReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtDailyCashReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDailyCashReport)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabRegistrationDate.ResumeLayout(false);
            this.tabRegistrationDate.PerformLayout();
            this.tabYearly.ResumeLayout(false);
            this.tabYearly.PerformLayout();
            this.panelYearRange.ResumeLayout(false);
            this.panelYearRange.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.DateTimePicker dtpRegistrationDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource dtDailyCashReportBindingSource;
        private dsDailyCashReport dsDailyCashReport;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabRegistrationDate;
        private System.Windows.Forms.TabPage tabYearly;
        private System.Windows.Forms.RadioButton rbRange;
        private System.Windows.Forms.RadioButton rbLastYear;
        private System.Windows.Forms.RadioButton rbThisYear;
        private System.Windows.Forms.ComboBox cbFromYear;
        private System.Windows.Forms.ComboBox cbToYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelYearRange;
    }
}