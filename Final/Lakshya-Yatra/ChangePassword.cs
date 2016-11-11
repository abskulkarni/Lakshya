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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                BusinessRules objBusinessRules = new BusinessRules();
                
                using (DataTable dt = objBusinessRules.ChangePassword(User.Instance.User_Name, txtNewPassword.Text))
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["User_Name"].ToString()))
                    {
                        User.Instance.User_Name = Convert.ToString(dt.Rows[0]["User_Name"]);
                        User.Instance.First_Name = Convert.ToString(dt.Rows[0]["First_Name"]);
                        User.Instance.Last_Name = Convert.ToString(dt.Rows[0]["Last_Name"]);
                        User.Instance.Password = Convert.ToString(dt.Rows[0]["Password"]);
                        User.Instance.IsAdmin = Convert.ToBoolean(dt.Rows[0]["IsAdmin"]);

                        MessageBox.Show("Password changed successfully.\n\nYou need to close and re-open the application.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private bool ValidateInputs()
        {
            bool res = true;
            if (string.IsNullOrEmpty(txtOldPassword.Text) ||
                string.IsNullOrEmpty(txtNewPassword.Text) ||
                string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                MessageBox.Show("Please enter all fields", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                res = false;
            }

            if (res)
            {
                if (txtOldPassword.Text.CompareTo(User.Instance.Password) != 0)
                {
                    MessageBox.Show("Old password is not correct", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    res = false;
                }
            }

            if (res)
            {
                if (txtNewPassword.Text.CompareTo(txtConfirmPassword.Text) != 0)
                {
                    MessageBox.Show("New Password and Confirm Password fields don't match", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    res = false;
                }
            }

            return res;
        }
    }
}
