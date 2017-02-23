using System;
using System.Data;
using System.Windows.Forms;

namespace Lakshya_Yatra
{
    public partial class LakshyaYatra : Form
    {
        public LakshyaYatra()
        {
            InitializeComponent();
        }
                
        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printPreviewToolStripButton_Click(object sender, EventArgs e)
        {
            ShowForm("SearchCustomer");
        }
        
        private void busRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Bus Registration");
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("SearchCustomer");
        }

        private void deleteAllDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Delete Data");
        }

        private void busReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("BusReport");
        }

        private void emptySeatsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Empty Seats");
        }
        
        private void cashExpenseTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Cash Expenses");
        }

        private void dailyCashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Daily Cash Report");
        }

        private void yatraDatewiseCashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Report");
        }

        private void allYatraDatesAllBusesCashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("All Yatra Dates - All Buses Report");
        }

        private void LakshyaYatra_Load(object sender, EventArgs e)
        {
            InitializeForm();
        }

        private void InitializeForm()
        {
            panelLogin.Visible = true;
            txtUserName.Text = txtPassword.Text = string.Empty;
            txtUserName.Focus();
            menuStrip.Enabled = toolStrip.Enabled = false;           
        }

        private bool ValidateInputs()
        {
            bool result = true;
            //User Name
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                result = false;
                MessageBox.Show("Please enter User Name.");
                txtUserName.Focus();
            }

            //Password
            if (result)
            {
                if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    result = false;
                    MessageBox.Show("Please enter Password.");
                    txtPassword.Focus();
                }
            }

            return result;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {            
            if (ValidateInputs())
            {
                BusinessRules objBusinessRules = new BusinessRules();
                using(DataTable dt = objBusinessRules.AuthenticateUser(txtUserName.Text.Trim(), txtPassword.Text.Trim()))
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["User_Name"].ToString()))
                    {
                        panelLogin.Visible = false;
                        menuStrip.Enabled = toolStrip.Enabled = true;

                        User.Instance.User_Name = txtUserName.Text.Trim();
                        User.Instance.First_Name = Convert.ToString(dt.Rows[0]["First_Name"]);
                        User.Instance.Last_Name = Convert.ToString(dt.Rows[0]["Last_Name"]);
                        User.Instance.Password = Convert.ToString(dt.Rows[0]["Password"]);
                        User.Instance.IsAdmin = Convert.ToBoolean(dt.Rows[0]["IsAdmin"]);

                        userManagementToolStripMenuItem.Visible = deleteAllDataToolStripMenuItem.Visible = User.Instance.IsAdmin;
                        //userManagementToolStripMenuItem.Visible = User.Instance.IsAdmin;

                        this.Text = "Lakshya - Yatra ==== (Logged in User : " + User.Instance.First_Name + " " + User.Instance.Last_Name + ")";

                    }
                    else
                    {
                        MessageBox.Show("Invalid User Name/Password combination", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("User Maintenance");
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Change Password");
        }

        private void discountReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Discount Report");
        }

        private void bloodGroupReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Blood Group Report");
        }

        private void userwiseCashReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Userwise Cash Report");
        }

        private void signOutToolStripButton_Click(object sender, EventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i-- )
            {
                if (Application.OpenForms[i].Text != this.Text)
                    Application.OpenForms[i].Close();
            }

            InitializeForm();
        }

        private void userwiseYearlyCashReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Userwise Yearly Cash Report");
        }

        private void expenseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Expense Report");
        }

        private void birthDateReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Birth Date Report");
        }

        private void birthdayWishesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Birthday Wishes");
        }

        private void customSMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Custom SMS");
        }

        private void toolStripMultipleRegistrationsMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Multiple Registration");
        }

        private void userwiseTicketReportMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Userwise Ticket Report");
        }

        private void electionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Election Report");
        }

        private void multipleRegistrationToolStripButton_Click(object sender, EventArgs e)
        {
            ShowForm("Multiple Registration");
        }

        private void customerManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Customer Maintenance");
        }

        private void areaManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Area Maintenance");
        }
        
        private void ShowForm(string formName)
        {
            Form f = FormFactory.Instance.CreateOrActivateForm(formName);
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }
    }
}
