using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Text;
namespace packet_tools
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            if (System.Diagnostics.Process.GetProcessesByName(
            System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length > 1) {
                MessageBox.Show("应用程序已经启动过了!");
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mainForm());
        }
    }
}
