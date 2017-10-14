using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace packet_tools
{
    public partial class frmLogin : Form
    {
        private string _user = "";
        private string _password = "";
        private bool isAdmin = false;
        public bool IsAdmin {
            get { return isAdmin; }
        }
        public string User
        {
            get { return _user; }
        }
        public string Password
        {
            get { return _password; }
        }
        public frmLogin()
        {
            InitializeComponent();
            this.DialogResult = System.Windows.Forms.DialogResult.None;
        }
        private void chbAdmin_CheckedChanged(object sender, EventArgs e)
        {
            txbPassword.Text = "";
            txbUser.Text = "";
            txbUser.Focus();
            if (chbAdmin.Checked == true)
            {
                txbPassword.Enabled = true;
                isAdmin = true;
            }
            else
            {
                txbPassword.Enabled = false;
                isAdmin = false;
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            _user = txbUser.Text.Trim();
            _password = txbPassword.Text.Trim();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnOK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK_Click(null, null);
            }
        }
    }
}
