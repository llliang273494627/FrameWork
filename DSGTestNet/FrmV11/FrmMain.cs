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

namespace DSGTestNet.FrmV11
{
    public partial class FrmMain : DSGTestVB.FrmMain
    {
        public FrmMain()
        {
            InitializeComponent();
            _modPublic = new Comm.ModPublic();
        }

        ModPublic _modPublic = null;

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
                            base.resetList();
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

        private async void FrmMain_Load(object sender, EventArgs e)
        {
            DSGTestVB.modPublic.Main();
            // Add by ZCJ 2012-07-09 初始化测试状态
            isInTesting = false;
            osen0Time = "";
            // Add by ZCJ 2012-07-09 初始化间隔时间
            tmpTime = DateTime.Now.AddSeconds(-30).ToString("yyyyMMdd HH:mm:ss");
            barCodeFlag = false;
            bool bl = true;
            initFrom(ref bl);
            // 是否带DSG
            bool.TryParse(await SqlComm.readState("test"), out bool testFlag);
            short.TryParse(await SqlComm.readState("state"), out base.TestStateFlag);

            // 系统状态栏检查周期
            short.TryParse(await SqlComm.getConfigValue("T_RunParam", "Timer", "TimerStatus"), out TimerStatus);
            // 数据库所在盘符
            DBPosition = await SqlComm.getConfigValue("T_RunParam", "Status", "DBPosition");
            // 数据库所在硬盘可用空间下限
            int.TryParse(await SqlComm.getConfigValue("T_RunParam", "Status", "SpaceAvailable"), out SpaceAvailable);

            // 胎压检测结果上传周期
            short.TryParse(await SqlComm.getConfigValue("T_RunParam", "Timer", "TimerResultUpLoad"), out TimerResultUpLoad);
            // 如果带DSG系统并且未检测完成，先加载已检测了的数据
            if (testFlag && base.TestStateFlag != 9999)
            {
                car = DSGTestVB.modPublic.getRunStateCar();
                txtVin.Text = base.car.VINCode;
            }

            // 如果已检测完成，则从数据库中加载VIN
            if (base.TestStateFlag > 9000 && base.TestStateFlag < 9999 || base.TestStateFlag == -1)
            {
                txtVin.Text = await SqlComm.readState("vin");
            }

            setFrm(ref TestStateFlag);
            short.TryParse(await SqlComm.getConfigValue("T_CtrlParam", "StepTime", "Step1Time"), out Step1Time);
            short.TryParse(await SqlComm.getConfigValue("T_CtrlParam", "StepTime", "Step2Time"), out Step2Time);
            short.TryParse(await SqlComm.getConfigValue("T_CtrlParam", "StepTime", "Step3Time"), out Step3Time);
            short.TryParse(await SqlComm.getConfigValue("T_CtrlParam", "StepTime", "Step4Time"), out Step4Time);
            await SqlComm.updateState("state", TestStateFlag.ToString());

            // 条码对象集合
            inputCode = new Scripting.Dictionary();

            // Modiy by ZCJ 2012-07-09 将解锁事件移动至此处
            osensorCommand = DSGTestVB.modPublic.sensorCommand;// 解锁事件
            bl = true;
            osensorCommand_onChange(ref bl);

            // 传感器
            osensor0 = DSGTestVB.modPublic.sensor0;
            osensor1 = DSGTestVB.modPublic.sensor1;
            osensor2 = DSGTestVB.modPublic.sensor2;
            osensor3 = DSGTestVB.modPublic.sensor3;
            osensor4 = DSGTestVB.modPublic.sensor4;
            osensor5 = DSGTestVB.modPublic.sensor5;
            osensorLine = DSGTestVB.modPublic.sensorLine; // 停线事件
            oRDCommand = DSGTestVB.modPublic.rdResetCommandS; // 系统复位事件
            Thread.Sleep(1000);

            sensorFlag = osensorLine.state;
            sensorControlFlag = false;// 传动链状态,False表示没有锁
            testEndDelyed = false;// 此标示与TestStateFlag=-1联合使用
            initDictionary();// 初始化扫描队列
            DSGTestVB.modPublic.flashLamp(ref DSGTestVB.modPublic.Lamp_GreenLight_IOPort);

            // 打开扫描枪串口
            _modPublic.OpenSerialPort(MSComVINO, "MSComVINO");
            _modPublic.OpenSerialPort(MSCommBTO, "MSCommBTO");
        }
    }
}
