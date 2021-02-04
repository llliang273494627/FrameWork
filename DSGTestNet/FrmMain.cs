using DSGTestNet.Comm;
using DSGTestNet.Helper;
using DSGTestNet.SqlServers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSGTestNet
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            Init();
        }

        string TestCode = string.Empty;
        bool BreakFlag = false;
        bool barCodeFlag = false;
        bool testEndDelyed = false;
        bool isInTesting = false;
        bool flag = false;
        bool isCheckAllQueue = false;
        int TestStateFlag = 0;

        // 信号灯相关控制参数（io信号输出端口）
        short  Lamp_GreenFlash_IOPort = 0;
        short Lamp_GreenLight_IOPort = 0;
        short Lamp_YellowLight_IOPort = 0;
        short Lamp_YellowFlash_IOPort = 0;
        short Lamp_RedLight_IOPort = 0;
        short Lamp_RedFlash_IOPort = 0;
        short Lamp_Buzzer_IOPort = 0;
        short rdOutput = 0;

        // 传感器参数设置
        string mdlValue = string.Empty;
        string preMinValue = string.Empty;
        string preMaxValue = string.Empty;
        string tempMinValue = string.Empty;
        string tempMaxValue = string.Empty;
        string acSpeedMinValue = string.Empty;
        string acSpeedMaxValue = string.Empty;
        string mTOCStartIndex = string.Empty;
        string tPMSCodeLen = string.Empty;

        // 鼠标点击左键的坐标
        Point mousePoint = new Point();
        frmInfo frmInfo = null;
        IOCard oIOCard = null;
        CCar car = null;
        // 条码存储对象
        Dictionary<string, string> inputCode = null;

        // VT520控制相关参数
        CVT520 oLVT520 = null;
        CVT520 oRVT520 = null;

        /// <summary>
        /// 初始化数据
        /// </summary>
        void Init()
        {
            frmInfo = new frmInfo();
            inputCode = new Dictionary<string, string>();
            oIOCard = new IOCard();
            car = new CCar();
            oLVT520 = new CVT520();
            oRVT520 = new CVT520();
        }

        /// <summary>
        /// 系统重置，即复位
        /// </summary>
        async Task resetList()
        {
            if (BreakFlag)
                return;

            await Service_vincoll.Deleteable();
            await initDictionary();

            if (testEndDelyed && TestStateFlag != -1)
                TestStateFlag = 9999;
            if (TestStateFlag != -1)
            {
                await Service_runstate.InitRunState();
                HelperLogWrete.Info(txtVin.Text.Trim() + " 测试完成!");
                HelperLogWrete.Info("============================================================");
            }
            txtVin.Text = string.Empty;

            setFrm(9999);
            await Service_runstate.UpdateableState(TestStateFlag);
            frmInfo.labNow.Text = string.Empty;
            await iniListInput();

            oIOCard.OutputController(Lamp_GreenFlash_IOPort, false); // 关闭绿色闪烁
            oIOCard.OutputController(Lamp_YellowLight_IOPort, false); // 关闭黄色
            oIOCard.OutputController(Lamp_YellowFlash_IOPort, false); // 关闭黄色闪烁
            oIOCard.OutputController(Lamp_RedLight_IOPort, false); // 关闭红色
            oIOCard.OutputController(Lamp_RedFlash_IOPort, false); // 关闭红色闪烁
            oIOCard.OutputController(Lamp_GreenLight_IOPort, true);
            oIOCard.OutputController(Lamp_Buzzer_IOPort, false); // 关闭蜂鸣
        }

        /// <summary>
        /// 初始化扫描队列信息
        /// </summary>
        async Task initDictionary()
        {
            inputCode.Clear();
            List1.Items.Clear();
            frmInfo.ListOutput.Items.Clear();
            var vins = await Service_vincoll.Queryable();
            if (vins == null || vins.Count < 1)
                return;
            foreach (var item in vins)
            {
                var subItem = item.Substring(1, 16);
                inputCode.Add(subItem, item);
                List1.Items.Add(subItem);
                frmInfo.ListOutput.Items.Add(subItem.Substring(subItem.Length - 8, 8));
            }
        }

        /// <summary>
        /// 显示当前的检测状态
        /// </summary>
        /// <param name="state"></param>
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
                    if (string.IsNullOrEmpty(car.TireRFID) && car.TireRFID != "00000000")
                    {
                        showDSGInfo("RF", car.TireRFID, car.TireRFMdl, car.TireRFPre, car.TireRFTemp, car.TireRFBattery, car.TireRFAcSpeed, "Green1.jpg");
                        HelperLogWrete.Info("右前轮检测结果：" + car.TireRFID);
                        AddMessage("右前轮检测完毕");
                    }
                    else
                    {
                        if (isInTesting)
                        {
                            AddMessage("正在检测右前轮……");
                        }
                        else
                        {
                            showDSGInfo("RF", "检测失败", (car.TireRFMdl), (car.TireRFPre), (car.TireRFTemp), (car.TireRFBattery), (car.TireRFAcSpeed), "Red1.jpg");
                            HelperLogWrete.Info("右前轮检测失败");
                            AddMessage("右前轮检测失败", true);
                        }
                    }
                    break;
                case 2:
                    if (string.IsNullOrEmpty(car.TireRFID) && car.TireRFID != "00000000")
                        showDSGInfo("RF", (car.TireRFID), (car.TireRFMdl), (car.TireRFPre), (car.TireRFTemp), (car.TireRFBattery), (car.TireRFAcSpeed), "Green1.jpg");
                    else
                        showDSGInfo("RF", "检测失败", (car.TireRFMdl), (car.TireRFPre), (car.TireRFTemp), (car.TireRFBattery), (car.TireRFAcSpeed), "Red1.jpg");
                    if (string.IsNullOrEmpty(car.TireLFID) && car.TireLFID != "00000000")
                    {
                        showDSGInfo("LF", (car.TireLFID), (car.TireLFMdl), (car.TireLFPre), (car.TireLFTemp), (car.TireLFBattery), (car.TireLFAcSpeed), "Green1.jpg");
                        HelperLogWrete.Info("左前轮检测结果：" + car.TireLFID);
                        AddMessage("左前轮检测完毕");
                    }
                    else
                    {
                        if (isInTesting)
                            AddMessage("正在检测左前轮……");
                        else
                        {
                            showDSGInfo("LF", "检测失败", (car.TireLFMdl), (car.TireLFPre), (car.TireLFTemp), (car.TireLFBattery), (car.TireLFAcSpeed), "Red1.jpg");
                            HelperLogWrete.Info("左前轮检测失败");
                            AddMessage("左前轮检测失败", true);
                        }
                    }
                    break;
                case 3:
                    if (string.IsNullOrEmpty(car.TireRFID) && car.TireRFID != "00000000")
                        showDSGInfo("RF", (car.TireRFID), (car.TireRFMdl), (car.TireRFPre), (car.TireRFTemp), (car.TireRFBattery), (car.TireRFAcSpeed), "Green1.jpg");
                    else
                        showDSGInfo("RF", "检测失败", (car.TireRFMdl), (car.TireRFPre), (car.TireRFTemp), (car.TireRFBattery), (car.TireRFAcSpeed), "Red1.jpg");
                    if (string.IsNullOrEmpty(car.TireLFID) && car.TireLFID != "00000000")
                        showDSGInfo("LF", (car.TireLFID), (car.TireLFMdl), (car.TireLFPre), (car.TireLFTemp), (car.TireLFBattery), (car.TireLFAcSpeed), "Green1.jpg");
                    else
                        showDSGInfo("LF", "检测失败", (car.TireLFMdl), (car.TireLFPre), (car.TireLFTemp), (car.TireLFBattery), (car.TireLFAcSpeed), "Red1.jpg");
                    if (string.IsNullOrEmpty(car.TireRRID) && car.TireRRID != "00000000")
                    {
                        showDSGInfo("RR", (car.TireRRID), (car.TireRRMdl), (car.TireRRPre), (car.TireRRTemp), (car.TireRRBattery), (car.TireRRAcSpeed), "Green1.jpg");
                        HelperLogWrete.Info("右后轮检测结果：" + car.TireRRID);
                        AddMessage("右后轮检测完毕");
                    }
                    else
                    {
                        if (isInTesting)
                            AddMessage("正在检测右后轮……");
                        else
                        {
                            showDSGInfo("RR", "检测失败", (car.TireRRMdl), (car.TireRRPre), (car.TireRRTemp), (car.TireRRBattery), (car.TireRRAcSpeed), "Red1.jpg");
                            HelperLogWrete.Info("右后轮检测失败");
                            AddMessage("右后轮检测失败", true);
                        }
                    }
                    break;
                case 4:
                    if (string.IsNullOrEmpty(car.TireRFID) && car.TireRFID != "00000000")
                        showDSGInfo("RF", (car.TireRFID), (car.TireRFMdl), (car.TireRFPre), (car.TireRFTemp), (car.TireRFBattery), (car.TireRFAcSpeed), "Green1.jpg");
                    else
                        showDSGInfo("RF", "检测失败", (car.TireRFMdl), (car.TireRFPre), (car.TireRFTemp), (car.TireRFBattery), (car.TireRFAcSpeed), "Red1.jpg");
                    if (string.IsNullOrEmpty(car.TireLFID) && car.TireLFID != "00000000")
                        showDSGInfo("LF", (car.TireLFID), (car.TireLFMdl), (car.TireLFPre), (car.TireLFTemp), (car.TireLFBattery), (car.TireLFAcSpeed), "Green1.jpg");
                    else
                        showDSGInfo("LF", "检测失败", (car.TireLFMdl), (car.TireLFPre), (car.TireLFTemp), (car.TireLFBattery), (car.TireLFAcSpeed), "Red1.jpg");
                    if (string.IsNullOrEmpty(car.TireRRID) && car.TireRRID != "00000000")
                        showDSGInfo("RR", (car.TireRRID), (car.TireRRMdl), (car.TireRRPre), (car.TireRRTemp), (car.TireRRBattery), (car.TireRRAcSpeed), "Green1.jpg");
                    else
                        showDSGInfo("RR", "检测失败", (car.TireRRMdl), (car.TireRRPre), (car.TireRRTemp), (car.TireRRBattery), (car.TireRRAcSpeed), "Red1.jpg");
                    if (string.IsNullOrEmpty(car.TireLRID) && car.TireLRID != "00000000")
                    {
                        showDSGInfo("LR", (car.TireLRID), (car.TireLRMdl), (car.TireLRPre), (car.TireLRTemp), (car.TireLRBattery), (car.TireLRAcSpeed), "Green1.jpg");
                        HelperLogWrete.Info("左后轮检测结果：" + car.TireLRID);
                        AddMessage("左后轮检测完毕");
                    }
                    else
                    {
                        if (isInTesting)
                            AddMessage("正在检测左后轮……");
                        else
                        {
                            showDSGInfo("LR", "检测失败", (car.TireLRMdl), (car.TireLRPre), (car.TireLRTemp), (car.TireLRBattery), (car.TireLRAcSpeed), "Red1.jpg");
                            HelperLogWrete.Info("左后轮检测失败");
                            AddMessage("左后轮检测失败", true);
                        }
                    }
                    break;
                case 9994:
                    AddMessage("车辆未装配DSG传感器，直接通过!");
                    AddMessage("未装配DSG:左后轮已通过测试区域");
                    break;
                case 9995:
                    AddMessage("车辆未装配DSG传感器，直接通过!");
                    AddMessage("未装配DSG:右后轮已通过测试区域");
                    break;
                case 9996:
                    AddMessage("车辆未装配DSG传感器，直接通过!");
                    AddMessage("未装配DSG:左前轮已通过测试区域");
                    break;
                case 9997:
                    AddMessage("车辆未装配DSG传感器，直接通过!");
                    AddMessage("未装配DSG:右前轮已通过测试区域");
                    break;
                case 9999:
                    AddMessage("等待扫描VIN，开始测试!");
                    initFrom(true);
                    break;
            }
        }

        /// <summary>
        /// 显示系统信息
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="isAlert"></param>
        void AddMessage(string txt, bool isAlert = false)
        {
            ListMsg.Items.Add($"[{DateTime.Now}]{txt }");
            if (isAlert)
            {
                frmInfo.txtInfo.ForeColor = Color.Red;
            }
            else
            {
                frmInfo.txtInfo.ForeColor = Color.Blue;
            }
            frmInfo.txtInfo.Text = txt;
            ListMsg.SelectedIndex = ListMsg.Items.Count - 1;
        }

        /// <summary>
        /// 初始化窗体的内容
        /// </summary>
        /// <param name="isInitVin"></param>
        void initFrom(bool isInitVin)
        {
            picLF.Image = ImageList.Images[6];
            frmInfo.picLF.Image = frmInfo.ImageList.Images[6];
            picLR.Image = ImageList.Images[6];
            frmInfo.picLR.Image = frmInfo.ImageList.Images[6];
            picRF.Image = ImageList.Images[6];
            frmInfo.picRF.Image = frmInfo.ImageList.Images[6];
            picRR.Image = ImageList.Images[6];
            frmInfo.picRR.Image = frmInfo.ImageList.Images[6];


            txtLR.Text = string.Empty;
            lbLRMdl.Text = string.Empty;
            lbLRPre.Text = string.Empty;
            lbLRTemp.Text = string.Empty;
            lbLRBattery.Text = string.Empty;
            lbLRAcSpeed.Text = string.Empty;

            frmInfo.txtLR.Text = string.Empty;
            frmInfo.lbLRMdl.Text = string.Empty;
            frmInfo.lbLRPre.Text = string.Empty;
            frmInfo.lbLRTemp.Text = string.Empty;
            frmInfo.lbLRBattery.Text = string.Empty;
            frmInfo.lbLRAcSpeed.Text = string.Empty;

            txtLF.Text = string.Empty;
            lbLFMdl.Text = string.Empty;
            lbLFPre.Text = string.Empty;
            lbLFTemp.Text = string.Empty;
            lbLFBattery.Text = string.Empty;
            lbLFAcSpeed.Text = string.Empty;

            frmInfo.txtLF.Text = string.Empty;
            frmInfo.lbLFMdl.Text = string.Empty;
            frmInfo.lbLFPre.Text = string.Empty;
            frmInfo.lbLFTemp.Text = string.Empty;
            frmInfo.lbLFBattery.Text = string.Empty;
            frmInfo.lbLFAcSpeed.Text = string.Empty;

            txtRR.Text = string.Empty;
            lbRRMdl.Text = string.Empty;
            lbRRPre.Text = string.Empty;
            lbRRTemp.Text = string.Empty;
            lbRRBattery.Text = string.Empty;
            lbRRAcSpeed.Text = string.Empty;

            frmInfo.txtRR.Text = string.Empty;
            frmInfo.lbRRMdl.Text = string.Empty;
            frmInfo.lbRRPre.Text = string.Empty;
            frmInfo.lbRRTemp.Text = string.Empty;
            frmInfo.lbRRBattery.Text = string.Empty;
            frmInfo.lbRRAcSpeed.Text = string.Empty;

            txtRF.Text = string.Empty;
            lbRFMdl.Text = string.Empty;
            lbRFPre.Text = string.Empty;
            lbRFTemp.Text = string.Empty;
            lbRFBattery.Text = string.Empty;
            lbRFAcSpeed.Text = string.Empty;

            frmInfo.txtRF.Text = string.Empty;
            frmInfo.lbRFMdl.Text = string.Empty;
            frmInfo.lbRFPre.Text = string.Empty;
            frmInfo.lbRFTemp.Text = string.Empty;
            frmInfo.lbRFBattery.Text = string.Empty;
            frmInfo.lbRFAcSpeed.Text = string.Empty;

            if (isInitVin)
            {
                txtVin.Text = string.Empty;
                frmInfo.labVin.Text = "胎压检测初始化系统";
            }
        }

        /// <summary>
        /// 在界面上显示检测到的传感器信息
        /// </summary>
        void showDSGInfo(string str_Renamed, string text_Renamed, string model, string pressure, string temperature, string battery, string acSpeed, string imgName)
        {
            string conName = $"txt{str_Renamed}";
            Controls[conName].Text = text_Renamed;
            frmInfo.Controls[conName].Text = text_Renamed;

            conName = $"pic{str_Renamed}";
            (Controls[conName] as PictureBox).Image = ImageList.Images[imgName];
            (frmInfo.Controls[conName] as PictureBox).Image = ImageList.Images[imgName];

            conName = $"lb{str_Renamed}Mdl";
            var mdlArr = mdlValue.Split(',');
            if (mdlArr.Contains(model))
            {
                Controls[conName].ForeColor = Color.Blue;
                frmInfo.Controls[conName].ForeColor = Color.Blue;
            }
            else
            {
                Controls[conName].ForeColor = Color.Red;
                frmInfo.Controls[conName].ForeColor = Color.Red;
            }
            Controls[conName].Text = model;
            frmInfo.Controls[conName].Text = model;

            conName = $"lb{str_Renamed}Pre";
            int.TryParse(pressure, out int value);
            int.TryParse(preMinValue, out int minValue);
            int.TryParse(preMaxValue, out int maxValue);
            if (value >= minValue && value <= maxValue)
            {
                Controls[conName].ForeColor = Color.Blue;
                frmInfo.Controls[conName].ForeColor = Color.Blue;
            }
            else
            {
                Controls[conName].ForeColor = Color.Red;
                frmInfo.Controls[conName].ForeColor = Color.Red;
            }
            string str = string.IsNullOrEmpty(pressure) ? "" : pressure + "kPa";
            Controls[conName].Text = str;
            frmInfo.Controls[conName].Text = str;

            conName = $"lb{str_Renamed}Temp";
            int.TryParse(temperature, out value);
            int.TryParse(tempMinValue, out minValue);
            int.TryParse(tempMaxValue, out maxValue);
            if (value >= minValue && value <= maxValue)
            {
                Controls[conName].ForeColor = Color.Blue;
                frmInfo.Controls[conName].ForeColor = Color.Blue;
            }
            else
            {
                Controls[conName].ForeColor = Color.Red;
                frmInfo.Controls[conName].ForeColor = Color.Red;
            }
            str = string.IsNullOrEmpty(pressure) ? "" : pressure + "℃";
            Controls[conName].Text = str;
            frmInfo.Controls[conName].Text = str;

            conName = $"lb{str_Renamed}Battery";
            if (battery == "OK")
            {
                Controls[conName].ForeColor = Color.Blue;
                frmInfo.Controls[conName].ForeColor = Color.Blue;
            }
            else
            {
                Controls[conName].ForeColor = Color.Red;
                frmInfo.Controls[conName].ForeColor = Color.Red;
            }
            Controls[conName].Text = battery;
            frmInfo.Controls[conName].Text = battery;

            conName = $"lb{str_Renamed}AcSpeed";
            int.TryParse(acSpeed, out value);
            int.TryParse(acSpeedMinValue, out minValue);
            int.TryParse(acSpeedMaxValue, out maxValue);
            if (value >= minValue && value <= maxValue)
            {
                Controls[conName].ForeColor = Color.Blue;
                frmInfo.Controls[conName].ForeColor = Color.Blue;
            }
            else
            {
                Controls[conName].ForeColor = Color.Red;
                frmInfo.Controls[conName].ForeColor = Color.Red;
            }
            str = string.IsNullOrEmpty(pressure) ? "" : pressure + "g";
            Controls[conName].Text = str;
            frmInfo.Controls[conName].Text = str;
        }

        /// <summary>
        /// 初始化排产队列信息
        /// </summary>
        async Task iniListInput()
        {
            string tmpVin = string.Empty;
            if (string.IsNullOrEmpty(txtVin.Text.Trim()))
                tmpVin = await Service_runstate.QueryableVIN();
            else
                tmpVin = txtVin.Text.Trim();
            var uw5 =await Service_vinlist.QueryableFirst(tmpVin);
            if (uw5 < 1)
            {
                if (string.IsNullOrEmpty(txtVin.Text.Trim()))
                    return;
                else
                    uw5 = 999999999;
            }

            frmInfo.ListInput.Items.Clear();
            var tmpVins = await Service_vinlist.QueryableVINs (uw5);
            flag = false;
            string tmp = tmpVins[0].Substring(tmpVins[0].Length - 8, 8);
            if (tmpVins != null)
            {
                foreach (var item in tmpVins)
                {
                    frmInfo.ListInput.Items.Add(tmp);
                    if (flag)
                    {
                        frmInfo.labNext.Text = tmp;
                        flag = false;
                    }
                    if (inputCode.Count != 0)
                    {
                        if (tmpVins[0] == inputCode.Last().Value)
                            flag = true;
                    }
                }
            }
            if (inputCode.Count == 0)
                frmInfo.labNext.Text = tmp;
        }

        void flashBuzzerLamp(short IOPort)
        {
            oIOCard.OutputController(Lamp_GreenLight_IOPort, false); // 关闭绿色
            oIOCard.OutputController(Lamp_GreenFlash_IOPort, false); // 关闭绿色闪烁
            oIOCard.OutputController(Lamp_YellowLight_IOPort, false); // 关闭黄色
            oIOCard.OutputController(Lamp_YellowFlash_IOPort, false); // 关闭黄色闪烁
            oIOCard.OutputController(Lamp_RedLight_IOPort, false); // 关闭红色
            oIOCard.OutputController(Lamp_RedFlash_IOPort, false);// 关闭红色闪烁
            oIOCard.OutputController(Lamp_Buzzer_IOPort, true);
            oIOCard.OutputController(IOPort, true);
        }

        void flashLamp(short IOPort)
        {
            oIOCard.OutputController(Lamp_GreenLight_IOPort, false);// 关闭绿色
            oIOCard.OutputController(Lamp_GreenFlash_IOPort, false);// 关闭绿色闪烁
            oIOCard.OutputController(Lamp_YellowLight_IOPort, false);// 关闭黄色
            oIOCard.OutputController(Lamp_YellowFlash_IOPort, false);// 关闭黄色闪烁
            oIOCard.OutputController(Lamp_RedLight_IOPort, false);// 关闭红色
            oIOCard.OutputController(Lamp_RedFlash_IOPort, false);// 关闭红色闪烁
            oIOCard.OutputController(IOPort, true);
        }

        /// <summary>
        /// 首次加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void FrmMain_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            frmInfo.Show();
            initFrom(true);

            string portNum = await modPublic.getConfigValue("T_CtrlParam", "LVT520", "LVT520_PortNum");
            string settings = await modPublic.getConfigValue("T_CtrlParam", "LVT520", "LVT520_Settings");
            oLVT520.SerialPortOnline(portNum, settings);
            portNum = await modPublic.getConfigValue("T_CtrlParam", "RVT520", "RVT520_PortNum");
            settings = await modPublic.getConfigValue("T_CtrlParam", "RVT520", "RVT520_Settings");
            oRVT520.SerialPortOnline(portNum, settings);
            // 配置条码扫描枪
            portNum = await modPublic.getConfigValue("T_CtrlParam", "BarCodeGun", "WirledCodeGun_PortNum");
            settings = await modPublic.getConfigValue("T_CtrlParam", "BarCodeGun", "WirledCodeGun_Settings");
            if (!string.IsNullOrEmpty(portNum) && !string.IsNullOrEmpty(settings))
                modPublic.SerialPortOnline(SerialPortVIN, portNum, settings);
            portNum = await modPublic.getConfigValue("T_CtrlParam", "BarCodeGun", "WirlessCodeGun_PortNum");
            settings = await modPublic.getConfigValue("T_CtrlParam", "BarCodeGun", "WirlessCodeGun_Settings");
            if (!string.IsNullOrEmpty(portNum) && !string.IsNullOrEmpty(settings))
                modPublic.SerialPortOnline(SerialPortBT, portNum, settings);

            Timer_DataSync.Start();
            Timer_PrintError.Start();
            Timer_StatusQuery.Start();
        }

        /// <summary>
        /// 退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picExit_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show("是否退出胎压初始化系统？", "提示", MessageBoxButtons.YesNo);
            if (msg == DialogResult.Yes)
            {
                //oIOCard.OutputController(Lamp_Buzzer_IOPort, False) '关闭蜂鸣
                //Call closeAll()
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// 窗体最小化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Picture1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// 记录点击鼠标时的坐标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                mousePoint = e.Location;
        }

        /// <summary>
        /// 窗体随鼠标移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = e.X - mousePoint.X;
                int y = e.Y - mousePoint.Y;
                Location = Point.Add(Location, new Size(x, y));
            }
        }

        private void txtInputVIN_Click(object sender, EventArgs e)
        {
            txtInputVIN.Text = string.Empty;
        }

        private void txtInputVIN_Leave(object sender, EventArgs e)
        {
            txtInputVIN.Text = "手工录入VIN，回车确认";
        }

        private async void txtInputVIN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (BreakFlag)
                return;
            if (e.KeyChar == 13)
            {
                TestCode = txtInputVIN.Text.Trim();
                txtInputVIN.Text = "手工录入VIN，回车确认";
                switch (TestCode.Substring(0, 17))
                {
                    case "R010000000000000C":
                        HelperLogWrete.Info("1扫描重置条码");
                        await resetList();
                        return;
                    case "R020000000000000C":
                        barCodeFlag = true;
                        return;
                }
                Debug.Print(TestCode);
               await txtVin_KeyPress(txtVin, e);
            }
        }

        private async Task  txtVin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (BreakFlag)
                return;
            if (e.KeyChar == 13)
            {
                HelperLogWrete.Info("************************************************************");
                HelperLogWrete.Info($"扫描条码：{TestCode }");
                HelperLogWrete.Info("************************************************************");
                if (TestCode.Length == 17)
                {
                    if (isCheckAllQueue)
                    {
                        if (frmInfo.ListInput.Items.Count > 0 && barCodeFlag == false)
                        {
                            if (frmInfo.labNext.Text != TestCode.Substring(TestCode.Length - 8, 8))
                            {
                                AddMessage("请注意待扫车辆信息是否正确", true);
                                flashBuzzerLamp(Lamp_RedLight_IOPort);
                                HelperLogWrete.Info("待扫车辆不匹配,调用声音报警");
                                Thread.Sleep(2000);
                                oIOCard.OutputController(Lamp_RedLight_IOPort, false);
                                oIOCard.OutputController(rdOutput, false);

                                if (TestStateFlag == 9999 || TestStateFlag == -1)
                                    oIOCard.OutputController(Lamp_GreenLight_IOPort, true);
                                else
                                    oIOCard.OutputController(Lamp_YellowFlash_IOPort, true);
                                return;
                            }
                        }
                    }
                    if (barCodeFlag)
                        barCodeFlag = false;
                    string subCode = TestCode.Substring(1, 16);
                    if (inputCode.ContainsKey(subCode))
                        return;

                    inputCode.Add(subCode, TestCode);
                    await Service_vincoll.InserVin(TestCode);
                    HelperLogWrete.Info($"{subCode} 进入扫描队列");
                    List1.Items.Add(subCode);
                    frmInfo.ListOutput.Items.Add(TestCode.Substring(TestCode.Length - 8, 8));
                    setFrm(TestStateFlag);
                    await initDictionary();
                    if (inputCode.Count == 1)
                    {
                        txtVin.Text = subCode;
                        frmInfo.labVin.Text = subCode;
                        await Service_runstate.UpdateableTest(false);
                        await Service_runstate.UpdateableVIN (subCode);
                        TestStateFlag = -1;
                        await Service_runstate.UpdateableState (-1);
                        AddMessage("等待扫描车辆进入工位!");
                    }
                    await iniListInput();
                    flashLamp(Lamp_GreenFlash_IOPort);
                    Thread.Sleep(1000);
                    flashLamp(Lamp_GreenLight_IOPort);
                    if (TestStateFlag == 9999 || TestStateFlag == -1)
                        oIOCard.OutputController(Lamp_GreenLight_IOPort, true);
                    else
                    {
                        oIOCard.OutputController(Lamp_GreenLight_IOPort, false);
                        oIOCard.OutputController(Lamp_YellowFlash_IOPort, true);
                    }    
                }
                else
                {
                    AddMessage("请注意扫描条码长度是否正确", true);
                    flashBuzzerLamp(Lamp_RedLight_IOPort);
                    HelperLogWrete.Info("条码长度不正确,调用声音报警!");
                    Thread.Sleep(2000);
                    oIOCard.OutputController(Lamp_RedLight_IOPort, false);
                    oIOCard.OutputController(rdOutput, false);
                    if (TestStateFlag == 9999 || TestStateFlag == -1)
                        oIOCard.OutputController(Lamp_GreenLight_IOPort, true);
                    else
                    {
                        oIOCard.OutputController(Lamp_GreenLight_IOPort, false);
                        oIOCard.OutputController(Lamp_YellowFlash_IOPort, true);
                    }
                }
            }
        }
    }
}
