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
    public partial class UserwiseTicketReport : Form
    {
        public UserwiseTicketReport()
        {
            InitializeComponent();
        }

        private void UserwiseTicketReport_Load(object sender, EventArgs e)
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
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DataSet ds = new DataSet();
                BusinessRules objBusinessRules = new BusinessRules();
                ReportContainer frmReportContainer = new ReportContainer();
                ds = objBusinessRules.getUserwiseTickets(Convert.ToString(cbUserNames.SelectedValue));
                frmReportContainer.ShowReport(ds, @"Reports\TicketReports\UserwiseTicketReport\rptUserwiseTicketReport.rpt", "dtUserwiseTicketReport");
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
