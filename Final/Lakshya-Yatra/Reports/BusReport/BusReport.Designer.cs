
using Lakshya_Yatra.Reports.BusReport;
namespace Lakshya_Yatra
{
    partial class BusReport
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
            this.dtBusReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsBusReport = new Lakshya_Yatra.Reports.BusReport.dsBusReport();
            this.dtpNavratriDate = new System.Windows.Forms.DateTimePicker();
            this.cbBus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabNavratriDate = new System.Windows.Forms.TabPage();
            this.tabYearly = new System.Windows.Forms.TabPage();
            this.panelYearRange = new System.Windows.Forms.Panel();
            this.cbToYear = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbFromYear = new System.Windows.Forms.ComboBox();
            this.rbRange = new System.Windows.Forms.RadioButton();
            this.rbLastYear = new System.Windows.Forms.RadioButton();
            this.rbThisYear = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dtBusReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBusReport)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabNavratriDate.SuspendLayout();
            this.tabYearly.SuspendLayout();
            this.panelYearRange.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtBusReportBindingSource
            // 
            this.dtBusReportBindingSource.DataMember = "dtBusReport";
            this.dtBusReportBindingSource.DataSource = this.dsBusReport;
            // 
            // dsBusReport
            // 
            this.dsBusReport.DataSetName = "dsBusReport";
            this.dsBusReport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtpNavratriDate
            // 
            this.dtpNavratriDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNavratriDate.Location = new System.Drawing.Point(138, 40);
            this.dtpNavratriDate.Name = "dtpNavratriDate";
            this.dtpNavratriDate.Size = new System.Drawing.Size(256, 22);
            this.dtpNavratriDate.TabIndex = 7;
            this.dtpNavratriDate.ValueChanged += new System.EventHandler(this.dtpNavratriDate_ValueChanged);
            // 
            // cbBus
            // 
            this.cbBus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBus.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBus.FormattingEnabled = true;
            this.cbBus.Location = new System.Drawing.Point(448, 41);
            this.cbBus.Name = "cbBus";
            this.cbBus.Size = new System.Drawing.Size(153, 22);
            this.cbBus.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(403, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 14);
            this.label1.TabIndex = 48;
            this.label1.Text = "Bus";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 14);
            this.label2.TabIndex = 47;
            this.label2.Text = "Navratri Date";
            // 
            // btnSubmit
            // 
            this.btnSubmit.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(815, 166);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(106, 27);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.Text = "Search";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabNavratriDate);
            this.tabControl1.Controls.Add(this.tabYearly);
            this.tabControl1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(45, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(764, 161);
            this.tabControl1.TabIndex = 0;
            // 
            // tabNavratriDate
            // 
            this.tabNavratriDate.Controls.Add(this.dtpNavratriDate);
            this.tabNavratriDate.Controls.Add(this.label2);
            this.tabNavratriDate.Controls.Add(this.label1);
            this.tabNavratriDate.Controls.Add(this.cbBus);
            this.tabNavratriDate.Location = new System.Drawing.Point(4, 23);
            this.tabNavratriDate.Name = "tabNavratriDate";
            this.tabNavratriDate.Padding = new System.Windows.Forms.Padding(3);
            this.tabNavratriDate.Size = new System.Drawing.Size(756, 134);
            this.tabNavratriDate.TabIndex = 0;
            this.tabNavratriDate.Text = "Navratri Datewise";
            this.tabNavratriDate.UseVisualStyleBackColor = true;
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
            this.tabYearly.Size = new System.Drawing.Size(756, 134);
            this.tabYearly.TabIndex = 1;
            this.tabYearly.Text = "Yearly";
            this.tabYearly.UseVisualStyleBackColor = true;
            // 
            // panelYearRange
            // 
            this.panelYearRange.Controls.Add(this.cbToYear);
            this.panelYearRange.Controls.Add(this.label4);
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
            this.cbToYear.Size = new System.Drawing.Size(111, 22);
            this.cbToYear.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(136, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 14);
            this.label4.TabIndex = 5;
            this.label4.Text = "To";
            // 
            // cbFromYear
            // 
            this.cbFromYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFromYear.FormattingEnabled = true;
            this.cbFromYear.Location = new System.Drawing.Point(13, 10);
            this.cbFromYear.Name = "cbFromYear";
            this.cbFromYear.Size = new System.Drawing.Size(111, 22);
            this.cbFromYear.TabIndex = 4;
            // 
            // rbRange
            // 
            this.rbRange.AutoSize = true;
            this.rbRange.Location = new System.Drawing.Point(232, 21);
            this.rbRange.Name = "rbRange";
            this.rbRange.Size = new System.Drawing.Size(65, 18);
            this.rbRange.TabIndex = 3;
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
            this.rbLastYear.Size = new System.Drawing.Size(84, 18);
            this.rbLastYear.TabIndex = 2;
            this.rbLastYear.TabStop = true;
            this.rbLastYear.Text = "Last Year";
            this.rbLastYear.UseVisualStyleBackColor = true;
            // 
            // rbThisYear
            // 
            this.rbThisYear.AutoSize = true;
            this.rbThisYear.Location = new System.Drawing.Point(25, 21);
            this.rbThisYear.Name = "rbThisYear";
            this.rbThisYear.Size = new System.Drawing.Size(82, 18);
            this.rbThisYear.TabIndex = 1;
            this.rbThisYear.TabStop = true;
            this.rbThisYear.Text = "This Year";
            this.rbThisYear.UseVisualStyleBackColor = true;
            // 
            // BusReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 733);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnSubmit);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "BusReport";
            this.Text = "BusReport";
            this.Load += new System.EventHandler(this.BusReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtBusReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBusReport)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabNavratriDate.ResumeLayout(false);
            this.tabNavratriDate.PerformLayout();
            this.tabYearly.ResumeLayout(false);
            this.tabYearly.PerformLayout();
            this.panelYearRange.ResumeLayout(false);
            this.panelYearRange.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpNavratriDate;
        private System.Windows.Forms.ComboBox cbBus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.BindingSource dtBusReportBindingSource;
        private dsBusReport dsBusReport;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabNavratriDate;
        private System.Windows.Forms.TabPage tabYearly;
        private System.Windows.Forms.Panel panelYearRange;
        private System.Windows.Forms.ComboBox cbToYear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbFromYear;
        private System.Windows.Forms.RadioButton rbRange;
        private System.Windows.Forms.RadioButton rbLastYear;
        private System.Windows.Forms.RadioButton rbThisYear;
    }
}