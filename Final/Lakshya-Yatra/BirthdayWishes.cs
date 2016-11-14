using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lakshya_Yatra
{
    public partial class BirthdayWishes : Form
    {
        public BirthdayWishes()
        {
            InitializeComponent();
        }

        private void BirthdayWishes_Load(object sender, EventArgs e)
        {
            InitializeForm();
        }

        private void InitializeForm()
        {
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

            rbMonth.Checked = true;
            dgvBirthdays.AutoGenerateColumns = false;
            dgvBirthdays.DataSource = null;
        }

        private void rbMonth_CheckedChanged(object sender, EventArgs e)
        {
            panelMonth.Visible = rbMonth.Checked;
            panelDate.Visible = !rbMonth.Checked;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DataSet ds = new DataSet();
                BusinessRules objBusinessRules = new BusinessRules();
                if (rbMonth.Checked)
                    ds = objBusinessRules.getBirthDateReport(BirthMonth: Convert.ToInt16(cbMonth.SelectedValue));
                else
                    ds = objBusinessRules.getBirthDateReport(BirthDate: dateTimePicker1.Value.Date);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgvBirthdays.DataSource = ds.Tables[0];                    
                }
                else
                    dgvBirthdays.DataSource = null;
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            InitializeForm();
        }

        private void btnExportToTXT_Click(object sender, EventArgs e)
        {
            ExporttoTXT();
        }

        private void ExporttoTXT()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (dgvBirthdays.DataSource != null)
                {
                    using (DataTable dt = (DataTable)dgvBirthdays.DataSource)
                    {
                        StringBuilder sb = new StringBuilder();

                        var query = from DataRow dr in dt.Rows
                                    where dr["Checked"] != DBNull.Value && Convert.ToBoolean(dr["Checked"]) == true
                                    select dr["Mobile_No"].ToString();

                        sb.AppendLine(string.Join("\r\n", query.ToList<string>()));
                        string result = sb.ToString();

                        try
                        {
                            string fileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + ConfigurationManager.AppSettings["Lakshya_Birthday_MobileNumbers"];
                            if (File.Exists(fileName))
                                File.Delete(fileName);
                            using (FileStream fs = new FileStream(fileName, FileMode.Create,FileAccess.Write))
                            {
                                using(StreamWriter sw = new StreamWriter(fs))
                                {
                                    sw.Write(sb.ToString());
                                    sw.Close();
                                }
                                fs.Close();
                            }
                            MessageBox.Show("Mobile Numbers exported successfully in below file\n" + fileName);
                        }
                        catch (IOException ex)
                        {
                            MessageBox.Show("Error occurred in writing CSV file. Please check if file is open.\nError : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
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
