using DSGTestNet.Comm;
using DSGTestNet.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSGTestNet.FrmV12
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            _modPublic = new ModPublic();
            _frmInfo = new Frms.FrmInfo();
            inputCode = new Dictionary<string, string>();
            _context = SynchronizationContext.Current;
            leftCont = new CVT520();
            leftCont.DataReceived += LeftCont_DataReceived;
            rightCont = new CVT520();
            rightCont.DataReceived += RightCont_DataReceived;
            oIOCard = new IOCard();
        }

        ModPublic _modPublic = null;
        Frms.FrmInfo _frmInfo = null;
        SynchronizationContext _context = null;
        CVT520 leftCont =null ;
        CVT520 rightCont = null;
        IOCard oIOCard = null;

        /// <summary>
        /// 鼠标按下左键是的坐标点
        /// </summary>
        Point _mousePoint = new Point();
        Dictionary<string, string> inputCode = null;

        bool BreakFlag = false;
        bool barCodeFlag = false;
        bool testEndDelyed = false;
        bool flag = false;

        string TestCode = string.Empty;
        string VINCode = string.Empty;
        string MTOCCode = string.Empty;

        short TestStateFlag = 0;

        // 信号灯相关控制参数（io信号输出端口）
        short Lamp_GreenFlash_IOPort;
        short Lamp_GreenLight_IOPort;
        short Lamp_YellowLight_IOPort;
        short Lamp_YellowFlash_IOPort;
        short Lamp_RedLight_IOPort;
        short Lamp_RedFlash_IOPort;
        short Lamp_Buzzer_IOPort;

        #region 方法

        /// <summary>
        /// 处理扫描枪信息
        /// </summary>
        async Task SetCode(SerialPort serial, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (BreakFlag || serial == null)
                    return;
                
                Thread.Sleep(100);
                string tmp = serial.ReadExisting();
                if (string.IsNullOrEmpty(tmp))
                    return;
                TestCode = tmp;
                if (TestCode.Length >= 17)
                {
                    switch (TestCode.Substring(0, 17))
                    {
                        case "R010000000000000C":
                            HelperLogWrete.Info("扫描重置条码");
                            await resetList();
                            return;
                        case "R020000000000000C":
                            barCodeFlag = true;
                            return;
                    }
                }
                Debug.Print(TestCode);
                txtVin_KeyUp(txtVin, new KeyEventArgs(Keys.Enter));
                txtInputVIN.Text = "手工录入VIN，回车确认";
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error($"处理扫描枪信息异常！{serial.PortName }", ex);
            }
        }

        /// <summary>
        /// 处理控制器信息
        /// </summary>
        /// <param name="serial"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        void SetCont(CVT520 serial, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (BreakFlag || serial == null)
                    return;

                Thread.Sleep(100);
                byte[] data = new byte[serial.BytesToRead];
                serial.Read(data, 0, data.Length);
                var strby = BitConverter.ToString(data);
                switch (strby)
                {
                    case "FF-05-00-01-FF-00-C8-24":// 测量成功，状态属性设为1
                        serial.Status = 1;
                        break;
                    case "FF-05-00-02-FF-00-38-24":// 清空结果成功，状态属性设为3
                        serial.Status = 3;
                        break;
                    default:
                        string subBy = strby.Length >= 8 ? strby.Substring(0, 8) : string.Empty;
                        switch (subBy)
                        {
                            case "FF-03-DC":
                                serial.Status = 2;// 结果读取成功，状态属性设为2
                                System.IO.MemoryStream memory = new System.IO.MemoryStream(data);
                                System.IO.BinaryReader read = new System.IO.BinaryReader(memory);
                                read.ReadBytes(11); // 11
                                int pre = read.ReadInt32() / 1000; // 15 压力值
                                read.ReadBytes(2); // 17
                                int tem = read.ReadInt16() / 100; // 19 温度
                                read.ReadBytes(2); // 21
                                int acsp = read.ReadInt16(); // 23 加速度
                                string id = BitConverter.ToString(read.ReadBytes(4)).Replace("-", ""); // 27 id
                                read.ReadBytes(4); // 31
                                string bat = BitConverter.ToString(read.ReadBytes(2)); // 33 电池
                                bat = bat == "4F-4B" ? "OK" : "Low";
                                break;
                            default:
                                serial.Status = 0; // 操作失败，状态属性设为0
                                break;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error($"处理扫描枪信息异常！{serial.PortName }", ex);
            }
        }

        /// <summary>
        /// 系统重置，即复位
        /// </summary>
        async Task resetList()
        {
            if (BreakFlag)
                return;

            VINCode = string.Empty;
            MTOCCode = string.Empty;
            await SqlServers.Service_vincoll.Deleteable();
            inputCode.Clear();
            List1.Items.Clear();
            _context.Send(Object => { _frmInfo.ListOutput.Items.Clear(); }, null);

            if (testEndDelyed == false && TestStateFlag != -1)
                TestStateFlag = 9999;
            if (TestStateFlag != -1)
            {
                await SqlServers.Service_runstate.InitRunState();
                HelperLogWrete.Info($"测试完成：{txtVin.Text.Trim()}");
                HelperLogWrete.Info("============================================================");
            }

            txtVin.Text = string.Empty;
            setFrm(9999);
            await SqlServers.Service_runstate.UpdateableState(TestStateFlag);
            _context.Send(Object => { _frmInfo.labNext.Text = string.Empty; }, null);

            // 初始化排产队列信息
            string tmpVin = await SqlServers.Service_runstate.QueryableVIN();
            int uw5 = await SqlServers.Service_vinlist.QueryableFirst(tmpVin);
            var vins = await SqlServers.Service_vinlist.QueryableVINs(uw5 - 1);
            _context.Send(Object => { _frmInfo.ListInput.Items.Clear(); }, null);
            if (vins != null && vins.Count > 0)
            {
                foreach (string item in vins)
                {
                    var tmpItem = item.Length > 7 ? item.Substring(item.Length - 8, 8) : item;
                    _context.Send(Object => { _frmInfo.ListInput.Items.Add(tmpItem); }, null);
                }
            }
            if (_frmInfo.ListInput.Items.Count > 0)
                _context.Send(Object => { _frmInfo.labNext.Text = _frmInfo.ListInput.Items[0].ToString(); }, null);

            // 关闭灯
            oIOCard.OutputController(Lamp_GreenFlash_IOPort, false); // 关闭绿色闪烁
            oIOCard.OutputController(Lamp_YellowLight_IOPort, false); // 关闭黄色
            oIOCard.OutputController(Lamp_YellowFlash_IOPort, false); // 关闭黄色闪烁
            oIOCard.OutputController(Lamp_RedLight_IOPort, false); // 关闭红色
            oIOCard.OutputController(Lamp_RedFlash_IOPort, false); // 关闭红色闪烁
            oIOCard.OutputController(Lamp_GreenLight_IOPort, true);
            oIOCard.OutputController(Lamp_Buzzer_IOPort, false);
        }

        void setFrm(int state)
        {
            switch (state)
            {
                case -1:
                    AddMessage("等待扫描车辆进入工位!");
                    initFrom(false);
                    break;
                case 0:
                    AddMessage("条码扫描通过等待车辆进入工位,开始测试!");
                    HelperLogWrete.Info("条码扫描通过等待车辆进入工位,开始测试!");
                    initFrom(false);
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 9994:
                    break;
                case 9995:
                    break;
                case 9996:
                    break;
                case 9997:
                    break;
                case 9999:
                    AddMessage("等待扫描VIN，开始测试!");
                    initFrom(true);
                    break;
            }
        }

        void AddMessage(string txt, bool isAlert = false)
        {
            _context.Send(Object =>
            {
                ListMsg.Items.Add($"[{DateTime.Now}]{txt}");
                _frmInfo.txtInfo.Text = txt;
            }, null);
        }
        void initFrom(bool isInitVin)
        {
            picLF.Image = ImageList.Images[6];
            picLR.Image = ImageList.Images[6];
            picRF.Image = ImageList.Images[6];
            picRR.Image = ImageList.Images[6];

            txtLR.Text = "";
            lbLRMdl.Text = "";
            lbLRPre.Text = "";
            lbLRTemp.Text = "";
            lbLRBattery.Text = "";
            lbLRAcSpeed.Text = "";

            txtLF.Text = "";
            lbLFMdl.Text = "";
            lbLFPre.Text = "";
            lbLFTemp.Text = "";
            lbLFBattery.Text = "";
            lbLFAcSpeed.Text = "";

            txtRR.Text = "";
            lbRRMdl.Text = "";
            lbRRPre.Text = "";
            lbRRTemp.Text = "";
            lbRRBattery.Text = "";
            lbRRAcSpeed.Text = "";

            txtRF.Text = "";
            lbRFMdl.Text = "";
            lbRFPre.Text = "";
            lbRFTemp.Text = "";
            lbRFBattery.Text = "";
            lbRFAcSpeed.Text = "";

            _context.Send(Object =>
            {
                _frmInfo.picLF.Image = ImageList.Images[6];
                _frmInfo.picLR.Image = ImageList.Images[6];
                _frmInfo.picRF.Image = ImageList.Images[6];
                _frmInfo.picRR.Image = ImageList.Images[6];

                _frmInfo.txtLR.Text = "";
                _frmInfo.lbLRMdl.Text = "";
                _frmInfo.lbLRPre.Text = "";
                _frmInfo.lbLRTemp.Text = "";
                _frmInfo.lbLRBattery.Text = "";
                _frmInfo.lbLRAcSpeed.Text = "";

                _frmInfo.txtLF.Text = "";
                _frmInfo.lbLFMdl.Text = "";
                _frmInfo.lbLFPre.Text = "";
                _frmInfo.lbLFTemp.Text = "";
                _frmInfo.lbLFBattery.Text = "";
                _frmInfo.lbLFAcSpeed.Text = "";

                _frmInfo.txtRR.Text = "";
                _frmInfo.lbRRMdl.Text = "";
                _frmInfo.lbRRPre.Text = "";
                _frmInfo.lbRRTemp.Text = "";
                _frmInfo.lbRRBattery.Text = "";
                _frmInfo.lbRRAcSpeed.Text = "";

                _frmInfo.txtRF.Text = "";
                _frmInfo.lbRFMdl.Text = "";
                _frmInfo.lbRFPre.Text = "";
                _frmInfo.lbRFTemp.Text = "";
                _frmInfo.lbRFBattery.Text = "";
                _frmInfo.lbRFAcSpeed.Text = "";

                _frmInfo.labVin.Text = "胎压检测初始化系统";
            }, null);

            if (isInitVin)
            {
                txtVin.Text = "";
                _context.Send(Object => { _frmInfo.labVin.Text = "胎压检测初始化系统"; }, null);
            }
        }
        #endregion

        /// <summary>
        /// 窗体移动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmInfo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _mousePoint = e.Location;
        }
        private void FrmInfo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = e.X - _mousePoint.X;
                int y = e.Y - _mousePoint.Y;
                Location = Point.Add(Location, new Size(x, y));
            }
        }

        /// <summary>
        /// 右侧控制器串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RightCont_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var serial = sender as CVT520;
            if (serial == null)
                return;
            SetCont(serial, e);
        }

        /// <summary>
        /// 左侧控制器串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeftCont_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var serial = sender as CVT520;
            if (serial == null)
                return;
            SetCont(serial, e);
        }

        /// <summary>
        /// 无线条码枪通信
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void MSCommBTO_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var serial = sender as SerialPort;
            if (serial == null)
                return;
            await SetCode(serial, e);
        }

        /// <summary>
        /// 处理有线扫描枪的扫描信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void MSComVINO_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var serial = sender as SerialPort;
            if (serial == null)
                return;
            await SetCode(serial, e);
        }

        /// <summary>
        /// 首次加载窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void FrmMain_Load(object sender, EventArgs e)
        {
            _frmInfo.Show();

            // CVT520控制器串口
            string lfName = await SqlServers.Service_T_CtrlParam.GetValue("LVT520", "LVT520_PortNum");
            string lfSetting = await SqlServers.Service_T_CtrlParam.GetValue("LVT520", "LVT520_Settings");
            _modPublic.OpenSerialPort(leftCont, lfName, lfSetting, "leftCont");
            string rgName = await SqlServers.Service_T_CtrlParam.GetValue("RVT520", "RVT520_PortNum");
            string rgSetting = await SqlServers.Service_T_CtrlParam.GetValue("RVT520", "RVT520_Settings");
            _modPublic.OpenSerialPort(rightCont, rgName, rgSetting, "rightCont");

            // 扫描枪串口
            string btName = await SqlServers.Service_T_CtrlParam.GetValue("BarCodeGun", "WirlessCodeGun_PortNum");
            string btSetting = await SqlServers.Service_T_CtrlParam.GetValue("BarCodeGun", "WirlessCodeGun_Settings");
            _modPublic.OpenSerialPort(MSCommBTO, btName, btSetting, "MSCommBTO");

            string vinName = await SqlServers.Service_T_CtrlParam.GetValue("BarCodeGun", "WirledCodeGun_PortNum");
            string vinSetting = await SqlServers.Service_T_CtrlParam.GetValue("BarCodeGun", "WirledCodeGun_Settings");
            _modPublic.OpenSerialPort(MSComVINO, vinName, vinSetting, "MSComVINO");
        }

        /// <summary>
        /// 退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picExit_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            Environment.Exit(0);
        }

        /// <summary>
        /// 清除条码信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInputVIN_Click(object sender, EventArgs e)
        {
            txtInputVIN.Text = string.Empty;
        }

        /// <summary>
        /// 处理条码信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void txtInputVIN_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                string tmp = txtInputVIN.Text.Trim();
                if (string.IsNullOrEmpty(tmp))
                    return;
                TestCode = tmp;
                if (TestCode.Length >= 17)
                {
                    switch (TestCode.Substring(0, 17))
                    {
                        case "R010000000000000C":
                            HelperLogWrete.Info("扫描重置条码");
                            await resetList();
                            return;
                        case "R020000000000000C":
                            barCodeFlag = true;
                            return;
                    }
                }
                Debug.Print(TestCode);
                txtVin_KeyUp(txtVin, new KeyEventArgs(Keys.Enter));
                txtInputVIN.Text = "手工录入VIN，回车确认";
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("处理条码信息异常！", ex);
            }
        }

        /// <summary>
        /// 处理条码信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtVin_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Frms.SerialPortTest().Show();
        }
    }
}
