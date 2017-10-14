using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace packet_tools {
    public partial class frmFormula : Form {
        private DataTable _snbox_set_table;
        private MySqlDataAdapter _sql_adp;
        private MySqlConnection _sql_conn;
        /// <summary>
        /// 返回所有型号的数据
        /// </summary>
        private void connectdb_and_init() {
            string sql = "select * from box_set order by snbox_serialnum";
            _snbox_set_table = new DataTable();
            _sql_conn = new MySqlConnection(run_contex.instance()._env.DbConn);
            _sql_conn.Open();
            _sql_adp = new MySqlDataAdapter(sql, _sql_conn);
            _sql_adp.Fill(_snbox_set_table);
        }
        private void bindDatabase() {
            cmbSnbox.DataSource = _snbox_set_table;
            cmbSnbox.DisplayMember = "serialnum";
            cmbSnbox.ValueMember = "snbox_serialnum";
            textBoxProductNum.DataBindings.Add(new Binding("text", _snbox_set_table, "snbox_num"));
            richTextBox.DataBindings.Add(new Binding("text", _snbox_set_table, "snbox_box"));
            richTextproduct.DataBindings.Add(new Binding("text", _snbox_set_table, "snbox_product"));
            //snbox_numbox
            tbCurboxnum.DataBindings.Add(new Binding("text", _snbox_set_table, "snbox_numbox"));
            tbCurpacknum.DataBindings.Add(new Binding("text", _snbox_set_table, "snbox_curboxnum"));
        }
        private void disconnect_db() {
            _sql_conn.Close();
        }
        public frmFormula() {
            InitializeComponent();
            this.DialogResult = System.Windows.Forms.DialogResult.None;
        }
        private void modify_richtext_style(RichTextBox r) {
            r.Text = r.Text.ToUpper();
            string content = r.Text;
            int len = content.Length;
            for (int i = 0; i < len; i++) {
                char c = content[i];
                if (c == '@') {
                    r.Select(i, 2);
                    r.SelectionColor = Color.Red;
                    r.SelectionFont = new Font("微软雅黑", 9, FontStyle.Underline);
                }
            }
        }
        private void selectCurrFormual() {
            string cur_formal = run_contex.instance()._curFormula;
            string item = "";
            if (cmbSnbox.Items.Count > 0 && cur_formal != "") {
                for (int i = 0; i < cmbSnbox.Items.Count; i++) {
                    item = _snbox_set_table.Rows[i]["snbox_serialnum"].ToString();
                    if (item == cur_formal) {
                        cmbSnbox.SelectedIndex = i;
                        break;
                    }
                }
            }
        }
        private void frmFormula_Load(object sender, EventArgs e) {
            modify_richtext_style(richTexttips);
            connectdb_and_init();
            bindDatabase();
            selectCurrFormual();
            if (!run_contex.instance()._env.login_private) {
                richTextBox.Enabled = false;
                richTextproduct.Enabled = false;
            } else {
                richTextBox.Enabled = true;
                richTextproduct.Enabled = true;
            }
            if (!run_contex.instance()._env.login_private) {
                tbCurpacknum.ReadOnly = true;
            }
        }
        /*
        private void fixboxsetIndexbug(string type) {
            string modify_cmd = string.Format("alter table box_set_{0} drop primary key;alter table box_set_{1} add id int auto_increment primary key;", type);
        }
         * */

        /// <summary>
        /// 检测产品型号是否重合
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private bool checkProduct(string type) {
            bool r = true;
            string sql = string.Format("select count(*) as count from box_set WHERE snbox_serialnum = \'{0}\'", type);
            MySqlDataReader read = new MySqlCommand(sql, _sql_conn).ExecuteReader();
            if (read != null && read.Read()) {
                int count = Convert.ToInt32(read[0]);
                if (count > 0) {
                    r = false;
                }
            }
            read.Dispose();
            return r;
        }
        /// <summary>
        /// 创建
        /// </summary>
        private void createProductTypeTable(string ptype) {
            ptype = ptype.ToUpper();
            string exe_sql = "CREATE TABLE IF Not Exists  `sn_box_" + ptype + "`" + "(" +
                                        "`id` int NOT NULL AUTO_INCREMENT COMMENT '主键', " + 
                                        "`dmc` varchar(100) CHARACTER SET ascii NOT NULL DEFAULT \'\'," +
                                        "`dmc_intern` varchar(100) CHARACTER SET ascii NOT NULL DEFAULT \'\', " +
                                        "`snbox` varchar(100) CHARACTER SET ascii NOT NULL DEFAULT \'\'," +
                                        "`numbox` int(10) NOT NULL DEFAULT 0, " +
                                        "`persno` varchar(20) CHARACTER SET ascii NOT NULL, " +
                                        "`time` timestamp  NOT NULL, " +
                                        "`unit` int(10) NOT NULL DEFAULT 0," +
                                        "PRIMARY KEY (`id`), " +
                                        "UNIQUE KEY `dmc` (`dmc`) USING BTREE " +
                                        ") ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;";
            MySqlCommand cmd = new MySqlCommand(exe_sql, _sql_conn);
            cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// 添加型号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuAdd_Click(object sender, EventArgs e) {
            if (!run_contex.instance()._env.login_private) return;
            frmInput input = new frmInput();
            if (input.ShowDialog() == System.Windows.Forms.DialogResult.OK && checkProduct(input.ProductType) && input.Product_Num != 0) {
                string sql = "INSERT INTO box_set " + "(snbox_serialnum, snbox_num, snbox_box, snbox_product, snbox_numbox) values ( \'{0}\', \'{1}\', \'{2}\', \'{3}\', 0)";
                sql = string.Format(sql, input.ProductType, input.Product_Num, "", "");
                MySqlCommand cmd = new MySqlCommand(sql, _sql_conn);
                try {
                    cmd.ExecuteNonQuery();
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                    return;
                }
                DataRow r = _snbox_set_table.NewRow();
                r["snbox_serialnum"] = input.ProductType;
                r["snbox_num"] = input.Product_Num;
                r["snbox_box"] = "";
                r["snbox_product"] = "";
                r["snbox_curboxnum"] = "0";
                _snbox_set_table.Rows.Add(r);
                cmbSnbox.SelectedIndex = cmbSnbox.Items.Count - 1;
                //创建对应的产品型号表
                createProductTypeTable(input.ProductType);
                cmbSnbox.Focus();
            } else if (input.ProductType != "") {
                MessageBox.Show("请不要输入重复的型号!");
            }
        }
        /// <summary>
        /// 删除型号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDel_Click(object sender, EventArgs e) {
            if (run_contex.instance()._env.login_private) {
                if (MessageBox.Show("是否要删除当前产品，删除后不可恢复", "注意!!!", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    if (cmbSnbox.SelectedIndex >= 0) {
                        string serial = cmbSnbox.Text;
                        _snbox_set_table.Rows.Remove(_snbox_set_table.Rows[cmbSnbox.SelectedIndex]);
                        string cmd_exe = string.Format("delete from box_set where snbox_serialnum=\'{0}\'; ", serial);
                        cmd_exe += "DROP TABLE IF EXISTS `sn_box_" + serial + "`;";
                        MySqlCommand cmd = new MySqlCommand(cmd_exe, _sql_conn);
                        int r = cmd.ExecuteNonQuery();
                        if (r > 0) {
                            MessageBox.Show("删除型号成功!");
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 产品型号
        /// </summary>
        private string _sn_box_type = "";
        public string BoxSN {
            get { return _sn_box_type; }
        }
        /// <summary>
        /// 选择型号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e) {
            
            this.DialogResult = System.Windows.Forms.DialogResult.No;
            if (cmbSnbox.SelectedIndex >= 0) {
                richTextBox.Text = richTextBox.Text.ToUpper();
                richTextproduct.Text = richTextproduct.Text.ToUpper();
                if (richTextBox.Text.Trim() == "" || richTextproduct.Text.Trim() == "") {
                    MessageBox.Show("装箱规则和产品规则必须输入!");
                    return;
                }
                DataRow row = _snbox_set_table.Rows[cmbSnbox.SelectedIndex];
                string serial = cmbSnbox.Text;
                string num = textBoxProductNum.Text;
                string box = richTextBox.Text;
                string product = richTextproduct.Text;
                string material_num = tbCurpacknum.Text.Trim();
                row["snbox_serialnum"] = serial;
                row["snbox_box"] = box;
                row["snbox_product"] = product;
                row["snbox_curboxnum"] = material_num;
                //run_contex.instance()._env.material_num = material_num;//料号
                string cmd_exe = string.Format("update box_set set snbox_serialnum=\'{0}\', snbox_box=\'{1}\', snbox_product=\'{2}\', snbox_curboxnum=\'{3}\' where snbox_serialnum = \'{4}\'",
                    serial, box, product, material_num, serial);
                MySqlCommand cmd = new MySqlCommand(cmd_exe, _sql_conn);
                cmd.ExecuteNonQuery();
                _sn_box_type = cmbSnbox.Text.Trim();
                if (_sn_box_type != "") {
                    //保存选择的配方
                    run_contex.instance()._env.PrevProduct = _sn_box_type;
                    //修改配方
                    if (run_contex.instance()._curFormula != _sn_box_type) {
                        run_contex.instance()._curFormula = _sn_box_type;
                        mainForm.getMainForm().setBoxNum("");
                        mainForm.getMainForm().setProductNum("");
                        //这里会有潜在的错误!!!
                        int allProNums = int.Parse(textBoxProductNum.Text);
                        //将当前的配方设置
                        int curNumbox = 0;
                        if (tbCurpacknum.Text != "")
                            curNumbox = int.Parse(tbCurpacknum.Text);
                        //当前箱号
                        //int curboxsn = 0;
                        //接着上面一次扫描
                        if (tbCurboxnum.Text != "" && tbCurboxnum.Text != "0"
                            && curNumbox > 0 && curNumbox < allProNums) {
                            //这里必须是数据，如果夹着字符就错误了!!!!
                            //curboxsn = int.Parse();
                            run_contex.instance()._curBoxsn = tbCurboxnum.Text.Trim();//箱号保留上次的
                            run_contex.instance()._isFull = false;//这时候箱子是非满的状态
                            run_contex.instance().material_ok = true;//不需扫料号
                        } else {
                            run_contex.instance()._curBoxsn = "";
                            run_contex.instance()._isFull = true;
                        }
                        if (curNumbox >= allProNums) {
                            curNumbox = 0;
                        }
                        run_contex.instance()._allProductNums = allProNums;
                        run_contex.instance()._curProductNums = curNumbox;
                        run_contex.instance()._leaveProductNums = allProNums - curNumbox;
                    }
                    run_contex.instance()._boxSnFormula = richTextBox.Text.Trim();
                    run_contex.instance()._productSnFormula = richTextproduct.Text.Trim();
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    if (material_num != "0") {
                        mainForm.getMainForm().updateInfo("料号不为空,扫描箱号前需要先扫描料号!料号:" + material_num);
                    } else {
                        mainForm.getMainForm().updateInfo("提示信息:");
                    }
                    run_contex.instance()._env.material_num = material_num;
                }
            }
            this.Close();
        }
        private void frmFormula_FormClosing(object sender, FormClosingEventArgs e) {
            disconnect_db();
        }
    }
}
