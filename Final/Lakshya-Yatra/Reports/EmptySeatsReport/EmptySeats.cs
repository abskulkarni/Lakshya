using System;
using System.Data;
using System.Windows.Forms;

namespace Lakshya_Yatra
{
    public partial class EmptySeats : Form
    {
        public EmptySeats()
        {
            InitializeComponent();
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

        private void EmptySeats_Load(object sender, EventArgs e)
        {
            dtpNavratriDate_ValueChanged(null, null);
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
                DateTime strYatraDate = dtpNavratriDate.Value.Date;
                string BusNo = cbBus.Items[cbBus.SelectedIndex].ToString();

                DataSet ds = new DataSet();
                BusinessRules objBusinessRules = new BusinessRules();
                ds = objBusinessRules.getEmptySeats(strYatraDate, BusNo);

                ReportContainer frmReportContainer = new ReportContainer();
                frmReportContainer.ShowReport(ds, @"Reports\EmptySeatsReport\rptEmptySeats.rpt", "dtEmptySeats");
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

        private bool Authenticate()
        {
            if (cbBus.SelectedIndex == -1)
            {
                MessageBox.Show("Please enter all fields!");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
