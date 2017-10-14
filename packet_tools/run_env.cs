using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
namespace packet_tools
{
    class env
    {
        private ini_cls _init;
        //扫描箱子的枪
        private string _box_scan_handle_name;
        //扫描产品的枪
        private string _product_scan_handle_name;
        //先前的生产配方
        private string _prev_pruduct;
        //log admin
        private bool _login_admin = false;

        private string _material_num  = "";

        public string material_num {
            set {
                _material_num = value;
                _init.IniWriteValue("log", "material_num", value);
            }
            get {
                return _material_num;
            }
        }

        public bool login_private
        {
            set { _login_admin = value; }
            get { return _login_admin; }
        }
        //connect db string
        private string _db_conn = "";
        public env()
        {
            _init = new ini_cls(Application.StartupPath + @"\config.ini");
            _db_conn = _init.IniReadValue("server", "connection");
            _prev_pruduct = _init.IniReadValue("log", "prev_product");
            _box_scan_handle_name = _init.IniReadValue("log", "box");
            _product_scan_handle_name = _init.IniReadValue("log", "product");
            _material_num = _init.IniReadValue("log", "material_num");
        }
        public string ScanBoxHandle
        {
            set
            {
                _box_scan_handle_name = value;
                _init.IniWriteValue("log", "box", _box_scan_handle_name);
            }
            get
            {
                
                return _box_scan_handle_name;
            }
        }
        public string DbConn {
            set {
                _db_conn = value;
                _init.IniWriteValue("server", "connection", _db_conn);
            }
            get {
                
                return _db_conn;
            }
        }
        public string ScanProductHandle
        {
            set
            {
                _product_scan_handle_name = value;
                _init.IniWriteValue("log", "product", _product_scan_handle_name);
            }
            get
            {
                return _product_scan_handle_name;
            }
        }
        public string PrevProduct
        {
            set
            {
                _prev_pruduct = value;
                _init.IniWriteValue("log", "prev_product", _prev_pruduct);
            }
            get
            {
                
                return _prev_pruduct;
            }
        }
    }
    public class ini_cls
    {
        public string inipath;
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        /// <summary> 
        /// 构造方法 
        /// </summary> 
        /// <param name="INIPath">文件路径</param> 
        public ini_cls(string INIPath)
        {
            inipath = INIPath;
        }
        /// <summary> 
        /// 写入INI文件 
        /// </summary> 
        /// <param name="Section">项目名称(如 [TypeName] )</param> 
        /// <param name="Key">键</param> 
        /// <param name="Value">值</param> 
        public void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.inipath);
        }
        /// <summary> 
        /// 读出INI文件 
        /// </summary> 
        /// <param name="Section">项目名称(如 [TypeName] )</param>
        /// <param name="Key">键</param> 
        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(500);
            int i = GetPrivateProfileString(Section, Key, "", temp, 500, this.inipath);
            return temp.ToString();
        }
        /// <summary> 
        /// 验证文件是否存在 
        /// </summary> 
        /// <returns>布尔值</returns> 
        public bool ExistINIFile()
        {
            return File.Exists(inipath);
        }
    }
}
