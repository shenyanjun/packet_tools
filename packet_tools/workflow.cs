using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Runtime.InteropServices;
//用来实现业务逻辑层
namespace packet_tools {
    class workflow {
        private MySqlConnection _sql_conn;
        //在接收到箱号扫描器时调用
        public bool onPBoxScanner(string sn) {
            if (checkBoxNo(sn)) {
                run_contex.instance()._curBoxsn = sn;
                //修正一个bug,必须更新到数据库中去
                updateBoxset(run_contex.instance()._curFormula);
                return true;
            } else {
                return false;
            }
        }
        private bool checkBoxNo(string sn) {
            //string sql = "SELECT count(sn_box_{0}.numbox) as select_num, box_set.snbox_num FROM box_set, sn_box_{1} WHERE sn_box_{2}.snbox = \'{3}\' and sn_box_{4}.snbox = box_set.snbox_numbox;";
            string sql = "SELECT count(sn_box_{0}.numbox) as select_num, box_set.snbox_num FROM box_set, sn_box_{1} WHERE sn_box_{2}.snbox = \'{3}\';";
            string exe = string.Format(sql, 
                run_contex.instance()._curFormula, 
                run_contex.instance()._curFormula,
                run_contex.instance()._curFormula, 
                sn
                );
            MySqlCommand cmd = new MySqlCommand(exe, _sql_conn);
            MySqlDataReader r = cmd.ExecuteReader();
            if (r.Read()) {
                int inputnum = Convert.ToInt32(r["select_num"]);
                if (inputnum == 0) {
                    r.Dispose();
                    return true;
                }
                int allnum = 0;
                try {
                    allnum = Convert.ToInt32(r["snbox_num"]);
                } catch {
                    allnum = 0;
                    r.Dispose();
                    return true;
                }
                if (inputnum < allnum) {
                    r.Dispose();
                    return true;
                }
            } else {
                r.Dispose();
                return true; 
            }
            r.Dispose();
            return false;
        }
        //更新数据到表中去
        //更新产品表
        public bool updateBoxset(string type) {
            bool r = false;
            string cmd_exe = string.Format("update box_set set snbox_curboxnum=\'{0}\', snbox_numbox=\'{1}\' where snbox_serialnum = \'{2}\';",
                    run_contex.instance()._curProductNums, run_contex.instance()._curBoxsn, type);
            MySqlCommand cmd = new MySqlCommand(cmd_exe, _sql_conn);
            int n = cmd.ExecuteNonQuery();
            if (n > 0) {
                r = true;
            }
            return r;
        }
        //插入数据到snbox
        private bool insert2Snbox(string sn) {
            bool r = false;
            string table = "sn_box_" + run_contex.instance()._curFormula;
            ++run_contex.instance()._curProductNums;
            string sql = "INSERT  INTO sn_box_{0} (dmc, dmc_intern, snbox, numbox, persno, time, unit) values ( \'{1}\', \'{2}\', \'{3}\', \'{4}\', \'{5}\', NOW(), \'{6}\')";
            string exec = string.Format(sql, run_contex.instance()._curFormula,
                sn,
                sn,
                run_contex.instance()._curBoxsn,
                run_contex.instance()._curProductNums.ToString(),
                run_contex.instance()._curWorker,
                run_contex.instance()._allProductNums.ToString());
            MySqlCommand cmd = new MySqlCommand(exec, _sql_conn);
            try {
                cmd.ExecuteNonQuery();
                r = true;
            } catch (Exception e) {
                --run_contex.instance()._curProductNums;
                System.Threading.Thread.Sleep(500);
                mainForm.getMainForm().setProductNum("请检查输入的产品号是否重复!");
                r = false;
                //
                mainForm.getMainForm().logRepeatTime("重复的产品号:", sn);
                mainForm.getMainForm().PlayFileAudio("Repeat.wav");
                string status = System.Environment.CurrentDirectory + "\\status";
                if (File.ReadAllLines(status)[0].Trim() == "-1") {
                    mainForm.getMainForm().setRepeatWarnDlg();
                }
            }
            return r;
        }
        //在接收到产品扫描器时调用
        public bool onProductScanner(string sn) {
            //return insert2Snbox(sn) && updateBoxset(run_contex.instance()._curFormula);
            return insert2Snbox(sn);
        }
        private void disconnect_db() {
            _sql_conn.Close();
        }
        public void connectdb_and_init() {
            _sql_conn = new MySqlConnection(run_contex.instance()._env.DbConn);
            try {
                _sql_conn.Open();
            } catch (MySqlException e) {
                MessageBox.Show(e.Message);
            }
        }
        public workflow() {
        }
        ~workflow() {
            disconnect_db();
        }
    }
}
