using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
namespace packet_tools {
    class run_contex {
        //料号检查
        public bool material_ok = false;
        //弹出对话框
        public bool diaglog_warn_flag = false;
        //是否开启初始化
        private bool init_run_ctx_flag = false;
        //运行需要的环境变量
        public env _env = new env();
        //当前箱号
        public string _curBoxsn = "";
        //箱子扫描枪句柄
        private scanner _box_handle = null;
        //产品扫描枪
        private scanner _product_handle = null;
        //产品号规则
        public string _productSnFormula = "";
        //装箱号规则
        public string _boxSnFormula = "";
        //当前产品数目
        public int _curProductNums = 0;
        //所有产品数目
        public int _allProductNums = 0;
        //剩余产品数目
        public int _leaveProductNums = 0;
        //当前配方
        public string _curFormula = "";
        //当前员工号
        public string _curWorker = "";
        //接收从扫描枪来的数据,相关的线程
        private Thread _logic_work = null;
        private bool _logic_flags = true;
        //满了--指示已经满了
        public bool _isFull = true;
        //扫描数据队列
        public queue _sn_scan_queue = new queue();
        //处理扫描内容的逻辑线程函数
        private workflow _scan_work_logic = new workflow();
        private void _procedure_logic(object p) {
            while (_logic_flags) {
                scan_handle_data d = _sn_scan_queue.pop_queue();
                if (d != null) {
                    //产品号
                    if (d.handle == 0) {
                        //修改数据
                        /*
                        if (mainForm.getMainForm()._changeValue) {
                            mainForm.getMainForm()._changeDlg.changeProductSN(d.sn_data);
                            continue;
                        }
                         * */
                        //第一次输入产品,这时候把是否为满的状态置为非满状态
                        if (_allProductNums > 0 &&
                            (_allProductNums == _leaveProductNums) &&
                            _isFull &&
                            d.sn_data != "" && run_contex.instance()._curBoxsn != "") {
                            _isFull = false;
                        }
                        if (_isFull) {
                            if (run_contex.instance()._curBoxsn == "")
                                mainForm.getMainForm().setProductNum("请扫描箱号!");
                        }
                        //没满开始扫描
                        if (_isFull == false) {
                            bool checkRes = false;
                            checkRes = checkSN(d.sn_data, _productSnFormula);
                            if (!checkRes) {
                                mainForm.getMainForm().setProductNum("输入的产品号不对!");
                                //16/5/30 产品号重复也要提示
                                mainForm.getMainForm().PlayFileAudio("error.wav");
                                string snstatus = System.Environment.CurrentDirectory + "\\snstatus";
                                if (File.ReadAllLines(snstatus)[0].Trim() == "-1") {
                                    mainForm.getMainForm().setRepeatWarnSNDlg();
                                }
                            }
                            if (!_isFull && _curFormula != ""
                               && _curBoxsn != "" && checkRes) {
                                mainForm.getMainForm().setProductNum(d.sn_data);
                                //
                                if (_scan_work_logic.onProductScanner(d.sn_data)) {
                                    _leaveProductNums = _allProductNums - _curProductNums;
                                    mainForm.getMainForm().setLeaveProductNum(_leaveProductNums.ToString());
                                    mainForm.getMainForm().setCurProductNum(_curProductNums.ToString());
                                    mainForm.getMainForm().setAllProductNum(_allProductNums.ToString());
                                    mainForm.getMainForm().setInsertRowData(d.sn_data);//插入数据
                                    mainForm.getMainForm().moveListTolast();//滚动到最后
                                    if (_curProductNums >= _allProductNums) {
                                        //满了
                                        _isFull = true;
                                        run_contex.instance().material_ok = false;
                                        _curProductNums = 0;
                                        _leaveProductNums = _allProductNums;
                                        _curBoxsn = "";//箱号为空
                                        //fix bug 
                                        _scan_work_logic.updateBoxset(run_contex.instance()._curFormula);
                                        //fix bug
                                        //打包完毕将箱号清零
                                        run_contex.instance()._curBoxsn = "";
                                        mainForm.getMainForm().setBoxNum("本箱产品已经打包完毕!");
                                        //string audiofile_scanok = System.Environment.CurrentDirectory + "\\提示音.wav";
                                        mainForm.getMainForm().PlayFileAudio();
                                    } else {
                                        string audiofile_scanok = System.Environment.CurrentDirectory + "\\叮.wav";
                                        System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
                                        sp.SoundLocation = audiofile_scanok;
                                        sp.PlaySync();
                                    }
                                }
                            } else if (_isFull) {
                                mainForm.getMainForm().setProductNum("请扫描箱号!");
                            }
                        }
                    }
                    //箱号
                    if (d.handle == 1) {
                        //--------------------------------------------------
                        //这里有bug
                        /*
                        if (mainForm.getMainForm()._changeValue) {
                            //更改箱号
                            mainForm.getMainForm()._changeDlg.changeBoxSN(d.sn_data);
                            run_contex.instance()._curBoxsn = d.sn_data;//更改box sn
                            continue;
                        }
                         * */
                        //新加入的料号检查
                        if (_isFull && run_contex.instance()._env.material_num != "0" && 
                            !run_contex.instance().material_ok) {
                            if (d.sn_data.Trim() != run_contex.instance()._env.material_num) {
                                System.Windows.Forms.MessageBox.Show("请先用箱号扫描枪扫入料号!");
                            } else {
                                run_contex.instance().material_ok = true;
                                mainForm.getMainForm().updateInfo("提示信息:扫描料号成功!");
                            }
                            return;
                        }
                        mainForm.getMainForm().updateInfo("提示信息:");
                        //---------------------------------------------------
                        //满了，并且检查到箱号符合规则,并且配方有效
                        bool checkres = checkSN(d.sn_data, _boxSnFormula);
                        if (_isFull && checkres && _curFormula != "") {
                            //更新box_set属性
                            if (!_scan_work_logic.onPBoxScanner(d.sn_data)) {
                                System.Threading.Thread.Sleep(500);
                                run_contex.instance()._curBoxsn = "";//清掉箱号
                                mainForm.getMainForm().setBoxNum("请不要输入重复的箱号!");
                                //
                                /*
                                mainForm.getMainForm().logRepeatTime("重复的箱号:", d.sn_data);
                                mainForm.getMainForm().PlayFileAudio("Repeat.wav");
                                string status = System.Environment.CurrentDirectory + "\\status";
                                if (File.ReadAllLines(status)[0].Trim() == "-1") {
                                    mainForm.getMainForm().setRepeatWarnDlg();
                                }
                                 * */
                                continue;
                            }
                            mainForm.getMainForm().setBoxNum(d.sn_data);
                            //重新开始计数
                            if (_curProductNums == 0) {
                                //不重复则返回true
                                if (_scan_work_logic.onPBoxScanner(d.sn_data)) {
                                    //这里是一个bug会造成输入连续第二遍箱号输入不进去的情况,所以必须是触发了扫描箱号才能设置
                                    //_isFull = false;
                                    run_contex.instance()._leaveProductNums = run_contex.instance()._allProductNums;//触发设置剩余箱数目,因为要用到
                                    mainForm.getMainForm().setAllProductNum(_allProductNums.ToString());
                                    mainForm.getMainForm().setLeaveProductNum(_allProductNums.ToString());
                                    mainForm.getMainForm().setCurProductNum(_curProductNums.ToString());
                                    mainForm.getMainForm().setProductNum("");
                                    //mainForm.getMainForm().setBoxNum("");
                                } else {
                                    System.Threading.Thread.Sleep(500);
                                    mainForm.getMainForm().setBoxNum("请不要输入重复的箱号!");
                                    run_contex.instance()._curBoxsn = "";//清掉箱号
                                    _isFull = true;
                                    //
                                    /*
                                    mainForm.getMainForm().logRepeatTime("重复的箱号:", d.sn_data);
                                    mainForm.getMainForm().PlayFileAudio("Repeat.wav");
                                    string status = System.Environment.CurrentDirectory + "\\status";
                                    if (File.ReadAllLines(status)[0].Trim() == "-1") {
                                        mainForm.getMainForm().setRepeatWarnDlg();
                                    }
                                     * */
                                }
                            }
                        } else if (!checkres) {
                                mainForm.getMainForm().setBoxNum("请检查输入的箱号是否符合规则!");
                        }
                    }
                } else {
                    Thread.Sleep(100);
                }
            }
        }
        public void clearRunStatus() {
            //产品号规则
            _productSnFormula = "";
            //装箱号规则
            _boxSnFormula = "";
            //当前产品数目
            _curProductNums = 0;
            //所有产品数目
            _allProductNums = 0;
            //剩余产品数目
            _leaveProductNums = 0;
            //箱号
            _curBoxsn = "";
            //第几箱
            _curProductNums = 0;
            //当前配方
            _curFormula = "";
            //当前员工号
            _curWorker = "";
            _isFull = true;
        }
        //检查产品序列号是否符合规定
        private bool checkSN(string sn, string fmt) {
            //修复一个bug,在创立配方时候，没有给配方过滤，这时候进来，为空
            if (fmt == "") {
                System.Windows.Forms.MessageBox.Show("检查到配方为空,请配置产品和箱号配方!");
                return false;
            }
            bool b = false;
            if (fmt == "") {
                b = true;
                return b;
            }
            //获取关键字起始位置
            int i = 0;
            if (fmt.Length != sn.Length)
                return false;
            while (i < fmt.Length) {
                if (fmt[i] == '$') {
                    sn = sn.Remove(i, 1);
                    fmt = fmt.Remove(i, 1);
                    continue;
                }
                i++;
            }
            if (sn == fmt) {
                b = true;
            }
            return b;
        }
        //运行实例变量
        public static run_contex _inst = null;
        //创建一个运行实例
        public static run_contex instance() {
            if (_inst == null) {
                _inst = new run_contex();
                _inst.init_db_conn();
            }
            return _inst;
        }
        public void init_db_conn() {
            _scan_work_logic.connectdb_and_init();
        }
        public run_contex() {
            
        }
        //创建运行环境
        public bool setup_runcontex() {
            if (!init_run_ctx_flag) {
                string box_scan = _env.ScanBoxHandle;
                string pro_scan = _env.ScanProductHandle;
                if (box_scan != null && pro_scan != null && box_scan != "" && pro_scan != "") {
                    _box_handle = new scanner(box_scan, 0);
                    _product_handle = new scanner(pro_scan, 1);
                    try {
                        if (!_box_handle.openScanner() || !_product_handle.openScanner()) {
                            mainForm.getMainForm().setWarnString("扫描枪对应的串口打开失败,请检测!");
                            return false;
                        }
                    } catch {
                        return false;
                    }
                    _logic_flags = false;
                    _logic_work = new Thread(new ParameterizedThreadStart(_procedure_logic));
                    _logic_flags = true;
                    //fix bug
                    //有正常输入数据的时候，选择配置串口通讯，不要破环上一次的数据
                    mainForm.getMainForm().setAllProductNum(run_contex.instance()._allProductNums.ToString());
                    mainForm.getMainForm().setLeaveProductNum(run_contex.instance()._leaveProductNums.ToString());
                    mainForm.getMainForm().setCurProductNum(run_contex.instance()._curProductNums.ToString());
                    //开启线程
                    _logic_work.Start();
                    init_run_ctx_flag = true;
                }
            }
            return true;
        }
        //释放运行环境
        public void exit_runcontex() {
            _logic_flags = false;
            init_run_ctx_flag = false;
            if (_box_handle != null)
                _box_handle.closeScanner();
            if (_product_handle != null)
                _product_handle.closeScanner();
            //这有bug
            /*
            mainForm.getMainForm().setAllProductNum("0");
            mainForm.getMainForm().setLeaveProductNum("0");
            mainForm.getMainForm().setCurProductNum("0");
             * */
        }
    }
}
