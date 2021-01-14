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
    public partial class FrmMain : DSGTestSL.FrmMain
    {
        public FrmMain()
        {
            InitializeComponent();
            //MSCommBTO.Open();
            //MSComVINO.Open();
        }

        FrmDef.FrmInfo frmInfo = new FrmDef.FrmInfo();

        /// <summary>
        /// 无线条码枪通信
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MSCommBTO_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                var serial = sender as SerialPort;
                if (serial == null || base.BreakFlag)
                    return;

                Thread.Sleep(100);
                base.TestCode = serial.ReadExisting();
                if (string.IsNullOrEmpty(base.TestCode))
                    return;

                if (base.TestCode.Length >= 17)
                {
                    var subCode = base.TestCode.Substring(0, 17);
                    switch (subCode)
                    {
                        case "R010000000000000C"://重置条码
                            HelperLogWrete.Info("0扫描重置条码");
                            base.resetList();
                            return;
                        case "R020000000000000C"://强制输入条码
                            HelperLogWrete.Info("扫描强制输入条码");
                            base.barCodeFlag = true;
                            return;
                    }
                }
                Debug.Print(base.TestCode);
                base.txtVIN_KeyPress(base.txtVin, new KeyPressEventArgs(Convert.ToChar(13)));
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("蓝牙扫描枪通信错误", ex);
            }
           
        }

        /// <summary>
        /// 处理有线扫描枪的扫描信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MSComVINO_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                var serial = sender as SerialPort;
                if (serial == null || base.BreakFlag)
                    return;

                Thread.Sleep(100);
                base.TestCode = serial.ReadExisting();
                if (string.IsNullOrEmpty(base.TestCode))
                    return;

                if (base.TestCode.Length >= 17)
                {
                    var subCode = base.TestCode.Substring(0, 17);
                    switch (subCode)
                    {
                        case "R010000000000000C"://重置条码
                            HelperLogWrete.Info("1扫描重置条码");
                            base.resetList();
                            return;
                        case "R020000000000000C"://强制输入条码
                            HelperLogWrete.Info("扫描强制输入条码");
                            base.barCodeFlag = true;
                            return;
                    }
                }
                Debug.Print(base.TestCode);
                base.txtVIN_KeyPress(base.txtVin, new KeyPressEventArgs(Convert.ToChar(13)));
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("蓝牙扫描枪通信错误", ex);
            }
        }

        /// <summary>
        /// 首次加载窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void FrmMain_Load(object sender, EventArgs e)
        {
            DSGTestSL.modPublic.Main();
            base.isInTesting = false;
            base.osen0Time = string.Empty;
            base.tmpTime = DateTime.Now.AddSeconds(-30).ToString("yyyyMMdd HH:mm:ss");
            base.barCodeFlag = false;
            frmInfo.Show();
            base.initFrom(true);
            // 排产队列同步周期
            short.TryParse(await SqlComm.getConfigValue("T_RunParam", "Timer", "TimerDataSync"), out base.TimerN);
            // 系统状态栏检查周期
            short.TryParse(await SqlComm.getConfigValue("T_RunParam", "Timer", "TimerStatus"), out base.TimerStatus);
            // 数据库所在盘符
            base.DBPosition = await SqlComm.getConfigValue("T_RunParam", "Status", "DBPosition");
            // 数据库所在硬盘可用空间下限
            int.TryParse(await SqlComm.getConfigValue("T_RunParam", "Status", "SpaceAvailable"), out base.SpaceAvailable);

            // 是否带DSG
            bool.TryParse(await SqlComm.readState("test"), out bool testFlag);
            short.TryParse(await SqlComm.readState("state"), out base.TestStateFlag);
            // 如果带DSG系统并且未检测完成，先加载已检测了的数据
            if (testFlag && base.TestStateFlag !=9999)
            {
                base.car = DSGTestSL.modPublic.getRunStateCar();
                base.txtVin.Text = base.car.VINCode;
            }

            // 如果已检测完成，则从数据库中加载VIN
            if (base.TestStateFlag > 9000 && base.TestStateFlag < 9999 || base.TestStateFlag == -1)
            {
                base.txtVin.Text = await SqlComm.readState("vin");
            }
            var subVin = base.txtVin.Text.Trim();
            if (subVin.Length > +8)
            {
                frmInfo.labNow.Text = subVin.Substring(subVin.Length - 8, 8);
            }
            frmInfo.labVin.Text = base.txtVin.Text.Trim();
            base.setFrm(ref base.TestStateFlag);
            base.Step1Time = 4;
            base.Step2Time = 4;
            base.Step3Time = 4;
            base.Step4Time = 4;
            await SqlComm.updateState("state", TestStateFlag.ToString());
            inputCode = new Scripting.Dictionary();

            base.osensorCommand = DSGTestSL.modPublic.sensorCommand;
            bool bl = osensorCommand.state;
            base.osensorCommand_onChange(ref bl);

            // 传感器
            osensor0 = DSGTestSL.modPublic.sensor0;
            osensor1 = DSGTestSL.modPublic.sensor1;
            osensor2 = DSGTestSL.modPublic.sensor2;
            osensor3 = DSGTestSL.modPublic.sensor3;
            osensor4 = DSGTestSL.modPublic.sensor4;
            osensor5 = DSGTestSL.modPublic.sensor5;
            osensorLine = DSGTestSL.modPublic.sensorLine; // 停线事件
            oRDCommand = DSGTestSL.modPublic.rdResetCommandS; // 系统复位事件
            Thread.Sleep(1000);

            sensorFlag = osensorLine.state;
            sensorControlFlag = false; //传动链状态,False表示没有锁
            testEndDelyed = false; // 此标示与TestStateFlag=-1联合使用
            initDictionary();
            iniListInput();
            flashLamp(ref DSGTestSL.modPublic.Lamp_GreenLight_IOPort);
        }
    }
}
