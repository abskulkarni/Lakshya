namespace Lakshya_Yatra
{
    partial class BusRegistration
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
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbBus = new System.Windows.Forms.ComboBox();
            this.lstBlockedSeatNo = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtBus = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbAddNew = new System.Windows.Forms.RadioButton();
            this.rbEdit = new System.Windows.Forms.RadioButton();
            this.dtpNavratriDate = new System.Windows.Forms.DateTimePicker();
            this.chkLstAvailableSeatNo = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBusFees = new System.Windows.Forms.TextBox();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpBusTime = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDeleteBus = new System.Windows.Forms.Button();
            this.panelBusRoute = new System.Windows.Forms.Panel();
            this.dgvBusRoutes = new System.Windows.Forms.DataGridView();
            this.btnCloseAddEditBusRoute = new System.Windows.Forms.Button();
            this.btnAddNewBusRoute = new System.Windows.Forms.Button();
            this.btnSubmitBusRoute = new System.Windows.Forms.Button();
            this.txtAddEditBusRoute = new System.Windows.Forms.TextBox();
            this.cbBusRoutes = new System.Windows.Forms.ComboBox();
            this.btnAddEditBusRoute = new System.Windows.Forms.Button();
            this.chkIsVisible = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.panelBusRoute.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusRoutes)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Navratri Date";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(55, 194);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 14);
            this.label9.TabIndex = 10;
            this.label9.Text = "Bus Name";
            // 
            // cbBus
            // 
            this.cbBus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBus.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBus.FormattingEnabled = true;
            this.cbBus.Location = new System.Drawing.Point(132, 192);
            this.cbBus.Name = "cbBus";
            this.cbBus.Size = new System.Drawing.Size(135, 22);
            this.cbBus.TabIndex = 4;
            this.cbBus.SelectedIndexChanged += new System.EventHandler(this.cbBus_SelectedIndexChanged);
            // 
            // lstBlockedSeatNo
            // 
            this.lstBlockedSeatNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstBlockedSeatNo.FormattingEnabled = true;
            this.lstBlockedSeatNo.ItemHeight = 14;
            this.lstBlockedSeatNo.Location = new System.Drawing.Point(277, 292);
            this.lstBlockedSeatNo.Name = "lstBlockedSeatNo";
            this.lstBlockedSeatNo.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstBlockedSeatNo.Size = new System.Drawing.Size(135, 254);
            this.lstBlockedSeatNo.TabIndex = 10;
            this.lstBlockedSeatNo.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(276, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 14);
            this.label1.TabIndex = 13;
            this.label1.Text = "Blocked Seat Nos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(5, 292);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 28);
            this.label3.TabIndex = 15;
            this.label3.Text = "Available Seat Nos\r\nfor Allocation";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(421, 463);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(108, 31);
            this.btnSubmit.TabIndex = 11;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtBus
            // 
            this.txtBus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBus.Location = new System.Drawing.Point(132, 192);
            this.txtBus.MaxLength = 4;
            this.txtBus.Name = "txtBus";
            this.txtBus.Size = new System.Drawing.Size(135, 22);
            this.txtBus.TabIndex = 6;
            this.txtBus.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbAddNew);
            this.groupBox1.Controls.Add(this.rbEdit);
            this.groupBox1.Location = new System.Drawing.Point(136, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 42);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // rbAddNew
            // 
            this.rbAddNew.AutoSize = true;
            this.rbAddNew.Location = new System.Drawing.Point(87, 18);
            this.rbAddNew.Name = "rbAddNew";
            this.rbAddNew.Size = new System.Drawing.Size(81, 18);
            this.rbAddNew.TabIndex = 2;
            this.rbAddNew.Text = "Add New";
            this.rbAddNew.UseVisualStyleBackColor = true;
            this.rbAddNew.CheckedChanged += new System.EventHandler(this.rbAddNew_CheckedChanged);
            // 
            // rbEdit
            // 
            this.rbEdit.AutoSize = true;
            this.rbEdit.Checked = true;
            this.rbEdit.Location = new System.Drawing.Point(16, 18);
            this.rbEdit.Name = "rbEdit";
            this.rbEdit.Size = new System.Drawing.Size(49, 18);
            this.rbEdit.TabIndex = 1;
            this.rbEdit.TabStop = true;
            this.rbEdit.Text = "Edit";
            this.rbEdit.UseVisualStyleBackColor = true;
            this.rbEdit.CheckedChanged += new System.EventHandler(this.rbEdit_CheckedChanged);
            // 
            // dtpNavratriDate
            // 
            this.dtpNavratriDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNavratriDate.Location = new System.Drawing.Point(110, 21);
            this.dtpNavratriDate.Name = "dtpNavratriDate";
            this.dtpNavratriDate.Size = new System.Drawing.Size(256, 22);
            this.dtpNavratriDate.TabIndex = 4;
            this.dtpNavratriDate.ValueChanged += new System.EventHandler(this.dtpNavratriDate_ValueChanged);
            // 
            // chkLstAvailableSeatNo
            // 
            this.chkLstAvailableSeatNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chkLstAvailableSeatNo.CheckOnClick = true;
            this.chkLstAvailableSeatNo.FormattingEnabled = true;
            this.chkLstAvailableSeatNo.Location = new System.Drawing.Point(135, 292);
            this.chkLstAvailableSeatNo.Name = "chkLstAvailableSeatNo";
            this.chkLstAvailableSeatNo.Size = new System.Drawing.Size(128, 223);
            this.chkLstAvailableSeatNo.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(62, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 14);
            this.label4.TabIndex = 18;
            this.label4.Text = "Bus Fees";
            // 
            // txtBusFees
            // 
            this.txtBusFees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBusFees.Location = new System.Drawing.Point(133, 232);
            this.txtBusFees.MaxLength = 4;
            this.txtBusFees.Name = "txtBusFees";
            this.txtBusFees.Size = new System.Drawing.Size(135, 22);
            this.txtBusFees.TabIndex = 8;
            this.txtBusFees.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RestrictToPositiveInteger);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkSelectAll.Location = new System.Drawing.Point(136, 267);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(88, 19);
            this.chkSelectAll.TabIndex = 9;
            this.chkSelectAll.Text = "Select All";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(29, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 14);
            this.label5.TabIndex = 20;
            this.label5.Text = "Bus Route";
            // 
            // dtpBusTime
            // 
            this.dtpBusTime.CustomFormat = "hh:mm tt";
            this.dtpBusTime.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBusTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBusTime.Location = new System.Drawing.Point(355, 192);
            this.dtpBusTime.Name = "dtpBusTime";
            this.dtpBusTime.ShowUpDown = true;
            this.dtpBusTime.Size = new System.Drawing.Size(130, 22);
            this.dtpBusTime.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(286, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 22;
            this.label6.Text = "Bus Time";
            // 
            // btnDeleteBus
            // 
            this.btnDeleteBus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnDeleteBus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteBus.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteBus.Location = new System.Drawing.Point(421, 516);
            this.btnDeleteBus.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.btnDeleteBus.Name = "btnDeleteBus";
            this.btnDeleteBus.Size = new System.Drawing.Size(108, 31);
            this.btnDeleteBus.TabIndex = 23;
            this.btnDeleteBus.TabStop = false;
            this.btnDeleteBus.Text = "Delete Bus";
            this.btnDeleteBus.UseVisualStyleBackColor = false;
            this.btnDeleteBus.Visible = false;
            this.btnDeleteBus.Click += new System.EventHandler(this.btnDeleteBus_Click);
            // 
            // panelBusRoute
            // 
            this.panelBusRoute.Controls.Add(this.dgvBusRoutes);
            this.panelBusRoute.Controls.Add(this.btnCloseAddEditBusRoute);
            this.panelBusRoute.Controls.Add(this.btnAddNewBusRoute);
            this.panelBusRoute.Controls.Add(this.btnSubmitBusRoute);
            this.panelBusRoute.Controls.Add(this.txtAddEditBusRoute);
            this.panelBusRoute.Location = new System.Drawing.Point(560, 12);
            this.panelBusRoute.Name = "panelBusRoute";
            this.panelBusRoute.Size = new System.Drawing.Size(476, 428);
            this.panelBusRoute.TabIndex = 92;
            this.panelBusRoute.Visible = false;
            // 
            // dgvBusRoutes
            // 
            this.dgvBusRoutes.AllowUserToAddRows = false;
            this.dgvBusRoutes.AllowUserToDeleteRows = false;
            this.dgvBusRoutes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBusRoutes.Location = new System.Drawing.Point(230, 44);
            this.dgvBusRoutes.Name = "dgvBusRoutes";
            this.dgvBusRoutes.ReadOnly = true;
            this.dgvBusRoutes.Size = new System.Drawing.Size(239, 361);
            this.dgvBusRoutes.TabIndex = 15;
            this.dgvBusRoutes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBusRoutes_CellClick);
            this.dgvBusRoutes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBusRoutes_CellContentClick);
            // 
            // btnCloseAddEditBusRoute
            // 
            this.btnCloseAddEditBusRoute.Location = new System.Drawing.Point(437, 10);
            this.btnCloseAddEditBusRoute.Name = "btnCloseAddEditBusRoute";
            this.btnCloseAddEditBusRoute.Size = new System.Drawing.Size(33, 22);
            this.btnCloseAddEditBusRoute.TabIndex = 95;
            this.btnCloseAddEditBusRoute.Text = "X";
            this.btnCloseAddEditBusRoute.UseVisualStyleBackColor = true;
            this.btnCloseAddEditBusRoute.Click += new System.EventHandler(this.btnCloseAddEditBusRoute_Click);
            // 
            // btnAddNewBusRoute
            // 
            this.btnAddNewBusRoute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnAddNewBusRoute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewBusRoute.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewBusRoute.Location = new System.Drawing.Point(13, 83);
            this.btnAddNewBusRoute.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.btnAddNewBusRoute.Name = "btnAddNewBusRoute";
            this.btnAddNewBusRoute.Size = new System.Drawing.Size(86, 31);
            this.btnAddNewBusRoute.TabIndex = 14;
            this.btnAddNewBusRoute.TabStop = false;
            this.btnAddNewBusRoute.Text = "Add New";
            this.btnAddNewBusRoute.UseVisualStyleBackColor = false;
            this.btnAddNewBusRoute.Click += new System.EventHandler(this.btnAddNewBusRoute_Click);
            // 
            // btnSubmitBusRoute
            // 
            this.btnSubmitBusRoute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSubmitBusRoute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmitBusRoute.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmitBusRoute.Location = new System.Drawing.Point(131, 83);
            this.btnSubmitBusRoute.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.btnSubmitBusRoute.Name = "btnSubmitBusRoute";
            this.btnSubmitBusRoute.Size = new System.Drawing.Size(93, 31);
            this.btnSubmitBusRoute.TabIndex = 13;
            this.btnSubmitBusRoute.Text = "Submit";
            this.btnSubmitBusRoute.UseVisualStyleBackColor = false;
            this.btnSubmitBusRoute.Click += new System.EventHandler(this.btnSubmitBusRoute_Click);
            // 
            // txtAddEditBusRoute
            // 
            this.txtAddEditBusRoute.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddEditBusRoute.Location = new System.Drawing.Point(13, 43);
            this.txtAddEditBusRoute.MaxLength = 50;
            this.txtAddEditBusRoute.Name = "txtAddEditBusRoute";
            this.txtAddEditBusRoute.Size = new System.Drawing.Size(211, 22);
            this.txtAddEditBusRoute.TabIndex = 12;
            // 
            // cbBusRoutes
            // 
            this.cbBusRoutes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBusRoutes.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBusRoutes.FormattingEnabled = true;
            this.cbBusRoutes.Location = new System.Drawing.Point(108, 60);
            this.cbBusRoutes.Name = "cbBusRoutes";
            this.cbBusRoutes.Size = new System.Drawing.Size(167, 22);
            this.cbBusRoutes.TabIndex = 5;
            this.cbBusRoutes.SelectedIndexChanged += new System.EventHandler(this.cbBusRoutes_SelectedIndexChanged);
            // 
            // btnAddEditBusRoute
            // 
            this.btnAddEditBusRoute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnAddEditBusRoute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddEditBusRoute.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEditBusRoute.Location = new System.Drawing.Point(410, 142);
            this.btnAddEditBusRoute.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.btnAddEditBusRoute.Name = "btnAddEditBusRoute";
            this.btnAddEditBusRoute.Size = new System.Drawing.Size(141, 26);
            this.btnAddEditBusRoute.TabIndex = 95;
            this.btnAddEditBusRoute.TabStop = false;
            this.btnAddEditBusRoute.Text = "Add/Edit Bus Route";
            this.btnAddEditBusRoute.UseVisualStyleBackColor = false;
            this.btnAddEditBusRoute.Click += new System.EventHandler(this.btnAddEditBusRoute_Click);
            // 
            // chkIsVisible
            // 
            this.chkIsVisible.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsVisible.Location = new System.Drawing.Point(407, 65);
            this.chkIsVisible.Name = "chkIsVisible";
            this.chkIsVisible.Size = new System.Drawing.Size(141, 61);
            this.chkIsVisible.TabIndex = 96;
            this.chkIsVisible.TabStop = false;
            this.chkIsVisible.Text = "Mark this combination as Visible";
            this.chkIsVisible.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpNavratriDate);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cbBusRoutes);
            this.groupBox2.Location = new System.Drawing.Point(27, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(374, 108);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // BusRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Lakshya_Yatra.Properties.Resources.digital_waves_background;
            this.ClientSize = new System.Drawing.Size(1094, 603);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.chkIsVisible);
            this.Controls.Add(this.btnAddEditBusRoute);
            this.Controls.Add(this.panelBusRoute);
            this.Controls.Add(this.btnDeleteBus);
            this.Controls.Add(this.dtpBusTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.txtBusFees);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkLstAvailableSeatNo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtBus);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstBlockedSeatNo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbBus);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "BusRegistration";
            this.Text = "Bus Registration";
            this.Load += new System.EventHandler(this.BusRegistration_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelBusRoute.ResumeLayout(false);
            this.panelBusRoute.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusRoutes)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbBus;
        private System.Windows.Forms.ListBox lstBlockedSeatNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtBus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbAddNew;
        private System.Windows.Forms.RadioButton rbEdit;
        private System.Windows.Forms.DateTimePicker dtpNavratriDate;
        private System.Windows.Forms.CheckedListBox chkLstAvailableSeatNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBusFees;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpBusTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDeleteBus;
        private System.Windows.Forms.Panel panelBusRoute;
        private System.Windows.Forms.ComboBox cbBusRoutes;
        private System.Windows.Forms.TextBox txtAddEditBusRoute;
        private System.Windows.Forms.Button btnAddNewBusRoute;
        private System.Windows.Forms.Button btnSubmitBusRoute;
        private System.Windows.Forms.Button btnCloseAddEditBusRoute;
        private System.Windows.Forms.DataGridView dgvBusRoutes;
        private System.Windows.Forms.Button btnAddEditBusRoute;
        private System.Windows.Forms.CheckBox chkIsVisible;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}