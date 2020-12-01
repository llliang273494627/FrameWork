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
using GQXJ_TCU_Writer_Model;
using Common.Logging;
using GQXJ_TCU_Writer_BLL;
using System.IO.Ports;
using System.IO;
using System.Drawing.Printing;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.Drawing.Imaging;
using Automation.BDaq;
using ModBusHelp;

namespace GQXJ_TCU_Writer
{
    public partial class FormMain : Form
    {
        #region 委托
        public delegate void ShowMessageDelegate(string txt, string place);
        public delegate void ChangeColorDelegate(Color color);
        public delegate void ShowPicDelegate(PictureBox picBox, string path);
        public delegate void GetPrintDelegate(PrintInfo info);
        public delegate void SetprogressBarDelegate(int value,int max);
        #endregion

        #region 私有变量

        /// <summary>
        /// 接收返回消息的队列
        /// </summary>
        private static Queue queReceiveMsg = new Queue();

        /// <summary>
        /// 接收返回消息的队列
        /// </summary>
        private static List<string> ReceiveList = new List<string>();
        /// <summary>
        /// 配置对象
        /// </summary>
        private static Configer configer = new Configer();
        /// <summary>
        /// 本地连接字符串
        /// </summary>
        private static readonly string localConnectionString = ConfigurationManager.ConnectionStrings["localCnnStr"] + "";
        //扫描枪串口号
        private static readonly string comString = ConfigurationManager.AppSettings["COM"];
        /// <summary>
        /// 日志对象
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(FormMain));
        /// <summary>
        /// 多次执行的退出标识，类似互斥锁
        /// </summary>
        private static bool canUse = true;
        /// <summary>
        /// 锁住执行方法的对象
        /// </summary>
        private static object olock = new object();
        /// <summary>
        /// 显示消息的委托
        /// </summary>
        private ShowMessageDelegate showMessageDelegate = null;
        /// <summary>
        /// 处理图片的委托
        /// </summary>
        private ShowPicDelegate showPicDelegate = null;
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
        /// TCU信息数据
        /// </summary>
        private TCUPath tcuPath = new TCUPath();
        //crc校验
        CRC32Cls crc = new CRC32Cls();
        //bin文件CRC校验码
        string crCstr = "00000000";
        //direr文件CRC校验码
        string direrStr = "00000000";
        //cal文件CRC校验码
        string calcrcStr = "00000000";
        //删除多少天之前的数据
        int DeleteLogDay;
        //日志文件，每刷一次生成一个日志文件
        string filePath = "";
        //控制灯柱
        ModBusWrapper Wrapper = ModBusWrapper.CreateInstance(Protocol.TCPIP);
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

        //[DllImport("controlcan.dll")]
        //static extern UInt32 VCI_OpenDevice(UInt32 DeviceType, UInt32 DeviceInd, UInt32 Reserved);
        //[DllImport("controlcan.dll")]
        //static extern UInt32 VCI_CloseDevice(UInt32 DeviceType, UInt32 DeviceInd);
        //[DllImport("controlcan.dll")]
        //static extern UInt32 VCI_InitCAN(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_INIT_CONFIG pInitConfig);
        //[DllImport("controlcan.dll")]
        //static extern UInt32 VCI_ReadBoardInfo(UInt32 DeviceType, UInt32 DeviceInd, ref VCI_BOARD_INFO pInfo);
        //[DllImport("controlcan.dll")]
        //static extern UInt32 VCI_ReadErrInfo(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_ERR_INFO pErrInfo);
        //[DllImport("controlcan.dll")]
        //static extern UInt32 VCI_ReadCANStatus(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_CAN_STATUS pCANStatus);
        //[DllImport("controlcan.dll")]
        //static extern UInt32 VCI_GetReference(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, UInt32 RefType, ref byte pData);
        //[DllImport("controlcan.dll")]
        ////static extern UInt32 VCI_SetReference(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, UInt32 RefType, ref byte pData);
        //unsafe static extern UInt32 VCI_SetReference(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, UInt32 RefType, byte* pData);
        //[DllImport("controlcan.dll")]
        //static extern UInt32 VCI_GetReceiveNum(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd);
        //[DllImport("controlcan.dll")]
        //static extern UInt32 VCI_ClearBuffer(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd);
        //[DllImport("controlcan.dll")]
        //static extern UInt32 VCI_StartCAN(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd);
        //[DllImport("controlcan.dll")]
        //static extern UInt32 VCI_ResetCAN(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd);
        //[DllImport("controlcan.dll")]
        //static extern UInt32 VCI_Transmit(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_CAN_OBJ pSend, UInt32 Len);
        ////[DllImport("controlcan.dll")]
        ////static extern UInt32 VCI_Receive(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, ref VCI_CAN_OBJ pReceive, UInt32 Len, Int32 WaitTime);
        //[DllImport("controlcan.dll", CharSet = CharSet.Ansi)]
        //static extern UInt32 VCI_Receive(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, IntPtr pReceive, UInt32 Len, Int32 WaitTime);

        #endregion

        SerialPort EAPort = new SerialPort(comString, 9600, Parity.None, 8, StopBits.One);      //初始化串口设置  
        public delegate void Displaydelegate(byte[] InputBuf);
        public Displaydelegate disp_delegate;  

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //初始化系统
            InitSystem();
        }

        /// <summary>
        /// 初始化系统
        /// </summary>
        private void InitSystem()
        {
            try
            {
                //设置窗体大小
                //this.Size = new System.Drawing.Size(1024, 768);
                //获得焦点
                this.txtInputTCU.Focus();
                //初始化显示数据的委托对象
                this.showMessageDelegate = new ShowMessageDelegate(this.ShowMessage);
                //初始化改变颜色的委托对象
                this.changeColorDelegate = new ChangeColorDelegate(this.ChangeColor);
                //初始化显示数据的委托对象
                this.showPicDelegate = new ShowPicDelegate(this.PicMessage);
                //打印委托
                this.printDelegate = new GetPrintDelegate(this.GetPrint);
                //进度条委托
                this.progressBarDelegate = new SetprogressBarDelegate(this.SetBar);

                //初始化配置对象
                configer = new Configer(localConnectionString);
                //读取MES连接字符串
                configer.MESCnnStr = configer.GetConfigValue("T_RunParam", "DB", "MESCnnStr");
                //MES的IP
                //configer.MES_IP = configer.GetConfigValue("T_RunParam", "MES", "MESIP");
                //设备类型
                configer.DevType = UInt32.Parse(configer.GetConfigValue("T_RunParam", "CAN", "DevType"));
                //设备索引号
                configer.DevInd = UInt32.Parse(configer.GetConfigValue("T_RunParam", "CAN", "DevInd"));
                //写入失败后尝试次数
                configer.WriteTimes = int.Parse(configer.GetConfigValue("T_RunParam", "CAN", "WriteTimes"));
                //状态检查周期
                //configer.CheckStateTime = int.Parse(configer.GetConfigValue("T_RunParam", "State", "CheckStateTime"));
                //线程停止时间
                configer.ThreadSleep = int.Parse(configer.GetConfigValue("T_RunParam", "Thread", "Sleep"));
                //启动状态检查的Timer
                //if (configer.CheckStateTime > 0)
                //{
                    //this.timCheckNetStart.Interval = configer.CheckStateTime;
                    //this.timCheckNetStart.Enabled = true;
                //}
                //等待指令
                configer.WaitCode = configer.GetConfigValue("T_RunParam", "Code", "WaitCode");
                
                //删除多少天之前的日志文件
                this.DeleteLogDay = int.Parse(configer.GetConfigValue("T_RunParam", "Del", "DeleteLog"));
                if (DeleteLogDay > 0)
                {
                    Log.DeleteLog(DeleteLogDay);
                }
                //定时上传检测信息
                //timeUpload = new System.Threading.Timer(new System.Threading.TimerCallback(configer.tmrUpload_Timer), this, 0, configer.TimeUpload * 1000);

                //设置串口
                disp_delegate = new Displaydelegate(DispUI);
                EAPort.DataReceived += new SerialDataReceivedEventHandler(Comm_DataReceived);
                EAPort.Open();


                //Wrapper.Connect("192.168.1.104", 502, 1000);
                //Wrapper.SendOnly(new byte[] { 255, 0 }, 18);

                //配置初始化成功
                //AddMessage("系统启动成功！");

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
        }

        public void DispUI(byte[] InputBuf)
        { 
            try
            {
                ASCIIEncoding encoding = new ASCIIEncoding();
                string tmp = encoding.GetString(InputBuf);

                //为空退出
                if (tmp == "") return;
                if (this.tcuPath.CarType == null)
                {
                    //扫描车型
                    GetScanData(tmp, 1);
                }
                else
                {
                    //扫描变速箱
                    tmp = tmp.Substring(0, 5);
                    GetScanData(tmp, 2);
                }

                this.txtInputTCU.Text = tmp;
                this.txtInputTCU.Focus();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
           
        }

        void Comm_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            Byte[] InputBuf = new Byte[128];

            try
            {
                System.Threading.Thread.Sleep(1000);
                EAPort.Read(InputBuf, 0, EAPort.BytesToRead);                                //读取缓冲区的数据直到“}”即0x7D为结束符  
                //InputBuf = UnicodeEncoding.Default.GetBytes(strRD);                   //将得到的数据转换成byte的格式               
                this.Invoke(disp_delegate, InputBuf);

            }
            catch (TimeoutException ex)         //超时处理  
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 从键盘录入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInputTCU_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                //取得条码
                string tmp = this.txtInputTCU.Text;
                //为空退出
                if (tmp == "") return;
                if (this.tcuPath.CarType == null)
                {
                    //扫描车型
                    GetScanData(tmp, 1);
                }
                else
                {
                    //扫描变速箱
                    GetScanData(tmp, 2);
                }

                //清空输入框的数据                             
                tmp = string.Empty;
                this.txtInputTCU.Text = tmp;
                this.txtInputTCU.Focus();
            }
        }

        /// <summary>
        /// 取得数据
        /// </summary>
        private void GetScanData(string TestCode, int num)
        {
            #region 格式化

            //去掉空格
            TestCode = TestCode.Trim();
            //转大写
            TestCode = TestCode.ToUpper();
            //去掉回车
            TestCode = TestCode.Replace("\r", "");
            //去掉换行
            TestCode = TestCode.Replace("\n", "");
            //去掉,
            TestCode = TestCode.Replace(",", "");
            //去掉-
            //TestCode = TestCode.Replace("-", "");
            TestCode = TestCode.Replace("\0", "");
            #endregion

            #region 判断条码
            
            //清空ListMsg
            this.ListMsg.Items.Clear();

            if (num == 1)
            {
                this.tcuPath.CarType = TestCode;
                int res = configer.GetStandard(this.tcuPath);

                if (res == 0)
                {
                    MessageBox.Show("该车型不存在，请添加", "提示");
                    tcuPath = new TCUPath();
                    return;
                }
                else if (res == -1)
                {
                    MessageBox.Show("数据库连接失败", "提示");
                    return;
                }
               
                lblVIN.Text = "请再扫描特制码";
                this.txtInputTCU.Text = TestCode;
            }
            else if (num == 2)
            {
                this.txtInputTzm.Text = TestCode;

                tcuPath.ConditionCode = TestCode;

                int res = configer.GetStandard(this.tcuPath);
                //tcuPath.ConditionCode == TestCode
                if (res == 1)
                {
                    this.Invoke(this.changeColorDelegate, new object[] { Color.Honeydew });
                    //开始写入
                    //把车辆类型码显示到中央
                    this.lblVIN.Text = this.tcuPath.CarType + "正在刷写";
                    //给tcuPath赋值
                    configer.GetTCUCodeLister(this.tcuPath);
                    //判断写入的文件是否存在，不存在就停止
                    if (!File.Exists(this.tcuPath.DirerPath + this.tcuPath.DirerName))
                    {
                        this.tcuPath = new TCUPath();
                        //设置背景色
                        this.ListMsg.BackColor = Color.White;
                        lblVIN.Text = "";
                        MessageBox.Show("driver文件不存在请重新上传文件", "提示");
                        return;
                    }

                    if (!File.Exists(this.tcuPath.BinPath + this.tcuPath.BinName))
                    {
                        this.tcuPath = new TCUPath();
                        //设置背景色
                        this.ListMsg.BackColor = Color.White;
                        lblVIN.Text = "";
                        MessageBox.Show("bin文件不存在请重新上传文件", "提示");
                        return;
                    }

                    if (!File.Exists(this.tcuPath.CalPath + this.tcuPath.CalName))
                    {
                        this.tcuPath = new TCUPath();
                        //设置背景色
                        this.ListMsg.BackColor = Color.White;
                        lblVIN.Text = "";
                        MessageBox.Show("标定文件不存在请重新上传文件", "提示");
                        return;
                    }

                    this.filePath = System.Windows.Forms.Application.StartupPath + "//Logs//" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".txt";

                    //开始写入
                    Thread threadWriter = new Thread(new ThreadStart(DSGStartWrite));
                    threadWriter.IsBackground = true;
                    threadWriter.Start();

                }
                else
                {
                    //不匹配
                    MessageBox.Show("特制码不匹配");
                }
            }

            #endregion

            TestCode = string.Empty;
        }

        /// <summary>
        /// 获得车型对应的相关参数
        /// </summary>
        private void DSGStartWrite()
        {
            try
            {
                //Wrapper.SendOnly(new byte[] { 255, 0 }, 17);
                //Wrapper.SendOnly(new byte[] { 0, 0 }, 18);
                //Wrapper.SendOnly(new byte[] { 0, 0 }, 16);

                this.Invoke(this.showPicDelegate, new object[] { pictureBox8, Application.StartupPath + "\\img\\" + "process-grey_03.png" });
                this.Invoke(this.showPicDelegate, new object[] { pictureBox9, Application.StartupPath + "\\img\\" + "process-grey_05.png" });
                this.Invoke(this.showPicDelegate, new object[] { pictureBox7, Application.StartupPath + "\\img\\" + "process-grey_07.png" });
                this.Invoke(this.showPicDelegate, new object[] { pictureBox10, Application.StartupPath + "\\img\\" + "process-grey_09.png" });
                this.Invoke(this.showPicDelegate, new object[] { pictureBox11, Application.StartupPath + "\\img\\" + "process-grey_11.png" });

                Boolean result = false;
                string errorCode = string.Empty;

                byte[] DirerByte = ReadBin(this.tcuPath.DirerPath + this.tcuPath.DirerName);
                byte[] binByte = ReadBin(this.tcuPath.BinPath + this.tcuPath.BinName);
                byte[] calByte = ReadBin(this.tcuPath.CalPath + this.tcuPath.CalName);

                byte[] DirCrcByte = DirerByte.Skip(9).Take(DirerByte.Length - 1).ToArray();
                direrStr = String.Format("{0:X8}", crc.GetCRC32Str2(DirCrcByte));

                byte[] crcByte = binByte.Skip(41).Take(binByte.Length - 1).ToArray();
                crCstr = String.Format("{0:X8}", crc.GetCRC32Str2(crcByte));

                byte[] CalCrcByte = calByte.Skip(41).Take(calByte.Length - 1).ToArray();
                calcrcStr = String.Format("{0:X8}", crc.GetCRC32Str2(CalCrcByte));

                //计算得到的crc码和提供的crc码对比
                //if (direrStr != tcuPath.CRC1 || crCstr != tcuPath.CRC2)
                //{
                //    return;
                //}

                //连接设备
                ConnectDevice();
                //发送报文
                List<DefineFlower> lstDefineFlower = Send(DirerByte, binByte,calByte);

                //校验结果
                AddMessage("发送完成");
                result = CheckFlow(lstDefineFlower, 1, ref errorCode);
                this.Invoke(this.showPicDelegate, new object[] { pictureBox10, Application.StartupPath + "\\img\\" + "process_09.png" });

                //关闭设备
                //CloseDevice();
                //写入结果
                this.tcuPath.WriteInResult = result;
                //写入过程
                //this.battery.ErrorCode = errorCode;
                //记录日志
                logger.Info(errorCode);
                //界面显示刷写结束
                this.Invoke(this.showPicDelegate, new object[] { pictureBox11, Application.StartupPath + "\\img\\" + "process_11.png" });
                //打印                

                if (this.tcuPath.WriteInResult)
                {
                    this.Invoke(this.showMessageDelegate, new object[] { this.tcuPath.CarType + "刷写成功", "up" });

                    PrintInfo info = new PrintInfo();
                    info.SoftWareVersion = this.tcuPath.SoftWareVersion;
                    info.OptionCode = this.tcuPath.CarType;
                    //info.OptionCode = System.Configuration.ConfigurationSettings.AppSettings["OptionCode"];
                    info.Barcode = this.tcuPath.SoftWareCode + this.tcuPath.ConditionCode;
                    info.Number = configer.GetPrintNum().ToString();
                    //info.PartsName = System.Configuration.ConfigurationSettings.AppSettings["PartsName"];
                    info.PartsName = this.tcuPath.ConditionCode;

                    //保存到本地
                    int res = configer.SaveLocalResult(this.tcuPath);
                    if (res != 1)
                    {
                        MessageBox.Show("写入数据库失败");
                    }
                    //上传到服务器configer.MESCnnStr
                    configer.Upload_Timer();

                    this.Invoke(this.printDelegate, new object[] { info });

                    //if (PrintB)
                    //{
                    //    this.tcuPath.IsPrint = 1;
                    //}
                    //else
                    //{
                    //    this.tcuPath.IsPrint = 0;
                    //} 

                    //Wrapper.SendOnly(new byte[] { 255, 0 }, 18);
                    //Wrapper.SendOnly(new byte[] { 0, 0 }, 17);
                }
                else
                {
                    this.Invoke(this.showMessageDelegate, new object[] { this.tcuPath.CarType + "刷写失败", "up" });
                    //Wrapper.SendOnly(new byte[] { 255, 0 }, 16);
                }

                this.tcuPath = new TCUPath();

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
        }

        /// <summary>
        /// 连接CAN设备
        /// </summary>
        unsafe private void ConnectDevice()
        {
            try
            {

                #region 打开设备

                if (VCI_OpenDevice(configer.DevType, configer.DevInd, 0) == 0)
                {
                    AddMessage("打开设备失败,请检查设备类型和设备索引号是否正确!");
                    AddMessage("如果确认无误后请重启软件!");
                    return;
                }

                #endregion

                //#region 设置波特率

                //UInt32 baud;
                //int baudIndex = 0;
                //switch (this.tcuPath.Baud)
                //{
                //    case "B1000":
                //        baudIndex = 0;
                //        break;
                //    case "B800":
                //        baudIndex = 1;
                //        break;
                //    case "B500":
                //        baudIndex = 2;
                //        break;
                //    case "B250":
                //        baudIndex = 3;
                //        break;
                //    case "B125":
                //        baudIndex = 4;
                //        break;
                //    case "B100":
                //        baudIndex = 5;
                //        break;
                //    case "B50":
                //        baudIndex = 6;
                //        break;
                //    case "B20":
                //        baudIndex = 7;
                //        break;
                //    default:
                //        baudIndex = 4;
                //        break;
                //}
                ////取得波特率
                //baud = GCanBrTab[baudIndex];

                //if (VCI_SetReference(configer.DevType, configer.DevInd, this.tcuPath.CANIND, 0, (byte*)&baud) != STATUS_OK)
                //{
                //    CloseDevice();
                //    AddMessage("设置波特率错误，打开设备失败!");
                //    return;
                //}

                //#endregion

                #region 初始化CAN

                m_bOpen = 1;
                VCI_INIT_CONFIG config = new VCI_INIT_CONFIG();
                config.AccCode = 0;
                config.AccMask = 4294967295;
                config.Mode = 0;
                config.Timing0 = 0;
                config.Timing1 = 28;
                config.Filter = 1;
                VCI_InitCAN(configer.DevType, configer.DevInd, this.tcuPath.CANIND, ref config);

                #endregion

                #region 设置滤波

                //VCI_FILTER_RECORD filterRecord = new VCI_FILTER_RECORD();
                //filterRecord.ExtFrame = 0;
                //filterRecord.Start = this.tcuPath.ResponseAddress;
                //filterRecord.End = this.tcuPath.ResponseAddress;
                ////填充滤波表格
                //VCI_SetReference(configer.DevType, configer.DevInd, this.tcuPath.CANIND, 1, (byte*)&filterRecord);
                ////使滤波表格生效
                //byte tm = 0;
                //if (VCI_SetReference(configer.DevType, configer.DevInd, this.tcuPath.CANIND, 2, &tm) != STATUS_OK)
                //{
                //    CloseDevice();
                //    AddMessage("设置滤波失败");
                //    return;
                //}

                #endregion

                #region 启动CAN

                VCI_StartCAN(configer.DevType, configer.DevInd, this.tcuPath.CANIND);

                #endregion

                #region 启动接收

                //关闭接收程序
                //if (this.threadReceive != null && this.threadReceive.IsAlive)
                //{
                //    this.threadReceive.Abort();
                //    this.threadReceive = null;
                //}
                //清空接收队列
                if (queReceiveMsg != null)
                {
                    queReceiveMsg.Clear();
                    queReceiveMsg = new Queue();

                    ReceiveList.Clear();
                    ReceiveList = new List<string>();
                }
                //初始化接收线程
                //this.threadReceive = new Thread(new ThreadStart(Thread_ReceiveMethod));
                //this.threadReceive.IsBackground = true;
                //this.threadReceive.Start();

                #endregion
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
        }

        /// <summary>
        /// 判断结果
        /// </summary>
        /// <param name="lstDefineFlower"></param>
        private Boolean CheckFlow(List<DefineFlower> lstDefineFlower, int writeTime, ref string errorCode)
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

                    string log = string.Empty;

                    #region 取出消息

                    string msg = string.Empty;
                    for (int i = 0; i < defineFlower.ReceiveNum; i++)
                    {
                        if (queReceiveMsg.Count != 0)
                        {
                            msg += queReceiveMsg.Dequeue() + "";
                        }
                    }

                    defineFlower.ReceiveMsg = msg.ToUpper();

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

                    errorCode += defineFlower.SendCmd + "=" + defineFlower.ReceiveMsg + "\r\n";

                    #endregion

                    if (defineFlower.ReceiveNum == 0)
                    {
                        #region 没有回复的帧

                        Boolean result = (defineFlower.ReceiveMsg == string.Empty) ? true : false;
                        log = string.Format("{0}{1}", defineFlower.FlowName, (result) ? "成功!" : "失败!");

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
                            result |= (defineFlower.ReceiveMsg.IndexOf(receiveCmd) >= 0);
                        }
                        log = string.Format(defineFlower.ReceiveMsg + "{0}{1}", defineFlower.FlowName, (result) ? "成功!" : "失败!");

                        finalResult &= result;

                        #endregion
                    }
                    AddMessage(log);

                    if (finalResult == false) break;
                }

                //显示最终结果
                if (finalResult)
                {
                    //this.Invoke(this.changeColorDelegate, new object[] { Color.Green });
                }
                else
                {
                    if (writeTime == configer.WriteTimes)
                    {
                        this.Invoke(this.changeColorDelegate, new object[] { Color.Red });
                        AddMessage(this.tcuPath.CarType + "写入失败,退出!");
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
                finalResult = false;

                //显示最终结果
                if (finalResult)
                {
                    this.Invoke(this.changeColorDelegate, new object[] { Color.Red });
                }
                else
                {
                    if (writeTime == configer.WriteTimes)
                    {
                        this.Invoke(this.changeColorDelegate, new object[] { Color.Red });
                        AddMessage(this.tcuPath.CarType + "写入失败,退出!");
                    }
                }
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
        /// 解析bin文件
        /// </summary>
        private byte[] ReadBin(string filePath)
        {
            byte[] binchar = new byte[] { };
            FileStream Myfile = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader binreader = new BinaryReader(Myfile);
            int file_len = (int)Myfile.Length;//获取bin文件长度 
            //byte b = byte.Parse(Convert.ToInt64("01", 16) + "");
            binchar = binreader.ReadBytes(file_len);

            return binchar;
        }



        /// <summary>
        /// 关闭设备
        /// </summary>
        unsafe private void CloseDevice()
        {
            try
            {
                if (m_bOpen == 1)
                {
                    //关闭设备
                    VCI_CloseDevice(configer.DevType, configer.DevInd);
                    m_bOpen = 0;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
        }

        /// <summary>
        /// 接收数据的线程
        /// </summary>
        unsafe private void Thread_ReceiveMethod()
        {
            ReceiveMethod();
        }

        /// <summary>
        /// 接收数据
        /// </summary>
        unsafe private void ReceiveMethod()
        {
            while (true)
            {
                try
                {
                    
                }
                catch (Exception ex)
                {
                    //if (!ex.Message.Contains("正在中止线程") && !ex.Message.Contains("Thread was being aborted"))                         logger.Error(ex.Message + "***" + ex.StackTrace);
                }
            }
        }


        /// <summary>
        /// 接收数据
        /// </summary>
        unsafe private void ReceiveMethod2(bool isRec)
        {
            try
            {               
                //判断接收区是否有数据
                UInt32 res = new UInt32();
                res = VCI_GetReceiveNum(configer.DevType, configer.DevInd, this.tcuPath.CANIND);
                if (res == 0) return;
                //分配内存
                UInt32 con_maxlen = 50;
                IntPtr pt = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(VCI_CAN_OBJ)) * (Int32)con_maxlen);
                //接收数据
                res = VCI_Receive(configer.DevType, configer.DevInd, this.tcuPath.CANIND, pt, con_maxlen, -1);

                for (UInt32 i = 0; i < res; i++)
                {
                    StringBuilder str = new StringBuilder();

                    VCI_CAN_OBJ obj = (VCI_CAN_OBJ)Marshal.PtrToStructure((IntPtr)((UInt32)pt + i * Marshal.SizeOf(typeof(VCI_CAN_OBJ))), typeof(VCI_CAN_OBJ));

                    if (obj.ID != this.tcuPath.ResponseAddress) continue;

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

                    if (isRec)
                    {
                        //把关键回复记入到结果队列，供后面判断刷写结果
                        queReceiveMsg.Enqueue(str + "");
                    }
                    ReceiveList.Add(str + "");
                    Log.writeTxt(str + "", filePath);
                }
                Marshal.FreeHGlobal(pt);
            }
            catch (Exception ex)
            {
                //if (!ex.Message.Contains("正在中止线程") && !ex.Message.Contains("Thread was being aborted"))                         logger.Error(ex.Message + "***" + ex.StackTrace);
                Log.writeTxt(ex.Message + "***" + ex.StackTrace, filePath);
            }
        }

        unsafe private List<DefineFlower> Send(byte[] DirerByte, byte[] BinByte,byte[] CalByte)
        {                   

            return null;
        }

        /// <summary>
        /// 发送并数据
        /// </summary>
        /// <param name="vco"></param>
        unsafe private void SendData(VCI_CAN_OBJ vco)
        {
            //设置CAN卡的参数
            int nTimeOut = 3000;

            VCI_SetReference(configer.DevType, configer.DevInd, this.tcuPath.CANIND, 4, (byte*)&nTimeOut);
            //发送
            if (VCI_Transmit(configer.DevType, configer.DevInd, this.tcuPath.CANIND, ref vco, 1) == 0)
            {
                Log.writeTxt("发送失败：" + vco.Data[0].ToString("X2") + " " + vco.Data[1].ToString("X2") + " " + vco.Data[2].ToString("X2") + " " + vco.Data[3].ToString("X2") + " " + vco.Data[4].ToString("X2") + " " + vco.Data[5].ToString("X2") + " " + vco.Data[6].ToString("X2") + " " + vco.Data[7].ToString("X2"), filePath);
                return;
            }
            Log.writeTxt(string.Format("0x{0} ", System.Convert.ToString((Int32)vco.ID, 16)) + " " + vco.Data[0].ToString("X2") + " " + vco.Data[1].ToString("X2") + " " + vco.Data[2].ToString("X2") + " " + vco.Data[3].ToString("X2") + " " + vco.Data[4].ToString("X2") + " " + vco.Data[5].ToString("X2") + " " + vco.Data[6].ToString("X2") + " " + vco.Data[7].ToString("X2"), filePath);
        }

        /// <summary>
        /// 处理TCU回复的数据
        /// </summary>
        /// <param name="res">判断条件</param>
        /// <param name="sleepTime">等待接收时间</param>
        /// <param name="vco">发送结束命令</param>
        /// <param name="isReceiveList">是否把接收到的数据写入到queReceiveMsg结果判断中</param>
        /// <returns></returns>
        unsafe private bool IsSend(string res, int sleepTime, VCI_CAN_OBJ vco, bool isCheck)
        {
            bool b = true;
            //如果回复数据包含 “24”说明通讯中断，结束刷写
            int count = 0;
            //等待接收数据，如果超过了60秒，结束刷写
            while (!ReceiveList[ReceiveList.Count - 1].Contains(res))
            {
                Thread.Sleep(sleepTime);
                ReceiveMethod2(isCheck);
                count += sleepTime;

                if (count > 60000)
                {
                    b = false;
                    break;
                }
            }
            if (!b)
            {
                vco.Data[0] = 2;
                vco.Data[1] = 17;
                vco.Data[2] = 1;
                vco.Data[3] = 170;
                vco.Data[4] = 170;
                vco.Data[5] = 170;
                vco.Data[6] = 170;
                vco.Data[7] = 170;
                SendData(vco);
                Thread.Sleep(50);
                ReceiveMethod2(true);
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
        /// 通过seed计算得到key
        /// </summary>
        /// <param name="hbSeed"></param>
        /// <param name="lbSeed"></param>
        /// <returns></returns>
        private byte[] SecurityAccess(string hbSeed, string lbSeed)
        {
            ////切分定义帧
            //string[] sendCmds = strSeed.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            ////转换成16进制
            //string[] seed = new string[4];
            //for (int i = 3; i < 7; i++)
            //{
            //    //vco.Data[i] = byte.Parse(Convert.ToInt64((sendCmds[i]) + "", 16) + "");
            //    //bf[i] = vco.Data[i];
            //    seed[i - 3] = Convert.ToString(Convert.ToInt64((sendCmds[i]) + "", 16), 2).PadLeft(8, '0');
            //}

            string HB1;
            string LB1;
            string HB2;
            string LB2;

            HB1 = Convert.ToString(Convert.ToInt64(hbSeed, 16), 2).PadLeft(8, '0').Substring(3, 5) + Convert.ToString(Convert.ToInt64(hbSeed, 16), 2).PadLeft(8, '0').Substring(0, 3);
            LB1 = Convert.ToString(Convert.ToInt64(lbSeed, 16), 2).PadLeft(8, '0').Substring(3, 5) + Convert.ToString(Convert.ToInt64(lbSeed, 16), 2).PadLeft(8, '0').Substring(0, 3);
            char[] HBs = new char[8];
            char[] LBs = new char[8];
            int c = 0;
            foreach (char item in HB1)
            {
                HBs[c] = item;
                c++;
            }

            c = 0;
            foreach (char item in LB1)
            {
                LBs[c] = item;
                c++;
            }

            HB2 = HBs[1].ToString() + HBs[0].ToString() + HBs[3].ToString() + HBs[2].ToString() + HBs[5].ToString() + HBs[4].ToString() + HBs[7].ToString() + HBs[6].ToString();
            LB2 = LBs[1].ToString() + LBs[0].ToString() + LBs[3].ToString() + LBs[2].ToString() + LBs[5].ToString() + LBs[4].ToString() + LBs[7].ToString() + LBs[6].ToString();
            HB1 = HB2.Substring(5, 3) + LB2.Substring(0, 5);
            LB1 = LB2.Substring(5, 3) + HB2.Substring(0, 5);

            char[] Coef1 = new char[8] { '0', '0', '0', '1', '0', '1', '0', '0' };
            char[] Coef2 = new char[8] { '0', '0', '1', '0', '0', '0', '0', '0' };

            c = 0;
            foreach (char item in HB1)
            {
                HBs[c] = (char)(item ^ Coef1[c]);
                HBs[c] = (char)(HBs[c] ^ '1');
                c++;
            }
            c = 0;
            foreach (char item in LB1)
            {
                LBs[c] = (char)(item ^ Coef2[c]);
                LBs[c] = (char)(LBs[c] ^ '1');
                c++;
            }

            HB1 = HBs[0].ToString() + HBs[1].ToString() + HBs[2].ToString() + HBs[3].ToString() + HBs[4].ToString() + HBs[5].ToString() + HBs[6].ToString() + HBs[7].ToString();
            LB1 = LBs[0].ToString() + LBs[1].ToString() + LBs[2].ToString() + LBs[3].ToString() + LBs[4].ToString() + LBs[5].ToString() + LBs[6].ToString() + LBs[7].ToString();

            byte[] bs = new byte[2];
            bs[0] = byte.Parse(Convert.ToInt32(HB1, 2) + "");
            bs[1] = byte.Parse(Convert.ToInt32(LB1, 2) + "");
            return bs;
        }

        #region 打印1
        PrintInfo PrtInfo;
        private bool Print1(Object tag)
        {
            try
            {
                this.printDocument1.OriginAtMargins = false;//启用页边距            
                this.pageSetupDialog1.EnableMetric = true; //以毫米为单位
                this.printDialog1.PrinterSettings.PrinterName = System.Configuration.ConfigurationSettings.AppSettings["print1"];
                string printname = printDocument1.PrinterSettings.PrinterName;
                PrintPageSize page = new PrintPageSize();
                page.SetPrintForm(printname, "dianchibiaoqian", 700, 200);
                foreach (PaperSize ps in printDocument1.PrinterSettings.PaperSizes)
                {
                    if (ps.PaperName.Equals("dianchibiaoqian"))
                        printDocument1.DefaultPageSettings.PaperSize = ps;
                }

                PrtInfo = (PrintInfo)tag;
                dataBind(PrtInfo);

                //PrintController printController = new StandardPrintController();
                //printDocument1.PrintController = printController;
                //this.printDocument1.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            return DoPrint1();
        }

        private bool DoPrint1()
        {
            bool success = true;
            try
            {
                dataBind(PrtInfo);
                PrintController printController = new StandardPrintController();
                printDocument1.PrintController = printController;
                this.printDocument1.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                success = false;
            }
            return success;
        }


        private void dataBind(PrintInfo info)
        {
            if (info.Barcode != "")
            {
                MemoryStream ms = GetQRCode(info.Barcode);
                //this.erweima.Image = Image.FromStream(ms);
            }
            //this.jzh.Text = b1.TypeID;
            //this.zth22.Text = b1.RecognitionId;
            //this.xh.Text = string.Format("{0}/{1}", b1.PrintId.ToString(), b1.PlanNum.ToString());
            //this.bh.Text = b1.BatteryCode;
        }

        public MemoryStream GetQRCode(string strContent)
        {
            MemoryStream ms = new MemoryStream();
            ErrorCorrectionLevel Ecl = ErrorCorrectionLevel.M; //误差校正水平   
            string Content = strContent;//待编码内容  
            QuietZoneModules QuietZones = QuietZoneModules.Two;  //空白区域               
            int ModuleSize = 12;//大小  
            var encoder = new QrEncoder(Ecl);
            QrCode qr;
            if (encoder.TryEncode(Content, out qr))//对内容进行编码，并保存生成的矩阵  
            {
                var render = new GraphicsRenderer(new FixedModuleSize(ModuleSize, QuietZones));
                render.WriteToStream(qr.Matrix, ImageFormat.Png, ms);
            }
            return ms;
        }

        private void groupPrint_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.Clear(groupPrint.BackColor);
        }
        #endregion

        private void btnConfig_Click(object sender, EventArgs e)
        {
            FrmConfig frmConfig = new FrmConfig(localConnectionString);
            frmConfig.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
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
                //清空接收队列
                if (queReceiveMsg != null)
                {
                    queReceiveMsg.Clear();
                    queReceiveMsg = new Queue();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
        }

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
                    VCI_CloseDevice(configer.DevType, configer.DevInd);

                    this.Invoke(this.showPicDelegate, new object[] { pictureBox8, Application.StartupPath + "\\img\\" + "process-grey_03.png" });
                    this.Invoke(this.showPicDelegate, new object[] { pictureBox9, Application.StartupPath + "\\img\\" + "process-grey_05.png" });
                    this.Invoke(this.showPicDelegate, new object[] { pictureBox7, Application.StartupPath + "\\img\\" + "process-grey_07.png" });
                    this.Invoke(this.showPicDelegate, new object[] { pictureBox10, Application.StartupPath + "\\img\\" + "process-grey_09.png" });
                    this.Invoke(this.showPicDelegate, new object[] { pictureBox11, Application.StartupPath + "\\img\\" + "process-grey_11.png" });

                    this.Invoke(this.progressBarDelegate, new object[] { 0, 0 });

                    //清空数据
                    this.ListMsg.Items.Clear();
                    this.lblVIN.Text = string.Empty;
                    this.tcuPath = new TCUPath();
                    //设置背景色
                    this.ListMsg.BackColor = Color.White;
                    //停止接收线程
                    if (this.threadReceive != null && this.threadReceive.IsAlive)
                    {
                        this.threadReceive.Abort();
                        this.threadReceive = null;
                    }
                    //清空接收队列
                    if (queReceiveMsg != null)
                    {
                        queReceiveMsg.Clear();
                        queReceiveMsg = new Queue();
                    }
                }              
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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

                //清空接收队列
                if (queReceiveMsg != null)
                {
                    queReceiveMsg.Clear();
                    queReceiveMsg = new Queue();
                }
                //this.Close();
                Application.Exit();  
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            FrmHistory frmHistory = new FrmHistory(localConnectionString);
            frmHistory.Show();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            FrmLog frmLog = new FrmLog();
            frmLog.Show();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            FrmExport frmExport = new FrmExport(localConnectionString);
            frmExport.Show();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #region 界面元素

        /// <summary>
        /// 在界面上显示
        /// </summary>
        /// <param name="txt"></param>
        private void AddMessage(string txt)
        {
            try
            {
                //logger.Info(txt);
                this.Invoke(this.showMessageDelegate, new object[] { txt,"" });
                Log.writeTxt(txt, filePath);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
        }
        /// <summary>
        /// 显示消息
        /// </summary>
        /// <param name="txt"></param>
        private void ShowMessage(string txt, string place)
        {
            try
            {
                if (place == "")
                {
                    this.ListMsg.Items.Add("[" + DateTime.Now + "]" + txt);
                    ListMsg.SelectedIndex = ListMsg.Items.Count - 1;
                    //this.lblVIN.Text = "检测完成";
                }
                else
                {
                    this.lblVIN.Text = txt;
                }
                
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
        }
        /// <summary>
        /// 显示消息
        /// </summary>
        /// <param name="txt"></param>
        private void PicMessage(PictureBox picBox,string path)
        {
            try
            {
                picBox.Image = Image.FromFile(path);
                //picBox.Image = list.Images[num];
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
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
                logger.Error(ex.Message + "***" + ex.StackTrace);
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
                this.ListMsg.BackColor = color;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
        }
        /// <summary>
        /// 设置进度条
        /// </summary>
        /// <param name="value"></param>
        private void SetBar(int value,int max)
        {
            try
            {
                this.progressBar1.Maximum = max;
                this.progressBar1.Value = value;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
        }

        /// <summary>
        /// 检测网络状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timCheckNetStart_Tick(object sender, EventArgs e)
        {
            if (!canUse)
            {
                return;
            }
            else
            {
                lock (olock)
                {
                    if (canUse)
                    {
                        canUse = false;
                    }
                    else
                    {
                        return;
                    }
                }
            }

            try
            {
                //检查大线激活岗网络状态
                string mainNetImg = Ping(configer.MES_IP) ? @"img\Green.jpg" : @"img\Red.jpg";
                //this.picMainNet.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + mainNetImg);
                //检查返修岗网络状态
                string repaireNetImg = Ping(configer.Repaire_IP) ? @"img\Green.jpg" : @"img\Red.jpg";
                //this.picRepaireNet.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + repaireNetImg);
                //检查大线激活岗数据库连接状态
                string mainDBImg = CheckConnection(configer.MESCnnStr) ? @"img\Green.jpg" : @"img\Red.jpg";
                //this.picMainDB.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + mainDBImg);
                //检查返修岗数据库连接状态
                string repaireDBImg = CheckConnection(configer.RDBCnnStr) ? @"img\Green.jpg" : @"img\Red.jpg";
                //this.picRepaireDB.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + repaireDBImg);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }
            finally
            {
                canUse = true;
            }
        }
        /// <summary>
        /// 检查网络状态
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        private bool Ping(string ip)
        {
            bool result = false;
            try
            {
                System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
                System.Net.NetworkInformation.PingOptions options = new System.Net.NetworkInformation.PingOptions();
                options.DontFragment = true;
                string data = "Test Data!";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 1000; // Timeout 时间，单位：毫秒  
                System.Net.NetworkInformation.PingReply reply = p.Send(ip, timeout, buffer, options);
                result = (reply.Status == System.Net.NetworkInformation.IPStatus.Success) ? true : false;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }

            return result;
        }
        /// <summary>
        /// 检查连接状态
        /// </summary>
        /// <param name="connstr"></param>
        /// <returns></returns>
        private bool CheckConnection(string connstr)
        {
            bool result = false;

            try
            {
                result = configer.CheckConnection(connstr);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "***" + ex.StackTrace);
            }

            return result;
        }

        #endregion

       

    }
}
