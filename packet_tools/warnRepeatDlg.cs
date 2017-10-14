using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
namespace packet_tools
{
    public partial class warnRepeatDlg : Form
    {
        private bool isAdmin = false;
        public warnRepeatDlg()
        {
            InitializeComponent();
        }

        private string getMd5(string info) {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string md5_bytes = BitConverter.ToString(md5.ComputeHash(Encoding.ASCII.GetBytes(info))).Replace("-", "");
            return md5_bytes;
        }

        private void warnDlg_Load(object sender, EventArgs e)
        {
            isAdmin = false;
        }

        private void warnRepeatDlg_FormClosing(object sender, FormClosingEventArgs e) {
            if (!isAdmin)
                e.Cancel = true;
            else
                e.Cancel = false;
        }

        private void warnRepeatDlg_KeyDown(object sender, KeyEventArgs e) {
            if ((e.KeyCode == Keys.F4) && (e.Alt == true)) {
                e.Handled = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e) {
            string pass = txbPassword.Text.Trim();
            string pass2 = txbRootPass.Text.Trim();
            if (pass != "" && pass2 != "") {
                if (pass == "112131" && pass2 == "111888") {
                    isAdmin = true;
                    FileStream status = new FileStream(System.Environment.CurrentDirectory + "\\status", FileMode.Truncate, FileAccess.ReadWrite);
                    StreamWriter status_writer = new StreamWriter(status);
                    status_writer.WriteLine("-1");
                    status_writer.Flush();
                    status.Close();
                    this.Close();
                }
            }
        }
    }
}