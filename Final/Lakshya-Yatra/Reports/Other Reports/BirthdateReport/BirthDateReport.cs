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
    public partial class BirthDateReport : Form
    {
        public BirthDateReport()
        {
            InitializeComponent();
        }

        private void BirthDateReport_Load(object sender, EventArgs e)
        {
            InitializeForm();

        }

        private void InitializeForm()
        {
            rbMonth.Checked = true;
            Dictionary<int, string> months = new Dictionary<int, string>(12);
            months.Add(1, "January");
            months.Add(2, "February");
            months.Add(3, "March");
            months.Add(4, "April");
            months.Add(5, "May");
            months.Add(6, "June");
            months.Add(7, "July");
            months.Add(8, "August");
            months.Add(9, "September");
            months.Add(10, "October");
            months.Add(11, "November");
            months.Add(12, "December");

            cbMonth.DataSource = new BindingSource(months, null);
            cbMonth.DisplayMember = "Value";
            cbMonth.ValueMember = "Key";
            cbMonth.SelectedValue = DateTime.Now.Month;

            lblCurrentYear.Text = Convert.ToString(DateTime.Now.Year);

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DataSet ds = new DataSet();
                BusinessRules objBusinessRules = new BusinessRules();
                ReportContainer frmReportContainer = new ReportContainer();
                if (rbMonth.Checked)
                    ds = objBusinessRules.getBirthDateReport(BirthMonth: Convert.ToInt16(cbMonth.SelectedValue), ForReport: true);
                else
                    ds = objBusinessRules.getBirthDateReport(BirthDate: dateTimePicker1.Value.Date, ForReport: true);
                frmReportContainer.ShowReport(ds, @"Reports\Other Reports\BirthdateReport\rptBirthDateReport.rpt", "dtBirthDate");
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

        private void rbMonth_CheckedChanged(object sender, EventArgs e)
        {
            panelMonth.Visible = rbMonth.Checked;
            panelDate.Visible = !rbMonth.Checked;
        }
    }
}
