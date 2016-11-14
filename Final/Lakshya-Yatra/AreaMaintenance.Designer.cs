namespace Lakshya_Yatra
{
    partial class AreaMaintenance
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
            this.dgvArea = new System.Windows.Forms.DataGridView();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.chkIsVisible = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteTransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArea)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvArea
            // 
            this.dgvArea.AllowUserToAddRows = false;
            this.dgvArea.AllowUserToDeleteRows = false;
            this.dgvArea.AllowUserToOrderColumns = true;
            this.dgvArea.AllowUserToResizeRows = false;
            this.dgvArea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArea.Location = new System.Drawing.Point(346, 12);
            this.dgvArea.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.dgvArea.MultiSelect = false;
            this.dgvArea.Name = "dgvArea";
            this.dgvArea.ReadOnly = true;
            this.dgvArea.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArea.Size = new System.Drawing.Size(291, 449);
            this.dgvArea.TabIndex = 4;
            this.dgvArea.TabStop = false;
            this.dgvArea.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvArea_RowHeaderMouseClick);
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNew.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.Location = new System.Drawing.Point(201, 137);
            this.btnAddNew.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(97, 34);
            this.btnAddNew.TabIndex = 3;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 46);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 14);
            this.label4.TabIndex = 100;
            this.label4.Text = "Area :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtArea
            // 
            this.txtArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtArea.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArea.ForeColor = System.Drawing.Color.Black;
            this.txtArea.Location = new System.Drawing.Point(90, 46);
            this.txtArea.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtArea.MaxLength = 30;
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(232, 22);
            this.txtArea.TabIndex = 0;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(90, 137);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(101, 33);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // chkIsVisible
            // 
            this.chkIsVisible.AutoSize = true;
            this.chkIsVisible.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsVisible.Location = new System.Drawing.Point(90, 90);
            this.chkIsVisible.Name = "chkIsVisible";
            this.chkIsVisible.Size = new System.Drawing.Size(82, 18);
            this.chkIsVisible.TabIndex = 1;
            this.chkIsVisible.Text = "Is Visible";
            this.chkIsVisible.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Verdana", 9F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteTransactionToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 26);
            // 
            // deleteTransactionToolStripMenuItem
            // 
            this.deleteTransactionToolStripMenuItem.Name = "deleteTransactionToolStripMenuItem";
            this.deleteTransactionToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.deleteTransactionToolStripMenuItem.Text = "Delete Area";
            this.deleteTransactionToolStripMenuItem.Click += new System.EventHandler(this.deleteTransactionToolStripMenuItem_Click);
            // 
            // AreaMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 488);
            this.Controls.Add(this.chkIsVisible);
            this.Controls.Add(this.dgvArea);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtArea);
            this.Controls.Add(this.btnSubmit);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AreaMaintenance";
            this.Text = "Area Maintenance";
            this.Load += new System.EventHandler(this.AreaMaintenance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArea)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvArea;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.CheckBox chkIsVisible;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteTransactionToolStripMenuItem;
    }
}