using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace packet_tools
{
    public partial class frmUserManager : Form
    {
        private DataTable _admin_table;
        private MySqlDataAdapter _sql_adp;
        private MySqlConnection _sql_conn;
        /// <summary>
        /// 返回所有型号的数据
        /// </summary>
        private void connectdb_and_init()
        {
            string sql = "select * from admin order by persno;";
            _admin_table = new DataTable();
            _sql_conn = new MySqlConnection(run_contex.instance()._env.DbConn);
            _sql_conn.Open();
            _sql_adp = new MySqlDataAdapter(sql, _sql_conn);
            _sql_adp.Fill(_admin_table);
            gridEX1.DataSource = _admin_table;
            gridEX1.MoveLast();
        }
       
        public frmUserManager()
        {
            InitializeComponent();
        }
        private void frmUserManager_Load(object sender, EventArgs e)
        {
            connectdb_and_init();
        }
        private void frmUserManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            _sql_conn.Close();
        }
        //添加员工
        private void menuAdd_Click(object sender, EventArgs e)
        {
            frmAddWorker frm = new frmAddWorker();
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK && frm.AddedWorker!="")
            {
                string _addWorker = frm.AddedWorker;
               string sql = "INSERT INTO admin set  persno = \'{0} \'";
               sql = string.Format(sql, _addWorker);
               try
               {
                   MySqlCommand cmd = new MySqlCommand(sql, _sql_conn);
                   cmd.ExecuteNonQuery();
                   DataRow dr = _admin_table.NewRow();
                   dr["persno"] = _addWorker;
                   _admin_table.Rows.Add(dr);
               }
               catch(Exception ex)
               {
                   MessageBox.Show(ex.Message);
               }
            }
        }
        //删除索引
        private void menuDel_Click(object sender, EventArgs e)
        {
            if (gridEX1.CurrentRow != null)
            {
                string person = (gridEX1.CurrentRow.DataRow as DataRowView).Row["persno"].ToString();
                try
                {
                    string sql = "DELETE FROM admin where persno = \'{0}\'";
                    sql = string.Format(sql, person);
                    MySqlCommand cmd = new MySqlCommand(sql, _sql_conn);
                    cmd.ExecuteNonQuery();
                    gridEX1.CurrentRow.Delete();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
