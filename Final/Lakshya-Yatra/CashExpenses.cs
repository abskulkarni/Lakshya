using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Lakshya_Yatra
{
    public partial class CashExpenses : Form
    {
        int Auto_ID;
        DataSet ds;
        public CashExpenses()
        {
            InitializeComponent();
        }

        private bool ValidateInputs()
        {
            bool result = true;

            if (Convert.ToInt16(cbExpenseType.SelectedValue) == 0)
            {
                result = false;
                MessageBox.Show("Please enter Expense Type", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (result)
            {
                if (string.IsNullOrEmpty(txtAmount.Text.Trim()))
                {
                    result = false;
                    MessageBox.Show("Please enter Amount", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            return result;
        }

        private void InitializeForm(bool withDataRefresh = false)
        {
            BusinessRules objDatabase = new BusinessRules();
            Auto_ID = 0;
            txtAmount.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            dtpExpenseDate.Enabled = cbExpenseType.Enabled = true;

            if (withDataRefresh)
            {
                ds = objDatabase.getAllExpenseTypeTransactions(dtpExpenseDate.Value.Date);

                DataRow dr = ds.Tables[0].NewRow();
                dr["Expense_ID"] = 0;
                dr["Expense_Type"] = "";
                ds.Tables[0].Rows.InsertAt(dr, 0);

                cbExpenseType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbExpenseType.AutoCompleteSource = AutoCompleteSource.ListItems;
                cbExpenseType.DisplayMember = "Expense_Type";
                cbExpenseType.ValueMember = "Expense_ID";
                cbExpenseType.DataSource = ds.Tables[0].DefaultView;

                if (ds.Tables[1].Rows.Count > 0)
                {
                    dgvExpense.DataSource = ds.Tables[1].DefaultView;
                    dgvExpense.Columns["Auto_ID"].Visible = dgvExpense.Columns["Expense_ID"].Visible =
                        dgvExpense.Columns["Expense_Date"].Visible = false;
                }
                else
                {
                    dgvExpense.DataSource = null;
                }

                lblTotalExpensesValue.Text = ds.Tables[1].Rows.Count > 0 ? ds.Tables[2].Rows[0]["Total_Expense"].ToString() : "0";
                if (!string.IsNullOrEmpty(lblTotalExpensesValue.Text.Trim()))
                {
                    lblTotalExpensesValue.Text = lblTotalExpensesValue.Text.SetFormattedInteger();
                }
            }
            cbExpenseType.SelectedIndex = 0;
            dtpExpenseDate.MaxDate = DateTime.Now.Date;
            dtpExpenseDate.Focus();
        }

        private void CashExpenses_Load(object sender, EventArgs e)
        {
            InitializeForm(true);
            label1.BackColor = label2.BackColor = label4.BackColor = label8.BackColor = lblTotalExpenses.BackColor = lblTotalExpensesValue.BackColor = Color.Transparent;
            dtpExpenseDate.MaxDate = DateTime.Now.Date;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateInputs() == false) return;

            BusinessRules objDatabase = new BusinessRules();
            int Expense_ID = Convert.ToInt32(cbExpenseType.SelectedValue);
            DateTime Expense_Date = dtpExpenseDate.Value.Date;
            int Amount = txtAmount.Text.Trim().GetInteger();
            string Remarks = txtRemarks.Text.Trim();
            try
            {
                DataSet ds = objDatabase.InsertUpdateCashExpenseTransaction(Auto_ID, Expense_Date, Expense_ID, Amount, Remarks, User.Instance.User_Name);
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    MessageBox.Show("Record updated successfully!");
                    InitializeForm(true);

                }
                else
                {
                    MessageBox.Show("Error in updating Record, please contact System Administrator!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in updating Record, please contact System Administrator!\n" + ex.Message.ToString());
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            InitializeForm();
        }

        private void dtpExpenseDate_ValueChanged(object sender, EventArgs e)
        {
            InitializeForm(true);
        }

        private void deleteTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BusinessRules objDatabase = new BusinessRules();
            try
            {
                DataSet ds = objDatabase.DeleteCashExpenseTransaction(Auto_ID);
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    MessageBox.Show("Record deleted successfully!");
                    InitializeForm(true);
                }
                else
                {
                    MessageBox.Show("Error in deleting Record, please contact System Administrator!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in deleting Record, please contact System Administrator!\n" + ex.Message.ToString());
            }
        }

        private void dgvExpense_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.dgvExpense.Rows[e.RowIndex].Selected = true;

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Auto_ID = int.Parse(dgvExpense.Rows[e.RowIndex].Cells["Auto_ID"].Value.ToString().Trim());
                cbExpenseType.SelectedValue = int.Parse(dgvExpense.Rows[e.RowIndex].Cells["Expense_ID"].Value.ToString().Trim());
                txtAmount.Text = dgvExpense.Rows[e.RowIndex].Cells["Amount"].Value.ToString().SetFormattedInteger();
                txtRemarks.Text = dgvExpense.Rows[e.RowIndex].Cells["Remarks"].Value.ToString();

                dtpExpenseDate.Enabled = cbExpenseType.Enabled = false;
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                Auto_ID = int.Parse(dgvExpense.Rows[e.RowIndex].Cells["Auto_ID"].Value.ToString().Trim());
                contextMenuStrip1.Show(Cursor.Position);
            }
        }
    }
}
