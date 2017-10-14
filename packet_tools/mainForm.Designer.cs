namespace packet_tools
{
    partial class mainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            Janus.Windows.GridEX.GridEXLayout gridEX1_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.menuLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSelectformula = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSetHandle = new System.Windows.Forms.ToolStripMenuItem();
            this.menuManager = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.page_up = new System.Windows.Forms.ToolStripButton();
            this.page_down = new System.Windows.Forms.ToolStripButton();
            this.tbJumpoffset = new System.Windows.Forms.ToolStripTextBox();
            this.jump_pageoffset = new System.Windows.Forms.ToolStripButton();
            this.chanegValue = new System.Windows.Forms.ToolStripMenuItem();
            this.lbSetValCap = new System.Windows.Forms.Label();
            this.lbCurValCap = new System.Windows.Forms.Label();
            this.lbLeftValCap = new System.Windows.Forms.Label();
            this.lbSetVal = new System.Windows.Forms.Label();
            this.lbCurVal = new System.Windows.Forms.Label();
            this.lbLeftVal = new System.Windows.Forms.Label();
            this.lbSubCap = new System.Windows.Forms.Label();
            this.lbEqualCap = new System.Windows.Forms.Label();
            this.panelValue = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridEX1 = new Janus.Windows.GridEX.GridEX();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lbPacketList = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lbInfo = new System.Windows.Forms.Label();
            this.lbCurPack = new System.Windows.Forms.Label();
            this.lbCurWork = new System.Windows.Forms.Label();
            this.lbWarn = new System.Windows.Forms.Label();
            this.lbCurBoxSerial = new System.Windows.Forms.Label();
            this.lbCurLogin = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbBoxNum = new System.Windows.Forms.Label();
            this.tbBoxNumber = new System.Windows.Forms.TextBox();
            this.lbProductNum = new System.Windows.Forms.Label();
            this.tbProductNum = new System.Windows.Forms.TextBox();
            this.timerFlashTitle = new System.Windows.Forms.Timer(this.components);
            this.mainMenu.SuspendLayout();
            this.panelValue.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).BeginInit();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.BackColor = System.Drawing.SystemColors.Control;
            this.mainMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLogin,
            this.menuLogout,
            this.menuSelectformula,
            this.itemSetHandle,
            this.menuManager,
            this.toolStripSeparator1,
            this.page_up,
            this.page_down,
            this.tbJumpoffset,
            this.jump_pageoffset,
            this.chanegValue});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mainMenu.Size = new System.Drawing.Size(931, 28);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // menuLogin
            // 
            this.menuLogin.Name = "menuLogin";
            this.menuLogin.Size = new System.Drawing.Size(44, 24);
            this.menuLogin.Text = "登入";
            this.menuLogin.Click += new System.EventHandler(this.menuLogin_Click);
            // 
            // menuLogout
            // 
            this.menuLogout.Name = "menuLogout";
            this.menuLogout.Size = new System.Drawing.Size(44, 24);
            this.menuLogout.Text = "登出";
            this.menuLogout.Click += new System.EventHandler(this.menuLogout_Click);
            // 
            // menuSelectformula
            // 
            this.menuSelectformula.Name = "menuSelectformula";
            this.menuSelectformula.Size = new System.Drawing.Size(68, 24);
            this.menuSelectformula.Text = "选择产品";
            this.menuSelectformula.Click += new System.EventHandler(this.itemSelectformula_Click);
            // 
            // itemSetHandle
            // 
            this.itemSetHandle.Name = "itemSetHandle";
            this.itemSetHandle.Size = new System.Drawing.Size(68, 24);
            this.itemSetHandle.Text = "通讯配置";
            this.itemSetHandle.Click += new System.EventHandler(this.itemSetHandle_Click);
            // 
            // menuManager
            // 
            this.menuManager.Name = "menuManager";
            this.menuManager.Size = new System.Drawing.Size(68, 24);
            this.menuManager.Text = "人员管理";
            this.menuManager.Click += new System.EventHandler(this.menuManager_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 24);
            // 
            // page_up
            // 
            this.page_up.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.page_up.Image = ((System.Drawing.Image)(resources.GetObject("page_up.Image")));
            this.page_up.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.page_up.Name = "page_up";
            this.page_up.Size = new System.Drawing.Size(36, 21);
            this.page_up.Text = "上页";
            this.page_up.Click += new System.EventHandler(this.page_up_Click);
            // 
            // page_down
            // 
            this.page_down.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.page_down.Image = ((System.Drawing.Image)(resources.GetObject("page_down.Image")));
            this.page_down.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.page_down.Name = "page_down";
            this.page_down.Size = new System.Drawing.Size(36, 21);
            this.page_down.Text = "下页";
            this.page_down.Click += new System.EventHandler(this.page_down_Click);
            // 
            // tbJumpoffset
            // 
            this.tbJumpoffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbJumpoffset.Font = new System.Drawing.Font("宋体", 9F);
            this.tbJumpoffset.Name = "tbJumpoffset";
            this.tbJumpoffset.Size = new System.Drawing.Size(200, 24);
            this.tbJumpoffset.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbJumpoffset.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbJumpoffset_KeyPress);
            // 
            // jump_pageoffset
            // 
            this.jump_pageoffset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.jump_pageoffset.Image = ((System.Drawing.Image)(resources.GetObject("jump_pageoffset.Image")));
            this.jump_pageoffset.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.jump_pageoffset.Name = "jump_pageoffset";
            this.jump_pageoffset.Size = new System.Drawing.Size(36, 21);
            this.jump_pageoffset.Text = "查找";
            this.jump_pageoffset.Click += new System.EventHandler(this.jump_pageoffset_Click);
            // 
            // chanegValue
            // 
            this.chanegValue.Name = "chanegValue";
            this.chanegValue.Size = new System.Drawing.Size(44, 24);
            this.chanegValue.Text = "修改";
            this.chanegValue.Click += new System.EventHandler(this.chanegValue_Click);
            // 
            // lbSetValCap
            // 
            this.lbSetValCap.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSetValCap.Location = new System.Drawing.Point(3, 0);
            this.lbSetValCap.Name = "lbSetValCap";
            this.lbSetValCap.Size = new System.Drawing.Size(67, 26);
            this.lbSetValCap.TabIndex = 1;
            this.lbSetValCap.Text = "设定值:";
            this.lbSetValCap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCurValCap
            // 
            this.lbCurValCap.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.lbCurValCap.Location = new System.Drawing.Point(326, 0);
            this.lbCurValCap.Name = "lbCurValCap";
            this.lbCurValCap.Size = new System.Drawing.Size(81, 23);
            this.lbCurValCap.TabIndex = 2;
            this.lbCurValCap.Text = "实际值:";
            this.lbCurValCap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLeftValCap
            // 
            this.lbLeftValCap.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.lbLeftValCap.Location = new System.Drawing.Point(649, 0);
            this.lbLeftValCap.Name = "lbLeftValCap";
            this.lbLeftValCap.Size = new System.Drawing.Size(50, 23);
            this.lbLeftValCap.TabIndex = 3;
            this.lbLeftValCap.Text = "差值:";
            this.lbLeftValCap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSetVal
            // 
            this.lbSetVal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSetVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbSetVal.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSetVal.ForeColor = System.Drawing.Color.Green;
            this.lbSetVal.Location = new System.Drawing.Point(3, 30);
            this.lbSetVal.Name = "lbSetVal";
            this.lbSetVal.Size = new System.Drawing.Size(271, 93);
            this.lbSetVal.TabIndex = 4;
            this.lbSetVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCurVal
            // 
            this.lbCurVal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCurVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbCurVal.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Bold);
            this.lbCurVal.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbCurVal.Location = new System.Drawing.Point(326, 30);
            this.lbCurVal.Name = "lbCurVal";
            this.lbCurVal.Size = new System.Drawing.Size(271, 93);
            this.lbCurVal.TabIndex = 5;
            this.lbCurVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLeftVal
            // 
            this.lbLeftVal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLeftVal.BackColor = System.Drawing.Color.Azure;
            this.lbLeftVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbLeftVal.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Bold);
            this.lbLeftVal.ForeColor = System.Drawing.Color.Red;
            this.lbLeftVal.Location = new System.Drawing.Point(649, 30);
            this.lbLeftVal.Name = "lbLeftVal";
            this.lbLeftVal.Size = new System.Drawing.Size(273, 93);
            this.lbLeftVal.TabIndex = 6;
            this.lbLeftVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSubCap
            // 
            this.lbSubCap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSubCap.Font = new System.Drawing.Font("华文琥珀", 18F, System.Drawing.FontStyle.Bold);
            this.lbSubCap.Location = new System.Drawing.Point(280, 30);
            this.lbSubCap.Name = "lbSubCap";
            this.lbSubCap.Size = new System.Drawing.Size(40, 93);
            this.lbSubCap.TabIndex = 7;
            this.lbSubCap.Text = "-";
            this.lbSubCap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbEqualCap
            // 
            this.lbEqualCap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbEqualCap.Font = new System.Drawing.Font("华文琥珀", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbEqualCap.Location = new System.Drawing.Point(603, 30);
            this.lbEqualCap.Name = "lbEqualCap";
            this.lbEqualCap.Size = new System.Drawing.Size(40, 93);
            this.lbEqualCap.TabIndex = 8;
            this.lbEqualCap.Text = "=";
            this.lbEqualCap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelValue
            // 
            this.panelValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelValue.Controls.Add(this.tableLayoutPanel1);
            this.panelValue.Location = new System.Drawing.Point(0, 101);
            this.panelValue.Name = "panelValue";
            this.panelValue.Size = new System.Drawing.Size(931, 129);
            this.panelValue.TabIndex = 9;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.lbSetValCap, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbLeftVal, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbEqualCap, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbLeftValCap, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbSetVal, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbCurVal, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbCurValCap, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbSubCap, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.84848F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.15152F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(925, 123);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.gridEX1);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Location = new System.Drawing.Point(1, 233);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(928, 297);
            this.panel1.TabIndex = 10;
            // 
            // gridEX1
            // 
            this.gridEX1.AllowColumnDrag = false;
            this.gridEX1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridEX1.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat;
            gridEX1_DesignTimeLayout.LayoutString = resources.GetString("gridEX1_DesignTimeLayout.LayoutString");
            this.gridEX1.DesignTimeLayout = gridEX1_DesignTimeLayout;
            this.gridEX1.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.gridEX1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridEX1.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gridEX1.GroupByBoxVisible = false;
            this.gridEX1.Location = new System.Drawing.Point(2, 41);
            this.gridEX1.Name = "gridEX1";
            this.gridEX1.RepeatHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gridEX1.RowFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.Flat;
            this.gridEX1.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridEX1.Size = new System.Drawing.Size(927, 256);
            this.gridEX1.TabIndex = 31;
            this.gridEX1.VisualStyle = Janus.Windows.GridEX.VisualStyle.VS2005;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.tableLayoutPanel3);
            this.panel4.Location = new System.Drawing.Point(1, 1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(926, 37);
            this.panel4.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.70274F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.67127F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.06294F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.02046F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.23018F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.lbPacketList, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 1);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(920, 36);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // lbPacketList
            // 
            this.lbPacketList.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbPacketList.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.lbPacketList.Location = new System.Drawing.Point(3, 7);
            this.lbPacketList.Name = "lbPacketList";
            this.lbPacketList.Size = new System.Drawing.Size(260, 22);
            this.lbPacketList.TabIndex = 0;
            this.lbPacketList.Text = "操作记录:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tableLayoutPanel4);
            this.panel2.Controls.Add(this.lbWarn);
            this.panel2.Controls.Add(this.lbCurBoxSerial);
            this.panel2.Controls.Add(this.lbCurLogin);
            this.panel2.Location = new System.Drawing.Point(2, 531);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(928, 25);
            this.panel2.TabIndex = 11;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Controls.Add(this.lbInfo, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.lbCurPack, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.lbCurWork, 2, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(2, 1);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(925, 23);
            this.tableLayoutPanel4.TabIndex = 6;
            // 
            // lbInfo
            // 
            this.lbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbInfo.AutoSize = true;
            this.lbInfo.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbInfo.Location = new System.Drawing.Point(3, 2);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(302, 19);
            this.lbInfo.TabIndex = 5;
            this.lbInfo.Text = "提示信息: ";
            this.lbInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCurPack
            // 
            this.lbCurPack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCurPack.AutoSize = true;
            this.lbCurPack.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCurPack.Location = new System.Drawing.Point(311, 1);
            this.lbCurPack.Name = "lbCurPack";
            this.lbCurPack.Size = new System.Drawing.Size(302, 20);
            this.lbCurPack.TabIndex = 2;
            this.lbCurPack.Text = "打包方案: ";
            this.lbCurPack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCurWork
            // 
            this.lbCurWork.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCurWork.AutoSize = true;
            this.lbCurWork.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCurWork.Location = new System.Drawing.Point(619, 1);
            this.lbCurWork.Name = "lbCurWork";
            this.lbCurWork.Size = new System.Drawing.Size(303, 20);
            this.lbCurWork.TabIndex = 0;
            this.lbCurWork.Text = "工号:";
            this.lbCurWork.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbWarn
            // 
            this.lbWarn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbWarn.AutoSize = true;
            this.lbWarn.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbWarn.ForeColor = System.Drawing.Color.OrangeRed;
            this.lbWarn.Location = new System.Drawing.Point(76, 6);
            this.lbWarn.Name = "lbWarn";
            this.lbWarn.Size = new System.Drawing.Size(0, 12);
            this.lbWarn.TabIndex = 4;
            // 
            // lbCurBoxSerial
            // 
            this.lbCurBoxSerial.AutoSize = true;
            this.lbCurBoxSerial.Location = new System.Drawing.Point(496, 6);
            this.lbCurBoxSerial.Name = "lbCurBoxSerial";
            this.lbCurBoxSerial.Size = new System.Drawing.Size(0, 12);
            this.lbCurBoxSerial.TabIndex = 3;
            this.lbCurBoxSerial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCurLogin
            // 
            this.lbCurLogin.AutoSize = true;
            this.lbCurLogin.Location = new System.Drawing.Point(797, 6);
            this.lbCurLogin.Name = "lbCurLogin";
            this.lbCurLogin.Size = new System.Drawing.Size(0, 12);
            this.lbCurLogin.TabIndex = 1;
            this.lbCurLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.tableLayoutPanel2);
            this.panel3.Location = new System.Drawing.Point(1, 26);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(928, 74);
            this.panel3.TabIndex = 12;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.88889F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.88889F));
            this.tableLayoutPanel2.Controls.Add(this.lbBoxNum, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbBoxNumber, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbProductNum, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbProductNum, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(927, 73);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // lbBoxNum
            // 
            this.lbBoxNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbBoxNum.AutoSize = true;
            this.lbBoxNum.Font = new System.Drawing.Font("微软雅黑", 14.25F);
            this.lbBoxNum.Location = new System.Drawing.Point(465, 24);
            this.lbBoxNum.Name = "lbBoxNum";
            this.lbBoxNum.Size = new System.Drawing.Size(96, 25);
            this.lbBoxNum.TabIndex = 10;
            this.lbBoxNum.Text = "箱号:";
            this.lbBoxNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbBoxNumber
            // 
            this.tbBoxNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBoxNumber.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbBoxNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbBoxNumber.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbBoxNumber.ForeColor = System.Drawing.Color.Red;
            this.tbBoxNumber.Location = new System.Drawing.Point(105, 19);
            this.tbBoxNumber.Name = "tbBoxNumber";
            this.tbBoxNumber.ReadOnly = true;
            this.tbBoxNumber.Size = new System.Drawing.Size(354, 34);
            this.tbBoxNumber.TabIndex = 9;
            this.tbBoxNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbProductNum
            // 
            this.lbProductNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbProductNum.AutoSize = true;
            this.lbProductNum.Font = new System.Drawing.Font("微软雅黑", 14.25F);
            this.lbProductNum.Location = new System.Drawing.Point(3, 24);
            this.lbProductNum.Name = "lbProductNum";
            this.lbProductNum.Size = new System.Drawing.Size(96, 25);
            this.lbProductNum.TabIndex = 6;
            this.lbProductNum.Text = "产品号:";
            this.lbProductNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbProductNum
            // 
            this.tbProductNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbProductNum.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbProductNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbProductNum.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbProductNum.ForeColor = System.Drawing.Color.Red;
            this.tbProductNum.Location = new System.Drawing.Point(567, 19);
            this.tbProductNum.Name = "tbProductNum";
            this.tbProductNum.ReadOnly = true;
            this.tbProductNum.Size = new System.Drawing.Size(357, 34);
            this.tbProductNum.TabIndex = 5;
            this.tbProductNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timerFlashTitle
            // 
            this.timerFlashTitle.Interval = 1000;
            this.timerFlashTitle.Tick += new System.EventHandler(this.timerFlashTitle_Tick);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(931, 559);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelValue);
            this.Controls.Add(this.mainMenu);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Resize += new System.EventHandler(this.mainForm_Resize);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mainForm_KeyDown);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.panelValue.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.Label lbSetValCap;
        private System.Windows.Forms.Label lbCurValCap;
        private System.Windows.Forms.Label lbLeftValCap;
        private System.Windows.Forms.Label lbSetVal;
        private System.Windows.Forms.Label lbCurVal;
        private System.Windows.Forms.Label lbLeftVal;
        private System.Windows.Forms.Label lbSubCap;
        private System.Windows.Forms.Label lbEqualCap;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelValue;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbPacketList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbProductNum;
        private System.Windows.Forms.TextBox tbProductNum;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lbCurLogin;
        private System.Windows.Forms.Label lbCurBoxSerial;
        private System.Windows.Forms.ToolStripMenuItem menuLogin;
        private System.Windows.Forms.ToolStripMenuItem menuLogout;
        private System.Windows.Forms.Label lbBoxNum;
        private System.Windows.Forms.TextBox tbBoxNumber;
        private System.Windows.Forms.ToolStripMenuItem itemSetHandle;
        private System.Windows.Forms.ToolStripMenuItem menuSelectformula;
        private System.Windows.Forms.ToolStripMenuItem menuManager;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton page_up;
        private System.Windows.Forms.ToolStripButton page_down;
        private System.Windows.Forms.ToolStripTextBox tbJumpoffset;
        private System.Windows.Forms.ToolStripButton jump_pageoffset;
        private Janus.Windows.GridEX.GridEX gridEX1;
        private System.Windows.Forms.Timer timerFlashTitle;
        private System.Windows.Forms.ToolStripMenuItem chanegValue;
        private System.Windows.Forms.Label lbWarn;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.Label lbCurPack;
        private System.Windows.Forms.Label lbCurWork;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
    }
}

