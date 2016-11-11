using Lakshya_Yatra.Reports.EmptySeatsReport;
namespace Lakshya_Yatra
{
    partial class EmptySeats
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
            this.dtEmptySeatsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsEmptySeats = new Lakshya_Yatra.Reports.EmptySeatsReport.dsEmptySeats();
            this.dtpNavratriDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.cbBus = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtEmptySeatsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEmptySeats)).BeginInit();
            this.SuspendLayout();
            // 
            // dtEmptySeatsBindingSource
            // 
            this.dtEmptySeatsBindingSource.DataMember = "dtEmptySeats";
            this.dtEmptySeatsBindingSource.DataSource = this.dsEmptySeats;
            // 
            // dsEmptySeats
            // 
            this.dsEmptySeats.DataSetName = "dsEmptySeats";
            this.dsEmptySeats.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtpNavratriDate
            // 
            this.dtpNavratriDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNavratriDate.Location = new System.Drawing.Point(140, 12);
            this.dtpNavratriDate.Name = "dtpNavratriDate";
            this.dtpNavratriDate.Size = new System.Drawing.Size(256, 22);
            this.dtpNavratriDate.TabIndex = 20;
            this.dtpNavratriDate.ValueChanged += new System.EventHandler(this.dtpNavratriDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 14);
            this.label2.TabIndex = 24;
            this.label2.Text = "Navratri Date";
            // 
            // btnSubmit
            // 
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(635, 12);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(108, 29);
            this.btnSubmit.TabIndex = 22;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // cbBus
            // 
            this.cbBus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBus.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBus.FormattingEnabled = true;
            this.cbBus.Location = new System.Drawing.Point(492, 13);
            this.cbBus.Name = "cbBus";
            this.cbBus.Size = new System.Drawing.Size(110, 22);
            this.cbBus.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(422, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 14);
            this.label9.TabIndex = 23;
            this.label9.Text = "Bus No.";
            // 
            // EmptySeats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 523);
            this.Controls.Add(this.dtpNavratriDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.cbBus);
            this.Controls.Add(this.label9);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "EmptySeats";
            this.Text = "Empty Seats";
            this.Load += new System.EventHandler(this.EmptySeats_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtEmptySeatsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEmptySeats)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpNavratriDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.ComboBox cbBus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.BindingSource dtEmptySeatsBindingSource;
        private dsEmptySeats dsEmptySeats;
    }
}