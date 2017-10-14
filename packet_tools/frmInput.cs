using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace packet_tools
{
    public partial class frmInput : Form
    {
        private string _product_type = "";
        public string ProductType
        {
            get 
            { 
                return _product_type; 
            }
        }
        private int _product_num = 0;
        public int Product_Num
        {
            get
            {
                return _product_num;
            }
        }
        public frmInput()
        {
            InitializeComponent();
            this.DialogResult = System.Windows.Forms.DialogResult.No;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (textBoxproduct_Type.Text == "" || ! int.TryParse( txbNum.Text, out _product_num))
            {
                MessageBox.Show("请正确输入产品型号名称和产品数据!");
                return;
            }
            else
            {
                _product_type = textBoxproduct_Type.Text.Trim();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
    }
}
