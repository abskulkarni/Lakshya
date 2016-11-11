using System;
using System.Data;
using System.Windows.Forms;

namespace Lakshya_Yatra
{
    public partial class DailyCashReport : Form
    {
        public DailyCashReport()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DataSet ds = new DataSet();
                BusinessRules objBusinessRules = new BusinessRules();
                ReportContainer frmReportContainer = new ReportContainer();
                if (tabControl1.SelectedTab == tabControl1.TabPages[0])
                {
                    DateTime Registration_Date = dtpRegistrationDate.Value.Date;
                    ds = objBusinessRules.getDailyCashReport(Registration_Date);
                    frmReportContainer.ShowReport(ds, @"Reports\CashReports\DailyCashReport\rptDailyCashReport.rpt", "dtDailyCashReport");
                    frmReportContainer.Show();
                }
                else
                {
                    DateTime fromDate, toDate;
                    if (rbThisYear.Checked)
                    {
                        fromDate = new DateTime(DateTime.Now.Year, 1, 1);
                        toDate = new DateTime(DateTime.Now.Year, 12, 31);
                        ds = objBusinessRules.getDailyCashReport(fromDate, toDate);
                    }
                    else if (rbLastYear.Checked)
                    {
                        fromDate = new DateTime(DateTime.Now.Year - 1, 1, 1);
                        toDate = new DateTime(DateTime.Now.Year - 1, 12, 31);
                        ds = objBusinessRules.getDailyCashReport(fromDate, toDate);
                    }
                    else
                    {
                        if (Convert.ToInt16(cbFromYear.SelectedItem) > Convert.ToInt16(cbToYear.SelectedItem))
                        {
                            MessageBox.Show("From Year cannot be greater than To Year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        fromDate = new DateTime(Convert.ToInt16(cbFromYear.SelectedItem), 1, 1);
                        toDate = new DateTime(Convert.ToInt16(cbToYear.SelectedItem), 12, 31);
                        ds = objBusinessRules.getDailyCashReport(fromDate, toDate);
                    }

                    frmReportContainer.ShowReport(ds, @"Reports\CashReports\DailyCashReport\rptDailyCashReport.rpt", "dtDailyCashReport");
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

        private void DailyCashReport_Load(object sender, EventArgs e)
        {
            InitializeForm();
        }

        private void InitializeForm()
        {
            tabControl1.SelectTab(1);
            rbThisYear.Checked = true;

            for (int year = DateTime.Now.Year - 4;year<=DateTime.Now.Year-1;year++)
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
