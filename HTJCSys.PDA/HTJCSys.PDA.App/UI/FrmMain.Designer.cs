namespace HTJCSys.PDA
{
    partial class FrmMain
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
            this.tTime = new System.Windows.Forms.Timer();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timerDownLoad = new System.Windows.Forms.Timer();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pBottom = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblDevice = new System.Windows.Forms.Label();
            this.lblStation = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnUpData = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.bntBack = new System.Windows.Forms.Button();
            this.btnBatch = new System.Windows.Forms.Button();
            this.btnDnData = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pBottom.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tTime
            // 
            this.tTime.Enabled = true;
            this.tTime.Tick += new System.EventHandler(this.tTime_Tick);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(238, 26);
            this.lblTitle.Text = "一厂踏板 PF2 BVM 镀铝";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 34);
            // 
            // timerDownLoad
            // 
            this.timerDownLoad.Tick += new System.EventHandler(this.timerDownLoad_Tick);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(29, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 18);
            this.label4.Text = "设备编号：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(29, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 18);
            this.label5.Text = "工位编号：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(28, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 18);
            this.label2.Text = "操作人员：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pBottom
            // 
            this.pBottom.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.pBottom.Controls.Add(this.lblVersion);
            this.pBottom.Location = new System.Drawing.Point(0, 263);
            this.pBottom.Name = "pBottom";
            this.pBottom.Size = new System.Drawing.Size(240, 23);
            // 
            // lblVersion
            // 
            this.lblVersion.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVersion.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblVersion.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Location = new System.Drawing.Point(0, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(240, 23);
            this.lblVersion.Text = "Version：v3.0.2016.0418";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDevice
            // 
            this.lblDevice.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblDevice.Location = new System.Drawing.Point(123, 42);
            this.lblDevice.Name = "lblDevice";
            this.lblDevice.Size = new System.Drawing.Size(110, 18);
            this.lblDevice.Text = "S01";
            // 
            // lblStation
            // 
            this.lblStation.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblStation.Location = new System.Drawing.Point(123, 64);
            this.lblStation.Name = "lblStation";
            this.lblStation.Size = new System.Drawing.Size(108, 18);
            this.lblStation.Text = "ST01";
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblUser.Location = new System.Drawing.Point(123, 17);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(110, 18);
            this.lblUser.Text = "管理员";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.btnStart);
            this.panelMain.Controls.Add(this.btnUpData);
            this.panelMain.Controls.Add(this.btnExit);
            this.panelMain.Controls.Add(this.bntBack);
            this.panelMain.Controls.Add(this.btnBatch);
            this.panelMain.Controls.Add(this.btnDnData);
            this.panelMain.Controls.Add(this.lblUser);
            this.panelMain.Controls.Add(this.lblStation);
            this.panelMain.Controls.Add(this.lblDevice);
            this.panelMain.Controls.Add(this.pBottom);
            this.panelMain.Controls.Add(this.label2);
            this.panelMain.Controls.Add(this.label5);
            this.panelMain.Controls.Add(this.label4);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 34);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(240, 286);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnStart.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(1, 104);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(78, 78);
            this.btnStart.TabIndex = 30;
            this.btnStart.Text = "扫描";
            // 
            // btnUpData
            // 
            this.btnUpData.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnUpData.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnUpData.ForeColor = System.Drawing.Color.White;
            this.btnUpData.Location = new System.Drawing.Point(80, 183);
            this.btnUpData.Name = "btnUpData";
            this.btnUpData.Size = new System.Drawing.Size(78, 78);
            this.btnUpData.TabIndex = 34;
            this.btnUpData.Text = "上传";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(159, 183);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(78, 78);
            this.btnExit.TabIndex = 32;
            this.btnExit.Text = "退   出";
            // 
            // bntBack
            // 
            this.bntBack.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.bntBack.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.bntBack.ForeColor = System.Drawing.Color.White;
            this.bntBack.Location = new System.Drawing.Point(159, 104);
            this.bntBack.Name = "bntBack";
            this.bntBack.Size = new System.Drawing.Size(78, 78);
            this.bntBack.TabIndex = 31;
            this.bntBack.Text = "返修";
            // 
            // btnBatch
            // 
            this.btnBatch.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnBatch.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnBatch.ForeColor = System.Drawing.Color.White;
            this.btnBatch.Location = new System.Drawing.Point(80, 104);
            this.btnBatch.Name = "btnBatch";
            this.btnBatch.Size = new System.Drawing.Size(78, 78);
            this.btnBatch.TabIndex = 35;
            this.btnBatch.Text = "批次";
            // 
            // btnDnData
            // 
            this.btnDnData.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnDnData.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnDnData.ForeColor = System.Drawing.Color.White;
            this.btnDnData.Location = new System.Drawing.Point(1, 183);
            this.btnDnData.Name = "btnDnData";
            this.btnDnData.Size = new System.Drawing.Size(78, 78);
            this.btnDnData.TabIndex = 33;
            this.btnDnData.Text = "下载";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmMain";
            this.Text = "主界面";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmMain_KeyPress);
            this.panel1.ResumeLayout(false);
            this.pBottom.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tTime;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timerDownLoad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pBottom;
        private System.Windows.Forms.Label lblDevice;
        private System.Windows.Forms.Label lblStation;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnUpData;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button bntBack;
        private System.Windows.Forms.Button btnBatch;
        private System.Windows.Forms.Button btnDnData;
    }
}