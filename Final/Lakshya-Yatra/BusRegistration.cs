using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Generic;


namespace Lakshya_Yatra
{

    public partial class BusRegistration : Form
    {
        struct Bus_Route_Item
        {
            public int Route_ID { get; set; }
            public string Bus_Route { get; set; }
        }
        delegate void RefreshBusRoutesHandler();
        event RefreshBusRoutesHandler OnBusRouteChanged = null;
        int seatsPerBus = 0;
        bool addNew = false;
        int Route_ID = 0;
        DataSet dsBusRegistrationInfo;
        BusinessRules objBusiness = new BusinessRules();
        public BusRegistration()
        {
            InitializeComponent();
        }

        private void BusRegistration_Load(object sender, EventArgs e)
        {
            Utilities.Instance.WriteLog("Entered BusRegistration_Load");
            this.OnBusRouteChanged += BusRegistration_OnBusRouteChanged;
            dgvBusRoutes.AutoGenerateColumns = true;
            InitializeForm();
            
            label1.BackColor = label2.BackColor = label3.BackColor = label5.BackColor = label6.BackColor
                = label9.BackColor = label4.BackColor = groupBox1.BackColor = Color.Transparent;
            Utilities.Instance.WriteLog("Exited BusRegistration_Load");
        }

        void RaiseBusRouteChangedEvent()
        {
            if (OnBusRouteChanged != null)
                OnBusRouteChanged();
        }

        void BusRegistration_OnBusRouteChanged()
        {
            dgvBusRoutes.DataSource = null;
            cbBusRoutes.DataSource = null;
            Route_ID = 0;
            txtAddEditBusRoute.Text = string.Empty;


            DataSet dsBusRoutes = objBusiness.GetBusRoutes();
            if (dsBusRoutes.Tables[0].Rows.Count > 0)
            {
                dgvBusRoutes.DataSource = dsBusRoutes.Tables[0].Copy();

                dgvBusRoutes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DataRow dr = dsBusRoutes.Tables[0].NewRow();
                dr["Route_ID"] = 0;
                dr["Bus_Route"] = "--Select--";
                dsBusRoutes.Tables[0].Rows.InsertAt(dr, 0);
                cbBusRoutes.DataSource = dsBusRoutes.Tables[0];
                dgvBusRoutes.Columns["Route_ID"].Visible = false;
                dgvBusRoutes.ClearSelection();
                
            }
            else
            {
                DataRow dr = dsBusRoutes.Tables[0].NewRow();
                dr["Route_ID"] = 0;
                dr["Bus_Route"] = "--Select--";
                dsBusRoutes.Tables[0].Rows.InsertAt(dr, 0);
                cbBusRoutes.DataSource = dsBusRoutes.Tables[0];
            }
            cbBusRoutes.DisplayMember = "Bus_Route";
            cbBusRoutes.ValueMember = "Route_ID";
            cbBusRoutes.SelectedValue = 0;
        }

        private void InitializeForm(bool formLoad = true)
        {
            try
            {
                Utilities.Instance.WriteLog("Entered InitializeForm formLoad = " + formLoad.ToString());
                RaiseBusRouteChangedEvent();
                Utilities.Instance.WriteLog("Calling Business Method GetBusRegistrationInfo");
                dsBusRegistrationInfo = objBusiness.GetBusRegistrationInfo();
                Utilities.Instance.WriteLog("Called Business Method GetBusRegistrationInfo");
                //rbEdit.Checked = true;
                txtBus.Text = string.Empty;
                chkSelectAll.Checked = false;
                seatsPerBus = Convert.ToInt16(ConfigurationManager.AppSettings["SeatsPerBus"]);
                panelBusRoute.Visible = false;
                Utilities.Instance.WriteLog("Calling GetBusNames");
                GetBusNames();
                Utilities.Instance.WriteLog("Called GetBusNames");
            }           
            catch (Exception ex)
            {
                Utilities.Instance.WriteLog("*** Exception in InitializeForm formLoad " + formLoad.ToString() + " : \n" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void GetBusNames()
        {
            //BusinessRules objBusinessRules = new BusinessRules();
            //DataSet ds = objBusinessRules.getAvailableBusName(cbNavratraDate.SelectedItem.ToString());
            Utilities.Instance.WriteLog("Entering GetBusNames Method");
            txtBusFees.Text = string.Empty;
            cbBusRoutes.SelectedValue = 0;
            txtBusFees.Enabled = true;
            cbBus.Items.Clear();
            chkLstAvailableSeatNo.Items.Clear();
            lstBlockedSeatNo.Items.Clear();
            Utilities.Instance.WriteLog("Cleared Control values");
            string expression = string.Format("Navratri_Date = '{0}'", dtpNavratriDate.Value.ToString("yyyy-MM-dd"));
            DataRow[] busNos = dsBusRegistrationInfo.Tables[0].Select(expression);
            Utilities.Instance.WriteLog("Applied filter : " + expression);

            if (busNos.Count() > 0)
            {
                foreach (DataRow row in busNos)
                {
                    if (!cbBus.Items.Contains(row["Bus_Name"].ToString()))
                    {
                        cbBus.Items.Add(row["Bus_Name"].ToString().Trim());                        
                    }
                }

                if (cbBus.Items.Count > 0)
                {
                    Utilities.Instance.WriteLog("Setting cbBus SelectedIndex 0");
                    cbBus.SelectedIndex = 0;
                    btnDeleteBus.Visible = !addNew ? true : false;
                }
                else
                {
                    btnDeleteBus.Visible = false;
                }
            }
            if (addNew)
            {
                Utilities.Instance.WriteLog("AddNew Mode : Adding seats in list box");
                for (int i = 1; i <= seatsPerBus; i++)
                {
                    chkLstAvailableSeatNo.Items.Add(i.ToString());
                }
            }
        }

        private void rbAddNew_CheckedChanged(object sender, EventArgs e)
        {
            Utilities.Instance.WriteLog("Entering rbAddNew_CheckedChanged");
            if (rbAddNew.Checked)
            {
                Utilities.Instance.WriteLog("Entering rbAddNew_CheckedChanged");
                addNew = true;
                txtBus.Visible = true;
                txtBus.Text = string.Empty;
                txtBusFees.Text = string.Empty;
                txtBusFees.Enabled = true;
                cbBus.Visible = false;
                chkLstAvailableSeatNo.Items.Clear();
                lstBlockedSeatNo.Items.Clear();
                RaiseBusRouteChangedEvent();

                for (int i = 1; i <= seatsPerBus; i++)
                {
                    chkLstAvailableSeatNo.Items.Add(i.ToString());
                }

                btnDeleteBus.Visible = false;
            }
            Utilities.Instance.WriteLog("Exiting rbAddNew_CheckedChanged");
        }

        private void rbEdit_CheckedChanged(object sender, EventArgs e)
        {
            Utilities.Instance.WriteLog("Entering rbEdit_CheckedChanged");
            if (rbEdit.Checked)
            {

                Utilities.Instance.WriteLog("Inside rbEdit_CheckedChanged");
                addNew = false;
                txtBus.Visible = false;
                txtBus.Text = string.Empty;
                cbBus.Visible = true;
                InitializeForm(false);

                //cbNavratraDate.SelectedIndex = 0;
            }
            Utilities.Instance.WriteLog("Exiting rbEdit_CheckedChanged");
        }

        private void cbBus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utilities.Instance.WriteLog("Entering cbBus_SelectedIndexChanged");
            chkLstAvailableSeatNo.Items.Clear();
            lstBlockedSeatNo.Items.Clear();

            for (int i = 1; i <= seatsPerBus; i++)
            {
                chkLstAvailableSeatNo.Items.Add(i.ToString());
            }

            if (rbEdit.Checked)
            {
                Utilities.Instance.WriteLog("rbEdit is checked");
                string expression = string.Format("Navratri_Date = '{0}' and Bus_Name = '{1}'", dtpNavratriDate.Value.ToString("yyyy-MM-dd"), cbBus.SelectedItem.ToString());
                DataRow[] seatsInfo = dsBusRegistrationInfo.Tables[0].Select(expression);
                Utilities.Instance.WriteLog("Applied Filter for seatsInfo : " + expression);

                if (seatsInfo.Count() > 0)
                {
                    Utilities.Instance.WriteLog("Entering For Loop as seatsInfo.Count > 0");
                    foreach (DataRow row in seatsInfo)
                    {
                        if (!string.IsNullOrEmpty(row["Is_Seat_Available"].ToString()))
                        {
                            if (Convert.ToBoolean(row["Is_Seat_Available"]) == true)
                            {                                
                                chkLstAvailableSeatNo.SetItemChecked(chkLstAvailableSeatNo.Items.IndexOf(row["Seat_No"].ToString()), true);
                            }
                            else
                            {
                                lstBlockedSeatNo.Items.Add(row["Seat_No"].ToString());
                                chkLstAvailableSeatNo.Items.Remove(row["Seat_No"].ToString());
                            }
                        }

                        txtBusFees.Text = row["Bus_Fees"].ToString();
                        //DateTime dt = new DateTime()
                        if (row["Bus_Time"] != DBNull.Value)
                        {
                            TimeSpan t = (TimeSpan)row["Bus_Time"];

                            dtpBusTime.Value = new DateTime(dtpBusTime.MinDate.Year, dtpBusTime.MinDate.Month, 1, t.Hours, t.Minutes, 0);
                        }
                        else
                        {
                            dtpBusTime.Value = DateTime.Now;
                        }
                        //txtBusRoute.Text = row["Bus_Route"].ToString();
                        cbBusRoutes.SelectedValue = Convert.ToInt16(row["Route_ID"]);
                    }
                    txtBusFees.Enabled = !(lstBlockedSeatNo.Items.Count > 0);
                    Utilities.Instance.WriteLog("Exiting For Loop");
                }
            }
            Utilities.Instance.WriteLog("Exiting cbBus_SelectedIndexChanged");
        }

        private bool ValidateInputs()
        {
            bool result = true;
            if (cbBus.Items.Contains(txtBus.Text.Trim()))
            {
                result = false;
                MessageBox.Show("Given Bus Name already exists for selected date.");
            }

            if (result)
            {
                if (!addNew && cbBus.SelectedItem == null)
                {
                    result = false;
                    MessageBox.Show("Please select Bus Name");
                }
            }

            if (result)
            {
                if (addNew && string.IsNullOrEmpty(txtBus.Text.Trim()))
                {
                    result = false;
                    MessageBox.Show("Please enter Bus Name"); 
                }
            }

            if (result)
            {
                if (addNew && string.IsNullOrEmpty(txtBusFees.Text.Trim()))
                {
                    result = false;
                    MessageBox.Show("Please enter Bus Fees");
                }
            }

            if (result)
            {
                //if (string.IsNullOrEmpty(txtBusRoute.Text.Trim()))
                if (Convert.ToInt16(cbBusRoutes.SelectedValue) == 0)
                {
                    result = false;
                    MessageBox.Show("Please enter Bus Route");
                }
            }
            return result;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Utilities.Instance.WriteLog("Entering btnSubmit_Click");
            if (ValidateInputs() == false) return;
            try
            {
                DateTime Navratri_Date = dtpNavratriDate.Value.Date;
                string Bus_Name = addNew ? txtBus.Text.Trim() : cbBus.SelectedItem.ToString();
                int Seat_Count = seatsPerBus;
                int Bus_Fees = Convert.ToInt16(txtBusFees.Text.Trim());
                int Route_ID = Convert.ToInt16(cbBusRoutes.SelectedValue);
                DateTime Bus_Time = dtpBusTime.Value;


                StringBuilder Seat_No = new StringBuilder();
                foreach (string item in chkLstAvailableSeatNo.CheckedItems)
                {
                    Seat_No.Append(string.IsNullOrEmpty(Seat_No.ToString()) ? item : string.Format(",{0}", item));
                }
                Utilities.Instance.WriteLog("Got Form Control Values");
                BusinessRules objBusinessRules = new BusinessRules();
                Utilities.Instance.WriteLog("Calling Business Method UpdateBusRegistration");
                DataSet ds = objBusinessRules.UpdateBusRegistration(Bus_Name, Navratri_Date, Seat_No.ToString(), Seat_Count, Bus_Fees, Route_ID, Bus_Time, User.Instance.User_Name);
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    Utilities.Instance.WriteLog("Calling InitializeForm after UpdateBusRegistration");
                    InitializeForm(false);
                    MessageBox.Show("Record updated successfully.");
                }
            }

            catch (Exception ex)
            {
                Utilities.Instance.WriteLog("*** Exception in btnSubmit_Click : \n" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void dtpNavratriDate_ValueChanged(object sender, EventArgs e)
        {
            Utilities.Instance.WriteLog("Entering dtpNavratriDate_ValueChanged");
            GetBusNames();
            Utilities.Instance.WriteLog("Exiting dtpNavratriDate_ValueChanged");
        }

        private void AllowDecimal(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back ||
                        e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Back
                        || e.KeyChar == (char)Keys.Right || e.KeyChar == (char)Keys.Left))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void RestrictToNegativeInteger(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back ||
                        e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Back
                        || e.KeyChar == (char)Keys.Right || e.KeyChar == (char)Keys.Left) || e.KeyChar == '.')
            { e.Handled = true; }
            TextBox txtNegativeNumber = sender as TextBox;
            if (e.KeyChar == '-' && txtNegativeNumber.Text.Trim().Length == 0)
            {
                e.Handled = false;
            }
        }

        private void RestrictToPositiveInteger(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back ||
                        e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Back
                        || e.KeyChar == (char)Keys.Right || e.KeyChar == (char)Keys.Left) || e.KeyChar == '.')
            { e.Handled = true; }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkSelectAll.Checked)
            {
                foreach (int i in chkLstAvailableSeatNo.CheckedIndices)
                {
                    chkLstAvailableSeatNo.SetItemCheckState(i, CheckState.Unchecked);
                }

            }
            else
            {
                for (int i = 0; i < chkLstAvailableSeatNo.Items.Count; i++)
                {
                    chkLstAvailableSeatNo.SetItemChecked(i, true);
                }
            }
        }

        private void btnDeleteBus_Click(object sender, EventArgs e)
        {
            if (lstBlockedSeatNo.Items.Count > 0)
            {
                MessageBox.Show("Bus cannot be deleted. Bus seats are booked.",
                                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            DialogResult f = MessageBox.Show("Are you sure to delete this entry?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (f == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            f = MessageBox.Show("Are you sure to delete this entry?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (f == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            f = MessageBox.Show("Are you sure to delete this entry?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (f == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            try
            {
                if (!addNew)
                {
                    DateTime Navratri_Date = dtpNavratriDate.Value.Date;
                    string Bus_Name = cbBus.SelectedItem.ToString();

                    BusinessRules objBusinessRules = new BusinessRules();
                    DataSet ds = objBusinessRules.DeleteBus(Bus_Name, Navratri_Date);
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        MessageBox.Show("Bus cannot be deleted. Please check if this Bus has got bookings recently.",
                                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("Bus deleted successfully.",
                                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        InitializeForm(false);
                    }
                }
            }

            catch (Exception ex)
            {
                Utilities.Instance.WriteLog("*** Exception in btnSubmit_Click : \n" + ex.Message);
                MessageBox.Show(ex.Message);
            }

        }

        private void lnkAddEditBusRoute_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelBusRoute.Visible = true;
        }

        private void btnCloseAddEditBusRoute_Click(object sender, EventArgs e)
        {
            panelBusRoute.Visible = false;
        }

        private void btnAddNewBusRoute_Click(object sender, EventArgs e)
        {
            Route_ID = 0;
            txtAddEditBusRoute.Text = string.Empty;
        }

        private void dgvBusRoutes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvBusRoutes.CurrentRow.Selected = true;
            ConfigureEditBusRoute();
        }

        private void ConfigureEditBusRoute()
        {
            if (dgvBusRoutes.SelectedRows.Count > 0)
            {
                Route_ID = Convert.ToInt16(dgvBusRoutes.SelectedRows[0].Cells["Route_ID"].Value);
                txtAddEditBusRoute.Text = Convert.ToString(dgvBusRoutes.SelectedRows[0].Cells["Bus_Route"].Value);
            }
        }

        private void dgvBusRoutes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvBusRoutes.CurrentRow.Selected = true;
            ConfigureEditBusRoute();
        }

        private void btnSubmitBusRoute_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAddEditBusRoute.Text))
            {
                MessageBox.Show("Please enter Bus Route");
                return;
            }
            
            string Bus_Route = txtAddEditBusRoute.Text.Trim();
            try
            {
                DataSet ds = objBusiness.InsertUpdateBusRoute(Route_ID, Bus_Route, User.Instance.User_Name);
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    MessageBox.Show("Record updated successfully!");
                    RaiseBusRouteChangedEvent();

                }
                else
                {
                    MessageBox.Show("Error in updating Record, please contact System Administrator!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in updating Record, please contact System Administrator!\n" + ex.Message.ToString());
            }
        }
    }
}
