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
        BusinessRules objBusinessRules = new BusinessRules();
        public ElectionReport()
        {
            InitializeComponent();
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                
                using (DataSet ds = objBusinessRules.GetElectionReport(Convert.ToInt16(cbArea.SelectedValue)))
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

        private void ElectionReport_Load(object sender, EventArgs e)
        {
            InitializaForm();
        }

        private void InitializaForm()
        {
            GetAreas();
            
        }

        private void GetAreas()
        {
            cbArea.DataSource = objBusinessRules.GetAreas(true);
            cbArea.DisplayMember = "Area";
            cbArea.ValueMember = "Area_ID";
            if (cbArea.DataSource != null)
                cbArea.SelectedIndex = 0;
        }
    }
}
