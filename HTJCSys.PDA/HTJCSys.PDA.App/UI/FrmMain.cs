using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using COM;
using MDL;
using DAL;
using System.Reflection;

namespace HTJCSys.PDA
{
    public partial class FrmMain : Form
    {
        /// <summary>
        /// 实例化UserInfoDAL类
        /// </summary>
        UserInfoDAL userDAL = new UserInfoDAL();
        /// <summary>
        /// 实例化LUserInfoDAL类
        /// </summary>
        LUserInfoDAL lUserDAL = new LUserInfoDAL();
        /// <summary>
        /// 实例化DeviceInfoDAL类
        /// </summary>
        DeviceInfoDAL deviceDAL = new DeviceInfoDAL();
        /// <summary>
        /// 实例化LDeviceInfoDAL类
        /// </summary>
        LDeviceInfoDAL lDeviceDAL = new LDeviceInfoDAL();
        /// <summary>
        /// 实例化ProductInfoDAL类
        /// </summary>
        ProductInfoDAL productDAL = new ProductInfoDAL();
        /// <summary>
        /// 实例化LProductInfoDAL类
        /// </summary>
        LProductInfoDAL lProductDAL = new LProductInfoDAL();
        /// <summary>
        /// 实例化ProductBomInfoDAL类
        /// </summary>
        ProductBomInfoDAL productBomDAL = new ProductBomInfoDAL();
        /// <summary>
        /// 实例化LProductBomInfoDAL类
        /// </summary>
        LProductBomInfoDAL lProductBomDAL = new LProductBomInfoDAL();
        /// <summary>
        /// 实例化MaterialFieldDAL类
        /// </summary>
        MaterialFieldDAL filedDAL = new MaterialFieldDAL();
        /// <summary>
        /// 实例化LMaterialFieldDAL类
        /// </summary>
        LMaterialFieldDAL lFieldDAL = new LMaterialFieldDAL();
        LPedalResultDAL lPedalResultDAL = new LPedalResultDAL();
        LBrakepumpResultDAL lBrakeResultDAL = new LBrakepumpResultDAL();
        /// <summary>
        ///  实例化本地LRadiatorResultDAL类
        /// </summary>
        LRadiatorResultDAL lRadiatorResultDAL = new LRadiatorResultDAL();
        /// <summary>
        ///  实例化本地LFrontAxleResultDAL类
        /// </summary>
        LFrontAxleResultDAL lFrontAxleResultDAL = new LFrontAxleResultDAL();
        /// <summary>
        ///  实例化本地LRearAxleResultDAL类
        /// </summary>
        LRearAxleResultDAL lRearAxleResultDAL = new LRearAxleResultDAL();
        /// <summary>
        ///  实例化本地LAuxiliaryFasiaResultDAL类
        /// </summary>
        LAuxiliaryFasiaResultDAL lAuxiliaryFasiaResultDAL = new LAuxiliaryFasiaResultDAL();
        /// <summary>
        ///  实例化本地LBatchNoDAL类
        /// </summary>
        LBatchNoDAL lBatchDAL = new LBatchNoDAL();

        //Thread threadRefreshTime;
        /// <summary>
        /// 加载信息
        /// </summary>
        public delegate void DeleteFrmMainLoad();
        /// <summary>
        /// 数据上传
        /// </summary>
        public delegate void DeleteDataUpload();
        /// <summary>
        /// 数据上传的时间间隔（单位：分钟）
        /// </summary>
        public static int Minutes = 2;
        /// <summary>
        /// 本地数据上传线程ThreadStart
        /// </summary>
        public static ThreadStart ThreadUploadDataStart = null;
        /// <summary>
        /// 本地数据上传线程
        /// </summary>
        public static Thread ThreadUploadData = null;

        public static bool ThreadUploadFlag = true;
        public static ThreadState ThreadUploadDataState = ThreadState.Stop;

        #region 初始化
        public FrmMain()
        {
            InitializeComponent();

            this.btnStart.Click +=new EventHandler(btnStart_Click);
            this.btnBatch.Click+=new EventHandler(btnBatch_Click);
            this.bntBack.Click+=new EventHandler(bntBack_Click);
            this.btnDnData.Click+=new EventHandler(btnDnData_Click);
            this.btnUpData.Click+=new EventHandler(btnUpData_Click);
            this.btnExit.Click+=new EventHandler(btnExit_Click);

            this.lblTitle.Text = "";//产品名称
            this.lblUser.Text = "";//用户工号
            this.lblStation.Text = "";//工位信息
            this.lblDevice.Text = "";

            this.lblVersion.Text = "Version：v" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            ThreadUploadFlag = true;
            //窗体加载方法
            LoadForm();
        }
        #endregion

        #region 窗体加载事件
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                //加载扫描信息
                XmlHelper xml = new XmlHelper();
                BaseVariable.ScanIsSound = xml.SelectValue("/Root/Sys/ScanIsSound") == "1" ? true : false;
                BaseVariable.ScanIsShake = xml.SelectValue("/Root/Sys/ScanIsShake") == "1" ? true : false;
                BaseVariable.ScanIsLED = xml.SelectValue("/Root/Sys/ScanIsLED") == "1" ? true : false;

                CLog.WriteStationLog("login", "用户登录");

                ThreadUploadDataStart = new ThreadStart(UploadData);
                ThreadUploadData = new Thread(ThreadUploadDataStart);
                ThreadUploadData.IsBackground = true;
                ThreadUploadData.Start();
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog("[FrmMain.FrmMainLoad]" + ex.Message);
            }
        } 
        #endregion

        #region 窗体加载方法
        /// <summary>
        /// 窗体加载方法
        /// </summary>
        public void LoadForm()
        {
            try
            {
                this.lblUser.Text = BaseVariable.UserEntity.UserName;//用户工号
                this.lblTitle.Text = BaseVariable.DeviceEntity.ProductType;//产品类型
                this.lblDevice.Text = BaseVariable.DeviceEntity.DeviceID;//设备编号
                this.lblStation.Text = BaseVariable.DeviceEntity.StationID;//工位信息
                string TableName = "";
                switch (BaseVariable.DeviceEntity.ProductType)
                {
                    case "制动泵":
                        TableName = "brakepumpresult";
                        break;
                    case "踏板":
                        TableName = "pedalresult";
                        break;
                    case "散热器":
                        TableName = "radiatorresult";
                        break;
                    case "前桥":
                        TableName = "frontaxleresult";
                        break;
                    case "后桥":
                        TableName = "rearaxleresult";
                        break;
                    case "副仪表板":
                        TableName = "AuxiliaryFasiaResult";
                        break;
                }
                BaseVariable.ResultTableName = TableName.ToString();
                //threadRefreshTime = new Thread(new ThreadStart(RefreshTimer));
                //threadRefreshTime.Start();
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog("[FrmMain.LoadFrm]"+ex.Message);
            }
        }
        #endregion

        #region 批次设置
        /// <summary>
        /// 批次设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBatch_Click(object sender, EventArgs e)
        {
            try
            {
                FrmBatch form = new FrmBatch();
                form.frmMain = this;
                form.ShowDialog();
                form.Dispose();
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog("[FrmMain.btnBatch]" + ex.Message);
            }
        }
        #endregion

        #region 扫描追溯
        /// <summary>
        /// 扫描追溯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                FrmScan form = new FrmScan();
                form.frmMain = this;
                form.ShowDialog();
                form.Dispose();
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog("[FrmMain.btnScan]" + ex.Message);
            }
        } 
        #endregion

        #region 返修设置
        /// <summary>
        /// 返修设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bntBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Opt.GlobalNetStatus())
                {
                    MessageBox.Show("离线模式下不能记录返修,待在线模式下返修!","系统提示",MessageBoxButtons.OK,MessageBoxIcon.Asterisk,MessageBoxDefaultButton.Button1);
                }
                else
                {
                    FrmRepair form = new FrmRepair();
                    form.frmMain = this;
                    form.ShowDialog();
                    form.Dispose();
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog("[FrmMain.bntBack]" + ex.Message);
            }
        } 
        #endregion

        #region 下载数据
        /// <summary>
        /// 下载数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDnData_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Opt.GlobalNetStatus())
                {
                    MessageBox.Show("离线模式下不能下载数据,待在线模式下下载数据!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    FrmDataSync form = new FrmDataSync(SyncType.Download);
                    form.ShowDialog();
                    form.Dispose();
                    LoadForm();

                    //加载产品特征码列表
                    Opt.LoadProductInfo();
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog("[FrmMain.btnDnData]" + ex.Message);
            }
        } 
        #endregion

        #region 上传数据
        /// <summary>
        /// 上传数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpData_Click(object sender, EventArgs e)
        {
            try
            {
                if (!BaseVariable.NetworkStatus || !BaseVariable.ServerStatus)
                {
                    MessageBox.Show("离线模式下不能上传数据,待在线模式下返修!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    int BatchCount = lBatchDAL.GetRecordCount("");

                    int BrakeResultCount = lBrakeResultDAL.GetRecordCount("");
                    int PedalResultCount = lPedalResultDAL.GetRecordCount("");
                    int RadiatorResultCount = lRadiatorResultDAL.GetRecordCount("");

                    //添加前桥和后桥
                    int FrontAxleResultCount = lFrontAxleResultDAL.GetRecordCount("");
                    int RearAxleResultCount = lRearAxleResultDAL.GetRecordCount("");
                    //添加副仪表板
                    int AuxiliaryFasiaResultCount = lAuxiliaryFasiaResultDAL.GetRecordCount("");

                    int total = BatchCount + BrakeResultCount + PedalResultCount + RadiatorResultCount + FrontAxleResultCount + RearAxleResultCount + AuxiliaryFasiaResultCount;
                    if (total > 0)
                    {
                        FrmDataSync form = new FrmDataSync(SyncType.Upload);
                        form.ShowDialog();
                        form.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("没有数据需上传", "上传提示");
                    }
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog("[FrmMain.btnUpData]" + ex.Message);
            }
        } 
        #endregion

        #region 退出
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                TipDataUpload();
                if (MessageBox.Show("确定退出吗?", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    CLog.WriteStationLog("login", "退出登录");
                    //XmlHelper xml = new XmlHelper();
                    //xml.UpdateInnerText("/Root/User/ProductType", BaseVariable.DeviceEntity.ProductType);
                    //xml.UpdateInnerText("/Root/User/ProductCode", BaseVariable.ProductInfo.ProductCode);
                    if (ThreadUploadData != null || ThreadUploadFlag )
                    {
                        ThreadUploadFlag = false;
                        FrmLoginWait frmLoginWait = new FrmLoginWait(this, 1, "正在处理数据，请稍候……");
                        frmLoginWait.ShowDialog();
                        ThreadUploadData = null;
                    }

                    Form ower = this.Owner;
                    ower.Close();
                    ower.Dispose();
                }
            }
            catch (Exception ex)
            {
                Form ower = this.Owner;
                ower.Close();
                ower.Dispose();
                CLog.WriteErrLog("[FrmMain.btnExit]" + ex.Message);
            }
        } 
        #endregion

        #region 启动的Timer
        /// <summary>
        /// 启动的Timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tTime_Tick(object sender, EventArgs e)
        {
            try
            {
                tTime.Enabled = false;
                if (BaseVariable.IsRunFirst)
                {
                    MessageBox.Show("第一次使用请先下载数据！！！");
                }
                else
                {
                    //加载产品特征码列表
                    Opt.LoadProductInfo();
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
        } 
        #endregion

        #region 数据下载
        /// <summary>
        /// 数据下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerDownLoad_Tick(object sender, EventArgs e)
        {
            try
            {
                timerDownLoad.Enabled = false;
                if (!BaseVariable.NetworkStatus || !BaseVariable.ServerStatus)
                {
                    MessageBox.Show("离线模式下不能下载数据,待在线模式下返修!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    FrmDataSync form = new FrmDataSync(SyncType.Download);
                    form.ShowDialog();
                    form.Dispose();
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
        }
        #endregion

        #region 数据上传提示
        /// <summary>
        /// 数据上传提示
        /// </summary>
        public void TipDataUpload()
        {
            try
            {
                string productType = BaseVariable.DeviceEntity.ProductType;
                //制动泵
                int BrakeResultCount = 0;
                //踏板
                int PedalResultCount = 0;
                //散热器
                int RadiatorResultCount = 0;
                int BatchCount = 0;
                //添加前桥和后桥
                int FrontAxleResultCount = 0;
                int RearAxleResultCount = 0;
                //添加副仪表板
                int AuxiliaryFasiaResultCount = 0;
                switch (productType)
                {
                    case "踏板":
                        PedalResultCount = lPedalResultDAL.GetRecordCount("");
                        break;
                    case "制动泵":
                        BrakeResultCount = lBrakeResultDAL.GetRecordCount("");
                        break;
                    case "散热器":
                        RadiatorResultCount = lRadiatorResultDAL.GetRecordCount("");
                        break;
                    case "前桥":
                        FrontAxleResultCount = lFrontAxleResultDAL.GetRecordCount("");
                        break;
                    case "后桥": 
                        RearAxleResultCount = lRearAxleResultDAL.GetRecordCount("");
                        break;
                    case "副仪表板":
                        AuxiliaryFasiaResultCount = lAuxiliaryFasiaResultDAL.GetRecordCount("");
                        break;
                }

                BatchCount = lBatchDAL.GetRecordCount("");
                int total = BatchCount + BrakeResultCount + PedalResultCount + RadiatorResultCount + FrontAxleResultCount + RearAxleResultCount + AuxiliaryFasiaResultCount;
                if (!Opt.GlobalNetStatus() && total > 0)
                {
                    string msg = string.Format("当前有{0}条数据需要上传,请在网络好的情况下手动上传!", total);
                    MessageBox.Show(msg, "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    return;
                }
                if (total > 0)
                {
                    string msg = string.Format("当前有{0}条数据需要上传,是否现在上传?", total);
                    if (MessageBox.Show(msg, "温馨提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        FrmDataSync form = new FrmDataSync(SyncType.Upload);
                        form.ShowDialog();
                        form.Dispose();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog("Use UploadTip Exception:"+ex.Message);
            }
        } 
        #endregion

        #region 更新时间的线程

        #region 更新时间线程调用方法
        /// <summary>
        /// 更新时间线程调用方法
        /// </summary>
        private void RefreshTimer()
        {
            System.Threading.Timer timer = new System.Threading.Timer(new System.Threading.TimerCallback(RefreshTime), null, 0, 1000);
        }
        #endregion

        #region 更新时间的方法
        /// <summary>
        /// 更新时间的方法
        /// </summary>
        /// <param name="state"></param>
        void RefreshTime(Object state)
        {
            try
            {
                this.Invoke((EventHandler)delegate
                {
                    string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    //this.lblTime.Text = time;
                    //this.pgbBattery.Value = PowerHelper.GetBattery();
                });
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
        }
        #endregion 

        #endregion

        #region 上传本地数据
        #region 上传数据
        /// <summary>
        /// 上传数据
        /// </summary>
        public static void UploadData()
        {
            try
            {
                ThreadUploadDataState = ThreadState.Running;
                //CLog.WriteSysLog("UploadData:Start...");
                while (ThreadUploadFlag)
                {
                    try
                    {
                        int BatchCount = GetBatchCount();
                        int MaterialCount = GetMarterialCount();
                        bool BatchStatus = BatchCount > 0;
                        bool MaterialStatus = MaterialCount > 0;
                        if (!BatchStatus && !MaterialStatus)
                        {
                            int Time = 60 * Minutes;
                            for (int i = 0; i < Time; i++)
                            {
                                if (!ThreadUploadFlag)
                                {
                                    break;
                                }
                                Thread.Sleep(1000);
                            }
                            if (ThreadUploadFlag)
                            {
                                continue;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else if (BatchStatus && Opt.GlobalNetStatus())
                        {
                            UploadBatchTable();
                        }
                        else if (MaterialStatus && Opt.GlobalNetStatus())
                        {
                            UploadMaterialTable();
                        }
                    }
                    catch (Exception ex)
                    {
                        CLog.WriteErrLog("UploadDataing Exception:" + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog("UploadData Exception:" + ex.Message);
            }
            ThreadUploadDataState = ThreadState.Stop;
        }
        #endregion

        #region 获取批次的记录条数
        /// <summary>
        /// 获取批次的记录条数
        /// </summary>
        /// <returns></returns>
        public static int GetBatchCount()
        {
            try
            {
                string sql = "SELECT COUNT(tid) FROM BatchNo;";
                int count = LocalDbDAL.ExecuteScaler(sql) == null && LocalDbDAL.ExecuteScaler(sql).ToString() == "0" ? (int)LocalDbDAL.ExecuteScaler(sql) : 0;
                return count;
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
                return 0;
            }
        }
        #endregion

        #region 获取当前产品的记录条数
        /// <summary>
        /// 获取当前产品的记录条数
        /// </summary>
        /// <returns></returns>
        public static int GetMarterialCount()
        {
            try
            {
                string sql = string.Format("SELECT COUNT(tid) FROM '{0}';", BaseVariable.ResultTableName);
                int count = LocalDbDAL.ExecuteScaler(sql) == null && LocalDbDAL.ExecuteScaler(sql).ToString() == "0" ? (int)LocalDbDAL.ExecuteScaler(sql) : 0;
                return count;
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
                return 0;
            }
        }
        #endregion

        #region 上传批次记录
        /// <summary>
        /// 上传批次记录
        /// </summary>
        public static void UploadBatchTable()
        {
            try
            {
                LBatchNoDAL ldal = new LBatchNoDAL();
                //获取本地批次信息
                DataTable table = ldal.GetList("").Tables[0];
                if (table == null || table.Rows.Count == 0)
                {
                    return;
                }
                BatchNoDAL dal = new BatchNoDAL();

                string IDs = dal.Upload(table);

                if (!string.IsNullOrEmpty(IDs))
                {
                    ldal.DeleteList(IDs);//上传后删除本地数据
                    CLog.WriteStationLog("Sys", "UploadBatchTable:TID->{" + IDs+"},Time:{"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"}");
                    //string[] str = IDs.Split(',');
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
        }
        #endregion

        #region 上传零件记录
        /// <summary>
        /// 上传零件记录
        /// </summary>
        public static void UploadMaterialTable()
        {
            try
            {
                string sql = string.Format("SELECT * FROM {0}", BaseVariable.ResultTableName);
                //获取当前产品的数据表
                DataTable table = LocalDbDAL.GetDataTable(sql);
                if (table==null || table.Rows.Count==0)
                {
                    return;
                }
                //向服务器发送请求，数据上传并返回上传成功的数据TID
                string IDs = ResultDAL.Upload(BaseVariable.DeviceEntity.ProductType, BaseVariable.ResultTableName, table);
                if (!string.IsNullOrEmpty(IDs))
                {
                    sql = string.Format("DELETE FROM {0} WHERE tid IN ({1});", BaseVariable.ResultTableName, IDs);
                    LocalDbDAL.ExecuteSql(sql);//上传后删除本地数据
                    CLog.WriteStationLog("Sys", "UploadMaterialTable:TID->{" + IDs+"},Time:{"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"}");
                    //string[] str = IDs.Split(',');
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
        }
        #endregion

        #endregion

        private void FrmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape) {
                this.Close();
            }
        }

    }

    public enum ThreadState
    {
        Stop = 0,
        Running = 1,
        Stoping = 2
    }
}