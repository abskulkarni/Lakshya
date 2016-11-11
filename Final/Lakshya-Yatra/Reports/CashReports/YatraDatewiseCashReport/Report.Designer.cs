
using Lakshya_Yatra.Reports.CashReports.YatraDatewiseCashReport;
namespace Lakshya_Yatra
{
    partial class Report
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
            this.dtCashReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsCashReport = new Lakshya_Yatra.Reports.CashReports.YatraDatewiseCashReport.dsCashReport();
            this.cbBus = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpNavratriDate = new System.Windows.Forms.DateTimePicker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabYatraDate = new System.Windows.Forms.TabPage();
            this.tabYearly = new System.Windows.Forms.TabPage();
            this.panelYearRange = new System.Windows.Forms.Panel();
            this.cbToYear = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFromYear = new System.Windows.Forms.ComboBox();
            this.rbRange = new System.Windows.Forms.RadioButton();
            this.rbLastYear = new System.Windows.Forms.RadioButton();
            this.rbThisYear = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dtCashReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCashReport)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabYatraDate.SuspendLayout();
            this.tabYearly.SuspendLayout();
            this.panelYearRange.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtCashReportBindingSource
            // 
            this.dtCashReportBindingSource.DataMember = "dtCashReport";
            this.dtCashReportBindingSource.DataSource = this.dsCashReport;
            // 
            // dsCashReport
            // 
            this.dsCashReport.DataSetName = "dsCashReport";
            this.dsCashReport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cbBus
            // 
            this.cbBus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBus.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBus.FormattingEnabled = true;
            this.cbBus.Location = new System.Drawing.Point(110, 68);
            this.cbBus.Name = "cbBus";
            this.cbBus.Size = new System.Drawing.Size(110, 26);
            this.cbBus.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(40, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 18);
            this.label9.TabIndex = 15;
            this.label9.Text = "Bus No.";
            // 
            // btnSubmit
            // 
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(411, 157);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(108, 29);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 18);
            this.label2.TabIndex = 19;
            this.label2.Text = "Navratri Date";
            // 
            // dtpNavratriDate
            // 
            this.dtpNavratriDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNavratriDate.Location = new System.Drawing.Point(110, 25);
            this.dtpNavratriDate.Name = "dtpNavratriDate";
            this.dtpNavratriDate.Size = new System.Drawing.Size(256, 26);
            this.dtpNavratriDate.TabIndex = 8;
            this.dtpNavratriDate.ValueChanged += new System.EventHandler(this.dtpNavratriDate_ValueChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabYatraDate);
            this.tabControl1.Controls.Add(this.tabYearly);
            this.tabControl1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(393, 161);
            this.tabControl1.TabIndex = 0;
            // 
            // tabYatraDate
            // 
            this.tabYatraDate.Controls.Add(this.cbBus);
            this.tabYatraDate.Controls.Add(this.dtpNavratriDate);
            this.tabYatraDate.Controls.Add(this.label9);
            this.tabYatraDate.Controls.Add(this.label2);
            this.tabYatraDate.Location = new System.Drawing.Point(4, 27);
            this.tabYatraDate.Name = "tabYatraDate";
            this.tabYatraDate.Padding = new System.Windows.Forms.Padding(3);
            this.tabYatraDate.Size = new System.Drawing.Size(385, 130);
            this.tabYatraDate.TabIndex = 0;
            this.tabYatraDate.Text = "Yatra Datewise";
            this.tabYatraDate.UseVisualStyleBackColor = true;
            // 
            // tabYearly
            // 
            this.tabYearly.Controls.Add(this.panelYearRange);
            this.tabYearly.Controls.Add(this.rbRange);
            this.tabYearly.Controls.Add(this.rbLastYear);
            this.tabYearly.Controls.Add(this.rbThisYear);
            this.tabYearly.Location = new System.Drawing.Point(4, 27);
            this.tabYearly.Name = "tabYearly";
            this.tabYearly.Padding = new System.Windows.Forms.Padding(3);
            this.tabYearly.Size = new System.Drawing.Size(385, 130);
            this.tabYearly.TabIndex = 1;
            this.tabYearly.Text = "Yearly";
            this.tabYearly.UseVisualStyleBackColor = true;
            // 
            // panelYearRange
            // 
            this.panelYearRange.Controls.Add(this.cbToYear);
            this.panelYearRange.Controls.Add(this.label3);
            this.panelYearRange.Controls.Add(this.cbFromYear);
            this.panelYearRange.Location = new System.Drawing.Point(6, 45);
            this.panelYearRange.Name = "panelYearRange";
            this.panelYearRange.Size = new System.Drawing.Size(295, 38);
            this.panelYearRange.TabIndex = 7;
            // 
            // cbToYear
            // 
            this.cbToYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbToYear.FormattingEnabled = true;
            this.cbToYear.Location = new System.Drawing.Point(170, 10);
            this.cbToYear.Name = "cbToYear";
            this.cbToYear.Size = new System.Drawing.Size(111, 26);
            this.cbToYear.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(136, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "To";
            // 
            // cbFromYear
            // 
            this.cbFromYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFromYear.FormattingEnabled = true;
            this.cbFromYear.Location = new System.Drawing.Point(13, 10);
            this.cbFromYear.Name = "cbFromYear";
            this.cbFromYear.Size = new System.Drawing.Size(111, 26);
            this.cbFromYear.TabIndex = 5;
            // 
            // rbRange
            // 
            this.rbRange.AutoSize = true;
            this.rbRange.Location = new System.Drawing.Point(232, 21);
            this.rbRange.Name = "rbRange";
            this.rbRange.Size = new System.Drawing.Size(75, 22);
            this.rbRange.TabIndex = 4;
            this.rbRange.TabStop = true;
            this.rbRange.Text = "Range";
            this.rbRange.UseVisualStyleBackColor = true;
            this.rbRange.CheckedChanged += new System.EventHandler(this.rbRange_CheckedChanged);
            // 
            // rbLastYear
            // 
            this.rbLastYear.AutoSize = true;
            this.rbLastYear.Location = new System.Drawing.Point(130, 21);
            this.rbLastYear.Name = "rbLastYear";
            this.rbLastYear.Size = new System.Drawing.Size(97, 22);
            this.rbLastYear.TabIndex = 3;
            this.rbLastYear.TabStop = true;
            this.rbLastYear.Text = "Last Year";
            this.rbLastYear.UseVisualStyleBackColor = true;
            // 
            // rbThisYear
            // 
            this.rbThisYear.AutoSize = true;
            this.rbThisYear.Location = new System.Drawing.Point(25, 21);
            this.rbThisYear.Name = "rbThisYear";
            this.rbThisYear.Size = new System.Drawing.Size(95, 22);
            this.rbThisYear.TabIndex = 2;
            this.rbThisYear.TabStop = true;
            this.rbThisYear.Text = "This Year";
            this.rbThisYear.UseVisualStyleBackColor = true;
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 595);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnSubmit);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Report";
            this.Text = "Report";
            this.Load += new System.EventHandler(this.Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtCashReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCashReport)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabYatraDate.ResumeLayout(false);
            this.tabYatraDate.PerformLayout();
            this.tabYearly.ResumeLayout(false);
            this.tabYearly.PerformLayout();
            this.panelYearRange.ResumeLayout(false);
            this.panelYearRange.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbBus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpNavratriDate;
        private System.Windows.Forms.BindingSource dtCashReportBindingSource;
        private dsCashReport dsCashReport;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabYatraDate;
        private System.Windows.Forms.TabPage tabYearly;
        private System.Windows.Forms.Panel panelYearRange;
        private System.Windows.Forms.ComboBox cbToYear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFromYear;
        private System.Windows.Forms.RadioButton rbRange;
        private System.Windows.Forms.RadioButton rbLastYear;
        private System.Windows.Forms.RadioButton rbThisYear;
    }
}