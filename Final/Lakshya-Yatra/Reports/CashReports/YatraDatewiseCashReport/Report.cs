using System;
using System.Data;
using System.Windows.Forms;

namespace Lakshya_Yatra
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private bool Authenticate()
        {
            if ( cbBus.SelectedIndex == -1)
            {
                MessageBox.Show("Please enter all fields!");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Authenticate())
            {
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            try
            {
                DataSet ds = new DataSet();
                BusinessRules objBusinessRules = new BusinessRules();
                ReportContainer frmReportContainer = new ReportContainer();
                if (tabControl1.SelectedTab == tabControl1.TabPages[0])
                {
                    DateTime strYatraDate = dtpNavratriDate.Value.Date;
                    string BusNo = cbBus.Items[cbBus.SelectedIndex].ToString();
                    ds = objBusinessRules.getCashReport(strYatraDate, BusNo);
                    frmReportContainer.ShowMultipleReports(ds, @"Reports\CashReports\YatraDatewiseCashReport\rptYatraDatewiseCashReport.rpt");
                    frmReportContainer.Show();
                }
                else
                {
                    DateTime fromDate, toDate;
                    if (rbThisYear.Checked)
                    {
                        fromDate = new DateTime(DateTime.Now.Year, 1, 1);
                        toDate = new DateTime(DateTime.Now.Year, 12, 31);
                        ds = objBusinessRules.getCashReport(fromDate, toDate);
                    }
                    else if (rbLastYear.Checked)
                    {
                        fromDate = new DateTime(DateTime.Now.Year - 1, 1, 1);
                        toDate = new DateTime(DateTime.Now.Year - 1, 12, 31);
                        ds = objBusinessRules.getCashReport(fromDate, toDate);
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
                        ds = objBusinessRules.getCashReport(fromDate, toDate);
                    }

                    frmReportContainer.ShowMultipleReports(ds, @"Reports\CashReports\YatraDatewiseCashReport\rptYatraDatewiseCashReport.rpt");
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

        private void dtpNavratriDate_ValueChanged(object sender, EventArgs e)
        {
            BusinessRules objBusinessRules = new BusinessRules();
            DataSet ds = objBusinessRules.getBusByYatraDate(dtpNavratriDate.Value.Date);

            cbBus.Items.Clear();

            if (ds.Tables[0] != null)
            {
                cbBus.Items.Add("All");
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    cbBus.Items.Add(row["Bus_Name"]);
                }
                if (cbBus.Items.Count > 0) cbBus.SelectedIndex = 0;
            }
        }

        private void Report_Load(object sender, EventArgs e)
        {
            dtpNavratriDate_ValueChanged(null, null);
            InitializeForm();
            //this.reportViewer1.RefreshReport();
        }

        private void InitializeForm()
        {
            tabControl1.SelectTab(1);
            rbThisYear.Checked = true;

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
