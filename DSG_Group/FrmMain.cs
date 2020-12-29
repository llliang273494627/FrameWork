using DSG_Group.DGComm;
using DSG_Group.SqlServers;
using FrameWork.Model.DFPV_DSG101;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSG_Group
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        frmInfo _frmInfo = new frmInfo();
        string VINCode = string.Empty;
        /// <summary>
        /// 条码储存对象
        /// </summary>
        Dictionary<string, string> inputCode = new Dictionary<string, string>();
        int TestStateFlag = -1;
        bool testEndDelyed = false;

        // 信号灯相关控制参数（io信号输出端口）
        int Lamp_GreenFlash_IOPort;
        int Lamp_GreenLight_IOPort;
        int Lamp_YellowLight_IOPort;
        int Lamp_YellowFlash_IOPort;
        int Lamp_RedLight_IOPort;
        int Lamp_RedFlash_IOPort;
        int Lamp_Buzzer_IOPort;

        /// <summary>
        /// 设置窗体
        /// </summary>
        void setFrm(int state)
        {
            if (state == -1)
            { }
            else if (state == 9999)
            {
                AddMessage("等待扫描VID，开始测试!");
                initFrom(true);
            }
            else if (state > 9000 && state < 9999)
            {

            }
            else
            {

            }
        }

        void AddMessage(string msg, bool isAlert = false)
        {
            if (ListMsg.Items.Count > 20)
                ListMsg.Items.Remove(0);

            ListMsg.Items.Add($"[{DateTime.Now}]:{msg}");
            _frmInfo.txtInfo.ForeColor = isAlert ? Color.Red : Color.Blue;
            _frmInfo.txtInfo.Text = msg;
            HelperLogWrete.Info(msg);
        }

        void initFrom(bool isInitVin)
        {
            // 左后轮
            picLR.Image = ImageList.Images[0];
            txtLR.Text = string.Empty;
            lbLRMdl.Text = string.Empty;
            lbLRPre.Text = string.Empty;
            lbLRTemp.Text = string.Empty;
            lbLRBattery.Text = string.Empty;
            lbLRAcSpeed.Text = string.Empty;
            _frmInfo.picLR.Image = ImageList.Images[0];
            _frmInfo.txtLR.Text = string.Empty;
            _frmInfo.lbLRMdl.Text = string.Empty;
            _frmInfo.lbLRPre.Text = string.Empty;
            _frmInfo.lbLRTemp.Text = string.Empty;
            _frmInfo.lbLRBattery.Text = string.Empty;
            _frmInfo.lbLRAcSpeed.Text = string.Empty;

            // 左前轮
            picLF.Image = ImageList.Images[0];
            txtLF.Text = string.Empty;
            lbLFMdl.Text = string.Empty;
            lbLFPre.Text = string.Empty;
            lbLFTemp.Text = string.Empty;
            lbLFBattery.Text = string.Empty;
            lbLFAcSpeed.Text = string.Empty;
            _frmInfo.picLF.Image = ImageList.Images[0];
            _frmInfo.txtLF.Text = string.Empty;
            _frmInfo.lbLFMdl.Text = string.Empty;
            _frmInfo.lbLFPre.Text = string.Empty;
            _frmInfo.lbLFTemp.Text = string.Empty;
            _frmInfo.lbLFBattery.Text = string.Empty;
            _frmInfo.lbLFAcSpeed.Text = string.Empty;

            // 右后轮
            picRR.Image = ImageList.Images[0];
            txtRR.Text = string.Empty;
            lbRRMdl.Text = string.Empty;
            lbRRPre.Text = string.Empty;
            lbRRTemp.Text = string.Empty;
            lbRRBattery.Text = string.Empty;
            lbRRAcSpeed.Text = string.Empty;
            _frmInfo.picRR.Image = ImageList.Images[0];
            _frmInfo.txtRR.Text = string.Empty;
            _frmInfo.lbRRMdl.Text = string.Empty;
            _frmInfo.lbRRPre.Text = string.Empty;
            _frmInfo.lbRRTemp.Text = string.Empty;
            _frmInfo.lbRRBattery.Text = string.Empty;
            _frmInfo.lbRRAcSpeed.Text = string.Empty;

            // 右前轮
            picRF.Image = ImageList.Images[0];
            txtRF.Text = string.Empty;
            lbRFMdl.Text = string.Empty;
            lbRFPre.Text = string.Empty;
            lbRFTemp.Text = string.Empty;
            lbRFBattery.Text = string.Empty;
            lbRFAcSpeed.Text = string.Empty;
            _frmInfo.picRF.Image = ImageList.Images[0];
            _frmInfo.txtRF.Text = string.Empty;
            _frmInfo.lbRFMdl.Text = string.Empty;
            _frmInfo.lbRFPre.Text = string.Empty;
            _frmInfo.lbRFTemp.Text = string.Empty;
            _frmInfo.lbRFBattery.Text = string.Empty;
            _frmInfo.lbRFAcSpeed.Text = string.Empty;

            if (isInitVin)
            {
                txtVin.Text = string.Empty;
                _frmInfo.labVin.Text = string.Empty;
            }
        }

        void closeAll()
        {
            NoController.OutputController(Lamp_GreenLight_IOPort, false);// 关闭绿色
            NoController.OutputController(Lamp_GreenFlash_IOPort, false);// 关闭绿色闪烁
            NoController.OutputController(Lamp_YellowLight_IOPort, false);// 关闭黄色
            NoController.OutputController(Lamp_YellowFlash_IOPort, false);// 关闭黄色闪烁
            NoController.OutputController(Lamp_RedLight_IOPort, false);// 关闭红色
            NoController.OutputController(Lamp_RedFlash_IOPort, false);// 关闭红色闪烁
        }


        /// <summary>
        /// 系统配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bntSystemSetting_Click(object sender, EventArgs e)
        {
            var frm = new frmPSW();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var frmoption = new frmOption();
                frmoption.ShowDialog();
            }
        }

        /// <summary>
        /// 系统复位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void bntSystemClear_Click(object sender, EventArgs e)
        {
            try
            {
                HelperLogWrete.Info("系统复位");
                VINCode = string.Empty;
                HelperLogWrete.Info("初始化表");
                await Servicevincoll.Deleteable();
                HelperLogWrete.Info("初始化扫描队列信息");
                inputCode.Clear();
                List1.Items.Clear();
                _frmInfo.ListOutput.Items.Clear();
                ListOutput1.Items.Clear();
                var vins = await Servicevincoll.Queryable();
                foreach (var item in vins)
                {
                    string tmpStr = item.Substring(0, 17);
                    inputCode.Add(tmpStr, item);
                    List1.Items.Add(tmpStr);
                    _frmInfo.ListOutput.Items.Add(tmpStr);
                    ListOutput1.Items.Add(tmpStr.Substring(tmpStr.Length - 8, 8));
                }
                if (testEndDelyed == false && TestStateFlag != -1)
                    TestStateFlag = 9999;
                if (TestStateFlag != -1)
                {
                    int k = await Servicerunstate.InitRunState();
                    HelperLogWrete.Info($"{txtVin.Text.Trim()}：测试完成，重置runstate表记录数：{k}");
                }
                txtVin.Text = string.Empty;
                setFrm(9999);
                int cont = await Servicerunstate.UpdateableState(TestStateFlag);
                _frmInfo.labNow.Text = string.Empty;
                
                closeAll();
                NoController.OutputController(Lamp_GreenLight_IOPort, true);
                NoController.OutputController(Lamp_Buzzer_IOPort, false);// 关闭蜂鸣

                // 隐藏面板
                frErrorText.Visible = false;
                // 重置提示板
                ListMsg.Items.Clear();

                closeAll();
                NoController.OutputController(Lamp_Buzzer_IOPort, false);// 关闭蜂鸣
                NoController.OutputController(Lamp_GreenFlash_IOPort, true);// 绿灯

            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("系统复位异常！", ex);
            }
        }
    }
}
