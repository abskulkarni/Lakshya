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

    public partial class AreaMaintenance : Form
    {
        int Area_ID;
        BusinessRules objDatabase = new BusinessRules();
        public AreaMaintenance()
        {
            InitializeComponent();
        }

        private void AreaMaintenance_Load(object sender, EventArgs e)
        {
            InitializeForm(true);
        }

        private void InitializeForm(bool withDataRefresh = false)
        {
            txtArea.Text = string.Empty;
            chkIsVisible.Checked = true;
            Area_ID = 0;
            if (withDataRefresh)
            {
                dgvArea.DataSource = objDatabase.GetAreas(false);
                dgvArea.Columns["Area_ID"].Visible = false;
                dgvArea.Columns["Area_ID"].ReadOnly = true;
                dgvArea.Columns["Is_Visible"].HeaderText = "Is Visible";
                dgvArea.Columns["Is_Visible"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            txtArea.Focus();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtArea.Text.Trim()))
            {
                MessageBox.Show("Please enter Area");
                return;
            }

            try
            {
                using (DataTable dt = objDatabase.InsertUpdateArea(Area_ID, txtArea.Text.Trim(), chkIsVisible.Checked, User.Instance.User_Name))
                {
                    if (dt.Rows[0][0].ToString() != "")
                    {
                        MessageBox.Show("Record updated successfully!");
                        InitializeForm(true);
                    }
                    else
                    {
                        MessageBox.Show("Error in updating Record, please contact System Administrator!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in updating Record, please contact System Administrator!\n" + ex.Message.ToString());
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            InitializeForm(false);
        }

        private void deleteTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult f = MessageBox.Show("Are you sure to continue?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (f == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            f = MessageBox.Show("Are you sure to continue?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (f == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            f = MessageBox.Show("Are you sure to continue?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (f == System.Windows.Forms.DialogResult.No)
            {
                return;
            }


            try
            {
                using (DataTable dt = objDatabase.DeleteArea(Area_ID))
                {
                    if (dt.Rows[0][0].ToString() == "-1")
                    {
                        MessageBox.Show("Area is being used Customer Information. Cannot be deleted.", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (dt.Rows[0][0].ToString() != "")
                    {
                        MessageBox.Show("Record updated successfully!");
                        InitializeForm(true);
                    }
                    else
                    {
                        MessageBox.Show("Error in updating Record, please contact System Administrator!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in updating Record, please contact System Administrator!\n" + ex.Message.ToString());
            }
        }

        private void dgvArea_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.dgvArea.Rows[e.RowIndex].Selected = true;

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Area_ID = int.Parse(dgvArea.Rows[e.RowIndex].Cells["Area_ID"].Value.ToString().Trim());
                txtArea.Text = Convert.ToString(dgvArea.Rows[e.RowIndex].Cells["Area"].Value.ToString().Trim());
                chkIsVisible.Checked = bool.Parse(dgvArea.Rows[e.RowIndex].Cells["Is_Visible"].Value.ToString().Trim());
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                Area_ID = int.Parse(dgvArea.Rows[e.RowIndex].Cells["Area_ID"].Value.ToString().Trim());
                contextMenuStrip1.Show(Cursor.Position);
            }
        }
    }
}
