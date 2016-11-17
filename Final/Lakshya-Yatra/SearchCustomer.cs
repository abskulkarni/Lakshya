using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Lakshya_Yatra
{
    public partial class SearchCustomer : Form
    {
        int customerID = 0;
        int old_Bus_Master_ID = 0;
        string imagesFolder = string.Empty;
        public SearchCustomer()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            SearchCustomers("");
        }

        private void SearchCustomers(string searchMode = "")
        {
            string strCustID = searchMode != "All" ? txtCustID.Text.Trim() : string.Empty;

            string strBloodGroup = "";
            if (cbBloodGroup.SelectedIndex != -1)
                strBloodGroup = searchMode != "All" ? cbBloodGroup.Items[cbBloodGroup.SelectedIndex].ToString() : string.Empty;

            //string strYatraDate = "";
            //if (cbNavratraDate.SelectedIndex != -1)
            DateTime? strYatraDate = null;
            if (rbNavratriDate.Checked && searchMode != "All")
                strYatraDate = dtpNavratriDate.Value.Date;
            string strMobileNo = searchMode != "All" ? txtMobileNo.Text.Trim() : string.Empty;
            string strAlternateMobileNo = searchMode != "All" ? txtAlternateMobileNo.Text.Trim() : string.Empty;
            string strFirstName = searchMode != "All" ? txtFirstName.Text.Trim() : string.Empty;
            string strLastName = searchMode != "All" ? txtLastName.Text.Trim() : string.Empty;
            string Bus_Name = rbNavratriDate.Checked && cbBus.SelectedItem != null && searchMode != "All" ? cbBus.SelectedItem.ToString() : string.Empty ;
            int Yatra_Year = rbNavratriYear.Checked && searchMode != "All" ? Convert.ToInt16(cbNavratriYear.SelectedItem.ToString()) : 0;

            DataSet ds = new DataSet();
            BusinessRules objBusinessRules = new BusinessRules();
            ds = objBusinessRules.searchCustomer(strCustID, strBloodGroup, strYatraDate, Yatra_Year, strMobileNo, strAlternateMobileNo, strFirstName, strLastName, Bus_Name);

            dgvCustomers.DataSource = ds.Tables[0].Rows.Count > 0 ? ds.Tables[0] : null;

            if (dgvCustomers.DataSource != null)
            {
                dgvCustomers.Columns["Customer_ID"].Visible = dgvCustomers.Columns["Bus_Master_ID"].Visible = 
                    dgvCustomers.Columns["Bus_Route"].Visible = dgvCustomers.Columns["Bus_Time"].Visible =
                    dgvCustomers.Columns["Navratri_Date"].Visible = false;
                dgvCustomers.Columns["Registration_Date"].HeaderText = "Registration Date";
                dgvCustomers.Columns["First_Name"].HeaderText = "First Name";
                dgvCustomers.Columns["Last_Name"].HeaderText = "Last Name";
                dgvCustomers.Columns["Mobile_No"].HeaderText = "Mobile No";
                dgvCustomers.Columns["Alternate_Mobile"].HeaderText = "Alternate Mobile";
                dgvCustomers.Columns["yatra_date"].HeaderText = "Yatra Date";
                dgvCustomers.Columns["Bus_Name"].HeaderText = "Bus Name";
                dgvCustomers.Columns["Seat_No"].HeaderText = "Seat No";

                dgvCustomers.Columns["Registration_Date"].DefaultCellStyle.Alignment =
                    dgvCustomers.Columns["Mobile_No"].DefaultCellStyle.Alignment =
                dgvCustomers.Columns["yatra_date"].DefaultCellStyle.Alignment =
                dgvCustomers.Columns["Bus_Name"].DefaultCellStyle.Alignment =
                dgvCustomers.Columns["Seat_No"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            //dgvCustomers.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill);
        }
        
        private void SearchCustomer_Load(object sender, EventArgs e)
        {
            label1.BackColor = label12.BackColor = label2.BackColor = label3.BackColor = label4.BackColor = label7.BackColor = label8.BackColor = Color.Transparent;
            imagesFolder = ConfigurationManager.AppSettings["ImagesFolder"];

            deleteCustomerToolStripMenuItem.Visible = User.Instance.IsAdmin;

            cbNavratriYear.Items.Clear();
            for (int year = DateTime.Now.Year-2; year <= DateTime.Now.Year; year++)
            {
                cbNavratriYear.Items.Add(year);
            }
            cbNavratriYear.SelectedIndex = cbNavratriYear.Items.Count - 1;
            rbNavratriYear.Checked = true;
            dtpNavratriDate_ValueChanged(null, null);
        }

        private void txtMobileNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (!((e.KeyValue >= 48 && e.KeyValue <= 57) || (e.KeyValue >= 96 && e.KeyValue <= 105)) &&
                !(((TextBox)sender).Text.Trim().Length == 0 && (e.KeyValue == 189 || e.KeyValue == 109)) &&
                !(e.KeyData == Keys.Back || e.KeyData == Keys.Left || e.KeyData == Keys.Right || e.KeyData == Keys.Delete))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void dgvCustomers_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dgvCustomers.ClearSelection();
                this.dgvCustomers.Rows[e.RowIndex].Selected = true;
                customerID = int.Parse(dgvCustomers.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());
                old_Bus_Master_ID = int.Parse(dgvCustomers.Rows[e.RowIndex].Cells[1].Value.ToString().Trim());
                //this.dgvCustomers.CurrentCell = this.dgvCustomers.Rows[e.RowIndex].Cells[1];
                this.contextMenuStrip1.Show(this.dgvCustomers, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void deleteCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            try
            {
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

                BusinessRules objDatabase = new BusinessRules();
                DataSet ds = objDatabase.DeleteTicket(customerID, old_Bus_Master_ID);
                //if (System.IO.File.Exists(imagesFolder + customerID.ToString() + ".jpg"))
                //{
                //    System.IO.File.Delete(imagesFolder + customerID.ToString() + ".jpg");
                //}
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    SearchCustomers();
                    MessageBox.Show("Record deleted successfully!");
                }
                else
                {
                    MessageBox.Show("Error in deleting Record, please contact System Administrator!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in updating Record, please contact System Administrator!\n" + ex.Message.ToString());
            }
        }

        private void editCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Multiple_Registration frmRegistration = (Multiple_Registration)FormFactory.Instance.CreateOrActivateForm("Multiple Registration");
            frmRegistration.Customer_ID = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["Customer_ID"].Value);
            frmRegistration.Bus_Master_ID = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["Bus_Master_ID"].Value);
            frmRegistration.InitializeForm(true);
            frmRegistration.MdiParent = this.MdiParent;
            frmRegistration.WindowState = FormWindowState.Maximized;
            frmRegistration.Show();
            frmRegistration.Focus();
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

        private void dtpNavratriDate_ValueChanged(object sender, EventArgs e)
        {
            BusinessRules objBusinessRules = new BusinessRules();
            DataSet ds = objBusinessRules.getBusByYatraDate(dtpNavratriDate.Value.Date);

            cbBus.Items.Clear();

            if (ds.Tables[0] != null)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    cbBus.Items.Add(row["Bus_Name"]);
                }
                if (cbBus.Items.Count > 0) cbBus.SelectedIndex = 0;
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            SearchCustomers("All");
        }

        private void btnSearchDatewise_Click(object sender, EventArgs e)
        {
            SearchCustomers("Datewise");
        }

        private void btnSendSMS_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                using (DataTable dt = (DataTable)dgvCustomers.DataSource)
                {
                    bool flg = true;
                    if (dgvCustomers.DataSource == null) return;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = dt.Rows[i];
                        DateTime strYatraDate = Convert.ToDateTime(dr["Navratri_Date"]);
                        string date = "\n " + strYatraDate.DayOfWeek.ToString() + " " + strYatraDate.ToString("dd MMM") + "\n";
                        string time = string.Empty;
                        if (dr["Bus_Time"] != DBNull.Value)
                        {
                            TimeSpan t = (TimeSpan)dr["Bus_Time"];
                            // lblBusTime.Text = "( Time : " + Convert.ToDateTime(new DateTime(dtpNavratriDate.MinDate.Year, dtpNavratriDate.MinDate.Month, 1, t.Hours, t.Minutes, 0)).ToString("hh:mm tt") + " )";

                            time = Convert.ToDateTime(new DateTime(dtpNavratriDate.MinDate.Year, dtpNavratriDate.MinDate.Month, 1, t.Hours, t.Minutes, 0)).ToString("hh:mm tt");// dr["Bus_Time"].ToString().Replace("( Time :", "").Replace(" )", "") + "\n";
                        }
                        string firstName = dr["First_Name"].ToString();
                        string lastName = dr["Last_Name"].ToString();
                        string route = dr["Bus_Route"].ToString().Replace(Environment.NewLine, " ");
                        string vehicleNo = dr["Bus_Name"].ToString();// +"\n";// lblVehicleNo.Text + "\n";
                        string SeatNo = dr["Seat_No"].ToString();// +"\n"; //lblSeatNo.Text + "\n";  

                        
                        //string date = " " + strYatraDate.DayOfWeek.ToString() + strYatraDate.ToString(" dd MMM yyyy");
                        //string time = " " + dr["Bus_Time"].ToString();
                        //string route = " " + dr["Bus_Route"].ToString().Replace(Environment.NewLine, " ");
                        string mobile = "+91" + dr["Mobile_No"].ToString();

                        string smsResult = Utilities.Instance.SendSMSUsingBS(firstName,lastName, date, time, route, mobile, vehicleNo, SeatNo);

                        if (smsResult.StartsWith("ES1009"))
                        {
                            flg = false;
                            MessageBox.Show("SMS could not be sent. Invalid Mobile Number : " + mobile, "SMS Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (smsResult.StartsWith("Unable to connect to the remote server"))
                        {
                            flg = false;
                            MessageBox.Show("SMS could not be sent. Please check internet connection", "SMS Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    if (flg)
                    {
                        MessageBox.Show("All SMS sent successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Error in sending all SMS");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error in sending SMS", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void rbNavratriDate_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rbNavratriYear_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = !rbNavratriYear.Checked;
            cbNavratriYear.Visible = rbNavratriYear.Checked;
        }
    }
}
