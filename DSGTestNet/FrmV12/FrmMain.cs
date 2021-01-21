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
            leftCont = new SerialPort();
            leftCont.DataReceived += LeftCont_DataReceived;
            rightCont = new SerialPort();
            rightCont.DataReceived += RightCont_DataReceived;
        }

        ModPublic _modPublic = null;
        Frms.FrmInfo _frmInfo = null;
        SynchronizationContext _context = null;
        SerialPort leftCont =null ;
        SerialPort rightCont = null;

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
        async Task SetCont(SerialPort serial, SerialDataReceivedEventArgs e)
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
                        break;
                    case "FF-05-00-02-FF-00-38-24":// 清空结果成功，状态属性设为3
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
           
        }

        void setFrm(int testStateFlag)
        { 
        
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
        private async void RightCont_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var serial = sender as SerialPort;
            if (serial == null)
                return;
            await SetCont(serial, e);
        }

        /// <summary>
        /// 左侧控制器串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void LeftCont_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var serial = sender as SerialPort;
            if (serial == null)
                return;
            await SetCont(serial, e);
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

        private void txtInputVIN_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var frm =new  Frms.SerialPortTest();
                frm.Show();
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
    }
}
