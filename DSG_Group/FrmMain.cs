using DSG_Group.BllComm;
using DSG_Group.DGComm;
using DSG_Group.SqlServers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
        CCar car = new CCar();
        string VINCode = string.Empty;
        /// <summary>
        /// 条码储存对象
        /// </summary>
        Dictionary<string, string> inputCode = new Dictionary<string, string>();
        int TestStateFlag = -1;
        bool testEndDelyed = false;

        // 信号灯相关控制参数（io信号输出端口）
        private int Lamp_GreenFlash_IOPort = 0;
        private int Lamp_GreenLight_IOPort = 0;
        private int Lamp_YellowLight_IOPort = 0;
        private int Lamp_YellowFlash_IOPort = 0;
        private int Lamp_RedLight_IOPort = 0;
        private int Lamp_RedFlash_IOPort = 0;
        private int Lamp_Buzzer_IOPort = 0;
        private int Line_IOPort = 0;

        // 运行状态
        private int mm = 0;
        /// <summary>
        /// 状态诊断周期
        /// </summary>
        private int TimerStatus = 0;
        /// <summary>
        /// 是否正在检测轮胎传感器
        /// </summary>
        private bool isInTesting = false;

        private int Step1Time = 0;
        private int Step2Time = 0;
        private int Step3Time = 0;
        private int Step4Time = 0;

        // 光电开关控制器以及控制参数
        private CSensor sensor0 = null;
        private CSensor sensor1 = null;
        private CSensor sensor2 = null;
        private CSensor sensor3 = null;
        private CSensor sensor4 = null;
        private CSensor sensor5 = null;

        /// <summary>
        /// 条码
        /// </summary>
        private string TestCode = string.Empty;
        private bool barCodeFlag = false;
        private bool BreakFlag = false;

        // 状态参数
        /// <summary>
        /// 数据库所在盘符
        /// </summary>
        private string DBPosition = string.Empty;
        /// <summary>
        /// 数据库所在硬盘可用空间下限
        /// </summary>
        private long SpaceAvailable = 0;

        /// <summary>
        /// 显示当前的检测状态
        /// </summary>
        void setFrm(int state)
        {
            if (state == -1)
            {
                AddMessage("等待扫描车辆进入工位!");
                initFrom(false);
            }
            else if (state == 9999)
            {
                AddMessage("等待扫描VID，开始测试!");
                initFrom(true);
            }
            else if (state > 9000 && state < 9999)
            {
                AddMessage("车辆未装配DSG传感器，直接通过!");
                switch (state)
                {
                    case 9997:
                        AddMessage("未装配DSG:右前轮已通过测试区域");
                        break;
                    case 9996:
                        AddMessage("未装配DSG: 左前轮已通过测试区域");
                        break;
                    case 9995:
                        AddMessage("未装配DSG: 右后轮已通过测试区域");
                        break;
                    case 9994:
                        AddMessage("未装配DSG: 左后轮已通过测试区域");
                        break;
                }
            }
            else
            {
                switch (state)
                {
                    case 0:
                        string msg = "条码扫描通过,准备开始TPMS测试!";
                        AddMessage(msg);
                        initFrom(false);
                        HelperLogWrete.Info(msg);
                        break;
                    case 1:
                        if (car.TireRFID != "00000000" && !string.IsNullOrEmpty(car.TireRFID))
                        {
                            showDSGInfo("RF", car.TireRFID, car.TireRFMdl, car.TireRFPre, car.TireRFTemp, car.TireRFBattery, car.TireRFAcSpeed, "Green1.jpg");
                            AddMessage("右前轮检测完毕");
                            HelperLogWrete.Info($"右前轮检测结果：{car.TireRFID}");
                        }
                        else
                        {
                            if (isInTesting)
                            {
                                AddMessage("正在检测右前轮……");
                            }
                            else
                            {
                                showDSGInfo("RF", "检测失败", car.TireRFMdl, car.TireRFPre, car.TireRFTemp, car.TireRFBattery, car.TireRFAcSpeed, "Red1.jpg");
                                AddMessage("右前轮检测失败");
                                HelperLogWrete.Error("右前轮检测失败");
                            }
                        }
                        break;
                    case 2:
                        if (car.TireRFID != "00000000" && !string.IsNullOrEmpty(car.TireRFID))
                        {
                            showDSGInfo("RF", car.TireRFID, car.TireRFMdl, car.TireRFPre, car.TireRFTemp, car.TireRFBattery, car.TireRFAcSpeed, "Green1.jpg");
                        }
                        else
                        {
                            showDSGInfo("RF", "检测失败", car.TireRFMdl, car.TireRFPre, car.TireRFTemp, car.TireRFBattery, car.TireRFAcSpeed, "Red1.jpg");
                        }
                        if (car.TireLFID != "00000000" && !string.IsNullOrEmpty(car.TireLFID))
                        {
                            showDSGInfo("LF", car.TireLFID, car.TireLFMdl, car.TireLFPre, car.TireLFTemp, car.TireLFBattery, car.TireLFAcSpeed, "Green1.jpg");
                            AddMessage("左前轮检测结果");
                            HelperLogWrete.Error($"左前轮检测结果：{car.TireLFID}");
                        }
                        else
                        {
                            if (isInTesting)
                            {
                                AddMessage("正在检测左前轮……");
                            }
                            else
                            {
                                showDSGInfo("LF", "检测失败", car.TireLFMdl, car.TireLFPre, car.TireLFTemp, car.TireLFBattery, car.TireLFAcSpeed, "Red1.jpg");
                                AddMessage("左前轮检测失败");
                                HelperLogWrete.Error("左前轮检测失败");
                            }
                        }
                        break;
                    case 3:
                        if (car.TireRFID != "00000000" && !string.IsNullOrEmpty(car.TireRFID))
                        {
                            showDSGInfo("RF", car.TireRFID, car.TireRFMdl, car.TireRFPre, car.TireRFTemp, car.TireRFBattery, car.TireRFAcSpeed, "Green1.jpg");
                        }
                        else
                        {
                            showDSGInfo("RF", "检测失败", car.TireRFMdl, car.TireRFPre, car.TireRFTemp, car.TireRFBattery, car.TireRFAcSpeed, "Red1.jpg");
                        }
                        if (car.TireLFID != "00000000" && !string.IsNullOrEmpty(car.TireLFID))
                        {
                            showDSGInfo("LF", car.TireLFID, car.TireLFMdl, car.TireLFPre, car.TireLFTemp, car.TireLFBattery, car.TireLFAcSpeed, "Green1.jpg");
                        }
                        else
                        {
                            showDSGInfo("LF", "检测失败", car.TireLFMdl, car.TireLFPre, car.TireLFTemp, car.TireLFBattery, car.TireLFAcSpeed, "Red1.jpg");
                        }
                        if (car.TireRRID != "00000000" && !string.IsNullOrEmpty(car.TireRRID))
                        {
                            showDSGInfo("RR", car.TireRRID, car.TireRRMdl, car.TireRRPre, car.TireRRTemp, car.TireRRBattery, car.TireRRAcSpeed, "Green1.jpg");
                            AddMessage("右后轮检测完毕");
                            HelperLogWrete.Info($"右后轮检测结果：{car.TireRRID}");
                        }
                        else
                        {
                            if (isInTesting)
                            {
                                AddMessage("正在检测右后轮……");
                            }
                            else
                            {
                                showDSGInfo("RR", "检测失败", car.TireRRMdl, car.TireRRPre, car.TireRRTemp, car.TireRRBattery, car.TireRRAcSpeed, "Red1.jpg");
                                AddMessage("右后轮检测失败");
                                HelperLogWrete.Error("右后轮检测失败");
                            }
                        }
                        break;
                    case 4:
                        if (car.TireRFID != "00000000" && !string.IsNullOrEmpty(car.TireRFID))
                        {
                            showDSGInfo("RF", car.TireRFID, car.TireRFMdl, car.TireRFPre, car.TireRFTemp, car.TireRFBattery, car.TireRFAcSpeed, "Green1.jpg");
                        }
                        else
                        {
                            showDSGInfo("RF", "检测失败", car.TireRFMdl, car.TireRFPre, car.TireRFTemp, car.TireRFBattery, car.TireRFAcSpeed, "Red1.jpg");
                        }
                        if (car.TireLFID != "00000000" && !string.IsNullOrEmpty(car.TireLFID))
                        {
                            showDSGInfo("LF", car.TireLFID, car.TireLFMdl, car.TireLFPre, car.TireLFTemp, car.TireLFBattery, car.TireLFAcSpeed, "Green1.jpg");
                        }
                        else
                        {
                            showDSGInfo("LF", "检测失败", car.TireLFMdl, car.TireLFPre, car.TireLFTemp, car.TireLFBattery, car.TireLFAcSpeed, "Red1.jpg");
                        }
                        if (car.TireRRID != "00000000" && !string.IsNullOrEmpty(car.TireRRID))
                        {
                            showDSGInfo("RR", car.TireRRID, car.TireRRMdl, car.TireRRPre, car.TireRRTemp, car.TireRRBattery, car.TireRRAcSpeed, "Green1.jpg");
                        }
                        else
                        {
                            showDSGInfo("RR", "检测失败", car.TireRRMdl, car.TireRRPre, car.TireRRTemp, car.TireRRBattery, car.TireRRAcSpeed, "Red1.jpg");
                        }
                        if (car.TireLRID != "00000000" && !string.IsNullOrEmpty(car.TireLRID))
                        {
                            showDSGInfo("LR", car.TireLRID, car.TireLRMdl, car.TireLRPre, car.TireLRTemp, car.TireLRBattery, car.TireLRAcSpeed, "Green1.jpg");
                            AddMessage("左后轮检测结果");
                            HelperLogWrete.Info($"左后轮检测结果：{car.TireRRID}");
                        }
                        else
                        {
                            if (isInTesting)
                            {
                                AddMessage("正在检测左后轮……");
                            }
                            else
                            {
                                showDSGInfo("LR", "检测失败", car.TireLRMdl, car.TireLRPre, car.TireLRTemp, car.TireLRBattery, car.TireLRAcSpeed, "Red1.jpg");
                                AddMessage("左后轮检测失败");
                                HelperLogWrete.Error("左后轮检测失败");
                            }
                        }
                        break;
                }
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

        /// <summary>
        /// 在界面上显示检测到的传感器信息
        /// </summary>
        void showDSGInfo(string str, string text, string model, string pressure, string temperature, string battery, string acSpeed, string imgName)
        {
            try
            {
                Controls[$"txt{str}"].Text = text;
                (Controls[$"pic{str}"] as PictureBox).Image = ImageList.Images[imgName];
                _frmInfo.Controls[$"txt{str}"].Text = text;
                (_frmInfo.Controls[$"pic{str}"] as PictureBox).Image = ImageList.Images[imgName];
               
                // 判断传感器模式是否合格
                string[] mdlArr = modPublic.mdlValue.Split(',');
                bool isOK = mdlArr.Contains(model);
                string contName = $"lb{str}Mdl";
                Controls[contName].ForeColor = isOK ? Color.Blue : Color.Red;
                _frmInfo.Controls[contName].ForeColor = isOK ? Color.Blue : Color.Red;
                Controls[$"lb{str}Mdl"].Text = model;
                _frmInfo.Controls[$"lb{str}Mdl"].Text = model;

                int value = 0;
                int min = 0;
                int max = 0;
                // 判断传感器的压力状态
                isOK = int.TryParse(pressure, out value) 
                    && int.TryParse(modPublic.preMinValue, out min)
                    && int.TryParse(modPublic.preMaxValue, out max)
                    && value <= max && value >= min;
                contName = $"lb{str}Pre";
                Controls[contName].ForeColor = isOK ? Color.Blue : Color.Red;
                _frmInfo.Controls[contName].ForeColor = isOK ? Color.Blue : Color.Red;
                Controls[contName].Text = string.IsNullOrEmpty(pressure) ? "" : $"{pressure}kPa";
                _frmInfo.Controls[contName].Text = string.IsNullOrEmpty(pressure) ? "" : $"{pressure}kPa";

                // 判断传感器的温度状态
                isOK = int.TryParse(temperature, out value)
                    && int.TryParse(modPublic.tempMinValue, out min)
                    && int.TryParse(modPublic.tempMaxValue, out max)
                    && value <= max && value >= min;
                contName = $"lb{str}Temp";
                Controls[contName].ForeColor = isOK ? Color.Blue : Color.Red;
                _frmInfo.Controls[contName].ForeColor = isOK ? Color.Blue : Color.Red;
                Controls[contName].Text = string.IsNullOrEmpty(temperature) ? "" : $"{temperature}℃";
                _frmInfo.Controls[contName].Text = string.IsNullOrEmpty(temperature) ? "" : $"{temperature}℃";

                // 判断传感器的电池电量状态
                isOK = battery == "OK"; 
                contName = $"lb{str}Battery";
                Controls[contName].ForeColor = isOK ? Color.Blue : Color.Red;
                _frmInfo.Controls[contName].ForeColor = isOK ? Color.Blue : Color.Red;
                Controls[contName].Text = battery;
                _frmInfo.Controls[contName].Text = battery;

                // 判断传感器的加速度值状态
                isOK = int.TryParse(acSpeed, out value)
                    && int.TryParse(modPublic.acSpeedMinValue, out min)
                    && int.TryParse(modPublic.acSpeedMaxValue, out max)
                    && value <= max && value >= min;
                contName = $"lb{str}Battery";
                Controls[contName].ForeColor = isOK ? Color.Blue : Color.Red;
                _frmInfo.Controls[contName].ForeColor = isOK ? Color.Blue : Color.Red;
                Controls[contName].Text = string.IsNullOrEmpty(acSpeed) ? "" : $"{acSpeed}g";
                _frmInfo.Controls[contName].Text = string.IsNullOrEmpty(acSpeed) ? "" : $"{acSpeed}g";
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("在界面上显示检测到的传感器信息异常！", ex);
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

       async void initDictionary()
        {
            inputCode.Clear();
            List1.Items.Clear();
            _frmInfo.ListOutput.Items.Clear();
            ListOutput1.Items.Clear();
            var vins = await Service_vincoll.Queryable();
            foreach (var item in vins)
            {
                string tmpStr = item.Substring(0, 17);
                inputCode.Add(tmpStr, item);
                List1.Items.Add(tmpStr);
                _frmInfo.ListOutput.Items.Add(tmpStr);
                ListOutput1.Items.Add(tmpStr.Substring(tmpStr.Length - 8, 8));
            }
        }

        /// <summary>
        /// 系统重置，即复位
        /// </summary>
        async void resetList()
        {
            VINCode = string.Empty;
            await Service_vincoll.Deleteable();
            initDictionary();
           
            if (testEndDelyed == false && TestStateFlag != -1)
                TestStateFlag = 9999;
            if (TestStateFlag != -1)
            {
                int k = await Service_runstate.InitRunState();
                HelperLogWrete.Info($"{txtVin.Text.Trim()}：测试完成，重置runstate表记录数：{k}");
            }
            txtVin.Text = string.Empty;

            setFrm(9999);
            int cont = await Service_runstate.UpdateableState(TestStateFlag);
            _frmInfo.labNow.Text = string.Empty;

            closeAll();
            NoController.OutputController(Lamp_GreenLight_IOPort, true);
            NoController.OutputController(Lamp_Buzzer_IOPort, false);// 关闭蜂鸣
        }

        void flashBuzzerLamp(int IOPort)
        {
            closeAll();
            modPublic.oIOCard.OutputController(Lamp_Buzzer_IOPort, true);
            modPublic.oIOCard.OutputController(IOPort, true);
        }

        /// <summary>
        /// 处理扫描条码信息
        /// </summary>
        /// <param name="keyAscii"></param>
        async void txtVIN_KeyPress(int keyAscii)
        {
            try
            {
                var subCode = TestCode.Length >= 17 ? TestCode.Substring(0, 17) : TestCode;
                var count = await Service_T_Result.Queryable(subCode);
                if (count.Count != 0)
                {
                    resetList();
                    AddMessage(subCode + "重复检测");
                    return;
                }
                // 系统锁定后扫描枪不响应
                if (BreakFlag) return;
                if (keyAscii == 13)
                {
                    if (TestCode.Length == 17 && TestCode.ToUpper().Substring(0, 1) == "T")
                    {
                        HelperLogWrete.Info($"扫描条码：{TestCode}");
                        // 关闭蜂鸣 第二次扫描条码正确后关闭蜂鸣
                        modPublic.oIOCard.OutputController(Lamp_Buzzer_IOPort, false);
                        if (inputCode.ContainsKey(TestCode))
                            return;
                        inputCode.Add(TestCode, TestCode);
                        // 将VIN,车型，是否带胎压写入到临时表vincoll中
                        modPublic.insertColl(TestCode);
                        HelperLogWrete.Info($"{TestCode}进入扫描队列");
                        List1.Items.Add(TestCode);
                        _frmInfo.ListOutput.Items.Add(TestCode);
                        ListOutput1.Items.Add(TestCode.Substring(17 - 8, 8));
                        initDictionary();

                        if (inputCode.Count == 1)
                        {
                            var tmpVin = inputCode.First().Value;
                            txtVin.Text = tmpVin;
                            _frmInfo.labVin.Text = tmpVin;
                            await Service_runstate.UpdateableTest(false);
                            await Service_runstate.UpdateableVIN(tmpVin);
                            // 避免扫描vin码时车辆已进入工位并且触发1号光电开关(TestStateFlag = 0或者9998)
                            if (TestStateFlag == 0 || TestStateFlag == 9998)
                            {
                                resetList();
                                txtInputVIN.Text = string.Empty;
                                return;
                            }
                            TestStateFlag = -1;
                            await Service_runstate.UpdateableState(TestStateFlag);
                            AddMessage("等待扫描车辆进入工位!");
                            if (TestStateFlag != -1)
                            {
                                resetList();
                                txtInputVIN.Text = string.Empty;
                                return;
                            }
                            modPublic.flashLamp(Lamp_GreenFlash_IOPort);
                            modPublic.DelayTime(1000);
                            modPublic.flashLamp(Lamp_GreenLight_IOPort);
                            if (TestStateFlag == 9999 || TestStateFlag == -1)
                                modPublic.oIOCard.OutputController(Lamp_GreenLight_IOPort, true);
                            else
                            {
                                modPublic.oIOCard.OutputController(Lamp_GreenLight_IOPort, false);
                                modPublic.oIOCard.OutputController(Lamp_YellowFlash_IOPort, true);
                            }
                        }
                    }
                    else
                    {
                        AddMessage("请注意扫描条码长度是否正确");
                        flashBuzzerLamp(Lamp_RedLight_IOPort);
                        HelperLogWrete.Error("条码长度不正确,调用声音报警!");
                        HelperLogWrete.Error($"错误条码：{TestCode}");
                        modPublic.DelayTime(2000);
                        modPublic.oIOCard.OutputController(Lamp_RedLight_IOPort, false);
                        modPublic.oIOCard.OutputController(modPublic.rdOutput, false);
                        if (TestStateFlag == 9999 || TestStateFlag == -1)
                            modPublic.oIOCard.OutputController(Lamp_GreenLight_IOPort, true);
                        else
                        {
                            modPublic.oIOCard.OutputController(Lamp_GreenLight_IOPort, false);
                            modPublic.oIOCard.OutputController(Lamp_YellowFlash_IOPort, true);
                        }
                        // 关闭蜂鸣
                        modPublic.oIOCard.OutputController(Lamp_Buzzer_IOPort, false);
                    }
                }
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("处理扫描条码信息异常", ex);
            }
            
        }

        /// <summary>
        /// 首次加载界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                // 启动计时器
                Timer_StatusQuery.Interval = 1000;
                Timer_StatusQuery.Start();
                Timer_UpLoadResult.Interval = 1000;
                Timer_UpLoadResult.Start();

                isInTesting = false;
                
                // 读取并初始化对象信号灯控制参数
                int.TryParse(await Service_T_CtrlParam.GetValue("Lamp", "Lamp_GreenFlash_IOPort"), out Lamp_GreenFlash_IOPort);
                int.TryParse(await Service_T_CtrlParam.GetValue("Lamp", "Lamp_GreenLight_IOPort"), out Lamp_GreenLight_IOPort);
                int.TryParse(await Service_T_CtrlParam.GetValue("Lamp", "Lamp_YellowLight_IOPort"), out Lamp_YellowLight_IOPort);
                int.TryParse(await Service_T_CtrlParam.GetValue("Lamp", "Lamp_RedLight_IOPort"), out Lamp_RedLight_IOPort);
                int.TryParse(await Service_T_CtrlParam.GetValue("Lamp", "Lamp_RedFlash_IOPort"), out Lamp_RedFlash_IOPort);
                int.TryParse(await Service_T_CtrlParam.GetValue("Lamp", "Lamp_Buzzer_IOPort"), out Lamp_Buzzer_IOPort);
                int.TryParse(await Service_T_CtrlParam.GetValue("Lamp", "Lamp_YellowFlash_IOPort"), out Lamp_YellowFlash_IOPort);
                int.TryParse(await Service_T_CtrlParam.GetValue("Line", "Line_IOPort"), out Line_IOPort);

                // 传感器参数设定
                modPublic.mdlValue = await Service_T_RunParam.GetValue("StandardValue", "MdlValue");
                modPublic.preMinValue = await Service_T_RunParam.GetValue("StandardValue", "PreMinValue");
                modPublic.preMaxValue = await Service_T_RunParam.GetValue("StandardValue", "PreMaxValue");
                modPublic.tempMinValue = await Service_T_RunParam.GetValue("StandardValue", "TempMinValue");
                modPublic.tempMaxValue = await Service_T_RunParam.GetValue("StandardValue", "TempMaxValue");
                modPublic.acSpeedMinValue = await Service_T_RunParam.GetValue("StandardValue", "AcSpeedMinValue");
                modPublic.acSpeedMaxValue = await Service_T_RunParam.GetValue("StandardValue", "AcSpeedMaxValue");

                int.TryParse(await Service_T_RunParam.GetValue("Timer", "TimerStatus"), out TimerStatus);
                DBPosition = await Service_T_RunParam.GetValue("Status", "DBPosition");
                long.TryParse(await Service_T_RunParam.GetValue("Status", "SpaceAvailable"), out SpaceAvailable);

                TestStateFlag = await Service_runstate.QueryableState();
                bool testFlag = await Service_runstate.QueryableTest();
                // 如果带DSG系统并且未检测完成，先加载已检测了的数据
                if (testFlag && TestStateFlag != 9999)
                {
                    car = await CCar.getRunStateCar();
                    txtVin.Text = car?.VINCode;
                }
                // 如果已检测完成，则从数据库中加载VIN
                if ((TestStateFlag > 9000 && TestStateFlag < 9999) || TestStateFlag == -1)
                {
                    txtVin.Text = await Service_runstate.QueryableVIN();
                }
                if (!string.IsNullOrEmpty(txtVin.Text))
                {
                    _frmInfo.labNow.Text = txtVin.Text.Substring(txtVin.Text.Trim().Length - 17, 17);
                    _frmInfo.labVin.Text = txtVin.Text;
                }
                setFrm(TestStateFlag);

                int.TryParse(await Service_T_CtrlParam.GetValue("StepTime", "Step1Time"), out Step1Time);
                int.TryParse(await Service_T_CtrlParam.GetValue("StepTime", "Step2Time"), out Step2Time);
                int.TryParse(await Service_T_CtrlParam.GetValue("StepTime", "Step3Time"), out Step3Time);
                int.TryParse(await Service_T_CtrlParam.GetValue("StepTime", "Step4Time"), out Step4Time);

                await Service_runstate.UpdateableState(TestStateFlag);
                inputCode = new Dictionary<string, string>();
                AddMessage("系统已解锁",true);
                setFrm(TestStateFlag);
                HelperLogWrete.Info("系统已解锁");

                sensor0 = new CSensor();
                sensor1 = new CSensor();
                sensor2 = new CSensor();
                sensor3 = new CSensor();
                sensor4 = new CSensor();
                sensor5 = new CSensor();
                
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("首次加载界面，数据异常！", ex);
            }
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
                await Service_vincoll.Deleteable();
                HelperLogWrete.Info("初始化扫描队列信息");
                inputCode.Clear();
                List1.Items.Clear();
                _frmInfo.ListOutput.Items.Clear();
                ListOutput1.Items.Clear();
                var vins = await Service_vincoll.Queryable();
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
                    int k = await Service_runstate.InitRunState();
                    HelperLogWrete.Info($"{txtVin.Text.Trim()}：测试完成，重置runstate表记录数：{k}");
                }
                txtVin.Text = string.Empty;
                setFrm(9999);
                int cont = await Service_runstate.UpdateableState(TestStateFlag);
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

        /// <summary>
        /// 查看日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bntLogSee_Click(object sender, EventArgs e)
        {
            var frm = new frmShowLog();
            frm.Show();
        }

        /// <summary>
        /// 历史记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picCommandHis_Click(object sender, EventArgs e)
        {
            var frm = new frmHistory();
            frm.Show();
        }

        /// <summary>
        /// 数据导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picCommandOut_Click(object sender, EventArgs e)
        {
            var frm = new frmDateZone();
            frm.Show();
        }

        /// <summary>
        /// 状态监控
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_StatusQuery_Tick(object sender, EventArgs e)
        {
            mm++;
            if (mm < TimerStatus)
                return;

            try
            {
                mm = 0;
                if (ListMsg.Items.Count > 20)
                    ListMsg.Items.RemoveAt(0);

                if (TestStateFlag <= 5)
                    return;

                // 检测剩余空间
                var dir = new DriveInfo(DBPosition);
                long dirSize = dir.TotalFreeSpace / 1024 / 1024;
                if (dirSize < SpaceAvailable)
                {
                    Picture9.Image = ImageList.Images["Red1.jpg"];
                    _frmInfo.Picture9.Image = ImageList.Images["Red1.jpg"];
                    HelperLogWrete.Error($"硬盘可用空间不足! 盘：{DBPosition}，剩余大小：{dirSize}");
                }
                else
                {
                    Picture9.Image = ImageList.Images["Green1.jpg"];
                    _frmInfo.Picture9.Image = ImageList.Images["Green1.jpg"];
                }

                // 查询控制器主机状态

                // 查询网络状态
                if (Service_T_RunParam.OnlineState())
                {
                    PicNet.Image = ImageList.Images["Green1.jpg"];
                    _frmInfo.PicNet.Image = ImageList.Images["Green1.jpg"];
                }
                else
                {
                    PicNet.Image = ImageList.Images["Red1.jpg"];
                    _frmInfo.PicNet.Image = ImageList.Images["Red1.jpg"];

                    if (ListMsg.Items.Count > 20)
                        ListMsg.Items.RemoveAt(0);
                    _frmInfo.txtInfo.ForeColor = Color.Red;
                    _frmInfo.txtInfo.Text = "本地数据库连接异常!";
                    HelperLogWrete.Error("本地数据库连接异常!");
                }
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("状态监控异常！", ex);
            }
        }

        /// <summary>
        /// 上传检测结果到电检服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_UpLoadResult_Tick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 点击vin输入框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInputVIN_Click(object sender, EventArgs e)
        {
            txtInputVIN.Text = string.Empty;
        }

        /// <summary>
        /// 输入VIN码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInputVIN_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            TestCode = txtInputVIN.Text.Trim();
            var subCode = TestCode.Length >= 17 ? TestCode.Substring(0, 17) : TestCode;
            switch (subCode.ToUpper())
            {
                case "R010000000000000C":
                    resetList();
                    txtInputVIN.Text = "手工录入VID，回车确认";
                    HelperLogWrete.Info("1扫描重置条码");
                    return;
                case "R020000000000000C":
                    barCodeFlag = true;
                    txtInputVIN.Text = "手工录入VID，回车确认";
                    return;
                case "SHOW":
                    Command13.Visible = true;
                    Command15.Visible = true;
                    Command16.Visible = true;
                    Command18.Visible = true;
                    Command19.Visible = true;
                    Command20.Visible = true;
                    Command3.Visible = true;
                    txtInputVIN.Text = string.Empty;
                    return;
                case "HIDE":
                    Command13.Visible = false;
                    Command15.Visible = false;
                    Command16.Visible = false;
                    Command18.Visible = false;
                    Command19.Visible = false;
                    Command20.Visible = false;
                    Command3.Visible = false;
                    txtInputVIN.Text = string.Empty;
                    return;
            }
            txtVIN_KeyPress(13);
            txtInputVIN.Text = "手工录入VID，回车确认";
        }
    }
}
