namespace Lakshya_Yatra
{
    partial class DeleteAllDataPwd
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpCreatedTo = new System.Windows.Forms.DateTimePicker();
            this.dtpCreatedFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.chkBusRoutes = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkBuses = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkCustomers = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(24, 281);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.AutoCompleteCustomSource.AddRange(new string[] {
            "Abhijit"});
            this.txtPassword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(95, 279);
            this.txtPassword.MaxLength = 40;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(167, 22);
            this.txtPassword.TabIndex = 7;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(428, 273);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(118, 31);
            this.btnSubmit.TabIndex = 8;
            this.btnSubmit.Text = "Delete Data";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.chkCustomers);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.chkBuses);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.chkBusRoutes);
            this.groupBox1.Controls.Add(this.dtpCreatedTo);
            this.groupBox1.Controls.Add(this.dtpCreatedFrom);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(27, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(519, 243);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dtpCreatedTo
            // 
            this.dtpCreatedTo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCreatedTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCreatedTo.Location = new System.Drawing.Point(356, 21);
            this.dtpCreatedTo.Name = "dtpCreatedTo";
            this.dtpCreatedTo.Size = new System.Drawing.Size(127, 22);
            this.dtpCreatedTo.TabIndex = 2;
            // 
            // dtpCreatedFrom
            // 
            this.dtpCreatedFrom.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCreatedFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCreatedFrom.Location = new System.Drawing.Point(123, 21);
            this.dtpCreatedFrom.Name = "dtpCreatedFrom";
            this.dtpCreatedFrom.Size = new System.Drawing.Size(122, 22);
            this.dtpCreatedFrom.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 14);
            this.label2.TabIndex = 21;
            this.label2.Text = "Created From";
            // 
            // chkBusRoutes
            // 
            this.chkBusRoutes.AutoSize = true;
            this.chkBusRoutes.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBusRoutes.Location = new System.Drawing.Point(68, 73);
            this.chkBusRoutes.Name = "chkBusRoutes";
            this.chkBusRoutes.Size = new System.Drawing.Size(97, 18);
            this.chkBusRoutes.TabIndex = 4;
            this.chkBusRoutes.Text = "Bus Routes";
            this.chkBusRoutes.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(171, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(297, 14);
            this.label4.TabIndex = 25;
            this.label4.Text = "(This will delete Routes, their Buses && Tickets)";
            // 
            // chkBuses
            // 
            this.chkBuses.AutoSize = true;
            this.chkBuses.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBuses.Location = new System.Drawing.Point(68, 123);
            this.chkBuses.Name = "chkBuses";
            this.chkBuses.Size = new System.Drawing.Size(49, 18);
            this.chkBuses.TabIndex = 5;
            this.chkBuses.Text = "Bus";
            this.chkBuses.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(171, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(245, 14);
            this.label5.TabIndex = 27;
            this.label5.Text = "(This will delete Buses && their Tickets)";
            // 
            // chkCustomers
            // 
            this.chkCustomers.AutoSize = true;
            this.chkCustomers.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCustomers.Location = new System.Drawing.Point(68, 174);
            this.chkCustomers.Name = "chkCustomers";
            this.chkCustomers.Size = new System.Drawing.Size(87, 18);
            this.chkCustomers.TabIndex = 6;
            this.chkCustomers.Text = "Customer";
            this.chkCustomers.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(171, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(268, 14);
            this.label6.TabIndex = 29;
            this.label6.Text = "(This will delete Customer && their Tickets)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(257, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 30;
            this.label1.Text = "Created To";
            // 
            // DeleteAllDataPwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 369);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DeleteAllDataPwd";
            this.Text = "Delete Data";
            this.Load += new System.EventHandler(this.DeleteAllDataPwd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpCreatedTo;
        private System.Windows.Forms.DateTimePicker dtpCreatedFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkBusRoutes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkBuses;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkCustomers;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
    }
}