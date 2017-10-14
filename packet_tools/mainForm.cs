using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;
using System.IO;
namespace packet_tools {
    public partial class mainForm : Form {
        private const string version = "Amphenol Packing V";
        private MySqlConnection _db_conn;
        //登入配置
        private string _root = "";
        private string _password = "";
        //private frmWarn _warm = new frmWarn();
        //所有用户
        private string[] all_workers = null;
        //箱号配置表
        private DataTable product_list_table = new DataTable("sn_box_table");
        private MySqlDataAdapter adp_product = new MySqlDataAdapter();
        //产品规则和装箱规则
        private void setup_database() {
            _db_conn = new MySqlConnection(run_contex.instance()._env.DbConn);
            //fixbug
            try {
                _db_conn.Open();
            } catch {
                //强制退出
                System.Environment.Exit(0);
            }
        }
        delegate void setText(string n);
        delegate void doSometing();
        public void setProductNum(string nu) {
            if (tbBoxNumber.InvokeRequired) {
                this.Invoke(new setText(setProductNum), new object[] { nu });
            } else {
                tbBoxNumber.Text = nu;
            }
        }
        //显示一个对话框
        public void setWarnningDlg()
        {
            this.Invoke((EventHandler)delegate { warnDlg d = new warnDlg(); d.Show(); });
        }
        /*
         * 播放mp3音乐
         * */
        enum playOpt {
            play = 0,
            stop = 1,
            sleep = 2
        };
        private System.Media.SoundPlayer sp = null;
        private playOpt _playFlag = playOpt.sleep;
        private bool playRunFlag = true;
        private Thread playAudioThread = null;
        private object _lock = new object();
        public void PlayAudio() {
            lock (_lock) {
                    _playFlag = playOpt.play;
            }
        }
        /*
        public void PlayeFileAudio(string file) {
            lock (_lock) {
                sp.SoundLocation = file;
                _playFlag = playOpt.play;
            }
        }
         * */
        public void PlayFileAudio() {
            lock (_lock) {
                _playFlag = playOpt.play;
            }
        }
        public void PlayFileAudio(string file) {
            lock (_lock) {
                string audio_file = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\"+file;
                sp.SoundLocation = audio_file;
                lock (_lock) {
                    _playFlag = playOpt.play;
                }
            }
        }
        //重复sn日志
        public void logRepeatTime(string desc, string sn) {
            string log_file = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\repeat.log";
            File.AppendAllText(log_file,
                             DateTime.Now.ToString("yyyy-MM-dd/HH:mm:ss ") + ":= " + desc + " "+sn + "\r\n" );
        }
        //显示一个重复sn对话框
        public void setRepeatWarnDlg()
        {
            if (File.Exists(System.Environment.CurrentDirectory+"\\status")) {
                File.WriteAllLines(System.Environment.CurrentDirectory+"\\status", new string[] { "0" });
            }
            this.Invoke((EventHandler)delegate { warnRepeatDlg d = new warnRepeatDlg(); d.ShowDialog(); });
        }
        //显示重复产品号对话框
        public void setRepeatWarnSNDlg() {
            if (File.Exists(System.Environment.CurrentDirectory + "\\snstatus")) {
                File.WriteAllLines(System.Environment.CurrentDirectory + "\\snstatus", new string[] { "0" });
            }
            this.Invoke((EventHandler)delegate { warnRepeatSNDlg d = new warnRepeatSNDlg(); d.ShowDialog(); });
        }

        private bool initPlayAudio() {
            bool rs = false;
            string audio_file = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\提示音.wav";
            //string audiofile_scanok = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\叮.wav";
            if (System.IO.File.Exists(audio_file) /*&& 
                System.IO.File.Exists(audiofile_scanok)*/) {
                //System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
                sp = new System.Media.SoundPlayer();
                sp.SoundLocation = audio_file;
                rs = true;
                playAudioThread = new Thread(new ThreadStart(delegate{
                    while (playRunFlag) {
                        if (_playFlag == playOpt.play) {
                            sp.PlaySync();
                            sp.SoundLocation = audio_file;
                            lock (_lock) {
                                _playFlag = playOpt.stop;
                            }
                        } else if (_playFlag == playOpt.stop) {
                            sp.Stop();
                            Thread.Sleep(10);
                        } else if (_playFlag == playOpt.sleep) {
                            Thread.Sleep(10);
                        }
                    }
                }));
                playAudioThread.Start();
            }
            return rs;
        }
        //更新信息
        public void updateInfo(string info) {
            if (lbInfo.InvokeRequired) {
                this.Invoke(new setText(updateInfo), new object[] { info });
            } else {
                lbInfo.Text = info;
            }
        }

        private void closePlayAudio() {
            playRunFlag = false;
        }

        public void setBoxNum(string nu) {
            if (tbProductNum.InvokeRequired) {
                this.Invoke(new setText(setBoxNum), new object[] { nu });
            } else {
                tbProductNum.Text = nu;
            }
        }
        public void setAllProductNum(string all) {
            if (lbSetVal.InvokeRequired) {
                this.Invoke(new setText(setAllProductNum), new object[] { all });
            } else {
                lbSetVal.Text = all;
            }
        }
        public void setCurProductNum(string cur) {
            if (lbCurVal.InvokeRequired) {
                this.Invoke(new setText(setCurProductNum), new object[] { cur });
            } else {
                lbCurVal.Text = cur;
            }
        }
        public void setLeaveProductNum(string leave) {
            if (lbLeftVal.InvokeRequired) {
                this.Invoke(new setText(setLeaveProductNum), new object[] { leave });
            } else {
                lbLeftVal.Text = leave;
            }
        }

        public void setWarnString(string warn) {
            if (lbWarn.InvokeRequired) {
                this.Invoke(new setText(setWarnString), new object[] { warn });
            } else {
                lbWarn.Text = warn;
            }
        }

        public void moveListTolast() {
            if (gridEX1.InvokeRequired) {
                this.Invoke(new doSometing(moveListTolast), null);
            } else {
                gridEX1.MoveLast();
            }
        }

        //把数据加入到列表中
        public void setInsertRowData(string sn) {
            if (this.InvokeRequired) {
                this.Invoke(new setText(setInsertRowData), new object[] { sn });
            } else {
                DataRow r = product_list_table.NewRow();
                r["dmc"] = sn;
                r["snbox"] = run_contex.instance()._curBoxsn;
                r["unit"] = run_contex.instance()._allProductNums.ToString();
                r["numbox"] = run_contex.instance()._curProductNums.ToString();
                r["persno"] = run_contex.instance()._curWorker;
                r["time"] = new MySql.Data.Types.MySqlDateTime(DateTime.Now);
                if (product_list_table.Rows.Count >= 1000)
                    product_list_table.Clear();
                product_list_table.Rows.Add(r);
            }
        }
        private static mainForm _mainform = null;
        public static mainForm getMainForm() {
            return _mainform;
        }
        //进入修改值页面
        public bool _changeValue = false;

        private void loadRoot() {
            DataTable tb_root = new DataTable();
            MySqlDataAdapter adp = new MySqlDataAdapter("SELECT * FROM root", _db_conn);
            adp.Fill(tb_root);
            adp.Dispose();
            if (tb_root.Rows.Count <= 0) {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO `root` VALUES ('admin', 'admin');", _db_conn);
                cmd.ExecuteNonQuery();
                _root = "admin";
                _password = "admin";
                tb_root.Dispose();
                return;
            }
            _root = tb_root.Rows[0]["super_user"].ToString();
            _password = tb_root.Rows[0]["pass_word"].ToString();
            tb_root.Dispose();
        }
        private void loadAllWorkers() {
            DataTable tb_allworkers = new DataTable();
            MySqlDataAdapter adp = new MySqlDataAdapter("SELECT * FROM admin", _db_conn);
            adp.Fill(tb_allworkers);
            adp.Dispose();
            all_workers = new string[tb_allworkers.Rows.Count+1];
            int i = 0;
            foreach (DataRow r in tb_allworkers.Rows) {
                all_workers[i] = Convert.ToString(r[0]).Trim();
                i++;
            }
            all_workers[i++] = "admin";
            tb_allworkers.Dispose();
        }
        public mainForm() {
            InitializeComponent();
            setup_database();
            createMySqlEnv();
            loadRoot();
            changeAccess(false);
        }
        /*
        private delegate void show();
        public void showWarm() {
            if (this.InvokeRequired) {
                this.Invoke(new show(showWarm), null);
            } else {
                if (_warm == null) {
                    _warm = new frmWarn();
                    _warm.Show();
                    _warm.BringToFront();
                } else {
                    _warm.Show();
                    _warm.BringToFront();
                }
            }
        }
        
        public void closeWarm() {
            if (this.InvokeRequired) {
                this.Invoke(new show(closeWarm), null);
            } else {
                if (_warm != null && _warm.Visible) {
                    _warm.Close();
                    _warm = null;
                }
            }
        }
         */
        /// <summary>
        /// 设置表格控件的大小
        /// </summary>
        private void setup_gridex_size() {
            int index_w = gridEX1.Width;
            gridEX1.RootTable.Columns[0].Width = (int)(index_w * 0.20);//产品sn
            gridEX1.RootTable.Columns[1].Width = (int)(index_w * 0.20);//箱sn
            gridEX1.RootTable.Columns[2].Width = (int)(index_w * 0.16);//每箱数量
            gridEX1.RootTable.Columns[3].Width = (int)(index_w * 0.10);//第几个
            gridEX1.RootTable.Columns[4].Width = (int)(index_w * 0.10);//工号
            gridEX1.RootTable.Columns[5].Width = (int)(index_w * 0.20);//操作时间
        }
        //数据库当前的页码
        private int page_offset = 0;
        //所有记录条目个数
        private int _all_counts = 0;
        //所有页码
        private int _all_page_count = 0;
        //载入数据
        private void load_data(string name) {
            product_list_table.Clear();
            //得到所有的条码数目
            string sql_query_all = string.Format("select COUNT(sn_box_{0}.dmc) from sn_box_{1};", name, name);
            MySqlDataReader read = new MySqlCommand(sql_query_all, _db_conn).ExecuteReader();
            if (read != null && read.Read()) {
                _all_counts = Convert.ToInt32(read[0]);
            }
            read.Dispose();
            _all_page_count = (_all_counts + 999) / 1000; //总的页数
            //计算出offset
            page_offset = _all_page_count - 1;
            if (page_offset < 0) {
                page_offset = 0;
            }
            //string query_later_page_data = "select * from sn_box_{0}  ORDER BY time limit 1000 offset {1};";
            string query_later_page_data = "select * from sn_box_{0} ORDER BY id ASC limit 1000 offset {1};";
            //string query_later_page_data = "select * from sn_box_{0}  ORDER BY numbox limit 1000 offset {1};";
            query_later_page_data = string.Format(query_later_page_data, name, page_offset * 1000);
            //查询
            adp_product = new MySqlDataAdapter(query_later_page_data, _db_conn);
            adp_product.Fill(product_list_table);
            gridEX1.DataSource = product_list_table;
            gridEX1.MoveLast();
            adp_product.Dispose();
        }
        //创建sql数据表格
        private void createMySqlEnv() {
            string create_database = "CREATE DATABASE IF NOT EXISTS packets default character set utf8 COLLATE utf8_general_ci;";
            MySqlCommand cmd = new MySqlCommand(create_database, _db_conn);
            cmd.ExecuteNonQuery();
            string exe_sql = "CREATE TABLE IF Not Exists  `box_set`( " +
                                     "`snbox_serialnum` varchar(100) NOT NULL, " +
                                     "`snbox_num` int(10) NOT NULL, " +
                                     "`snbox_box` varchar(100) NOT NULL, " +
                                     "`snbox_product` varchar(100) NOT NULL, " +
                                     "`snbox_curboxnum` varchar(100) NOT NULL DEFAULT 0, " +
                                     "`snbox_numbox` varchar(100) NOT NULL," +
                                     " PRIMARY KEY (`snbox_serialnum`), " +
                                     " UNIQUE KEY `snbox_serialnum` (`snbox_serialnum`) USING BTREE " +
                                     ") ENGINE=InnoDB DEFAULT CHARSET=utf8;";
            cmd.CommandText = exe_sql;
            cmd.ExecuteNonQuery();

            string modify_cmd = "alter table box_set modify snbox_serialnum varchar(100) NOT NULL,modify snbox_box varchar(100) NOT NULL, modify snbox_product varchar(100) NOT NULL,modify snbox_curboxnum varchar(100) NOT NULL DEFAULT 0,modify snbox_numbox varchar(100) NOT NULL;";
            cmd.CommandText = modify_cmd;
            cmd.ExecuteNonQuery();

            exe_sql = "CREATE TABLE IF  Not EXISTS `admin` (" +
                                    "`persno` varchar(8) CHARACTER SET ascii DEFAULT NULL, " +
                                    "UNIQUE KEY `persno` (`persno`) USING BTREE " +
                                    ") ENGINE=InnoDB DEFAULT CHARSET=utf8;";
            cmd.CommandText = exe_sql;
            cmd.ExecuteNonQuery();
            exe_sql = "CREATE TABLE IF  Not EXISTS `root`( " +
                            "`super_user` varchar(10) NOT NULL, " +
                            "`pass_word` varchar(10) NOT NULL, " +
                            "PRIMARY KEY (`super_user`) " +
                            ") ENGINE=InnoDB DEFAULT CHARSET=utf8;";
            cmd.CommandText = exe_sql;
            cmd.ExecuteNonQuery();
            //修复一个bug
            string query_primary_key = "SELECT t.TABLE_NAME,t.CONSTRAINT_TYPE,c.COLUMN_NAME," +
                                       "c.ORDINAL_POSITION FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS t," +
                                       "INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS c WHERE t.TABLE_NAME = c.TABLE_NAME " +
                                       "AND t.TABLE_SCHEMA = \'packets\' AND t.CONSTRAINT_TYPE = \'PRIMARY KEY\' " +
                                       "AND t.TABLE_NAME LIKE \'sn_box_%\' AND COLUMN_NAME=\'dmc\';";
            cmd.CommandText = query_primary_key;
            /*
            try {
                MySqlDataReader r = cmd.ExecuteReader();
                List<string> store_table_name = new List<string>();
                while (r.Read()) {
                    store_table_name.Add(r["TABLE_NAME"].ToString());
                }
                r.Close();
                foreach (string t in store_table_name) {
                    string del_primary_key = "ALTER table {0} drop primary key;alter table {1} add column `id` int not null auto_increment primary key comment '主键' first;";
                    string exe = string.Format(del_primary_key, t, t);
                    cmd.CommandText = exe;
                    cmd.ExecuteNonQuery();
                }
            } catch(Exception e) {
                MessageBox.Show(e.Message);
            }
             * */
        }

        private void mainForm_Load(object sender, EventArgs e) {
            //创建status文件
            string status = System.Environment.CurrentDirectory + "\\status";
            if (!File.Exists(status)) {
                File.WriteAllLines(System.Environment.CurrentDirectory + "\\status", new string[] { "-1" });
            }
            //创建snstatus文件
            string snstatus = System.Environment.CurrentDirectory + "\\snstatus";
            if (!File.Exists(snstatus)) {
                File.WriteAllLines(System.Environment.CurrentDirectory + "\\snstatus", new string[] { "-1" });
            }
            _mainform = this;
            if (File.ReadAllLines(status)[0].Trim() == "0") {
                mainForm.getMainForm().setRepeatWarnDlg();
            }
            //add 16/5/30
            if (File.ReadAllLines(snstatus)[0].Trim() == "0") {
                mainForm.getMainForm().setRepeatWarnSNDlg();
            }
            //set up version
            string Ver = packet_tools.Properties.Resources.version;
            this.Text = version + Ver;
            setup_gridex_size();
            if (!initPlayAudio()) {
                MessageBox.Show("创建播放提醒声音失败");
            }
        }
        private int getCurBoxMaxNum(string type) {
            int res = 0;
            string sql = "SELECT sn_box_" + type + ".packbox FROM sn_box_" + type + " WHERE sn_box_" + type + ".packbox = (SELECT MAX(sn_box_" + type + ".packbox) FROM sn_box_" + type + ");";
            MySqlDataReader r = new MySqlCommand(sql, _db_conn).ExecuteReader();
            if (r.Read()) {
                res = Convert.ToInt32(r[0]);
            }
            r.Close();
            return res;
        }
        private void mainForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (MessageBox.Show("你是否要离开打包程序?", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                _db_conn.Close();
                run_contex.instance().exit_runcontex();
                closePlayAudio();
            } else {
                e.Cancel = true;
            }
        }
        //更改权限
        private void changeAccess(bool p) {
            menuSelectformula.Enabled = p;
            itemSetHandle.Enabled = p;
            if (p && run_contex.instance()._env.login_private) {
                menuManager.Enabled = p;
            } else {
                menuManager.Enabled = p;
            }
            page_up.Enabled = p;
            page_down.Enabled = p;
            tbJumpoffset.Text = "";
            tbJumpoffset.Enabled = p;
            jump_pageoffset.Enabled = p;
            chanegValue.Enabled = p;
            lbSetVal.Text = "0";
            lbLeftVal.Text = "0";
            lbCurVal.Text = "0";
        }
        //获取已经输入到表中的数量
        private int get_input_data_len(string t, string box_sn) {
            int n = 0;
            string sql = "SELECT COUNT(dmc) FROM sn_box_{0} where snbox = \'{1}\'";
            string exec = string.Format(sql, t, box_sn);
            MySqlDataReader read = null;
            try
            {
                read = new MySqlCommand(exec, _db_conn).ExecuteReader();
            }
            catch
            {
                if (read != null)
                    read.Dispose();
                return n;
            }
            if (read != null && read.Read()) {
                n = Convert.ToInt32(read[0]);
            }
            read.Dispose();
            return n;
        }

        //判断表是否存在
        private bool judge_table_exit(string t) {
            string sql = "SELECT table_name FROM information_schema.TABLES WHERE table_name = \'sn_box_{0}\' ;";
            string exec = string.Format(sql, t);
            MySqlDataReader read = null;
            try
            {
                read = new MySqlCommand(exec, _db_conn).ExecuteReader();
            }
            catch
            {
                if (read != null)
                    read.Dispose();
                return false;
            }
            if (read != null && read.Read()) {
                if (read.HasRows)
                    read.Dispose();
                    return true;
            }
            read.Dispose();
            return false;
        }
        //重新整理了数据载入逻辑
        private void initSetting(string table_subfix) {
            string query_box_set = "select * from box_set where snbox_serialnum = \'" + table_subfix + "\';";
            MySqlCommand cmd_query_box_set = new MySqlCommand(query_box_set, _db_conn);
            MySqlDataReader query_box_set_res =  cmd_query_box_set.ExecuteReader();
            int box_set_max = 0;
            string product_formual = "";
            string box_formual = "";
            if (query_box_set_res.Read()){
                //取得最大值
                box_set_max = Convert.ToInt32(query_box_set_res["snbox_num"]);
                product_formual = query_box_set_res["snbox_product"].ToString();
                box_formual = query_box_set_res["snbox_box"].ToString();
                run_contex.instance()._boxSnFormula = box_formual;
                run_contex.instance()._productSnFormula = product_formual;
            }
            query_box_set_res.Close();
            //读取到的box_set的num为0，直接返回
            if (box_set_max==0)return;
            string table = string.Format("sn_box_{0}", table_subfix);
            string sql = "select * from " + table + 
                " where id =(select max(id) from " 
                + table+ ") order by id;";
            MySqlCommand cmd = new MySqlCommand(sql, _db_conn);
            MySqlDataReader r =  cmd.ExecuteReader();
            if (r.Read()) {
                run_contex.instance()._allProductNums = Convert.ToInt32(r["unit"]);
                run_contex.instance()._curProductNums = Convert.ToInt32(r["numbox"]);
                run_contex.instance()._curBoxsn = r["snbox"].ToString();
                run_contex.instance()._leaveProductNums = run_contex.instance()._allProductNums - run_contex.instance()._curProductNums;
                if (run_contex.instance()._leaveProductNums == 0) {
                    run_contex.instance()._isFull = true;
                    run_contex.instance()._leaveProductNums = run_contex.instance()._allProductNums;
                    run_contex.instance()._curBoxsn = "";
                    run_contex.instance()._curProductNums = 0;
                } else {
                    run_contex.instance()._isFull = false;
                }
            } else {
                run_contex.instance()._allProductNums = box_set_max;
                run_contex.instance()._curProductNums = 0;
                run_contex.instance()._curBoxsn = "";//箱号为空
                run_contex.instance()._leaveProductNums = box_set_max;
                run_contex.instance()._isFull = true;
            }
            r.Close();
            mainForm.getMainForm().setAllProductNum(run_contex.instance()._allProductNums.ToString());
            mainForm.getMainForm().setLeaveProductNum(run_contex.instance()._leaveProductNums.ToString());
            mainForm.getMainForm().setCurProductNum(run_contex.instance()._curProductNums.ToString());
            setBoxNum(run_contex.instance()._curBoxsn);
            load_data(table_subfix);
        }

        //载入产品公共函数
        private void loadProductType(string type)
        {
            //自动载入
            //修改了华工提出的不能自动载入的bug
            DataTable _snbox_set_table;
            MySqlDataAdapter _sql_adp;
            string sql = "select * from box_set where snbox_serialnum = \'" + type + "\';";
            _snbox_set_table = new DataTable();
            _sql_adp = new MySqlDataAdapter(sql, _db_conn);
            _sql_adp.Fill(_snbox_set_table);
            if (_snbox_set_table.Rows.Count > 0)
            {
                //这里可能会有问题
                string box_sn = _snbox_set_table.Rows[0]["snbox_numbox"].ToString();//获取当前打包箱号
                if (box_sn == null || box_sn == "")
                {
                    run_contex.instance()._allProductNums = run_contex.instance()._leaveProductNums = Convert.ToInt32(_snbox_set_table.Rows[0]["snbox_num"]);
                    run_contex.instance()._curProductNums = 0;
                    run_contex.instance()._isFull = true;
                }
                else if (box_sn != "")
                {
                    run_contex.instance()._allProductNums = Convert.ToInt32(_snbox_set_table.Rows[0]["snbox_num"]);
                    int n = get_input_data_len(type, box_sn);
                    if (n == run_contex.instance()._allProductNums)
                    {
                        run_contex.instance()._isFull = true;
                        run_contex.instance()._curProductNums = 0;
                    }
                    else if (run_contex.instance()._allProductNums != n && n > 0)
                    {
                        run_contex.instance()._isFull = false;
                        run_contex.instance()._curProductNums = n;
                    }
                    else if (n == 0)
                    {
                        run_contex.instance()._isFull = true;
                        run_contex.instance()._curProductNums = 0;
                    }
                    run_contex.instance()._leaveProductNums = run_contex.instance()._allProductNums - run_contex.instance()._curProductNums;
                }
                mainForm.getMainForm().setAllProductNum(run_contex.instance()._allProductNums.ToString());
                mainForm.getMainForm().setLeaveProductNum(run_contex.instance()._leaveProductNums.ToString());
                mainForm.getMainForm().setCurProductNum(run_contex.instance()._curProductNums.ToString());
                if (!run_contex.instance()._isFull)
                {
                    run_contex.instance()._curBoxsn = box_sn;
                    //设置箱号
                    setBoxNum(run_contex.instance()._curBoxsn);
                }
                run_contex.instance()._productSnFormula = _snbox_set_table.Rows[0]["snbox_product"].ToString();
                run_contex.instance()._boxSnFormula = _snbox_set_table.Rows[0]["snbox_box"].ToString();
                load_data(type);
            }
        }


        private void menuLogin_Click(object sender, EventArgs e) {
            //载入所有工作人员
            loadAllWorkers();
            frmLogin frm = new frmLogin();
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                run_contex.instance()._env.login_private = false;
                if (frm.IsAdmin&& frm.User == _root && frm.Password == _password) {
                    run_contex.instance()._curWorker = _root;
                    lbCurWork.Text = "工号: " + _root;
                    changeAccess(true);
                    menuManager.Enabled = true;
                    //写入登入标志
                    run_contex.instance()._env.login_private = true;
                    /*
                    //创建运行环境
                    run_contex.instance().setup_runcontex();
                    return;
                     * */
                }
                if (frm.IsAdmin && (frm.User != _root || frm.Password != _password)) {
                    MessageBox.Show("登入失败,请重新登入!");
                    return;
                }
                if (frm.User != "") {
                    foreach (string u in all_workers) {
                        if (u == frm.User) {
                            run_contex.instance()._curWorker = u;
                            lbCurWork.Text = "工号: " + u;
                            changeAccess(true);
                            //从ini配置里面取出上次操作的产品
                            string type = run_contex.instance()._env.PrevProduct;
                            if (!judge_table_exit(type)) {
                                run_contex.instance()._env.PrevProduct = "";
                                MessageBox.Show("请创建产品!");
                                return;
                            }
                            //开启串口接收线程
                            run_contex.instance().setup_runcontex();
                            timerFlashTitle.Start();
                            if (type != "") {
                                timerFlashTitle.Stop();
                                string Ver = packet_tools.Properties.Resources.version;
                                this.Text = version + Ver + "-----打包方案 " + type;
                                lbCurPack.Text = "打包方案: " + type;
                                run_contex.instance()._curFormula = type;
                                if (run_contex.instance()._env.material_num.Trim() != "0" && run_contex.instance()._isFull ) {
                                    updateInfo("料号不为空,扫描箱号前需要先扫描料号!料号:" + run_contex.instance()._env.material_num);
                                } else {
                                    updateInfo("提示信息:");
                                }
                                //loadProductType(type);
                                initSetting(type);
                                //自动载入
                                //修改了华工提出的不能自动载入的bug
                                /*
                                DataTable _snbox_set_table;
                                MySqlDataAdapter _sql_adp;
                                string sql = "select * from box_set where snbox_serialnum = \'" + type + "\';";
                                _snbox_set_table = new DataTable();
                                _sql_adp = new MySqlDataAdapter(sql, _db_conn);
                                _sql_adp.Fill(_snbox_set_table);
                                if (_snbox_set_table.Rows.Count > 0) {
                                    //这里可能会有问题
                                    string box_sn = _snbox_set_table.Rows[0]["snbox_numbox"].ToString();//获取当前打包箱号
                                    if (box_sn == null || box_sn == ""){
                                        run_contex.instance()._allProductNums=run_contex.instance()._leaveProductNums = Convert.ToInt32(_snbox_set_table.Rows[0]["snbox_num"]);
                                        run_contex.instance()._curProductNums = 0;
                                        run_contex.instance()._isFull = true;
                                    }
                                    else if (box_sn != "") {
                                        run_contex.instance()._allProductNums = Convert.ToInt32(_snbox_set_table.Rows[0]["snbox_num"]);
                                        int n = get_input_data_len(type, box_sn);
                                        if (n == run_contex.instance()._allProductNums) {
                                            run_contex.instance()._isFull = true;
                                            run_contex.instance()._curProductNums = 0;
                                        } else if (run_contex.instance()._allProductNums != n && n>0 ) {
                                            run_contex.instance()._isFull = false;
                                            run_contex.instance()._curProductNums = n;
                                        } else if (n == 0) {
                                            run_contex.instance()._isFull = true;
                                            run_contex.instance()._curProductNums = 0;
                                        }
                                        run_contex.instance()._leaveProductNums = run_contex.instance()._allProductNums - run_contex.instance()._curProductNums;
                                    }
                                    mainForm.getMainForm().setAllProductNum(run_contex.instance()._allProductNums.ToString());
                                    mainForm.getMainForm().setLeaveProductNum(run_contex.instance()._leaveProductNums.ToString());
                                    mainForm.getMainForm().setCurProductNum(run_contex.instance()._curProductNums.ToString());
                                    if (!run_contex.instance()._isFull) {
                                        run_contex.instance()._curBoxsn = box_sn;
                                        //设置箱号
                                        setBoxNum(run_contex.instance()._curBoxsn);
                                    }
                                    run_contex.instance()._productSnFormula = _snbox_set_table.Rows[0]["snbox_product"].ToString();
                                    run_contex.instance()._boxSnFormula = _snbox_set_table.Rows[0]["snbox_box"].ToString();
                                    load_data(type);
                                }
                                 * */
                            }
                            MessageBox.Show("登入成功!");
                            return;
                        }
                    }
                } 
                MessageBox.Show("登入失败,请重新登入!");
            }
        }

        

        private string[] getAllTables() {
            List<string> d = new List<string>();
            string sql = "select table_name from information_schema.tables where table_schema='packets'";
            MySqlDataReader r = new MySqlCommand(sql, _db_conn).ExecuteReader();
            while (r.Read()) {
                string data = r[0].ToString();
                if (data.StartsWith("sn_box_")) {
                    d.Add(data);
                }
            }
            r.Close();
            return d.ToArray();
        }
        //退出登入
        private void menuLogout_Click(object sender, EventArgs e) {
            changeAccess(false);
            if (run_contex.instance()._env.login_private) {
                run_contex.instance()._env.login_private = false;
                menuManager.Enabled = false;
                //退出登入，可以使得扫箱规则的满，变成默认的满了
                run_contex.instance().clearRunStatus();
                run_contex.instance().exit_runcontex();
            }
            run_contex.instance().exit_runcontex();
            string Ver = packet_tools.Properties.Resources.version;
            this.Text = version+ Ver;
            lbCurWork.Text = "工号: ";
            lbCurPack.Text = "打包方案: ";
            lbCurVal.Text = "0";
            lbLeftVal.Text = "0";
            lbSetVal.Text = "0";
            tbProductNum.Text = "";
            tbBoxNumber.Text = "";
        }
        private void itemSetHandle_Click(object sender, EventArgs e) {
            frmScannerHandler frm = new frmScannerHandler();
            frm.ShowDialog();
        }
        private void itemSelectformula_Click(object sender, EventArgs e) {
            frmFormula frm = new frmFormula();
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                timerFlashTitle.Stop();
                string type = frm.BoxSN;
                string Ver = packet_tools.Properties.Resources.version;
                this.Text = version+ Ver + "-----打包方案 " + type;
                lbCurPack.Text = "打包方案: " + type;
                run_contex.instance()._curFormula = type;
                
                //load_data(type);
                //loadProductType(type);
                initSetting(type);
                /*
                lbSetVal.Text = run_contex.instance()._allProductNums.ToString();
                lbCurVal.Text = run_contex.instance()._curProductNums.ToString();
                lbLeftVal.Text = run_contex.instance()._leaveProductNums.ToString();
                tbProductNum.Text = run_contex.instance()._curBoxsn;
                mainForm.getMainForm().setProductNum("");//清零产品号
                 * */
            }
        }
        private void menuManager_Click(object sender, EventArgs e) {
            if (run_contex.instance()._env.login_private) {
                frmUserManager frm = new frmUserManager();
                frm.ShowDialog();
            }
        }
        //上翻
        private void page_up_Click(object sender, EventArgs e) {
            if (run_contex.instance()._curFormula != "") {
                if (page_offset >= 0) {
                    string query_later_page_data = "select * from sn_box_{0} ORDER BY id limit 1000 offset {1};";
                    query_later_page_data = string.Format(query_later_page_data, run_contex.instance()._curFormula, page_offset * 1000);
                    //查询
                    product_list_table.Clear();
                    adp_product = new MySqlDataAdapter(query_later_page_data, _db_conn);
                    adp_product.Fill(product_list_table);
                    adp_product.Dispose();
                    --page_offset;
                    if (page_offset <= 0)
                        page_offset = 0;
                    gridEX1.MoveFirst();
                }
            }
        }
        //下翻
        private void page_down_Click(object sender, EventArgs e) {
            if (run_contex.instance()._curFormula != "") {
                if (page_offset <= _all_page_count - 1) {
                    string query_later_page_data = "select * from sn_box_{0} ORDER BY id limit 1000 offset {1};";
                    query_later_page_data = string.Format(query_later_page_data, run_contex.instance()._curFormula, page_offset * 1000);
                    //查询
                    product_list_table.Clear();
                    adp_product = new MySqlDataAdapter(query_later_page_data, _db_conn);
                    adp_product.Fill(product_list_table);
                    adp_product.Dispose();
                    ++page_offset;
                    if (page_offset >= _all_page_count) {
                        page_offset = _all_page_count - 1;
                    }
                    gridEX1.MoveLast();
                }
            }
        }
        //跳转
        private void jump_pageoffset_Click(object sender, EventArgs e) {
            //PlayAudio("stop");
            if (run_contex.instance()._curFormula != "") {
                try {
                    int jump_offset = 0;
                    jump_offset = int.Parse(tbJumpoffset.Text.Trim());
                    page_offset = (jump_offset + 999) / 1000 - 1;
                    string query_later_page_data = "select * from sn_box_{0} ORDER BY id limit 1000 offset {1};";
                    query_later_page_data = string.Format(query_later_page_data, run_contex.instance()._curFormula,page_offset * 1000);
                    //查询
                    product_list_table.Clear();
                    adp_product = new MySqlDataAdapter(query_later_page_data, _db_conn);
                    adp_product.Fill(product_list_table);
                    adp_product.Dispose();
                    gridEX1.MoveTo(jump_offset - 1);
                    tbJumpoffset.Text = "";
                } catch {
                    MessageBox.Show("请输入准确的数字!");
                    tbJumpoffset.Text = "";
                }
            }
        }
        //按键事件
        private void mainForm_KeyDown(object sender, KeyEventArgs e) {
            if ((e.KeyCode == Keys.F4) && (e.Alt == true)) {
                e.Handled = true;
            }
        }
        //响应查询事件
        private void tbJumpoffset_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13 && run_contex.instance()._curWorker != "") {
                jump_pageoffset_Click(sender, null);
            }
        }
        //登入后，闪烁字符
        private bool _flash = false;
        private void timerFlashTitle_Tick(object sender, EventArgs e) {
            _flash = !_flash;
            string Ver = packet_tools.Properties.Resources.version;
            if (_flash) {
                this.Text = version + Ver + " -----请选择打包方案!!!-----";
            } else {
                this.Text = version + Ver;
            }
        }
        //窗口大小变化
        private void mainForm_Resize(object sender, EventArgs e) {
            setup_gridex_size();
        }
        //change value 对话框
        public frmChangeValue _changeDlg = null;
        
        //更新数据到表中去
        //更新产品表
        private bool updateBoxset(string type) {
            bool r = false;
            string cmd_exe = string.Format("update box_set set snbox_numbox=\'{0}\' where snbox_serialnum = \'{1}\';",
                    run_contex.instance()._curBoxsn, type);
            MySqlCommand cmd = new MySqlCommand(cmd_exe, _db_conn);
            int n = cmd.ExecuteNonQuery();
            if (n > 0) {
                r = true;
            }
            return r;
        }
        private bool assertBoxsetIsFull(string new_boxset) {
            bool res = false;
            string cmd_exe = string.Format("select count(dmc) c , unit from sn_box_{0} where snbox = \'{1}\'", run_contex.instance()._curFormula, new_boxset);
            MySqlCommand cmd = new MySqlCommand(cmd_exe, _db_conn);
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.Read()) {
                int c = Convert.ToInt32(r["c"]);
                int a = 0;
                if (r["unit"] == DBNull.Value) {
                    a = 0;
                } else {
                    a = Convert.ToInt32(r["unit"]);
                }
                if (c == 0)
                    res = false;
                else if (c>0 && c >= a)
                    res = true;
                else
                    res= false;
            }
            r.Close();
            return res;
        }
        //修改指定记录
        private void chanegValue_Click(object sender, EventArgs e) {
            if (run_contex.instance()._env.login_private) {
                if (product_list_table != null && product_list_table.Rows.Count <= 0)
                    return;
                int i = gridEX1.CurrentRow.Position;
                if (i >= 0) {
                    _changeValue = true;
                    DataRow dr = product_list_table.Rows[i];
                    string dmc = dr["dmc"].ToString();
                    string snbox = dr["snbox"].ToString();
                    //string time = dr["time"].ToString();
                    _changeDlg = new frmChangeValue();
                    _changeDlg.BoxSN = snbox;
                    _changeDlg.ProductSN = dmc;
                    if (_changeDlg.ShowDialog() == DialogResult.Yes) {
                        string new_snbox = _changeDlg.BoxSN;
                        string new_dmc = _changeDlg.ProductSN;
                        if (assertBoxsetIsFull(new_snbox))
                            return;
                        /*
                        string cmd_exe = string.Format("update sn_box_{0} set dmc=\'{1}\', dmc_intern=\'{2}\', snbox=\'{3}\' , persno = \'{4}\', time = NOW() where  dmc = \'{5}\';",
                        run_contex.instance()._curFormula, new_dmc, new_dmc, new_snbox ,run_contex.instance()._curWorker, dmc);
                        */
                        /*
                        if (snbox.Trim() != new_snbox.Trim()) {
                            string update_snbox = "update sn_box_{0} set snbox=\'{1}\' where snbox=\'{2}\';";
                            string ex = string.Format(update_snbox, run_contex.instance()._curFormula, new_snbox, snbox);
                            MySqlCommand cmd1 = new MySqlCommand(ex, _db_conn);
                            cmd1.ExecuteNonQuery();
                        }
                         * */
                        string cmd_exe = string.Format("update sn_box_{0} set dmc=\'{1}\', dmc_intern=\'{2}\', time = Now(), snbox= \'{3}\' where  dmc = \'{4}\';",
                          run_contex.instance()._curFormula, new_dmc, new_dmc, new_snbox, dmc);
                        MySqlCommand cmd = new MySqlCommand(cmd_exe, _db_conn);
                        try {
                            cmd.ExecuteNonQuery();
                        } catch {
                            MessageBox.Show("更新失败,检查输入的产品号是否重复!");
                            return;
                        }
                        dr["dmc"] = new_dmc;
                        dr["snbox"] = new_snbox;
                        dr["time"] = new MySql.Data.Types.MySqlDateTime(DateTime.Now);
                        //修改箱号
                        DataRow last_row = product_list_table.Rows[product_list_table.Rows.Count - 1];
                        run_contex.instance()._curBoxsn = last_row["snbox"].ToString();
                        updateBoxset(run_contex.instance()._curFormula);
                        mainForm.getMainForm().setBoxNum(run_contex.instance()._curBoxsn);    
                        //重新载入数据
                        //loadProductType(run_contex.instance()._curFormula);
                        initSetting(run_contex.instance()._curFormula);
                        /*
                        //修改箱号
                        if (new_snbox.Trim() != snbox.Trim()) {
                            string cmd_exe = string.Format("update sn_box_{0} set snbox=\'{1}\' , time=Now() where snbox=\'{2}\';",
                                run_contex.instance()._curFormula, new_snbox, snbox);
                            MySqlCommand cmd = new MySqlCommand(cmd_exe, _db_conn);
                            try {
                                cmd.ExecuteNonQuery();
                            } catch {
                                MessageBox.Show("更新失败,检查输入的箱号是否正确!");
                                return;
                            }
                            foreach (DataRow r in product_list_table.Rows) {
                                if (r["snbox"].ToString() == snbox) {
                                    r["snbox"] = new_snbox;
                                    r["time"] = new MySql.Data.Types.MySqlDateTime(DateTime.Now);
                                }
                            }
                        }
                         * */
                    }
                    _changeDlg.Dispose();
                }
            }
        }
    }
}
