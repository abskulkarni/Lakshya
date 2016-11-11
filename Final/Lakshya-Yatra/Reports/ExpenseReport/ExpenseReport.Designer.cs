namespace Lakshya_Yatra
{
    partial class ExpenseReport
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.cbUserNames = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabUserwise = new System.Windows.Forms.TabPage();
            this.tabYearly = new System.Windows.Forms.TabPage();
            this.panelYearRange = new System.Windows.Forms.Panel();
            this.cbToYear = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbFromYear = new System.Windows.Forms.ComboBox();
            this.rbRange = new System.Windows.Forms.RadioButton();
            this.rbLastYear = new System.Windows.Forms.RadioButton();
            this.rbThisYear = new System.Windows.Forms.RadioButton();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabUserwise.SuspendLayout();
            this.tabYearly.SuspendLayout();
            this.panelYearRange.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 18);
            this.label1.TabIndex = 32;
            this.label1.Text = "Year :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 18);
            this.label2.TabIndex = 31;
            this.label2.Text = "User :";
            // 
            // cbYear
            // 
            this.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYear.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbYear.FormattingEnabled = true;
            this.cbYear.Location = new System.Drawing.Point(106, 95);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(148, 26);
            this.cbYear.TabIndex = 30;
            // 
            // cbUserNames
            // 
            this.cbUserNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUserNames.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbUserNames.FormattingEnabled = true;
            this.cbUserNames.Location = new System.Drawing.Point(106, 27);
            this.cbUserNames.Name = "cbUserNames";
            this.cbUserNames.Size = new System.Drawing.Size(326, 26);
            this.cbUserNames.TabIndex = 29;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabUserwise);
            this.tabControl1.Controls.Add(this.tabYearly);
            this.tabControl1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(22, 23);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(581, 238);
            this.tabControl1.TabIndex = 33;
            // 
            // tabUserwise
            // 
            this.tabUserwise.Controls.Add(this.cbUserNames);
            this.tabUserwise.Controls.Add(this.label1);
            this.tabUserwise.Controls.Add(this.cbYear);
            this.tabUserwise.Controls.Add(this.label2);
            this.tabUserwise.Location = new System.Drawing.Point(4, 27);
            this.tabUserwise.Name = "tabUserwise";
            this.tabUserwise.Padding = new System.Windows.Forms.Padding(3);
            this.tabUserwise.Size = new System.Drawing.Size(573, 207);
            this.tabUserwise.TabIndex = 0;
            this.tabUserwise.Text = "Userwise";
            this.tabUserwise.UseVisualStyleBackColor = true;
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
            this.tabYearly.Size = new System.Drawing.Size(573, 207);
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
            this.cbToYear.Size = new System.Drawing.Size(111, 26);
            this.cbToYear.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(136, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "To";
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
            // btnSubmit
            // 
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(491, 297);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(108, 29);
            this.btnSubmit.TabIndex = 34;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // ExpenseReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 401);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ExpenseReport";
            this.Text = "Expense Report";
            this.Load += new System.EventHandler(this.ExpenseReport_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabUserwise.ResumeLayout(false);
            this.tabUserwise.PerformLayout();
            this.tabYearly.ResumeLayout(false);
            this.tabYearly.PerformLayout();
            this.panelYearRange.ResumeLayout(false);
            this.panelYearRange.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbYear;
        private System.Windows.Forms.ComboBox cbUserNames;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabUserwise;
        private System.Windows.Forms.TabPage tabYearly;
        private System.Windows.Forms.Panel panelYearRange;
        private System.Windows.Forms.ComboBox cbToYear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbFromYear;
        private System.Windows.Forms.RadioButton rbRange;
        private System.Windows.Forms.RadioButton rbLastYear;
        private System.Windows.Forms.RadioButton rbThisYear;
        private System.Windows.Forms.Button btnSubmit;

    }
}