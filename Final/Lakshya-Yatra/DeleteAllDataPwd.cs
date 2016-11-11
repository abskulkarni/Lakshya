using System;
using System.Data;
using System.Windows.Forms;

namespace Lakshya_Yatra
{
    public partial class DeleteAllDataPwd : Form
    {
        public DeleteAllDataPwd()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!txtPassword.Text.Equals("rameshpunde"))
            {
                MessageBox.Show("Invalid Password. Please try again.", "Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult f = MessageBox.Show("This will erase all data including Bus data. Are you sure to continue?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (f == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            f = MessageBox.Show("This will erase all data including Bus data. Are you sure to continue?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (f == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            f = MessageBox.Show("This will erase all data including Bus data. Are you sure to continue?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (f == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            try
            {
                BusinessRules obj = new BusinessRules();
                DataSet ds = obj.DeleteData(dtpCreatedFrom.Value, dtpCreatedTo.Value,chkBusRoutes.Checked, chkBuses.Checked,chkCustomers.Checked);
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    MessageBox.Show("Data erased successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in deleting data \n " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteAllDataPwd_Load(object sender, EventArgs e)
        {
            InitializeForm();
        }
        private void InitializeForm()
        {
            dtpCreatedFrom.Value = dtpCreatedTo.Value = DateTime.Now.Date;
            chkBuses.Checked = chkBusRoutes.Checked = chkCustomers.Checked = false;
            txtPassword.Text = string.Empty;
        }
    }
}
