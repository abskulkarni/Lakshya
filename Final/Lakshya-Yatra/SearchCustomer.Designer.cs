namespace Lakshya_Yatra
{
    partial class SearchCustomer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtCustID = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbBloodGroup = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.cbBus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dtpNavratriDate = new System.Windows.Forms.DateTimePicker();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnSearchDatewise = new System.Windows.Forms.Button();
            this.btnSendSMS = new System.Windows.Forms.Button();
            this.txtAlternateMobileNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbNavratriDate = new System.Windows.Forms.RadioButton();
            this.rbNavratriYear = new System.Windows.Forms.RadioButton();
            this.cbNavratriYear = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCustID
            // 
            this.txtCustID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustID.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustID.Location = new System.Drawing.Point(173, 13);
            this.txtCustID.Name = "txtCustID";
            this.txtCustID.Size = new System.Drawing.Size(164, 29);
            this.txtCustID.TabIndex = 7;
            this.txtCustID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RestrictToPositiveInteger);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(70, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(126, 22);
            this.label12.TabIndex = 23;
            this.label12.Text = "Customer ID";
            // 
            // txtLastName
            // 
            this.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLastName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Location = new System.Drawing.Point(347, 49);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(164, 29);
            this.txtLastName.TabIndex = 9;
            // 
            // txtFirstName
            // 
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFirstName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(173, 49);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(164, 29);
            this.txtFirstName.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(121, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 22);
            this.label3.TabIndex = 31;
            this.label3.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 22);
            this.label2.TabIndex = 29;
            this.label2.Text = "Navratri Date";
            // 
            // cbBloodGroup
            // 
            this.cbBloodGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBloodGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBloodGroup.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBloodGroup.FormattingEnabled = true;
            this.cbBloodGroup.Items.AddRange(new object[] {
            "A+",
            "A-",
            "B+",
            "B-",
            "AB+",
            "AB-",
            "O+",
            "O-"});
            this.cbBloodGroup.Location = new System.Drawing.Point(173, 82);
            this.cbBloodGroup.Name = "cbBloodGroup";
            this.cbBloodGroup.Size = new System.Drawing.Size(164, 30);
            this.cbBloodGroup.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(72, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 22);
            this.label7.TabIndex = 33;
            this.label7.Text = "Blood Group";
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMobileNo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobileNo.Location = new System.Drawing.Point(173, 120);
            this.txtMobileNo.MaxLength = 10;
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(164, 29);
            this.txtMobileNo.TabIndex = 11;
            this.txtMobileNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMobileNo_KeyDown);
            this.txtMobileNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RestrictToPositiveInteger);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(87, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 22);
            this.label8.TabIndex = 35;
            this.label8.Text = "Mobile No.";
            // 
            // btnSubmit
            // 
            this.btnSubmit.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(628, 164);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(106, 27);
            this.btnSubmit.TabIndex = 13;
            this.btnSubmit.Text = "Search";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvCustomers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCustomers.Location = new System.Drawing.Point(34, 226);
            this.dgvCustomers.MultiSelect = false;
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.dgvCustomers.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(1110, 432);
            this.dgvCustomers.TabIndex = 8;
            this.dgvCustomers.TabStop = false;
            this.dgvCustomers.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCustomers_CellMouseUp);
            // 
            // cbBus
            // 
            this.cbBus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBus.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBus.FormattingEnabled = true;
            this.cbBus.Location = new System.Drawing.Point(179, 49);
            this.cbBus.Name = "cbBus";
            this.cbBus.Size = new System.Drawing.Size(153, 30);
            this.cbBus.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(134, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 22);
            this.label1.TabIndex = 44;
            this.label1.Text = "Bus";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Verdana", 9F);
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editCustomerToolStripMenuItem,
            this.deleteCustomerToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(255, 56);
            // 
            // editCustomerToolStripMenuItem
            // 
            this.editCustomerToolStripMenuItem.Name = "editCustomerToolStripMenuItem";
            this.editCustomerToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.editCustomerToolStripMenuItem.Text = "Edit Registration";
            this.editCustomerToolStripMenuItem.Click += new System.EventHandler(this.editCustomerToolStripMenuItem_Click);
            // 
            // deleteCustomerToolStripMenuItem
            // 
            this.deleteCustomerToolStripMenuItem.Name = "deleteCustomerToolStripMenuItem";
            this.deleteCustomerToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.deleteCustomerToolStripMenuItem.Text = "Delete Registration";
            this.deleteCustomerToolStripMenuItem.Click += new System.EventHandler(this.deleteCustomerToolStripMenuItem_Click);
            // 
            // dtpNavratriDate
            // 
            this.dtpNavratriDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNavratriDate.Location = new System.Drawing.Point(130, 12);
            this.dtpNavratriDate.Name = "dtpNavratriDate";
            this.dtpNavratriDate.Size = new System.Drawing.Size(202, 29);
            this.dtpNavratriDate.TabIndex = 5;
            this.dtpNavratriDate.ValueChanged += new System.EventHandler(this.dtpNavratriDate_ValueChanged);
            // 
            // btnShowAll
            // 
            this.btnShowAll.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAll.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowAll.Location = new System.Drawing.Point(740, 164);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(106, 27);
            this.btnShowAll.TabIndex = 0;
            this.btnShowAll.Text = "Show All";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // btnSearchDatewise
            // 
            this.btnSearchDatewise.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnSearchDatewise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchDatewise.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchDatewise.Location = new System.Drawing.Point(958, 185);
            this.btnSearchDatewise.Name = "btnSearchDatewise";
            this.btnSearchDatewise.Size = new System.Drawing.Size(146, 27);
            this.btnSearchDatewise.TabIndex = 14;
            this.btnSearchDatewise.Text = "Search Datewise";
            this.btnSearchDatewise.UseVisualStyleBackColor = true;
            this.btnSearchDatewise.Visible = false;
            this.btnSearchDatewise.Click += new System.EventHandler(this.btnSearchDatewise_Click);
            // 
            // btnSendSMS
            // 
            this.btnSendSMS.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnSendSMS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendSMS.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendSMS.Location = new System.Drawing.Point(870, 164);
            this.btnSendSMS.Name = "btnSendSMS";
            this.btnSendSMS.Size = new System.Drawing.Size(106, 27);
            this.btnSendSMS.TabIndex = 15;
            this.btnSendSMS.Text = "Send SMS";
            this.btnSendSMS.UseVisualStyleBackColor = true;
            this.btnSendSMS.Click += new System.EventHandler(this.btnSendSMS_Click);
            // 
            // txtAlternateMobileNo
            // 
            this.txtAlternateMobileNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAlternateMobileNo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlternateMobileNo.Location = new System.Drawing.Point(173, 162);
            this.txtAlternateMobileNo.MaxLength = 10;
            this.txtAlternateMobileNo.Name = "txtAlternateMobileNo";
            this.txtAlternateMobileNo.Size = new System.Drawing.Size(164, 29);
            this.txtAlternateMobileNo.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(194, 22);
            this.label4.TabIndex = 48;
            this.label4.Text = "Alternate Mobile No.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbBus);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpNavratriDate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(677, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(389, 95);
            this.panel1.TabIndex = 4;
            // 
            // rbNavratriDate
            // 
            this.rbNavratriDate.AutoSize = true;
            this.rbNavratriDate.Location = new System.Drawing.Point(529, 19);
            this.rbNavratriDate.Name = "rbNavratriDate";
            this.rbNavratriDate.Size = new System.Drawing.Size(158, 26);
            this.rbNavratriDate.TabIndex = 3;
            this.rbNavratriDate.TabStop = true;
            this.rbNavratriDate.Text = "Navratri Date";
            this.rbNavratriDate.UseVisualStyleBackColor = true;
            this.rbNavratriDate.CheckedChanged += new System.EventHandler(this.rbNavratriDate_CheckedChanged);
            // 
            // rbNavratriYear
            // 
            this.rbNavratriYear.AutoSize = true;
            this.rbNavratriYear.Location = new System.Drawing.Point(529, 53);
            this.rbNavratriYear.Name = "rbNavratriYear";
            this.rbNavratriYear.Size = new System.Drawing.Size(155, 26);
            this.rbNavratriYear.TabIndex = 1;
            this.rbNavratriYear.TabStop = true;
            this.rbNavratriYear.Text = "Navratri Year";
            this.rbNavratriYear.UseVisualStyleBackColor = true;
            this.rbNavratriYear.CheckedChanged += new System.EventHandler(this.rbNavratriYear_CheckedChanged);
            // 
            // cbNavratriYear
            // 
            this.cbNavratriYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNavratriYear.FormattingEnabled = true;
            this.cbNavratriYear.Location = new System.Drawing.Point(677, 53);
            this.cbNavratriYear.Name = "cbNavratriYear";
            this.cbNavratriYear.Size = new System.Drawing.Size(121, 30);
            this.cbNavratriYear.TabIndex = 2;
            // 
            // SearchCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Lakshya_Yatra.Properties.Resources.digital_waves_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1146, 650);
            this.Controls.Add(this.cbNavratriYear);
            this.Controls.Add(this.rbNavratriYear);
            this.Controls.Add(this.rbNavratriDate);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtAlternateMobileNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSendSMS);
            this.Controls.Add(this.btnSearchDatewise);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.dgvCustomers);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtMobileNo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbBloodGroup);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCustID);
            this.Controls.Add(this.label12);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SearchCustomer";
            this.Text = "SearchCustomer";
            this.Load += new System.EventHandler(this.SearchCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCustID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbBloodGroup;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.ComboBox cbBus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editCustomerToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dtpNavratriDate;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnSearchDatewise;
        private System.Windows.Forms.Button btnSendSMS;
        private System.Windows.Forms.TextBox txtAlternateMobileNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbNavratriDate;
        private System.Windows.Forms.RadioButton rbNavratriYear;
        private System.Windows.Forms.ComboBox cbNavratriYear;
    }
}