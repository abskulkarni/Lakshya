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
    public partial class BloodGroupReport : Form
    {
        public BloodGroupReport()
        {
            InitializeComponent();
        }

        private void BloodGroup_Load(object sender, EventArgs e)
        {
            InitializeForm();
        }
        private void InitializeForm()
        {
            cbBloodGroup.SelectedIndex = 0;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DataSet ds = new DataSet();
                BusinessRules objBusinessRules = new BusinessRules();
                ReportContainer frmReportContainer = new ReportContainer();
                ds = objBusinessRules.getBloodGroupReport(cbBloodGroup.SelectedItem.ToString());
                frmReportContainer.ShowReport(ds, @"Reports\Other Reports\Bloodgroup\rptBloodGroupReport.rpt", "dtBloodGroup");
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
