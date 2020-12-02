using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAL;
using MDL;
using COM;
using System.Reflection;
using XY.DataCollect.Intermec;
using XY.Util;

namespace HTJCSys.PDA
{
    public partial class FrmLogin : Form
    {
        //首先获取本机IP
        //根据IP获取设备ID及工位信息
        //选择产品类型
        //选择产品编码
        //进入系统

        DeviceInfoMDL deviceModel = null;//当前设备信息
        DeviceInfoDAL deviceDAL = new DeviceInfoDAL();
        LDeviceInfoDAL lDeviceDAL = new LDeviceInfoDAL();
        ProductInfoDAL productDAL = new ProductInfoDAL();
        UserInfoDAL UserDAL = new UserInfoDAL();
        LUserInfoDAL lUserDAL = new LUserInfoDAL();
        FrmLoginWait frmLoginWait = null;

        public delegate void delegateInit();

        public bool NetStatus = false;
        public bool ServerStatus = false;
        public FrmLogin()
        {
            InitializeComponent();
            this.lblMsg.Text = "";
            this.lblNetwork.Text = ""; 
            this.lblDevice.Text = "";
            this.txtUser.Text = "";
            this.txtPwd.Text = "";
            this.lblVersion.Text = "version:" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        #region 登录操作
        /// <summary>
        /// 登录操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                BaseVariable.NetworkStatus = NetStatus;
                BaseVariable.ServerStatus = ServerStatus;
                string UserID = this.txtUser.Text.Trim().ToString();
                string UserPwd = this.txtPwd.Text.Trim().ToString();
                UserInfoMDL UserInfo = null;
                if (!NetStatus || !ServerStatus)
                {
                    UserInfo = lUserDAL.GetModel(UserID);
                }
                else
                {
                    UserInfo = UserDAL.GetModel(UserID);
                }                
                if (UserInfo != null)
                {
                    string UserPwdMD5 = MD5.Encode(UserPwd, 32).ToUpper();
                    if (UserInfo.UserPwd.ToUpper() == UserPwdMD5)
                    {
                        BaseVariable.UserEntity = UserInfo;
                        XmlHelper xml = new XmlHelper();
                        xml.UpdateInnerText("/Root/User/UserID", UserID);
                        xml.UpdateInnerText("/Root/User/UserPwd", UserPwd);

                        FrmMain form = new FrmMain();
                        form.Owner = this;
                        form.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("密码错误");
                    }
                }
                else
                {
                    MessageBox.Show("用户不存在");
                }
            }
            catch (Exception ex)
            {
                this.lblMsg.Text = "服务器连接失败"; 
                CLog.WriteErrLog(ex.Message);
            }
        } 
        #endregion

        #region 退出程序
        /// <summary>
        /// 退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Close();
        } 
        #endregion

        #region 窗体加载事件
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
        } 
        #endregion

        #region 系统初始化
        /// <summary>
        /// 系统初始化
        /// </summary>
        public void Init()
        {
            try
            {
                InitInfo();
                InitNetwork();
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
                this.btnLogin.Enabled = false;
                this.lblMsg.Text = "未知错误";
            }
        } 
        #endregion

        #region 系统信息初始化
        /// <summary>
        /// 系统信息初始化
        /// </summary>
        public void InitInfo()
        {
            try
            {
                //BaseVariable.InitXmlVar();//初始化基础变量
                XmlHelper xml = new XmlHelper();
                BaseVariable.RequestURL = xml.SelectValue("/Root/Server/APIURL");
                bool IsRunFirst = xml.SelectValue("/Root/Local/IsRunFirst") == "0" ? false : true;//判断是否是第一次运行
                if (IsRunFirst)
                {
                    bool IsCreateTable = false;
                    if (LocalDbDAL.CreateDB())
                    {
                        IsCreateTable = LocalDbDAL.CreateTable();
                    }
                    if (IsCreateTable)
                    {
                        xml.UpdateInnerText("/Root/Local/DbIsCreated", "1");
                    }
                    //初始化xml信息
                    //创建数据库
                    //创建数据表
                    xml.UpdateInnerText("/Root/Local/IsRunFirst", "0");
                }
                BaseVariable.RequestURL = xml.SelectValue("/Root/Server/APIURL");
                BaseVariable.IsRunFirst = IsRunFirst;
                this.txtUser.Text = xml.SelectValue("/Root/User/UserID");
                this.txtPwd.Text = xml.SelectValue("/Root/User/UserPwd");
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
        } 
        #endregion

        #region 初始化网络
        /// <summary>
        /// 初始化网络
        /// </summary>
        private void InitNetwork()
        {
            try
            {
                int WiFiLevel = (int)Network.GetWifiStrengthLevel();
                if (WiFiLevel == -1)
                {
                    this.lblMsg.Text = "网络未连接";
                    NetStatus = false;
                    this.btnLogin.Text = "本地登录";
                    this.lblNetwork.Text = "离线模式";
                    GetDeviceInfo(false);//获取设备信息
                }
                else
                {
                    NetStatus = true;
                    ServerStatus = Opt.ServerConnectStatus();
                    if (!ServerStatus)
                    {
                        this.lblMsg.Text = "服务器连接失败";
                        ////this.btnLogin.Text = "登    录";
                        this.lblNetwork.Text = "离线模式";
                        this.btnLogin.Text = "本地登录";
                        GetDeviceInfo(ServerStatus);//获取设备信息
                    }
                    else
                    {
                        object obj = Opt.GetDateTime();
                        if (obj != null)//设置系统时间
                        {
                            DateTime date = DateTime.Parse(obj.ToString());
                            SystemTime.SetDate(date);
                        }
                        this.lblMsg.Text = "服务器连接成功";
                        this.lblNetwork.Text = "在线模式";
                        this.btnLogin.Enabled = true;
                        GetDeviceInfo(ServerStatus);//获取设备信息
                    }
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
        } 
        #endregion

        #region 获取设备信息
        /// <summary>
        /// 获取设备信息
        /// </summary>
        /// <param name="IsOnline"></param>
        private void GetDeviceInfo(bool IsOnline)
        {
            XmlHelper xml = new XmlHelper();
            string ip = "";
            //首先获取本机IP
            if (IsOnline)
            {
                ip = NetworkHelper.GetIpAddress();
                //ip = "192.168.0.140";//制动泵
                //ip = "192.168.0.129";//踏板
                //ip = "192.168.0.173";//前桥
                //ip = "192.168.0.174";//后桥
                xml.UpdateInnerText("/Root/Local/LocalIp", ip);
                deviceModel = deviceDAL.GetModel("","",ip);
            }
            else
            {
                if (BaseVariable.IsRunFirst)
                {
                    this.btnLogin.Enabled = false;
                    return;
                }
                ip = xml.SelectValue("/Root/Local/LocalIp");
                deviceModel = lDeviceDAL.GetModel(string.Format("DeviceIP='{0}'", ip));
            }
            if (deviceModel == null)
            {
                this.btnLogin.Enabled = false;
                MessageBox.Show("获取设备信息失败,请联系管理人员", "系统提示");
                return;
            }
            BaseVariable.DeviceEntity = deviceModel;//当前设备信息
            this.lblDevice.Text = "设备:" + deviceModel.DeviceID;
        } 
        #endregion

        #region 初始化触发器
        /// <summary>
        /// 初始化触发器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerInit_Tick(object sender, EventArgs e)
        {
            try
            {
                this.timerInit.Enabled = false;
                frmLoginWait = new FrmLoginWait(this, 0,"正在初始化数据，请稍候……");
                frmLoginWait.ShowDialog();                
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
            finally 
            {
            }
        } 
        #endregion
    }
}