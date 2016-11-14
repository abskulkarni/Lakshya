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
    public partial class CustomSMS : Form
    {
        public CustomSMS()
        {
            InitializeComponent();
        }

        private void CustomSMS_Load(object sender, EventArgs e)
        {
            InitializeForm();
        }

        private void InitializeForm()
        {
            cbYear.Items.Clear();
            for (int year = DateTime.Now.Year; year >= DateTime.Now.Year-4; year--)
            {
                cbYear.Items.Add(year);
            }
            cbYear.SelectedIndex = 0;

            rbDate.Checked = true;
            rbMobileNumber.Checked = true;
            txtMessage.Text = string.Empty;
            dgvMobileNumbers.DataSource = null;
        }

        private void rbYear_CheckedChanged(object sender, EventArgs e)
        {
            panelYear.Visible = rbYear.Checked;
            panelDate.Visible = !rbYear.Checked;

            dgvMobileNumbers.DataSource = null;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DataSet ds = new DataSet();
                BusinessRules objBusinessRules = new BusinessRules();

                string mobileOrAlternate = rbMobileNumber.Checked ? "Mobile" : "Alternate";

                if (rbYear.Checked)
                    ds = objBusinessRules.getMobileNumbers(YatraYear: Convert.ToInt16(cbYear.SelectedItem), MobileOrAlternate: mobileOrAlternate);
                else
                    ds = objBusinessRules.getMobileNumbers(YatraDate: dateTimePicker1.Value.Date, MobileOrAlternate: mobileOrAlternate);

                dgvMobileNumbers.DataSource = ds.Tables[0].Rows.Count > 0 ? ds.Tables[0] : null;
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
                if (dgvMobileNumbers.DataSource != null)
                {
                    using (DataTable dt = (DataTable)dgvMobileNumbers.DataSource)
                    {
                        StringBuilder sb = new StringBuilder();

                        var query =
                                    from DataRow dr in dt.Rows
                                    select rbMobileNumber.Checked ? dr["Mobile_No"].ToString() : dr["Alternate_Mobile"].ToString();

                        sb.AppendLine(string.Join("\r\n", query.ToList<string>()));
                        string result = sb.ToString();

                        try
                        {
                            string fileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" +
                                (rbMobileNumber.Checked ? ConfigurationManager.AppSettings["Lakshya_CustomSMS_MobileNumbers"] :
                                                        ConfigurationManager.AppSettings["Lakshya_CustomSMS_Alternate_MobileNumbers"]);
                            if (File.Exists(fileName))
                                File.Delete(fileName);
                            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                            {
                                using (StreamWriter sw = new StreamWriter(fs))
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

        private void btnSendSMS_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMessage.Text.Trim()))
                {
                    MessageBox.Show("Please enter message");
                    return;
                }

                if (dgvMobileNumbers.DataSource == null)
                {
                    MessageBox.Show("No mobile numbers available.");
                    return;
                }

                var query = from DataRow dr in ((DataTable)dgvMobileNumbers.DataSource).Rows
                            select rbMobileNumber.Checked ? dr["Mobile_No"].ToString() : dr["Alternate_Mobile"].ToString();

                List<string> mobileNumbers = query.ToList<string>();

                bool flg = true;
                panelSMS.Visible = true;
                progressBar1.Minimum = progressBar1.Value = 0;
                
                progressBar1.Maximum = mobileNumbers.Count;
                Application.DoEvents();
                foreach (string mobile in mobileNumbers)
                {
                    string smsResult = Utilities.Instance.SendCustomSMS(txtMessage.Text.Trim(), mobile.Trim());
                    
                    if (smsResult.StartsWith("ES1009"))
                    {
                        flg = false;
                        MessageBox.Show("SMS could not be sent. Invalid Mobile Number : " + mobile, "SMS Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (smsResult.StartsWith("Unable to connect to the remote server"))
                    {
                        flg = false;
                        MessageBox.Show("SMS could not be sent. Please check internet connection", "SMS Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        progressBar1.Value += 1;
                        Application.DoEvents();
                    }
                }
                if (flg)
                {
                    panelSMS.Visible = false;
                    progressBar1.Minimum = progressBar1.Value = 0;
                    Application.DoEvents();
                    MessageBox.Show("Message successfully sent to all customers.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in sending SMS\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void rbMobileNumber_CheckedChanged(object sender, EventArgs e)
        {
            dgvMobileNumbers.DataSource = null;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dgvMobileNumbers.DataSource = null;
        }
    }
}
