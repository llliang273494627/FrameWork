using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Configuration;
using System.Threading;
using System.Runtime.InteropServices;
using GACNew_VCU_Writer;
using Common.Logging;
using GACNew_VCU_Writer_BLL;
using System.IO.Ports;
using System.IO;
using System.Drawing.Printing;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.Drawing.Imaging;
using Automation.BDaq;
using ModBusHelp;
using Microsoft.Reporting.WinForms;
using ZXing;
using ZXing.Common;
using FrameWork.Model.Comm;
using FrameWork.Model.Models;
using GACNew_VCU_Writer.Comm;

namespace GACNew_VCU_Writer
{
    #region 委托

    public delegate void CloseVCIDelegate(Label[] label);
    public delegate void ShowMessageDelegate(Label label, string txt, Color color);
    public delegate void ChangeColorDelegate(Color color);
    public delegate void ButtonDelegate(Button button, string txt);
    public delegate void ButtonClickDelegate(object sender, EventArgs e);
    public delegate void GetPrintDelegate(PrintInfo info);
    public delegate void SetprogressBarDelegate(ProgressBar progressBar, int value, int max);
    public delegate void MyInvoke(Parameter param);
    public delegate void ShowDelegate(TextBox tb,string txt);
    public delegate void FileDelegate(ComboBox cb1, ComboBox cb2, ComboBox cb3, string txt1, string txt2,string txt3);

    #endregion

    public partial class FrmMain : Form
    {
        #region 委托对象

        /// <summary>
        /// 清除VCI的委托
        /// </summary>
        private CloseVCIDelegate closeVCIDelegate = null;
        /// <summary>
        /// 显示消息的委托
        /// </summary>
        private ShowMessageDelegate showMessageDelegate = null;
        /// <summary>
        /// 处理图片的委托
        /// </summary>
        private ButtonDelegate buttonDelegate = null;
        /// <summary>
        /// 
        /// </summary>
        private ButtonClickDelegate buttonClickDelegate = null;
        /// <summary>
        /// 打印委托
        /// </summary>
        private GetPrintDelegate printDelegate = null;
        /// <summary>
        /// 改变颜色的委托
        /// </summary>
        private ChangeColorDelegate changeColorDelegate = null;
        /// <summary>
        /// 进度条委托
        /// </summary>
        private SetprogressBarDelegate progressBarDelegate = null;
        /// <summary>
        /// 零件条码委托
        /// </summary>
        private ShowDelegate showDelegate = null;
        /// <summary>
        /// 刷写文件显示委托
        /// </summary>
        private FileDelegate fileDelegate = null;

        #endregion

        #region IO对象

        private static Parameter io1 = null;
        private static Parameter io2 = null;
        private static Parameter io3 = null;
        private static Parameter io4 = null;
        private static Parameter io5 = null;
        private static Parameter io6 = null;
        private static Parameter io7 = null;
        private static Parameter io8 = null;

        #endregion

        #region 私有变量

        private BackgroundWorker bgWorker = new BackgroundWorker();

        /// <summary>
        /// 配置对象
        /// </summary>
        private static Configer configer = new Configer();
        /// <summary>
        /// MTOC配置对象
        /// </summary>
        private static VCUconfig config = new VCUconfig();
        /// <summary>
        /// 扫描枪串口对象
        /// </summary>
        private static SerialPort serialPortScanGunCom = null;
        /// <summary>
        /// 本地连接字符串
        /// </summary>
        private static readonly string localConnectionString = ConfigurationManager.ConnectionStrings["localCnnStr"] + "";
        /// <summary>
        /// 扫描枪串口号
        /// </summary>
        private static readonly string comString = ConfigurationManager.AppSettings["COM"];
        /// <summary>
        /// 定时检查状态IO1
        /// </summary>
        private static System.Threading.Timer timeCheckIO1 = null;
        /// <summary>
        /// 定时检查状态IO2
        /// </summary>
        private static System.Threading.Timer timeCheckIO2 = null;
        /// <summary>
        /// 定时检查状态IO3
        /// </summary>
        private static System.Threading.Timer timeCheckIO3 = null;
        /// <summary>
        /// 定时检查状态IO4
        /// </summary>
        private static System.Threading.Timer timeCheckIO4 = null;
        /// <summary>
        /// 定时检查状态IO5
        /// </summary>
        private static System.Threading.Timer timeCheckIO5 = null;
        /// <summary>
        /// 定时检查状态IO6
        /// </summary>
        private static System.Threading.Timer timeCheckIO6 = null;
        /// <summary>
        /// 定时检查状态IO7
        /// </summary>
        private static System.Threading.Timer timeCheckIO7 = null;
        /// <summary>
        /// 定时检查状态IO8
        /// </summary>
        private static System.Threading.Timer timeCheckIO8 = null;
        /// <summary>
        /// 初始化输出IO
        /// </summary>
        private static Automation.BDaq.InstantDoCtrl instantDoCtrl = new Automation.BDaq.InstantDoCtrl();
        /// <summary>
        /// 初始化输入IO
        /// </summary>
        private static Automation.BDaq.InstantDiCtrl instantDiCtrl = new Automation.BDaq.InstantDiCtrl();
        /// <summary>
        /// 打印结果数据
        /// </summary>
        private static Form1 printResult = null;

        /// <summary>
        /// crc校验
        /// </summary>
        CRC32Cls crc = new CRC32Cls();
        /// <summary>
        /// bin文件CRC校验码
        /// </summary>
        string crCstr = "00000000";
        /// <summary>
        /// direr文件CRC校验码
        /// </summary>
        string direrStr = "00000000";
        /// <summary>
        /// cal文件CRC校验码
        /// </summary>
        string calcrcStr = "00000000";
        /// <summary>
        /// 删除多少天之前的数据
        /// </summary>
        int DeleteLogDay;
        /// <summary>
        /// 日志文件，每刷一次生成一个日志文件
        /// </summary>
        string filePath = "";
        /// <summary>
        /// 控制灯柱
        /// </summary>
        ModBusWrapper Wrapper = ModBusWrapper.CreateInstance(Protocol.TCPIP);
        /// <summary>
        /// 响应地址
        /// </summary>
        private uint response = 0;
        /// <summary>
        /// 驱动文件路径
        /// </summary>
        private string FlashPath = null;
        /// <summary>
        /// 应用文件路径
        /// </summary>
        private string WritePath = null;
        /// <summary>
        /// 标定文件路径
        /// </summary>
        private string CalPath = null;
        /// <summary>
        /// 自动模式下定位的VIN
        /// </summary>
        private string vin = null;
        /// <summary>
        /// 设备号
        /// </summary>
        private string num = null;

        LocalReport report = new LocalReport();

        BindingSource bs = new BindingSource();

        #endregion

        #region CAN通迅私有变量

        /// <summary>
        /// CAN是否打开的全局标识
        /// </summary>
        UInt32 m_bOpen = 0;
        /// <summary>
        /// 波特率
        /// </summary>
        static UInt32[] GCanBrTab = new UInt32[10] { 0x060003, 0x060004, 0x060007, 0x1C0008, 0x1C0011, 0x160023, 0x1C002C, 0x1600B3, 0x1C00E0, 0x1C01C1 };
        /// <summary>
        /// 成功标识
        /// </summary>
        const UInt32 STATUS_OK = 1;
        /// <summary>
        /// 接收线程
        /// </summary>
        private Thread threadReceive = null;
        #endregion

        #region 导入的方法

        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_OpenDevice(UInt32 DeviceType, UInt32 DeviceInd, UInt32 Reserved);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_CloseDevice(UInt32 DeviceType, UInt32 DeviceInd);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_InitCAN(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_INIT_CONFIG pInitConfig);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_ReadBoardInfo(UInt32 DeviceType, UInt32 DeviceInd, ref VCI_BOARD_INFO pInfo);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_ReadErrInfo(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_ERR_INFO pErrInfo);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_ReadCANStatus(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_CAN_STATUS pCANStatus);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_GetReference(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, UInt32 RefType, ref byte pData);
        [DllImport("controlcan.dll")]
        //static extern UInt32 VCI_SetReference(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, UInt32 RefType, ref byte pData);
        unsafe static extern UInt32 VCI_SetReference(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, UInt32 RefType, byte* pData);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_GetReceiveNum(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_ClearBuffer(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_StartCAN(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_ResetCAN(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_Transmit(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_CAN_OBJ pSend, UInt32 Len);
        //[DllImport("controlcan.dll")]
        //static extern UInt32 VCI_Receive(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_CAN_OBJ pReceive, UInt32 Len, Int32 WaitTime);
        [DllImport("controlcan.dll", CharSet = CharSet.Ansi)]
        static extern UInt32 VCI_Receive(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, IntPtr pReceive, UInt32 Len, Int32 WaitTime);

        #endregion

        public FrmMain()
        {
            InitializeComponent();
        }

        #region 初始化

        /// <summary>
        /// 加载主窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //初始化系统
            InitSystem();
            //CheckForIllegalCrossThreadCalls = false; 
        }
        /// <summary>
        /// 初始化系统
        /// </summary>
        private async void InitSystem()
        {
            try
            {
                #region 驱动文件夹绝对路径

                //驱动bin文件夹路径
                FlashPath = ConfigurationManager.AppSettings["driverPos"] + "";
                DirectoryInfo FlashFolder = new DirectoryInfo(FlashPath);
                foreach (FileInfo file in FlashFolder.GetFiles("*.bin"))
                {
                    this.combxFB1.Items.Add(file.Name);
                    this.combxFB2.Items.Add(file.Name);
                    this.combxFB3.Items.Add(file.Name);
                    this.combxFB4.Items.Add(file.Name);
                    this.combxFB5.Items.Add(file.Name);
                    this.combxFB6.Items.Add(file.Name);
                    this.combxFB7.Items.Add(file.Name);
                    this.combxFB8.Items.Add(file.Name);
                }
                
                //写入bin文件夹路径
                WritePath = ConfigurationManager.AppSettings["writePos"] + "";
                DirectoryInfo WriteFolder = new DirectoryInfo(WritePath);
                foreach (FileInfo file in WriteFolder.GetFiles("*.bin"))
                {
                    this.combxWB1.Items.Add(file.Name);
                    this.combxWB2.Items.Add(file.Name);
                    this.combxWB3.Items.Add(file.Name);
                    this.combxWB4.Items.Add(file.Name);
                    this.combxWB5.Items.Add(file.Name);
                    this.combxWB6.Items.Add(file.Name);
                    this.combxWB7.Items.Add(file.Name);
                    this.combxWB8.Items.Add(file.Name);
                }
                //Cal bin文件夹路径
                CalPath = ConfigurationManager.AppSettings["calPos"] + "";
                DirectoryInfo CalFolder = new DirectoryInfo(CalPath);
                foreach (FileInfo file in CalFolder.GetFiles("*.bin"))
                {
                    this.combxCB1.Items.Add(file.Name);
                    this.combxCB2.Items.Add(file.Name);
                    this.combxCB3.Items.Add(file.Name);
                    this.combxCB4.Items.Add(file.Name);
                    this.combxCB5.Items.Add(file.Name);
                    this.combxCB6.Items.Add(file.Name);
                    this.combxCB7.Items.Add(file.Name);
                    this.combxCB8.Items.Add(file.Name);
                }

                #endregion

                #region 委托

                //关闭VCI的委托对象
                this.closeVCIDelegate = new CloseVCIDelegate(this.CloseVCIMethod);
                //初始化显示数据的委托对象
                this.showMessageDelegate = new ShowMessageDelegate(this.ShowMessage);
                //初始化改变颜色的委托对象
                this.changeColorDelegate = new ChangeColorDelegate(this.ChangeColor);
                //初始化显示数据的委托对象
                this.buttonDelegate = new ButtonDelegate(this.ButtonClick);
                ////打印委托
                //this.printDelegate = new GetPrintDelegate(this.GetPrint);
                //进度条委托
                this.progressBarDelegate = new SetprogressBarDelegate(this.SetBar);
                this.showDelegate = new ShowDelegate(this.ShowInfo);
                this.fileDelegate = new FileDelegate(this.ShowFileName);

                #endregion

                #region 从数据库中读取配置

                //初始化配置对象
                configer = new Configer(localConnectionString);
                //读取MES连接字符串
                //configer.MESCnnStr = configer.GetConfigValue("T_RunParam", "DB", "MESCnnStr");
                configer.MESCnnStr =await SqlComm.GetConfigValue("DB", "MESCnnStr");
                //MES的IP
                //configer.MES_IP = configer.GetConfigValue("T_RunParam", "MES", "MESIP");
                //设备类型
                //configer.DevType = UInt32.Parse(configer.GetConfigValue("T_RunParam", "CAN", "DevType"));
                configer.DevType = UInt32.Parse(await SqlComm.GetConfigValue("CAN", "DevType"));
                //设备索引号
                //configer.DevInd = UInt32.Parse(configer.GetConfigValue("T_RunParam", "CAN", "DevInd"));
                configer.DevInd = UInt32.Parse(await SqlComm.GetConfigValue("CAN", "DevInd"));
                //写入失败后尝试次数
                //configer.WriteTimes = int.Parse(configer.GetConfigValue("T_RunParam", "CAN", "WriteTimes"));
                configer.WriteTimes = int.Parse(await SqlComm.GetConfigValue("CAN", "WriteTimes"));
                //线程停止时间
                //configer.ThreadSleep = int.Parse(configer.GetConfigValue("T_RunParam", "Thread", "Sleep"));
                configer.ThreadSleep = int.Parse(await SqlComm.GetConfigValue("Thread", "Sleep"));
                //等待指令
                //configer.WaitCode = configer.GetConfigValue("T_RunParam", "Code", "WaitCode");
                configer.WaitCode =await SqlComm.GetConfigValue("Code", "WaitCode");
                //无线条码枪串口号
                //configer.PortNum = int.Parse(configer.GetConfigValue("T_RunParam", "BarCodeGun", "WirledCodeGun_PortNum"));
                configer.PortNum = int.Parse(await SqlComm.GetConfigValue("BarCodeGun", "WirledCodeGun_PortNum"));
                //无线条码枪串口设置
                //string portSetting = configer.GetConfigValue("T_RunParam", "BarCodeGun", "WirledCodeGun_Settings");
                string portSetting =await SqlComm.GetConfigValue("BarCodeGun", "WirledCodeGun_Settings");

                #region 初始化并打开扫描枪对象

                //初始化扫描枪对象
                serialPortScanGunCom = InitSerialPort(configer.PortNum, portSetting);
                //绑定接收数据的方法
                serialPortScanGunCom.DataReceived += new SerialDataReceivedEventHandler(serialPortScanGunCom_DataReceived);
                //关闭串口
                if (serialPortScanGunCom.IsOpen) serialPortScanGunCom.Close();
                //打开串口
                serialPortScanGunCom.Open();

                #endregion

                //io1 = GenerateIO(configer.GetConfigValue("T_RunParam", "IO", "IO1"));
                io1 = GenerateIO(await SqlComm.GetConfigValue("IO", "IO1"));
                io1.ButtonClickDelegate_Prop = new ButtonClickDelegate(this.btStart1_Click);
                
                //io2 = GenerateIO(configer.GetConfigValue("T_RunParam", "IO", "IO2"));
                io2 = GenerateIO(await SqlComm.GetConfigValue("IO", "IO2"));
                io2.ButtonClickDelegate_Prop = new ButtonClickDelegate(this.btStart2_Click);

                //io3 = GenerateIO(configer.GetConfigValue("T_RunParam", "IO", "IO3"));
                io3 = GenerateIO(await SqlComm.GetConfigValue("IO", "IO3"));
                io3.ButtonClickDelegate_Prop = new ButtonClickDelegate(this.btStart3_Click);
                
                //io4 = GenerateIO(configer.GetConfigValue("T_RunParam", "IO", "IO4"));
                io4 = GenerateIO(await SqlComm.GetConfigValue("IO", "IO4"));
                io4.ButtonClickDelegate_Prop = new ButtonClickDelegate(this.btStart4_Click);
                
                //io5 = GenerateIO(configer.GetConfigValue("T_RunParam", "IO", "IO5"));
                io5 = GenerateIO(await SqlComm.GetConfigValue("IO", "IO5"));
                io5.ButtonClickDelegate_Prop = new ButtonClickDelegate(this.btStart5_Click);

                //io6 = GenerateIO(configer.GetConfigValue("T_RunParam", "IO", "IO6"));
                io6 = GenerateIO(await SqlComm.GetConfigValue("IO", "IO6"));
                io6.ButtonClickDelegate_Prop = new ButtonClickDelegate(this.btStart6_Click);
                
                //io7 = GenerateIO(configer.GetConfigValue("T_RunParam", "IO", "IO7"));
                io7 = GenerateIO(await SqlComm.GetConfigValue("IO", "IO7"));
                io7.ButtonClickDelegate_Prop = new ButtonClickDelegate(this.btStart7_Click);

                //io8 = GenerateIO(configer.GetConfigValue("T_RunParam", "IO", "IO8"));
                io8 = GenerateIO(await SqlComm.GetConfigValue("IO", "IO8"));
                io8.ButtonClickDelegate_Prop = new ButtonClickDelegate(this.btStart8_Click);

                //获得VCU响应地址
                //response = configer.GetVCUCodeList();
                response =await SqlComm.GetVCUCodeList();
                //删除多少天之前的日志文件
                //this.DeleteLogDay = int.Parse(configer.GetConfigValue("T_RunParam", "Del", "DeleteLog"));
                this.DeleteLogDay = int.Parse(await SqlComm.GetConfigValue("Del", "DeleteLog"));
                //删除日志                                 -
                if (DeleteLogDay > 0)
                {
                    Log.DeleteLog(DeleteLogDay);
                }
                ////初始化输出IO
                //instantDoCtrl.SelectedDevice = new DeviceInformation("PCI-1730,BID#0");
                ////初始化输入IO
                //instantDiCtrl.SelectedDevice = new DeviceInformation("PCI-1730,BID#0");

                //选择自动/手动模式
                if (this.btnSelect.Text == "手动模式")
                {
                    this.lbVIN.Visible = false;
                    this.tbVIN.Visible = false;
                }

                else if (this.btnSelect.Text == "自动模式")
                {
                    this.lbVIN.Visible = true;
                    this.tbVIN.Visible = true;
                } 

                #endregion
                   
            }
            catch (Exception ex)
            {
               // logger.Error(ex.Message + "***" + ex.StackTrace);
                Log.writeTxt(ex.Message + "***" + ex.StackTrace, filePath);
            }
            finally
            {
                //启动检测thread(实时监测IO输入状态)
                timeCheckIO1 = new System.Threading.Timer(new System.Threading.TimerCallback(timCheck), io1, 0, 100);
                timeCheckIO2 = new System.Threading.Timer(new System.Threading.TimerCallback(timCheck), io2, 0, 100);
                timeCheckIO3 = new System.Threading.Timer(new System.Threading.TimerCallback(timCheck), io3, 0, 100);
                timeCheckIO4 = new System.Threading.Timer(new System.Threading.TimerCallback(timCheck), io4, 0, 100);
                timeCheckIO5 = new System.Threading.Timer(new System.Threading.TimerCallback(timCheck), io5, 0, 100);
                timeCheckIO6 = new System.Threading.Timer(new System.Threading.TimerCallback(timCheck), io6, 0, 100);
                timeCheckIO7 = new System.Threading.Timer(new System.Threading.TimerCallback(timCheck), io7, 0, 100);
                timeCheckIO8 = new System.Threading.Timer(new System.Threading.TimerCallback(timCheck), io8, 0, 100);
            }
        }
        

        private Parameter GenerateIO(string configer)
        {
            Parameter ioTmp = new Parameter();

            try
            {
                string[] ioStrings = configer.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                ioTmp.Input = int.Parse(ioStrings[0]);
                ioTmp.Output = int.Parse(ioStrings[1]);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ioTmp;
        }

        #endregion

        #region 按钮刷写事件

        private void btStart1_Click(object sender, EventArgs e)
        {
            Parameter senderIO = sender as Parameter;
            ErrorCode err = ErrorCode.Success;
            if ((senderIO != null && senderIO.CanUse == false))
            {
                //灯亮
                err = instantDoCtrl.WriteBit(0, senderIO.Output, (byte)1);
                if (this.btnSelect.Text == "手动模式")
                {
                    if (this.combxFB1.Text != "" && this.combxWB1.Text != "" && this.combxCB1.Text != "")
                    {
                        //senderIO.Driver = this.combxFB1.Text;
                        //senderIO.Write = this.combxWB1.Text;
                        //senderIO.Cal = this.combxCB1.Text;
                        //senderIO.Num = 1;
                        //senderIO.Label_Attribute = this.lbMessage1;
                        //senderIO.ProgressBar_Attribute = this.progressBar1;
                        //senderIO.Button_Attribute = this.btStart1;
                        Parameter param = new Parameter(this.combxFB1.Text, this.combxWB1.Text, this.combxCB1.Text, 1, this.lbMessage1, this.progressBar1, this.btStart1,this.tbTracCode1.Text);
                        Thread thread = new Thread(new ParameterizedThreadStart(DoWork));
                        thread.IsBackground = true;
                        thread.Start(param);
                    }
                    else
                    {
                        MessageBox.Show("请选择完整的需要刷写的文件！");
                    }
                }
                else if (this.btnSelect.Text == "自动模式")
                {
                    this.FlashPath=config.DriverPath;
                    this.WritePath=config.BinPath;
                    this.CalPath=config.CalPath;
                    Parameter param = new Parameter(config.DriverName, this.combxWB1.Text, this.combxCB1.Text, 1, this.lbMessage1, this.progressBar1, this.btStart1, this.tbTracCode1.Text);

                    Thread thread = new Thread(new ParameterizedThreadStart(DoWork));
                    thread.IsBackground = true;
                    thread.Start(param);
                }
                
            }
            else if(sender != null && e!= null)
            {
                //if (this.combxFB1.Text != "" && this.combxWB1.Text != "" && this.combxCB1.Text != "")
                //{
                //    Parameter param = new Parameter(this.combxFB1.Text, this.combxWB1.Text, this.combxCB1.Text, 1, this.lbMessage1, this.progressBar1, this.btStart1);

                //    Thread thread = new Thread(new ParameterizedThreadStart(DoWork));
                //    thread.IsBackground = true;
                //    thread.Start(param);
                //}
                //else
                //{
                //    MessageBox.Show("请选择完整的需要刷写的文件！");
                //}

                if (this.btnSelect.Text == "手动模式")
                {
                    if (this.combxFB1.Text != "" && this.combxWB1.Text != "" && this.combxCB1.Text != "" && this.tbTracCode1.Text!="")
                    {
                        //senderIO.Driver = this.combxFB1.Text;
                        //senderIO.Write = this.combxWB1.Text;
                        //senderIO.Cal = this.combxCB1.Text;
                        //senderIO.Num = 1;
                        //senderIO.Label_Attribute = this.lbMessage1;
                        //senderIO.ProgressBar_Attribute = this.progressBar1;
                        //senderIO.Button_Attribute = this.btStart1;

                        Parameter param = new Parameter(this.combxFB1.Text, this.combxWB1.Text, this.combxCB1.Text, 1, this.lbMessage1,this.lbResult1, this.progressBar1, this.btStart1, this.tbVIN1.Text, this.tbTracCode1.Text);

                        Thread thread = new Thread(new ParameterizedThreadStart(DoWork));
                        thread.IsBackground = true;
                        thread.Start(param);
                    }
                    else
                    {
                        MessageBox.Show("请选择完整的需要刷写的文件和追溯码！");
                    }
                }
                else if (this.btnSelect.Text == "自动模式")
                {
                    this.FlashPath = config.DriverPath;
                    this.WritePath = config.BinPath;
                    this.CalPath = config.CalPath;
                    Parameter param = new Parameter(this.combxFB1.Text, this.combxWB1.Text, this.combxCB1.Text, 1, this.lbMessage1, this.lbResult1, this.progressBar1, this.btStart1, this.tbVIN1.Text, this.tbTracCode1.Text);

                    //bgWorker.RunWorkerAsync(param);

                    Thread thread = new Thread(new ParameterizedThreadStart(DoWork));
                    thread.IsBackground = true;
                    thread.Start(param);
                }
            }
        }

        private void btStart2_Click(object sender, EventArgs e)
        {
            Parameter senderIO = sender as Parameter;
            ErrorCode err = ErrorCode.Success;

            if ((senderIO != null && senderIO.CanUse == false))
            {
                //灯亮
                err = instantDoCtrl.WriteBit(0, senderIO.Output, (byte)1);

                if (this.combxFB2.Text != "" && this.combxWB2.Text != "" && this.combxCB2.Text != "")
                {
                    //senderIO.Driver = this.combxFB1.Text;
                    //senderIO.Write = this.combxWB1.Text;
                    //senderIO.Cal = this.combxCB1.Text;
                    //senderIO.Num = 2;
                    //senderIO.Label_Attribute = this.lbMessage2;
                    //senderIO.ProgressBar_Attribute = this.progressBar2;
                    //senderIO.Button_Attribute = this.btStart2;

                    Parameter param = new Parameter(this.combxFB2.Text, this.combxWB2.Text, this.combxCB2.Text, 2, this.lbMessage2, this.progressBar2, this.btStart2, this.tbTracCode2.Text);

                    Thread thread = new Thread(new ParameterizedThreadStart(DoWork));
                    thread.IsBackground = true;
                    thread.Start(param);
                }
                else
                {
                    MessageBox.Show("请选择完整的需要刷写的文件！");
                }
            }
            else if (sender != null && e != null)
            {
                if (this.btnSelect.Text == "手动模式")
                {
                    if (this.combxFB2.Text != "" && this.combxWB2.Text != "" && this.combxCB2.Text != "")
                    {
                        Parameter param = new Parameter(this.combxFB2.Text, this.combxWB2.Text, this.combxCB2.Text, 2, this.lbMessage2, this.lbResult2, this.progressBar2, this.btStart2, this.tbVIN2.Text, this.tbTracCode2.Text);

                        Thread thread = new Thread(new ParameterizedThreadStart(DoWork));
                        thread.IsBackground = true;
                        thread.Start(param);
                    }
                    else
                    {
                        MessageBox.Show("请选择完整的需要刷写的文件！");
                    }
                }
                
                else if (this.btnSelect.Text == "自动模式")
                {
                    this.FlashPath = config.DriverPath;
                    this.WritePath = config.BinPath;
                    this.CalPath = config.CalPath;
                    Parameter param = new Parameter(this.combxFB2.Text, this.combxWB2.Text, this.combxCB2.Text, 2, this.lbMessage2, this.lbResult2, this.progressBar2, this.btStart2, this.tbVIN2.Text, this.tbTracCode2.Text);

                    Thread thread = new Thread(new ParameterizedThreadStart(DoWork));
                    thread.IsBackground = true;
                    thread.Start(param);
                }
            }

            #region Comment out

            //IOButtion senderIO = sender as IOButtion;
            //ErrorCode err = ErrorCode.Success;

            //if ((senderIO != null && senderIO.CanUse == false))
            //{
            //    err = instantDoCtrl.WriteBit(0, senderIO.Output, (byte)1);

            //    if (this.combxFB1.Text != "" && this.combxWB1.Text != "" && this.combxCB1.Text != "")
            //    {
            //        Parameter param = new Parameter(this.combxFB1.Text, this.combxWB1.Text, this.combxCB1.Text, 2, this.lbMessage2, this.progressBar2, this.btStart2);
            //        Thread thread = new Thread(new ParameterizedThreadStart(DoWork));
            //        thread.IsBackground = true;
            //        thread.Start(param);
            //    }
            //    else
            //    {
            //        MessageBox.Show("请选择完整的需要刷写的文件！");
            //    }
            //}
            //else if (sender != null && e != null)
            //{
            //    if (this.combxFB1.Text != "" && this.combxWB1.Text != "" && this.combxCB1.Text != "")
            //    {
            //        Parameter param = new Parameter(this.combxFB1.Text, this.combxWB1.Text, this.combxCB1.Text, 2, this.lbMessage2, this.progressBar2, this.btStart2);
            //        Thread thread = new Thread(new ParameterizedThreadStart(DoWork));
            //        thread.IsBackground = true;
            //        thread.Start(param);
            //    }
            //    else
            //    {
            //        MessageBox.Show("请选择完整的需要刷写的文件！");
            //    }
            //}

            #endregion
        }

        private void btStart3_Click(object sender, EventArgs e)
        {
            Parameter senderIO = sender as Parameter;
            ErrorCode err = ErrorCode.Success;

            if ((senderIO != null && senderIO.CanUse == false))
            {
                //灯亮
                err = instantDoCtrl.WriteBit(0, senderIO.Output, (byte)1);

                if (this.combxFB3.Text != "" && this.combxWB3.Text != "" && this.combxCB3.Text != "")
                {
                    //senderIO.Driver = this.combxFB1.Text;
                    //senderIO.Write = this.combxWB1.Text;
                    //senderIO.Cal = this.combxCB1.Text;
                    //senderIO.Num = 3;
                    //senderIO.Label_Attribute = this.lbMessage3;
                    //senderIO.ProgressBar_Attribute = this.progressBar3;
                    //senderIO.Button_Attribute = this.btStart3;

                    Parameter param = new Parameter(this.combxFB3.Text, this.combxWB3.Text, this.combxCB3.Text, 3, this.lbMessage3, this.progressBar3, this.btStart3, this.tbTracCode3.Text);

                    Thread thread = new Thread(new ParameterizedThreadStart(DoWork));
                    thread.IsBackground = true;
                    thread.Start(param);
                }
                else
                {
                    MessageBox.Show("请选择完整的需要刷写的文件！");
                }
            }
            else if (sender != null && e != null)
            {
                if (this.btnSelect.Text == "手动模式")
                {
                    if (this.combxFB3.Text != "" && this.combxWB3.Text != "" && this.combxCB3.Text != "")
                    {
                        Parameter param = new Parameter(this.combxFB3.Text, this.combxWB3.Text, this.combxCB3.Text, 3, this.lbMessage3, this.lbResult3, this.progressBar3, this.btStart3, this.tbVIN3.Text, this.tbTracCode3.Text);

                        Thread thread = new Thread(new ParameterizedThreadStart(DoWork));
                        thread.IsBackground = true;
                        thread.Start(param);
                    }
                    else
                    {
                        MessageBox.Show("请选择完整的需要刷写的文件！");
                    }
                }
                else if (this.btnSelect.Text == "自动模式")
                {
                    this.FlashPath = config.DriverPath;
                    this.WritePath = config.BinPath;
                    this.CalPath = config.CalPath;
                    Parameter param = new Parameter(this.combxFB3.Text, this.combxWB3.Text, this.combxCB3.Text, 3, this.lbMessage3, this.lbResult3, this.progressBar3, this.btStart3, this.tbVIN3.Text, this.tbTracCode3.Text);

                    Thread thread = new Thread(new ParameterizedThreadStart(DoWork));
                    thread.IsBackground = true;
                    thread.Start(param);
                }
            }

            #region comment out 

            //IOButtion senderIO = sender as IOButtion;
            //ErrorCode err = ErrorCode.Success;

            //if ((senderIO != null && senderIO.CanUse == false))
            //{
            //    err = instantDoCtrl.WriteBit(0, senderIO.Output, (byte)1);

            //    if (this.combxFB1.Text != "" && this.combxWB1.Text != "" && this.combxCB1.Text != "")
            //    {
            //        Parameter param = new Parameter(this.combxFB1.Text, this.combxWB1.Text, this.combxCB1.Text, 2, this.lbMessage3, this.progressBar3, this.btStart3);
            //        Thread thread = new Thread(new ParameterizedThreadStart(DoWork));
            //        thread.IsBackground = true;
            //        thread.Start(param);
            //    }
            //    else
            //    {
            //        MessageBox.Show("请选择完整的需要刷写的文件！");
            //    }
            //}
            //else if (sender != null && e != null)
            //{
            //    if (this.combxFB1.Text != "" && this.combxWB1.Text != "" && this.combxCB1.Text != "")
            //    {
            //        Parameter param = new Parameter(this.combxFB1.Text, this.combxWB1.Text, this.combxCB1.Text, 2, this.lbMessage3, this.progressBar3, this.btStart3);
            //        Thread thread = new Thread(new ParameterizedThreadStart(DoWork));
            //        thread.IsBackground = true;
            //        thread.Start(param);
            //    }
            //    else
            //    {
            //        MessageBox.Show("请选择完整的需要刷写的文件！");
            //    }
            //}

            #endregion
        }

        private void btStart4_Click(object sender, EventArgs e)
        {
            Parameter senderIO = sender as Parameter;
            ErrorCode err = ErrorCode.Success;

            if ((senderIO != null && senderIO.CanUse == false))
            {
                //灯亮
                err = instantDoCtrl.WriteBit(0, senderIO.Output, (byte)1);

                if (this.combxFB4.Text != "" && this.combxWB4.Text != "" && this.combxCB4.Text != "")
                {
                    //senderIO.Driver = this.combxFB1.Text;
                    //senderIO.Write = this.combxWB1.Text;
                    //senderIO.Cal = this.combxCB1.Text;
                    //senderIO.Num = 4;
                    //senderIO.Label_Attribute = this.lbMessage4;
                    //senderIO.ProgressBar_Attribute = this.progressBar4;
                    //senderIO.Button_Attribute = this.btStart4;

                    Parameter param = new Parameter(this.combxFB4.Text, this.combxWB4.Text, this.combxCB4.Text, 4, this.lbMessage4, this.progressBar4, this.btStart4, this.tbTracCode4.Text);

                    Thread thread = new Thread(new ParameterizedThreadStart(DoWork));
                    thread.IsBackground = true;
                    thread.Start(param);
                }
                else
                {
                    MessageBox.Show("请选择完整的需要刷写的文件！");
                }
            }
            else if (sender != null && e != null)
            {
                if (this.btnSelect.Text == "手动模式")
                {
                    if (this.combxFB4.Text != "" && this.combxWB4.Text != "" && this.combxCB4.Text != "")
                    {
                        Parameter param = new Parameter(this.combxFB4.Text, this.combxWB4.Text, this.combxCB4.Text, 4, this.lbMessage4, this.lbResult4, this.progressBar4, this.btStart4, this.tbVIN4.Text, this.tbTracCode4.Text);

                        Thread thread = new Thread(new ParameterizedThreadStart(DoWork));
                        thread.IsBackground = true;
                        thread.Start(param);
                    }
                    else
                    {
                        MessageBox.Show("请选择完整的需要刷写的文件！");
                    }
                }
                else if (this.btnSelect.Text == "自动模式")
                {
                    this.FlashPath = config.DriverPath;
                    this.WritePath = config.BinPath;
                    this.CalPath = config.CalPath;
                    Parameter param = new Parameter(this.combxFB4.Text, this.combxWB4.Text, this.combxCB4.Text, 4, this.lbMessage4, this.lbResult4, this.progressBar4, this.btStart4, this.tbVIN4.Text, this.tbTracCode4.Text);

                    Thread thread = new Thread(new ParameterizedThreadStart(DoWork));
                    thread.IsBackground = true;
                    thread.Start(param);
                }
            }

            #region Comment out

            //IOButtion ioTmp = sender as IOButtion;
            //ErrorCode err = ErrorCode.Success;

            //if (ioTmp != null)
            //{
            //    err = instantDoCtrl.WriteBit(0, ioTmp.Output, (byte)1);
            //}

            //if (btStart4.Text == "开始刷写")
            //{
            //    //err = instantDoCtrl.Write(0, (byte)(Opos3 + 1));
            //    Thread.Sleep(100);
            //    if (this.combxFB1.Text != "" && this.combxWB1.Text != "" && this.combxCB1.Text != "")
            //    {
            //        this.Invoke(this.buttonDelegate, new object[] { btStart4, "停止刷写" });
            //        Parameter param = new Parameter(this.combxFB1.Text, this.combxWB1.Text, this.combxCB1.Text, 4, this.lbMessage4, this.progressBar4, this.btStart4);
            //        Thread thread = new Thread(new ParameterizedThreadStart(DoWork));
            //        thread.IsBackground = true;
            //        thread.Start(param);
            //    }

            //}
            //else if (btStart4.Text == "停止刷写")
            //{
            //    //关掉所有灯显示
            //    //err = instantDoCtrl.Write(0, (byte)0);
            //    try
            //    {
            //        MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            //        DialogResult dr = MessageBox.Show("该操作会清空界面数据，请确认未进行刷写操作", "系统复位", messButton);
            //        if (dr == DialogResult.OK)
            //        {
            //            //重置CAN卡
            //            VCI_ResetCAN(configer.DevType, configer.DevInd, 3);


            //            this.Invoke(this.buttonDelegate, new object[] { btStart4, "开始刷写" });
            //            Thread.Sleep(1000);
            //            this.Invoke(this.progressBarDelegate, new object[] { this.progressBar4, 0, 0 });
            //            //清空数据

            //            //Thread.Sleep(1000);
            //            this.Invoke(this.showMessageDelegate, new object[] { lbMessage4, "请重新开始刷写", Color.Green });
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        //logger.Error(ex.Message + "***" + ex.StackTrace);
            //        Log.writeTxt(ex.Message + "***" + ex.StackTrace, filePath);
            //    }
            //}

            #endregion
        }

        private void btStart5_Click(object sender, EventArgs e)
        {
            Parameter senderIO = sender as Parameter;
            ErrorCode err = ErrorCode.Success;

            if ((senderIO != null && senderIO.CanUse == false))
            {
                //灯亮
                err = instantDoCtrl.WriteBit(0, senderIO.Output, (byte)1);

                if (this.combxFB5.Text != "" && this.combxWB5.Text != "" && this.combxCB5.Text != "")
                {
                    //senderIO.Driver = this.combxFB1.Text;
                    //senderIO.Write = this.combxWB1.Text;
                    //senderIO.Cal = this.combxCB1.Text;
                    //senderIO.Num = 5;
                    //senderIO.Label_Attribute = this.lbMessage5;
                    //senderIO.ProgressBar_Attribute = this.progressBar5;
                    //senderIO.Button_Attribute = this.btStart5;

                    Parameter param = new Parameter(this.combxFB5.Text, this.combxWB5.Text, this.combxCB5.Text, 5, this.lbMessage5, this.progressBar5, this.btStart5, this.tbTracCode5.Text);

                    Thread thread = new Thread(new ParameterizedThreadStart(DoWork));
                    thread.IsBackground = true;
                    thread.Start(param);
                }
                else
                {
                    MessageBox.Show("请选择完整的需要刷写的文件！");
                }
            }
            else if (sender != null && e != null)
            {
                if (this.btnSelect.Text == "手动模式")
                {
                    if (this.combxFB5.Text != "" && this.combxWB5.Text != "" && this.combxCB5.Text != "")
                    {
                        Parameter param = new Parameter(this.combxFB5.Text, this.combxWB5.Text, this.combxCB5.Text, 5, this.lbMessage5, this.lbResult5, this.progressBar5, this.btStart5, this.tbVIN5.Text, this.tbTracCode5.Text);

                        Thread thread = new Thread(new ParameterizedThreadStart(DoWork));
                        thread.IsBackground = true;
                        thread.Start(param);
                    }
                    else
                    {
                        MessageBox.Show("请选择完整的需要刷写的文件！");
                    }
                }
                else if (this.btnSelect.Text == "自动模式")
                {
                    this.FlashPath = config.DriverPath;
                    this.WritePath = config.BinPath;
                    this.CalPath = config.CalPath;
                    Parameter param = new Parameter(this.combxFB5.Text, this.combxWB5.Text, this.combxCB5.Text, 5, this.lbMessage5, this.lbResult5, this.progressBar5, this.btStart5, this.tbVIN5.Text, this.tbTracCode5.Text);

                    Thread thread = new Thread(new ParameterizedThreadStart(DoWork));
                    thread.IsBackground = true;
                    thread.Start(param);
                }
            }

            #region Comment out

            //IOButtion ioTmp = sender as IOButtion;
            //ErrorCode err = ErrorCode.Success;

            //if (ioTmp != null)
            //{
            //    err = instantDoCtrl.WriteBit(0, ioTmp.Output, (byte)1);
            //}

            //if (btStart5.Text == "开始刷写")
            //{
            //    //err = instantDoCtrl.Write(0, (byte)(Opos3 + 1));
            //    Thread.Sleep(100);
            //    if (this.combxFB1.Text != "" && this.combxWB1.Text != "" && this.combxCB1.Text != "")
            //    {
            //        btStart5.Text = "停止刷写";

            //        Parameter param = new Parameter(this.combxFB1.Text, this.combxWB1.Text, this.combxCB1.Text, 5, this.lbMessage5, this.progressBar5, this.btStart5);

            //        Thread thread = new Thread(new ParameterizedThreadStart(DoWork));
            //        thread.IsBackground = true;
            //        thread.Start(param);
            //    }

            //}
            //else if (btStart5.Text == "停止刷写")
            //{
            //    //关掉所有灯显示
            //    //err = instantDoCtrl.Write(0, (byte)0);
            //    try
            //    {
            //        MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            //        DialogResult dr = MessageBox.Show("该操作会清空界面数据，请确认未进行刷写操作", "系统复位", messButton);
            //        if (dr == DialogResult.OK)
            //        {
            //            //重置CAN卡
            //            VCI_ResetCAN(configer.DevType, configer.DevInd, 4);


            //            this.Invoke(this.buttonDelegate, new object[] { btStart5, "开始刷写" });
            //            Thread.Sleep(1000);
            //            this.Invoke(this.progressBarDelegate, new object[] { this.progressBar5, 0, 0 });
            //            //清空数据

            //            //Thread.Sleep(1000);
            //            this.Invoke(this.showMessageDelegate, new object[] { lbMessage5, "请重新开始刷写", Color.Green });
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        //logger.Error(ex.Message + "***" + ex.StackTrace);
            //        Log.writeTxt(ex.Message + "***" + ex.StackTrace, filePath);
            //    }
            //}

            #endregion
        }

        private void btStart6_Click(object sender, EventArgs e)
        {
            Parameter senderIO = sender as Parameter;
            ErrorCode err = ErrorCode.Success;

            if ((senderIO != null && senderIO.CanUse == false))
            {
                //灯亮
                err = instantDoCtrl.WriteBit(0, senderIO.Output, (byte)1);

                if (this.combxFB6.Text != "" && this.combxWB6.Text != "" && this.combxCB6.Text != "")
                {
                    //senderIO.Driver = this.combxFB1.Text;
                    //senderIO.Write = this.combxWB1.Text;
                    //senderIO.Cal = this.combxCB1.Text;
                    //senderIO.Num = 6;
                    //senderIO.Label_Attribute = this.lbMessage6;
                    //senderIO.ProgressBar_Attribute = this.progressBar6;
                    //senderIO.Button_Attribute = this.btStart6;

                    Parameter param = new Parameter(this.combxFB6.Text, this.combxWB6.Text, this.combxCB6.Text, 6, this.lbMessage6, this.progressBar6, this.btStart6, this.tbTracCode6.Text);

                    Thread thread = new Thread(new ParameterizedThreadStart(DoWork));
                    thread.IsBackground = true;
                    thread.Start(param);
                }
                else
                {
                    MessageBox.Show("请选择完整的需要刷写的文件！");
                }
            }
            else if (sender != null && e != null)
            {
                if (this.btnSelect.Text == "手动模式")
                {
                    if (this.combxFB6.Text != "" && this.combxWB6.Text != "" && this.combxCB6.Text != "")
                    {
                        Parameter param = new Parameter(this.combxFB6.Text, this.combxWB6.Text, this.combxCB6.Text, 6, this.lbMessage6, this.lbResult6, this.progressBar6, this.btStart6, this.tbVIN6.Text, this.tbTracCode6.Text);

                        Thread thread = new Thread(new ParameterizedThreadStart(DoWork));
                        thread.IsBackground = true;
                        thread.Start(param);
                    }
                    else
                    {
                        MessageBox.Show("请选择完整的需要刷写的文件！");
                    }
                }
                else if (this.btnSelect.Text == "自动模式")
                {
                    this.FlashPath = config.DriverPath;
                    this.WritePath = config.BinPath;
                    this.CalPath = config.CalPath;
                    Parameter param = new Parameter(this.combxFB6.Text, this.combxWB6.Text, this.combxCB6.Text, 6, this.lbMessage6, this.lbResult6, this.progressBar6, this.btStart6, this.tbVIN6.Text, this.tbTracCode6.Text);

                    Thread thread = new Thread(new ParameterizedThreadStart(DoWork));
                    thread.IsBackground = true;
                    thread.Start(param);
                }
            }

            #region Comment out

            //IOButtion ioTmp = sender as IOButtion;
            //ErrorCode err = ErrorCode.Success;

            //if (ioTmp != null)
            //{
            //    err = instantDoCtrl.WriteBit(0, ioTmp.Output, (byte)1);
            //}

            //if (btStart3.Text == "开始刷写")
            //{
            //    //err = instantDoCtrl.Write(0, (byte)(Opos3 + 1));
            //    Thread.Sleep(100);
            //    if (this.combxFB1.Text != "" && this.combxWB1.Text != "" && this.combxCB1.Text != "")
            //    {
            //        this.Invoke(this.buttonDelegate, new object[] { btStart6, "停止刷写" });
            //        Parameter param = new Parameter(this.combxFB1.Text, this.combxWB1.Text, this.combxCB1.Text, 6, this.lbMessage6, this.progressBar6, this.btStart6);
            //        Thread thread = new Thread(new ParameterizedThreadStart(DoWork));
            //        thread.Start(param);
            //    }

            //}
            //else if (btStart6.Text == "停止刷写")
            //{
            //    //关掉所有灯显示
            //    //err = instantDoCtrl.Write(0, (byte)0);
            //    try
            //    {
            //        MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            //        DialogResult dr = MessageBox.Show("该操作会清空界面数据，请确认未进行刷写操作", "系统复位", messButton);
            //        if (dr == DialogResult.OK)
            //        {
            //            //重置CAN卡
            //            VCI_ResetCAN(configer.DevType, configer.DevInd, 5);


            //            this.Invoke(this.buttonDelegate, new object[] { btStart6, "开始刷写" });
            //            Thread.Sleep(1000);
            //            this.Invoke(this.progressBarDelegate, new object[] { this.progressBar6, 0, 0 });
            //            //清空数据

            //            //Thread.Sleep(1000);
            //            this.Invoke(this.showMessageDelegate, new object[] { lbMessage6, "请重新开始刷写", Color.Green });
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        // logger.Error(ex.Message + "***" + ex.StackTrace);
            //        Log.writeTxt(ex.Message + "***" + ex.StackTrace, filePath);
            //    }
            //}

            #endregion
        }

        private void btStart7_Click(object sender, EventArgs e)
        {
            Parameter senderIO = sender as Parameter;
            ErrorCode err = ErrorCode.Success;

            if ((senderIO != null && senderIO.CanUse == false))
            {
                //灯亮
                err = instantDoCtrl.WriteBit(0, senderIO.Output, (byte)1);

                if (this.combxFB7.Text != "" && this.combxWB7.Text != "" && this.combxCB7.Text != "")
                {
                    //senderIO.Driver = this.combxFB1.Text;
                    //senderIO.Write = this.combxWB1.Text;
                    //senderIO.Cal = this.combxCB1.Text;
                    //senderIO.Num = 7;
                    //senderIO.Label_Attribute = this.lbMessage7;
                    //senderIO.ProgressBar_Attribute = this.progressBar7;
                    //senderIO.Button_Attribute = this.btStart7;

                    Parameter param = new Parameter(this.combxFB7.Text, this.combxWB7.Text, this.combxCB7.Text, 7, this.lbMessage7, this.progressBar7, this.btStart7,this.tbTracCode7.Text);

                    Thread thread = new Thread(new ParameterizedThreadStart(DoWork));
                    thread.IsBackground = true;
                    thread.Start(param);
                }
                else
                {
                    MessageBox.Show("请选择完整的需要刷写的文件！");
                }
            }
            else if (sender != null && e != null)
            {
                if (this.btnSelect.Text == "手动模式")
                {
                    if (this.combxFB7.Text != "" && this.combxWB7.Text != "" && this.combxCB7.Text != "")
                    {
                        Parameter param = new Parameter(this.combxFB7.Text, this.combxWB7.Text, this.combxCB7.Text, 7, this.lbMessage7, this.lbResult7, this.progressBar7, this.btStart7,this.tbVIN7.Text, this.tbTracCode7.Text);

                        Thread thread = new Thread(new ParameterizedThreadStart(DoWork));
                        thread.IsBackground = true;
                        thread.Start(param);
                    }
                    else
                    {
                        MessageBox.Show("请选择完整的需要刷写的文件！");
                    }
                }
                else if (this.btnSelect.Text == "自动模式")
                {
                    this.FlashPath = config.DriverPath;
                    this.WritePath = config.BinPath;
                    this.CalPath = config.CalPath;
                    Parameter param = new Parameter(this.combxFB7.Text, this.combxWB7.Text, this.combxCB7.Text, 7, this.lbMessage7, this.lbResult7, this.progressBar7, this.btStart7, this.tbVIN7.Text, this.tbTracCode7.Text);

                    Thread thread = new Thread(new ParameterizedThreadStart(DoWork));
                    thread.IsBackground = true;
                    thread.Start(param);
                }
            }

            #region comment out

            //IOButtion ioTmp = sender as IOButtion;
            //ErrorCode err = ErrorCode.Success;

            //if (ioTmp != null)
            //{
            //    err = instantDoCtrl.WriteBit(0, ioTmp.Output, (byte)1);
            //}

            //if (btStart7.Text == "开始刷写")
            //{
            //    //err = instantDoCtrl.Write(0, (byte)(Opos3 + 1));
            //    Thread.Sleep(100);
            //    if (this.combxFB1.Text != "" && this.combxWB1.Text != "" && this.combxCB1.Text != "")
            //    {
            //        this.Invoke(this.buttonDelegate, new object[] { btStart7, "停止刷写" });
            //        Parameter param = new Parameter(this.combxFB1.Text, this.combxWB1.Text, this.combxCB1.Text, 7, this.lbMessage7, this.progressBar7, this.btStart7);
            //        Thread thread = new Thread(new ParameterizedThreadStart(DoWork));
            //        thread.IsBackground = true;
            //        thread.Start(param);
            //    }

            //}
            //else if (btStart7.Text == "停止刷写")
            //{
            //    //关掉所有灯显示
            //    //err = instantDoCtrl.Write(0, (byte)0);
            //    try
            //    {
            //        MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            //        DialogResult dr = MessageBox.Show("该操作会清空界面数据，请确认未进行刷写操作", "系统复位", messButton);
            //        if (dr == DialogResult.OK)
            //        {
            //            //重置CAN卡
            //            VCI_ResetCAN(configer.DevType, configer.DevInd, 6);


            //            this.Invoke(this.buttonDelegate, new object[] { btStart7, "开始刷写" });
            //            Thread.Sleep(1000);
            //            this.Invoke(this.progressBarDelegate, new object[] { this.progressBar7, 0, 0 });
            //            //清空数据

            //            //Thread.Sleep(1000);
            //            this.Invoke(this.showMessageDelegate, new object[] { lbMessage7, "请重新开始刷写", Color.Green });
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        // logger.Error(ex.Message + "***" + ex.StackTrace);
            //        Log.writeTxt(ex.Message + "***" + ex.StackTrace, filePath);
            //    }
            //}

            #endregion
        }

        private void btStart8_Click(object sender, EventArgs e)
        {
            Parameter senderIO = sender as Parameter;
            ErrorCode err = ErrorCode.Success;

            if ((senderIO != null && senderIO.CanUse == false))
            {
                //灯亮
                err = instantDoCtrl.WriteBit(0, senderIO.Output, (byte)1);

                if (this.combxFB8.Text != "" && this.combxWB8.Text != "" && this.combxCB8.Text != "")
                {
                    //senderIO.Driver = this.combxFB1.Text;
                    //senderIO.Write = this.combxWB1.Text;
                    //senderIO.Cal = this.combxCB1.Text;
                    //senderIO.Num = 8;
                    //senderIO.Label_Attribute = this.lbMessage8;
                    //senderIO.ProgressBar_Attribute = this.progressBar8;
                    //senderIO.Button_Attribute = this.btStart8;

                    Parameter param = new Parameter(this.combxFB8.Text, this.combxWB8.Text, this.combxCB8.Text, 8, this.lbMessage8,this.progressBar8, this.btStart8,this.tbTracCode8.Text);

                    Thread thread = new Thread(new ParameterizedThreadStart(DoWork));
                    thread.IsBackground = true;
                    thread.Start(param);
                }
                else
                {
                    MessageBox.Show("请选择完整的需要刷写的文件！");
                }
            }
            else if (sender != null && e != null)
            {
                if (this.btnSelect.Text == "手动模式")
                {
                    if (this.combxFB8.Text != "" && this.combxWB8.Text != "" && this.combxCB8.Text != "")
                    {
                        Parameter param = new Parameter(this.combxFB8.Text, this.combxWB8.Text, this.combxCB8.Text, 8, this.lbMessage8, this.lbResult8, this.progressBar8, this.btStart8,this.tbVIN8.Text, this.tbTracCode8.Text);

                        Thread thread = new Thread(new ParameterizedThreadStart(DoWork));
                        thread.IsBackground = true;
                        thread.Start(param);
                    }
                    else
                    {
                        MessageBox.Show("请选择完整的需要刷写的文件！");
                    }
                }    
                else if (this.btnSelect.Text == "自动模式")
                {
                    this.FlashPath = config.DriverPath;
                    this.WritePath = config.BinPath;
                    this.CalPath = config.CalPath;
                    Parameter param = new Parameter(this.combxFB8.Text, this.combxWB8.Text, this.combxCB8.Text, 8, this.lbMessage8, this.lbResult8, this.progressBar8, this.btStart8, this.tbVIN8.Text, this.tbTracCode8.Text);

                    Thread thread = new Thread(new ParameterizedThreadStart(DoWork));
                    thread.IsBackground = true;
                    thread.Start(param);
                }
            }

            #region comment out

            //IOButtion ioTmp = sender as IOButtion;
            //ErrorCode err = ErrorCode.Success;

            //if (ioTmp != null)
            //{
            //    err = instantDoCtrl.WriteBit(0, ioTmp.Output, (byte)1);
            //}

            //if (btStart8.Text == "开始刷写")
            //{
            //    //err = instantDoCtrl.Write(0, (byte)(Opos3 + 1));
            //    Thread.Sleep(100);
            //    if (this.combxFB1.Text != "" && this.combxWB1.Text != "" && this.combxCB1.Text != "")
            //    {
            //        this.Invoke(this.buttonDelegate, new object[] { btStart8, "停止刷写" });
            //        Parameter param = new Parameter(this.combxFB1.Text, this.combxWB1.Text, this.combxCB1.Text, 8, this.lbMessage8, this.progressBar8, this.btStart8);
            //        Thread thread = new Thread(new ParameterizedThreadStart(DoWork));
            //        thread.IsBackground = true;
            //        thread.Start(param);
            //    }

            //}
            //else if (btStart8.Text == "停止刷写")
            //{
            //    //关掉所有灯显示
            //    //err = instantDoCtrl.Write(0, (byte)0);
            //    try
            //    {
            //        MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            //        DialogResult dr = MessageBox.Show("该操作会清空界面数据，请确认未进行刷写操作", "系统复位", messButton);
            //        if (dr == DialogResult.OK)
            //        {
            //            //重置CAN卡
            //            VCI_ResetCAN(configer.DevType, configer.DevInd, 7);


            //            this.Invoke(this.buttonDelegate, new object[] { btStart8, "开始刷写" });
            //            Thread.Sleep(1000);
            //            this.Invoke(this.progressBarDelegate, new object[] { this.progressBar8, 0, 0 });
            //            //清空数据

            //            //Thread.Sleep(1000);
            //            this.Invoke(this.showMessageDelegate, new object[] { lbMessage8, "请重新开始刷写", Color.Green });
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        //logger.Error(ex.Message + "***" + ex.StackTrace);
            //        Log.writeTxt(ex.Message + "***" + ex.StackTrace, filePath);
            //    }
            //}

            #endregion
        }

        #endregion

        #region 委托绑定方法

        /// <summary>
        /// 关闭VCI
        /// </summary>
        /// <param name="label"></param>
        private void CloseVCIMethod(Label[] label)
        {
            bool result = true;
            try
            {
                for (int i = 0; i < label.Length; i++)
                {
                    result &= (label[i].Text != "...");
                }

                if (result)
                {
                    m_bOpen = 0;
                    VCI_CloseDevice(configer.DevType, configer.DevInd);
                }
            }
            catch (Exception ex)
            {
                Log.writeTxt(ex.Message + "***" + ex.StackTrace, filePath);
            }
        }
        /// <summary>
        /// 显示消息
        /// </summary>
        /// <param name="txt"></param>
        private void ShowMessage(Label label, string txt, Color color)
        {
            try
            {
                label.Text = txt;
                label.ForeColor = color;
            }
            catch (Exception ex)
            {
                //logger.Error(ex.Message + "***" + ex.StackTrace);
                Log.writeTxt(ex.Message + "***" + ex.StackTrace, filePath);
            }
        }
        /// <summary>
        /// 改变颜色
        /// </summary>
        /// <param name="color"></param>
        private void ChangeColor(Color color)
        {
            try
            {
                this.groupBox1.BackColor = color;
                //this.ListMsg.BackColor = color;
            }
            catch (Exception ex)
            {
                //logger.Error(ex.Message + "***" + ex.StackTrace);
                Log.writeTxt(ex.Message + "***" + ex.StackTrace, filePath);
            }
        }
        /// <summary>
        /// 显示消息
        /// </summary>
        /// <param name="txt"></param>
        private void ButtonClick(Button button, string txt)
        {
            try
            {
                //button.Click += button_Click;
                button.Text = txt;
                //picBox.Image = Image.FromFile(path);
                //picBox.Image = list.Images[num];
            }
            catch (Exception ex)
            {
                //logger.Error(ex.Message + "***" + ex.StackTrace);
                Log.writeTxt(ex.Message + "***" + ex.StackTrace, filePath);
            }
        }
        /// <summary>
        /// 设置进度条
        /// </summary>
        /// <param name="value"></param>
        private void SetBar(ProgressBar progressBar, int value, int max)
        {
            try
            {
                progressBar.Maximum = max;
                progressBar.Value = value;
            }
            catch (Exception ex)
            {
                // logger.Error(ex.Message + "***" + ex.StackTrace);
                Log.writeTxt(ex.Message + "***" + ex.StackTrace, filePath);
            }
        }
        /// <summary>
        /// 在界面上显示
        /// </summary>
        /// <param name="txt"></param>
        private void AddMessage(Label label, string txt, Color color)
        {
            try
            {
                //logger.Info(txt);
                this.Invoke(this.showMessageDelegate, new object[] { label, txt, color });
                //Log.writeTxt(txt, filePath);
            }
            catch (Exception ex)
            {
                //logger.Error(ex.Message + "***" + ex.StackTrace);
                Log.writeTxt(ex.Message + "***" + ex.StackTrace, filePath);
            }
        }
        /// <summary>
        /// 打印委托
        /// </summary>
        private void GetPrint(PrintInfo info)
        {
            try
            {
                WinPrintForm frm = new WinPrintForm();
                frm.Tag = info;
                frm.Show();
                //frm.Hide();
            }
            catch (Exception ex)
            {
                // logger.Error(ex.Message + "***" + ex.StackTrace);
                Log.writeTxt(ex.Message + "***" + ex.StackTrace, filePath);
            }
        }
        /// <summary>
        /// 零件条码委托
        /// </summary>
        /// <param name="tx"></param>
        /// <param name="txt"></param>
        private void ShowInfo(TextBox tx, string txt)
        {
            try
            {
                tx.Text = txt;
            }
            catch (Exception ex)
            {
                // logger.Error(ex.Message + "***" + ex.StackTrace);
                Log.writeTxt(ex.Message + "***" + ex.StackTrace, filePath);
            }
        }
        /// <summary>
        /// 刷写文件显示委托
        /// </summary>
        /// <param name="tx"></param>
        /// <param name="txt"></param>
        private void ShowFileName(ComboBox cb1, ComboBox cb2, ComboBox cb3, string txt1, string txt2, string txt3)
        {
            try
            {
                cb1.Text = txt1;
                cb2.Text = txt2;
                cb3.Text = txt3;
            }
            catch (Exception ex)
            {
                //logger.Error(ex.Message + "***" + ex.StackTrace);
                Log.writeTxt(ex.Message + "***" + ex.StackTrace, filePath);
            }
        }
        
        #endregion

        #region 刷写流程

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        public void DoWork(object o)
        {
            try
            {
                Parameter param = o as Parameter;
                if (param == null) return;
                //开始写入
                DSGStartWrite(param);

                #region Comment out

                //MyInvoke mi = new MyInvoke(UpdateForm);
                //this.BeginInvoke(mi, new Object[] { param });

                //UpdateForm(param);

                #endregion
            }
            catch (Exception ex)
            {
                // logger.Error(ex.Message + "***" + ex.StackTrace);
                Log.writeTxt(ex.Message + "***" + ex.StackTrace, filePath);
            }
        }
        /// <summary>
        /// 获得车型对应的相关参数
        /// </summary>
        public async void DSGStartWrite(Parameter param)
        {
            try
            {
                Tools.WriteToMyLog("这里开始了", "这里开始了");
                #region 临时变量

                if (param == null) return;
                
                UInt32 CANID = uint.Parse((param.Num - 1) + ""); //CAN ID 0-7
                string driver = param.Driver;
                string write = param.Write;
                string cal= param.Cal;
                Label label = param.Label_Attribute;
                Label lbResult = param.LbResult_Attribute;
                ProgressBar progressBar = param.ProgressBar_Attribute;
                Button button = param.Button_Attribute;
                string element = param.Element;
                string vin = param.VIN;

                Boolean result = false;
                StringBuilder log = new StringBuilder();

                string str = CANID + "," + driver + "," + write + "," + cal + "," + vin + "," + element;
                Tools.WriteToMyLog(str, str);

                #endregion

                //显示结果（附空）
                AddMessage(lbResult, "...", Color.Green);

                #region 定义驱动bin字节数组

                byte[] DirerByte = null;

                #endregion


                #region 定义应用bin字节数组

                //应用bin字节数组
                byte[] binByte = null;
                byte[] binByte1 = null;
                byte[] binByte2 = null;

                //余文杰备注;
                //sw文件实际上是有不定个section,如果是多个section这块byte数组应该定义成List<byte[]>
                //头文件也应该明确的区分开来方便计算
                //清理空间计算规则为末section末尾地址-首地址+1=对应填写值。下面方法就来计算。最后算出来的结果去填写汪柯星的40
                //汪柯星的40，为没有删除，留着






                //需要查找的字节
                byte[] searchByte = new byte[4];
                searchByte[0] = 239;
                searchByte[1] = 190;
                searchByte[2] = 173;
                searchByte[3] = 222;

                //弄头文件地址，计算清除值
                //int index = 0;
                //for (int i = 0; i < binByte.Length; i++)
                //{
                //    if (binByte[i] == searchByte[0] && binByte[i + 1] == searchByte[1] && binByte[i + 2] == searchByte[2] && binByte[i + 3] == searchByte[3])
                //    {
                //        index = i;
                //        break;
                //    }
                //}
                //section地址存放
                //byte[] 

                #endregion

                #region 定义标定bin字节数组

                byte[] calByte = null;

                #endregion

                #region 开始写入的位置

                int position = 0;

                #endregion
                Tools.WriteToMyLog("开始读driver", "开始读driver");


                #region 读取驱动bin文件

    //                <add key ="driverPos" value="D:\VCU刷写程序\GACNew_VCU_Writer\Flash driver\" />
    //<add key ="writePos" value="D:\VCU刷写程序\GACNew_VCU_Writer\Write driver\" />
    //<add key ="calPos" value="D:\VCU刷写程序\GACNew_VCU_Writer\Cal driver\"/>

                if (this.FlashPath == null)
                    this.FlashPath = System.Configuration.ConfigurationManager.AppSettings["driverPos"];
                string pp = this.FlashPath + driver;
                Tools.WriteToMyLog(pp, pp);
                DirerByte = ReadBin(this.FlashPath + driver, 0);

                Tools.WriteToMyLog("sw_bin读取完毕", "sw_bin读取完毕");

                #endregion

                #region 处理应用bin文件

                //读取写入bin文件
                if (this.WritePath == null)
                    this.WritePath = System.Configuration.ConfigurationManager.AppSettings["writePos"];

                binByte = ReadBin(this.WritePath + write, 0);
                Tools.WriteToMyLog(this.WritePath + write, this.WritePath + write);


                int SW_FRASH_ADDRESS = Tools.GetQingLiValue(binByte);
                byte address = Convert.ToByte(SW_FRASH_ADDRESS);
                //获取EF BE AD DE最后出现的位置，即SW2文件写入的开始数据
                for (int i = 0; i < binByte.Length; i++)
                {
                    if (binByte[i] == searchByte[0] && binByte[i + 1] == searchByte[1] && binByte[i + 2] == searchByte[2] && binByte[i + 3] == searchByte[3])
                    {
                        position = i;
                    }
                }
                // position=1572913
                //去掉8个字节
                binByte1 = new byte[position - 8];
                for (int i = 0; i < binByte1.Length; i++)
                {
                    if (i < 41)
                    {
                        binByte1[i] = binByte[i];
                    }
                    else
                    {
                        binByte1[i] = binByte[i + 8];
                    }
                }
                binByte2 = new byte[binByte.Length - position + 41];

                //这里感觉是在拼文件2的头文件
                for (int i = 0; i < binByte2.Length; i++)
                {
                    //这个33是文件1的头文件，由于是文件2，所以要去掉。
                    if (i < 33)
                    {
                        binByte2[i] = binByte[i];
                    }
                    //这里41以后是文件2的头，其实没问题，这里拼的就是文件2的头
                    else if (i < 41)
                    {
                        binByte2[i] = binByte[i + 8];
                    }
                    else
                    {
                        //这个地方真要改的话，长度也没问题。41是去掉了文件1的头，留了文件2的头
                        binByte2[i] = binByte[position + i - 41];
                    }
                }

                #endregion


                Tools.WriteToMyLog("sw_bin读取完毕", "sw_bin读取完毕");
                #region 处理标定bin文件

                if (this.CalPath == null)
                    this.CalPath = System.Configuration.ConfigurationManager.AppSettings["calPos"];

                calByte = ReadBin(this.CalPath + cal, 0);

                Tools.WriteToMyLog(this.CalPath + cal, this.CalPath + cal);
                #endregion


                Tools.WriteToMyLog("calByte读取完毕", "calByte读取完毕");
                #region 给驱动bin添加CRC校验

                byte[] DirCrcByte = DirerByte.Skip(9).Take(DirerByte.Length - 1).ToArray();
                direrStr = String.Format("{0:X8}", crc.GetCRC32Str2(DirCrcByte));
                param.CRC1 = direrStr;

                #endregion

                #region 给应用bin添加CRC校验

                //CRC校验如果增加到第三个section这里就要改了，实际上如果把EF BE AD DE开始位置传进去更好
                //固定49只能支持2个section
                byte[] crcByte = binByte.Skip(49).Take(binByte.Length - 1).ToArray();
                crCstr = String.Format("{0:X8}", crc.GetCRC32Str2(crcByte));
                param.CRC2 = crCstr;

                #endregion

                #region 给标定bin添加CRC校验

                byte[] CalCrcByte = calByte.Skip(41).Take(calByte.Length - 1).ToArray();
                calcrcStr = String.Format("{0:X8}", crc.GetCRC32Str2(CalCrcByte));
                param.CRC3 = calcrcStr;
                //计算得到的crc码和提供的crc码对比
                //if (direrStr != vcuPath.CRC1 || crCstr != vcuPath.CRC2)
                //{
                //    return;
                //}

                #endregion

                Tools.WriteToMyLog("CRC校验通过", "CRC校验通过");

                for (int i = 1; i <= configer.WriteTimes; i++)
                {
                    log.Append("\r\n" + DateTime.Now + " " + "开始第" + i + "次刷写!" + "\r\n");

                    //清空数据
                    this.Invoke(this.showMessageDelegate, new object[] { label, "开始第" + i + "次刷写!", Color.Green });

                    #region 连接设备

                    ConnectDevice((UInt32)CANID, label, param);

                    #endregion

                    #region 发送报文

                    //List<DefineFlower> lstDefineFlower = Send(SW_FRASH_ADDRESS,  DirerByte, binByte1, binByte2, calByte, (UInt32)CANID, label, progressBar, ref log, param);
                    List<DefineFlower> lstDefineFlower = Send(SW_FRASH_ADDRESS, DirerByte, binByte1, binByte2, calByte, (UInt32)CANID, label, progressBar, ref log, param);

                    #endregion

                    #region 校验结果

                    result = CheckFlow(lstDefineFlower, 1, label, ref log, param);
                    //this.Invoke(this.showPicDelegate, new object[] { pictureBox10, Application.StartupPath + "\\img\\" + "process_09.png" });

                    if (result == true)
                    {
                        log.Append("\r\n" + DateTime.Now + " " + "第" + i + "次刷写成功!" + "\r\n");
                        break;
                    }
                    else
                    {
                        //如果失败，会尝试3次，如果三次都失败的话，也就是失败了
                        #region 重置CAN卡

                        VCI_ResetCAN(configer.DevType, configer.DevInd, CANID);
                        log.Append("\r\n" + DateTime.Now + " " + "第" + i + "次刷写失败!" + "\r\n");
                        Thread.Sleep(5000);

                        #endregion
                    }
                    #endregion
                }

                #region 重置CAN卡
                VCI_ResetCAN(configer.DevType, configer.DevInd, CANID);
                #endregion

                #region 重置界面显示

                //AddMessage(label, "发送完成", Color.Green);
                //显示结果（OK/NG）
                AddMessage(lbResult, result ? "OK" : "NG", result ? Color.Green : Color.Red);

                //重置button显示
                this.Invoke(this.buttonDelegate, new object[] { button, "开始刷写" });

                Thread.Sleep(1000);
                //重置进度条显示
                this.Invoke(this.progressBarDelegate, new object[] { progressBar, 0, 0 });

                #endregion

                #region 正常检测完成？

                //正常检测完成
                if (result)
                {
                    //清空数据
                    this.Invoke(this.showMessageDelegate, new object[] { label, "刷写成功，请继续下一次刷写!", Color.Green });
                    //打印当前结果
                    //零件号、软件版本、硬件型号、SW、HW
                    //string[] info = configer.GetInfo(this.FlashPath, driver, this.WritePath, write, this.CalPath, cal);
                    string[] info = SqlComm.GetInfo(this.FlashPath, driver, this.WritePath, write, this.CalPath, cal);
                    //PrintResult(info[0], info[1], info[2], info[3], info[4], DateTime.Now.ToString("d").Replace("-", "/"), element, param.Num.ToString(), param.VIN.Substring(12, 5));
                    printResult = new Form1(info[0], info[1], info[2], info[3], info[4], DateTime.Now.ToString("d").Replace("-", "/"), element, param.Num.ToString(), param.VIN.Substring(12, 5),info[5]);
                   
                    printResult.Print();
                }
                else
                {
                    this.Invoke(this.showMessageDelegate, new object[] { label, "刷写失败，请重新开始刷写!", Color.Red });
                }

                if (vin != null)
                {
                    //修改当前检测状态成功为2，失败为1
                    //configer.ChangeState(result, vin);
                   await SqlComm.ChangeState(result, vin);
                    //保存当前检测结果
                    //configer.SaveLocalResult(element, result, vin, driver, write, cal);
                   await SqlComm.SaveLocalResult(element, result, vin, driver, write, cal);
                }

                this.Invoke(this.closeVCIDelegate, new object[] { new Label[] { this.lbResult1, this.lbResult2, this.lbResult3, this.lbResult4, this.lbResult5, this.lbResult6, this.lbResult7, this.lbResult8} });

                #endregion

                #region 记录日志

                //logger.Info(errorCode);
                //Log.writeTxt(log + "", filePath);

                Log.writeTxt(log + "", filePath, CANID + "",vin);

                #endregion

                #region Comment out

                //界面显示刷写结束
                //this.Invoke(this.showPicDelegate, new object[] { pictureBox11, Application.StartupPath + "\\img\\" + "process_11.png" });

                //打印                

                //if (this.vcuPath.WriteInResult)
                //{
                //    this.Invoke(this.showMessageDelegate, new object[] { this.vcuPath.CarType + "刷写成功", "up" });

                //    PrintInfo info = new PrintInfo();
                //    info.SoftWareVersion = this.vcuPath.SoftWareVersion;
                //    info.OptionCode = this.vcuPath.CarType;
                //    //info.OptionCode = System.Configuration.ConfigurationSettings.AppSettings["OptionCode"];
                //    info.Barcode = this.vcuPath.SoftWareCode + this.vcuPath.ConditionCode;
                //    info.Number = configer.GetPrintNum().ToString();
                //    //info.PartsName = System.Configuration.ConfigurationSettings.AppSettings["PartsName"];
                //    info.PartsName = this.vcuPath.ConditionCode;

                //    //保存到本地
                //    int res = configer.SaveLocalResult(this.vcuPath);
                //    if (res != 1)
                //    {
                //        MessageBox.Show("写入数据库失败");
                //    }
                //    //上传到服务器configer.MESCnnStr
                //    configer.Upload_Timer();

                //    this.Invoke(this.printDelegate, new object[] { info });

                //    //if (PrintB)
                //    //{
                //    //    this.vcuPath.IsPrint = 1;
                //    //}
                //    //else
                //    //{
                //    //    this.vcuPath.IsPrint = 0;
                //    //} 

                //    //Wrapper.SendOnly(new byte[] { 255, 0 }, 18);
                //    //Wrapper.SendOnly(new byte[] { 0, 0 }, 17);
                //}
                //else
                //{
                //    this.Invoke(this.showMessageDelegate, new object[] { this.vcuPath.CarType + "刷写失败", "up" });
                //    //Wrapper.SendOnly(new byte[] { 255, 0 }, 16);
                //}


                #endregion
            }
            catch (Exception ex)
            {
                //logger.Error(ex.Message + "***" + ex.StackTrace);
                Log.writeTxt(ex.Message + "***" + ex.StackTrace, filePath);
            }
        }

        /// <summary>
        /// 解析bin文件
        /// </summary>
        private byte[] ReadBin(string filePath, int length)
        {
            byte[] binchar = new byte[] { };
            FileStream Myfile = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader binreader = new BinaryReader(Myfile);
            int file_len = (int)Myfile.Length;//获取bin文件长度 
            //byte b = byte.Parse(Convert.ToInt64("01", 16) + "");
            if (length == 0)
            {
                binchar = binreader.ReadBytes(file_len);
            }
            else
            {
                binchar = binreader.ReadBytes(length);
            }
            return binchar;
        }
        /// <summary>
        /// 连接CAN设备
        /// </summary>
        unsafe private void ConnectDevice(UInt32 canid, Label label,Parameter param)
        {
            try
            {
                if (m_bOpen == 0)
                {
                    #region 打开设备
                    //configer.DevType=34，8E-U=34,4E-U,2E-U给胎压用，具体数值看胎压程序，8E代表8个口，4E代表4个口，以此类推
                    //DevInd固定，是0
                    if (VCI_OpenDevice(configer.DevType, configer.DevInd, 0) == 0)
                    {
                        AddMessage(label, "打开设备失败,请检查设备类型和设备索引号是否正确!", Color.Red);
                        AddMessage(label, "如果确认无误后请重启软件!", Color.Red);
                        return;
                    }
                    m_bOpen = 1;

                    #endregion
                }
                #region 初始化CAN

                VCI_INIT_CONFIG config = new VCI_INIT_CONFIG();
                //8E-U是固定的复制
                config.AccCode = 0;
                config.AccMask = 4294967295;
                config.Mode = 0;
                config.Timing0 = 0;
                config.Timing1 = 28;
                config.Filter = 1;
                //canid是端口号，0-7
                VCI_InitCAN(configer.DevType, configer.DevInd, canid, ref config);

                #endregion

                #region 启动CAN

                VCI_StartCAN(configer.DevType, configer.DevInd, canid);

                //AddMessage(label, "成功！", Color.Green);

                #endregion

                #region 启动接收

                //清空接收队列
                if (param.QueReceiveMsg != null)
                {
                    param.QueReceiveMsg.Clear();
                    param.QueReceiveMsg = new Queue();

                    param.QueReceiveMsg.Clear();
                    param.ReceiveList = new List<string>();
                }

                #endregion
            }
            catch (Exception ex)
            {
                //logger.Error(ex.Message + "***" + ex.StackTrace);
                Log.writeTxt(ex.Message + "***" + ex.StackTrace, filePath);
            }
        }
        /// <summary>
        /// 发送方法
        /// </summary>
        /// <param name="DirerByte"></param>
        /// <param name="BinByte1"></param>
        /// <param name="BinByte2"></param>
        /// <param name="CalByte"></param>
        /// <param name="canid"></param>
        /// <param name="label"></param>
        /// <param name="progressBar"></param>
        /// <returns></returns>
        unsafe private List<DefineFlower> Send(int SW_FRASH_ADDRESS,byte[] DirerByte, byte[] BinByte1, byte[] BinByte2, byte[] CalByte, UInt32 canid, Label label, ProgressBar progressBar, ref StringBuilder log,Parameter param)
        {
            log.AppendLine();
            List<DefineFlower> lstDefineFlower = new List<DefineFlower>();
            //AddMessage(label, "开始发送", Color.Green);
            try
            {
                //this.Invoke(this.showPicDelegate, new object[] { pictureBox8, Application.StartupPath + "\\img\\" + "process_03.png" });

                //连接好了的话m_bOpen = 1

                
                if (m_bOpen == 0)
                {
                    AddMessage(label, "与车辆连接失败，无法发送!", Color.Red);
                    return lstDefineFlower;
                }

                Tools.WriteToMyLog("连接成功", "连接成功");
                //取出定义帧
                //lstDefineFlower = configer.GetDefineFlower();
                lstDefineFlower = SqlComm.GetDefineFlower();
                Tools.WriteToMyLog("读取流程成功", "读取流程成功");

                VCI_CAN_OBJ vco = new VCI_CAN_OBJ();

             
                // 正常发送
                vco.SendType = 0;
                // 数据帧
                vco.RemoteFlag = 0;
                // 标准帧
                vco.ExternFlag = 0;
                // 数据长度1个字节
                vco.DataLen = 8;

                int DirerCount = DirerByte.Count();
                int binCount1 = BinByte1.Count();
                int binCount2 = BinByte2.Count();
                int calCount = CalByte.Count();
                int barMaxValue = DirerCount + binCount1 + binCount2 + calCount;//进度条最大长度值
                int calMaxValue = calCount;
                byte[] bf = new byte[8];
                string seedkey = null; //安全访问的key

                int start = 32;//bin文件取数的起始位置,前面的为文件头信息

                this.Invoke(this.progressBarDelegate, new object[] { progressBar, 0, barMaxValue });//进度条

                //



                #region 发送文件

                Tools.WriteToMyLog("开始操作", "开始操作");
                foreach (DefineFlower defineFlower in lstDefineFlower)
                {
                    // 填写第一帧的ID
                    //Address是7E3,CAN的地址就是这样，回复是7EB,前两个是物理地址，7DF属于功能地址
                    vco.ID = defineFlower.SendAddress;

                    //切分定义帧
                    string[] sendCmds = defineFlower.SendCmd.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    //转换成16进制
                    for (int i = 0; i < sendCmds.Length; i++)
                    {
                        vco.Data[i] = byte.Parse(Convert.ToInt64((sendCmds[i]) + "", 16) + "");
                        bf[i] = vco.Data[i];
                    }

                    switch (defineFlower.FlowName)
                    {
                        case "安全访问key":
                            vco.Data[3] = byte.Parse(Convert.ToInt64((seedkey.Substring(0, 2)) + "", 16) + "");
                            vco.Data[4] = byte.Parse(Convert.ToInt64((seedkey.Substring(3, 2)) + "", 16) + "");
                            vco.Data[5] = byte.Parse(Convert.ToInt64((seedkey.Substring(6, 2)) + "", 16) + "");
                            vco.Data[6] = byte.Parse(Convert.ToInt64((seedkey.Substring(9, 2)) + "", 16) + "");
                            vco.Data[7] = 170;
                            Tools.WriteToMyLog("安全访问key", "安全访问key");
                            break;
                        case "请求下载driver":
                            vco.Data[5] = DirerByte[1];
                            vco.Data[6] = DirerByte[2];
                            vco.Data[7] = DirerByte[3];

                            Tools.WriteToMyLog("请求下载driver", "请求下载driver");
                            break;
                        case "下载driver":
                            vco.Data[1] = DirerByte[4];
                            vco.Data[2] = DirerByte[5];
                            vco.Data[3] = DirerByte[6];
                            vco.Data[4] = DirerByte[7];
                            vco.Data[5] = DirerByte[8];
                            vco.Data[6] = 170;
                            vco.Data[7] = 170;
                            Tools.WriteToMyLog("下载driver", "下载driver");
                            break;
                        case "请求下载bin1":
                            vco.Data[5] = BinByte1[start + 1];
                            vco.Data[6] = BinByte1[start + 2];
                            vco.Data[7] = BinByte1[start + 3];
                            Tools.WriteToMyLog("请求下载bin1", "请求下载bin1");
                            break;
                        case "下载bin1":
                            vco.Data[1] = BinByte1[start + 4];
                            vco.Data[2] = BinByte1[start + 5];
                            vco.Data[3] = BinByte1[start + 6];
                            vco.Data[4] = BinByte1[start + 7];
                            vco.Data[5] = BinByte1[start + 8];
                            vco.Data[6] = 170;
                            vco.Data[7] = 170;
                            Tools.WriteToMyLog("下载bin1", "下载bin1");
                            break;
                        case "请求下载bin2":
                            vco.Data[5] = BinByte2[start + 1];
                            vco.Data[6] = BinByte2[start + 2];
                            vco.Data[7] = BinByte2[start + 3];
                            Tools.WriteToMyLog("请求下载bin2", "请求下载bin2");
                            break;
                        case "下载bin2":
                            vco.Data[1] = BinByte2[start + 4];
                            vco.Data[2] = BinByte2[start + 5];
                            vco.Data[3] = BinByte2[start + 6];
                            vco.Data[4] = BinByte2[start + 7];
                            vco.Data[5] = BinByte2[start + 8];
                            vco.Data[6] = 170;
                            vco.Data[7] = 170;
                            Tools.WriteToMyLog("请求下载bin2", "请求下载bin2");
                            break;
                        case "请求下载cal":
                            vco.Data[5] = CalByte[start + 1];
                            vco.Data[6] = CalByte[start + 2];
                            vco.Data[7] = CalByte[start + 3];
                            Tools.WriteToMyLog("请求下载cal", "请求下载cal");
                            break;
                        case "下载cal":
                            vco.Data[1] = CalByte[start + 4];
                            vco.Data[2] = CalByte[start + 5];
                            vco.Data[3] = CalByte[start + 6];
                            vco.Data[4] = CalByte[start + 7];
                            vco.Data[5] = CalByte[start + 8];
                            vco.Data[6] = 170;
                            vco.Data[7] = 170;
                            Tools.WriteToMyLog("下载cal", "下载cal");
                            break;
                        case "写入日期":
                            string year = DateTime.Now.Year.ToString();
                            vco.Data[4] = byte.Parse(Convert.ToInt64(year.Substring(0, 2), 16) + "");
                            vco.Data[5] = byte.Parse(Convert.ToInt64(year.Substring(2, 2), 16) + "");
                            vco.Data[6] = byte.Parse(Convert.ToInt64(DateTime.Now.Month + "", 16) + "");
                            vco.Data[7] = byte.Parse(Convert.ToInt64(DateTime.Now.Day + "", 16) + "");
                            Tools.WriteToMyLog("写入日期", "写入日期");
                            break;
                        case "清理内存":
                            vco.Data[7] = BinByte1[start + 1];
                            Tools.WriteToMyLog("清理内存-bin1", "清理内存-bin1");
                            break;
                        case "清理数据": //一个BIN文件只修改一次
                            vco.Data[1] = BinByte1[start + 2];
                            vco.Data[2] = BinByte1[start + 3];
                            vco.Data[3] = BinByte1[start + 4];
                            vco.Data[4] = BinByte1[start + 5];
                            vco.Data[5] = Convert.ToByte(SW_FRASH_ADDRESS);//24; //40;  //新车型是24
                            vco.Data[6] = BinByte1[start + 7];
                            vco.Data[7] = BinByte1[start + 8];
                            // //35,36,37,38,39(被写死),40
                            Tools.WriteToMyLog("清理数据-bin1", "清理数据-bin1");
                            break;
                        case "清理数据2":
                            vco.Data[1] = CalByte[start + 2];
                            vco.Data[2] = CalByte[start + 3];
                            vco.Data[3] = CalByte[start + 4];
                            vco.Data[4] = CalByte[start + 5];
                            vco.Data[5] = CalByte[start + 6];
                            vco.Data[6] = CalByte[start + 7];
                            vco.Data[7] = CalByte[start + 8];
                            Tools.WriteToMyLog("清理数据-cal", "清理数据-cal");
                            //35,36,37,38,39,40,41。这里没毛病
                            break;
                        case "检查流程":
                            //vco.Data[6] = byte.Parse(Convert.ToInt64(crCstr.Substring(0, 2), 16) + "");
                            //vco.Data[7] = byte.Parse(Convert.ToInt64(crCstr.Substring(2, 2), 16) + "");
                            vco.Data[6] = byte.Parse(Convert.ToInt64(param.CRC2.Substring(0, 2), 16) + "");
                            vco.Data[7] = byte.Parse(Convert.ToInt64(param.CRC2.Substring(2, 2), 16) + "");
                            Tools.WriteToMyLog("CRC2检查流程", "CRC2检查流程");

                            break;
                        case "检查流程2":
                            //vco.Data[1] = byte.Parse(Convert.ToInt64(crCstr.Substring(4, 2), 16) + "");
                            //vco.Data[2] = byte.Parse(Convert.ToInt64(crCstr.Substring(6, 2), 16) + "");
                            vco.Data[1] = byte.Parse(Convert.ToInt64(param.CRC2.Substring(4, 2), 16) + "");
                            vco.Data[2] = byte.Parse(Convert.ToInt64(param.CRC2.Substring(6, 2), 16) + "");
                            vco.Data[3] = 170;
                            vco.Data[4] = 170;
                            vco.Data[5] = 170;
                            vco.Data[6] = 170;
                            vco.Data[7] = 170;
                            Tools.WriteToMyLog("CRC2检查流程2", "CRC2检查流程2");
                            break;

                        case "检查流程-cal":
                            //vco.Data[6] = byte.Parse(Convert.ToInt64(calcrcStr.Substring(0, 2), 16) + "");
                            //vco.Data[7] = byte.Parse(Convert.ToInt64(calcrcStr.Substring(2, 2), 16) + "");
                            vco.Data[6] = byte.Parse(Convert.ToInt64(param.CRC3.Substring(0, 2), 16) + "");
                            vco.Data[7] = byte.Parse(Convert.ToInt64(param.CRC3.Substring(2, 2), 16) + "");
                            Tools.WriteToMyLog("检查流程-cal", "检查流程-cal");
                            break;
                        case "检查流程2-cal":
                            //vco.Data[1] = byte.Parse(Convert.ToInt64(calcrcStr.Substring(4, 2), 16) + "");
                            //vco.Data[2] = byte.Parse(Convert.ToInt64(calcrcStr.Substring(6, 2), 16) + "");
                            vco.Data[1] = byte.Parse(Convert.ToInt64(param.CRC3.Substring(4, 2), 16) + "");
                            vco.Data[2] = byte.Parse(Convert.ToInt64(param.CRC3.Substring(6, 2), 16) + "");
                            vco.Data[3] = 170;
                            vco.Data[4] = 170;
                            vco.Data[5] = 170;
                            vco.Data[6] = 170;
                            vco.Data[7] = 170;
                            Tools.WriteToMyLog("检查流程2-cal", "检查流程2-cal");
                            break;
                        case "检查数据":
                            //vco.Data[6] = byte.Parse(Convert.ToInt64(direrStr.Substring(0, 2), 16) + "");
                            //vco.Data[7] = byte.Parse(Convert.ToInt64(direrStr.Substring(2, 2), 16) + "");
                            vco.Data[6] = byte.Parse(Convert.ToInt64(param.CRC1.Substring(0, 2), 16) + "");
                            vco.Data[7] = byte.Parse(Convert.ToInt64(param.CRC1.Substring(2, 2), 16) + "");
                            Tools.WriteToMyLog("CRC1检查数据", "CRC1检查数据");
                            break;
                        case "检查数据2":
                            //vco.Data[1] = byte.Parse(Convert.ToInt64(direrStr.Substring(4, 2), 16) + "");
                            //vco.Data[2] = byte.Parse(Convert.ToInt64(direrStr.Substring(6, 2), 16) + "");
                            vco.Data[1] = byte.Parse(Convert.ToInt64(param.CRC1.Substring(4, 2), 16) + "");
                            vco.Data[2] = byte.Parse(Convert.ToInt64(param.CRC1.Substring(6, 2), 16) + "");
                            vco.Data[3] = 170;
                            vco.Data[4] = 170;
                            vco.Data[5] = 170;
                            vco.Data[6] = 170;
                            vco.Data[7] = 170;
                            Tools.WriteToMyLog("CRC1检查数据2", "CRC1检查数据2");
                            break;
                        default:
                            break;
                    }

                    byte xhb = 1; //36 发送的次数

                    //开始写入driver文件
                    if (defineFlower.FlowName == "传递driver")
                    {
                        AddMessage(label, "正在刷写驱动文件...", Color.Green);
                        //this.Invoke(this.showPicDelegate, new object[] { pictureBox9, Application.StartupPath + "\\img\\" + "process_05.png" });
                        vco.Data[3] = xhb;
                        vco.Data[4] = DirerByte[9];
                        vco.Data[5] = DirerByte[10];
                        vco.Data[6] = DirerByte[11];
                        vco.Data[7] = DirerByte[12];
                        xhb++;

                        SendData(vco, canid, ref log);
                        //设置时间间隔
                        if (defineFlower.SleepTime != -1)
                        {
                            Thread.Sleep(defineFlower.SleepTime);
                        }
                        //接收
                        ReceiveMethod2(true, canid, ref log, param);

                        byte b = 33;
                        int xh = 4088;
                        int sum = 0;

                        int lasti = 0;//已经发送了多少个数据
                        for (int i = 13; i < DirerCount - 7; i += 7)
                        {
                           
                            //由于每条发送指令最多发送FFF既4095个数据，所以每发送4095个数据后要重新发送一条写入指令。
                            if (sum == xh)
                            {
                                //this.Invoke(this.progressBarDelegate, new object[] { i, barMaxValue });//进度条
                                sum = 0;
                                //前一次发送的最后一行数据
                                vco.Data[0] = b;
                                vco.Data[1] = DirerByte[i];
                                vco.Data[2] = 170;
                                vco.Data[3] = 170;
                                vco.Data[4] = 170;
                                vco.Data[5] = 170;
                                vco.Data[6] = 170;
                                vco.Data[7] = 170;
                                SendData(vco, canid, ref log);
                                //设置时间间隔
                                if (defineFlower.SleepTime != -1)
                                {
                                    Thread.Sleep(defineFlower.SleepTime);
                                }
                                //接收
                                ReceiveMethod2(false, canid, ref log, param);
                                //判断接收数据是否合格
                                if (!IsSend("02 76", 50, vco, false, canid, ref log,param))
                                {
                                    return lstDefineFlower;//如果接收数据失败，停止刷写
                                }

                                //如果剩下的数据个数超过了4095，那么指令为1F FF，如果没有超过那么剩下的个数是多少指令就是多少。
                                if (DirerCount - i - 1 > 4095)
                                {
                                    vco.Data[0] = bf[0];
                                    vco.Data[1] = bf[1];
                                    vco.Data[2] = bf[2];
                                    vco.Data[3] = xhb;
                                    vco.Data[4] = DirerByte[i + 1];
                                    vco.Data[5] = DirerByte[i + 2];
                                    vco.Data[6] = DirerByte[i + 3];
                                    vco.Data[7] = DirerByte[i + 4];
                                    SendData(vco, canid, ref log);
                                    //设置时间间隔
                                    if (defineFlower.SleepTime != -1)
                                    {
                                        Thread.Sleep(defineFlower.SleepTime);
                                    }
                                    //接收
                                    ReceiveMethod2(false, canid, ref log, param);
                                    xhb++;
                                    i += -2;
                                    b = 33;
                                    lasti = i + 4;
                                }
                                else
                                {
                                    string bfstr = System.Convert.ToString(DirerCount - i + 1, 16).PadLeft(3, '0');
                                    vco.Data[0] = byte.Parse(Convert.ToInt64("1" + bfstr.Substring(0, 1), 16) + "");
                                    vco.Data[1] = byte.Parse(Convert.ToInt64(bfstr.Substring(1, 2), 16) + "");
                                    vco.Data[2] = bf[2];
                                    vco.Data[3] = xhb;
                                    vco.Data[4] = DirerByte[i + 1];
                                    vco.Data[5] = DirerByte[i + 2];
                                    vco.Data[6] = DirerByte[i + 3];
                                    vco.Data[7] = DirerByte[i + 4];
                                    SendData(vco, canid, ref log);
                                    //设置时间间隔
                                    if (defineFlower.SleepTime != -1)
                                    {
                                        Thread.Sleep(defineFlower.SleepTime);
                                    }
                                    //接收
                                    ReceiveMethod2(false, canid, ref log, param);

                                    xhb++;
                                    i += -2;

                                    b = 33;

                                    lasti = i + 4;
                                }

                            }
                            else   //一般情况下发送一行数据。
                            {
                                

                                vco.Data[0] = b;
                                vco.Data[1] = DirerByte[i];
                                vco.Data[2] = DirerByte[i + 1];
                                vco.Data[3] = DirerByte[i + 2];
                                vco.Data[4] = DirerByte[i + 3];
                                vco.Data[5] = DirerByte[i + 4];
                                vco.Data[6] = DirerByte[i + 5];
                                vco.Data[7] = DirerByte[i + 6];
                                SendData(vco, canid, ref log);

                                sum += 7;
                                if (b == 47)
                                {
                                    b = 32;
                                }
                                else
                                {
                                    b++;
                                }

                                lasti = i + 6;
                            }

                        }
                        //最后剩余不足7个数据，额外发送
                        if (DirerCount - lasti > 1)
                        {
                            vco.Data[0] = b;
                            //for (int i = 0; i < 8; i++)
                            //{
                            //    if (DirerCount - lasti > 1)
                            //    {
                            //        vco.Data[i + 1] = DirerByte[lasti + 1];
                            //        lasti++;
                            //    }
                            //    else
                            //    {
                            //        vco.Data[i + 1] = 170;
                            //    }
                            //}
                            //SendData(vco,canid);
                            ////接收
                            //if (defineFlower.SleepTime != -1)
                            //{
                            //    Thread.Sleep(50);
                            //}
                            //ReceiveMethod2(false,canid);
                            ////判断接收数据是否合格
                            //if (!IsSend("02 76", 50, vco, false))
                            //{
                            //    return lstDefineFlower;//如果接收数据失败，停止刷写
                            //}

                            vco.Data[1] = DirerByte[lasti + 1];
                            for (int i = 0; i < 6; i++)
                            {
                                vco.Data[i + 2] = 170;
                            }

                            SendData(vco, canid, ref log);
                            //接收
                            if (defineFlower.SleepTime != -1)
                            {
                                Thread.Sleep(10);
                            }
                            ReceiveMethod2(false, canid, ref log, param);
                            //判断接收数据是否合格
                            if (!IsSend("02 76 01", 50, vco, false, canid, ref log, param))
                            {
                                return lstDefineFlower;//如果接收数据失败，停止刷写
                            }

                            Thread.Sleep(10);

                            vco.Data[0] = 5;
                            vco.Data[1] = 54;
                            vco.Data[2] = 2;
                            for (int i = 0; i < 3; i++)
                            {
                                vco.Data[i + 3] = 195;
                            }
                            vco.Data[6] = 170;
                            vco.Data[7] = 170;
                            SendData(vco, canid, ref log);
                            //接收
                            if (defineFlower.SleepTime != -1)
                            {
                                Thread.Sleep(10);
                            }
                            ReceiveMethod2(false, canid, ref log, param);
                            ////判断接收数据是否合格
                            if (!IsSend("02 76 02", 50, vco, false, canid, ref log, param))
                            {
                                return lstDefineFlower;//如果接收数据失败，停止刷写
                            }
                            this.Invoke(this.showMessageDelegate, new object[] { label, "刷写驱动文件成功！", Color.Green });
                        }

                    }
                    else if (defineFlower.FlowName == "传递bin1")//开始写入bin文件
                    {
                        AddMessage(label, "正在刷写应用文件1...", Color.Green);
                        //this.Invoke(this.showPicDelegate, new object[] { pictureBox7, Application.StartupPath + "\\img\\" + "process_07.png" });

                        xhb = 1;
                        vco.Data[3] = xhb;
                        vco.Data[4] = BinByte1[start + 9];
                        vco.Data[5] = BinByte1[start + 10];
                        vco.Data[6] = BinByte1[start + 11];
                        vco.Data[7] = BinByte1[start + 12];
                        xhb++;
                        SendData(vco, canid, ref log);
                        //设置时间间隔
                        if (defineFlower.SleepTime != -1)
                        {
                            Thread.Sleep(defineFlower.SleepTime);
                        }
                        //接收
                        ReceiveMethod2(true, canid, ref log, param);

                        byte b = 33;
                        int xh = 4088;
                        int sum = 0;
                        int lasti = 0;//已经发送了多少个数据,头文件和EF BE DA FF,所以是start+13, binCount1 - 7是因为我7个字节一发。
                        for (int i = start + 13; i < binCount1 - 7; i += 7)
                        {
                           
                            if (sum == xh)//每次发送4095个数据后，要再发送一条写入数据指令
                            {
                                this.Invoke(this.progressBarDelegate, new object[] { progressBar, DirerCount + i, barMaxValue });//进度条
                                sum = 0;
                                //发送最后一行
                                vco.Data[0] = b;
                                vco.Data[1] = BinByte1[i];
                                vco.Data[2] = 170;
                                vco.Data[3] = 170;
                                vco.Data[4] = 170;
                                vco.Data[5] = 170;
                                vco.Data[6] = 170;
                                vco.Data[7] = 170;
                                SendData(vco, canid, ref log);
                                //设置时间间隔
                                if (defineFlower.SleepTime != -1)
                                {
                                    Thread.Sleep(defineFlower.SleepTime);
                                }
                                //接收
                                ReceiveMethod2(false, canid, ref log, param);
                                //一组数据发送完成后，必须接收到了“02 76”才能接着发
                                if (!IsSend("02 76", 50, vco, false, canid, ref log, param))
                                {
                                    return lstDefineFlower;//如果接收数据失败，停止刷写
                                }

                                //判断是否发送到最后一轮数据了，最后一轮数据不满4095
                                if (binCount1 - i - 1 > 4095)
                                {
                                    vco.Data[0] = bf[0];
                                    vco.Data[1] = bf[1];
                                    vco.Data[2] = bf[2];
                                    vco.Data[3] = xhb;
                                    vco.Data[4] = BinByte1[i + 1];
                                    vco.Data[5] = BinByte1[i + 2];
                                    vco.Data[6] = BinByte1[i + 3];
                                    vco.Data[7] = BinByte1[i + 4];
                                    SendData(vco, canid, ref log);
                                    //设置时间间隔
                                    if (defineFlower.SleepTime != -1)
                                    {
                                        Thread.Sleep(50);
                                    }
                                    //接收
                                    ReceiveMethod2(false, canid, ref log, param);

                                    xhb++;
                                    i += -2;

                                    b = 33;

                                    lasti = i + 4;
                                }
                                else
                                {
                                    string bfstr = System.Convert.ToString(binCount1 - i + 1, 16).PadLeft(3, '0');
                                    vco.Data[0] = byte.Parse(Convert.ToInt64("1" + bfstr.Substring(0, 1), 16) + "");
                                    vco.Data[1] = byte.Parse(Convert.ToInt64(bfstr.Substring(1, 2), 16) + "");
                                    vco.Data[2] = bf[2];
                                    vco.Data[3] = xhb;
                                    vco.Data[4] = BinByte1[i + 1];
                                    vco.Data[5] = BinByte1[i + 2];
                                    vco.Data[6] = BinByte1[i + 3];
                                    vco.Data[7] = BinByte1[i + 4];
                                    SendData(vco, canid, ref log);
                                    //设置时间间隔
                                    if (defineFlower.SleepTime != -1)
                                    {
                                        Thread.Sleep(50);
                                    }
                                    //接收
                                    ReceiveMethod2(false, canid, ref log, param);


                                    xhb++;
                                    i += -2;

                                    b = 33;

                                    lasti = i + 4;
                                }
                            }
                            else
                            {
                                vco.Data[0] = b;
                                if (b == 47)
                                {
                                    b = 32;
                                }
                                else
                                {
                                    b++;
                                }
                                vco.Data[1] = BinByte1[i];
                                vco.Data[2] = BinByte1[i + 1];
                                vco.Data[3] = BinByte1[i + 2];
                                vco.Data[4] = BinByte1[i + 3];
                                vco.Data[5] = BinByte1[i + 4];
                                vco.Data[6] = BinByte1[i + 5];
                                vco.Data[7] = BinByte1[i + 6];

                                SendData(vco, canid, ref log);
                                sum += 7;

                                lasti = i + 6;
                            }
                        }
                        //最后剩余不足7个数据，额外发送
                        if (binCount1 - lasti > 1)
                        {
                            vco.Data[0] = b;
                            for (int i = 0; i < 8; i++)
                            {
                                if (binCount1 - lasti > 1)
                                {
                                    vco.Data[i + 1] = BinByte1[lasti + 1];
                                    lasti++;
                                }
                                else
                                {
                                    vco.Data[i + 1] = 170;
                                }
                            }
                            SendData(vco, canid, ref log);

                            if (defineFlower.SleepTime != -1)
                            {
                                Thread.Sleep(defineFlower.SleepTime);
                            }
                            //接收
                            ReceiveMethod2(false, canid, ref log, param);
                            //一组数据发送完成后，必须接收到了“02 76”才能接着发
                            if (!IsSend("02 76", 50, vco, false, canid, ref log, param))
                            {
                                return lstDefineFlower;//如果接收数据失败，停止刷写
                            }
                            this.Invoke(this.showMessageDelegate, new object[] { label, "刷写应用文件成功！", Color.Green });
                        }
                    }

                    else if (defineFlower.FlowName == "传递bin2")//开始写入bin文件
                    {
                        AddMessage(label, "正在刷写应用文件2...", Color.Green);
                        //this.Invoke(this.showPicDelegate, new object[] { pictureBox7, Application.StartupPath + "\\img\\" + "process_07.png" });

                        xhb = 1;
                        vco.Data[3] = xhb;
                        vco.Data[4] = BinByte2[start + 9];
                        vco.Data[5] = BinByte2[start + 10];
                        vco.Data[6] = BinByte2[start + 11];
                        vco.Data[7] = BinByte2[start + 12];

                        xhb++;

                        SendData(vco, canid, ref log);
                        //设置时间间隔
                        if (defineFlower.SleepTime != -1)
                        {
                            Thread.Sleep(defineFlower.SleepTime);
                        }
                        //接收
                        ReceiveMethod2(true, canid, ref log, param);

                        byte b = 33;
                        int xh = 4088;
                        int sum = 0;
                        int lasti = 0;//已经发送了多少个数据
                        for (int i = start + 13; i < binCount2 - 7; i += 7)
                        {
                           
                            if (sum == xh)//每次发送4095个数据后，要再发送一条写入数据指令
                            {
                                this.Invoke(this.progressBarDelegate, new object[] { progressBar, DirerCount + binCount1 + i, barMaxValue });//进度条
                                sum = 0;
                                //发送最后一行
                                vco.Data[0] = b;
                                vco.Data[1] = BinByte2[i];
                                vco.Data[2] = 170;
                                vco.Data[3] = 170;
                                vco.Data[4] = 170;
                                vco.Data[5] = 170;
                                vco.Data[6] = 170;
                                vco.Data[7] = 170;
                                SendData(vco, canid, ref log);
                                //设置时间间隔
                                if (defineFlower.SleepTime != -1)
                                {
                                    Thread.Sleep(defineFlower.SleepTime);
                                }
                                //接收
                                ReceiveMethod2(false, canid, ref log, param);
                                //一组数据发送完成后，必须接收到了“02 76”才能接着发
                                if (!IsSend("02 76", 50, vco, false, canid, ref log, param))
                                {
                                    return lstDefineFlower;//如果接收数据失败，停止刷写
                                }

                                //判断是否发送到最后一轮数据了，最后一轮数据不满4095
                                if (binCount2 - i - 1 > 4095)
                                {
                                    vco.Data[0] = bf[0];
                                    vco.Data[1] = bf[1];
                                    vco.Data[2] = bf[2];
                                    vco.Data[3] = xhb;
                                    vco.Data[4] = BinByte2[i + 1];
                                    vco.Data[5] = BinByte2[i + 2];
                                    vco.Data[6] = BinByte2[i + 3];
                                    vco.Data[7] = BinByte2[i + 4];
                                    SendData(vco, canid, ref log);
                                    //设置时间间隔
                                    if (defineFlower.SleepTime != -1)
                                    {
                                        Thread.Sleep(50);
                                    }
                                    //接收
                                    ReceiveMethod2(false, canid, ref log, param);

                                    xhb++;
                                    i += -2;

                                    b = 33;

                                    lasti = i + 4;
                                }
                                else
                                {
                                    string bfstr = System.Convert.ToString(binCount2 - i + 1, 16).PadLeft(3, '0');
                                    vco.Data[0] = byte.Parse(Convert.ToInt64("1" + bfstr.Substring(0, 1), 16) + "");
                                    vco.Data[1] = byte.Parse(Convert.ToInt64(bfstr.Substring(1, 2), 16) + "");
                                    vco.Data[2] = bf[2];
                                    vco.Data[3] = xhb;
                                    vco.Data[4] = BinByte2[i + 1];
                                    vco.Data[5] = BinByte2[i + 2];
                                    vco.Data[6] = BinByte2[i + 3];
                                    vco.Data[7] = BinByte2[i + 4];
                                    SendData(vco, canid, ref log);
                                    //设置时间间隔
                                    if (defineFlower.SleepTime != -1)
                                    {
                                        Thread.Sleep(50);
                                    }
                                    //接收
                                    ReceiveMethod2(false, canid, ref log, param);


                                    xhb++;
                                    i += -2;

                                    b = 33;

                                    lasti = i + 4;
                                }
                            }
                            else
                            {
                                vco.Data[0] = b;
                                if (b == 47)
                                {
                                    b = 32;
                                }
                                else
                                {
                                    b++;
                                }
                                vco.Data[1] = BinByte2[i];
                                vco.Data[2] = BinByte2[i + 1];
                                vco.Data[3] = BinByte2[i + 2];
                                vco.Data[4] = BinByte2[i + 3];
                                vco.Data[5] = BinByte2[i + 4];
                                vco.Data[6] = BinByte2[i + 5];
                                vco.Data[7] = BinByte2[i + 6];

                                SendData(vco, canid, ref log);
                                sum += 7;

                                lasti = i + 6;
                            }
                        }
                        //最后剩余不足7个数据，额外发送
                        if (binCount2 - lasti > 1)
                        {
                            vco.Data[0] = b;
                            for (int i = 0; i < 8; i++)
                            {
                                if (binCount2 - lasti > 1)
                                {
                                    vco.Data[i + 1] = BinByte2[lasti + 1];
                                    lasti++;
                                }
                                else
                                {
                                    vco.Data[i + 1] = 170;
                                }
                            }
                            SendData(vco, canid, ref log);

                            if (defineFlower.SleepTime != -1)
                            {
                                Thread.Sleep(defineFlower.SleepTime);
                            }
                            //接收
                            ReceiveMethod2(false, canid, ref log, param);
                            //一组数据发送完成后，必须接收到了“02 76”才能接着发
                            if (!IsSend("02 76", 50, vco, false, canid, ref log, param))
                            {
                                return lstDefineFlower;//如果接收数据失败，停止刷写
                            }
                            this.Invoke(this.showMessageDelegate, new object[] { label, "刷写应用文件成功！", Color.Green });
                        }
                    }

                    else if (defineFlower.FlowName == "传递cal")//开始写入bin文件
                    {
                        AddMessage(label, "正在刷写标定文件...", Color.Green);
                        //this.Invoke(this.showPicDelegate, new object[] { pictureBox7, Application.StartupPath + "\\img\\" + "process_07.png" });

                        xhb = 1;
                        vco.Data[3] = xhb;
                        vco.Data[4] = CalByte[start + 9];
                        vco.Data[5] = CalByte[start + 10];
                        vco.Data[6] = CalByte[start + 11];
                        vco.Data[7] = CalByte[start + 12];

                        xhb++;

                        SendData(vco, canid, ref log);
                        //设置时间间隔
                        if (defineFlower.SleepTime != -1)
                        {
                            Thread.Sleep(defineFlower.SleepTime);
                        }
                        //接收
                        ReceiveMethod2(true, canid, ref log, param);

                        byte b = 33;
                        int xh = 4088;
                        int sum = 0;
                        int lasti = 0;//已经发送了多少个数据
                        for (int i = start + 13; i < calCount - 7; i += 7)
                        {
                            if (sum == xh)//每次发送4095个数据后，要再发送一条写入数据指令
                            {
                                this.Invoke(this.progressBarDelegate, new object[] { progressBar, DirerCount + binCount1 + binCount2 + i, barMaxValue });//进度条
                                sum = 0;
                                //发送最后一行
                                vco.Data[0] = b;
                                vco.Data[1] = CalByte[i];
                                vco.Data[2] = 170;
                                vco.Data[3] = 170;
                                vco.Data[4] = 170;
                                vco.Data[5] = 170;
                                vco.Data[6] = 170;
                                vco.Data[7] = 170;
                                SendData(vco, canid, ref log);
                                //设置时间间隔
                                if (defineFlower.SleepTime != -1)
                                {
                                    Thread.Sleep(defineFlower.SleepTime);
                                }
                                //接收
                                ReceiveMethod2(false, canid, ref log, param);
                                //一组数据发送完成后，必须接收到了“02 76”才能接着发
                                if (!IsSend("02 76", 50, vco, false, canid, ref log, param))
                                {
                                    return lstDefineFlower;//如果接收数据失败，停止刷写
                                }

                                //判断是否发送到最后一轮数据了，最后一轮数据不满4095
                                if (calCount - i - 1 > 4095)
                                {
                                    vco.Data[0] = bf[0];
                                    vco.Data[1] = bf[1];
                                    vco.Data[2] = bf[2];
                                    vco.Data[3] = xhb;
                                    vco.Data[4] = CalByte[i + 1];
                                    vco.Data[5] = CalByte[i + 2];
                                    vco.Data[6] = CalByte[i + 3];
                                    vco.Data[7] = CalByte[i + 4];
                                    SendData(vco, canid, ref log);
                                    //设置时间间隔
                                    if (defineFlower.SleepTime != -1)
                                    {
                                        Thread.Sleep(50);
                                    }
                                    //接收
                                    ReceiveMethod2(false, canid, ref log, param);

                                    xhb++;
                                    i += -2;

                                    b = 33;

                                    lasti = i + 4;
                                }
                                else
                                {
                                    string bfstr = System.Convert.ToString(calCount - i + 1, 16).PadLeft(3, '0');
                                    vco.Data[0] = byte.Parse(Convert.ToInt64("1" + bfstr.Substring(0, 1), 16) + "");
                                    vco.Data[1] = byte.Parse(Convert.ToInt64(bfstr.Substring(1, 2), 16) + "");
                                    vco.Data[2] = bf[2];
                                    vco.Data[3] = xhb;
                                    vco.Data[4] = CalByte[i + 1];
                                    vco.Data[5] = CalByte[i + 2];
                                    vco.Data[6] = CalByte[i + 3];
                                    vco.Data[7] = CalByte[i + 4];
                                    SendData(vco, canid, ref log);
                                    //设置时间间隔
                                    if (defineFlower.SleepTime != -1)
                                    {
                                        Thread.Sleep(50);
                                    }
                                    //接收
                                    ReceiveMethod2(false, canid, ref log, param);

                                    xhb++;
                                    i += -2;

                                    b = 33;

                                    lasti = i + 4;
                                }
                            }
                            else
                            {
                                vco.Data[0] = b;
                                if (b == 47)
                                {
                                    b = 32;
                                }
                                else
                                {
                                    b++;
                                }
                                vco.Data[1] = CalByte[i];
                                vco.Data[2] = CalByte[i + 1];
                                vco.Data[3] = CalByte[i + 2];
                                vco.Data[4] = CalByte[i + 3];
                                vco.Data[5] = CalByte[i + 4];
                                vco.Data[6] = CalByte[i + 5];
                                vco.Data[7] = CalByte[i + 6];

                                SendData(vco, canid, ref log);
                                sum += 7;

                                lasti = i + 6;
                            }
                        }
                        //最后剩余不足7个数据，额外发送
                        if (calCount - lasti > 1)
                        {
                            vco.Data[0] = b;
                            for (int i = 0; i < 8; i++)
                            {
                                if (calCount - lasti > 1)
                                {
                                    vco.Data[i + 1] = CalByte[lasti + 1];
                                    lasti++;
                                }
                                else
                                {
                                    vco.Data[i + 1] = 170;
                                }
                            }
                            SendData(vco, canid, ref log);

                            if (defineFlower.SleepTime != -1)
                            {
                                Thread.Sleep(defineFlower.SleepTime);
                            }
                            //接收
                            ReceiveMethod2(false, canid, ref log, param);
                            //一组数据发送完成后，必须接收到了“02 76”才能接着发
                            if (!IsSend("02 76", 50, vco, false, canid, ref log, param))
                            {
                                return lstDefineFlower;//如果接收数据失败，停止刷写
                            }
                            this.Invoke(this.showMessageDelegate, new object[] { label, "刷写CAL文件成功！", Color.Green });
                        }
                    }

                    else
                    {
                        SendData(vco, canid, ref log);

                        //设置时间间隔
                        if (defineFlower.SleepTime != -1)
                        {
                            Thread.Sleep(defineFlower.SleepTime);
                        }
                        //接收
                        ReceiveMethod2(true, canid, ref log, param);

                        //由于这些数据回复的时候回复需要等待，等待过程中会出现等待码“78”，需要特殊处理
                        switch (defineFlower.FlowName)
                        {
                            //case "会话控制":
                            //    if (!IsSend("50 03", 1000, vco, true, canid, ref log, param))
                            //    {
                            //        return lstDefineFlower;//如果接收数据失败，停止刷写
                            //    }
                            //    break;
                            //case "编程设置":
                            //    if (!IsSend("C5 02", 1000, vco, true, canid, ref log, param))
                            //    {
                            //        return lstDefineFlower;//如果接收数据失败，停止刷写
                            //    }
                            //    break;
                            //case "通讯控制":
                            //    if (!IsSend("68 03", 1000, vco, true, canid, ref log, param))
                            //    {
                            //        return lstDefineFlower;//如果接收数据失败，停止刷写
                            //    }
                            //    break;
                            //case "服务控制":
                            //    if (!IsSend("50 02", 1000, vco, true, canid, ref log, param))
                            //    {
                            //        return lstDefineFlower;//如果接收数据失败，停止刷写
                            //    }
                            //    break;
                            case "清理数据":
                                if (!IsSend("71 01 FF", 1000, vco, true, canid, ref log, param))
                                {
                                    return lstDefineFlower;//如果接收数据失败，停止刷写
                                }
                                break;
                            case "检查流程2":
                                if (!IsSend("71 01 02 02 00", 1000, vco, true, canid, ref log, param))
                                {
                                    return lstDefineFlower;//如果接收数据失败，停止刷写
                                }
                                break;
                            case "检查兼容性":
                                if (!IsSend("71 01 FF 01 00", 1000, vco, true, canid, ref log, param))
                                {
                                    return lstDefineFlower;//如果接收数据失败，停止刷写
                                }
                                break;
                            case "写入日期":
                                if (!IsSend("6E F1 99", 1000, vco, true, canid, ref log, param))
                                {
                                    return lstDefineFlower;//如果接收数据失败，停止刷写
                                }
                                this.Invoke(this.progressBarDelegate, new object[] { progressBar, barMaxValue, barMaxValue });
                                break;
                            case "安全访问seed":
                                //通过收到的seed数据来计算得到key数据，再发出去
                                if (!IsSend("67 11", 50, vco, true, canid, ref log, param))
                                {
                                    return lstDefineFlower;//如果接收数据失败，停止刷写
                                }
                                string[] sends = param.ReceiveList[param.ReceiveList.Count - 1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                                seedkey = SecurityAccess(sends[4] + sends[5] + sends[6] + sends[7]);
                                break;
                            case "下载cal":
                                //设置时间间隔
                                if (defineFlower.SleepTime != -1)
                                {
                                    Thread.Sleep(defineFlower.SleepTime);
                                }
                                //接收
                                ReceiveMethod2(true, canid, ref log,param);

                                //判断接收数据是否合格
                                if (!IsSend("74 20", 50, vco, true, canid, ref log, param))
                                {
                                    return lstDefineFlower;//如果接收数据失败，停止刷写
                                }
                                break;
                            case "检查流程2-cal":
                                //通过收到的seed数据来计算得到key数据，再发出去
                                if (!IsSend("71 01 02 02 00", 50, vco, true, canid, ref log, param))
                                {
                                    return lstDefineFlower;//如果接收数据失败，停止刷写
                                }
                                break;
                            case "结束请求":
                                //通过收到的seed数据来计算得到key数据，再发出去
                                if (!IsSend("77", 50, vco, true, canid, ref log, param))
                                {
                                    return lstDefineFlower;//如果接收数据失败，停止刷写
                                }
                                break;
                            case "重置ECU":
                                //通过收到的seed数据来计算得到key数据，再发出去
                                if (!IsSend("51 01", 50, vco, true, canid, ref log, param))
                                {
                                    return lstDefineFlower;//如果接收数据失败，停止刷写
                                }
                                Thread.Sleep(1000);
                                break;
                            case "02 04状态":
                                //通过收到的seed数据来计算得到key数据，再发出去
                                if (!IsSend("6E 02 04", 50, vco, true, canid, ref log, param))
                                {
                                    return lstDefineFlower;//如果接收数据失败，停止刷写
                                }
                                break;
                            default:
                                break;
                        }
                        // this.Invoke(this.showMessageDelegate, new object[] { defineFlower.FlowName+"成功！", Color.Green });
                    }
                }

                //Log.writeTxt(log + "", filePath);

                #endregion
            }
            catch (Exception ex)
            {
                //logger.Error(ex.Message + "***" + ex.StackTrace);
                Log.writeTxt(ex.Message + "***" + ex.StackTrace, filePath);
            }

            return lstDefineFlower;
        }
        /// <summary>
        /// 发送并数据
        /// </summary>
        /// <param name="vco"></param>
        unsafe private void SendData(VCI_CAN_OBJ vco, UInt32 canid, ref StringBuilder log)
        {
            //设置CAN卡的参数
            int nTimeOut = 3000;

            //VCI_SetReference(configer.DevType, configer.DevInd, canid, 4, (byte*)&nTimeOut);
            //发送
            if (VCI_Transmit(configer.DevType, configer.DevInd, canid, ref vco, 1) == 0)
            {
                log.AppendLine("发送失败：" + vco.Data[0].ToString("X2") + " " + vco.Data[1].ToString("X2") + " " + vco.Data[2].ToString("X2") + " " + vco.Data[3].ToString("X2") + " " + vco.Data[4].ToString("X2") + " " + vco.Data[5].ToString("X2") + " " + vco.Data[6].ToString("X2") + " " + vco.Data[7].ToString("X2"));
                //Log.writeTxt(log, filePath);
                return;
            }
            log.AppendLine(string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff") + "0x{0} ", System.Convert.ToString((Int32)vco.ID, 16)) + " " + vco.Data[0].ToString("X2") + " " + vco.Data[1].ToString("X2") + " " + vco.Data[2].ToString("X2") + " " + vco.Data[3].ToString("X2") + " " + vco.Data[4].ToString("X2") + " " + vco.Data[5].ToString("X2") + " " + vco.Data[6].ToString("X2") + " " + vco.Data[7].ToString("X2"));
            //Log.writeTxt(log, filePath);
        }
        /// <summary>
        /// 处理TCU回复的数据
        /// </summary>
        /// <param name="res">判断条件</param>
        /// <param name="sleepTime">等待接收时间</param>
        /// <param name="vco">发送结束命令</param>
        /// <param name="isReceiveList">是否把接收到的数据写入到queReceiveMsg结果判断中</param>
        /// <returns></returns>
        unsafe private bool IsSend(string res, int sleepTime, VCI_CAN_OBJ vco, bool isCheck, UInt32 canid, ref StringBuilder log,Parameter param)
        {
            bool b = true;
            //如果回复数据包含 “24”说明通讯中断，结束刷写
            int count = 0;
            //等待接收数据，如果超过了60秒，结束刷写
            while (!param.ReceiveList[param.ReceiveList.Count - 1].Contains(res))
            {
                //流控制帧
                //vco.Data[0] = 48;
                //vco.Data[1] = 0;
                //vco.Data[2] = 0;
                //vco.Data[3] = 170;
                //vco.Data[4] = 170;
                //vco.Data[5] = 170;
                //vco.Data[6] = 170;
                //vco.Data[7] = 170;
                //SendData(vco, canid, ref log);

                Thread.Sleep(sleepTime);
                ReceiveMethod2(isCheck, canid, ref log,param);
                count += sleepTime;

                if (count > 10000)
                {
                    b = false;
                    break;
                }
            }
            if (!b)
            {
                vco.Data[0] = 2;
                vco.Data[1] = 17;
                vco.Data[2] = 1;  //02 11 01 重置ecu指令
                vco.Data[3] = 170;
                vco.Data[4] = 170;
                vco.Data[5] = 170;
                vco.Data[6] = 170;
                vco.Data[7] = 170;
                SendData(vco, canid, ref log);
                Thread.Sleep(50);
                ReceiveMethod2(true, canid, ref log,param);

                for (int i = 0; i < 3; i++)
                {
                    int k = 0;
                    while (!param.ReceiveList[param.ReceiveList.Count - 1].Contains("51 01"))  //回复51 01为02 11 01的回复。40
                    {
                        SendData(vco, canid, ref log);
                        Thread.Sleep(50);
                        ReceiveMethod2(true, canid, ref log, param);
                        k += 50;
                        if (k > 10000)
                        {
                            b = false;
                            break;
                        }
                    }
                    
                }
                    
            }
            return b;
        }
        /// <summary>
        /// 通过seed计算得到key
        /// </summary>
        /// <param name="hbSeed"></param>
        /// <param name="lbSeed"></param>
        /// <returns></returns>
        public string SecurityAccess(string seed)
        {
            string key = null;
            uint value = 0xec3a5941;
            //去掉空格
            seed = seed.Replace(" ", "");
            uint seed1 = Convert.ToUInt32(seed, 16);
            uint seed2 = (((seed1 >> 9) | (seed1 << 22)) * 3) ^ value;
            uint seed3 = (seed2 << 14) | (seed2 >> 17);
            //转化为字符串
            string keyValue = seed3.ToString("x8").ToUpper();
            key = keyValue.Substring(0, 2) + " " + keyValue.Substring(2, 2) + " " + keyValue.Substring(4, 2) + " " + keyValue.Substring(6, 2) + " " + "aa";
            return key;
        }
        /// <summary>
        /// 判断结果
        /// </summary>
        /// <param name="lstDefineFlower"></param>
        private Boolean CheckFlow(List<DefineFlower> lstDefineFlower, int writeTime, Label label, ref StringBuilder log,Parameter param)
        {
            Boolean finalResult = true;

            try
            {
                string vinCode = string.Empty;
                string tpmsCode = string.Empty;
                string dtcCode = string.Empty;
                if (lstDefineFlower.Count == 0) finalResult = false;

                for (int defineFlowerIndex = 0; defineFlowerIndex < lstDefineFlower.Count; defineFlowerIndex++)
                {
                    DefineFlower defineFlower = lstDefineFlower[defineFlowerIndex];

                    #region 取出消息

                    string msg = string.Empty;
                    for (int i = 0; i < defineFlower.ReceiveNum; i++)
                    {
                        if (param.QueReceiveMsg.Count != 0)
                        {
                            msg += param.QueReceiveMsg.Dequeue() + "";
                        }
                    }

                    defineFlower.ReceiveMsg = msg.ToUpper();

                    //判断是否是等待指令，比如03 7F 78 ,如果是不管它，过滤掉
                    string[] strs = configer.WaitCode.Split(',');

                    //判断如果接收到的是等待指令，就跳过不做处理
                    bool iscfzl = false;
                    foreach (string item in strs)
                    {
                        if (defineFlower.ReceiveMsg.IndexOf(item) >= 0)
                        {
                            defineFlowerIndex--;
                            iscfzl = true;
                            continue;
                        }
                    }

                    if (iscfzl)
                    {
                        continue;
                    }

                    //errorCode += defineFlower.SendCmd + "=" + defineFlower.ReceiveMsg + "\r\n";

                    #endregion

                    if (defineFlower.ReceiveNum == 0)
                    {
                        #region 没有回复的帧

                        Boolean result = (defineFlower.ReceiveMsg == string.Empty) ? true : false;
                        log.AppendLine(string.Format("{0}{1}", defineFlower.FlowName, (result) ? "成功!" : "失败!"));

                        finalResult &= result;

                        #endregion
                    }
                    else if (defineFlower.ReceiveNum == 1)
                    {
                        #region 判断单帧
                        
                        string[] receiveCmdS = defineFlower.ReceiveCmd.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                        Boolean result = false;
                        foreach (string receiveCmd in receiveCmdS)
                        {
                            
                            //if (defineFlower.ReceiveMsg.IndexOf("7F 11 78") >= 0)
                            //{
                            //    result = true;
                            //    continue;
                            //}
                            //else
                            //{
                                result |= (defineFlower.ReceiveMsg.IndexOf(receiveCmd) >= 0);
                            //}
                            if (!result)
                            {
                                log.AppendLine(defineFlower.ReceiveMsg+"---"+receiveCmd);
                            }
                        }
                        log.AppendLine(string.Format(defineFlower.ReceiveMsg + "{0}{1}", defineFlower.FlowName, (result) ? "成功!" : "失败!"));

                        finalResult &= result;

                        #endregion
                    }

                    if (finalResult == false) break;
                }
                //万一前面判断失误，6E F1 99表示最后一帧回复，有这个的话，表示刷写成功了。
                if (finalResult == false)
                {
                    for (int i = 0; i < param.ReceiveList.Count; i++)
                    {
                        if (param.ReceiveList[i].ToString().Contains("6E F1 99"))
                        {
                            finalResult = true;
                            break;
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                Log.writeTxt(ex.Message + "***" + ex.StackTrace, filePath);
                finalResult = false;
            }
            finally
            {
                #region 关闭接收线程

                if (this.threadReceive != null && this.threadReceive.IsAlive)
                {
                    this.threadReceive.Abort();
                    this.threadReceive = null;
                    Thread.Sleep(configer.ThreadSleep);
                }

                #endregion
            }

            return finalResult;
        }
        /// <summary>
        /// 接收数据
        /// </summary>
        unsafe private void ReceiveMethod2(bool isRec, UInt32 canid, ref StringBuilder log,Parameter param)
        {
            try
            {
                //判断接收区是否有数据
                UInt32 res = new UInt32();
                res = VCI_GetReceiveNum(configer.DevType, configer.DevInd, canid);
                if (res == 0) return;
                //分配内存
                UInt32 con_maxlen = 50;
                IntPtr pt = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(VCI_CAN_OBJ)) * (Int32)con_maxlen);
                //接收数据
                res = VCI_Receive(configer.DevType, configer.DevInd, canid, pt, con_maxlen, -1);

                for (UInt32 i = 0; i < res; i++)
                {
                    StringBuilder str = new StringBuilder();

                    VCI_CAN_OBJ obj = (VCI_CAN_OBJ)Marshal.PtrToStructure((IntPtr)((UInt32)pt + i * Marshal.SizeOf(typeof(VCI_CAN_OBJ))), typeof(VCI_CAN_OBJ));

                    if (obj.ID != this.response) continue;

                    str.Append(string.Format("0x{0} ", System.Convert.ToString((Int32)obj.ID, 16)));

                    if (obj.RemoteFlag == 0)
                    {
                        byte len = (byte)(obj.DataLen % 9);
                        byte j = 0;
                        if (j++ < len)
                            str.Append(" " + System.Convert.ToString(obj.Data[0], 16).PadLeft(2, '0'));
                        if (j++ < len)
                            str.Append(" " + System.Convert.ToString(obj.Data[1], 16).PadLeft(2, '0'));
                        if (j++ < len)
                            str.Append(" " + System.Convert.ToString(obj.Data[2], 16).PadLeft(2, '0'));
                        if (j++ < len)
                            str.Append(" " + System.Convert.ToString(obj.Data[3], 16).PadLeft(2, '0'));
                        if (j++ < len)
                            str.Append(" " + System.Convert.ToString(obj.Data[4], 16).PadLeft(2, '0'));
                        if (j++ < len)
                            str.Append(" " + System.Convert.ToString(obj.Data[5], 16).PadLeft(2, '0'));
                        if (j++ < len)
                            str.Append(" " + System.Convert.ToString(obj.Data[6], 16).PadLeft(2, '0'));
                        if (j++ < len)
                            str.Append(" " + System.Convert.ToString(obj.Data[7], 16).PadLeft(2, '0'));
                    }

                    //上面代码不用管，别人给的，下面的是我们的
                    //记录回复信息，加入到队列
                    if (isRec&&param!=null)
                    {
                        //把关键回复记入到结果队列，供后面判断刷写结果
                        param.QueReceiveMsg.Enqueue((str + "").ToUpper());
                    }
                    //记录给日志用
                    if (param != null)
                    {
                        param.ReceiveList.Add((str + "").ToUpper());
                    }
                    
                    log.AppendLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")+ str + "");
                    //Log.writeTxt(, filePath);
                }
                Marshal.FreeHGlobal(pt);
            }
            catch (Exception ex)
            {
                //if (!ex.Message.Contains("正在中止线程") && !ex.Message.Contains("Thread was being aborted"))                         logger.Error(ex.Message + "***" + ex.StackTrace);
                Log.writeTxt(ex.Message + "***" + ex.StackTrace, filePath);
            }
        }

        #endregion

        #region 界面事件

        /// <summary>
        /// 检测开关按钮状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timCheck(object obj)
        {
            //Parameter ioTmp = obj as Parameter;

            //if (!ioTmp.CanUse)
            //{
            //    return;
            //}
            //else
            //{
            //    lock (ioTmp.Olock)
            //    {
            //        if (ioTmp.CanUse)
            //        {
            //            ioTmp.CanUse = false;
            //        }
            //        else
            //        {
            //            return;
            //        }
            //    }
            //}

            //try
            //{
            //    ErrorCode err = ErrorCode.Success;

            //    //读取8个灯的状态值
            //    byte btn1 = new byte();
            //    err = instantDiCtrl.ReadBit(0, ioTmp.Input, out btn1);

            //    if (btn1 == (byte) 1)
            //    {
            //        this.Invoke(ioTmp.ButtonClickDelegate_Prop, new object[] { ioTmp, null });
            //    }

            //    #region  comment out

            //    //for (int i = 0; i < 8; i++)
            //    //{
            //    //    if (result[i] == 1)
            //    //    {
            //    //        //检测到灯的状态触发点击事件
            //    //        Thread.Sleep(100);
            //    //        switch (i)
            //    //        {
            //    //            case 0:
            //    //                this.btStart1_Click(null, null);
            //    //                break;
            //    //            case 1:
            //    //                this.btStart2_Click(null, null);
            //    //                break;
            //    //            case 2:
            //    //                this.btStart3_Click(null, null);
            //    //                break;
            //    //            case 3:
            //    //                this.btStart4_Click(null, null);
            //    //                break;
            //    //            case 4:
            //    //                this.btStart5_Click(null, null);
            //    //                break;
            //    //            case 5:
            //    //                this.btStart6_Click(null, null);
            //    //                break;
            //    //            case 6:
            //    //                this.btStart7_Click(null, null);
            //    //                break;
            //    //            case 7:
            //    //                this.btStart8_Click(null, null);
            //    //                break;
            //    //        }
            //    //    }
            //    //}

            //    #endregion
            //}
            //catch (Exception ex)
            //{
            //    //logger.Error(ex.Message + "***" + ex.StackTrace);
            //    Log.writeTxt(ex.Message + "***" + ex.StackTrace, filePath);
            //}
            //finally
            //{
            //    ioTmp.CanUse = true;
            //}
        }
        /// <summary>
        /// 关闭按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_bOpen == 1)
                {
                    //关闭设备
                    VCI_CloseDevice(configer.DevType, configer.DevInd);
                    m_bOpen = 0;
                }

                //停止接收线程
                if (this.threadReceive != null && this.threadReceive.IsAlive)
                {
                    this.threadReceive.Abort();
                    this.threadReceive = null;
                }

                //this.Close();
                Application.Exit();
            }
            catch (Exception ex)
            {
               // logger.Error(ex.Message + "***" + ex.StackTrace);
                Log.writeTxt(ex.Message + "***" + ex.StackTrace, filePath);
            }
        }
        /// <summary>
        /// 界面最小化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        /// <summary>
        /// 系统配置按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfig_Click(object sender, EventArgs e)
        {
            FrmConfig frmConfig = new FrmConfig(localConnectionString);
            frmConfig.Show();
        }
        /// <summary>
        /// 系统复位按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("该操作会清空界面数据，请确认未进行刷写操作", "系统复位", messButton);
                if (dr == DialogResult.OK)
                {
                    //重置CAN卡
                    //VCI_ResetCAN(configer.DevType, configer.DevInd, 0);
                    //关闭CAN卡
                    //CloseDevice();
                    m_bOpen = 0;
                    VCI_CloseDevice(configer.DevType, configer.DevInd);

                    //this.Invoke(this.showPicDelegate, new object[] { pictureBox8, Application.StartupPath + "\\img\\" + "process-grey_03.png" });
                    //this.Invoke(this.showPicDelegate, new object[] { pictureBox9, Application.StartupPath + "\\img\\" + "process-grey_05.png" });
                    //this.Invoke(this.showPicDelegate, new object[] { pictureBox7, Application.StartupPath + "\\img\\" + "process-grey_07.png" });
                    //this.Invoke(this.showPicDelegate, new object[] { pictureBox10, Application.StartupPath + "\\img\\" + "process-grey_09.png" });
                    //this.Invoke(this.showPicDelegate, new object[] { pictureBox11, Application.StartupPath + "\\img\\" + "process-grey_11.png" });

                    this.Invoke(this.progressBarDelegate, new object[] { this.progressBar1, 0, 0 });
                    this.Invoke(this.progressBarDelegate, new object[] { this.progressBar2, 0, 0 });
                    this.Invoke(this.progressBarDelegate, new object[] { this.progressBar3, 0, 0 });
                    this.Invoke(this.progressBarDelegate, new object[] { this.progressBar4, 0, 0 });
                    this.Invoke(this.progressBarDelegate, new object[] { this.progressBar5, 0, 0 });
                    this.Invoke(this.progressBarDelegate, new object[] { this.progressBar6, 0, 0 });
                    this.Invoke(this.progressBarDelegate, new object[] { this.progressBar7, 0, 0 });
                    this.Invoke(this.progressBarDelegate, new object[] { this.progressBar8, 0, 0 });

                    this.Invoke(this.buttonDelegate, new object[] { this.btStart1, "开始刷写" });
                    this.Invoke(this.buttonDelegate, new object[] { this.btStart2, "开始刷写" });
                    this.Invoke(this.buttonDelegate, new object[] { this.btStart3, "开始刷写" });
                    this.Invoke(this.buttonDelegate, new object[] { this.btStart4, "开始刷写" });
                    this.Invoke(this.buttonDelegate, new object[] { this.btStart5, "开始刷写" });
                    this.Invoke(this.buttonDelegate, new object[] { this.btStart6, "开始刷写" });
                    this.Invoke(this.buttonDelegate, new object[] { this.btStart7, "开始刷写" });
                    this.Invoke(this.buttonDelegate, new object[] { this.btStart8, "开始刷写" });

                    //清空数据
                    this.lbMessage1.Text = "";
                    this.lbMessage2.Text = "";
                    this.lbMessage3.Text = "";
                    this.lbMessage4.Text = "";
                    this.lbMessage5.Text = "";
                    this.lbMessage6.Text = "";
                    this.lbMessage7.Text = "";
                    this.lbMessage8.Text = "";

                    
                    this.tbVIN.Text = "";
                    this.tbVIN1.Text = "";
                    this.tbVIN2.Text = "";
                    this.tbVIN3.Text = "";
                    this.tbVIN4.Text = "";
                    this.tbVIN5.Text = "";
                    this.tbVIN6.Text = "";
                    this.tbVIN7.Text = "";
                    this.tbVIN8.Text = "";

                    this.tbTracCode1.Text = "";
                    this.tbTracCode2.Text = "";
                    this.tbTracCode3.Text = "";
                    this.tbTracCode4.Text = "";
                    this.tbTracCode5.Text = "";
                    this.tbTracCode6.Text = "";
                    this.tbTracCode7.Text = "";
                    this.tbTracCode8.Text = "";


                    this.Invoke(this.fileDelegate, new object[] { this.combxFB1, this.combxWB1, this.combxCB1, "", "", "" });
                    this.Invoke(this.fileDelegate, new object[] { this.combxFB2, this.combxWB2, this.combxCB2, "", "", "" });
                    this.Invoke(this.fileDelegate, new object[] { this.combxFB3, this.combxWB3, this.combxCB3, "", "", "" });
                    this.Invoke(this.fileDelegate, new object[] { this.combxFB4, this.combxWB4, this.combxCB4, "", "", "" });
                    this.Invoke(this.fileDelegate, new object[] { this.combxFB5, this.combxWB5, this.combxCB5, "", "", "" });
                    this.Invoke(this.fileDelegate, new object[] { this.combxFB6, this.combxWB6, this.combxCB6, "", "", "" });
                    this.Invoke(this.fileDelegate, new object[] { this.combxFB7, this.combxWB7, this.combxCB7, "", "", "" });
                    this.Invoke(this.fileDelegate, new object[] { this.combxFB8, this.combxWB8, this.combxCB8, "", "", "" });

                    this.Invoke(this.showMessageDelegate, new object[] { this.lbResult1, "", Color.White});
                    this.Invoke(this.showMessageDelegate, new object[] { this.lbResult2, "", Color.White });
                    this.Invoke(this.showMessageDelegate, new object[] { this.lbResult3, "", Color.White });
                    this.Invoke(this.showMessageDelegate, new object[] { this.lbResult4, "", Color.White });
                    this.Invoke(this.showMessageDelegate, new object[] { this.lbResult5, "", Color.White });
                    this.Invoke(this.showMessageDelegate, new object[] { this.lbResult6, "", Color.White });
                    this.Invoke(this.showMessageDelegate, new object[] { this.lbResult7, "", Color.White });
                    this.Invoke(this.showMessageDelegate, new object[] { this.lbResult8, "", Color.White });

                    configer.VIN = "";
                    configer.ID = 0;

                    //设置背景色
                    //停止接收线程
                    if (this.threadReceive != null && this.threadReceive.IsAlive)
                    {
                        this.threadReceive.Abort();
                        this.threadReceive = null;
                    }
                }
            }
            catch (Exception ex)
            {
                //logger.Error(ex.Message + "***" + ex.StackTrace);
                Log.writeTxt(ex.Message + "***" + ex.StackTrace, filePath);
            }
        }
        /// <summary>
        /// 历史查询按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHistory_Click(object sender, EventArgs e)
        {
            FrmHistory frmHistory = new FrmHistory(localConnectionString);
            frmHistory.Show();
        }
        /// <summary>
        /// 日志查询按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLog_Click(object sender, EventArgs e)
        {
            FrmLog frmLog = new FrmLog();
            frmLog.Show();
        }
        /// <summary>
        /// 数据导出按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            FrmExport frmExport = new FrmExport(localConnectionString);
            frmExport.Show();
        }
        /// <summary>
        /// 打印按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            printResult = new Form1("1110003ARD0300", "1110003ARD0300S", "VC1-UP008.0", "1110003ARD0300S.G", "1110003ARD0300H.0", DateTime.Now.ToString("d").Replace("-", "/"), "+AA01SE1024K4100257", "2", "10467","S1");
            //printResult.ShowDialog();
            printResult.Print();
            
            //PrintResult("1110003ARD0300", "1110003ARD0300S", "VC1-UP008.0", "1110003ARD0300S.G", "1110003ARD0300H.0", DateTime.Now.ToString("d").Replace("-", "/"), "+AA01SE1024K4100256", "1", "10467");
        }

        /// <summary>
        /// VCI复位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVCIReset_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("该操作会重置VCI，请确认未进行刷写操作", "VCI复位", messButton);
                if (dr == DialogResult.OK)
                {
                    //重置CAN卡
                    //VCI_ResetCAN(configer.DevType, configer.DevInd, 0);
                    //关闭CAN卡
                    //CloseDevice();
                    m_bOpen = 0;
                    VCI_CloseDevice(configer.DevType, configer.DevInd);
                }
            }
            catch (Exception ex)
            {
                //logger.Error(ex.Message + "***" + ex.StackTrace);
                Log.writeTxt(ex.Message + "***" + ex.StackTrace, filePath);
            }
        }

        #endregion

        #region 扫描枪相关事件
        /// <summary>
        /// 初始化串口
        /// </summary>
        /// <param name="port">串口号</param>
        /// <param name="serialPortSetting">串口设置</param>
        /// <returns>串口对象</returns>
        private SerialPort InitSerialPort(int port, string serialPortSetting)
        {
            try
            {
                SerialPort serialPort = new SerialPort();

                #region 串口号

                serialPort.PortName = "COM" + port;

                #endregion

                #region 波特率

                string[] portSettings = serialPortSetting.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                //波特率
                serialPort.BaudRate = int.Parse(portSettings[0]);

                #endregion

                #region parity

                //parity
                switch (portSettings[1].ToLower())
                {
                    case "n":
                        serialPort.Parity = Parity.None;
                        break;
                    case "o":
                        serialPort.Parity = Parity.Odd;
                        break;
                    case "e":
                        serialPort.Parity = Parity.Even;
                        break;
                    case "m":
                        serialPort.Parity = Parity.Mark;
                        break;
                    case "s":
                        serialPort.Parity = Parity.Space;
                        break;
                    default:
                        break;
                }

                #endregion

                #region databits

                //dataBits
                serialPort.DataBits = int.Parse(portSettings[2]);

                #endregion

                #region stopbits

                //stopbits
                switch (portSettings[3].ToLower())
                {
                    case "0":
                        serialPort.StopBits = StopBits.None;
                        break;
                    case "1":
                        serialPort.StopBits = StopBits.One;
                        break;
                    case "2":
                        serialPort.StopBits = StopBits.Two;
                        break;
                    case "3":
                        serialPort.StopBits = StopBits.OnePointFive;
                        break;
                    default:
                        break;
                }

                #endregion

                return serialPort;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 扫描枪串口数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       async void serialPortScanGunCom_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string elementCode = string.Empty;
                Thread.Sleep(100);
                int byteCount = serialPortScanGunCom.BytesToRead;
                byte[] buffer = new byte[byteCount];
                serialPortScanGunCom.Read(buffer, 0, byteCount);

                if (this.btnSelect.Text == "手动模式")
                {
                    string info = Encoding.Default.GetString(buffer).ToString().Replace("\r\n","").Replace("\r\n","");
                    #region  扫描设备号事件

                    //扫描1号设备事件
                    if (info == "R0000000000000001")
                    {
                        this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage1, "请继续扫描VIN码!", Color.Green });
                        //将当前设备号赋值给num
                        num = info;
                        return;
                    }
                    //扫描2号设备事件
                    if (info == "R0000000000000002")
                    {
                        this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage2, "请继续扫描VIN码!", Color.Green });
                       
                        num = info;
                        return;
                    }
                    //扫描3号设备事件
                    if (info == "R0000000000000003")
                    {
                        this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage3, "请继续扫描VIN码!", Color.Green });
                        
                        num = info;
                        return;
                    }
                    //扫描4号设备事件
                    if (info == "R0000000000000004")
                    {
                        this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage4, "请继续扫描VIN码!", Color.Green });
                        
                        num = info;
                        return;
                    }
                    //扫描5号设备事件
                    if (info == "R0000000000000005")
                    {
                        this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage5, "请继续扫描VIN码!", Color.Green });
                       
                        num = info;
                        return;
                    }
                    //扫描6号设备事件
                    if (info == "R0000000000000006")
                    {
                        this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage6, "请继续扫描VIN码!", Color.Green });
                        
                        num = info;
                        return;
                    }
                    //扫描7号设备事件
                    if (info == "R0000000000000007")
                    {
                        this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage7, "请继续扫描VIN码!", Color.Green });
                        
                        num = info;
                        return;
                    }
                    //扫描8号设备事件
                    if (info == "R0000000000000008")
                    {
                        this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage8, "请继续扫描VIN码!", Color.Green });
                        
                        num = info;
                        return;
                    }

                    vin = info;

                    #region 扫描VIN码事件
                    if (num == "R0000000000000001")
                    {
                        this.Invoke(this.showDelegate, new object[] { this.tbVIN1, vin });
                        this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage1, "扫描VIN码成功，请继续扫描VCU上追溯码!", Color.Green });
                        num = "1";
                        return;
                    }
                    else if (num == "R0000000000000002")
                    {
                        this.Invoke(this.showDelegate, new object[] { this.tbVIN2, vin });
                        this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage2, "扫描VIN码成功，请继续扫描VCU上追溯码!", Color.Green });
                        num = "2";
                        return;
                    }
                    else if (num == "R0000000000000003")
                    {
                        this.Invoke(this.showDelegate, new object[] { this.tbVIN3, vin });
                        this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage3, "扫描VIN码成功，请继续扫描VCU上追溯码!", Color.Green });
                        num = "3";
                        return;
                    }
                    else if (num == "R0000000000000004")
                    {
                        this.Invoke(this.showDelegate, new object[] { this.tbVIN4, vin });
                        this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage4, "扫描VIN码成功，请继续扫描VCU上追溯码!", Color.Green });
                        num = "4";
                        return;
                    }
                    else if (num == "R0000000000000005")
                    {
                        this.Invoke(this.showDelegate, new object[] { this.tbVIN5, vin });
                        this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage5, "扫描VIN码成功，请继续扫描VCU上追溯码!", Color.Green });
                        num = "5";
                        return;
                    }
                    else if (num == "R0000000000000006")
                    {
                        this.Invoke(this.showDelegate, new object[] { this.tbVIN6, vin });
                        this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage6, "扫描VIN码成功，请继续扫描VCU上追溯码!", Color.Green });
                        num = "6";
                        return;
                    }
                    else if (num == "R0000000000000007")
                    {
                        this.Invoke(this.showDelegate, new object[] { this.tbVIN7, vin });
                        this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage7, "扫描VIN码成功，请继续扫描VCU上追溯码!", Color.Green });
                        num = "7";
                        return;
                    }
                    else if (num == "R0000000000000008")
                    {
                        this.Invoke(this.showDelegate, new object[] { this.tbVIN8, vin });
                        this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage8, "扫描VIN码成功，请继续扫描VCU上追溯码!", Color.Green });
                        num = "8";
                        return;
                    }
                    #endregion

                    elementCode = info;

                    #region 扫描VCU追溯码事件
                    if (num == "1")
                    {
                        this.Invoke(this.showDelegate, new object[] { this.tbTracCode1, elementCode });
                        this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage1, "扫描VCU追溯码成功，请选择刷写文件后点击开始刷写!", Color.Green });
                        vin = this.tbVIN1.Text;
                        this.Invoke(this.fileDelegate, new object[] { this.combxFB1, this.combxWB1, this.combxCB1, config.DriverName, config.BinName, config.CalName });
                    }
                    else if (num == "2")
                    {
                        this.Invoke(this.showDelegate, new object[] { this.tbTracCode2, elementCode });
                        this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage2, "扫描VCU追溯码成功，请选择刷写文件后点击开始刷写!", Color.Green });
                        vin = this.tbVIN2.Text;
                        this.Invoke(this.fileDelegate, new object[] { this.combxFB2, this.combxWB2, this.combxCB2, config.DriverName, config.BinName, config.CalName });
                    }
                    else if (num == "3")
                    {
                        this.Invoke(this.showDelegate, new object[] { this.tbTracCode3, elementCode });
                        this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage3, "扫描VCU追溯码成功，请选择刷写文件后点击开始刷写!", Color.Green });
                        vin = this.tbVIN3.Text;
                        this.Invoke(this.fileDelegate, new object[] { this.combxFB3, this.combxWB3, this.combxCB3, config.DriverName, config.BinName, config.CalName });
                    }
                    else if (num == "4")
                    {
                        this.Invoke(this.showDelegate, new object[] { this.tbTracCode4, elementCode });
                        this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage4, "扫描VCU追溯码成功，请选择刷写文件后点击开始刷写!", Color.Green });
                        vin = this.tbVIN4.Text;
                        this.Invoke(this.fileDelegate, new object[] { this.combxFB4, this.combxWB4, this.combxCB4, config.DriverName, config.BinName, config.CalName });
                    }
                    else if (num == "5")
                    {
                        this.Invoke(this.showDelegate, new object[] { this.tbTracCode5, elementCode });
                        this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage5, "扫描VCU追溯码成功，请选择刷写文件后点击开始刷写!", Color.Green });
                        vin = this.tbVIN5.Text;
                        this.Invoke(this.fileDelegate, new object[] { this.combxFB5, this.combxWB5, this.combxCB5, config.DriverName, config.BinName, config.CalName });
                    }
                    else if (num == "6")
                    {
                        this.Invoke(this.showDelegate, new object[] { this.tbTracCode6, elementCode });
                        this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage6, "扫描VCU追溯码成功，请选择刷写文件后点击开始刷写!", Color.Green });
                        vin = this.tbVIN6.Text;
                        this.Invoke(this.fileDelegate, new object[] { this.combxFB6, this.combxWB6, this.combxCB6, config.DriverName, config.BinName, config.CalName });
                    }
                    else if (num == "7")
                    {
                        this.Invoke(this.showDelegate, new object[] { this.tbTracCode7, elementCode });
                        this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage7, "扫描VCU追溯码成功，请选择刷写文件后点击开始刷写!", Color.Green });
                        vin = this.tbVIN7.Text;
                        this.Invoke(this.fileDelegate, new object[] { this.combxFB7, this.combxWB7, this.combxCB7, config.DriverName, config.BinName, config.CalName });
                    }
                    else if (num == "8")
                    {
                        this.Invoke(this.showDelegate, new object[] { this.tbTracCode8, elementCode });
                        this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage8, "扫描VCU追溯码成功，请选择刷写文件后点击开始刷写!", Color.Green });
                        vin = this.tbVIN8.Text;
                        this.Invoke(this.fileDelegate, new object[] { this.combxFB8, this.combxWB8, this.combxCB8, config.DriverName, config.BinName, config.CalName });
                    }
                    #endregion

                }
                else if (this.btnSelect.Text == "自动模式")
                {
                    if (this.tbVIN.Text == "")
                    {
                        //初始定位下一台要刷写的VIN
                        vin = Encoding.Default.GetString(buffer).ToString();
                        this.Invoke(this.showDelegate, new object[] { this.tbVIN, vin });
                        ////获取下一台车VIN码
                        //vin = configer.GetNextVIN(vin);
                        //if (vin != "" && vin != null)
                        //{
                        //    this.Invoke(this.showDelegate, new object[] { this.tbVIN, vin});
                        //}
                        //else
                        //{
                        //    MessageBox.Show("不存在当前VIN或不存在下一台车，请核查!");
                        //}
                    }
                    else
                    {
                        string info = Encoding.Default.GetString(buffer).ToString().Replace("\r\n","");

                        if (info.Contains("@"))
                        {
                            MessageBox.Show("扫码异常请重新扫此条码!");
                            return;
                        }
                        vin = this.tbVIN.Text;

                        #region  扫描设备号事件
 
                        //扫描1号设备事件
                        if (info == "R0000000000000001")
                        {
                            this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage1, "请继续扫描VCU上追溯码!", Color.Green });
                            //显示当前VIN
                            this.Invoke(this.showDelegate, new object[] { this.tbVIN1, vin});
                            //重置下一台车VIN
                            //string nextVIN = configer.GetNextVIN(vin);
                            string nextVIN =await SqlComm.GetNextVIN(vin);
                            if (nextVIN != "" && nextVIN != null)
                            {
                                this.Invoke(this.showDelegate, new object[] { this.tbVIN, nextVIN });
                            }
                            else
                            {
                                MessageBox.Show("不存在当前VIN或不存在下一台车，请核查!");
                            }
                            //将当前设备号赋值给num
                            num = info;
                            return;
                        }
                        //扫描2号设备事件
                        if (info == "R0000000000000002")
                        {
                            this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage2, "请继续扫描VCU上追溯码!", Color.Green });
                            //显示当前VIN
                            this.Invoke(this.showDelegate, new object[] { this.tbVIN2, vin });
                            //重置下一台车VIN
                            //string nextVIN = configer.GetNextVIN(vin);
                            string nextVIN =await SqlComm.GetNextVIN(vin);
                            if (nextVIN != "" && nextVIN != null)
                            {
                                this.Invoke(this.showDelegate, new object[] { this.tbVIN, nextVIN });
                            }
                            else
                            {
                                MessageBox.Show("不存在当前VIN或不存在下一台车，请核查!");
                            }
                            //将当前设备号赋值给num
                            num = info;
                            return;
                        }
                        //扫描3号设备事件
                        if (info == "R0000000000000003")
                        {
                            this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage3, "请继续扫描VCU上追溯码!", Color.Green });
                            //显示当前VIN
                            this.Invoke(this.showDelegate, new object[] { this.tbVIN3, vin });
                            //重置下一台车VIN
                            //string nextVIN = configer.GetNextVIN(vin);
                            string nextVIN =await SqlComm.GetNextVIN(vin);
                            if (nextVIN != "" && nextVIN != null)
                            {
                                this.Invoke(this.showDelegate, new object[] { this.tbVIN, nextVIN });
                            }
                            else
                            {
                                MessageBox.Show("不存在当前VIN或不存在下一台车，请核查!");
                            }
                            num = info;
                            return;
                        }
                        //扫描4号设备事件
                        if (info == "R0000000000000004")
                        {
                            this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage4, "请继续扫描VCU上追溯码!", Color.Green });
                            //显示当前VIN
                            this.Invoke(this.showDelegate, new object[] { this.tbVIN4, vin });
                            //重置下一台车VIN
                            //string nextVIN = configer.GetNextVIN(vin);
                            string nextVIN =await SqlComm.GetNextVIN(vin);
                            if (nextVIN != "" && nextVIN != null)
                            {
                                this.Invoke(this.showDelegate, new object[] { this.tbVIN, nextVIN });
                            }
                            else
                            {
                                MessageBox.Show("不存在当前VIN或不存在下一台车，请核查!");
                            }
                            num = info;
                            return;
                        }
                        //扫描5号设备事件
                        if (info == "R0000000000000005")
                        {
                            this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage5, "请继续扫描VCU上追溯码!", Color.Green });
                            //显示当前VIN
                            this.Invoke(this.showDelegate, new object[] { this.tbVIN5, vin });
                            //重置下一台车VIN
                            //string nextVIN = configer.GetNextVIN(vin);
                            string nextVIN =await SqlComm.GetNextVIN(vin);
                            if (nextVIN != "" && nextVIN != null)
                            {
                                this.Invoke(this.showDelegate, new object[] { this.tbVIN, nextVIN });
                            }
                            else
                            {
                                MessageBox.Show("不存在当前VIN或不存在下一台车，请核查!");
                            }
                            num = info;
                            return;
                        }
                        //扫描6号设备事件
                        if (info == "R0000000000000006")
                        {
                            this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage6, "请继续扫描VCU上追溯码!", Color.Green });
                            //显示当前VIN
                            this.Invoke(this.showDelegate, new object[] { this.tbVIN6, vin });
                            //重置下一台车VIN
                            //string nextVIN = configer.GetNextVIN(vin);
                            string nextVIN =await SqlComm.GetNextVIN(vin);
                            if (nextVIN != "" && nextVIN != null)
                            {
                                this.Invoke(this.showDelegate, new object[] { this.tbVIN, nextVIN });
                            }
                            else
                            {
                                MessageBox.Show("不存在当前VIN或不存在下一台车，请核查!");
                            }
                            num = info;
                            return;
                        }
                        //扫描7号设备事件
                        if (info == "R0000000000000007")
                        {
                            this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage7, "请继续扫描VCU上追溯码!", Color.Green });
                            //显示当前VIN
                            this.Invoke(this.showDelegate, new object[] { this.tbVIN7, vin });
                            //重置下一台车VIN
                            //string nextVIN = configer.GetNextVIN(vin);
                            string nextVIN =await SqlComm.GetNextVIN(vin);
                            if (nextVIN != "" && nextVIN != null)
                            {
                                this.Invoke(this.showDelegate, new object[] { this.tbVIN, nextVIN });
                            }
                            else
                            {
                                MessageBox.Show("不存在当前VIN或不存在下一台车，请核查!");
                            }
                            num = info;
                            return;
                        }
                        //扫描8号设备事件
                        if (info == "R0000000000000008")
                        {
                            this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage8, "请继续扫描VCU上追溯码!", Color.Green });
                            //显示当前VIN
                            this.Invoke(this.showDelegate, new object[] { this.tbVIN8, vin });
                            //重置下一台车VIN
                            //string nextVIN = configer.GetNextVIN(vin);
                            string nextVIN =await SqlComm.GetNextVIN(vin);
                            if (nextVIN != "" && nextVIN != null)
                            {
                                this.Invoke(this.showDelegate, new object[] { this.tbVIN, nextVIN });
                            }
                            else
                            {
                                MessageBox.Show("不存在当前VIN或不存在下一台车，请核查!");
                            }
                            num = info;
                            return;
                        }
                        #endregion

                        elementCode = info;

                        #region 扫描VCU追溯码事件
                        if (num == "R0000000000000001")
                        {
                            this.Invoke(this.showDelegate, new object[] { this.tbTracCode1, elementCode });
                            this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage1, "扫描VCU追溯码成功，请点击开始刷写!", Color.Green });

                            //获取零件号对应MTOC-刷写bin文件
                            vin = this.tbVIN1.Text;
                            //string res=configer.GetMTOC(elementCode, vin, config);
                            string res =await SqlComm.GetMTOC(elementCode, vin, config);
                            if (string.IsNullOrEmpty(res))
                            {
                                this.Invoke(this.fileDelegate, new object[] { this.combxFB1, this.combxWB1, this.combxCB1, config.DriverName, config.BinName, config.CalName });
                            }
                            else
                            {
                                MessageBox.Show(res+",请选择刷写的文件!");
                            }
                        }
                        else if (num == "R0000000000000002")
                        {
                            this.Invoke(this.showDelegate, new object[] { this.tbTracCode2, elementCode });
                            this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage2, "扫描VCU追溯码成功，请点击开始刷写!", Color.Green });
                            //获取零件号对应MTOC-刷写bin文件
                            vin = this.tbVIN2.Text;
                            //string res=configer.GetMTOC(elementCode, vin, config);
                            string res =await SqlComm.GetMTOC(elementCode, vin, config);
                            if (string.IsNullOrEmpty(res))
                            {
                                this.Invoke(this.fileDelegate, new object[] { this.combxFB2, this.combxWB2, this.combxCB2, config.DriverName, config.BinName, config.CalName });
                            }
                            else
                            {
                                MessageBox.Show(res + ",请选择刷写的文件!");
                            }
                        }
                        else if (num == "R0000000000000003")
                        {
                            this.Invoke(this.showDelegate, new object[] { this.tbTracCode3, elementCode });
                            this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage3, "扫描VCU追溯码成功，请点击开始刷写!", Color.Green });
                            //获取零件号对应MTOC-刷写bin文件
                            vin = this.tbVIN3.Text;
                            //string res=configer.GetMTOC(elementCode, vin, config);
                            string res =await SqlComm.GetMTOC(elementCode, vin, config);
                            if (string.IsNullOrEmpty(res))
                            {
                            
                                this.Invoke(this.fileDelegate, new object[] { this.combxFB3, this.combxWB3, this.combxCB3, config.DriverName, config.BinName, config.CalName });
                            }
                            else
                            {
                                MessageBox.Show(res + ",请选择刷写的文件!");
                            }
                        }
                        else if (num == "R0000000000000004")
                        {
                            this.Invoke(this.showDelegate, new object[] { this.tbTracCode4, elementCode });
                            this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage4, "扫描VCU追溯码成功，请点击开始刷写!", Color.Green });
                            //获取零件号对应MTOC-刷写bin文件
                            vin = this.tbVIN4.Text;
                            //string res = configer.GetMTOC(elementCode, vin, config);
                            string res =await SqlComm.GetMTOC(elementCode, vin, config);
                            if (string.IsNullOrEmpty(res))
                            {
                                this.Invoke(this.fileDelegate, new object[] { this.combxFB4, this.combxWB4, this.combxCB4, config.DriverName, config.BinName, config.CalName });
                            }
                            else
                            {
                                MessageBox.Show(res + ",请选择刷写的文件!");
                            }
                        }
                        else if (num == "R0000000000000005")
                        {
                            this.Invoke(this.showDelegate, new object[] { this.tbTracCode5, elementCode });
                            this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage5, "扫描VCU追溯码成功，请点击开始刷写!", Color.Green });
                            //获取零件号对应MTOC-刷写bin文件
                            vin = this.tbVIN5.Text;
                            //string res = configer.GetMTOC(elementCode, vin, config);
                            string res =await SqlComm.GetMTOC(elementCode, vin, config);
                            if (string.IsNullOrEmpty(res))
                            {
                                this.Invoke(this.fileDelegate, new object[] { this.combxFB5, this.combxWB5, this.combxCB5, config.DriverName, config.BinName, config.CalName });
                            }
                            else
                            {
                                MessageBox.Show(res + ",请选择刷写的文件!");
                            }
                        }
                        else if (num == "R0000000000000006")
                        {
                            this.Invoke(this.showDelegate, new object[] { this.tbTracCode6, elementCode });
                            this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage6, "扫描VCU追溯码成功，请点击开始刷写!", Color.Green });
                            //获取零件号对应MTOC-刷写bin文件
                            vin = this.tbVIN6.Text;
                            //string res = configer.GetMTOC(elementCode, vin, config);
                            string res =await SqlComm.GetMTOC(elementCode, vin, config);
                            if (string.IsNullOrEmpty(res))
                            {
                                this.Invoke(this.fileDelegate, new object[] { this.combxFB6, this.combxWB6, this.combxCB6, config.DriverName, config.BinName, config.CalName });
                            }
                            else
                            {
                                MessageBox.Show(res + ",请选择刷写的文件!");
                            }
                        }
                        else if (num == "R0000000000000007")
                        {
                            this.Invoke(this.showDelegate, new object[] { this.tbTracCode7, elementCode });
                            this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage7, "扫描VCU追溯码成功，请点击开始刷写!", Color.Green });
                            //获取零件号对应MTOC-刷写bin文件
                            vin = this.tbVIN7.Text;
                            //string res = configer.GetMTOC(elementCode, vin, config);
                            string res =await SqlComm.GetMTOC(elementCode, vin, config);
                            if (string.IsNullOrEmpty(res))
                            {
                                this.Invoke(this.fileDelegate, new object[] { this.combxFB7, this.combxWB7, this.combxCB7, config.DriverName, config.BinName, config.CalName });
                            }
                            else
                            {
                                MessageBox.Show(res + ",请选择刷写的文件!");
                            }
                        }
                        else if (num == "R0000000000000008")
                        {
                            this.Invoke(this.showDelegate, new object[] { this.tbTracCode8, elementCode });
                            this.Invoke(this.showMessageDelegate, new object[] { this.lbMessage8, "扫描VCU追溯码成功，请点击开始刷写!", Color.Green });
                            //获取零件号对应MTOC-刷写bin文件
                            vin = this.tbVIN8.Text;
                            //string res = configer.GetMTOC(elementCode, vin, config);
                            string res =await SqlComm.GetMTOC(elementCode, vin, config);
                            if (string.IsNullOrEmpty(res))
                            {
                                this.Invoke(this.fileDelegate, new object[] { this.combxFB8, this.combxWB8, this.combxCB8, config.DriverName, config.BinName, config.CalName });
                            }
                            else
                            {
                                MessageBox.Show(res + ",请选择刷写的文件!");
                            }
                        }
                        #endregion
  
                    }
                }
            }
            catch (Exception ex)
            {
                Log.writeTxt(ex.Message + "***" + ex.StackTrace, filePath);
            }
        }
        
        /// <summary>
        /// 模式选择按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (this.btnSelect.Text == "手动模式")
            {
                this.btnSelect.Text = "自动模式";
            }

            else if (this.btnSelect.Text == "自动模式")
            {
                this.btnSelect.Text = "手动模式";
            }
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="partNum">设备号</param>
        /// <param name="software">软件号</param>
        /// <param name="hardware">硬件号</param>
        /// <param name="sw">SW</param>
        /// <param name="hw">HW</param>
        /// <param name="time">时间</param>
        /// <param name="tracyCode">追溯码</param>
        /// <param name="num">打印端口</param>
        /// <param name="vin">VIN</param>
        private void PrintResult(string partNum,string software,string hardware,string sw,string hw,string time,string tracyCode,string num,string vin)
        {
            try
            {
                CreatCode(tracyCode);

                DataTable dt = new DataTable();
                //实例化8个列
                DataColumn dc1 = new DataColumn("vin", System.Type.GetType("System.String"));

                DataColumn dc2 = new DataColumn("hardware", System.Type.GetType("System.String"));

                DataColumn dc3 = new DataColumn("software", System.Type.GetType("System.String"));

                DataColumn dc4 = new DataColumn("time", System.Type.GetType("System.String"));

                DataColumn dc5 = new DataColumn("num", System.Type.GetType("System.String"));

                DataColumn dc6 = new DataColumn("partNum", System.Type.GetType("System.String"));

                DataColumn dc7 = new DataColumn("sw", System.Type.GetType("System.String"));

                DataColumn dc8 = new DataColumn("hw", System.Type.GetType("System.String"));

                DataColumn dc9 = new DataColumn("tracyCode", System.Type.GetType("System.String"));

                dt.Columns.Add(dc1);

                dt.Columns.Add(dc2);

                dt.Columns.Add(dc3);

                dt.Columns.Add(dc4);

                dt.Columns.Add(dc5);

                dt.Columns.Add(dc6);

                dt.Columns.Add(dc7);

                dt.Columns.Add(dc8);

                dt.Columns.Add(dc9);

                DataRow row = dt.NewRow();
                
                row["hardware"] = hardware;
                row["software"] = software;
                row["time"] = time;
                row["vin"] = vin;
                row["num"] = num;
                row["tracyCode"] = tracyCode;
                row["partNum"] = partNum;
                row["hw"] = hw;
                row["sw"] = sw;

                dt.Rows.Add(row);

                //设置需要打印的报表的文件名称。

                report.ReportPath = Application.StartupPath + @"\Result.rdlc";

                //创建要打印的数据源


                //以图片显示
                report.EnableExternalImages = true;

                ReportParameter rp1 = new ReportParameter("txVIN", vin);
                ReportParameter rp2 = new ReportParameter("txTime", time);
                ReportParameter rp3 = new ReportParameter("txHardware", "硬件型号:"+hardware);
                ReportParameter rp4 = new ReportParameter("txSoftware", "软件版本:"+software);
                ReportParameter rp5 = new ReportParameter("txNum", num);
                ReportParameter rp6 = new ReportParameter("txTracyCode", @"file:\"+Application.StartupPath + @"\TracyCodeImage\" + tracyCode + ".jpg");
                ReportParameter rp7 = new ReportParameter("txPartNum", partNum);
                ReportParameter rp8 = new ReportParameter("txHW", "HW:"+hw);
                ReportParameter rp9 = new ReportParameter("txSW", "SW:"+sw);

                report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5,rp6,rp7,rp8,rp9 });

                ReportDataSource source = new ReportDataSource("result", dt);

                report.DataSources.Add(source);

                RdlcPrintNew rdlcprint = new RdlcPrintNew();
                rdlcprint.Run(report, "", false, "");
            }
            catch (Exception ex)
            {
                Log.writeTxt(ex.Message + "***" + ex.StackTrace, filePath);
            }
        }

        /// <summary>
        /// 生成条形码
        /// </summary>
        private void CreatCode(string text)
        {
            BarcodeWriter writer = new BarcodeWriter();
            //使用ITF 格式，不能被现在常用的支付宝、微信扫出来
            //如果想生成可识别的可以使用 CODE_128 格式
            //writer.Format = BarcodeFormat.ITF;
            writer.Format = BarcodeFormat.CODE_128;
            EncodingOptions options = new EncodingOptions()
            {
                Width = 565,
                Height = 60,
                //Margin = 10
            };
            writer.Options = options;
            Bitmap map = writer.Write(text);
            Image img = map;
            img.Save(Application.StartupPath+@"\TracyCodeImage\"+text+".jpg");
        }

        #endregion

        #endregion

        #region 未用到的方法

        ///// <summary>
        ///// 初始化串口设置 
        ///// </summary>
        //SerialPort EAPort = new SerialPort(comString, 9600, Parity.None, 8, StopBits.One);
        //public delegate void Displaydelegate(byte[] InputBuf);
        //public Displaydelegate disp_delegate;
        //public StringBuilder code = new StringBuilder();
        //public EventHandler button_Click { get; set; }


        ///// <summary>
        ///// 关闭设备
        ///// </summary>
        //unsafe private void CloseDevice()
        //{
        //    try
        //    {
        //        if (m_bOpen == 1)
        //        {
        //            //关闭设备
        //            VCI_CloseDevice(configer.DevType, configer.DevInd);
        //            m_bOpen = 0;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error(ex.Message + "***" + ex.StackTrace);
        //    }
        //}
        ///// <summary>
        ///// 通过seed计算得到key
        ///// </summary>
        ///// <param name="hbSeed"></param>
        ///// <param name="lbSeed"></param>
        ///// <returns></returns>
        //private byte[] SecurityAccess(string hbSeed, string lbSeed)
        //{
        //    ////切分定义帧
        //    //string[] sendCmds = strSeed.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        //    ////转换成16进制
        //    //string[] seed = new string[4];
        //    //for (int i = 3; i < 7; i++)
        //    //{
        //    //    //vco.Data[i] = byte.Parse(Convert.ToInt64((sendCmds[i]) + "", 16) + "");
        //    //    //bf[i] = vco.Data[i];
        //    //    seed[i - 3] = Convert.ToString(Convert.ToInt64((sendCmds[i]) + "", 16), 2).PadLeft(8, '0');
        //    //}

        //    string HB1;
        //    string LB1;
        //    string HB2;
        //    string LB2;

        //    HB1 = Convert.ToString(Convert.ToInt64(hbSeed, 16), 2).PadLeft(8, '0').Substring(3, 5) + Convert.ToString(Convert.ToInt64(hbSeed, 16), 2).PadLeft(8, '0').Substring(0, 3);
        //    LB1 = Convert.ToString(Convert.ToInt64(lbSeed, 16), 2).PadLeft(8, '0').Substring(3, 5) + Convert.ToString(Convert.ToInt64(lbSeed, 16), 2).PadLeft(8, '0').Substring(0, 3);
        //    char[] HBs = new char[8];
        //    char[] LBs = new char[8];
        //    int c = 0;
        //    foreach (char item in HB1)
        //    {
        //        HBs[c] = item;
        //        c++;
        //    }

        //    c = 0;
        //    foreach (char item in LB1)
        //    {
        //        LBs[c] = item;
        //        c++;
        //    }

        //    HB2 = HBs[1].ToString() + HBs[0].ToString() + HBs[3].ToString() + HBs[2].ToString() + HBs[5].ToString() + HBs[4].ToString() + HBs[7].ToString() + HBs[6].ToString();
        //    LB2 = LBs[1].ToString() + LBs[0].ToString() + LBs[3].ToString() + LBs[2].ToString() + LBs[5].ToString() + LBs[4].ToString() + LBs[7].ToString() + LBs[6].ToString();
        //    HB1 = HB2.Substring(5, 3) + LB2.Substring(0, 5);
        //    LB1 = LB2.Substring(5, 3) + HB2.Substring(0, 5);

        //    char[] Coef1 = new char[8] { '0', '0', '0', '1', '0', '1', '0', '0' };
        //    char[] Coef2 = new char[8] { '0', '0', '1', '0', '0', '0', '0', '0' };

        //    c = 0;
        //    foreach (char item in HB1)
        //    {
        //        HBs[c] = (char)(item ^ Coef1[c]);
        //        HBs[c] = (char)(HBs[c] ^ '1');
        //        c++;
        //    }
        //    c = 0;
        //    foreach (char item in LB1)
        //    {
        //        LBs[c] = (char)(item ^ Coef2[c]);
        //        LBs[c] = (char)(LBs[c] ^ '1');
        //        c++;
        //    }

        //    HB1 = HBs[0].ToString() + HBs[1].ToString() + HBs[2].ToString() + HBs[3].ToString() + HBs[4].ToString() + HBs[5].ToString() + HBs[6].ToString() + HBs[7].ToString();
        //    LB1 = LBs[0].ToString() + LBs[1].ToString() + LBs[2].ToString() + LBs[3].ToString() + LBs[4].ToString() + LBs[5].ToString() + LBs[6].ToString() + LBs[7].ToString();

        //    byte[] bs = new byte[2];
        //    bs[0] = byte.Parse(Convert.ToInt32(HB1, 2) + "");
        //    bs[1] = byte.Parse(Convert.ToInt32(LB1, 2) + "");
        //    return bs;
        //}

        //private void btnClose_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (m_bOpen == 1)
        //        {
        //            //关闭设备
        //            VCI_CloseDevice(configer.DevType, configer.DevInd);
        //            m_bOpen = 0;
        //        }

        //        //停止接收线程
        //        if (this.threadReceive != null && this.threadReceive.IsAlive)
        //        {
        //            this.threadReceive.Abort();
        //            this.threadReceive = null;
        //        }
        //        //清空接收队列
        //        if (queReceiveMsg != null)
        //        {
        //            queReceiveMsg.Clear();
        //            queReceiveMsg = new Queue();
        //        }
        //        this.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error(ex.Message + "***" + ex.StackTrace);
        //    }
        //}

        //private void pictureBox1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (m_bOpen == 1)
        //        {
        //            //关闭设备
        //            VCI_CloseDevice(configer.DevType, configer.DevInd);
        //            m_bOpen = 0;
        //        }

        //        //停止接收线程
        //        if (this.threadReceive != null && this.threadReceive.IsAlive)
        //        {
        //            this.threadReceive.Abort();
        //            this.threadReceive = null;
        //        }

        //        //清空接收队列
        //        if (queReceiveMsg != null)
        //        {
        //            queReceiveMsg.Clear();
        //            queReceiveMsg = new Queue();
        //        }
        //        //this.Close();
        //        Application.Exit();
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error(ex.Message + "***" + ex.StackTrace);
        //    }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="param"></param>
        //public void UpdateForm(Parameter param)
        //{
        //    if (param.Num == 1)
        //    {
        //        DSGStartWrite(0, param.Driver, param.Write, param.Cal, this.lbMessage1, this.progressBar1, this.btStart1);
        //    }
        //    if (param.Num == 2)
        //    {
        //        DSGStartWrite(1, param.Driver, param.Write, param.Cal, this.lbMessage2, this.progressBar2, this.btStart2);
        //    }
        //    if (param.Num == 3)
        //    {
        //        DSGStartWrite(2, param.Driver, param.Write, param.Cal, this.lbMessage3, this.progressBar3, this.btStart3);
        //    }
        //    if (param.Num == 4)
        //    {
        //        DSGStartWrite(3, param.Driver, param.Write, param.Cal, this.lbMessage4, this.progressBar4, this.btStart4);
        //    }
        //    if (param.Num == 5)
        //    {
        //        DSGStartWrite(4, param.Driver, param.Write, param.Cal, this.lbMessage5, this.progressBar5, this.btStart5);
        //    }
        //    if (param.Num == 6)
        //    {
        //        DSGStartWrite(5, param.Driver, param.Write, param.Cal, this.lbMessage6, this.progressBar6, this.btStart6);
        //    }
        //    if (param.Num == 7)
        //    {
        //        DSGStartWrite(6, param.Driver, param.Write, param.Cal, this.lbMessage7, this.progressBar7, this.btStart7);
        //    }
        //    if (param.Num == 8)
        //    {
        //        DSGStartWrite(7, param.Driver, param.Write, param.Cal, this.lbMessage8, this.progressBar8, this.btStart8);
        //    }
        //}

        #endregion
    }
}
        

