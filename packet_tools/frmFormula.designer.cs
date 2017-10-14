namespace packet_tools
{
    partial class frmFormula
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFormula));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbCurpacknum = new System.Windows.Forms.TextBox();
            this.tbCurboxnum = new System.Windows.Forms.TextBox();
            this.richTextproduct = new System.Windows.Forms.TextBox();
            this.richTextBox = new System.Windows.Forms.TextBox();
            this.richTexttips = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxProductNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSnbox = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDel = new System.Windows.Forms.ToolStripMenuItem();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbCurpacknum);
            this.groupBox1.Controls.Add(this.tbCurboxnum);
            this.groupBox1.Controls.Add(this.richTextproduct);
            this.groupBox1.Controls.Add(this.richTextBox);
            this.groupBox1.Controls.Add(this.richTexttips);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxProductNum);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbSnbox);
            this.groupBox1.Location = new System.Drawing.Point(1, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 321);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "型号列表:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "当前箱号:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "料号:";
            // 
            // tbCurpacknum
            // 
            this.tbCurpacknum.Location = new System.Drawing.Point(80, 169);
            this.tbCurpacknum.MaxLength = 50;
            this.tbCurpacknum.Name = "tbCurpacknum";
            this.tbCurpacknum.Size = new System.Drawing.Size(235, 21);
            this.tbCurpacknum.TabIndex = 14;
            this.tbCurpacknum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbCurboxnum
            // 
            this.tbCurboxnum.Location = new System.Drawing.Point(82, 138);
            this.tbCurboxnum.MaxLength = 50;
            this.tbCurboxnum.Name = "tbCurboxnum";
            this.tbCurboxnum.ReadOnly = true;
            this.tbCurboxnum.Size = new System.Drawing.Size(233, 21);
            this.tbCurboxnum.TabIndex = 13;
            this.tbCurboxnum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // richTextproduct
            // 
            this.richTextproduct.Location = new System.Drawing.Point(81, 245);
            this.richTextproduct.MaxLength = 50;
            this.richTextproduct.Name = "richTextproduct";
            this.richTextproduct.Size = new System.Drawing.Size(234, 21);
            this.richTextproduct.TabIndex = 11;
            this.richTextproduct.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(81, 215);
            this.richTextBox.MaxLength = 50;
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(234, 21);
            this.richTextBox.TabIndex = 10;
            this.richTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // richTexttips
            // 
            this.richTexttips.BackColor = System.Drawing.Color.Azure;
            this.richTexttips.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTexttips.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTexttips.Location = new System.Drawing.Point(23, 14);
            this.richTexttips.Name = "richTexttips";
            this.richTexttips.ReadOnly = true;
            this.richTexttips.Size = new System.Drawing.Size(311, 58);
            this.richTexttips.TabIndex = 9;
            this.richTexttips.Text = "例如:$12345ABCDE$$$$$12345\n说明： $代表一位可变值，使用上面数据计算数据位数.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "产品号规则:";
            // 
            // textBoxProductNum
            // 
            this.textBoxProductNum.Location = new System.Drawing.Point(81, 108);
            this.textBoxProductNum.MaxLength = 10;
            this.textBoxProductNum.Name = "textBoxProductNum";
            this.textBoxProductNum.ReadOnly = true;
            this.textBoxProductNum.Size = new System.Drawing.Size(233, 21);
            this.textBoxProductNum.TabIndex = 6;
            this.textBoxProductNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "产品数量:";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(112, 278);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(123, 38);
            this.btnSelect.TabIndex = 4;
            this.btnSelect.Text = "确定";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "装箱号规则:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "打包方案:";
            // 
            // cmbSnbox
            // 
            this.cmbSnbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSnbox.FormattingEnabled = true;
            this.cmbSnbox.Location = new System.Drawing.Point(81, 78);
            this.cmbSnbox.Name = "cmbSnbox";
            this.cmbSnbox.Size = new System.Drawing.Size(233, 20);
            this.cmbSnbox.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAdd,
            this.menuDel});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(347, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuAdd
            // 
            this.menuAdd.Name = "menuAdd";
            this.menuAdd.Size = new System.Drawing.Size(92, 21);
            this.menuAdd.Text = "添加打包方案";
            this.menuAdd.Click += new System.EventHandler(this.menuAdd_Click);
            // 
            // menuDel
            // 
            this.menuDel.Name = "menuDel";
            this.menuDel.Size = new System.Drawing.Size(92, 21);
            this.menuDel.Text = "删除打包方案";
            this.menuDel.Click += new System.EventHandler(this.menuDel_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(84, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(197, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "0:代表不使用料号,非0代表使用料号";
            // 
            // frmFormula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(347, 352);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFormula";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "打包方案";
            this.Load += new System.EventHandler(this.frmFormula_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFormula_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSnbox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuAdd;
        private System.Windows.Forms.ToolStripMenuItem menuDel;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox textBoxProductNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTexttips;
        private System.Windows.Forms.TextBox richTextproduct;
        private System.Windows.Forms.TextBox richTextBox;
        private System.Windows.Forms.TextBox tbCurboxnum;
        private System.Windows.Forms.TextBox tbCurpacknum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}