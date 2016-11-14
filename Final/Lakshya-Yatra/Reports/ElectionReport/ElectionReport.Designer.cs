namespace Lakshya_Yatra
{
    partial class ElectionReport
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
            this.btnShowReport = new System.Windows.Forms.Button();
            this.cbArea = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnShowReport
            // 
            this.btnShowReport.Location = new System.Drawing.Point(143, 87);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(196, 36);
            this.btnShowReport.TabIndex = 1;
            this.btnShowReport.Text = "Show Election Report";
            this.btnShowReport.UseVisualStyleBackColor = true;
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
            // 
            // cbArea
            // 
            this.cbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbArea.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbArea.FormattingEnabled = true;
            this.cbArea.Location = new System.Drawing.Point(92, 30);
            this.cbArea.Name = "cbArea";
            this.cbArea.Size = new System.Drawing.Size(247, 22);
            this.cbArea.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(50, 38);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 14);
            this.label14.TabIndex = 23;
            this.label14.Text = "Area";
            // 
            // ElectionReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 262);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cbArea);
            this.Controls.Add(this.btnShowReport);
            this.Name = "ElectionReport";
            this.Text = "ElectionReport";
            this.Load += new System.EventHandler(this.ElectionReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShowReport;
        private System.Windows.Forms.ComboBox cbArea;
        private System.Windows.Forms.Label label14;
    }
}