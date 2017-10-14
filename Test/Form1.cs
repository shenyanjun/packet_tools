using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace Test {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private string box_sn = "";
        private string product_sn = "";

        private bool checkParam() {
            return textBox4.Text != "" && textBox3.Text != "" && textBox5.Text != "" && textBox1.Text != "" && textBox2.Text != "";   
        }
        private void work_proc(object obj) {
            long s, e;
            s = ((long[])obj)[0];
            e = ((long[])obj)[1];
            for (long i = s; i <= e; i++) {
                product_sn = i.ToString() + "\r";
                if (serialPort2.IsOpen)
                {
                    for (int j = 0; j < product_sn.Length; j++)
                    {
                        serialPort2.Write(product_sn[j].ToString());
                        Thread.Sleep(j % 5);
                    }
                    //serialPort2.Write(product_sn);
                }
                else
                    break;
                //Thread.Sleep(50);
            }
        }
        private Thread work_thread;
        private bool work_flag = true;
        private void button1_Click(object sender, EventArgs e) {
            work_flag = false;
            if (checkParam()) {
                if (serialPort1.IsOpen) {
                    serialPort1.Close();
                    serialPort1.PortName = textBox4.Text.Trim();
                    serialPort1.Open();
                } else {
                    serialPort1.PortName = textBox4.Text.Trim();
                    serialPort1.Open();
                }
                if (serialPort2.IsOpen) {
                    serialPort2.Close();
                    serialPort2.PortName = textBox3.Text.Trim();
                    serialPort2.Open();
                } else {
                    serialPort2.PortName = textBox3.Text.Trim();
                    serialPort2.Open();
                }
                box_sn = textBox5.Text.Trim() + "\r";
                work_flag = true;
                work_thread = new Thread(new ParameterizedThreadStart(work_proc), 0);
                long s = long.Parse(textBox1.Text.Trim());
                long l = long.Parse(textBox2.Text.Trim());
                serialPort1.Write(box_sn);
                work_thread.Start(new long[] { s, l});
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            if (checkParam()) {
                if (serialPort2.IsOpen) {
                    serialPort2.Close();
                    serialPort2.PortName = textBox3.Text.Trim();
                    serialPort2.Open();
                } else {
                    serialPort2.PortName = textBox3.Text.Trim();
                    serialPort2.Open();
                }
                string sn = textBox1.Text.Trim() + "\r";
                serialPort2.Write(sn);
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            if (checkParam()) {
                if (serialPort1.IsOpen) {
                    serialPort1.Close();
                    serialPort1.PortName = textBox4.Text.Trim();
                    serialPort1.Open();
                } else {
                    serialPort1.PortName = textBox4.Text.Trim();
                    serialPort1.Open();
                }
                box_sn = textBox5.Text.Trim() + "\r";
                serialPort1.Write(box_sn);
            }
        }
    }
}