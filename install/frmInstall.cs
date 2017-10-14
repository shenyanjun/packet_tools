using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.ServiceProcess;
namespace install {
    public partial class frmInstall : Form {
        
        public frmInstall() {
            InitializeComponent();
        }
        private bool assertSC(string sc_name) {
            Regex r = new Regex("MariaDB");
            Match m = r.Match(sc_name, 0);
            if (m.Success) {
                return true;
            }
            return false;
        }

        private void startMariaDB() {
            string localPath = Application.StartupPath;
            string mysqlPath = localPath + @"\MariaDB\bin\mysqld.exe";
            string iniPath = localPath + @"\MariaDB\my.ini";
            string param = mysqlPath + "--defaults-file= " + iniPath + " MariaDB";
            ServiceController[] scs = ServiceController.GetServices();
            foreach (ServiceController sc in scs) {
                if (assertSC(sc.ServiceName)) {
                    if (sc.Status == ServiceControllerStatus.Stopped ||
                        sc.Status == ServiceControllerStatus.Paused) {
                        sc.Start(new string[] { param });
                        return;
                    }
                }
            }
            ServiceController sc_db = new ServiceController();
            sc_db.Start(new string[] { param });
        }

        private bool haveMariaDbPacket() {
            string localPath = Application.StartupPath;
            string mysqlPath = localPath + @"\MariaDB\bin\mysqld.exe";
            if (System.IO.File.Exists(mysqlPath)) return true;
            return false;
        }

        private void btnInstall_Click(object sender, EventArgs e) {
            if (haveMariaDbPacket()) {
                startMariaDB();
                MessageBox.Show("启动数据库成功");
            }
        }
    }
}