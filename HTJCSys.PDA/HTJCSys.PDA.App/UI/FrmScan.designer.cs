namespace HTJCSys.PDA
{
    partial class FrmScan
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
            System.Windows.Forms.ListViewItem listViewItem19 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem20 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem21 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem22 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem23 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem24 = new System.Windows.Forms.ListViewItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lvMaterial = new System.Windows.Forms.ListView();
            this.MaterialCode = new System.Windows.Forms.ColumnHeader();
            this.Status = new System.Windows.Forms.ColumnHeader();
            this.MaterialNum = new System.Windows.Forms.ColumnHeader();
            this.ScanNum = new System.Windows.Forms.ColumnHeader();
            this.MaterialName = new System.Windows.Forms.ColumnHeader();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblScanCode = new System.Windows.Forms.Label();
            this.lblProductCode = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblTip = new System.Windows.Forms.Label();
            this.lblOK = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCurrentCount = new System.Windows.Forms.Label();
            this.btnCount = new System.Windows.Forms.Button();
            this.lblHJCode = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbtnInScan = new System.Windows.Forms.RadioButton();
            this.rbtnNormalScan = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.Text = "产品编码：";
            // 
            // lvMaterial
            // 
            this.lvMaterial.Columns.Add(this.MaterialCode);
            this.lvMaterial.Columns.Add(this.Status);
            this.lvMaterial.Columns.Add(this.MaterialNum);
            this.lvMaterial.Columns.Add(this.ScanNum);
            this.lvMaterial.Columns.Add(this.MaterialName);
            this.lvMaterial.FullRowSelect = true;
            this.lvMaterial.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            listViewItem19.BackColor = System.Drawing.Color.Silver;
            listViewItem19.ForeColor = System.Drawing.Color.Green;
            listViewItem19.Text = "9687192480";
            listViewItem19.SubItems.Add("OK");
            listViewItem19.SubItems.Add("1");
            listViewItem19.SubItems.Add("0");
            listViewItem19.SubItems.Add("9687192480");
            listViewItem20.BackColor = System.Drawing.Color.Gainsboro;
            listViewItem20.ForeColor = System.Drawing.Color.Green;
            listViewItem20.Text = "9687192481";
            listViewItem20.SubItems.Add("√");
            listViewItem20.SubItems.Add("96");
            listViewItem20.SubItems.Add("0");
            listViewItem20.SubItems.Add("9687192480");
            listViewItem21.BackColor = System.Drawing.Color.Silver;
            listViewItem21.ForeColor = System.Drawing.Color.Black;
            listViewItem21.Text = "9687192482";
            listViewItem21.SubItems.Add("×");
            listViewItem21.SubItems.Add("300");
            listViewItem21.SubItems.Add("0");
            listViewItem21.SubItems.Add("9687192480");
            listViewItem22.BackColor = System.Drawing.Color.Gainsboro;
            listViewItem22.ForeColor = System.Drawing.Color.Black;
            listViewItem22.Text = "9687192483";
            listViewItem22.SubItems.Add("√");
            listViewItem22.SubItems.Add("968");
            listViewItem22.SubItems.Add("0");
            listViewItem22.SubItems.Add("9687192483");
            listViewItem23.BackColor = System.Drawing.Color.Silver;
            listViewItem23.ForeColor = System.Drawing.Color.Red;
            listViewItem23.Text = "9687192484";
            listViewItem23.SubItems.Add("√");
            listViewItem23.SubItems.Add("96");
            listViewItem23.SubItems.Add("0");
            listViewItem23.SubItems.Add("9687192483");
            listViewItem24.BackColor = System.Drawing.Color.Gainsboro;
            listViewItem24.ForeColor = System.Drawing.Color.Red;
            listViewItem24.Text = "9687192485";
            listViewItem24.SubItems.Add("×");
            listViewItem24.SubItems.Add("9");
            listViewItem24.SubItems.Add("0");
            listViewItem24.SubItems.Add("9687192483");
            this.lvMaterial.Items.Add(listViewItem19);
            this.lvMaterial.Items.Add(listViewItem20);
            this.lvMaterial.Items.Add(listViewItem21);
            this.lvMaterial.Items.Add(listViewItem22);
            this.lvMaterial.Items.Add(listViewItem23);
            this.lvMaterial.Items.Add(listViewItem24);
            this.lvMaterial.Location = new System.Drawing.Point(4, 122);
            this.lvMaterial.Name = "lvMaterial";
            this.lvMaterial.Size = new System.Drawing.Size(232, 149);
            this.lvMaterial.TabIndex = 3;
            this.lvMaterial.View = System.Windows.Forms.View.Details;
            // 
            // MaterialCode
            // 
            this.MaterialCode.Text = "材料编码";
            this.MaterialCode.Width = 80;
            // 
            // Status
            // 
            this.Status.Text = "状态";
            this.Status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Status.Width = 38;
            // 
            // MaterialNum
            // 
            this.MaterialNum.Text = "数量";
            this.MaterialNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MaterialNum.Width = 38;
            // 
            // ScanNum
            // 
            this.ScanNum.Text = "次数";
            this.ScanNum.Width = 38;
            // 
            // MaterialName
            // 
            this.MaterialName.Text = "材料名称";
            this.MaterialName.Width = 100;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.Text = "材料列表：";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 275);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.Text = "当前条码：";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(197, 294);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(42, 24);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "返回";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblScanCode
            // 
            this.lblScanCode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblScanCode.ForeColor = System.Drawing.Color.Navy;
            this.lblScanCode.Location = new System.Drawing.Point(71, 273);
            this.lblScanCode.Name = "lblScanCode";
            this.lblScanCode.Size = new System.Drawing.Size(167, 20);
            this.lblScanCode.Text = "88JCB2E950223H";
            // 
            // lblProductCode
            // 
            this.lblProductCode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblProductCode.ForeColor = System.Drawing.Color.Black;
            this.lblProductCode.Location = new System.Drawing.Point(71, 75);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new System.Drawing.Size(112, 20);
            this.lblProductCode.Text = "9435220880";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(197, 96);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(38, 24);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "复位";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblTip
            // 
            this.lblTip.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblTip.ForeColor = System.Drawing.Color.Red;
            this.lblTip.Location = new System.Drawing.Point(2, 296);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(233, 22);
            this.lblTip.Text = "当前型号没有扫描追溯零件";
            // 
            // lblOK
            // 
            this.lblOK.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.lblOK.ForeColor = System.Drawing.Color.Green;
            this.lblOK.Location = new System.Drawing.Point(120, 95);
            this.lblOK.Name = "lblOK";
            this.lblOK.Size = new System.Drawing.Size(41, 24);
            this.lblOK.Text = "OK";
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(240, 24);
            this.lblTitle.Text = "扫描-左前半桥总成";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCurrentCount
            // 
            this.lblCurrentCount.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentCount.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.lblCurrentCount.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblCurrentCount.Location = new System.Drawing.Point(71, 95);
            this.lblCurrentCount.Name = "lblCurrentCount";
            this.lblCurrentCount.Size = new System.Drawing.Size(50, 24);
            this.lblCurrentCount.Text = "999";
            this.lblCurrentCount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCount
            // 
            this.btnCount.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnCount.ForeColor = System.Drawing.Color.White;
            this.btnCount.Location = new System.Drawing.Point(197, 71);
            this.btnCount.Name = "btnCount";
            this.btnCount.Size = new System.Drawing.Size(38, 22);
            this.btnCount.TabIndex = 0;
            this.btnCount.Text = "计数";
            this.btnCount.Click += new System.EventHandler(this.btnCount_Click);
            // 
            // lblHJCode
            // 
            this.lblHJCode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblHJCode.ForeColor = System.Drawing.Color.Maroon;
            this.lblHJCode.Location = new System.Drawing.Point(72, 52);
            this.lblHJCode.Name = "lblHJCode";
            this.lblHJCode.Size = new System.Drawing.Size(164, 20);
            this.lblHJCode.Text = "88JCB2E950223H";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(4, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.Text = "合件条码：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtnNormalScan);
            this.panel1.Controls.Add(this.rbtnInScan);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 28);
            // 
            // rbtnInScan
            // 
            this.rbtnInScan.Location = new System.Drawing.Point(123, 5);
            this.rbtnInScan.Name = "rbtnInScan";
            this.rbtnInScan.Size = new System.Drawing.Size(100, 20);
            this.rbtnInScan.TabIndex = 1;
            this.rbtnInScan.TabStop = false;
            this.rbtnInScan.Text = "上线扫描";
            this.rbtnInScan.CheckedChanged += new System.EventHandler(this.rbtnInScan_CheckedChanged);
            // 
            // rbtnNormalScan
            // 
            this.rbtnNormalScan.Checked = true;
            this.rbtnNormalScan.Location = new System.Drawing.Point(17, 5);
            this.rbtnNormalScan.Name = "rbtnNormalScan";
            this.rbtnNormalScan.Size = new System.Drawing.Size(100, 20);
            this.rbtnNormalScan.TabIndex = 0;
            this.rbtnNormalScan.Text = "正常扫描";
            this.rbtnNormalScan.CheckedChanged += new System.EventHandler(this.rbtnNormalScan_CheckedChanged);
            // 
            // FrmScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCount);
            this.Controls.Add(this.lblHJCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblCurrentCount);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lvMaterial);
            this.Controls.Add(this.lblOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblProductCode);
            this.Controls.Add(this.lblScanCode);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmScan";
            this.Text = "操作流程";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmScan_Load);
            this.Closed += new System.EventHandler(this.FrmScan_Closed);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvMaterial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ColumnHeader MaterialCode;
        private System.Windows.Forms.ColumnHeader MaterialName;
        private System.Windows.Forms.ColumnHeader MaterialNum;
        private System.Windows.Forms.Label lblScanCode;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ColumnHeader ScanNum;
        private System.Windows.Forms.Label lblProductCode;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.Label lblOK;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCurrentCount;
        private System.Windows.Forms.Button btnCount;
        private System.Windows.Forms.Label lblHJCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbtnNormalScan;
        private System.Windows.Forms.RadioButton rbtnInScan;

    }
}