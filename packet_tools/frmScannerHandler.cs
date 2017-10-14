using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace packet_tools {
    public partial class frmScannerHandler : Form {
        public frmScannerHandler() {
            InitializeComponent();
            this.DialogResult = System.Windows.Forms.DialogResult.None;
        }
        private void btnFreshScanDevice_Click(object sender, EventArgs e) {
            cmbBoxComList.Items.Clear();
            cmbProductComList.Items.Clear();
            scannerUtile.dev_detail[] devices = scannerUtile.MulGetHardwareInfo(scannerUtile.HardwareEnum.Win32_PnPEntity);
            if (devices != null) {
                for (int i = 0; i < devices.Length; i++) {
                    cmbBoxComList.Items.Add(devices[i]);
                    cmbProductComList.Items.Add(devices[i]);
                }
                cmbBoxComList.SelectedIndex = 0;
                cmbProductComList.SelectedIndex = 0;
            }
        }
        private bool assertSelectDevice() {
            if (cmbBoxComList.SelectedItem == null || cmbProductComList.SelectedItem == null) {
                return false;
            }
            if (cmbBoxComList.Text.Trim() == cmbProductComList.Text.Trim()) {
                return false;
            }
            return true;
        }
        private void saveParam() {
            run_contex.instance()._env.ScanBoxHandle = scannerUtile.GetSerialPortName(cmbBoxComList.Text);
            run_contex.instance()._env.ScanProductHandle = scannerUtile.GetSerialPortName(cmbProductComList.Text);
        }
        private void btnOpen_Click(object sender, EventArgs e) {
            if (assertSelectDevice()) {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                //线退出
                run_contex.instance().exit_runcontex();
                saveParam();
                if (run_contex.instance().setup_runcontex()) {
                    MessageBox.Show("配置扫面枪成功!");
                }
            } else {
                this.DialogResult = System.Windows.Forms.DialogResult.No;
                MessageBox.Show("配置错误，请重新配置扫描枪!");
            }
        }
        private void frmScannerHandler_Load(object sender, EventArgs e) {
            string tmp = run_contex.instance()._env.ScanBoxHandle;
            if (tmp != "") {
                cmbBoxComList.Items.Add(tmp);
                cmbBoxComList.SelectedIndex = 0;
            }
            tmp = "";
            tmp = run_contex.instance()._env.ScanProductHandle;
            if (tmp != "") {
                cmbProductComList.Items.Add(tmp);
                cmbProductComList.SelectedIndex = 0;
            }
        }
    }
}
