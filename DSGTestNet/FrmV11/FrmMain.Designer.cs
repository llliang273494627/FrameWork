
namespace DSGTestNet.FrmV11
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.MSComVINO = new System.IO.Ports.SerialPort(this.components);
            this.MSCommBTO = new System.IO.Ports.SerialPort(this.components);
            this.frErrorText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Picture10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicNet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCommandReset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCommandConifg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCommandOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCommandLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCommandHis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture4)).BeginInit();
            this.SuspendLayout();
            // 
            // txtVin
            // 
            this.txtVin.Text = "T020000000000000C";
            // 
            // ListMsg
            // 
            this.ListMsg.Items.AddRange(new object[] {
            "[2021/1/14 17:19:05]等待扫描车辆进入工位!",
            "[2021/1/14 17:19:05]系统已解锁！",
            "[2021/1/14 17:19:05]等待扫描车辆进入工位!",
            "[2021/1/14 8:49:39]等待扫描车辆进入工位!",
            "[2021/1/14 8:49:39]系统已解锁！",
            "[2021/1/14 8:49:39]等待扫描车辆进入工位!",
            "[2021/1/13 17:56:06]等待扫描车辆进入工位!",
            "[2021/1/13 17:56:06]系统已解锁！",
            "[2021/1/13 17:56:06]等待扫描车辆进入工位!",
            "[2021/1/13 17:07:21]等待扫描车辆进入工位!",
            "[2021/1/13 17:07:21]系统已解锁！",
            "[2021/1/13 17:07:21]等待扫描车辆进入工位!",
            "[2021/1/13 16:57:58]等待扫描车辆进入工位!",
            "[2021/1/13 16:57:58]系统已解锁！",
            "[2021/1/13 16:57:58]等待扫描车辆进入工位!"});
            // 
            // picRF
            // 
            this.picRF.Image = ((System.Drawing.Image)(resources.GetObject("picRF.Image")));
            // 
            // picRR
            // 
            this.picRR.Image = ((System.Drawing.Image)(resources.GetObject("picRR.Image")));
            // 
            // picLF
            // 
            this.picLF.Image = ((System.Drawing.Image)(resources.GetObject("picLF.Image")));
            // 
            // picLR
            // 
            this.picLR.Image = ((System.Drawing.Image)(resources.GetObject("picLR.Image")));
            // 
            // lbRFAcSpeed
            // 
            this.lbRFAcSpeed.Text = "";
            // 
            // lbRFBattery
            // 
            this.lbRFBattery.Text = "";
            // 
            // lbRFMdl
            // 
            this.lbRFMdl.Text = "";
            // 
            // lbRFPre
            // 
            this.lbRFPre.Text = "";
            // 
            // lbRFTemp
            // 
            this.lbRFTemp.Text = "";
            // 
            // lbRRTemp
            // 
            this.lbRRTemp.Text = "";
            // 
            // lbRRPre
            // 
            this.lbRRPre.Text = "";
            // 
            // lbRRMdl
            // 
            this.lbRRMdl.Text = "";
            // 
            // lbRRBattery
            // 
            this.lbRRBattery.Text = "";
            // 
            // lbRRAcSpeed
            // 
            this.lbRRAcSpeed.Text = "";
            // 
            // lbLFTemp
            // 
            this.lbLFTemp.Text = "";
            // 
            // lbLFPre
            // 
            this.lbLFPre.Text = "";
            // 
            // lbLFMdl
            // 
            this.lbLFMdl.Text = "";
            // 
            // lbLFBattery
            // 
            this.lbLFBattery.Text = "";
            // 
            // lbLFAcSpeed
            // 
            this.lbLFAcSpeed.Text = "";
            // 
            // lbLRAcSpeed
            // 
            this.lbLRAcSpeed.Text = "";
            // 
            // lbLRBattery
            // 
            this.lbLRBattery.Text = "";
            // 
            // lbLRMdl
            // 
            this.lbLRMdl.Text = "";
            // 
            // lbLRPre
            // 
            this.lbLRPre.Text = "";
            // 
            // lbLRTemp
            // 
            this.lbLRTemp.Text = "";
            // 
            // MSComVINO
            // 
            this.MSComVINO.PortName = "COM252";
            this.MSComVINO.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.MSComVINO_DataReceived);
            // 
            // MSCommBTO
            // 
            this.MSCommBTO.PortName = "COM252";
            this.MSCommBTO.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.MSCommBTO_DataReceived);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1024, 779);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.frErrorText.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Picture10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicNet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCommandReset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCommandConifg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCommandOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCommandLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCommandHis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort MSComVINO;
        private System.IO.Ports.SerialPort MSCommBTO;
    }
}