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
    public partial class ExpenseReport : Form
    {
        public ExpenseReport()
        {
            InitializeComponent();
        }

        private void ExpenseReport_Load(object sender, EventArgs e)
        {
            InitializeForm();
        }

        private void InitializeForm()
        {
            BusinessRules objBusinessRules = new BusinessRules();
            cbUserNames.DataSource = null;
            cbUserNames.ValueMember = "User_Name";
            cbUserNames.DisplayMember = "Full_Name";
            cbUserNames.DataSource = objBusinessRules.GetUserNames();

            cbYear.Items.Clear();
            for (int year = 2016; year <= DateTime.Now.Year; year++)
            {
                cbYear.Items.Add(year);
            }
            cbYear.SelectedIndex = cbYear.Items.Count - 1;

            rbThisYear.Checked = true;

            tabControl1.SelectTab(0);
            for (int year = DateTime.Now.Year - 4; year <= DateTime.Now.Year - 1; year++)
            {
                cbFromYear.Items.Add(year);
            }
            for (int year = DateTime.Now.Year - 4; year <= DateTime.Now.Year; year++)
            {
                cbToYear.Items.Add(year);
            }
            cbFromYear.SelectedIndex = 0;
            cbToYear.SelectedIndex = cbToYear.Items.Count - 1;
            panelYearRange.Enabled = false;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DataSet ds = new DataSet();
                BusinessRules objBusinessRules = new BusinessRules();
                ReportContainer frmReportContainer = new ReportContainer();
                if (tabControl1.SelectedTab == tabControl1.TabPages[0])
                {
                    if (Convert.ToString(cbUserNames.SelectedValue) == "All")
                        ds = objBusinessRules.getExpenseReport(Convert.ToInt16(cbYear.SelectedItem), Convert.ToInt16(cbYear.SelectedItem));
                    else
                        ds = objBusinessRules.getExpenseReport(User.Instance.User_Name, Convert.ToInt16(cbYear.SelectedItem), Convert.ToInt16(cbYear.SelectedItem));
                    frmReportContainer.ShowReport(ds, @"Reports\ExpenseReport\rptExpenseReport_Userwise.rpt", "dtExpenseReport");
                    frmReportContainer.Show();
                }
                else
                {
                    if (rbThisYear.Checked)
                    {
                        ds = objBusinessRules.getExpenseReport(DateTime.Now.Year, DateTime.Now.Year);
                    }
                    else if (rbLastYear.Checked)
                    {
                        ds = objBusinessRules.getExpenseReport(DateTime.Now.Year - 1, DateTime.Now.Year - 1);
                    }
                    else
                    {
                        if (Convert.ToInt16(cbFromYear.SelectedItem) > Convert.ToInt16(cbToYear.SelectedItem))
                        {
                            MessageBox.Show("From Year cannot be greater than To Year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        ds = objBusinessRules.getExpenseReport(Convert.ToInt16(cbFromYear.SelectedItem), Convert.ToInt16(cbToYear.SelectedItem));
                    }

                    frmReportContainer.ShowReport(ds, @"Reports\ExpenseReport\rptExpenseReport_Datewise.rpt", "dtExpenseReport");
                    frmReportContainer.Show();
                }

                frmReportContainer = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occurred : \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void rbRange_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRange.Checked)
            {
                panelYearRange.Enabled = true;
                cbFromYear.Focus();
            }
            else
            {
                panelYearRange.Enabled = false;
            }
        }
    }
}
