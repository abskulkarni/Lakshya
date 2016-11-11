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
    public partial class UserMaintenance : Form
    {
        DataTable dtUsers = null;
        enum OperationMode
        {
            AddUser,
            EditUser
        }
        OperationMode runningMode;
        public UserMaintenance()
        {
            InitializeComponent();
        }

        private void SetFormForAddUser()
        {
            runningMode = OperationMode.AddUser;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtUserName.Text = string.Empty;

            txtUserName.ReadOnly = false;
            chkIsAdmin.Checked = false;
        }

        private void SetFormForEditUser()
        {
            runningMode = OperationMode.EditUser;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtSearchFirstName.Text = string.Empty;
            txtSearchLastName.Text = string.Empty;
            SearchUsers(string.Empty, string.Empty, string.Empty);

            txtUserName.ReadOnly = true;
        }

        private void rdEditDeleteUser_CheckedChanged(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = false;
            SetFormForEditUser();
        }

        private void rdAddNewUser_CheckedChanged(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = true;
            SetFormForAddUser();
        }
        private void InitializeForm()
        {
            rdEditDeleteUser.Checked = true;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtUserName.Text = string.Empty;
            SearchUsers(txtUserName.Text.Trim(), txtFirstName.Text.Trim(), txtLastName.Text.Trim());
        }

        private void SearchUsers(string UserName, string FirstName,string LastName)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {                
                BusinessRules objBusinessRules = new BusinessRules();
                dtUsers = objBusinessRules.GetUserDetails(UserName,FirstName,LastName);
                dgvUsers.DataSource = dtUsers.Rows.Count > 0 ? dtUsers : null;

                if (dgvUsers.DataSource != null)
                {
                    dgvUsers.Rows[0].Selected = true;
                    dgvUsers.Columns["Password"].Visible = false;
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

        private void UserMaintenance_Load(object sender, EventArgs e)
        {
            InitializeForm();
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                DialogResult userConfirmation = MessageBox.Show("Are you sure to delete selected user?", "Confirm", MessageBoxButtons.YesNoCancel);
                if (userConfirmation != System.Windows.Forms.DialogResult.Yes) return;

                this.Cursor = Cursors.WaitCursor;
                try
                {
                    string User_Name = Convert.ToString(dgvUsers.SelectedRows[0].Cells["User_Name"].Value);
                    BusinessRules objBusinessRules = new BusinessRules();
                    using (DataTable dt = objBusinessRules.DeleteUser(User_Name))
                    {
                        switch (Convert.ToInt16(dt.Rows[0][0]))
                        {
                            case -2:
                                {
                                    MessageBox.Show("Selected user has already been deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    SearchUsers(string.Empty,txtSearchFirstName.Text.Trim(),txtSearchLastName.Text.Trim());
                                    break;
                                }
                            case 0:
                                {
                                    MessageBox.Show("User deleted successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    SearchUsers(string.Empty, txtSearchFirstName.Text.Trim(), txtSearchLastName.Text.Trim());
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

        private void SearchUsersParametersChanged(object sender, EventArgs e)
        {
            SearchUsers(string.Empty, txtSearchFirstName.Text.Trim(), txtSearchLastName.Text.Trim());
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvUsers.CurrentRow.Selected = true;
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvUsers.CurrentRow.Selected = true;
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    txtUserName.Text = Convert.ToString(dgvUsers.SelectedRows[0].Cells["User_Name"].Value);
                    txtFirstName.Text = Convert.ToString(dgvUsers.SelectedRows[0].Cells["First_Name"].Value);
                    txtLastName.Text = Convert.ToString(dgvUsers.SelectedRows[0].Cells["Last_Name"].Value);
                    txtPassword.Text = Convert.ToString(dgvUsers.SelectedRows[0].Cells["Password"].Value);
                    chkIsAdmin.Checked = Convert.ToBoolean(dgvUsers.SelectedRows[0].Cells["IsAdmin"].Value);
                    runningMode = OperationMode.EditUser;
                    txtUserName.ReadOnly = true;

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

        private bool ValidateInputs()
        {
            bool result = true;
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()) || string.IsNullOrEmpty(txtPassword.Text.Trim()) ||
                string.IsNullOrEmpty(txtFirstName.Text.Trim()) || string.IsNullOrEmpty(txtLastName.Text.Trim()))
            {
                MessageBox.Show("All Fields are mandatory", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                result = false;
            }
            return result;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;
            BusinessRules objBusinessRules = new BusinessRules();
            if (runningMode == OperationMode.AddUser)
            {
                using (DataTable dt = objBusinessRules.CreateUser(txtUserName.Text.Trim(), txtPassword.Text.Trim(),
                                                                    txtFirstName.Text.Trim(), txtLastName.Text.Trim(), chkIsAdmin.Checked))
                {
                    switch(Convert.ToInt16(dt.Rows[0][0]))
                    {
                        case -2:
                            {
                                MessageBox.Show("User Name already exists", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);                                
                                break;
                            }
                        case 0:
                            {
                                MessageBox.Show("User successfully added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtFirstName.Text = string.Empty;
                                txtLastName.Text = string.Empty;
                                txtPassword.Text = string.Empty;
                                txtUserName.Text = string.Empty;
                                break;
                            }
                    }
                }
            }
            else if (runningMode == OperationMode.EditUser)
            {
                using (DataTable dt = objBusinessRules.UpdateUser(txtUserName.Text.Trim(), txtPassword.Text.Trim(),
                                                                    txtFirstName.Text.Trim(), txtLastName.Text.Trim(), chkIsAdmin.Checked))
                {
                    MessageBox.Show("User updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (User.Instance.User_Name == txtUserName.Text.Trim())
                    {
                        User.Instance.First_Name = Convert.ToString(dt.Rows[0]["First_Name"]);
                        User.Instance.Last_Name = Convert.ToString(dt.Rows[0]["Last_Name"]);
                        this.Parent.Text = "Lakshya - Yatra ==== (Logged in User : " + User.Instance.First_Name + " " + User.Instance.Last_Name + ")";
                    }
                    SearchUsers(string.Empty, string.Empty, string.Empty);
                }
            }
        }
    }
}
