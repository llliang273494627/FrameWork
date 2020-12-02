namespace HTJCSys.PDA
{
    partial class FrmBatch
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
            this.lblTip = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.tbSupplier = new System.Windows.Forms.TextBox();
            this.tbMaterialBatchNum = new System.Windows.Forms.TextBox();
            this.tbBarCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbMaterialCode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMaterialBatchNo = new System.Windows.Forms.TextBox();
            this.lblMaterialName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTip
            // 
            this.lblTip.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblTip.ForeColor = System.Drawing.Color.Red;
            this.lblTip.Location = new System.Drawing.Point(3, 300);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(234, 20);
            this.lblTip.Text = "扫描材料编码不在此产品列";
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
            this.lblTitle.Text = "批次追溯";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnReset.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(62, 273);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(56, 24);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "复位";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnApply.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.btnApply.ForeColor = System.Drawing.Color.White;
            this.btnApply.Location = new System.Drawing.Point(122, 273);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(56, 24);
            this.btnApply.TabIndex = 0;
            this.btnApply.Text = "确定";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnBack.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(182, 273);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(56, 24);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "返回";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnEdit.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(2, 273);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(56, 24);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "手动";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FloralWhite;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.tbSupplier);
            this.panel1.Controls.Add(this.tbMaterialBatchNum);
            this.panel1.Controls.Add(this.tbBarCode);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cmbMaterialCode);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbMaterialBatchNo);
            this.panel1.Controls.Add(this.lblMaterialName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(7, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(223, 245);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(29, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(164, 14);
            this.label7.Text = "合件条码：";
            // 
            // tbSupplier
            // 
            this.tbSupplier.BackColor = System.Drawing.Color.White;
            this.tbSupplier.Location = new System.Drawing.Point(31, 112);
            this.tbSupplier.Multiline = true;
            this.tbSupplier.Name = "tbSupplier";
            this.tbSupplier.ReadOnly = true;
            this.tbSupplier.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbSupplier.Size = new System.Drawing.Size(161, 19);
            this.tbSupplier.TabIndex = 1;
            this.tbSupplier.Text = "M104650000";
            // 
            // tbMaterialBatchNum
            // 
            this.tbMaterialBatchNum.BackColor = System.Drawing.Color.White;
            this.tbMaterialBatchNum.Location = new System.Drawing.Point(123, 132);
            this.tbMaterialBatchNum.Multiline = true;
            this.tbMaterialBatchNum.Name = "tbMaterialBatchNum";
            this.tbMaterialBatchNum.ReadOnly = true;
            this.tbMaterialBatchNum.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbMaterialBatchNum.Size = new System.Drawing.Size(70, 19);
            this.tbMaterialBatchNum.TabIndex = 2;
            this.tbMaterialBatchNum.Text = "100";
            // 
            // tbBarCode
            // 
            this.tbBarCode.BackColor = System.Drawing.Color.White;
            this.tbBarCode.Location = new System.Drawing.Point(31, 225);
            this.tbBarCode.Multiline = true;
            this.tbBarCode.Name = "tbBarCode";
            this.tbBarCode.ReadOnly = true;
            this.tbBarCode.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbBarCode.Size = new System.Drawing.Size(161, 19);
            this.tbBarCode.TabIndex = 4;
            this.tbBarCode.Text = "78CCA3G400075D";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(29, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 14);
            this.label6.Text = "供应商编码：";
            // 
            // cmbMaterialCode
            // 
            this.cmbMaterialCode.Items.Add("9671840280");
            this.cmbMaterialCode.Location = new System.Drawing.Point(32, 20);
            this.cmbMaterialCode.Name = "cmbMaterialCode";
            this.cmbMaterialCode.Size = new System.Drawing.Size(161, 22);
            this.cmbMaterialCode.TabIndex = 0;
            this.cmbMaterialCode.SelectedIndexChanged += new System.EventHandler(this.cmbMaterialCode_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(29, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.Text = "包装数量：";
            // 
            // tbMaterialBatchNo
            // 
            this.tbMaterialBatchNo.BackColor = System.Drawing.Color.White;
            this.tbMaterialBatchNo.Location = new System.Drawing.Point(32, 172);
            this.tbMaterialBatchNo.Multiline = true;
            this.tbMaterialBatchNo.Name = "tbMaterialBatchNo";
            this.tbMaterialBatchNo.ReadOnly = true;
            this.tbMaterialBatchNo.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbMaterialBatchNo.Size = new System.Drawing.Size(161, 34);
            this.tbMaterialBatchNo.TabIndex = 3;
            this.tbMaterialBatchNo.Text = "981331318000064M10601000020160412H08022503600000000Y0607981331318000064M106010000" +
                "201604\r\n";
            // 
            // lblMaterialName
            // 
            this.lblMaterialName.BackColor = System.Drawing.Color.Silver;
            this.lblMaterialName.ForeColor = System.Drawing.Color.Black;
            this.lblMaterialName.Location = new System.Drawing.Point(32, 61);
            this.lblMaterialName.Name = "lblMaterialName";
            this.lblMaterialName.Size = new System.Drawing.Size(161, 32);
            this.lblMaterialName.Text = "螺栓  M12X125 L80 AC12（轴承固定螺栓）";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(29, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 14);
            this.label3.Text = "子零件名称：";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(29, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 16);
            this.label4.Text = "批次号条码：";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(32, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 14);
            this.label1.Text = "子零件编码：";
            // 
            // FrmBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblTip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmBatch";
            this.Text = "批次设置";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmBatch_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbMaterialBatchNo;
        private System.Windows.Forms.Label lblMaterialName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMaterialCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbBarCode;
        private System.Windows.Forms.TextBox tbSupplier;
        private System.Windows.Forms.TextBox tbMaterialBatchNum;


    }
}