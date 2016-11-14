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
    public partial class UserwiseCashReport : Form
    {
        public UserwiseCashReport()
        {
            InitializeComponent();
        }

        private void UserwiseCashReport_Load(object sender, EventArgs e)
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
            for (int year=2016; year<=DateTime.Now.Year; year++)
            {
                cbYear.Items.Add(year);
            }
            cbYear.SelectedIndex = cbYear.Items.Count - 1;

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DataSet ds = new DataSet();
                BusinessRules objBusinessRules = new BusinessRules();
                ReportContainer frmReportContainer = new ReportContainer();
                ds = objBusinessRules.getCashReport_Userwise(Convert.ToString(cbUserNames.SelectedValue), Convert.ToInt16(cbYear.SelectedItem));
                frmReportContainer.ShowReport(ds, @"Reports\CashReports\UserwiseCashReport\rptUserwiseCashReport.rpt", "dtCashReport");
                frmReportContainer.Show();

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
    }
}
