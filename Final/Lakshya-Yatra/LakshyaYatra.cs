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

        private void ShowNewForm(object sender, EventArgs e)
        {
            registrationToolStripMenuItem1_Click(null, null);
        }
        
        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printPreviewToolStripButton_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "SearchCustomer")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                SearchCustomer frmSearchCustomer = new SearchCustomer();
                frmSearchCustomer.MdiParent = this;
                frmSearchCustomer.WindowState = FormWindowState.Maximized;
                frmSearchCustomer.Show();
            }
        }

        private void busRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Bus Registration")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                BusRegistration frmBusRegistration = new BusRegistration();
                frmBusRegistration.MdiParent = this;
                frmBusRegistration.WindowState = FormWindowState.Maximized;
                frmBusRegistration.Show();
            }
        }

        private void registrationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Registration")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                Registration frmRegistration = new Registration();
                frmRegistration.MdiParent = this;
                frmRegistration.WindowState = FormWindowState.Maximized;
                frmRegistration.Show();
            }
        }

        private void reportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "SearchCustomer")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                SearchCustomer frmSearchCustomer = new SearchCustomer();
                frmSearchCustomer.MdiParent = this;
                frmSearchCustomer.WindowState = FormWindowState.Maximized;
                frmSearchCustomer.Show();
            }
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void deleteAllDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Delete Data")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                DeleteAllDataPwd frmDeleteAllDataPwd = new DeleteAllDataPwd();
                frmDeleteAllDataPwd.MdiParent = this;
                frmDeleteAllDataPwd.WindowState = FormWindowState.Maximized;
                frmDeleteAllDataPwd.Show();
            }
        }

        private void busReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "BusReport")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                BusReport frmBusReport = new BusReport();
                frmBusReport.MdiParent = this;
                frmBusReport.WindowState = FormWindowState.Maximized;
                frmBusReport.Show();
            }
        }

        private void emptySeatsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Empty Seats")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                EmptySeats frmEmptySeats = new EmptySeats();
                frmEmptySeats.MdiParent = this;
                frmEmptySeats.WindowState = FormWindowState.Maximized;
                frmEmptySeats.Show();
            }
        }

        private void dailyCashReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void cashExpenseTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Cash Expenses")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                CashExpenses frmCashExpenses = new CashExpenses();
                frmCashExpenses.MdiParent = this;
                frmCashExpenses.WindowState = FormWindowState.Maximized;
                frmCashExpenses.Show();
            }
        }

        private void dailyCashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Daily Cash Report")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                DailyCashReport frmDailyCashReport = new DailyCashReport();
                frmDailyCashReport.MdiParent = this;
                frmDailyCashReport.WindowState = FormWindowState.Maximized;
                frmDailyCashReport.Show();
            }
        }

        private void yatraDatewiseCashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Report")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                Report frmReport = new Report();
                frmReport.MdiParent = this;
                frmReport.WindowState = FormWindowState.Maximized;
                frmReport.Show();
            }
        }

        private void allYatraDatesAllBusesCashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "All Yatra Dates - All Buses Report")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                AllYatraDatesAllBusesReport frmReport = new AllYatraDatesAllBusesReport();
                frmReport.MdiParent = this;
                frmReport.WindowState = FormWindowState.Maximized;
                frmReport.Show();
            }
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
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "User Maintenance")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                UserMaintenance frmUserMaintenance = new UserMaintenance();
                frmUserMaintenance.MdiParent = this;
                frmUserMaintenance.WindowState = FormWindowState.Maximized;
                frmUserMaintenance.Show();
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Change Password")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                ChangePassword frmChangePassword = new ChangePassword();
                frmChangePassword.MdiParent = this;
                frmChangePassword.WindowState = FormWindowState.Maximized;
                frmChangePassword.Show();
            }
        }

        private void discountReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Change Password")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                DiscountReport frmDiscountReport = new DiscountReport();
                frmDiscountReport.MdiParent = this;
                frmDiscountReport.WindowState = FormWindowState.Maximized;
                frmDiscountReport.Show();
            }
        }

        private void bloodGroupReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Blood Group Report")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                BloodGroupReport frmBloodGroupReport = new BloodGroupReport();
                frmBloodGroupReport.MdiParent = this;
                frmBloodGroupReport.WindowState = FormWindowState.Maximized;
                frmBloodGroupReport.Show();
            }
        }

        private void userwiseCashReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Userwise Cash Report")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                UserwiseCashReport frmUserwiseCashReport = new UserwiseCashReport();
                frmUserwiseCashReport.MdiParent = this;
                frmUserwiseCashReport.WindowState = FormWindowState.Maximized;
                frmUserwiseCashReport.Show();
            }
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
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Userwise Yearly Cash Report")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                UserwiseYearlyCashReport frmUserwiseYearlyCashReport = new UserwiseYearlyCashReport();
                frmUserwiseYearlyCashReport.MdiParent = this;
                frmUserwiseYearlyCashReport.WindowState = FormWindowState.Maximized;
                frmUserwiseYearlyCashReport.Show();
            }
        }

        private void expenseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Expense Report")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                ExpenseReport frmExpenseReport = new ExpenseReport();
                frmExpenseReport.MdiParent = this;
                frmExpenseReport.WindowState = FormWindowState.Maximized;
                frmExpenseReport.Show();
            }
        }

        private void birthDateReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Birth Date Report")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                BirthDateReport frmBirthDateReport = new BirthDateReport();
                frmBirthDateReport.MdiParent = this;
                frmBirthDateReport.WindowState = FormWindowState.Maximized;
                frmBirthDateReport.Show();
            }
        }

        private void birthdayWishesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Birthday Wishes")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                BirthdayWishes frmBirthdayWishes = new BirthdayWishes();
                frmBirthdayWishes.MdiParent = this;
                frmBirthdayWishes.WindowState = FormWindowState.Maximized;
                frmBirthdayWishes.Show();
            }
        }

        private void customSMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Custom SMS")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                CustomSMS frmCustomSMS = new CustomSMS();
                frmCustomSMS.MdiParent = this;
                frmCustomSMS.WindowState = FormWindowState.Maximized;
                frmCustomSMS.Show();
            }
        }

        private void toolStripMultipleRegistrationsMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Multiple Registration")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                Multiple_Registration frmMultiple_Registration = new Multiple_Registration();
                frmMultiple_Registration.MdiParent = this;
                frmMultiple_Registration.WindowState = FormWindowState.Maximized;
                frmMultiple_Registration.Show();
            }
        }

        private void userwiseTicketReportMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Userwise Ticket Report")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                UserwiseTicketReport frmUserwiseTicketReport = new UserwiseTicketReport();
                frmUserwiseTicketReport.MdiParent = this;
                frmUserwiseTicketReport.WindowState = FormWindowState.Maximized;
                frmUserwiseTicketReport.Show();
            }
        }

        private void electionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Election Report")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                ElectionReport frmElectionReport = new ElectionReport();
                frmElectionReport.MdiParent = this;
                frmElectionReport.WindowState = FormWindowState.Maximized;
                frmElectionReport.Show();
            }
        }

        private void multipleRegistrationToolStripButton_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Multiple Registration")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                Multiple_Registration frmMultiple_Registration = new Multiple_Registration();
                frmMultiple_Registration.MdiParent = this;
                frmMultiple_Registration.WindowState = FormWindowState.Maximized;
                frmMultiple_Registration.Show();
            }
        }

        private void customerManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Customer Maintenance")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                CustomerMaintenance frmCustomerMaintenance = new CustomerMaintenance();
                frmCustomerMaintenance.MdiParent = this;
                frmCustomerMaintenance.WindowState = FormWindowState.Maximized;
                frmCustomerMaintenance.Show();
            }
        }
    }
}
