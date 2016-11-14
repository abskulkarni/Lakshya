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
    public partial class AllYatraDatesAllBusesReport : Form
    {
        public AllYatraDatesAllBusesReport()
        {
            InitializeComponent();
        }

        private void AllYatraDatesAllBusesReport_Load(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DateTime YatraDateFrom = dtpNavratriDateFrom.Value.Date;
                DateTime YatraDateTo = dtpNavratriDateTo.Value.Date;

                DataSet ds = new DataSet();
                BusinessRules objBusinessRules = new BusinessRules();
                ds = objBusinessRules.getAllYatraDatesAllBusesCashReport(YatraDateFrom, YatraDateTo);

                ReportContainer frmReportContainer = new ReportContainer();
                frmReportContainer.ShowReport(ds, @"Reports\CashReports\AllYatraAllYatraDatesReport\rptAllYatraDatesAllBuses.rpt", "dtAllYatraDatesAllBusesCashReport");
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
