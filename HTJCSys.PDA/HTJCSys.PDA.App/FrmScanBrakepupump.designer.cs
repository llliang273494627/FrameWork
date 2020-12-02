namespace HTJCSysPDA
{
    partial class FrmScanBrakepupump
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem();
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
            this.btnSelectCode = new System.Windows.Forms.Button();
            this.lblCurrentMaterialCode = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.Label();
            this.txtHJCode = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblTip = new System.Windows.Forms.Label();
            this.lblOK = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 25);
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
            listViewItem1.BackColor = System.Drawing.Color.Silver;
            listViewItem1.ForeColor = System.Drawing.Color.Green;
            listViewItem1.Text = "9687192480";
            listViewItem1.SubItems.Add("OK");
            listViewItem1.SubItems.Add("1");
            listViewItem1.SubItems.Add("0");
            listViewItem1.SubItems.Add("9687192480");
            listViewItem2.BackColor = System.Drawing.Color.Gainsboro;
            listViewItem2.ForeColor = System.Drawing.Color.Green;
            listViewItem2.Text = "9687192481";
            listViewItem2.SubItems.Add("√");
            listViewItem2.SubItems.Add("96");
            listViewItem2.SubItems.Add("0");
            listViewItem2.SubItems.Add("9687192480");
            listViewItem3.BackColor = System.Drawing.Color.Silver;
            listViewItem3.ForeColor = System.Drawing.Color.Black;
            listViewItem3.Text = "9687192482";
            listViewItem3.SubItems.Add("×");
            listViewItem3.SubItems.Add("300");
            listViewItem3.SubItems.Add("0");
            listViewItem3.SubItems.Add("9687192480");
            listViewItem4.BackColor = System.Drawing.Color.Gainsboro;
            listViewItem4.ForeColor = System.Drawing.Color.Black;
            listViewItem4.Text = "9687192483";
            listViewItem4.SubItems.Add("√");
            listViewItem4.SubItems.Add("968");
            listViewItem4.SubItems.Add("0");
            listViewItem4.SubItems.Add("9687192483");
            listViewItem5.BackColor = System.Drawing.Color.Silver;
            listViewItem5.ForeColor = System.Drawing.Color.Red;
            listViewItem5.Text = "9687192484";
            listViewItem5.SubItems.Add("√");
            listViewItem5.SubItems.Add("96");
            listViewItem5.SubItems.Add("0");
            listViewItem5.SubItems.Add("9687192483");
            listViewItem6.BackColor = System.Drawing.Color.Gainsboro;
            listViewItem6.ForeColor = System.Drawing.Color.Red;
            listViewItem6.Text = "9687192485";
            listViewItem6.SubItems.Add("×");
            listViewItem6.SubItems.Add("9");
            listViewItem6.SubItems.Add("0");
            listViewItem6.SubItems.Add("9687192483");
            this.lvMaterial.Items.Add(listViewItem1);
            this.lvMaterial.Items.Add(listViewItem2);
            this.lvMaterial.Items.Add(listViewItem3);
            this.lvMaterial.Items.Add(listViewItem4);
            this.lvMaterial.Items.Add(listViewItem5);
            this.lvMaterial.Items.Add(listViewItem6);
            this.lvMaterial.Location = new System.Drawing.Point(4, 94);
            this.lvMaterial.Name = "lvMaterial";
            this.lvMaterial.Size = new System.Drawing.Size(232, 177);
            this.lvMaterial.TabIndex = 2;
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
            this.label2.Location = new System.Drawing.Point(3, 72);
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
            this.btnExit.BackColor = System.Drawing.Color.Turquoise;
            this.btnExit.Location = new System.Drawing.Point(197, 294);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(42, 24);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "返回";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSelectCode
            // 
            this.btnSelectCode.BackColor = System.Drawing.Color.Turquoise;
            this.btnSelectCode.Location = new System.Drawing.Point(195, 19);
            this.btnSelectCode.Name = "btnSelectCode";
            this.btnSelectCode.Size = new System.Drawing.Size(40, 24);
            this.btnSelectCode.TabIndex = 9;
            this.btnSelectCode.Text = "选型";
            this.btnSelectCode.Click += new System.EventHandler(this.btnSelectCode_Click);
            // 
            // lblCurrentMaterialCode
            // 
            this.lblCurrentMaterialCode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblCurrentMaterialCode.ForeColor = System.Drawing.Color.Navy;
            this.lblCurrentMaterialCode.Location = new System.Drawing.Point(71, 273);
            this.lblCurrentMaterialCode.Name = "lblCurrentMaterialCode";
            this.lblCurrentMaterialCode.Size = new System.Drawing.Size(167, 20);
            this.lblCurrentMaterialCode.Text = "88JCB2E950223H";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.Text = "合件条码：";
            // 
            // txtProductCode
            // 
            this.txtProductCode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtProductCode.ForeColor = System.Drawing.Color.Black;
            this.txtProductCode.Location = new System.Drawing.Point(71, 24);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(112, 20);
            this.txtProductCode.Text = "9435220880";
            // 
            // txtHJCode
            // 
            this.txtHJCode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtHJCode.ForeColor = System.Drawing.Color.Maroon;
            this.txtHJCode.Location = new System.Drawing.Point(71, 47);
            this.txtHJCode.Name = "txtHJCode";
            this.txtHJCode.Size = new System.Drawing.Size(164, 20);
            this.txtHJCode.Text = "9435220880";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Turquoise;
            this.btnReset.Location = new System.Drawing.Point(193, 68);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(42, 24);
            this.btnReset.TabIndex = 29;
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
            this.lblTip.Text = "合件不在此产品列";
            // 
            // lblOK
            // 
            this.lblOK.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.lblOK.ForeColor = System.Drawing.Color.Green;
            this.lblOK.Location = new System.Drawing.Point(145, 67);
            this.lblOK.Name = "lblOK";
            this.lblOK.Size = new System.Drawing.Size(46, 24);
            this.lblOK.Text = "OK";
            // 
            // FrmScanBrakepupump
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.lvMaterial);
            this.Controls.Add(this.lblOK);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtHJCode);
            this.Controls.Add(this.txtProductCode);
            this.Controls.Add(this.lblCurrentMaterialCode);
            this.Controls.Add(this.btnSelectCode);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmScanBrakepupump";
            this.Text = "操作流程";
            this.Deactivate += new System.EventHandler(this.FrmScan_Deactivate);
            this.Load += new System.EventHandler(this.FrmScan_Load);
            this.Activated += new System.EventHandler(this.FrmScan_Activated);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvMaterial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSelectCode;
        private System.Windows.Forms.ColumnHeader MaterialCode;
        private System.Windows.Forms.ColumnHeader MaterialName;
        private System.Windows.Forms.ColumnHeader MaterialNum;
        private System.Windows.Forms.Label lblCurrentMaterialCode;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader ScanNum;
        private System.Windows.Forms.Label txtProductCode;
        private System.Windows.Forms.Label txtHJCode;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.Label lblOK;

    }
}