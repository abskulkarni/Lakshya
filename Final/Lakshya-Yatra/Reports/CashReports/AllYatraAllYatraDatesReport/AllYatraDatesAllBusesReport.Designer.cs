using Lakshya_Yatra.Reports.CashReports.AllYatraAllYatraDatesReport;
namespace Lakshya_Yatra
{
    partial class AllYatraDatesAllBusesReport
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
            this.dtAllYatraDatesAllBusesCashReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsAllYatraDatesAllBuses = new Lakshya_Yatra.Reports.CashReports.AllYatraAllYatraDatesReport.dsAllYatraDatesAllBuses();
            this.dtpNavratriDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpNavratriDateTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtAllYatraDatesAllBusesCashReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAllYatraDatesAllBuses)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtAllYatraDatesAllBusesCashReportBindingSource
            // 
            this.dtAllYatraDatesAllBusesCashReportBindingSource.DataMember = "dtAllYatraDatesAllBusesCashReport";
            this.dtAllYatraDatesAllBusesCashReportBindingSource.DataSource = this.dsAllYatraDatesAllBuses;
            // 
            // dsAllYatraDatesAllBuses
            // 
            this.dsAllYatraDatesAllBuses.DataSetName = "dsAllYatraDatesAllBuses";
            this.dsAllYatraDatesAllBuses.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtpNavratriDateFrom
            // 
            this.dtpNavratriDateFrom.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNavratriDateFrom.Location = new System.Drawing.Point(68, 21);
            this.dtpNavratriDateFrom.Name = "dtpNavratriDateFrom";
            this.dtpNavratriDateFrom.Size = new System.Drawing.Size(256, 22);
            this.dtpNavratriDateFrom.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 14);
            this.label2.TabIndex = 21;
            this.label2.Text = "From";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpNavratriDateTo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpNavratriDateFrom);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(32, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(649, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Yatra Date";
            // 
            // dtpNavratriDateTo
            // 
            this.dtpNavratriDateTo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNavratriDateTo.Location = new System.Drawing.Point(375, 21);
            this.dtpNavratriDateTo.Name = "dtpNavratriDateTo";
            this.dtpNavratriDateTo.Size = new System.Drawing.Size(256, 22);
            this.dtpNavratriDateTo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(347, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 14);
            this.label1.TabIndex = 23;
            this.label1.Text = "To";
            // 
            // btnSubmit
            // 
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(687, 37);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(108, 29);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // AllYatraDatesAllBusesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 627);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AllYatraDatesAllBusesReport";
            this.Text = "All Yatra Dates - All Buses Report";
            this.Load += new System.EventHandler(this.AllYatraDatesAllBusesReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtAllYatraDatesAllBusesCashReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAllYatraDatesAllBuses)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpNavratriDateFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpNavratriDateTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.BindingSource dtAllYatraDatesAllBusesCashReportBindingSource;
        private dsAllYatraDatesAllBuses dsAllYatraDatesAllBuses;
    }
}