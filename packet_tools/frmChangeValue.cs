using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace packet_tools {
    public partial class frmChangeValue : Form {
        public frmChangeValue() {
            InitializeComponent();
            this.DialogResult = DialogResult.No;
        }
        private string _productSN = "";
        private string _boxSN = "";
        public string ProductSN{
            get { return _productSN; }
            set { _productSN = value; tbProduct.Text = value; }
        }
        public string BoxSN {
            get { return _boxSN; }
            set { _boxSN = value; tbBox.Text = value; }
        }
        private delegate void changeTxt(string txt);

        public void changeBoxSN(string txt) {
            if (tbBox.InvokeRequired) {
                tbBox.Invoke(new changeTxt(changeBoxSN), new object[] { txt });
            } else {
                tbBox.Text = txt;
            }
        }
        public void changeProductSN(string txt) {
            if (tbProduct.InvokeRequired) {
                tbProduct.Invoke(new changeTxt(changeProductSN), new object[] { txt });
            } else {
                tbProduct.Text = txt;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.No;
            if (tbProduct.Text.Trim() != ProductSN || tbBox.Text.Trim()!= BoxSN) {
                ProductSN  = tbProduct.Text.Trim();
                BoxSN = tbBox.Text.Trim();
                this.DialogResult = DialogResult.Yes;
            }
            mainForm.getMainForm()._changeValue = false;
            this.Close();
        }
    }
}