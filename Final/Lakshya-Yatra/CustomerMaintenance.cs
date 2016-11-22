using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lakshya_Yatra
{
    public partial class CustomerMaintenance : Form
    {
        DataTable dtCustomers = null;
        BusinessRules objBusinessRules = new BusinessRules();
        int Customer_ID;
        enum OperationMode
        {
            AddCustomer,
            EditCustomer
        }
        OperationMode runningMode;
        public CustomerMaintenance()
        {
            InitializeComponent();
        }

        private void CustomerMaintenance_Load(object sender, EventArgs e)
        {
            InitializeForm();
        }

        private void InitializeForm()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            txtAlternateMobileNo.Text = string.Empty;
            txtSearchFirstName.Text = txtSearchFirstName.Text = txtSearchLastName.Text = string.Empty;

            chkDontKnowBirthdate.Checked = chkDontKnowBloodGroup.Checked = chkDontKnowAlternateMobile.Checked = true;

            cbArea.DataSource = objBusinessRules.GetAreas();
            cbArea.DisplayMember = "Area";
            cbArea.ValueMember = "Area_ID";

            SetFormForEditCustomer();
        }

        private void chkDontKnowBirthdate_CheckedChanged(object sender, EventArgs e)
        {
            dtpBirthDate.Enabled = !chkDontKnowBirthdate.Checked;
        }

        private void chkDontKnowBloodGroup_CheckedChanged(object sender, EventArgs e)
        {
            cbBloodGroup.Enabled = !chkDontKnowBloodGroup.Checked;
        }

        private void chkDontKnowAlternateMobile_CheckedChanged(object sender, EventArgs e)
        {
            txtAlternateMobileNo.Enabled = !chkDontKnowAlternateMobile.Checked;
        }

        private void SetFormForEditCustomer()
        {
            runningMode = OperationMode.EditCustomer;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            txtAlternateMobileNo.Text = string.Empty;
            txtSearchFirstName.Text = txtSearchFirstName.Text = txtSearchLastName.Text = string.Empty;

            chkDontKnowBirthdate.Checked = chkDontKnowBloodGroup.Checked = chkDontKnowAlternateMobile.Checked = false;

            SearchCustomers(string.Empty, string.Empty, string.Empty);
        }

        private void SetFormForAddCustomer()
        {
            runningMode = OperationMode.AddCustomer;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            txtAlternateMobileNo.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtSearchFirstName.Text = txtSearchFirstName.Text = txtSearchLastName.Text = string.Empty;

            chkDontKnowBirthdate.Checked = chkDontKnowBloodGroup.Checked = chkDontKnowAlternateMobile.Checked = true;

            Customer_ID = 0;
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvCustomers.CurrentRow.Selected = true;
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvCustomers.CurrentRow.Selected = true;
        }

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    Customer_ID = Convert.ToInt16(dgvCustomers.SelectedRows[0].Cells["Customer_ID"].Value);
                    txtFirstName.Text = Convert.ToString(dgvCustomers.SelectedRows[0].Cells["First_Name"].Value);
                    txtLastName.Text = Convert.ToString(dgvCustomers.SelectedRows[0].Cells["Last_Name"].Value);
                    txtAddress.Text = Convert.ToString(dgvCustomers.SelectedRows[0].Cells["Address"].Value);
                    txtMobileNo.Text = Convert.ToString(dgvCustomers.SelectedRows[0].Cells["Mobile_No"].Value);

                    txtAlternateMobileNo.Text = Convert.ToString(dgvCustomers.SelectedRows[0].Cells["Alternate_Mobile"].Value);
                    chkDontKnowAlternateMobile.Checked = string.IsNullOrEmpty(txtAlternateMobileNo.Text);

                    cbArea.SelectedValue = !string.IsNullOrEmpty(Convert.ToString(dgvCustomers.SelectedRows[0].Cells["Area_ID"].Value)) ?
                        Convert.ToInt16(dgvCustomers.SelectedRows[0].Cells["Area_ID"].Value) : 0;

                    if (!string.IsNullOrEmpty(dgvCustomers.SelectedRows[0].Cells["Birth_Date"].Value.ToString()))
                        dtpBirthDate.Value = Convert.ToDateTime(dgvCustomers.SelectedRows[0].Cells["Birth_Date"].Value);
                    else
                        chkDontKnowBirthdate.Checked = true;

                    if (!string.IsNullOrEmpty(Convert.ToString(dgvCustomers.SelectedRows[0].Cells["Blood_Group"].Value)))
                    {
                        chkDontKnowBloodGroup.Checked = false;
                        cbBloodGroup.SelectedItem = cbBloodGroup.Items[cbBloodGroup.Items.IndexOf(Convert.ToString(dgvCustomers.SelectedRows[0].Cells["Blood_Group"].Value))];
                    }
                    else
                    {
                        chkDontKnowBloodGroup.Checked = true;
                        cbBloodGroup.SelectedIndex = -1;
                    }

                    runningMode = OperationMode.EditCustomer;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.Cursor = DefaultCursor;
                }
            }
        }

        private void SearchUsersParametersChanged(object sender, EventArgs e)
        {
            SearchCustomers(txtSearchFirstName.Text.Trim(), txtSearchLastName.Text.Trim(), txtSearchMobileNo.Text.Trim());
        }

        private void SearchCustomers(string FirstName, string LastName, string Mobile_No)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                dtCustomers = objBusinessRules.GetCustomers(FirstName, LastName, Mobile_No);
                dgvCustomers.DataSource = dtCustomers.Rows.Count > 0 ? dtCustomers : null;

                if (dgvCustomers.DataSource != null)
                {
                    dgvCustomers.Rows[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = DefaultCursor;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;
            string Blood_Group = cbBloodGroup.SelectedItem != null ? cbBloodGroup.SelectedItem.ToString() : string.Empty;
            if (runningMode == OperationMode.AddCustomer)
            {
                using (DataTable dt = objBusinessRules.InsertCustomer(txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtMobileNo.Text.Trim(), 
                                                                        txtAddress.Text.Trim(),Convert.ToInt16(cbArea.SelectedValue),dtpBirthDate.Value, !chkDontKnowBirthdate.Checked,Blood_Group,
                                                                        txtAlternateMobileNo.Text.Trim(),User.Instance.User_Name))
                {
                    switch (Convert.ToInt16(dt.Rows[0][0]))
                    {
                        case 0:
                            {
                                MessageBox.Show("User with given Mobile Number already exists", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                break;
                            }
                        default:
                            {
                                MessageBox.Show("User successfully added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                SetFormForAddCustomer();
                                break;
                            }
                    }
                }
            }
            else if (runningMode == OperationMode.EditCustomer)
            {
                using (DataTable dt = objBusinessRules.UpdateCustomer(Customer_ID, txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtMobileNo.Text.Trim(),
                                                                        txtAddress.Text.Trim(),Convert.ToInt16(cbArea.SelectedValue), dtpBirthDate.Value, !chkDontKnowBirthdate.Checked, Blood_Group,
                                                                        txtAlternateMobileNo.Text.Trim(), User.Instance.User_Name))
                {
                    switch (Convert.ToInt16(dt.Rows[0][0]))
                    {
                        case 0:
                            {
                                MessageBox.Show("User with given Mobile Number already exists", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                break;
                            }
                        default:
                            {
                                MessageBox.Show("User successfully updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                SearchCustomers(txtSearchFirstName.Text.Trim(), txtSearchLastName.Text.Trim(), txtSearchMobileNo.Text.Trim());
                                break;
                            }
                    }
                }
            }
        }

        private bool ValidateInputs()
        {
            bool result = true;
            if (string.IsNullOrEmpty(txtMobileNo.Text.Trim()) ||
                string.IsNullOrEmpty(txtFirstName.Text.Trim()) || string.IsNullOrEmpty(txtLastName.Text.Trim()) || string.IsNullOrEmpty(txtAddress.Text.Trim())
                || Convert.ToInt16(cbArea.SelectedValue) == 0)
            {
                MessageBox.Show("Name, Mobile Number, Area and Address are mandatory", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                result = false;
            }
            return result;
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                txtAddress.Text += Clipboard.GetText(TextDataFormat.Text).ToString();
            }
        }

        private void dgvCustomers_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dgvCustomers.ClearSelection();
                this.dgvCustomers.Rows[e.RowIndex].Selected = true;
                Customer_ID = Convert.ToInt16(dgvCustomers.Rows[e.RowIndex].Cells["Customer_ID"].Value);
                //this.dgvCustomers.CurrentCell = this.dgvCustomers.Rows[e.RowIndex].Cells[1];
                this.contextMenuStrip2.Show(this.dgvCustomers, e.Location);
                contextMenuStrip2.Show(Cursor.Position);
            }
        }

        private void deleteCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                DialogResult userConfirmation = MessageBox.Show("Are you sure to delete selected customer?", "Confirm", MessageBoxButtons.YesNoCancel);
                if (userConfirmation != System.Windows.Forms.DialogResult.Yes) return;

                userConfirmation = MessageBox.Show("Are you sure to delete selected customer?", "Confirm", MessageBoxButtons.YesNoCancel);
                if (userConfirmation != System.Windows.Forms.DialogResult.Yes) return;

                userConfirmation = MessageBox.Show("Are you sure to delete selected customer?", "Confirm", MessageBoxButtons.YesNoCancel);
                if (userConfirmation != System.Windows.Forms.DialogResult.Yes) return;

                this.Cursor = Cursors.WaitCursor;
                try
                {
                    Customer_ID = Convert.ToInt16(dgvCustomers.SelectedRows[0].Cells["Customer_ID"].Value);
                    using (DataTable dt = objBusinessRules.DeleteCustomer(Customer_ID))
                    {
                        switch (Convert.ToInt16(dt.Rows[0][0]))
                        {
                            case 0:
                                {
                                    MessageBox.Show("Customer is having seats booked. Cannot be deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    break;
                                }
                            default:
                                {
                                    MessageBox.Show("Customer successfully deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    SearchCustomers(txtSearchFirstName.Text.Trim(), txtSearchLastName.Text.Trim(), txtSearchMobileNo.Text.Trim());
                                    break;
                                }
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.Cursor = DefaultCursor;
                }
            }
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A && sender != null)
                ((TextBox)sender).SelectAll();
        }
    }
}
