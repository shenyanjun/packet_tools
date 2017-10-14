using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace packet_tools
{
    public partial class frmAddWorker : Form
    {
        public frmAddWorker()
        {
            InitializeComponent();
            this.DialogResult = System.Windows.Forms.DialogResult.None;
        }
        private string _addedWorker = "";
        public string AddedWorker
        {
            get { return _addedWorker; }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _addedWorker = textBox1.Text.Trim();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
