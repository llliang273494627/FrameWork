namespace HTJCSys.PDA
{
    partial class FrmRepair
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReStart = new System.Windows.Forms.Button();
            this.lvMaterial = new System.Windows.Forms.ListView();
            this.MaterialCode = new System.Windows.Forms.ColumnHeader();
            this.MaterialName = new System.Windows.Forms.ColumnHeader();
            this.BarCode = new System.Windows.Forms.ColumnHeader();
            this.lblBarCode = new System.Windows.Forms.Label();
            this.lblMaterialCode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblTip = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblProductCode = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblHJCode = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnReStart);
            this.panel1.Controls.Add(this.lvMaterial);
            this.panel1.Controls.Add(this.lblBarCode);
            this.panel1.Controls.Add(this.lblMaterialCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnApply);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Location = new System.Drawing.Point(0, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 230);
            // 
            // btnReStart
            // 
            this.btnReStart.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnReStart.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnReStart.ForeColor = System.Drawing.Color.White;
            this.btnReStart.Location = new System.Drawing.Point(12, 203);
            this.btnReStart.Name = "btnReStart";
            this.btnReStart.Size = new System.Drawing.Size(60, 25);
            this.btnReStart.TabIndex = 1;
            this.btnReStart.Text = "复位";
            this.btnReStart.Click += new System.EventHandler(this.btnReStart_Click);
            // 
            // lvMaterial
            // 
            this.lvMaterial.Columns.Add(this.MaterialCode);
            this.lvMaterial.Columns.Add(this.MaterialName);
            this.lvMaterial.Columns.Add(this.BarCode);
            this.lvMaterial.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvMaterial.FullRowSelect = true;
            this.lvMaterial.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            listViewItem1.BackColor = System.Drawing.Color.Silver;
            listViewItem1.ForeColor = System.Drawing.Color.Green;
            listViewItem1.Text = "9687192480";
            listViewItem1.SubItems.Add("9687192480");
            this.lvMaterial.Items.Add(listViewItem1);
            this.lvMaterial.Location = new System.Drawing.Point(0, 0);
            this.lvMaterial.Name = "lvMaterial";
            this.lvMaterial.Size = new System.Drawing.Size(240, 156);
            this.lvMaterial.TabIndex = 0;
            this.lvMaterial.View = System.Windows.Forms.View.Details;
            // 
            // MaterialCode
            // 
            this.MaterialCode.Text = "材料编码";
            this.MaterialCode.Width = 84;
            // 
            // MaterialName
            // 
            this.MaterialName.Text = "材料名称";
            this.MaterialName.Width = 110;
            // 
            // BarCode
            // 
            this.BarCode.Text = "条码";
            this.BarCode.Width = 60;
            // 
            // lblBarCode
            // 
            this.lblBarCode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblBarCode.Location = new System.Drawing.Point(75, 181);
            this.lblBarCode.Name = "lblBarCode";
            this.lblBarCode.Size = new System.Drawing.Size(156, 20);
            this.lblBarCode.Text = "SW11053784S";
            // 
            // lblMaterialCode
            // 
            this.lblMaterialCode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblMaterialCode.Location = new System.Drawing.Point(75, 159);
            this.lblMaterialCode.Name = "lblMaterialCode";
            this.lblMaterialCode.Size = new System.Drawing.Size(156, 20);
            this.lblMaterialCode.Text = "9801434380";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "材料编码：";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.Text = "流水条码：";
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnApply.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnApply.ForeColor = System.Drawing.Color.White;
            this.btnApply.Location = new System.Drawing.Point(90, 203);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(60, 25);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "确定";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnBack.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(169, 203);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(60, 25);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "返回";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblTip
            // 
            this.lblTip.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblTip.ForeColor = System.Drawing.Color.Red;
            this.lblTip.Location = new System.Drawing.Point(3, 301);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(234, 17);
            this.lblTip.Text = "扫描材料编码不在此产品列";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.Text = "产品编码：";
            // 
            // lblProductCode
            // 
            this.lblProductCode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblProductCode.ForeColor = System.Drawing.Color.Navy;
            this.lblProductCode.Location = new System.Drawing.Point(75, 47);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new System.Drawing.Size(164, 20);
            this.lblProductCode.Text = "9435220880";
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
            this.lblTitle.Text = "返修追溯";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblHJCode
            // 
            this.lblHJCode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblHJCode.ForeColor = System.Drawing.Color.Maroon;
            this.lblHJCode.Location = new System.Drawing.Point(76, 25);
            this.lblHJCode.Name = "lblHJCode";
            this.lblHJCode.Size = new System.Drawing.Size(164, 20);
            this.lblHJCode.Text = "9435220880";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.Text = "合件条码：";
            // 
            // FrmRepair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.lblHJCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblProductCode);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmRepair";
            this.Text = "批次设置";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Deactivate += new System.EventHandler(this.FrmRepair_Deactivate);
            this.Load += new System.EventHandler(this.FrmBatch_Load);
            this.Activated += new System.EventHandler(this.FrmRepair_Activated);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lvMaterial;
        private System.Windows.Forms.ColumnHeader MaterialCode;
        private System.Windows.Forms.ColumnHeader MaterialName;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblProductCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader BarCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBarCode;
        private System.Windows.Forms.Label lblMaterialCode;
        private System.Windows.Forms.Button btnReStart;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblHJCode;
        private System.Windows.Forms.Label label5;


    }
}