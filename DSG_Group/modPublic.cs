using DSG_Group.BllComm;
using DSG_Group.DGComm;
using DSG_Group.SqlServers;
using FrameWork.Model.DFPV_DSG101;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSG_Group
{
    public partial class FrmMain
    {
        // 信号灯相关控制参数（io信号输出端口）
        public int Lamp_GreenFlash_IOPort;
        public int Lamp_GreenLight_IOPort;
        public int Lamp_YellowLight_IOPort;
        public int Lamp_YellowFlash_IOPort;
        public int Lamp_RedLight_IOPort;
        public int Lamp_RedFlash_IOPort;
        public int Lamp_Buzzer_IOPort;
        public int Line_IOPort;

        /// <summary>
        /// 程序Title在所有需要显示的地方全部用该变量，例如msgbox函数的Title参数
        /// </summary>
        public string ProgramTitle;
        /// <summary>
        /// 数据库连接字符串全局需要连接数据库的地方全部调用该变量
        /// </summary>
        public string DBCnnStr;
        public string RDBCnnStr;

        /// <summary>
        /// MES数据库的连接字符串
        /// </summary>
        public string MESCnnStr;
        /// <summary>
        /// MES服务器IP地址
        /// </summary>
        public string MES_IP;
        /// <summary>
        /// 当天（班次）检测数量
        /// </summary>
        public int DayCount;
        /// <summary>
        /// 是否更新最新数据
        /// </summary>
        public int DataDel;

        /// <summary>
        /// IO控制对象
        /// </summary>
        public IOCard oIOCard;

        // VT520控制相关参数
        public CVT520 oLVT520;
        public int LVT520_PortNum;
        public string LVT520_Settings;
        public CVT520 oRVT520;
        public int RVT520_PortNum;
        public string RVT520_Settings;
        /// <summary>
        /// 左边VT520的读取次数
        /// </summary>
        public int LVT520_icount;
        /// <summary>
        /// 右边VT520的读取次数
        /// </summary>
        public int RVT520_icount;

        // 打印模式设定
        /// <summary>
        /// 0表示全不打印，1表示全部打印，2表示仅失败打印
        /// </summary>
        public string PrintModel;

        // 条码枪设置
        public string WirledCodeGun_PortNum;
        public string WirledCodeGun_Settings;
        public string WirlessCodeGun_PortNum;
        public string WirlessCodeGun_Settings;

        // 喇叭控制参数（io信号输出端口）
        public int rdOutput;
        public int rdResetCommand;

        // 光电开关控制器以及控制参数
        public CSensor sensor0;
        public CSensor sensor1;
        public CSensor sensor2;
        public CSensor sensor3;
        public CSensor sensor4;
        public CSensor sensor5;
        public CSensor sensorCommand;
        public CSensor sensorLine;
        public CSensor rdResetCommandS;

        public int sensor0Port;
        public int sensor1Port;
        public int sensor2Port;
        public int sensor3Port;
        public int sensor4Port;
        public int sensor5Port;

        public int sensorCommandPort;
        public int sensorLinePort;

        // 传感器参数设置
        public string mdlValue;
        public string preMinValue;
        public string preMaxValue;
        public string tempMinValue;
        public string tempMaxValue;
        public string acSpeedMinValue;
        public string acSpeedMaxValue;
        public string mTOCStartIndex;
        public string tPMSCodeLen;

        // 系统扫描条码的模式
        /// <summary>
        /// 是否校验排产队列
        /// </summary>
        public bool isCheckAllQueue;
        /// <summary>
        /// 是否只扫描VIN码，MTOC码将会从MES系统中获得
        /// </summary>
        public bool isOnlyScanVINCode;
        /// <summary>
        /// 是否只打印诊断结果为NG的诊断单据
        /// </summary>
        public bool isOnlyPrintNGWriteResult;
        /// <summary>
        /// 是否只打印NG的诊断流程，合格的流程不打印
        /// </summary>
        public bool isOnlyPrintNGFlow;

        public int TimeOutNum;
        public bool lineCommandFlag;

        public async Task Main()
        {
            try
            {
                ProgramTitle = "DSG初始化系统";

                // MES系统Oracle数据库连接字符串
                MESCnnStr = await Service_T_RunParam.GetValue("DB", "MESCnnStr");
                // MES系统数据库所在服务器IP地址
                MES_IP = await Service_T_RunParam.GetValue("MES", "MESIP");
                // 当天（班次）检测数量限制
                int.TryParse(await Service_T_RunParam.GetValue("Count", "DayCount"), out DayCount);
                // 获取是否保持T_Result表最新数据
                int.TryParse(await Service_T_RunParam.GetValue("Data", "DataDel"), out DataDel);

                // 初始化VT520参数
                int.TryParse(await Service_T_CtrlParam.GetValue("LVT520", "LVT520_PortNum"), out LVT520_PortNum);
                LVT520_Settings = await Service_T_CtrlParam.GetValue("LVT520", "LVT520_Settings");
                int.TryParse(await Service_T_CtrlParam.GetValue("LVT520", "LVT520_icount"), out LVT520_icount);

                oLVT520 = new CVT520
                {
                    CommPort = LVT520_PortNum,
                    ComSettings = LVT520_Settings,
                    OpenPort = true,
                };

                int.TryParse(await Service_T_CtrlParam.GetValue("RVT520", "RVT520_PortNum"), out RVT520_PortNum);
                RVT520_Settings = await Service_T_CtrlParam.GetValue("RVT520", "RVT520_Settings");
                int.TryParse(await Service_T_CtrlParam.GetValue("RVT520", "RVT520_icount"), out RVT520_icount);
                oRVT520 = new CVT520
                {
                    CommPort = RVT520_PortNum,
                    ComSettings = RVT520_Settings,
                    OpenPort = true,
                };

                oIOCard = new IOCard();

                // 读取并初始化对象信号灯控制参数
                int.TryParse(await Service_T_CtrlParam.GetValue("Lamp", "Lamp_GreenFlash_IOPort"), out Lamp_GreenFlash_IOPort);
                int.TryParse(await Service_T_CtrlParam.GetValue("Lamp", "Lamp_GreenLight_IOPort"), out Lamp_GreenLight_IOPort);
                int.TryParse(await Service_T_CtrlParam.GetValue("Lamp", "Lamp_YellowLight_IOPort"), out Lamp_YellowLight_IOPort);
                int.TryParse(await Service_T_CtrlParam.GetValue("Lamp", "Lamp_RedLight_IOPort"), out Lamp_RedLight_IOPort);
                int.TryParse(await Service_T_CtrlParam.GetValue("Lamp", "Lamp_RedFlash_IOPort"), out Lamp_RedFlash_IOPort);
                int.TryParse(await Service_T_CtrlParam.GetValue("Lamp", "Lamp_Buzzer_IOPort"), out Lamp_Buzzer_IOPort);
                int.TryParse(await Service_T_CtrlParam.GetValue("Lamp", "Lamp_YellowFlash_IOPort"), out Lamp_YellowFlash_IOPort);
                int.TryParse(await Service_T_CtrlParam.GetValue("Line", "Line_IOPort"), out Line_IOPort);

                int.TryParse(await Service_T_CtrlParam.GetValue("Lamp", "rdOutput"), out rdOutput);
                int.TryParse(await Service_T_CtrlParam.GetValue("Lamp", "rdResetCommand"), out rdResetCommand);

                int.TryParse(await Service_T_CtrlParam.GetValue("Line", "sensorCommandPort"), out sensorCommandPort);
                int.TryParse(await Service_T_CtrlParam.GetValue("Line", "sensorLinePort"), out sensorLinePort);

                // 初始化光电开关
                int.TryParse(await Service_T_CtrlParam.GetValue("sensor", "sensor0Port"), out sensor0Port);
                int.TryParse(await Service_T_CtrlParam.GetValue("sensor", "sensor1Port"), out sensor1Port);
                int.TryParse(await Service_T_CtrlParam.GetValue("sensor", "sensor2Port"), out sensor2Port);
                int.TryParse(await Service_T_CtrlParam.GetValue("sensor", "sensor3Port"), out sensor3Port);
                int.TryParse(await Service_T_CtrlParam.GetValue("sensor", "sensor4Port"), out sensor4Port);
                int.TryParse(await Service_T_CtrlParam.GetValue("sensor", "sensor5Port"), out sensor5Port);

                // 传感器参数设定
                mdlValue = await Service_T_RunParam.GetValue("StandardValue", "MdlValue");
                preMinValue = await Service_T_RunParam.GetValue("StandardValue", "PreMinValue");
                preMaxValue = await Service_T_RunParam.GetValue("StandardValue", "PreMaxValue");
                tempMinValue = await Service_T_RunParam.GetValue("StandardValue", "TempMinValue");
                tempMaxValue = await Service_T_RunParam.GetValue("StandardValue", "TempMaxValue");
                acSpeedMinValue = await Service_T_RunParam.GetValue("StandardValue", "AcSpeedMinValue");
                acSpeedMaxValue = await Service_T_RunParam.GetValue("StandardValue", "AcSpeedMaxValue");

                WirledCodeGun_PortNum = await Service_T_CtrlParam.GetValue("BarCodeGun", "WirledCodeGun_PortNum");
                WirledCodeGun_Settings = await Service_T_CtrlParam.GetValue("BarCodeGun", "WirledCodeGun_Settings");
                WirlessCodeGun_PortNum = await Service_T_CtrlParam.GetValue("BarCodeGun", "WirlessCodeGun_PortNum");
                WirlessCodeGun_Settings = await Service_T_CtrlParam.GetValue("BarCodeGun", "WirlessCodeGun_Settings");

                bool.TryParse(await Service_T_CtrlParam.GetValue("sensor", "lineCommandFlag"), out lineCommandFlag);

                bool.TryParse(await Service_T_RunParam.GetValue("Print", "OnlyPrintNGWriteResult"), out isOnlyPrintNGWriteResult);
                bool.TryParse(await Service_T_RunParam.GetValue("Print", "OnlyPrintNGFlow"), out isOnlyPrintNGFlow);

                // 打印模式
                PrintModel = await Service_T_RunParam.GetValue("Print", "PrintModel");

                sensor0 = new CSensor();
                sensor1 = new CSensor();
                sensor2 = new CSensor();
                sensor3 = new CSensor();
                sensor4 = new CSensor();
                sensor5 = new CSensor();
                rdResetCommandS = new CSensor();
                sensorCommand = new CSensor();
                sensorLine = new CSensor();

                sensor0.IOPort = sensor0Port;
                sensor1.IOPort = sensor1Port;
                sensor2.IOPort = sensor2Port;
                sensor3.IOPort = sensor3Port;
                sensor4.IOPort = sensor4Port;
                sensor5.IOPort = sensor5Port;
                rdResetCommandS.IOPort = rdResetCommand;
                sensorCommand.IOPort = sensorCommandPort;
                sensorLine.IOPort = sensorLinePort;
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error("初始化参数失败！请检查配置信息", ex);
            }
        }

        public void flashBuzzerLamp(int IOPort)
        {
            closeAll();
            oIOCard.OutputController(Lamp_Buzzer_IOPort, true);
            oIOCard.OutputController(IOPort, true);
        }

        public void DelayTime(long LngTime)
        {
            //long LngTick = NativeMethods.GetTickCount();
            System.Threading.Thread.Sleep((int)LngTime);
        }

        public void flashLamp(int IOPort)
        {
            closeAll();
            oIOCard.OutputController(IOPort, true);
        }

        public async Task insertColl(string code)
        {
            try
            {
                var data = await Service_cartype_tpms.Queryable();
                foreach (var item in data)
                {
                    var subStr = code.Substring(item.CodeStartIndex - 1, item.CodeLen);
                    if (subStr == item.MatchLetter)
                    {
                        int k = await Service_vincoll.Updateable(code, item.CarType, item.ifTPMS);
                        return;
                    }
                }
                // 没有匹配的车型
                var tmpK = await Service_vincoll.Insertable(code, "no", false);
                HelperLogWrete.Info($"没有匹配的车型，插入扫描队列 VIN：{code}");
            }
            catch (Exception ex)
            {
                HelperLogWrete.Error(ex.Message, ex);
            }
        }

        public async Task<CCar> getRunStateCar()
        {
            var rs = await Service_runstate.Queryable();
            if (rs == null)
                return null;
            var ccar = new CCar
            {
                VINCode = string.IsNullOrEmpty(rs.vin) ? string.Empty : rs.vin,
                TireRFID = string.IsNullOrEmpty(rs.dsgrf) ? string.Empty : rs.dsgrf,
                TireRFMdl = string.IsNullOrEmpty(rs.mdlrf) ? string.Empty : rs.mdlrf,
                TireRFPre = string.IsNullOrEmpty(rs.prerf) ? string.Empty : rs.prerf,
                TireRFTemp = string.IsNullOrEmpty(rs.temprf) ? string.Empty : rs.temprf,
                TireRFBattery = string.IsNullOrEmpty(rs.batteryrf) ? string.Empty : rs.batteryrf,
                TireRFAcSpeed = string.IsNullOrEmpty(rs.acspeedrf) ? string.Empty : rs.acspeedrf,
                TireLFID = string.IsNullOrEmpty(rs.dsglf) ? string.Empty : rs.dsglf,
                TireLFMdl = string.IsNullOrEmpty(rs.mdllf) ? string.Empty : rs.mdllf,
                TireLFPre = string.IsNullOrEmpty(rs.prelf) ? string.Empty : rs.prelf,
                TireLFTemp = string.IsNullOrEmpty(rs.templf) ? string.Empty : rs.templf,
                TireLFBattery = string.IsNullOrEmpty(rs.batterylf) ? string.Empty : rs.batterylf,
                TireLFAcSpeed = string.IsNullOrEmpty(rs.acspeedlf) ? string.Empty : rs.acspeedlf,
                TireRRID = string.IsNullOrEmpty(rs.dsgrr) ? string.Empty : rs.dsgrr,
                TireRRMdl = string.IsNullOrEmpty(rs.mdlrr) ? string.Empty : rs.mdlrr,
                TireRRPre = string.IsNullOrEmpty(rs.prerr) ? string.Empty : rs.prerr,
                TireRRTemp = string.IsNullOrEmpty(rs.temprr) ? string.Empty : rs.temprr,
                TireRRBattery = string.IsNullOrEmpty(rs.batteryrr) ? string.Empty : rs.batteryrr,
                TireRRAcSpeed = string.IsNullOrEmpty(rs.acspeedrr) ? string.Empty : rs.acspeedrr,
                CarType = string.Empty,
            };
            return ccar;
        }

        public async Task resetState()
        {
            await Service_runstate.InitRunState();
        }

        public async Task delColl(string vin)
        {
            await Service_vincoll.DeleteableVIN(vin);
        }

        public async Task<bool> hasDSG(string vin)
        {
            var tmp = await Service_vincoll.Queryablevincoll(vin);
            if (tmp != null)
                return tmp.tpms;
            else
                return false;
        }
    }
}
