namespace Lakshya_Yatra
{
    partial class CashExpenses
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
            this.dgvExpense = new System.Windows.Forms.DataGridView();
            this.lblTotalExpensesValue = new System.Windows.Forms.Label();
            this.lblTotalExpenses = new System.Windows.Forms.Label();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbExpenseType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpExpenseDate = new System.Windows.Forms.DateTimePicker();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteTransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpense)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvExpense
            // 
            this.dgvExpense.AllowUserToAddRows = false;
            this.dgvExpense.AllowUserToDeleteRows = false;
            this.dgvExpense.AllowUserToOrderColumns = true;
            this.dgvExpense.AllowUserToResizeRows = false;
            this.dgvExpense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpense.Location = new System.Drawing.Point(439, 52);
            this.dgvExpense.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.dgvExpense.Name = "dgvExpense";
            this.dgvExpense.ReadOnly = true;
            this.dgvExpense.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExpense.Size = new System.Drawing.Size(456, 479);
            this.dgvExpense.TabIndex = 90;
            this.dgvExpense.TabStop = false;
            this.dgvExpense.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvExpense_RowHeaderMouseClick);
            // 
            // lblTotalExpensesValue
            // 
            this.lblTotalExpensesValue.AutoSize = true;
            this.lblTotalExpensesValue.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalExpensesValue.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotalExpensesValue.Location = new System.Drawing.Point(552, 19);
            this.lblTotalExpensesValue.Name = "lblTotalExpensesValue";
            this.lblTotalExpensesValue.Size = new System.Drawing.Size(18, 17);
            this.lblTotalExpensesValue.TabIndex = 96;
            this.lblTotalExpensesValue.Text = "0";
            // 
            // lblTotalExpenses
            // 
            this.lblTotalExpenses.AutoSize = true;
            this.lblTotalExpenses.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalExpenses.Location = new System.Drawing.Point(436, 20);
            this.lblTotalExpenses.Name = "lblTotalExpenses";
            this.lblTotalExpenses.Size = new System.Drawing.Size(119, 14);
            this.lblTotalExpenses.TabIndex = 95;
            this.lblTotalExpenses.Text = "Total Expenses : ";
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNew.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.Location = new System.Drawing.Point(246, 256);
            this.btnAddNew.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(107, 34);
            this.btnAddNew.TabIndex = 89;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 94;
            this.label1.Text = "Remarks:";
            // 
            // txtRemarks
            // 
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(123, 153);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtRemarks.MaxLength = 200;
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(230, 75);
            this.txtRemarks.TabIndex = 87;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(52, 101);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 14);
            this.label4.TabIndex = 93;
            this.label4.Text = "Amount:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAmount
            // 
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Font = new System.Drawing.Font("Verdana", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.ForeColor = System.Drawing.Color.Maroon;
            this.txtAmount.Location = new System.Drawing.Point(123, 101);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtAmount.MaxLength = 8;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(172, 22);
            this.txtAmount.TabIndex = 86;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 16);
            this.label2.TabIndex = 92;
            this.label2.Text = "Expense Type:";
            // 
            // cbExpenseType
            // 
            this.cbExpenseType.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbExpenseType.FormattingEnabled = true;
            this.cbExpenseType.Location = new System.Drawing.Point(123, 59);
            this.cbExpenseType.Name = "cbExpenseType";
            this.cbExpenseType.Size = new System.Drawing.Size(245, 24);
            this.cbExpenseType.TabIndex = 85;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(65, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 17);
            this.label8.TabIndex = 91;
            this.label8.Text = "Date:";
            // 
            // dtpExpenseDate
            // 
            this.dtpExpenseDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpExpenseDate.Location = new System.Drawing.Point(123, 16);
            this.dtpExpenseDate.Name = "dtpExpenseDate";
            this.dtpExpenseDate.Size = new System.Drawing.Size(245, 23);
            this.dtpExpenseDate.TabIndex = 84;
            this.dtpExpenseDate.ValueChanged += new System.EventHandler(this.dtpExpenseDate_ValueChanged);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(123, 256);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(113, 33);
            this.btnSubmit.TabIndex = 88;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Verdana", 9F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteTransactionToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(192, 26);
            // 
            // deleteTransactionToolStripMenuItem
            // 
            this.deleteTransactionToolStripMenuItem.Name = "deleteTransactionToolStripMenuItem";
            this.deleteTransactionToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.deleteTransactionToolStripMenuItem.Text = "Delete Transaction";
            this.deleteTransactionToolStripMenuItem.Click += new System.EventHandler(this.deleteTransactionToolStripMenuItem_Click);
            // 
            // CashExpenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 543);
            this.Controls.Add(this.dgvExpense);
            this.Controls.Add(this.lblTotalExpensesValue);
            this.Controls.Add(this.lblTotalExpenses);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbExpenseType);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpExpenseDate);
            this.Controls.Add(this.btnSubmit);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CashExpenses";
            this.Text = "Cash Expenses";
            this.Load += new System.EventHandler(this.CashExpenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpense)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvExpense;
        private System.Windows.Forms.Label lblTotalExpensesValue;
        private System.Windows.Forms.Label lblTotalExpenses;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbExpenseType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpExpenseDate;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteTransactionToolStripMenuItem;
    }
}