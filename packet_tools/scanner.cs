using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Management;
using System.ComponentModel;
using System.Timers;
using System.Text.RegularExpressions;
using System.Threading;

namespace packet_tools
{
    public class scanner
    {
        private enum scanner_status
        {
            //读取状态
            status_reading = 0,
            //等待下次一次读取
            status_waitnext,
        }

        private SerialPort _port;

        private int _scanner_handle;
       
        private string port_name = "";

        private Queue<byte> _recv_data_queue = new Queue<byte>(100);

        private bool _sc_recv_flag = true;

        public scanner(string p, int h)
        {
            port_name = p;
            _scanner_handle = h;
        }

        //串口接收线程函数
        private void recvSCDataProc()
        {
            //开始标志
            bool start_recv_flag = false;
            long timeout_readbyte = 0;

            bool start_sleep = false;
            long timeout_sleep = 0;

            while (_sc_recv_flag)
            {
                try
                {
                    //先读取进来
                    byte data = (byte)_port.ReadByte();

                    if (start_sleep)
                    {
                        if ((DateTime.Now.Ticks - timeout_sleep) / 10000.0 > 200.0)
                        {
                            start_sleep = false;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    //
                    if ( !start_recv_flag )
                    {
                        start_recv_flag = true;
                        timeout_readbyte = DateTime.Now.Ticks;
                        if (data == 0x0d)
                        {
                            continue;
                        }
                        else
                        {
                            _recv_data_queue.Enqueue(data);
                            continue;
                        }
                    }

                    //单个字节间隔超过100ms
                    if (start_recv_flag)
                    {
                        if ((DateTime.Now.Ticks - timeout_readbyte) / 10000.0 > 50.0)
                        {
                            _recv_data_queue.Clear();
                            timeout_readbyte = DateTime.Now.Ticks;
                            continue;
                        }
                    }
                    
                    if (data != 0x0d)
                    {
                        _recv_data_queue.Enqueue(data);
                    }
                    else
                    {
                        start_recv_flag = false;//重新开始
                        if (_recv_data_queue.Count == 0) continue;
                        else
                        {
                            string sn = Encoding.ASCII.GetString(_recv_data_queue.ToArray());
                            Console.WriteLine(sn);
                            scan_handle_data dat = new scan_handle_data();
                            dat.handle = _scanner_handle;
                            dat.sn_data = sn;
                            //放入数据到队列
                            run_contex.instance()._sn_scan_queue.push_queue(dat);
                            _recv_data_queue.Clear();
                            //开始休眠
                            start_sleep = true;
                            timeout_sleep = DateTime.Now.Ticks;
                        }
                    }
                }
                catch (Exception e)
                {
                    break;
                }
            }
        }

        public bool openScanner()
        {
            if (_port != null && _port.IsOpen)
            {
                _port.Close();
                _port.Dispose();
            }
            _port = new SerialPort(port_name);
            _port.BaudRate = 9600;
            _port.Parity = Parity.None;
            _port.ReceivedBytesThreshold = 1;
            _port.StopBits = StopBits.One;
            _port.DataBits = 8;
            //_port.ReadTimeout = 1000;
            try
            {
                _port.Open();
                Thread recvSCThread = new Thread(new ThreadStart(recvSCDataProc));
                recvSCThread.Start();
            }
            catch
            {
                return false;
            }
            return true;
        }
        //s = 0 : box handle
        //s = 1 : product handle
        public void closeScanner()
        {
            if (_port!=null && _port.IsOpen)
            {
                _sc_recv_flag = false;
                Thread.Sleep(1000);
                _port.Close();
            }
        }
    }
    /// <summary>
    /// 用来枚举串口扫描器
    /// </summary>
    public static class scannerUtile
    {
        /// <summary>
        /// 枚举win32 api
        /// </summary>
        public enum HardwareEnum
        {
            // 硬件
            Win32_Processor, // CPU 处理器
            Win32_PhysicalMemory, // 物理内存条
            Win32_Keyboard, // 键盘
            Win32_PointingDevice, // 点输入设备，包括鼠标.
            Win32_FloppyDrive, // 软盘驱动器
            Win32_DiskDrive, // 硬盘驱动器
            Win32_CDROMDrive, // 光盘驱动器
            Win32_BaseBoard, // 主板
            Win32_BIOS, // BIOS 芯片
            Win32_ParallelPort, // 并口
            Win32_SerialPort, // 串口
            Win32_SerialPortConfiguration, // 串口配置
            Win32_SoundDevice, // 多媒体设置，一般指声卡。
            Win32_SystemSlot, // 主板插槽 (ISA & PCI & AGP)
            Win32_USBController, // USB 控制器
            Win32_NetworkAdapter, // 网络适配器
            Win32_NetworkAdapterConfiguration, // 网络适配器设置
            Win32_Printer, // 打印机
            Win32_PrinterConfiguration, // 打印机设置
            Win32_PrintJob, // 打印机任务
            Win32_TCPIPPrinterPort, // 打印机端口
            Win32_POTSModem, // MODEM
            Win32_POTSModemToSerialPort, // MODEM 端口
            Win32_DesktopMonitor, // 显示器
            Win32_DisplayConfiguration, // 显卡
            Win32_DisplayControllerConfiguration, // 显卡设置
            Win32_VideoController, // 显卡细节。
            Win32_VideoSettings, // 显卡支持的显示模式。
            // 操作系统
            Win32_TimeZone, // 时区
            Win32_SystemDriver, // 驱动程序
            Win32_DiskPartition, // 磁盘分区
            Win32_LogicalDisk, // 逻辑磁盘
            Win32_LogicalDiskToPartition, // 逻辑磁盘所在分区及始末位置。
            Win32_LogicalMemoryConfiguration, // 逻辑内存配置
            Win32_PageFile, // 系统页文件信息
            Win32_PageFileSetting, // 页文件设置
            Win32_BootConfiguration, // 系统启动配置
            Win32_ComputerSystem, // 计算机信息简要
            Win32_OperatingSystem, // 操作系统信息
            Win32_StartupCommand, // 系统自动启动程序
            Win32_Service, // 系统安装的服务
            Win32_Group, // 系统管理组
            Win32_GroupUser, // 系统组帐号
            Win32_UserAccount, // 用户帐号
            Win32_Process, // 系统进程
            Win32_Thread, // 系统线程
            Win32_Share, // 共享
            Win32_NetworkClient, // 已安装的网络客户端
            Win32_NetworkProtocol, // 已安装的网络协议
            Win32_PnPEntity,//all device
        }
        /// <summary>
        /// 设备描述
        /// </summary>
        public struct dev_detail
        {
            public string dev_name;//设备名称
            public string dev_discript;//设备描述
            public override string ToString()
            {
                return dev_discript;
            }
        }
        public static string GetSerialPortName(string detail)
        {
            detail = detail.ToUpper();
            Regex reg = new Regex(@"COM\d+");
            Match mc = reg.Match(detail, 0);
            if (mc.Success) {
                return detail.Substring(mc.Index, mc.Length);
            }
            return "";
        }
        /// <summary>
        /// WMI取硬件信息
        /// </summary>
        /// <param name="hardType"></param>
        /// <param name="propKey"></param>
        /// <returns></returns>
        public static  dev_detail[] MulGetHardwareInfo(HardwareEnum hardType)
        {
            List<dev_detail> dev_list = new List<dev_detail>();
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + hardType))
                {
                    ManagementObjectCollection hardInfos = searcher.Get();
                    foreach (ManagementBaseObject hardInfo in hardInfos)
                    {
                        if (hardInfo.Properties["Name"].Value.ToString().Contains("COM"))
                        {
                            dev_detail dev = new dev_detail();
                            dev.dev_name = GetSerialPortName(hardInfo.Properties["Name"].Value.ToString());
                            dev.dev_discript = hardInfo.Properties["Name"].Value.ToString();
                            dev_list.Add(dev);
                        }
                    }
                    searcher.Dispose();
                }
                return dev_list.ToArray();
            }
            catch
            {
                return null;
            }
            finally { dev_list = null; }
        }
    }
}
