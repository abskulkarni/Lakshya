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
    public partial class ElectionReport : Form
    {
        public ElectionReport()
        {
            InitializeComponent();
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                BusinessRules objBusinessRules = new BusinessRules();
                using (DataSet ds = objBusinessRules.GetElectionReport())
                {
                    ReportContainer frmReportContainer = new ReportContainer();

                    frmReportContainer.ShowReport(ds, @"Reports\ElectionReport\rptElectionReport.rpt", "dtElectionReport");
                    frmReportContainer.Show();


                    frmReportContainer = null;
                }
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
